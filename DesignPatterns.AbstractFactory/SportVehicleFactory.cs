namespace DesignPatterns.AbstractFactory
{
    internal class SportVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike() => new SportBike();
        public ICar CreateCar() => new SportCar();
    }
}
