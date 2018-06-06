using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3forecasting
{
    public class DES : Forecast
    {
        public float beta = 0.00f;

        public DES(float alpha, float beta, List<int> demand, List<int> time)
        {
            this.alpha = alpha;
            this.beta = beta;

            SmoothenedData = new List<double>();
            Demand = demand;
            Time = time;

            ComputeDES();
        }

        private void ComputeDES()
        {
            if (alpha == 0.33f && beta == 0.37f)
            {
                Console.WriteLine("test pause");
            }
            
            //𝒔𝒕 = 𝜶 * 𝒙𝒕 + (𝟏 − 𝜶) * (𝒔𝒕−𝟏 + 𝒃𝒕−𝟏)
            //𝒃𝒕 = 𝜷 * (𝒔𝒕 − 𝒔𝒕−𝟏) + (𝟏 − 𝜷) * 𝒃𝒕−𝟏
            
            List<double> s = new List<double>();
            List<double> b = new List<double>();
//            s.Add(0);
            s.Add(Demand[1]); //smooth index 1

  //          b.Add(0);
            b.Add(Demand[1] - Demand[0]); // beta index 1

            //SmoothenedData.Add(s[0] + b[0]); // t=3 == index 2

            // index 2 - 35
            for (int i = 1; i < Demand.Count -1; i++)//begin with (index 3 == t4) compared to (index 0 of DESlist == t3)
            {
                var demand = Demand[i + 1];
                var previousSmoothing = s[i - 1];
                var previousTrend = b[i - 1];

                var smooth = alpha * Demand[i + 1] + (1 - alpha) * (s[i - 1] + b[i - 1]);
                s.Add(smooth);

                var trend = beta * (s[i] - s[i - 1]) + (1 - beta) * b[i - 1];
                b.Add(trend);


                SmoothenedData.Add(s[i - 1] + b[i - 1]); //
            }

            // extra 1 possible
            //SmoothenedData.Add(s.Last() + b.Last());
            //forecast
            //𝒇𝒕+𝟏 = 𝒔𝒕 + 𝒃𝒕
            // index 36 - 48
            for (int i = Demand.Count +1; i <= Time.Count; i++)
            {
                SmoothenedData.Add(s.Last() + (i - Demand.Count) * b.Last());
            }

            CalculateError();
        }
        protected override void CalculateError()
        {
            double error = 0;

            for (int i = 0; i < Demand.Count; i++)//compare index 0 with 2
            {
                error += Math.Pow(Demand[i] - SmoothenedData[i], 2);

            }
            error = error / (Demand.Count - 1);

            error = Math.Sqrt(error);

            this.error = error;
        }
        //private void CalculateError()
        //{
        //    double error = 0;

        //    for (int i = 0; i < Demand.Count; i++)
        //    {
        //        error += Demand[i] - SmoothenedData[i];
        //    }

        //    error = Math.Pow(error, 2);
        //    error = error / Demand.Count - 1;

        //    error = Math.Sqrt(error);

        //    this.error = error;
        //    //if (error < this.error && alpha < 1 && beta < 1)
        //    //{
        //    //    this.error = error;
        //    //    alpha += 0.1f;
        //    //    beta += 0.1f;
        //    //    Reset();
        //    //}
        //}

        //private void Reset()
        //{
        //    SmoothenedData.Clear();
        //    ComputeDES();
        //}
    }
}
