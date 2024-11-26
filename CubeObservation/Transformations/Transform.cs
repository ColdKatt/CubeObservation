using System;
using System.Numerics;

namespace CubeObservation.Transformations
{
    /// <summary>
    /// Class for tracking changes in position, rotation and scale.
    /// </summary>
    internal class Transform
    {
        public event Action OnRotationChanged;
        public event Action OnPositionChanged;
        public event Action OnScaleChanged;

        private Quaternion _rotation;
        private Vector3 _position;
        private Vector3 _scale;

        public Quaternion Rotation
        {
            get => _rotation;
            set
            {
                _rotation = Quaternion.Normalize(value);
                OnRotationChanged?.Invoke();
            }
        }

        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPositionChanged?.Invoke();
            }
        }

        public Vector3 Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                OnScaleChanged?.Invoke();
            }
        }

        public Transform()
        {
            Rotation = Quaternion.Identity;
            Position = Vector3.Zero;
            Scale = Vector3.One;
        }

        /// <summary>
        /// Rotates the object by the angle of the corresponding axis.
        /// </summary>
        /// <param name="deltaVector">Angle vector in degrees</param>
        public void Rotate(Vector3 deltaVector)
        {
            Quaternion quaternionX = Quaternion.CreateFromAxisAngle(Vector3.UnitX, ((float)Math.PI / 180) * deltaVector.X);
            Quaternion quaternionY = Quaternion.CreateFromAxisAngle(Vector3.UnitY, ((float)Math.PI / 180) * deltaVector.Y);
            Quaternion quaternionZ = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, ((float)Math.PI / 180) * deltaVector.Z);

            Rotation = quaternionX * quaternionY * quaternionZ * Rotation;
        }

        /// <summary>
        /// Adds the given vector to the current position of the object.
        /// </summary>
        /// <param name="deltaVector"></param>
        public void Translate(Vector3 deltaVector) => Position += deltaVector;
    }
}
