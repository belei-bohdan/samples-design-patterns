namespace DesignPatterns.FactoryMethod
{
    internal class Privatbank : ICreditCard
    {
        public string GetCardType()
        {
            return "Privat Bank Universal Card";
        }

        public int GetCreditLimit()
        {
            return 50000;
        }
    }
}
