namespace DesignPatterns.FluentBuilderWithFluentInterface
{
    internal class MutableConnStringBuilder :
        IWithInitialCatalog, IWithAuthentication, IWithOptionalParams
    {
        private string? DataSource { get; set; }
        private string? InitialCatalog { get; set; }
        private string? Security { get; set; }
        private string ConnectTimeoutSegment { get; set; } = string.Empty;
        private string? ProviderSegment { get; set; }

        private MutableConnStringBuilder() { }

        public static IWithInitialCatalog WithDataSource(string dataSource) =>
            new MutableConnStringBuilder() { DataSource = ValidDataSource(dataSource) };

        public static IWithInitialCatalog WithDataSource(string dataSource, int port) =>
            new MutableConnStringBuilder()
            {
                DataSource = $"{ValidDataSource(dataSource)},{port}"
            };

        private static string ValidDataSource(string dataSource) =>
            !string.IsNullOrWhiteSpace(dataSource) ? dataSource
            : throw new ArgumentException(null, nameof(dataSource));

        public IWithAuthentication WithInitialCatalog(string initialCatalog)
        {
            InitialCatalog = ValidInitialCatalog(initialCatalog);
            return this;
        }

        private static string ValidInitialCatalog(string initialCatalog) =>
            !string.IsNullOrWhiteSpace(initialCatalog) ? initialCatalog
            : throw new ArgumentException(null, nameof(initialCatalog));

        public IWithOptionalParams WithCredentials(string userId, string password)
        {
            Security = Credentials(userId, password);
            return this;
        }

        private static string Credentials(string user, string password) =>
            !string.IsNullOrWhiteSpace(user) && password is not null
                ? $"User Id={Escape(user)};Password={Escape(password)}"
                : throw new ArgumentException("User and Password can not be null.");

        public IWithOptionalParams UseIntegratedSecurity()
        {
            Security = "Integrated Security=true";
            return this;
        }

        public IWithOptionalParams UseTrustedConnection()
        {
            Security = "Trusted_Connection=yes";
            return this;
        }

        public IWithOptionalParams WithConnectionTimeout(int seconds)
        {
            ConnectTimeoutSegment = $";Connect Timeout={seconds}";
            return this;
        }

        public IWithOptionalParams WithProvider(string name)
        {
            ProviderSegment ??= $"Provider={Escape(name)};";
            return this;
        }

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
