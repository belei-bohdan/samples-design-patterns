namespace DesignPatterns.Factory
{
    internal class Credobank : ICreditCard
    {
        public string GetDescription()
        {
            return "Credit Bank card";
        }

        public int GetCreditLimit()
        {
            return 100000;
        }
    }
}
