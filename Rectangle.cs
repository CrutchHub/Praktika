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
            while (!int.TryParse(Console.ReadLine(), out paymentSum) && paymentSum < 1) Console.Write("Неправильная сумма, введите снова:");
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

    public bool BuyGood (int id, int count)
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




public abstract class Transport 
{
    public string Manufacturer { get => _manufacturer; protected set => _manufacturer = value; }
    public string Name { get => _name; protected set => _name = value; }
    public double Weight { get => _weight; protected set => _weight = value; }
    public double Cost { get => _cost; protected set => _cost = value; }
    public bool IsEngineEnabled { get => _isEngineEnabled; protected set => _isEngineEnabled = value; }

    protected string _manufacturer;
    protected string _name;
    protected double _weight;
    protected double _cost;
    protected bool _isEngineEnabled = false;

    public Transport(string manufacturer, string name, double weight, double cost)
    {
        Manufacturer = manufacturer;
        Weight = weight;
        Cost = cost;
        Name = name;
    }
    /// <summary>
    /// Запустить двигатель
    /// </summary>
    public void StartEngine() {
        if (IsEngineEnabled == false) { IsEngineEnabled = true; Console.WriteLine("Двигатель успешно запущен"); }
        else Console.WriteLine("Двигатель уже был ранее запущен");
    }
    /// <summary>
    /// Выключить двигатель
    /// </summary>
    public void StopEngine()
    {
        if (IsEngineEnabled == true) { IsEngineEnabled = false; Console.WriteLine("Двигатель выключен"); }
        else { Console.WriteLine("Двигатель уже был ранее выключен"); }
    }
    /// <summary>
    /// Отобразить информацию о транспорте
    /// </summary>
    public virtual void ShowInfo() {
        Console.WriteLine("---Информация о транспорте---");
        Console.WriteLine($"Производитель:{Manufacturer}");
        Console.WriteLine($"Название:{Name}");
        Console.WriteLine($"Масса:{Weight}");
        Console.WriteLine($"Цена:{Cost}");
        Console.WriteLine($"Запущен ли двигатель?:{IsEngineEnabled}");
    }
}
public class Auto : Transport
{
    public string TypeOfRubber { get => _typeOfRubber; protected set => _typeOfRubber = value; }
    public string Class { get => _class; protected set => _class = value; }
    public bool IsTheTrunkOpen { get => _isTheTrunkOpen; protected set => _isTheTrunkOpen = value; }

    protected string _typeOfRubber;
    protected string _class;
    protected bool _isTheTrunkOpen = false;

    public Auto(string typeOfRubber, string @class,string manufacturer, double weight, double cost, string name) : base(manufacturer, name, weight, cost)
    {
        TypeOfRubber = typeOfRubber;
        Class = @class;
    }
    /// <summary>
    /// Открыть багажник
    /// </summary>
    public virtual void OpenTheTrunk()
    {
        if (IsTheTrunkOpen == false) { IsTheTrunkOpen = true; Console.WriteLine("Багажник успешно открыт"); }
        else Console.WriteLine("Вы уже открыли багажник");
    }
    /// <summary>
    /// Закрыть багажник
    /// </summary>
    public virtual void CloseTheTrunk()
    {
        if (IsTheTrunkOpen == true) { IsTheTrunkOpen = false; Console.WriteLine("Багажник успешно закрыт"); }
        else Console.WriteLine("Вы уже закрыли багажник");
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Тип резины:{TypeOfRubber}");
        Console.WriteLine($"Класс машины:{Class}");
        Console.WriteLine($"Открыт ли багажник/кузов?:{IsTheTrunkOpen}");
    }
}
public class PassengerCar : Auto
{
    public int NumberOfSeats { get => _numberOfSeats; protected set => _numberOfSeats = value; }
    public int MaxSpeed { get => _maxSpeed; protected set => _maxSpeed = value; }

    protected int _numberOfSeats;
    protected int _maxSpeed;

    public PassengerCar(int numberOfSeats, int maxSpeed, string typeOfRubber, string @class, string manufacturer, double weight, double cost, string name) : base(typeOfRubber, @class, manufacturer, weight, cost, name)
    {
        NumberOfSeats = numberOfSeats;
        MaxSpeed = maxSpeed;
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Число сидений:{NumberOfSeats}");
        Console.WriteLine($"Максимальная скорость:{MaxSpeed}");
    }
}
public class Lorry : Auto
{
    public double Carrying { get => _carrying; set => _carrying = value; }

