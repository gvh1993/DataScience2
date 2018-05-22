using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public class GeneticAlgorithm
    {
        public GeneticAlgorithm()
        {
            Individual ind = CreateIndividual();
            double fittness = ComputeFitness(ind);
        }
        private Individual CreateIndividual()
        {
            Individual ind = new Individual();

            Random r = new Random();
            for (int i = 0; i < ind.Value.Length; i++)
            {
                double value = r.NextDouble();
                if (value > 0.5)
                {
                    ind.Value[i] = true;
                }
                else
                {
                    ind.Value[i] = false;
                }
            }

            return ind;
        }

        private double ComputeFitness(Individual ind)
        {
            int intValue = ind.CalculateFromByteArray();

            //𝑓(𝑥) = −(𝑥^2)+7𝑥            double fitness = -(Math.Pow(intValue, 2)) + 7 * intValue;

            return fitness;
        }

        private void SelectTwoParents(List<Individual> population)
        {

        }
    }
}
