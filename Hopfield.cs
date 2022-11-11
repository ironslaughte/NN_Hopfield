using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenceAdditional
{
    public delegate void InitVector(Vector vec);
    public class Hopfield
    {
        private Matrix _weights;
        private List<Letter> _letters;
        private int _N;
        public Hopfield(List<Letter> letters)
        {            
            this._letters = letters;
            _N = letters[0].Vector.Size;
            _weights = new Matrix(_N);
            InitWeights();
        }

        private int CheckInLetters(Vector pred)
        {
            for(int i = 0; i <  _letters.Count; i++)
                if (pred.Equals(_letters[i])) return i;
            return -1;
        }

        public int Predict(Letter letter)
        {
            Vector vectorLetter = letter.Vector;
            Vector res = new Vector(new());
            InitVector init = delegate (Vector vec)
            {
                for (int i = 0; i < vectorLetter.Size; i++)
                    res.Add(0);
            };
            init(res);
            int count = 0, idxOfEqualLetter = -1;
            while (count < 5 && idxOfEqualLetter == -1)
            {
                for (int i = 0; i < _weights.Size[0]; i++)
                {                  
                    for (int j = 1; j < _weights.Size[1]; j++)
                        res[i] += _weights[i][j] * vectorLetter[j];                   
                }
                Activation(res);
                idxOfEqualLetter = CheckInLetters(res);                
                count++;
            }
            return idxOfEqualLetter;
        }

        private void Activation(Vector v)
        {
            for (int i = 0; i < v.Size; i++)
                v[i] = v[i] < 0 ? -1 : 1;
        }

        private void InitWeights()
        {
            for (int i = 0; i < _letters.Count; i++)
            {
                Vector letter = _letters[i].Vector;
                _weights.Sum(letter.Myltiply(letter));
            }
            _weights.MultiplyByNum(1f/ _letters[0].Size);
            for (int i = 0; i < _weights.Size[0]; i++)
                _weights[i][i] = 0;
        }   
    }
}
