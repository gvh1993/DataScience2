﻿using System;
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
            if (alpha == 0.5f && beta == 0.5f)
            {
                Console.WriteLine("test pause");
            }
            
            //𝒔𝒕 = 𝜶 * 𝒙𝒕 + (𝟏 − 𝜶) * (𝒔𝒕−𝟏 + 𝒃𝒕−𝟏)
            //𝒃𝒕 = 𝜷 * (𝒔𝒕 − 𝒔𝒕−𝟏) + (𝟏 − 𝜷) * 𝒃𝒕−𝟏
            
            List<double> s = new List<double>();
            List<double> b = new List<double>();

            //initialisation
            s.Add(Demand[1]); //smooth index 1
            b.Add(Demand[1] - Demand[0]); // beta index 1

            //SmoothenedData.Add(s[0] + b[0]); // t=3 == index 2

            // index 1 - 35
            for (int i = 1; i < Demand.Count -1; i++)//begin with (index 3 == t4) compared to (index 0 of DESlist == t3)
            {
                var demand = Demand[i + 1];
                var previousSmoothing = s[i - 1];
                var previousTrend = b[i - 1];
                

                var smooth = alpha * demand + (1 - alpha) * (previousSmoothing + previousTrend);
                s.Add(smooth);

                var trend = beta * (s[i] - previousSmoothing) + (1 - beta) * previousTrend;
                b.Add(trend);

                SmoothenedData.Add(s[i - 1] + b[i - 1]); //
            }


            //forecast
            //𝒇𝒕+𝟏 = 𝒔𝒕 + 𝒃𝒕
            // index 36 - 48
            int forecastCount = 0;
            for (int i = Demand.Count + 1; i <= Time.Count; i++)
            {
                forecastCount++;

                // 𝑓𝑛+𝑚 = 𝑠𝑛 + 𝑚𝑏n
                // 
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
    }
}
