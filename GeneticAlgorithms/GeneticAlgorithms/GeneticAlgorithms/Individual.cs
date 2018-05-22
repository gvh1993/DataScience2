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
        public int Fitness { get; set; }


        public Individual()
        {
            Value = new bool[5];
        }

        public int CalculateFromByteArray()
        {
            int totalValue = 0;
            for (int i = Value.Length -1; i > 0; i--)
            {
                if (Value[i] == true)
                {
                    totalValue += (int)Math.Pow(i , 2);
                }
            }

            return totalValue;
        }
    }
}
