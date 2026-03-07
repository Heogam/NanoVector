using System.Numerics;
using System.Runtime.CompilerServices;

namespace NanoVector
{
    public struct MultiVector
    {
        private Memory<float> _data;
        public Memory<float> Data 
        { 
            get { return _data; }
            set { _data = value; }
        }

        public MultiVector() => _data = new Memory<float>();
        public MultiVector(float[] data) => _data = data;
        public MultiVector(List<float> data) => _data = data.ToArray();
        public MultiVector(Memory<float> data) => _data = data;

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
        public ReadOnlyMultiVector AsReadOnly() => new ReadOnlyMultiVector(_data);
    }
}