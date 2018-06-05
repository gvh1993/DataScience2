using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3forecasting
{
    public class SES : Forecast
    {
        public SES(float alpha, List<int> demand, List<int> time)
        {
            this.alpha = alpha;
            SmoothenedData = new List<double>();

            Demand = demand;
            Time = time;

            ComputeSES();
        }

        private void ComputeSES()
        {
            // add first value
            //SmoothenedData.Add(Demand[0]);

            // mean of first 12
            var sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += Demand[i];
                Console.WriteLine(Demand[i]);
            }
            SmoothenedData.Add((double)sum / 12);

            // index 0 - 35 
            for (int i = 1; i < Demand.Count; i++)
            {
                double smoothValue = alpha * Demand[i - 1] + (1 - alpha) * SmoothenedData[i - 1];
                SmoothenedData.Add(smoothValue);
            }

            //forecast
            // index 36 - 48
            for (int i = Demand.Count +1; i <= Time.Count; i++)
            {
                SmoothenedData.Add(SmoothenedData.Last());
            }

            CalculateError();
        }


    }
}
