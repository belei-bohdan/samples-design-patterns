namespace DesignPatterns.AbstractFactory
{
    internal class SportCar : ICar
    {
        public void DisplaySpeed()
        {
            Console.WriteLine("Sport car speed: 320km/h");
        }
    }
}
