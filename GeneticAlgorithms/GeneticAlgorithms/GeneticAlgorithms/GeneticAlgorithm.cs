using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithms
{
    public class GeneticAlgorithm
    {
        readonly Random r;

        public float PopulationSize { get;}

        public GeneticAlgorithm()
        {
             r = new Random();

            PopulationSize = 25;
        }
        public Individual CreateIndividual()
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

        public double ComputeFitness(Individual ind)
        {
            int intValue = ind.CalculateFromByteArray();

            //𝑓(𝑥) = −(𝑥^2)+7𝑥
            double fitness = -(Math.Pow(intValue, 2)) + 7 * intValue;

            return fitness;
        }

        public List<Individual> InitPopulation()
        {
            List<Individual> population = new List<Individual>();

            for (int i = 0; i < PopulationSize; i++)
            {
                population.Add(CreateIndividual());
            }

            return population;
        }

        public Tuple<Individual, Individual> SelectTwoParents(List<Individual> population)
        {
            // RANK SELECTION
            
            // order by fitness
            List<Individual> populationOrderedByRank = population.OrderBy(x => x.Fitness).ToList();

            //(6+1)*6/2
            float sumRank = (population.Count + 1) * (float)population.Count / 2;
            double worst_probability = (double)2 / (PopulationSize * (PopulationSize + 1));
            double best_probability = (double)PopulationSize / ((PopulationSize * (PopulationSize + 1)) / 2);

            //calculate probability to be chosen and assign to individuals
            for (int i = 0; i < PopulationSize; i++)
            {
                populationOrderedByRank[i].ProbabilityChosen = (i+1) / sumRank;
            }


            //generate random number
            //father
            int selectIndFather = r.Next(1, (int)PopulationSize +1);
            double selectedProbabilityFather = selectIndFather / sumRank;
            Individual father = null;

            for (int i = 0; i < PopulationSize; i++)
            {
                if (populationOrderedByRank[i].ProbabilityChosen >= selectedProbabilityFather)
                {
                    father = populationOrderedByRank[i];
                    break;
                }
            }


            //mother
            //father
            int selectIndMother = r.Next(1, (int)PopulationSize + 1);
            double selectedProbabilityMother = selectIndMother / sumRank;
            Individual mother = null;

            for (int i = 0; i < PopulationSize; i++)
            {
                if (populationOrderedByRank[i].ProbabilityChosen >= selectedProbabilityMother)
                {
                    mother = populationOrderedByRank[i];
                    break;
                }
            }

            if (father == null || mother == null)
            {
                Console.WriteLine("HELP!!");
            }

            return new Tuple<Individual, Individual>(father, mother);
        }

        public Tuple<Individual, Individual> CrossOver(Tuple<Individual, Individual> parents)
        {
            const int crossoverThreshold = 90;
            const int crossoverPoint = 3;
            double crossoverRate = r.NextDouble();

            if (crossoverRate > crossoverThreshold)
            {
                return parents;
            }

            Individual father = parents.Item1;
            Individual mother = parents.Item2;


            Individual child1 = new Individual();
            Individual child2 = new Individual();

            for (int i = 0; i < father.Value.Length; i++)
            {
                if (i < crossoverPoint)
                {
                    child1.Value[i] = father.Value[i];
                    child2.Value[i] = mother.Value[i];
                }
                else
                {
                    child1.Value[i] = mother.Value[i];
                    child2.Value[i] = father.Value[i];
                }
            }

            return new Tuple<Individual, Individual>(child1, child2);
        }

        public Individual Mutation(Individual individual)
        {
            const float mutationThreshold = 0.1f;

            for (int i = 0; i < individual.Value.Length; i++)
            {
                double mutationRate = r.NextDouble();

                if (mutationRate < mutationThreshold)
                {
                    if (individual.Value[i])
                    {
                        // if to be mutated value is true
                        individual.Value[i] = false;
                    }
                    else
                    {
                        // if to be mutated value is false
                        individual.Value[i] = true;
                    }
                }
            }

            return individual;
        }

        public List<Individual> Elitism(List<Individual> population)
        {
            // take best 3
            int topAmount = 3;

            List<Individual> elitePopulation = population.OrderByDescending(x => x.Fitness).Take(topAmount).ToList();

            return elitePopulation;
        }

        public double CalculateAverageFitness(List<Individual> population)
        {
            return population.Average(x => x.Fitness);
        }


        public Individual GetBestIndividual(List<Individual> population)
        {
            return population.OrderByDescending(x => x.Fitness).First();
        }
    }
}
