namespace DesignPatterns.AbstractFactory
{
    internal class RegularBike : IBike
    {
        public void DisplaySpeed()
        {
            Console.WriteLine("Regular bike speed: 20km/h");
        }
    }
}
