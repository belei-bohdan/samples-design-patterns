namespace DesignPatterns.Adapter
{
    internal class OldCarAdapter : IVehicle
    {
        private readonly OldCar _oldCar;

        public OldCarAdapter(OldCar oldCar)
        {
            _oldCar = oldCar;
        }

        public int GetSpeed()
        {
            _ = int.TryParse(new string(_oldCar.GetSpeedAsString()
                .Where(c => char.IsDigit(c)).ToArray()), out int speed);

            return speed;
        }
    }
}
