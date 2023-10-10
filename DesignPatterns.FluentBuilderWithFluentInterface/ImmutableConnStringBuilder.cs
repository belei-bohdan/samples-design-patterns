namespace DesignPatterns.FluentBuilderWithFluentInterface
{
    internal class ConnectionStringBuilder :
        IWithInitialCatalog, IWithAuthentication, IWithOptionalParams
    {
        private string? DataSource { get; }
        private string? InitialCatalog { get; }
        private string? Security { get; }
        private string? ConnectTimeoutSegment { get; }
        private string? ProviderSegment { get; }

        private ConnectionStringBuilder(
            string? dataSource, string? initialCatalog, string? security,
            string? connectionTimeoutSegment, string? providerSegment)
        {
            DataSource = dataSource;
            InitialCatalog = initialCatalog;
            Security = security;
            ConnectTimeoutSegment = connectionTimeoutSegment;
            ProviderSegment = providerSegment;
        }

        public static IWithInitialCatalog WithDataSource(string dataSource) =>
            new ConnectionStringBuilder(ValidDataSource(dataSource),
                                        null, null, string.Empty, null);

        public static IWithInitialCatalog WithDataSource(string dataSource, int port) =>
            new ConnectionStringBuilder($"{ValidDataSource(dataSource)},{port}",
                                        null, null, string.Empty, null);

        private static string ValidDataSource(string dataSource) =>
            !string.IsNullOrWhiteSpace(dataSource) ? dataSource
            : throw new ArgumentException(null, nameof(dataSource));

        public IWithAuthentication WithInitialCatalog(string initialCatalog) =>
            new ConnectionStringBuilder(
                DataSource, ValidInitialCatalog(initialCatalog),
                Security, ConnectTimeoutSegment, ProviderSegment);

        private static string ValidInitialCatalog(string initialCatalog) =>
            !string.IsNullOrWhiteSpace(initialCatalog) ? initialCatalog
            : throw new ArgumentException(null, nameof(initialCatalog));

        public IWithOptionalParams WithCredentials(string userId, string password) =>
            new ConnectionStringBuilder(
                DataSource, InitialCatalog, Credentials(userId, password),
                ConnectTimeoutSegment, ProviderSegment);

        private static string Credentials(string user, string password) =>
            !string.IsNullOrWhiteSpace(user) && password is not null
                ? $"User Id={Escape(user)};Password={Escape(password)}"
                : throw new ArgumentException("User and Password can not be null.");

        public IWithOptionalParams UseIntegratedSecurity() =>
            new ConnectionStringBuilder(
                DataSource, InitialCatalog, "Integrated Security=true",
                ConnectTimeoutSegment, ProviderSegment);

        public IWithOptionalParams UseTrustedConnection() =>
            new ConnectionStringBuilder(
                DataSource, InitialCatalog, "Trusted_Connection=yes",
                ConnectTimeoutSegment, ProviderSegment);

        public IWithOptionalParams WithConnectionTimeout(int seconds) =>
            new ConnectionStringBuilder(
                DataSource, InitialCatalog, Security,
                $";Connect Timeout={seconds}", ProviderSegment);

        public IWithOptionalParams WithProvider(string name) =>
            new ConnectionStringBuilder(
                DataSource, InitialCatalog, Security, ConnectTimeoutSegment,
                ProviderSegment ?? $"Provider={Escape(ValidProvider(name))};");

        private static string ValidProvider(string name) =>
            !string.IsNullOrEmpty(name) ? name
            : throw new ArgumentException(null, nameof(name));

        public string Build() =>
            $"{ProviderSegment}Data Source={Escape(DataSource!)};" +
            $"Initial Catalog={Escape(InitialCatalog!)};" +
            $"{Security}{ConnectTimeoutSegment}";

        private static string? Escape(string? value) =>
            ";' \t".ToCharArray().Any(ch => value?.Contains(ch) ?? false) ? $"\"{value?.Replace("\"", "\"\"")}\""
            : value?.Contains('"') ?? false ? $"'{value}'"
            : value;
    }
}
