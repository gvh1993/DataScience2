using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public class GeneticAlgorithm
    {
        Random r;
        private const float POPULATION_SIZE = 25;

        public GeneticAlgorithm()
        {
             r = new Random();

            Individual ind = CreateIndividual();
            double fittness = ComputeFitness(ind);

            List<Individual> population = InitPopulation();
            SelectTwoParents(population);
        }
        private Individual CreateIndividual()
        {
            Individual ind = new Individual();

            
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

            //𝑓(𝑥) = −(𝑥^2)+7𝑥
            double fitness = -(Math.Pow(intValue, 2)) + 7 * intValue;

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
            float sumRank = (population.Count + 1) * (float)population.Count / 2;
            double worst_probability = (double)2 / (POPULATION_SIZE * (POPULATION_SIZE + 1));
            double best_probability = (double)POPULATION_SIZE / ((POPULATION_SIZE * (POPULATION_SIZE + 1)) / 2);

            //calculate probability to be chosen and assign to individuals
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                populationOrderedByRank[i].ProbabilityChosen = (i+1) / sumRank;
            }



            //generate random number
            //father
            int selectIndFather = r.Next(1, (int)POPULATION_SIZE +1);
            float selectedProbabilityFather = selectIndFather / sumRank;
            Individual father = null;

            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                if (populationOrderedByRank[i].ProbabilityChosen >= selectedProbabilityFather)
                {
                    father = populationOrderedByRank[i];
                    break;
                }
            }


            //mother
            //father
            int selectIndMother = r.Next(1, (int)POPULATION_SIZE + 1);
            double selectedProbabilityMother = selectIndMother / sumRank;
            Individual mother = null;

            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                if (populationOrderedByRank[i].ProbabilityChosen >= selectedProbabilityMother)
                {
                    mother = populationOrderedByRank[i];
                    break;
                }
            }

            return new Tuple<Individual, Individual>(father, mother);
        }
    }
}
