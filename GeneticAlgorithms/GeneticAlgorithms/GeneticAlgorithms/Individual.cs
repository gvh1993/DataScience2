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
                if (Value[i])
                {
                    var bitLocation = (Value.Length - i) - 1;

                    totalValue += (int)Math.Pow(2 , bitLocation);
                }
            }

            return totalValue;
        }

        public override string ToString()
        {
            return "\n Genes: " + string.Join(",", Value) + "\n Genes value: " + CalculateFromByteArray() + "\n Fitness: " + Fitness;
        }  
    }
}
