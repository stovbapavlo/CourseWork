using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class BaseClass
    {
        protected int element = 1;
        protected int number = 2;
        protected int i = 0;

        public virtual bool Calculation(int n, int x, out double final)
        {
            bool test = false;
            final = 1.0;
            for (i = 0; i < n; i++)
            {
                test = true;
                if (i % 2 == 0)//парне
                {
                    final *= (number - 1) + (1 / Math.Pow(element * x, n - element));
                    number++;
                }
                else//непарне
                {
                    final *= (number) - (1 / Math.Pow(element * x, n - element));
                }
                element++;
            }
            return test;
        }
    }
    class DerivedClass : BaseClass
    {

        public override bool Calculation(int n, int x, out double final)
        {
            return CalculateRecursive(n, x, 0, 1.0, 2, 1, out final);
        }

        private bool CalculateRecursive(int n, int x, int i, double final, double number, double element, out double result)
        {
            if (i < n)
            {
                if (i % 2 == 0)//парне
                {
                    final *= (number - 1) + (1 / Math.Pow(element * x, n - element));
                    number++;
                }
                else//непарне
                {
                    final *= (number) - (1 / Math.Pow(element * x, n - element));
                }
                element++;
                i++;

                return CalculateRecursive(n, x, i, final,number, element, out result);
            }
            else
            {
                result = final;
                return true;
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double rex;

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.Calculation(9, 1, out rex);
            Console.WriteLine(rex);

            BaseClass base1 = new BaseClass();
            base1.Calculation(9, 1, out rex);
            Console.WriteLine(rex);

            Console.ReadKey();
        }
    }
}
