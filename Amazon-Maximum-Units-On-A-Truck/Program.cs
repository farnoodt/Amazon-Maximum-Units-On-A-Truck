using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazon_Maximum_Units_On_A_Truck
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[][]
            {
                new int[]{5,10},
                new int[]{2,5},
                new int[]{3,9},
                new int[]{ 4, 7 }
            };
            
            Console.WriteLine(MaximumUnits(arr, 10));
        }

        static  int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            Dictionary<int, int> Di = new Dictionary<int, int>();
            int Boxes = 0;
            int Max = 0;
            for (int i = 0; i< boxTypes.Length; i++)
            {
                Di.Add(boxTypes[i][0], boxTypes[i][1]);
            }
            var DS = Di.OrderByDescending(keys => keys.Value);

            for (int i = 0; i < DS.Count(); i++)
            {
                if (Boxes + DS.ElementAt(i).Key <= truckSize)
                {
                    Boxes += DS.ElementAt(i).Key;
                    Max += DS.ElementAt(i).Key * DS.ElementAt(i).Value;
                }
                else
                {
                    Max += (truckSize-Boxes) * DS.ElementAt(i).Value;
                    break;
                }
            }
            return Max;
        }
    }
}
