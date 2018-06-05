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

        public int PopulationSize { get;}
        public int Iterations { get;}
        public double CrossoverRate { get;}
        public double MutationRate { get;}

        public GeneticAlgorithm(int populationSize, int iterations, double crossoverRate, double mutationRate)
        {
             r = new Random();

            PopulationSize = populationSize;
            Iterations = iterations;
            CrossoverRate = crossoverRate;
            MutationRate = mutationRate;
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

            for (int i = 0; i < PopulationSize; i++)
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
            double worst_probability = (double)2 / (PopulationSize * (PopulationSize + 1));
            double best_probability = (double)PopulationSize / ((PopulationSize * (PopulationSize + 1)) / 2);

            //calculate probability to be chosen and assign to individuals
            for (int i = 0; i < PopulationSize; i++)
            {
                populationOrderedByRank[i].ProbabilityChosen = (i+1) / sumRank;
            }


            //generate random number
            //father
            int selectIndFather = r.Next(1, PopulationSize +1);
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
            int selectIndMother = r.Next(1, PopulationSize + 1);
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

        private Tuple<Individual, Individual> Tournament(List<Individual> population){
            Individual father = new Individual();
            father.Fitness = float.MinValue;

            Individual mother = new Individual();
            mother.Fitness = float.MinValue;

            // select x amount of potential parents random
            const int tournamentSize = 10;

            // SELECT FATHER
            List<Individual> tournamentParticipants = new List<Individual>();
            for (int i = 0; i < tournamentSize; i++)
            {
                var selectedIndex = r.Next(0, PopulationSize);
                tournamentParticipants.Add(population[selectedIndex]);
            }

            // fight them by fitness
            foreach (var potentialParent in tournamentParticipants)
            {
                // select parent by best fitness
                if (father.Fitness < potentialParent.Fitness)
                {
                    father = potentialParent;
                }
            }


            // SELECT MOTHER
            tournamentParticipants = new List<Individual>();
            for (int i = 0; i < tournamentSize; i++)
            {
                var selectedIndex = r.Next(0, PopulationSize);
                tournamentParticipants.Add(population[selectedIndex]);
            }

            // fight them by fitness
            foreach (var potentialParent in tournamentParticipants)
            {
                // select parent by best fitness
                if (mother.Fitness < potentialParent.Fitness)
                {
                    mother = potentialParent;
                }
            }

            return new Tuple<Individual, Individual>(father, mother);
        }

        private Tuple<Individual, Individual> CrossOver(Tuple<Individual, Individual> parents)
        {
            const int crossoverPoint = 3;
            double randomCrossover = r.NextDouble();

            if (randomCrossover > CrossoverRate)
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

        private Individual Mutation(Individual individual)
        {

            for (int i = 0; i < individual.Value.Length; i++)
            {
                double randomMutation = r.NextDouble();

                if (randomMutation < MutationRate)
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

        private List<Individual> Elitism(List<Individual> population)
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

        public int GetAmountWithBestFitness(List<Individual> population)
        {
            // get the best fitness
            Individual bestIndividual = GetBestIndividual(population);

            // get list where individual has that fitness
            return population.Where(x => x.Fitness == bestIndividual.Fitness).Count();
        }

        public List<Individual> StartWithElitism()
        {
            // init population
            List<Individual> population = InitPopulation();
            List<double> fitnessHistory = new List<double>();

            int innerIteration;

            bool populationSizeIsEven;
            //check if population is even number
            if (PopulationSize % 2 == 0)
            {
                populationSizeIsEven = true;
                innerIteration = (PopulationSize / 2) -1;
            }
            else
            {
                populationSizeIsEven = false;
                innerIteration = Convert.ToInt32(((double)PopulationSize / 2) - 1.5);
            }


            for (int i = 0; i < Iterations; i++)
            {
                List<Individual> newPopulation = new List<Individual>();

                //loop 11 times to get 22 individuals
                // remaining 3 is for elitism
                for (int j = 0; j < innerIteration; j++)
                {
                    //selection
                    //var parents = ga.SelectTwoParents(population);
                    var parents = Tournament(population);
                    //crossover
                    var offspring = CrossOver(parents);

                    //mutation
                    Individual child1 = Mutation(offspring.Item1);
                    Individual child2 = Mutation(offspring.Item2);

                    child1.Fitness = ComputeFitness(child1);
                    child2.Fitness = ComputeFitness(child2);

                    newPopulation.Add(child1);
                    newPopulation.Add(child2);
                }

                //elitism
                // delete one individual because elitism is 3
                if (populationSizeIsEven)
                {
                    newPopulation.RemoveAt(newPopulation.Count -1);
                }
                newPopulation.AddRange(Elitism(population));

                // calculate 
                var averageFitness = CalculateAverageFitness(newPopulation);
                var bestIndividual = GetBestIndividual(newPopulation);
                fitnessHistory.Add(averageFitness);

                // set newpopulation to population
                population = newPopulation;
            }


            return population;
        }

        public List<Individual> StartWithoutElitism()
        {
            // init population
            List<Individual> population = InitPopulation();
            List<double> fitnessHistory = new List<double>();

            int innerIteration;

            bool populationSizeIsEven;
            //check if population is even number
            if (PopulationSize % 2 == 0)
            {
                populationSizeIsEven = true;
                innerIteration = PopulationSize / 2;
            }
            else
            {
                populationSizeIsEven = false;
                innerIteration = Convert.ToInt32(((double)PopulationSize / 2) + .5);
            }



            for (int i = 0; i < Iterations; i++)
            {
                List<Individual> newPopulation = new List<Individual>();

                //loop 11 times to get 22 individuals
                // remaining 3 is for elitism
                for (int j = 0; j < innerIteration; j++)
                {
                    //selection
                    //var parents = ga.SelectTwoParents(population);
                    var parents = Tournament(population);
                    //crossover
                    var offspring = CrossOver(parents);

                    //mutation
                    Individual child1 = Mutation(offspring.Item1);
                    Individual child2 = Mutation(offspring.Item2);

                    child1.Fitness = ComputeFitness(child1);
                    child2.Fitness = ComputeFitness(child2);

                    newPopulation.Add(child1);
                    newPopulation.Add(child2);
                }

                //elitism
                // there is no elitism selected.. we should remove one of the population if population size is odd
                if (!populationSizeIsEven)
                {
                    newPopulation.RemoveAt(newPopulation.Count -1);
                }
                //newPopulation.AddRange(Elitism(population));

                // calculate 
                var averageFitness = CalculateAverageFitness(newPopulation);
                var bestIndividual = GetBestIndividual(newPopulation);
                fitnessHistory.Add(averageFitness);

                // set newpopulation to population
                population = newPopulation;
            }


            return population;
        }
    }
}
