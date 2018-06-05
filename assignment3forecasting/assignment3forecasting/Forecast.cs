using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3forecasting
{

    public abstract class Forecast
    {
        protected List<int> Time { get; set; }
        public List<int> Demand { get; set; }

        public List<double> SmoothenedData { get; set; }

        public float alpha = 0.00f;

        public double error = double.MaxValue;


        protected virtual void CalculateError()
        {
            double error = 0;

            for (int i = 0; i < Demand.Count; i++)
            {
                error += Math.Pow(Demand[i] - SmoothenedData[i], 2);

            }
            error = error / (Demand.Count - 1);

            error = Math.Sqrt(error);

            this.error = error;
        }


    }
}
