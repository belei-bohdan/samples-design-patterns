using DesignPatterns.Factory;
ICreditCard creditCard = CreditCardFactory.CreateCreditCard(CreditCardType.Privatbank);

Console.WriteLine("Description: " + creditCard.GetDescription());
Console.WriteLine("Credit Limit: " + creditCard.GetCreditLimit());

Console.ReadKey();