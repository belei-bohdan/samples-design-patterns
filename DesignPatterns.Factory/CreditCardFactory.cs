namespace DesignPatterns.Factory
{
    internal abstract class CreditCardFactory
    {
        public static ICreditCard CreateCreditCard(CreditCardType type) => type switch
        {
            CreditCardType.Monobank => new Monobank(),
            CreditCardType.Privatbank => new Privatbank(),
            CreditCardType.Credobank => new Credobank(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Invalid Card Type: {type}"),
        };
    }
}
