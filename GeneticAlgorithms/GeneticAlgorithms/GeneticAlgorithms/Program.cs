using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GeneticAlgorithm ga = new GeneticAlgorithm();

            // init population
            List<Individual> population = ga.InitPopulation();
            List<double> fitnessHistory = new List<double>();

            for (int i = 0; i < 100; i++)
            {
                List<Individual> newPopulation = new List<Individual>();

                //loop 11 times to get 22 individuals
                // remaining 3 is for elitism
                for (int j = 0; j < 11; j++)
                {
                    //selection
                    //var parents = ga.SelectTwoParents(population);
                    var parents = ga.Tournament(population);
                    //crossover
                    var offspring = ga.CrossOver(parents);

                    //mutation
                    Individual child1 = ga.Mutation(offspring.Item1);
                    Individual child2 = ga.Mutation(offspring.Item2);

                    child1.Fitness = ga.ComputeFitness(child1);
                    child2.Fitness = ga.ComputeFitness(child2);

                    newPopulation.Add(child1);
                    newPopulation.Add(child2);
                }

                //elitism
                newPopulation.AddRange(ga.Elitism(population));

                // calculate 
                var averageFitness = ga.CalculateAverageFitness(newPopulation);
                var bestIndividual = ga.GetBestIndividual(newPopulation);
                fitnessHistory.Add(averageFitness);

                // set newpopulation to population
                population = newPopulation;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
