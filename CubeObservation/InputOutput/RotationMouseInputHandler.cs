using CubeObservation.Transformations;
using System.Numerics;

namespace CubeObservation.InputOutput
{
    internal class RotationMouseInputHandler : TransformMouseInputHandler
    {
        public RotationMouseInputHandler(ITransformable transformableObject, Vector2 startMousePosition) : base(transformableObject, startMousePosition)
        {
        }

        public override void HandleInput(Vector2 newMousePosition)
        {
            base.HandleInput(newMousePosition);

            var deltaVector = _startMousePosition - newMousePosition;
            _transformableObject.Transform.Rotate(new Vector3(-deltaVector.Y, -deltaVector.X, 0));

            _startMousePosition = newMousePosition;
        }
    }
}
