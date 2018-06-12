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
            List<ClientItem> wineData = dataProcessor.ReadFile();

            KMeans kMeans = new KMeans(wineData);
            kMeans.ExecuteKmeans();
            Console.WriteLine(kMeans.SumSquaredError);

            // get results (clients)
            // get results per offer

            List<Cluster> bestCLusters = kMeans.BestClusters;

            // iterate over clusters
            foreach (var cluster in bestCLusters)
            {
                // iterate per client per cluster
                foreach (var client in cluster.ClientItems)
                {
                    // iteratie per wineItem per client per cluster
                    for (int i = 0; i < client.WineData.Count; i++)
                    {
                        // if wine item is bought
                        if (client.WineData[i] == 1)
                        {
                            //check if WineItem exist in list<WineItem>
                            if (!cluster.WineItems.Any(x => x.WineOfferId == i+1))
                            {
                                WineItem item = new WineItem();
                                item.WineOfferId = i + 1;
                                item.ClientsOfferTaken.Add(client);

                                cluster.WineItems.Add(item);
                            }
                            else
                            {
                                //append to existing wineItem
                                try
                                {
                                    var myCluster = cluster.WineItems.First(x => x.WineOfferId == i + 1);

                                    myCluster.ClientsOfferTaken.Add(client);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                                
                                //item.ClientsOfferTaken.Add(client);

                                //wineItems.Add(item);
                            }
                        }
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
