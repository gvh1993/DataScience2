using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public class Individual
    {
        public bool[] Value { get; set; }
        public double Fitness { get; set; }
        public double ProbabilityChosen { get; set; }

        public Individual()
        {
            Value = new bool[5];
        }

        public int CalculateFromByteArray()
        {
            int totalValue = 0;
            for (int i = Value.Length -1 ; i >= 0; i--)
            {
                var bitLocation = (Value.Length - i) - 1;
                Console.WriteLine(bitLocation);

                if (Value[i])
                {
                    totalValue += (int)Math.Pow(2 , bitLocation);
                }
            }

            return totalValue;
        }
    }
}
