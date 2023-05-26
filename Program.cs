
while (true)
{
    try
    {
        Console.Write("Введите количество одногруппников: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество страниц каждому: ");
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
   
}
