using DesignPatterns.Builder;

var connStr = new ConnectionStringBuilder()
                    .WithDataSource("localhost", 1433)
                    .WithInitialCatalog("BuilderDemo.Db")
                    .UseIntegratedSecurity()
                    .Build();

Console.WriteLine(connStr);

Console.WriteLine(new string('-', 20));

Connect(new ConnectionStringBuilder()
    .WithDataSource("localhost")
    .WithInitialCatalog("BuilderDemo.Db")
    .WithCredentials("user", "very-\"strong\"-pass")
    .WithProvider("System.Data.SqlClient")
    .AsFactory());

static void Connect(Func<string> connStringFactory)
{
    var connStr = connStringFactory();
    Console.WriteLine(connStr);
}

Console.ReadKey();