using CubeObservation.Shapes;
using System.Collections.Generic;

namespace CubeObservation.Extensions
{
    internal static class TriangleFacesListExtension
    {
        public static ushort[] IndicesToUnsignedShortArray(this List<TriangleFace> list)
        {
            var indices = new List<ushort>();

            foreach (var face in list)
            {
                foreach (var index in face.Indices)
                {
                    indices.Add(index);
                }
            }

            return indices.ToArray();
        }
    }
}
