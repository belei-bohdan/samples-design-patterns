namespace DesignPatterns.Factory
{
    internal class Privatbank : ICreditCard
    {
        public string GetDescription()
        {
            return "Privat Bank Universal Card";
        }

        public int GetCreditLimit()
        {
            return 50000;
        }
    }
}
