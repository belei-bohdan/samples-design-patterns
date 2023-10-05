namespace DesignPatterns.FactoryMethod
{
    internal class Monobank : ICreditCard
    {
        public string GetCardType()
        {
            return "Monobank credit card";
        }

        public int GetCreditLimit()
        {
            return 30000;
        }
    }
}
