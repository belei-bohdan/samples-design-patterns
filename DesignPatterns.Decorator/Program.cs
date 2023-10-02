using DesignPatterns.Decorator;

ICoffee espresso = new Espresso("Espresso", 2);
espresso.DisplayReceipt();

ICoffee milkEspresso = new MilkCoffee(espresso);
milkEspresso.DisplayReceipt();

Console.ReadKey();
