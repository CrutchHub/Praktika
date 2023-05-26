
while (true)
{
    try
    {
        Console.Write("Введите первое число: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int b = Convert.ToInt32(Console.ReadLine());

        if (a < 0 || b < 0)
        {
            Console.WriteLine("0");
        }
        else
        {
            Console.WriteLine($"Количество страниц которое необходимо распечатать: {a * b}");
        }
    }
    catch
    {
        Console.WriteLine("Неправильный тип данных");
    }
   // сас
}
