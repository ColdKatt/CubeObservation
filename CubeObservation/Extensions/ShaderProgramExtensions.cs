using SharpGL;
using SharpGL.SceneGraph.Shaders;
using System;
using System.IO;
using System.Numerics;

namespace CubeObservation.Extensions
{
    internal static class ShaderProgramExtensions
    {
        public static ShaderProgram SetupShaders(OpenGL gl, string vertexShaderPath, string fragmentShaderPath)
        {
            var program = new ShaderProgram();

            var vShader = new VertexShader();
            vShader.CreateInContext(gl);
            vShader.SetSource(File.ReadAllText(vertexShaderPath));
            vShader.Compile();

            var fShader = new FragmentShader();
            fShader.CreateInContext(gl);
            fShader.SetSource(File.ReadAllText(fragmentShaderPath));
            fShader.Compile();

            if (vShader.CompileStatus != true || fShader.CompileStatus != true)
            {
                throw new Exception("Shaders didn't compile");
            }

            program.CreateInContext(gl);
            program.AttachShader(vShader);
            program.AttachShader(fShader);
            program.Link();

            vShader.DestroyInContext(gl);
            fShader.DestroyInContext(gl);

            return program;
        }

        public static void SetUniformVec3(this ShaderProgram program, string uniformName, Vector3 newVector)
        {
            int uniformLocation = program.GetUniformLocation(uniformName);

            program.Push(program.CurrentOpenGLContext, null);
            program.CurrentOpenGLContext.Uniform3(uniformLocation, newVector.X, newVector.Y, newVector.Z);
            program.Pop(program.CurrentOpenGLContext, null);
        }

        public static void SetUniformMatrix4(this ShaderProgram program, string uniformName, Matrix4x4 matrix)
        {
            int uniformLocation = program.GetUniformLocation(uniformName);

            program.Push(program.CurrentOpenGLContext, null);
            program.CurrentOpenGLContext.UniformMatrix4(uniformLocation, 1, false, matrix.ToFloatArray());
            program.Pop(program.CurrentOpenGLContext, null);
        }

        public static void SetUniformFloat(this ShaderProgram program, string uniformName, float value)
        {
            int uniformLocation = program.GetUniformLocation(uniformName);

            program.Push(program.CurrentOpenGLContext, null);
            program.CurrentOpenGLContext.Uniform1(uniformLocation, value);
            program.Pop(program.CurrentOpenGLContext, null);
        }
    }
}
