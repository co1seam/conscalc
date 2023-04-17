using System;

namespace conscalc
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c=0;       // Коэффициенты квадратного уравнения
            double fa, fb, fc;      // Функции
            double x1, x2;          // Корни уравнения
            double eps = 0.000001;  //Точность вычесления корня

            // запрашиваем у пользователя коэффициенты a, b и c квадратного уравнения
            Console.WriteLine("Введите коэффициенты квадратного уравнения ax^2 + bx + c = 0:");
            Console.Write("Введите a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите c: ");
            c = Convert.ToDouble(Console.ReadLine());

            // вычисляем значения функции f(x) в точках -10^10, 0, 10^10    
            fa = a * Math.Pow(-10, 10) * Math.Pow(-10, 10) + b * -10 + c;
            fb = a * Math.Pow(10, 10) * Math.Pow(10, 10) + b * 10 + c;
            fc = a * Math.Pow(0, 10) * Math.Pow(0, 10) + b * 0 + c;

            // Отладка значений функций в точках -10^10, 10^10 и 0
            Console.WriteLine($"Значение функции f(x) в точке -10^10: {fa}");
            Console.WriteLine($"Значение функции f(x) в точке 10^10: {fb}");
            Console.WriteLine($"Значение функции f(x) в точке 0: {fc}");

            // проверяем, находятся ли корни уравнения в интервале [-10^10,10^10]
            if (fa * fb > 0)
            {
                Console.WriteLine("Корни уравнения находятся вне отрезка [-10^10;10^10]");
                return;
            }

            // проверяем, какой из корней находится в интервале [-10,0], а какой в интервале [0,10]
            if (fa * fc > 0)
            {
                x1 = -10;
                x2 = 0;
            }
            else
            {
                x1 = 0;
                x2 = 10;
            }

            // Отладка значений x1 и x2
            Console.WriteLine($"Значение x1: {x1}");
            Console.WriteLine($"Значение x2: {x2}");

            // метод половинного деления для нахождения корней уравнения
            while (Math.Abs(x2 - x1) > eps)
            {
                double x = (x1 + x2) / 2;
                double f = a * Math.Pow(x, 2) + b * x + c;
                if (f * (a * Math.Pow(x1, 2) + b * x1 + c) < 0)
                {
                    x2 = x;
                }
                else
                {
                    x1 = x;
                }
            }

            Console.WriteLine($"Корни уравнения: x1 = {x1}, x2 = {x2}");
        }
    }
}