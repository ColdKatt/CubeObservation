using SharpGL.SceneGraph;
using System.Collections.Generic;

namespace CubeObservation.Extensions
{
    internal static class VertexExtensions
    {
        public static float[] ToFLoatArray(this Vertex[] vertices)
        {
            var pointsList = new List<float>();

            foreach (var vertex in vertices)
            {
                pointsList.Add(vertex.X);
                pointsList.Add(vertex.Y);
                pointsList.Add(vertex.Z);
            }

            return pointsList.ToArray();
        }
    }
}
