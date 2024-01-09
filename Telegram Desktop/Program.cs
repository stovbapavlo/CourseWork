using System;

namespace лр5_блок1
{
    class Program
    {
        static long FindGcd(long nom, long denom)
        {
            nom = Math.Abs(nom);
            denom = Math.Abs(denom);

            if (nom == 0)
            {
                return 1;
            }
            else
            {
                while (nom != 0 && denom != 0)
                {
                    if (nom > denom)
                    {
                        nom %= denom;
                    }
                    else
                    {
                        denom %= nom;
                    }
                }

                long gcd = nom+denom;
                return gcd;
            }
        }

        struct MyFrac
        {
            public long nom, denom;
            public MyFrac(long nom_, long denom_)
            {
                nom = nom_;
                denom = denom_;

                long gcd = FindGcd(nom, denom);

                nom = nom / gcd;
                denom = denom / gcd;

                if (nom < 0 && denom < 0)
                {
                    nom = Math.Abs(nom);
                    denom = Math.Abs(denom);
                }
                else if (denom < 0)
                {
                    nom = -1 * nom;
                    denom = Math.Abs(denom);
                }
            }
            public override string ToString()
            {
                return nom + "/" + denom;
            }
        }

        static string ToStringWithIntPart(MyFrac f)
        {
            long whole_part = f.nom / f.denom;
            long nom = f.nom % f.denom;
            string str = "(" + Math.Abs(whole_part) + "+" + Math.Abs(nom) + "/" + Math.Abs(f.denom) + ")";
            if (f.nom < 0 || f.denom < 0)
            {
                str = "-(" + Math.Abs(whole_part) + "+" + Math.Abs(nom) + "/" + Math.Abs(f.denom) + ")";
            }
            return str;
        }

        static double DoubleValue(MyFrac f)
        {
            return Convert.ToDouble(f.nom) / Convert.ToDouble(f.denom);
        }

        static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom,
            f1.denom * f2.denom);
        }

        static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom,
            f1.denom * f2.denom);
        }

        static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }

        static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }

        static MyFrac CalcExpr1(int n)
        {
            MyFrac res = new MyFrac(0, 1);
            for(long i = 1; i <= n; i++)
            {
                MyFrac add = new MyFrac(1, i * (i + 1));
                res = Plus(res, add);
            }
            return res;
        }

        static MyFrac CalcExpr2(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                MyFrac f1 = new MyFrac(1, 1);
                MyFrac f2 = new MyFrac(1, i * i);
                MyFrac frac = Minus(f1, f2);

                res = Multiply(res, frac);
            }
            return res;
        }

        static void Main(string[] args)
        {
            Console.Write("Введіть чисельник дробу: ");
            long nom = int.Parse(Console.ReadLine());
            Console.Write("Введіть знаменник дробу: ");
            long denom = int.Parse(Console.ReadLine());

            MyFrac frac = new MyFrac(nom, denom);

            Console.WriteLine("Скорочений дріб: {0}", frac);

            Console.WriteLine("Дріб з виділеною цілою частиною: {0}", ToStringWithIntPart(frac));

            Console.WriteLine("Дійсне значення дробу: {0}", DoubleValue(frac));

            Console.Write("\nВведіть чисельник іншого дробу: ");
            long nom2 = int.Parse(Console.ReadLine());
            Console.Write("Введіть знаменник іншого дробу: ");
            long denom2 = int.Parse(Console.ReadLine());

            int choice;
            do
            {
                Console.WriteLine("\nЩоб додати два дроби натисніть 1, відняти - 2, помножити - 3, поділити - 4 " +
                "порахувати за першою формулою - 5, порахувати за другою формулою - 6 або нуль для завершення");
                choice = int.Parse(Console.ReadLine());

                MyFrac frac2 = new MyFrac(nom2, denom2);

                if (choice == 1)
                {
                    Console.WriteLine("Результат: " + Plus(frac, frac2));
                }
                if (choice == 2)
                {
                    Console.WriteLine("Результат: " + Minus(frac, frac2));
                }
                if (choice == 3)
                {
                    Console.WriteLine("Результат: " + Multiply(frac, frac2));
                }
                if (choice == 4)
                {
                    Console.WriteLine("Результат: " + Divide(frac, frac2));
                }
                if(choice == 5)
                {
                    Console.Write("\nВведіть n, щоб порахувати суму за формулою 1 / (1 * 2) + 1 / (2 * 3) + 1 / (3 * 4) + ...+1 / (n * (n + 1)): ");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + CalcExpr1(n));
                    Console.WriteLine("Перевірка: " + new MyFrac(n, n + 1));
                }
                if (choice == 6)
                {
                    Console.Write("\nВведіть n, щоб порахувати суму за формулою (1–1/4)*(1–1/9)*(1–1/16)*...*(1–1/n*n): ");
                    int n2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + CalcExpr2(n2));
                    Console.WriteLine("Перевірка: " + new MyFrac(n2 + 1, 2 * n2));
                }
            } while (choice != 0);
        }
    }
}
