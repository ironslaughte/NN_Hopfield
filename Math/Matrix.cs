namespace IntelligenceAdditional
{
    public class Matrix
    {
        private List<Vector> _container;

        public Vector Size
        {
            get
            {
                if (this._container == null)
                    return new Vector(vector: new() { 0f, 0f });

                if (this._container[0] == null)
                    return new Vector(new() { _container.Count, 0f });

                return new Vector(new() { _container.Count, this._container[0].Size });
            }
        }

        public Matrix(List<Vector> container)
        {
            _container = container;
        }      
        public Matrix(int dimension)
        {
            _container = new List<Vector>();
            for (int i = 0; i < dimension; i++)              
                _container.Add(new Vector(CreateZeroList(dimension)));
        }
        
        private List<float> CreateZeroList(int dimension)
        {
            List<float> zeroList = new List<float>();
            for (int i = 0; i < dimension; i++)
                zeroList.Add(0f);
            return zeroList;
        }       
        public void PrintMatrix()
        {
            for (int i = 0; i < _container.Count; i++)
                Console.WriteLine(_container[i]);
        }
        public void Sum(Matrix matrix)
        {
            for (int i = 0; i < _container.Count; i++)
                for (int j = 0; j < _container[i].Size; j++)
                    _container[i][j] += matrix[i][j];
        }
        public void MultiplyByNum(float num)
        {
            for (int i = 0; i < _container.Count; i++)
                for (int j = 0; j < _container[i].Size; j++)
                    _container[i][j] *= num;
        }
        public Vector this[int index]
        {
            get => _container[index];
            set => _container[index] = value;
        }
    }
}
