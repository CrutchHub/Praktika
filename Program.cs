VendingMachine vendingMachine = new();
vendingMachine.AddGood("Сок злой", 3, 50);
vendingMachine.AddGood("Сок добрый", 2, 55);
vendingMachine.AddGood("Злой кола", 4, 105);
vendingMachine.AddGood("Добрый кола", 5, 100);
vendingMachine.AddGood("Адреналин раш Б", 2, 85);
vendingMachine.AddGood("Энергетик гореть нанкин резня великий дракон", 5, 100);
vendingMachine.AddGood("Левая палочка твикс", 3, 40);
vendingMachine.AddGood("Правая палочка твикс", 4, 1000);
vendingMachine.AddGood("Батончик Илон Марс", 2, 75);
vendingMachine.AddGood("Слабительное Доктор Дизель", 2, 55);
while (true)
{
    Console.WriteLine("------Банкомат десептикон v23.07.07b приветствует вас------");
    Console.WriteLine("Вы можете ввести следующие команды:\n" +
        "AddMoney - для зачисления денег на баланс\n" +
        "GetChange - для выдачи сдачи\n" +
        "ShowGoods - для просмотра списка товаров\n" +
        "BuyGood {Номер товара} {Количество} - для покупки товара (скобки не вводить)");
    Console.Write("Введите команду:");
    string command = Console.ReadLine().ToLower();
    if (command.Contains("buygood"))
    {
        string[] buyCommand = command.Split(' ');
        try
        {
            int id = int.Parse(buyCommand[1]) - 1;
            int count = int.Parse(buyCommand[2]);
            vendingMachine.BuyGood(id, count);
        }
        catch
        {
            Console.WriteLine("Неправильно введена команда");
        }
    }
    else
    {
        switch (command)
        {
            case "addmoney":
                vendingMachine.AddMoney();
                break;
            case "getchange":
                vendingMachine.GetChange();
                break;
            case "showgoods":
                vendingMachine.ShowGoods();
                break;
            default: Console.WriteLine("Такой команды нет"); break;
        }
    }
}


