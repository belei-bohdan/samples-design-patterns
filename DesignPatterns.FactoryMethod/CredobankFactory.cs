namespace DesignPatterns.FactoryMethod
{
    internal class CredobankFactory : CreditCardFactory
    {
        protected override ICreditCard Make()
        {
            return new Credobank();
        }
    }
}
