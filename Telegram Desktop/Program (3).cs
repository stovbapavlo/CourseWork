using System;

namespace лаб1сем2
{
    class Program
    {
        static int[] ArrayNew()
        {
            Console.WriteLine("Введiть 1, якщо ви бажаєте заповнити масив випадковим чином.");
            Console.WriteLine("Введiть 2, якщо ви бажаєте заповнити масив вручну в стовпчик.");
            Console.WriteLine("Введiть 3, якщо ви бажаєте заповнити масив вручну в рядок.");
            sbyte choice = sbyte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    int[] arr1 = Array1();
                    PrintArray(arr1);
                    return arr1;
                case 2:
                    int[] arr2 = Array2();
                    return arr2;
                case 3:
                    int[] arr3 = Array3();
                    return arr3;
                default:
                    Console.WriteLine($"Команда \"{choice}\" не розпiзнана.");
                    break;
            }
            return null;
        }
        static void PrintArray(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] Array1()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв:");
            int count = int.Parse(Console.ReadLine());
            int[] x = new int[count];
            Random rnd = new Random();
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = rnd.Next(-100, 100);
            }
            return x;
        }
        static int[] Array2()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв:");
            int count = int.Parse(Console.ReadLine());
            int[] x = new int[count];
            Console.WriteLine("Введiть елементи масиву:");
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = int.Parse(Console.ReadLine());
            }
            return x;
        }
        static int[] Array3()
        {
            Console.WriteLine("Введiть елементи масиву:");
            string[] str = Console.ReadLine().Split();
            int[] x = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                x[i] = int.Parse(str[i]);
            }
            return x;
        }
        static int MinAndMaxNums(int[] arr, out int max)
        {
            int imin = 0;
            int imax = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[imax])
                {
                    imax = i;
                }
                if (arr[i] < arr[imin])
                {
                    imin = i;
                }
            }
            max = Math.Max(imax, imin);
            int min = Math.Min(imax, imin);
            return min;
        }
        static int SumOfElements(int[] arr, int min, int max) 
        {
            int sum = 0;
            for (int i = min + 1; i < max; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int[] arr = ArrayNew();
            int min = MinAndMaxNums(arr, out int max);
            int sum = SumOfElements(arr, min, max);
            Console.WriteLine($"Сума елементiв масиву, якi розмiщенi мiж першими входженнями максимального та мiнiмального чисел дорiвнює {sum}.");
        }
    }
}
