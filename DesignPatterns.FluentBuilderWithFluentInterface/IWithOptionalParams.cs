namespace DesignPatterns.FluentBuilderWithFluentInterface
{
    public interface IWithOptionalParams
    {
        IWithOptionalParams WithConnectionTimeout(int seconds);
        IWithOptionalParams WithProvider(string provider);
        string Build();
    }
}