using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenceAdditional
{
    public class Program
    {
        public static void Main()
        {
            List<Letter> letterList = new List<Letter>();
            letterList.Add(new Letter('п', new Vector(new() { 1, 1, 1, 1, -1, 1, 1, -1, 1 })));
            letterList.Add(new Letter('г', new Vector(new() { 1, 1, 1, 1, -1, -1, 1, -1, -1 })));
            letterList.Add(new Letter('L', new Vector(new() { 1, -1, -1, 1, -1, -1, 1, 1, 1 })));
            Hopfield hopfield = new Hopfield(letterList);
            Console.WriteLine(hopfield.Predict(new Letter ('t', new Vector(new() { 1, 1, 1, 1, -1, -1, 1, -1, -1 }))));
        }
    }
}
