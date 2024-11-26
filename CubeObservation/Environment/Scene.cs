using CubeObservation.Extensions;
using SharpGL;
using SharpGL.SceneGraph.Shaders;
using System.Numerics;

namespace CubeObservation.Environment
{
    internal class Scene
    {
        public readonly Camera MainCamera;

        public Scene(OpenGL gl, Matrix4x4 cameraPerspective)
        {
            MainCamera = new Camera(cameraPerspective);
        }

        public void UpdateProgramView(ShaderProgram program)
        {
            program.SetUniformMatrix4("view", MainCamera.ViewMatrix);
        }

        public void UpdateProgramProjection(ShaderProgram program)
        {
            program.SetUniformMatrix4("projection", MainCamera.ProjectionMatrix);
        }

        public void ApplySceneSettingsToProgram(ShaderProgram program)
        {
            UpdateProgramView(program);
            UpdateProgramProjection(program);
        }
    }
}
