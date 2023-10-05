namespace DesignPatterns.FactoryMethod
{
    internal class Credobank : ICreditCard
    {
        public string GetCardType()
        {
            return "Credit Bank card";
        }

        public int GetCreditLimit()
        {
            return 100000;
        }
    }
}
