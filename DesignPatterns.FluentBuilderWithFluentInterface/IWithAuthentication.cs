namespace DesignPatterns.FluentBuilderWithFluentInterface
{
    public interface IWithAuthentication
    {
        IWithOptionalParams WithCredentials(string user, string password);
        IWithOptionalParams UseIntegratedSecurity();
        IWithOptionalParams UseTrustedConnection();
    }
}