namespace DesignPatterns.AbstractFactory
{
    internal class RegularCar : ICar
    {
        public void DisplaySpeed()
        {
            Console.WriteLine("Regular car speed: 220km/h");
        }
    }
}