    protected double _carrying;
    public Lorry(double carrying, string typeOfRubber, string @class, string manufacturer, double weight, double cost, string name) : base(typeOfRubber, @class, manufacturer, weight, cost, name)
    {
        Carrying = carrying;
    }
    /// <summary>
    /// Открыть кузов
    /// </summary>
    public override void OpenTheTrunk()
    {
        if (IsTheTrunkOpen == false) { IsTheTrunkOpen = true; Console.WriteLine("Кузов успешно открыт"); }
        else Console.WriteLine("Вы уже открыли кузов");
    }
    /// <summary>
    /// Закрыть кузов
    /// </summary>
    public override void CloseTheTrunk()
    {
        if (IsTheTrunkOpen == true) { IsTheTrunkOpen = false; Console.WriteLine("Кузов успешно закрыт"); }
        else Console.WriteLine("Вы уже закрыли кузов");
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Грузоподъемность:{Carrying}");
    }
}
public class Train : Transport
{
    public string TypeOfTrain { get => _typeOfTrain; protected set => _typeOfTrain = value; }
    public int WagonsCount { get => _wagonsCount; protected set => _wagonsCount = value; }

    protected string _typeOfTrain;
    protected int _wagonsCount;
    public Train(string typeOfTrain, int wagonsCount, string manufacturer, double weight, double cost, string name) : base(manufacturer, name, weight, cost)
    {
        TypeOfTrain = typeOfTrain;
        WagonsCount = wagonsCount;
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Тип поезда:{TypeOfTrain}");
        Console.WriteLine($"Количество вагонов:{WagonsCount}");
    }
}
public class Plane : Transport
{
    public int MaxHeight { get => _maxHeight; protected set => _maxHeight = value; }
    public int MaxSpeed { get => _maxSpeed; protected set => _maxSpeed = value; }

    protected int _maxHeight;
    protected int _maxSpeed;

    public Plane(int maxHeight, int maxSpeed, string manufacturer, double weight, double cost, string name) : base(manufacturer, name, weight, cost)
    {
        MaxHeight = maxHeight;
        MaxSpeed = maxSpeed;
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Максимальная высота:{MaxHeight}");
        Console.WriteLine($"Максимальная скорость:{MaxSpeed}");
    }
}
public class PassengerPlane : Plane
{
    public int PassengerCount { get => _passengerCount; protected set => _passengerCount = value; }
    public string PlaneClass { get => _planeClass; protected set => _planeClass = value; }

    protected int _passengerCount;
    protected string _planeClass;

    public PassengerPlane(int passengerCount, string planeClass, int maxHeight, int maxSpeed, string manufacturer, double weight, double cost, string name) : base(maxHeight, maxSpeed, manufacturer, weight, cost, name)
    {
        PassengerCount = passengerCount;
        PlaneClass = planeClass;
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Количество пассажиров:{PassengerCount}");
        Console.WriteLine($"Класс самолета:{PlaneClass}");
    }
}
public class CargoPlane : Plane
{
    public double MaxCarrying { get => _maxCarrying; protected set => _maxCarrying = value; }
    public double CurrentCarrying { get => _currentCarrying; protected set => _currentCarrying = Math.Min(value, MaxCarrying); }

    protected double _maxCarrying;
    protected double _currentCarrying;

    public CargoPlane(double maxCarrying, double currentCarrying, int maxHeight, int maxSpeed, string manufacturer, double weight, double cost, string name) : base(maxHeight, maxSpeed, manufacturer, weight, cost, name)
    {
        MaxCarrying = maxCarrying;
        CurrentCarrying = currentCarrying;
    }

    public void ChangeCurrentCarrying(double newCarrying)
    {
        if (MaxCarrying < newCarrying) Console.WriteLine("Превышение допустимой грузоподъемности");
        else if (newCarrying < 0) Console.WriteLine("Груз не может быть меньше 0");
        else { CurrentCarrying = newCarrying; Console.WriteLine("Груз успешно изменен"); }
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Максимальная грузоподъемность:{MaxCarrying}");
        Console.WriteLine($"Текущая загрузка:{CurrentCarrying}");
    }
}


