using K_Means.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    public class DataProcessor
    {
        public List<WineItem> ReadFile()
        {
            List<WineItem> wineData = new List<WineItem>();
            const char DELIMETER = ',';

            using (var reader = new StreamReader("D:/Github/DataScience2/K-Means/data/WineData.csv"))
            {
                //iteration per row
                while (!reader.EndOfStream)
                {
                    // get all values per row
                    var line = reader.ReadLine();
                    var values = line.Split(DELIMETER);

                    List<float> wineValues = new List<float>();

                    // parsevalues to float
                    for (int i = 0; i < values.Length; i++)
                    {
                       float wineValue = float.Parse(values[i]);
                       wineValues.Add(wineValue);

                        //check if WineItem exist in list<WineItem>
                        if (wineData.ElementAtOrDefault(i) == null)
                        {
                            WineItem item = new WineItem();
                            item.WineData.Add(wineValue);
                            wineData.Insert(i, item);
                        }
                        else
                        {
                            //append to existing wineItem
                            wineData[i].WineData.Add(wineValue);
                        }
                    }
                }
            }

            return wineData;
        }
    }
}
