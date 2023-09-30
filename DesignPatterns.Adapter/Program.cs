using DesignPatterns.Adapter;

var oldCar = new OldCar();
IVehicle oldCarAdapted = new OldCarAdapter(oldCar);

Console.WriteLine(oldCarAdapted.GetSpeed());

Console.ReadKey();