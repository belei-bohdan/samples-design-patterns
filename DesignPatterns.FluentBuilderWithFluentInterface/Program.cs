using DesignPatterns.FluentBuilderWithFluentInterface;

var connStr1 = MutableConnStringBuilder
    .WithDataSource("localhost")
    .WithInitialCatalog("FirstDb")
    .UseIntegratedSecurity()
    .WithConnectionTimeout(100)
    .Build();

var connStr2 = MutableConnStringBuilder
    .WithDataSource("localhost")
    .WithInitialCatalog("SecondDb")
    .WithCredentials("user", "very-\"strong\"-password")
    .Build();

Console.WriteLine($"ConnStr1 build by mutable builder: {connStr1}");
Console.WriteLine($"ConnStr2 build by immutable builder: {connStr2}");

Console.ReadKey();