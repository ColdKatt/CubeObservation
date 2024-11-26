using CubeObservation.Extensions;
using CubeObservation.Transformations;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Shaders;
using SharpGL.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace CubeObservation.Shapes
{
    /// <summary>
    /// Base class for shapes.
    /// </summary>
    internal abstract class Shape : ITransformable
    {
        protected readonly OpenGL _gl;

        protected readonly VertexBuffer _vertexBuffer;
        protected readonly VertexBufferArray _vertexBufferArray;
        protected readonly IndexBuffer _indexBuffer;
        protected readonly IndexBuffer _wireframeIndexBuffer;

        private readonly Transform _transform;

        protected List<TriangleFace> _faces;

        protected Vertex[] _vertices;
        protected ushort[] _indices;
        protected ushort[] _wireframeIndices;

        private ShaderProgram _shaderProgram;

        private uint _drawMode;
        private bool _isTransparencyEnabled;

        /// <summary>
        /// Transform of the shape.
        /// </summary>
        public Transform Transform => _transform;

        /// <summary>
        /// ShaderProgram of the shape.
        /// </summary>
        public ShaderProgram ShaderProgram
        {
            get => _shaderProgram;
            protected set
            {
                _shaderProgram = value;
                UpdateModel();
            }
        }

        /// <summary>
        /// Sets the drawing mode for the shape. Can set OpenGL.GL_FILL and OpenGL.GL_LINE values.
        /// </summary>
        public uint DrawMode
        {
            get => _drawMode;
            set
            {
                if (value != OpenGL.GL_FILL && value != OpenGL.GL_LINE) return;

                _drawMode = value;
                if (_wireframeIndices.Length == 0)
                {
                    _gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, _drawMode); // additional way to draw edges
                }
            }
        }

        public bool IsTransparencyEnabled
        {
            get => _isTransparencyEnabled;
            set
            {
                _isTransparencyEnabled = value;
                var alphaValue = _isTransparencyEnabled ? 0.5f : 1.0f;
                _shaderProgram.SetUniformFloat("alpha", alphaValue);
            }
        }

        public Shape(OpenGL gl)
        {
            _transform = new Transform();
            _transform.OnScaleChanged += UpdateModel;
            _transform.OnRotationChanged += UpdateModel;
            _transform.OnPositionChanged += UpdateModel;

            _gl = gl;

            _drawMode = OpenGL.GL_FILL;

            _vertices = new Vertex[] { };

            _indices = new ushort[] { };
            _wireframeIndices = new ushort[] { };

            _vertexBuffer = new VertexBuffer();
            _vertexBufferArray = new VertexBufferArray();
            _indexBuffer = new IndexBuffer();
            _wireframeIndexBuffer = new IndexBuffer();
        }

        /// <summary>
        /// The main method for drawing the shape. Should be called in OpenGLDraw method.
        /// </summary>
        public void Draw()
        {
            // updating scene settings
            Form1.s_Scene.ApplySceneSettingsToProgram(_shaderProgram);

            _faces.Sort((firstFace, secondFace) =>
                        Vector3.Distance(Form1.s_Scene.MainCamera.Transform.Position, firstFace.Center)
                               .CompareTo(Vector3.Distance(Form1.s_Scene.MainCamera.Transform.Position, secondFace.Center)));

            // updating buffers
            SetupBuffers(0, false, 3);

            _shaderProgram.Push(_gl, null);
            _vertexBufferArray.Bind(_gl);

            if (_drawMode == OpenGL.GL_LINE && _wireframeIndices.Length > 0)
            {
                DrawElements(_wireframeIndexBuffer, OpenGL.GL_LINES, _wireframeIndices.Length);
            }
            else
            {
                DrawElements(_indexBuffer, OpenGL.GL_TRIANGLES, _indices.Length);
            }

            _vertexBufferArray.Unbind(_gl);
            _shaderProgram.Pop(_gl, null);
        }

        protected void SetupBuffers(uint attributeIndex, bool isNormalized, int stride)
        {
            if (!_vertexBuffer.IsCreated())
            {
                _vertexBufferArray.Create(_gl);
                _vertexBuffer.Create(_gl);
                _indexBuffer.Create(_gl);
                _wireframeIndexBuffer.Create(_gl);
            }

            _vertexBufferArray.Bind(_gl);

            _vertexBuffer.Bind(_gl);
            _vertexBuffer.SetData(_gl, attributeIndex, _vertices.ToFLoatArray(), isNormalized, stride);

            _indices = _faces.IndicesToUnsignedShortArray();
            _indexBuffer.Bind(_gl);
            _indexBuffer.SetData(_gl, _indices);

            _wireframeIndexBuffer.Bind(_gl);
            _wireframeIndexBuffer.SetData(_gl, _wireframeIndices);

            _vertexBuffer.Unbind(_gl);
            _vertexBufferArray.Unbind(_gl);
            _indexBuffer.Unbind(_gl);
            _wireframeIndexBuffer.Unbind(_gl);
        }

        private void UpdateModel()
        {
            var scaleMatrix = Matrix4x4.CreateScale(Transform.Scale);
            var rotationMatrix = Matrix4x4.CreateFromQuaternion(Transform.Rotation);
            var translationMatrix = Matrix4x4.CreateTranslation(Transform.Position);

            var modelMatrix = scaleMatrix * rotationMatrix * translationMatrix;

            _shaderProgram.SetUniformMatrix4("model", modelMatrix);
        }

        private void DrawElements(IndexBuffer indexBuffer, uint mode, int indicesLength)
        {
            indexBuffer.Bind(_gl);
            _gl.DrawElements(mode, indicesLength, OpenGL.GL_UNSIGNED_SHORT, IntPtr.Zero);
            indexBuffer.Unbind(_gl);
        }

        ~Shape()
        {
            _transform.OnScaleChanged -= UpdateModel;
            _transform.OnRotationChanged -= UpdateModel;
            _transform.OnPositionChanged -= UpdateModel;
        }
    }
}
