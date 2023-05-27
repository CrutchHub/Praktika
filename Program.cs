while (true)
{
    Console.Write("Введите номер задания:");
    int taskCode;
    while (!int.TryParse(Console.ReadLine(), out taskCode)) Console.Write("Неправильный тип данных, введите повторно:");
    switch (taskCode)
    {
        case 1:
            Console.Write("Введите температуру по шкале цельсия:");
            double temp;
            while (!double.TryParse(Console.ReadLine(), out temp)) Console.Write("Неправильный тип данных, введите повторно:");
            double farrengate = Math.Round(temp * (9.0 / 5) + 32, 3);
            double kelvin = temp + 273.15;
            Console.WriteLine($"Температура по шкале Фарренгейта: {farrengate}\n Температура по шкале Кельвина: {kelvin}");
            break;
        case 2:
            Console.WriteLine(
                "Выберите код операциии из следующего списка:\n" +
                "1 - Сложение\n" +
                "2 - Вычитание\n" +
                "3 - Умножение\n" +
                "4 - Деление\n" +
                "5 - Остаток от деления"
                );
            int code;
            Console.Write("Введите код:");
            while (!int.TryParse(Console.ReadLine(), out code)) Console.Write("Неправильный тип данных, введите повторно:");
            if (code < 0 || code > 5) { Console.WriteLine("Неправильный код"); continue; }
            Console.Write("Введите первое число: ");
            double a, b;
            while (!double.TryParse(Console.ReadLine(), out a)) Console.Write("Неправильный тип данных, введите повторно:");
            Console.Write("Введите второе число: ");
            while (!double.TryParse(Console.ReadLine(), out b)) Console.Write("Неправильный тип данных, введите повторно:");
            if (b == 0 && (code == 4 || code == 5)) { Console.WriteLine("Нельзя указывать 0 в качестве делителя"); continue; }
            switch (code)
            {
                case 1: Console.WriteLine($"Результат операции: {a + b}"); break;
                case 2: Console.WriteLine($"Результат операции: {a - b}"); break;
                case 3: Console.WriteLine($"Результат операции: {a * b}"); break;
                case 4: Console.WriteLine($"Результат операции: {Math.Round(a / b, 3)}"); break;
                case 5: Console.WriteLine($"Результат операции: {a % b}"); break;
            }
            break;
        case 3:
            int c, d;
            Console.Write("Введите первое число: ");
            while (!int.TryParse(Console.ReadLine(), out c)) Console.Write("Неправильный тип данных, число должно быть целым и не отрицательным, не должно содержать букв или спецсимволов, введите повторно:");
            Console.Write("Введите второе число: ");
            while (!int.TryParse(Console.ReadLine(), out d)) Console.Write("Неправильный тип данных, число должно быть целым и не отрицательным, не должно содержать букв или спецсимволов, введите повторно:");
            if ((c > 0 && c < 10) && (d > 0 && d < 10))
            {
                int rightAnswer = c * d;
                int userAnswer;
                Console.Write("Напишите результат умножения этих чисел: ");
                while (!int.TryParse(Console.ReadLine(), out userAnswer)) Console.Write("Неправильный тип данных, число должно быть целым и не отрицательным, не должно содержать букв или спецсимволов, введите повторно:");
                if (userAnswer == rightAnswer) Console.WriteLine("Ответ правильный");
                else Console.WriteLine($"Ответ неверный, правильный ответ: {rightAnswer}");
            }
            else Console.WriteLine("Числа должны быть в пределе от 1 до 9");
            break;
        case 4:
            int age;
            Console.Write("Введите ваш возраст:");
            while (!int.TryParse(Console.ReadLine(), out age)) Console.Write("Неправильный тип данных, число должно быть целым и не отрицательным, не должно содержать букв или спецсимволов, введите повторно:");
            string agestring = "" + age;
            string yearsWord;
            if (age > 20) agestring = Convert.ToString(agestring[agestring.Length - 1]);
            Console.WriteLine(agestring);
            if (age > 0 && age < 100)
            {

                if (age == 1 || Convert.ToInt32(agestring) == 1) yearsWord = "год";
                else if (age > 9 && age < 20) yearsWord = "лет";
                else if (Convert.ToInt32(agestring) > 1 && Convert.ToInt32(agestring) < 5) yearsWord = "года";
                else yearsWord = "лет";
                Console.WriteLine($"Мне {age} {yearsWord}");
            }
            else Console.WriteLine("Возраст не может быть меньше 1 и больше 99");
            break;
        default: Console.WriteLine("Неверный код"); break;
    }
}















