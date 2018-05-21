using K_Means.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_Means
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataProcessor dataProcessor = new DataProcessor();
            List<WineItem> wineData = dataProcessor.ReadFile();

            float sumSquaredError = float.MaxValue;
            List<Cluster> bestClusters = new List<Cluster>();

            KMeans kMeans = new KMeans(wineData);

            for (int j = 0; j < 10; j++)
            {
                List<Cluster> clusters = kMeans.InitiateCentroidBySelection(wineData);
                for (int i = 0; i < 25; i++)
                {
                    clusters = kMeans.AssignToCluster(clusters, wineData);
                    clusters = kMeans.RecalculateCentroids(clusters);
                }
                clusters = kMeans.AssignToCluster(clusters, wineData);

                float distance = kMeans.CalculateSSE(clusters);
                if (distance < sumSquaredError)
                {
                    sumSquaredError = distance;
                    bestClusters = clusters;
                }
            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
