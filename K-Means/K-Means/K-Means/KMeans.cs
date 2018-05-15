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

            clusters = InitiateCentroidBySelection(wineData);
            clusters = AssignToCluster(clusters);
        }

        private List<Cluster> InitiateCentroidBySelection(List<WineItem> wineData)
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

        private List<Cluster> InitiateCentroid()
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
        private List<Cluster> AssignToCluster(List<Cluster> clusters)
        {

            //iterate over wineItems
            foreach (var wineItem in wineItems)
            {
                int closestDistance = Int32.MaxValue;
                Cluster closestCluster = new Cluster();

                //check distance per centriod
                foreach (var cluster in clusters)
                {
                    int distance = CalculateDistance(cluster, wineItem);
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

        private List<Cluster> RecalculateCentroids(List<Cluster> clusters)
        {
            List<Cluster> newClusters = new List<Cluster>();

            // calculate mean per dimension
            // loop through clusters
            foreach (var cluster in clusters)
            {
                Cluster newcluster = new Cluster();

                // calculate new location centroid
                // put centroid in new cluster
                // add cluster to list newclusters
            }
        }

        private int CalculateDistance(Cluster cluster, WineItem wineItem)
        {
            List<float> centroidLocation = cluster.Centroid.WineData;
            List<float> wineItemLocation = wineItem.WineData;

            int distance = 0;

            for (int i = 0; i < wineItemLocation.Count; i++)
            {
                if (centroidLocation[i] != wineItemLocation[i])
                {
                    distance++;
                }
            }

            return distance;
        }

    }
}
