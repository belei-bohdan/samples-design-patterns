namespace DesignPatterns.AbstractFactory
{
    internal class SportBike : IBike
    {
        public void DisplaySpeed()
        {
            Console.WriteLine("Sport bike speed: 45km/h");
        }
    }
}
