using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iterations = Int32.Parse(txt_Iterations.Text);
            int populationSize = Int32.Parse(txt_PopulationSize.Text);
            double crossoverRate = Double.Parse(txt_Crossover.Text);
            double mutationRate = Double.Parse(txt_MutationRate.Text);
            bool elitism = false;

            if (chb_Elitism.Checked)
            {
                elitism = true;
            }

            List<Individual> population;

            GeneticAlgorithm ga = new GeneticAlgorithm(populationSize, iterations, crossoverRate, mutationRate);

            if (elitism)
            {
                population = ga.StartWithElitism();
            }
            else
            {
                population = ga.StartWithoutElitism();
            }

            //show results
            lbl_AverageFitness.Text = "Average fitness: " + ga.CalculateAverageFitness(population);
            lbl_AmountWithBestFitness.Text = "Amount with best fitness: " + ga.GetAmountWithBestFitness(population);

            Individual bestIndividual = ga.GetBestIndividual(population);
            lbl_BestFitness.Text = "Best fitness: " + bestIndividual.Fitness;
            lbl_BestIndividual.Text = "Best individual: " + bestIndividual.ToString();
            
        }

        private string CheckInput()
        {
            if (txt_Crossover.Text.Length > 0)
            {

            }

            return "";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
