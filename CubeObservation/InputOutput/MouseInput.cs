using System.Numerics;

namespace CubeObservation.InputOutput
{
    internal abstract class MouseInput
    {
        protected Vector2 _startMousePosition;

        public MouseInput(Vector2 startMousePosition)
        {
            _startMousePosition = startMousePosition;
        }

        public abstract void HandleInput(Vector2 newMousePosition);
    }
}
