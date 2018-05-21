using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Means.Models;

namespace K_Means
{
    public class KMeans
    {
        List<WineItem> wineItems = new List<WineItem>();
        List<Cluster> clusters = new List<Cluster>();
        int dimension = 0;

        const int K = 5;
        const int ITERATIONS = 20;

        public KMeans(List<WineItem> wineData)
        {
            wineItems = wineData;
            dimension = wineData[0].WineData.Count;

        }

        public List<Cluster> InitiateCentroidBySelection(List<WineItem> wineData)
        {
            Random r = new Random();

            List<Cluster> clusters = new List<Cluster>();

            for (int i = 0; i < K; i++)
            {
                Cluster cluster = new Cluster();
                int index = r.Next(0, 32);

                cluster.Centroid = wineData[index];

                clusters.Add(cluster);
            }

            return clusters;
        }

        public List<Cluster> InitiateCentroid()
        {
            Random r = new Random();
            List<Cluster> clusters = new List<Cluster>();

            for (int i = 0; i < K; i++)
            {
                Cluster cluster = new Cluster
                {
                    Centroid = new WineItem()
                };

                for (int j = 0; j < dimension; j++)
                {
                    if (r.Next(0,1) > 0.5)
                    {
                        cluster.Centroid.WineData.Add(1);
                    }
                    else
                    {
                        cluster.Centroid.WineData.Add(0);
                    }
                }

                clusters.Add(cluster);
            }

            return clusters;
        }

        // calculate nearest centroid per wineItem and put it into cluster
        public List<Cluster> AssignToCluster(List<Cluster> clusters, List<WineItem> wineItems)
        {

            //iterate over wineItems
            foreach (var wineItem in wineItems)
            {
                double closestDistance = Double.MaxValue;
                Cluster closestCluster = new Cluster();

                //check distance per centriod
                foreach (var cluster in clusters)
                {
                    if (cluster.Centroid.WineData.Count == 0)
                    {
                        Console.WriteLine("error");
                    }
                    double distance = CalculateDistance(cluster, wineItem);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestCluster = cluster;
                    }
                }

                closestCluster.WineData.Add(wineItem);
            }

            return clusters;
        }

        public List<Cluster> RecalculateCentroids(List<Cluster> clusters)
        {
            List<Cluster> newClusters = new List<Cluster>();

            // calculate mean per dimension
            // loop through clusters
            foreach (var cluster in clusters)
            {
                Cluster newCluster = new Cluster();

                if (cluster.WineData.Count == 0)
                {
                    newCluster.Centroid = cluster.Centroid;
                }
                else
                {
                    // calculate new location centroid
                    newCluster.Centroid = CalculateMean(cluster.WineData);
                }

                // add cluster to list newclusters
                newClusters.Add(newCluster);
            }

            return newClusters;
        }

        private float CalculateDistance(Cluster cluster, WineItem wineItem)
        {
            List<float> centroidLocation = cluster.Centroid.WineData;
            List<float> wineItemLocation = wineItem.WineData;

            double distance = 0;

            for (int i = 0; i < wineItemLocation.Count; i++)
            {
                distance += Math.Pow(wineItemLocation[i] - centroidLocation[i], 2);
            }

            return (float)distance;
        }

        private WineItem CalculateMean(List<WineItem> wineData)
        {
            WineItem newCentroid = new WineItem();

            List<float> totalWineData = new List<float>();


            int length = 0;
            if (wineData.Any())
            {
                length = wineData.First().WineData.Count;
            }
            //fill list with zeros so we can access index later
            for (int i = 0; i < length; i++)
            {
                totalWineData.Add(0);
            }


            foreach (var wineItem in wineData)
            {
                for (int i = 0; i < wineItem.WineData.Count; i++)
                {
                    totalWineData[i] += wineItem.WineData[i];
                }
            }

            for (int i = 0; i < totalWineData.Count; i++)
            {
                totalWineData[i] /= wineData.Count;
            }

            newCentroid.WineData = totalWineData;

            return newCentroid;
            
        }

        public float CalculateSSE(List<Cluster> clusters)
        {
            float distance = 0;

            foreach (var cluster in clusters)
            {
                foreach (var wineItem in cluster.WineData)
                {
                    distance += CalculateDistance(cluster, wineItem);
                }
            }

            return distance;
        }
    }
}
