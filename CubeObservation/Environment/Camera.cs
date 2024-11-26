using CubeObservation.Transformations;
using System.Numerics;

namespace CubeObservation.Environment
{
    internal class Camera : ITransformable
    {
        private readonly Transform _transform;

        private Matrix4x4 _viewMatrix;
        private Matrix4x4 _projectionMatrix;

        public Matrix4x4 ViewMatrix { get => _viewMatrix; }
        public Matrix4x4 ProjectionMatrix { get => _projectionMatrix; }

        public Transform Transform => _transform;

        public Camera(Matrix4x4 projectionMatrix)
        {
            _transform = new Transform();
            _transform.OnPositionChanged += UpdateView;
            _transform.OnRotationChanged += UpdateView;

            _viewMatrix = Matrix4x4.CreateLookAt(Transform.Position, Vector3.Zero, Vector3.UnitY);
            _projectionMatrix = projectionMatrix;
        }

        private void UpdateView()
        {
            var rotationMatrix = Matrix4x4.CreateFromQuaternion(Transform.Rotation);
            _viewMatrix = rotationMatrix * Matrix4x4.CreateLookAt(Transform.Position, Vector3.Zero, Vector3.UnitY);
        }

        ~Camera()
        {
            _transform.OnPositionChanged -= UpdateView;
            _transform.OnRotationChanged -= UpdateView;
        }
    }
}
