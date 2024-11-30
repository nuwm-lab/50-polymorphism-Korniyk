using System;

class Fraction
{
    protected double a1;
    public virtual void SetCoefficients()
    {
        Console.Write("Введіть коефіцієнт a1: ");
        a1 = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void DisplayCoefficients()
    {
        Console.WriteLine($"Коефіцієнт a1: {a1}");
    }

    public virtual double Calculate(double x)
    {
        if (a1 == 0)
            throw new DivideByZeroException("Коефіцієнт a1 не може дорівнювати 0.");
        return 1.0 / (a1 * x + 1);
    }
}

class TrigonometricFraction : Fraction
{
    private double a2;
    private double a3;

    public override void SetCoefficients()
    {
        base.SetCoefficients();
        Console.Write("Введіть коефіцієнт a2: ");
        a2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть коефіцієнт a3: ");
        a3 = Convert.ToDouble(Console.ReadLine());
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Коефіцієнти: a1 = {a1}, a2 = {a2}, a3 = {a3}");
    }

    public override double Calculate(double x)
    {
        if (a1 == 0 || a2 == 0 || a3 == 0)
            throw new DivideByZeroException("Коефіцієнти не можуть дорівнювати 0.");
        return 1.0 / (a1 * x + (1.0 / (a2 * x + (1.0 / (a3 * x + 1)))));
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Fraction fraction = null;

            Console.WriteLine("Оберіть тип дробу:");
            Console.WriteLine("1. Простий дріб");
            Console.WriteLine("2. Тригонометричний підхідний дріб");
            Console.Write("Ваш вибір (1 або 2): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
                fraction = new Fraction();
            else if (choice == 2)
                fraction = new TrigonometricFraction();
            else
            {
                Console.WriteLine("Неправильний вибір!");
                return;
            }

            fraction.SetCoefficients();

            Console.WriteLine("\nВведені коефіцієнти:");
            fraction.DisplayCoefficients();

            Console.Write("\nВведіть значення x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            double result = fraction.Calculate(x);
            Console.WriteLine($"\nРезультат обчислення дробу при x = {x}: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
