using CubeObservation.Extensions;
using SharpGL;
using SharpGL.SceneGraph;
using System.Collections.Generic;

namespace CubeObservation.Shapes
{
    internal class Cube : Shape
    {
        private const string VERTEX_SHADER_PATH = "Shaders/VertexShader.glsl";
        private const string FRAGMENT_SHADER_PATH = "Shaders/FragmentShader.glsl";

        public Cube(OpenGL gl) : base(gl)
        {
            _vertices = new Vertex[]
            {
                new Vertex(-0.5f, -0.5f, -0.5f),
                new Vertex(-0.5f, -0.5f,  0.5f),
                new Vertex(0.5f, -0.5f,  0.5f),
                new Vertex(0.5f, -0.5f, -0.5f),

                new Vertex(-0.5f,  0.5f, -0.5f),
                new Vertex(-0.5f,  0.5f,  0.5f),
                new Vertex(0.5f,  0.5f,  0.5f),
                new Vertex(0.5f,  0.5f, -0.5f)
            };

            _faces = new List<TriangleFace>()
            {
                new TriangleFace(new ushort[] { 1, 2, 6 }, _vertices, "BACK"),
                new TriangleFace(new ushort[] { 1, 5, 6 }, _vertices, "BACK"),

                new TriangleFace(new ushort[] { 0, 1, 2 }, _vertices, "BOTTOM"),
                new TriangleFace(new ushort[] { 0, 3, 2 }, _vertices, "BOTTOM"),

                new TriangleFace(new ushort[] { 0, 4, 5 }, _vertices, "LEFT"),
                new TriangleFace(new ushort[] { 0, 1, 5 }, _vertices, "LEFT"),

                new TriangleFace(new ushort[] { 4, 5, 6 }, _vertices, "TOP"),
                new TriangleFace(new ushort[] { 4, 7, 6 }, _vertices, "TOP"),

                new TriangleFace(new ushort[] { 3, 2, 6 }, _vertices, "RIGHT"),
                new TriangleFace(new ushort[] { 3, 7, 6 }, _vertices, "RIGHT"),

                new TriangleFace(new ushort[] { 0, 4, 7 }, _vertices, "FORWARD"),
                new TriangleFace(new ushort[] { 0, 3, 7 }, _vertices, "FORWARD"),

            };

            _indices = new ushort[]
            {
                1, 2, 6, // backward
                1, 5, 6,

                0, 1, 2, // bottom
                0, 3, 2,

                0, 4, 5, // left
                0, 1, 5,

                4, 5, 6, // top
                4, 7, 6,

                3, 2, 6, // right
                3, 7, 6,

                0, 4, 7, // forward
                0, 3, 7,
            };

            _wireframeIndices = new ushort[]
            {
                0, 1,   4, 5,   0, 4,
                1, 2,   5, 6,   1, 5,
                2, 3,   6, 7,   2, 6,
                3, 0,   7, 4,   3, 7
            };

            ShaderProgram = ShaderProgramExtensions.SetupShaders(_gl, VERTEX_SHADER_PATH, FRAGMENT_SHADER_PATH);

            SetupBuffers(0, false, 3);
        }
    }
}
