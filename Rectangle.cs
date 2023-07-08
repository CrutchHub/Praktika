public class VendingMachine
{
    public List<Dictionary<string, object>> Goods { get => _goods; protected set => _goods = value; }
    public double MoneyOnBalance { get => _moneyOnBalance; protected set => _moneyOnBalance = value; }

    protected List<Dictionary<string, object>> _goods = new List<Dictionary<string, object>>();
    protected double _moneyOnBalance;

    public void AddMoney()
    {
        int paymentType;
        int paymentSum;
        do
        {
            Console.Write("Необходимо выбрать тип оплаты. Если хотите картой, введите 1, если монетами - введите 2:");
        }
        while (!int.TryParse(Console.ReadLine(), out paymentType) || (paymentType != 1 && paymentType != 2));
        if (paymentType == 1)
        {
            Console.Write("Введите сумму:");
            while (!int.TryParse(Console.ReadLine(), out paymentSum) || paymentSum < 1) Console.Write("Неправильная сумма, введите снова:");
            MoneyOnBalance += paymentSum;
            Console.WriteLine("Успешное пополнение");
        }
        else
        {
            int tenCoins; int fiveCoins; int twoCoins; int oneCoins;
            Console.Write("Введите количество десятирублевых монет:");
            while (!int.TryParse(Console.ReadLine(), out tenCoins) || tenCoins < 0)
            {
                Console.Write("Неправильный ввод, повторите:");
            }
            Console.Write("Введите количество пятирублевых монет:");
            while (!int.TryParse(Console.ReadLine(), out fiveCoins) || fiveCoins < 0)
            {
                Console.Write("Неправильный ввод, повторите:");
            }
            Console.Write("Введите количество двухрублевых монет:");
            while (!int.TryParse(Console.ReadLine(), out twoCoins) || twoCoins < 0)
            {
                Console.Write("Неправильный ввод, повторите:");
            }
            Console.Write("Введите количество однорублевых монет:");
            while (!int.TryParse(Console.ReadLine(), out oneCoins) || oneCoins < 0)
            {
                Console.Write("Неправильный ввод, повторите:");
            }
            MoneyOnBalance += tenCoins * 10 + fiveCoins * 5 + twoCoins * 2 + oneCoins;
            Console.WriteLine("Успешное пополнение");
        }
        Console.WriteLine($"На балансе сейчас:{MoneyOnBalance} руб.\n------------");
    }

    public void GetChange()
    {
        double tenCoins; double fiveCoins; double twoCoins; double oneCoins; double sum = MoneyOnBalance;
        tenCoins = Math.Truncate(MoneyOnBalance / 10.0);
        MoneyOnBalance -= tenCoins * 10;
        fiveCoins = Math.Truncate(MoneyOnBalance / 5.0);
        MoneyOnBalance -= fiveCoins * 5;
        twoCoins = Math.Truncate(MoneyOnBalance / 2.0);
        MoneyOnBalance -= twoCoins * 2;
        oneCoins = MoneyOnBalance;
        MoneyOnBalance -= oneCoins;
        Console.WriteLine("-----Ваша сдача-----");
        Console.WriteLine(
            $"Количество десятирублевых монет:{tenCoins}\n" +
            $"Количество пятирублевых монет:{fiveCoins}\n" +
            $"Количество двухрублевых монет:{twoCoins}\n" +
            $"Количество однорублевых монет:{oneCoins}\n" +
            $"В сумме:{sum}\n" +
            $"------------"
            );
    }

    public void ShowGoods()
    {
        Console.WriteLine("------Список товаров------");
        for (int i = 0; i < Goods.Count; i++)
        {
            Console.WriteLine($"Номер товара:{i + 1}\nНазвание товара:{Goods[i]["Название"]}\n" +
                $"Количество товара:{Goods[i]["Количество"]}\nЦена товара:{Goods[i]["Цена"]}\n");
        }
        Console.WriteLine("------------");
    }

    public bool BuyGood(int id, int count)
    {
        if (count <= 0) { Console.WriteLine("Неправильное количество товара"); return false; }
        try
        {
            if ((int)Goods[id]["Количество"] < count || (double)Goods[id]["Цена"] * count > MoneyOnBalance)
            {
                Console.WriteLine("Товаров в наличии меньше введенного количества или недостаточно денег на балансе");
                return false;
            }
            else
            {
                int Remains = (int)Goods[id]["Количество"];
                Remains -= count;
                Goods[id]["Количество"] = Remains;
                MoneyOnBalance -= (double)Goods[id]["Цена"] * count;
                Console.WriteLine($"Успешная покупка. Остаток на балансе:{MoneyOnBalance}");
                Console.WriteLine("------------");
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Такого товара нет в списке");
            return false;
        }
    }

    /// <summary>
    /// Добавляет товар в список. Необходимо указать в параметрах название, количество и цену.
    /// </summary>
    /// <param name="name">Название товара</param>
    /// <param name="count">Кол-во товара</param>
    /// <param name="price">Цена</param>
    public void AddGood(string name, int count, double price)
    {
        Dictionary<string, object> newGood = new Dictionary<string, object>
        {
            { "Название", name },
            { "Количество", count },
            { "Цена", price }
        };
        Goods.Add(newGood);
    }
    /// <summary>
    /// Удаляет товар из списка. Требует указания ID товара в качестве параметра.
    /// </summary>
    /// <param name="id">ID товара</param>
    /// <returns>true, если успешно и false, если неудачно</returns>
    public bool RemoveGood(int id)
    {
        try
        {
            Goods.RemoveAt(id);
        }
        catch
        {
            return false;
        }
        return true;
    }
}


