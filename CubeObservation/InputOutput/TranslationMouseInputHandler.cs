using CubeObservation.Transformations;
using System.Numerics;

namespace CubeObservation.InputOutput
{
    internal class TranslationMouseInputHandler : TransformMouseInputHandler
    {
        private readonly float _sensitivity;

        public TranslationMouseInputHandler(ITransformable transformableObject, Vector2 startMousePosition) : base(transformableObject, startMousePosition)
        {
            _sensitivity = 0.01f;
        }

        public override void HandleInput(Vector2 newMousePosition)
        {
            base.HandleInput(newMousePosition);

            var deltaVector = _startMousePosition - newMousePosition;
            _transformableObject.Transform.Translate(new Vector3(-deltaVector.X, deltaVector.Y, 0) * _sensitivity);

            _startMousePosition = newMousePosition;
        }
    }
}
