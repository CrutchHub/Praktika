Random random = new();

Console.WriteLine("Первое задание");
string[,] academicPerfomance = {
       {"Ученик", "Информатика", "Разработка игр", "Основы алгоритмизации" },
       { "1", "", "", "" },
       { "2", "", "", "" },
       { "3", "", "", "" },
       { "4", "", "", "" },
       { "5", "", "", "" }
};

for (int i = 1; i < academicPerfomance.GetLength(0); i++)
{
    for (int j = 1; j < academicPerfomance.GetLength(1); j++)
    {
        academicPerfomance[i, j] = Convert.ToString(random.Next(2, 6));
    }
}
for (int i = 0; i < academicPerfomance.GetLength(0); i++)
{
    for (int j = 0; j < academicPerfomance.GetLength(1); j++)
    {
        Console.Write($"|{academicPerfomance[i, j],+21}| ");
    }
    Console.WriteLine();
}
string userInput = "";
bool isCorrect = false;
Console.Write("Желаете изменить оценки? Введите да/нет:");
do
{
    userInput = Console.ReadLine();
    if (userInput.ToLower() == "да" || userInput.ToLower() == "нет") isCorrect = true;
}
while (!isCorrect);

if (userInput.ToLower() != "нет")
{
    bool finish = false;
    while (!finish)
    {
        Console.Clear();
        PrintTable(academicPerfomance);
        Console.Write("Введите номер предмета:");
        int subjectCode = 0;
        bool isValid;
        do isValid = int.TryParse(Console.ReadLine(), out subjectCode) && subjectCode > 0 && subjectCode < 4;
        while (!isValid);
        Console.Write("Введите номер ученика:");
        int studentCode = 0;
        do isValid = int.TryParse(Console.ReadLine(), out studentCode) && studentCode > 0 && studentCode < 6;
        while (!isValid);
        Console.Write("Введите оценку:");
        int mark = 0;
        do isValid = int.TryParse(Console.ReadLine(), out mark) && mark > 1 && mark < 6;
        while (!isValid);
        academicPerfomance[studentCode, subjectCode] = "" + mark;
        Console.Clear();
        PrintTable(academicPerfomance);
        Console.Write("Продолжить изменения?:");
        isCorrect = false;
        do { userInput = Console.ReadLine(); if (userInput.ToLower() == "да" || userInput.ToLower() == "нет") isCorrect = true; }
        while (!isCorrect);
        if (userInput.ToLower() == "да") continue;
        else finish = true;
    }
}


Console.WriteLine("2 задание");
int[] numbers = new int[random.Next(5, 10)];
for (int i = 0; i < numbers.Length; i++) { numbers[i] = random.Next(-10, 11); Console.Write(numbers[i] + " "); }
Console.WriteLine("\nВывод элементов массива в обратном порядке:");
for (int i = numbers.Length - 1; i >= 0; i--) { Console.Write(numbers[i] + " "); }
Console.WriteLine("\nВывод через 1 элемент:");
for (int i = 0; i < numbers.Length; i += 2) { Console.Write(numbers[i] + " "); }
Console.WriteLine("\nВывод до первого -1:");
for (int i = 0; i < numbers.Length; i++) { Console.Write(numbers[i] + " "); if (numbers[i] == -1) break; }


Console.WriteLine("\n-------------------------------\nДополнительное задание");
Console.WriteLine("Первый номер:");
int[,] temp = {
                {-8,-14,-19,-18},
                { 25,28, 26, 20},
                { 11,18, 20, 25}
               };
Console.WriteLine($"Температура 4 дня на 2 метеостанции:{temp[1, 3]}\nТемпература 1 дня на 3 метеостанции:{temp[2, 0]}");
Console.WriteLine("-------------------------------\nВторой номер:");
for (int i = 0; i < temp.GetLength(0); i++)
{
    for (int j = 1; j < 2; j++)
    {
        Console.WriteLine($"Температура {i + 1} метеостанции на {j + 1} день = {temp[i, j]}");
    }
}
Console.WriteLine("-------------------------------\nТретий номер:");
for (int i = 0; i < temp.GetLength(0); i++)
{
    for (int j = 0; j < temp.GetLength(1); j++)
    {
        Console.WriteLine($"Температура {i + 1} метеостанции на {j + 1} день = {temp[i, j]}");
    }
}
Console.WriteLine("-------------------------------\nЧетвертый номер:");
double avg = 0;
for (int j = 0; j < temp.GetLength(1); j++)
{
    avg += temp[2, j];
}
Console.WriteLine($"Средняя температура на 3 метеостанции = {avg / temp.GetLength(1)}");
Console.WriteLine("-------------------------------\nПятый номер:");
for (int i = 0; i < temp.GetLength(0); i++)
{
    for (int j = 0; j < temp.GetLength(1); j++)
    {
        if (temp[i, j] > 23 && temp[i, j] < 27) Console.WriteLine($"Температура {i + 1} метеостанции на {j + 1} день = {temp[i, j]} и была в диапазоне 24-26 градусов");
    }
}

static void PrintTable(string[,] table)
{
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            Console.Write($"|{table[i, j],+21}| ");
        }
        Console.WriteLine();
    }
}










