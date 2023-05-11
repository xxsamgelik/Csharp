using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MyArray> arrayCollection = new List<MyArray>();
            arrayCollection.Add(new MyArray(new int[] { 1, 2, 3, 4, 5 }));
            arrayCollection.Add(new MyArray(new int[] { 2, 4, 6, 8, 10 }));
            arrayCollection.Add(new MyArray(new int[] { 1, 3, 5, 7, 9 }));
            arrayCollection.Add(new MyArray(new int[] { 1, 3, 5, 7, 9 }));
            if (arrayCollection.Count % 2 == 0)
            {
                Parallel.ForEach(arrayCollection, myArray =>
                {
                    int[] oddNumbers = myArray.FindOddNumbers();
                    Console.WriteLine("Нечетные элементы массива {0}: {1}",
                                      Array.IndexOf(arrayCollection.ToArray(), myArray) + 1,
                                      string.Join(", ", oddNumbers));
                });
            }
            else
            {
                Console.WriteLine("Количество массивов в коллекции нечетное.");
            }

        }
    }
}
