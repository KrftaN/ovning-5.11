using System;

namespace övning_5._11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] talArray = { 1, 4, 7, 10, 2 };
            double median = BeräknaMedian(talArray);
            Console.WriteLine($"Medianen är: {median}");

            int[] talArray2 = { 12345, 45561, 15451, 64132423, 4524 };
            median = BeräknaMedian(talArray2);
            Console.WriteLine($"Medianen är: {median}");

            int[] talArray3 = { 61, 51414, -1321, 312345, 61123, -56223, 5601 };
            median = BeräknaMedian(talArray3);
            Console.WriteLine($"Medianen är: {median}");
        }

        static double BeräknaMedian(int[] array)
        {
            int mittIndex = array.Length / 2;
            return FinnsMindre(array, mittIndex, array.Length) ? MedianFrånLänk(array, mittIndex) : MedianFrånMitten(array, mittIndex);
        }

        static bool FinnsMindre(int[] array, int k, int längd)
        {
            return k < längd / 2;
        }

        static double MedianFrånLänk(int[] array, int k)
        {
            int lägre = 0;
            int högre = int.MaxValue;

            foreach (int tal in array)
            {
                if (tal < högre)
                {
                    lägre = högre;
                    högre = tal;
                }
                else if (tal < lägre)
                {
                    lägre = tal;
                }
            }

            return (lägre + högre) / 2.0;
        }

        static double MedianFrånMitten(int[] array, int k)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (int tal in array)
            {
                if (tal < min) min = tal;
                if (tal > max) max = tal;
            }

            while (min < max)
            {
                int mitten = min + (max - min) / 2;
                int mindre = 0;
                int likaStora = 0;

                foreach (int tal in array)
                {
                    if (tal < mitten) mindre++;
                    if (tal == mitten) likaStora++;
                }

                if (mindre <= k && k < mindre + likaStora) return mitten;
                else if (mindre > k) max = mitten;
                else min = mitten + 1;
            }

            return min;
        }
    }
}
