using System.Text;
namespace IntelligenceAdditional
{
    public class Vector 
    {
        private List<float> _vector;
        public int Size => _vector.Count;

        public Vector(List<float> vector) => _vector = vector;
        public void Add(float value) => _vector.Add(value);
        public override bool Equals(object? obj)
        {
            var other = obj as Letter;
            if(other == null || other.Vector.Size != Size) return false;
            var otherVec = other.Vector;
            for (int i = 0; i < Size; i++)
                if (_vector[i] != otherVec[i]) return false;
            return true;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for(int i = 0; i < Size; i++)
            {
                str.Append(_vector[i].ToString());
            }
            return str.ToString();
        }
        public Matrix Myltiply(Vector vector)
        {
            if (vector.Size != Size) return new Matrix(0);

            Matrix res = new Matrix(Size);
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    res[i][j] += _vector[i] * vector[j];
            return res;
        }
        public float this[int index]
        {
            get => _vector[index];
            set => _vector[index] = value;
        }
    }
}
