using DesignPatterns.FactoryMethod;

ICreditCard creditCard = new MonobankFactory().Create();

Console.WriteLine("Card Type: " + creditCard.GetCardType());
Console.WriteLine("Credit Limit: " + creditCard.GetCreditLimit());
Console.WriteLine("--------------");

creditCard = new CredobankFactory().Create();
Console.WriteLine("Card Type: " + creditCard.GetCardType());
Console.WriteLine("Credit Limit: " + creditCard.GetCreditLimit());

Console.ReadKey();