using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public class GeneticAlgorithm
    {
        private const float POPULATION_SIZE = 25;

        public GeneticAlgorithm()
        {
            Individual ind = CreateIndividual();
            double fittness = ComputeFitness(ind);

            List<Individual> population = InitPopulation();

            SelectTwoParents(population);
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

            // Fill fittness
            ind.Fitness = ComputeFitness(ind);

            return ind;
        }

        private double ComputeFitness(Individual ind)
        {
            int intValue = ind.CalculateFromByteArray();

            //𝑓(𝑥) = −(𝑥^2)+7𝑥            double fitness = -(Math.Pow(intValue, 2)) + 7 * intValue;

            return fitness;
        }

        private List<Individual> InitPopulation()
        {
            List<Individual> population = new List<Individual>();

            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                population.Add(CreateIndividual());
            }

            return population;
        }

        private Tuple<Individual, Individual> SelectTwoParents(List<Individual> population)
        {
            // RANK SELECTION
            
            // order by fitness
            List<Individual> populationOrderedByRank = population.OrderBy(x => x.Fitness).ToList();

            //(6+1)*6/2
            float sumRank = (population.Count + 1) * population.Count / 2;

            Random r = new Random();
            var outcome = r.NextDouble(0, sumRank);

            //var index = (outcome - 1) * outcome / 2;
            float cumProb = 0;
            //select first parent
            for (int i = 1; i < population.Count +1; i++)
            {
                //calculate p
                float p = (float)i / sumRank;
                cumProb += p;
                Console.WriteLine(p);
            }
            Console.WriteLine("total probability: " + sumprob);
            return null;
        }
    }
}
