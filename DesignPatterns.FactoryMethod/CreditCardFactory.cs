namespace DesignPatterns.FactoryMethod
{
    internal abstract class CreditCardFactory
    {
        protected abstract ICreditCard Make();

        public ICreditCard Create()
        {
            return this.Make();
        }
    }
}
