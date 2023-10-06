using DesignPatterns.AbstractFactory;

IVehicleFactory regularVehicleFactory = new RegularVehicleFactory();

IBike regularBike = regularVehicleFactory.CreateBike();
regularBike.DisplaySpeed();

ICar regularCar = regularVehicleFactory.CreateCar();
regularCar.DisplaySpeed();

IVehicleFactory sportVehicleFactory = new SportVehicleFactory();

IBike sportBike = sportVehicleFactory.CreateBike();
sportBike.DisplaySpeed();

ICar sportCar = sportVehicleFactory.CreateCar();
sportCar.DisplaySpeed();

Console.ReadKey();
