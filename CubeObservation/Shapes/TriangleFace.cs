using SharpGL.SceneGraph;
using System.Numerics;

namespace CubeObservation.Shapes
{
    internal struct TriangleFace
    {
        public Vector3 Center;
        public ushort[] Indices;
        public string Name;

        public TriangleFace(ushort[] indices, Vertex[] vertices, string name)
        {
            Indices = indices;
            Name = name;

            var res = Vector3.Zero;
            foreach (var index in indices)
            {
                res.X += vertices[index].X;
                res.Y += vertices[index].Y;
                res.Z += vertices[index].Z;
            }

            Center = res / 3f;
        }
    }
}
