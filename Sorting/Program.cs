using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Sorting
{
    class Program : AdditionalMethods
    {
        static void Main(string[] args)
        {

                    Stopwatch myStopwatch = CreateStopwatch();
                    int[] array = CreateArray();
                    Console.Write("\n1. Быстрая сортировка\n2. Сортировка пузырьком\n3. Сортировка вставками\n4. Шейкерная (Коктельная) сортировка\n5. Сортировка Шелла\n" +
                        "6. Сортировка выбором\n7. ВСЁ И СРАЗУ\n\nВыберите: ");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            {
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                QuickSort(array);
                                myStopwatch.Stop();
                                Console.WriteLine($"\nУпорядоченный массив: {string.Join(", ", array)}");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                TimeToWork(myStopwatch, "быстрой сортировкой");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case "2":
                            {
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                BubbleSort(array);
                                myStopwatch.Stop();
                                Console.WriteLine($"\nУпорядоченный массив: {string.Join(", ", array)}");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                TimeToWork(myStopwatch, "сортировки пузырьком");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case "3":
                            {
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                InsertionSort(array);
                                myStopwatch.Stop();
                                Console.WriteLine($"\nУпорядоченный массив: {string.Join(", ", array)}");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                TimeToWork(myStopwatch, "сортировки вставками");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case "4":
                            {
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                ShakerSort(array);
                                myStopwatch.Stop();
                                Console.WriteLine($"\nУпорядоченный массив: {string.Join(", ", array)}");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                TimeToWork(myStopwatch, "сортировки шейкером");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case "5":
                            {
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                ShellSort(array);
                                myStopwatch.Stop();
                                Console.WriteLine($"\nУпорядоченный массив: {string.Join(", ", array)}");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                TimeToWork(myStopwatch, "сортировки Шелла");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case "6":
                            {
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                SelectionSort(array);
                                myStopwatch.Stop();
                                Console.WriteLine($"\nУпорядоченный массив: {string.Join(", ", array)}");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                TimeToWork(myStopwatch, "сортировки выбором");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case "7":
                            {
                                int[] arrayQuick = array;
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                QuickSort(arrayQuick); //Быстрая сортировка
                                myStopwatch.Stop();
                                Console.WriteLine($"\nУпорядоченный массив: {string.Join(", ", arrayQuick)}\n"); //Выводим только 1 раз, каждый раз не имеет смысла
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                TimeToWork(myStopwatch, "быстрой сортировки");
                                ;
                                int[] arrayBubble = array;
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                BubbleSort(arrayBubble); //Сортировка пузырьком
                                myStopwatch.Stop();
                                TimeToWork(myStopwatch, "сортировки пузырьком");

                                int[] arrayInsert = array;
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                InsertionSort(arrayInsert); //Сортировка вставками
                                myStopwatch.Stop();
                                TimeToWork(myStopwatch, "сортировки вставками");

                                int[] arrayShaker = array;
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                ShakerSort(arrayShaker); //Сортировка шейкером
                                myStopwatch.Stop();
                                TimeToWork(myStopwatch, "сортировки шейкером");

                                int[] arrayShell = array;
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                ShellSort(arrayShell); //Сортировка Шелла
                                myStopwatch.Stop();
                                TimeToWork(myStopwatch, "сортировки Шелла");

                                int[] arraySelection = array;
                                myStopwatch.Reset();
                                myStopwatch.Start();
                                SelectionSort(arraySelection); //Сортировка выбором
                                myStopwatch.Stop();
                                TimeToWork(myStopwatch, "сортировки выбором");



                                break;
                            }
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка: введено некорректное значение");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                    }


                    //Закрытие программы
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nНажмите");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" Enter");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", чтобы закончить.");
                button:
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key != ConsoleKey.Enter)
                    {
                        goto button;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                //Быстрая сортировка
                static int[] QuickSort(int[] array, int minIndex, int maxIndex)
                {
                    if (minIndex >= maxIndex)
                    {
                        return array;
                    }

                    var pivotIndex = Partition(array, minIndex, maxIndex);
                    QuickSort(array, minIndex, pivotIndex - 1);
                    QuickSort(array, pivotIndex + 1, maxIndex);

                    return array;
                }
                static int[] QuickSort(int[] array)
                {
                    return QuickSort(array, 0, array.Length - 1);
                }

                //Сортировка пузырьком
                static int[] BubbleSort(int[] array)
                {
                    int temp;
                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int j = i + 1; j < array.Length; j++)
                        {
                            if (array[i] > array[j])
                            {
                                temp = array[i];
                                array[i] = array[j];
                                array[j] = temp;
                            }
                        }
                    }
                    return array;
                }

                //Сортировка вставками
                static int[] InsertionSort(int[] array)
                {
                    for (var i = 1; i < array.Length; i++)
                    {
                        var key = array[i];
                        var j = i;
                        while ((j > 1) && (array[j - 1] > key))
                        {
                            Swap(ref array[j - 1], ref array[j]);
                            j--;
                        }

                        array[j] = key;
                    }

                    return array;
                }

                //Шейкерная (коктельная) сортировка
                static int[] ShakerSort(int[] array)
                {
                    for (var i = 0; i < array.Length / 2; i++)
                    {
                        var swapFlag = false;
                        //проход слева направо
                        for (var j = i; j < array.Length - i - 1; j++)
                        {
                            if (array[j] > array[j + 1])
                            {
                                Swap(ref array[j], ref array[j + 1]);
                                swapFlag = true;
                            }
                        }

                        //проход справа налево
                        for (var j = array.Length - 2 - i; j > i; j--)
                        {
                            if (array[j - 1] > array[j])
                            {
                                Swap(ref array[j - 1], ref array[j]);
                                swapFlag = true;
                            }
                        }

                        //если обменов не было выходим
                        if (!swapFlag)
                        {
                            break;
                        }
                    }

                    return array;
                }

                //Сортировка Шелла
                static int[] ShellSort(int[] array)
                {
                    //расстояние между элементами, которые сравниваются
                    int distance = array.Length / 2;
                    while (distance >= 1)
                    {
                        for (int i = distance; i < array.Length; i++)
                        {
                            int j = i;
                            while ((j >= distance) && (array[j - distance] > array[j]))
                            {
                                Swap(ref array[j], ref array[j - distance]);
                                j -= distance;
                            }
                        }
                        distance /= 2;
                    }
                    return array;
                }

                //Сортировка выбором
                static int[] SelectionSort(int[] array, int currentIndex = 0)
                {
                    if (currentIndex == array.Length)
                    {
                        return array;
                    }
                    int index = IndexOfMin(array, currentIndex);
                    if (index != currentIndex)
                    {
                        Swap(ref array[index], ref array[currentIndex]);
                    }
                    return SelectionSort(array, currentIndex + 1);
                }
    }
}
