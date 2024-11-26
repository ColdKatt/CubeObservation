using CubeObservation.Transformations;
using System.Numerics;

namespace CubeObservation.InputOutput
{
    internal abstract class TransformMouseInputHandler : MouseInput
    {
        protected readonly ITransformable _transformableObject;

        public TransformMouseInputHandler(ITransformable transformableObject, Vector2 startMousePosition) : base(startMousePosition)
        {
            _transformableObject = transformableObject;
        }

        public override void HandleInput(Vector2 newMousePosition) { }
    }
}
