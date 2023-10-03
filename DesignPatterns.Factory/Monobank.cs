namespace DesignPatterns.Factory
{
    internal class Monobank : ICreditCard
    {
        public string GetDescription()
        {
            return "Monobank credit card";
        }

        public int GetCreditLimit()
        {
            return 30000;
        }
    }
}
