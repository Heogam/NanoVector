using System.Numerics;
using System.Runtime.CompilerServices;

namespace NanoVector
{
    public readonly struct ReadOnlyMultiVector
    {
        private readonly ReadOnlyMemory<float> _data;
        public ReadOnlyMemory<float> Data { get { return _data; } }

        public ReadOnlyMultiVector() => _data = new Memory<float>();
        public ReadOnlyMultiVector(float[] data) => _data = data;
        public ReadOnlyMultiVector(List<float> data) => _data = data.ToArray();
        public ReadOnlyMultiVector(Memory<float> data) => _data = data;

        public unsafe float Sum()
        {
            var span = _data.Span;
            if (span.Length == 0)
                return 0;
            int count = Vector<float>.Count;
            Vector<float> sum = Vector<float>.Zero;
            int i = 0;

            fixed (float* p = span)
            {
                for (; i <= span.Length - count; i += count)
                {
                    sum += Unsafe.AsRef<Vector<float>>(p + i);
                }
            }

            float finalResult = Vector.Dot(sum, Vector<float>.One);
            for (; i < span.Length; i++) finalResult += span[i];
            return finalResult;
        }
        public unsafe float SumOfSquares()
        {
            var span = _data.Span;
            if (span.Length == 0)
                return 0;
            int count = Vector<float>.Count;
            Vector<float> sum = Vector<float>.Zero;
            int i = 0;

            fixed (float* p = span)
            {
                for (; i <= span.Length - count; i += count)
                {
                    sum += Unsafe.AsRef<Vector<float>>(p + i) * Unsafe.AsRef<Vector<float>>(p + i);
                }
            }

            float finalResult = Vector.Dot(sum, Vector<float>.One);
            for (; i < span.Length; i++) finalResult += span[i] * span[i];
            return finalResult;
        }
    }
}