using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorting
{
    class AdditionalMethods
    {
        //Создание System.Diagnostics.Stopwatch
        public static Stopwatch CreateStopwatch()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            return stopwatch;
        }

        //Замер времени работы кода и вывод на экран
        public static void TimeToWork(System.Diagnostics.Stopwatch myStopwatch, string name)
        {
            TimeSpan ts = myStopwatch.Elapsed;
            Console.WriteLine(String.Format($"Время работы {name}: {ts.TotalMilliseconds / 10}c."));
        }
        public static int[] CreateArray()
        {
            Random random = new Random();
            Console.Write("Введите количество элементов: ");
            int length = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[length];
            Console.Write("Массив: ");
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = random.Next(0, 100);
                Console.Write(array[i] + ", ");
            }
            Console.WriteLine();
            return array;
        }

        //Обычный swap
        public static void Swap(ref int x, ref int y)
        {
            int buffer = x;
            x = y;
            y = buffer;
        }

        //Доп.метод для быстрой сортировки
        public static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //Доп.метод для сортировки выбором
        public static int IndexOfMin(int[] array, int n)
        {
            int result = n;
            for (var i = n; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }
            return result;
        }
    }
}
