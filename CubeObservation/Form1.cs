using CubeObservation.Environment;
using CubeObservation.Extensions;
using CubeObservation.InputOutput;
using CubeObservation.Shapes;
using SharpGL;
using System;
using System.Numerics;
using System.Windows.Forms;

namespace CubeObservation
{
    public partial class Form1 : Form
    {
        internal static Scene s_Scene;

        private TransformMouseInputHandler _mouseInputHandler;

        private Shape _shape;

        public Form1()
        {
            InitializeComponent();
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            DrawModeButton.Text = "Draw Mode: FILL";
            TransparencyButton.Text = "Transparency: OFF";

            var gl = openGLControl1.OpenGL;

            // Camera setup (view, projection)
            s_Scene = new Scene(gl, Matrix4x4.CreatePerspective((float)Math.PI / 4f, (float)Size.Height / (float)Size.Width, 0.1f, 10f));
            s_Scene.MainCamera.Transform.Position = new Vector3(0.0f, 0.0f, 1.0f);
            //

            // gl settings
            gl.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);
            gl.Enable(OpenGL.GL_BLEND);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            //

            // shape instantiating
            _shape = new Cube(gl);
            _shape.ShaderProgram.SetUniformVec3("baseColor", new Vector3(0.0f, 0.5f, 0.5f));
            _shape.ShaderProgram.SetUniformFloat("alpha", 1.0f);

        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            var gl = openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // instantiating another cube for transparency demonstrating
            var staticCube = new Cube(gl);
            staticCube.ShaderProgram.SetUniformVec3("baseColor", new Vector3(1.0f, 0.1f, 0.1f));
            staticCube.ShaderProgram.SetUniformFloat("alpha", 1.0f);
            staticCube.Transform.Position = new Vector3(0.0f, 0.0f, -0.5f);
            staticCube.Draw();
            //

            gl.Disable(OpenGL.GL_DEPTH_TEST);
            _shape.Draw();
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            gl.Flush();
        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            var _startPosition = new Vector2(e.X, e.Y);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _mouseInputHandler = new TranslationMouseInputHandler(_shape, _startPosition);
                    break;
                case MouseButtons.Right:
                    _mouseInputHandler = new RotationMouseInputHandler(_shape, _startPosition);
                    break;
                default:
                    _mouseInputHandler = null;
                    break;
            }
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseInputHandler = null;
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseInputHandler == null) return;

            var newPosition = new Vector2(e.X, e.Y);

            _mouseInputHandler.HandleInput(newPosition);
        }

        private void openGLControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            var delta = e.Delta < 0 ? -0.05f : 0.05f;

            var scale = _shape.Transform.Scale;
            _shape.Transform.Scale = new Vector3(scale.X + delta, scale.Y + delta, scale.Z + delta);
        }

        private void DrawModeButton_Click(object sender, EventArgs e)
        {
            var baseButtonText = "Draw Mode: ";
            var drawMode = _shape.DrawMode == OpenGL.GL_LINE
                ? new Tuple<uint, string>(OpenGL.GL_FILL, "FILL")
                : new Tuple<uint, string>(OpenGL.GL_LINE, "EDGES");

            _shape.DrawMode = drawMode.Item1;
            DrawModeButton.Text = $"{baseButtonText}{drawMode.Item2}";
        }

        private void TransparencyButton_Click(object sender, EventArgs e)
        {
            var baseButtonText = "Transparency: ";
            _shape.IsTransparencyEnabled = !_shape.IsTransparencyEnabled;
            var state = _shape.IsTransparencyEnabled ? "ON" : "OFF";
            TransparencyButton.Text = $"{baseButtonText}{state}";
        }

        private void ColorChangeButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            _shape.ShaderProgram.SetUniformVec3("baseColor", new Vector3(colorDialog1.Color.R / 255f, colorDialog1.Color.G / 255f, colorDialog1.Color.B / 255f));
        }
    }
}
