namespace DesignPatterns.FluentBuilderWithFluentInterface
{
    public interface IWithInitialCatalog
    {
        IWithAuthentication WithInitialCatalog(string initialCatalog);
    }
}