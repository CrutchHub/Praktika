while (true)
{
    Console.Write("Введите номер задания:");
    int taskCode;
    while (!int.TryParse(Console.ReadLine(), out taskCode)) Console.Write("Неправильный тип данных, введите повторно:");
    Console.Clear();
    switch (taskCode)
    {
        case 1:
            for (int i = 1; i <= 100; i++) if (i % 2 == 0) Console.WriteLine(i);
            break;
        case 2:
            int firstNumber = 0, secondNumber = 1, lastNumber;
            for (int i = 1; i < 11; i++)
            {
                lastNumber = firstNumber + secondNumber;
                if (firstNumber < secondNumber) firstNumber = lastNumber;
                else secondNumber = lastNumber;
                Console.WriteLine(lastNumber);
            }
            break;
        case 3:
            // j = 1 так как я учитываю при счете 1ый день в который он пробежал 10 км
            double run = 10;
            int j = 1;
            while (run < 100) { run *= 1.1; j++; }
            Console.WriteLine($"Ответ: на {j} день он превысит 100 км");
            break;
        default:
            Console.WriteLine("Неправильный код");
            break;
    }
}









