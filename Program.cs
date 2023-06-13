Auto testAuto = new("ШиповОчка", "Эконом", "ЛАДА", 400, 5000, "Гроб на колесах");
testAuto.ShowInfo();
Console.WriteLine("-------------------------------------");
PassengerCar testPassengerCar = new(4, 100, "ШиповОчка", "Бюджетный", "Узбек с рынка", 300, 4000, "Вай какая машина");
testPassengerCar.ShowInfo();
Console.WriteLine("-------------------------------------");
Lorry testLorry = new(500, "ШиповОчка", "Не ты боишься аварии а она тебя", "Зуб даю", 3000, 4500, "3 всадник апокалипсиса");
testLorry.ShowInfo();
Console.WriteLine("-------------------------------------");
Train testTrain = new("Пассажирский", 10, "ООО \"Вагонеточка\"", 500, 30000, "Экспресс \"Дорогу покажешь - доедем\"");
testTrain.ShowInfo();
Console.WriteLine("-------------------------------------");
Plane testPlane = new(3000, 300, "Взлетело? - Уже неплохо.", 500, 10000, "\"Билет в один конец\"");
testPlane.ShowInfo();
Console.WriteLine("-------------------------------------");
PassengerPlane testPassengerPlane = new(50, "Эконом", 5000, 200, "BOYing", 1000, 50000, "Get your рейс back here");
testPassengerPlane.ShowInfo();
Console.WriteLine("-------------------------------------");
CargoPlane testCargoPlane = new(500, 250, 3000, 500, "\"Доставка бомб до вашего дома\"", 1000, 100000, "Еb@n3t? - Не должно");
testCargoPlane.ShowInfo();




