using System.Numerics;
using System.Runtime.CompilerServices;

namespace NanoVector
{
    public partial class NanoComparator
    {
        public static unsafe float Compare(MultiVector x, MultiVector y)
        {
            float dot = DotProduct(x, y);

            float magX = MathF.Sqrt(x.SumOfSquares());
            float magY = MathF.Sqrt(y.SumOfSquares());

            if (magX == 0 || magY == 0) return 0;

            return dot / (magX * magY);
        }
        public static unsafe float DotProduct(MultiVector x, MultiVector y)
        {
            var spanX = x.Data.Span;
            var spanY = y.Data.Span;

            if (spanX.Length == 0 || spanY.Length == 0)
                return 0;
            if (spanX.Length != spanY.Length)
                throw new ArgumentException("Vectors of different lengths!");

            int count = Vector<float>.Count;
            Vector<float> sum = Vector<float>.Zero;
            int i = 0;

            fixed (float* pX = spanX, pY = spanY)
            {
                for (; i < spanX.Length - count; i += count)
                {
                    sum += Unsafe.AsRef<Vector<float>>(pX + i) * Unsafe.AsRef<Vector<float>>(pY + i);
                }
            }
            float result = Vector.Dot(sum, Vector<float>.One);
            for (; i < spanX.Length; i++) result += spanX[i] * spanY[i];
            return result;
        }
    }
}