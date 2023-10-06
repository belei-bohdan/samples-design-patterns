namespace DesignPatterns.AbstractFactory
{
    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike() => new RegularBike();
        public ICar CreateCar() => new RegularCar();
    }
}
