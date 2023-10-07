namespace DesignPatterns.Builder
{
    internal class ConnectionStringBuilder
    {
        private string? DataSource { get; set; }
        private string? InitialCatalog { get; set; }
        private string? Security { get; set; }
        private bool IsValidSecurity { get; set; }
        private string ConnectTimeoutSegment { get; set; } = string.Empty;
        private string? ProviderSegment { get; set; }

        public ConnectionStringBuilder WithDataSource(string address)
        {
            this.DataSource = address;
            return this;
        }

        public ConnectionStringBuilder WithDataSource(string address, int portNumber)
        {
            this.DataSource = $"{address},{portNumber}";
            return this;
        }

        public ConnectionStringBuilder WithInitialCatalog(string initialCatalog)
        {
            this.InitialCatalog = initialCatalog;
            return this;
        }

        public ConnectionStringBuilder WithCredentials(string userId, string password)
        {
            this.IsValidSecurity = !string.IsNullOrWhiteSpace(userId) && password is not null;
            this.Security = $"User Id={Escape(userId)};Password={Escape(password)}";
            return this;
        }

        public ConnectionStringBuilder UseIntegratedSecurity()
        {
            this.IsValidSecurity = true;
            this.Security = "Integrated Security=true";
            return this;
        }

        public ConnectionStringBuilder UseTrustedConnection()
        {
            this.IsValidSecurity = true;
            this.Security = "Trusted_Connection=yes";
            return this;
        }

        public ConnectionStringBuilder WithConnectTimeout(int seconds)
        {
            this.ConnectTimeoutSegment = $";Connect Timeout={seconds}";
            return this;
        }

        public ConnectionStringBuilder WithDefaultConnectTimeout()
        {
            this.ConnectTimeoutSegment = string.Empty;
            return this;
        }

        public ConnectionStringBuilder WithProvider(string name)
        {
            this.ProviderSegment ??= $"Provider={Escape(name)};";
            return this;
        }

        public ConnectionStringBuilder WithDefaultProvider()
        {
            this.ProviderSegment = null;
            return this;
        }

        public bool CanBuild() =>
            !string.IsNullOrWhiteSpace(this.DataSource) &&
            !string.IsNullOrWhiteSpace(this.InitialCatalog) &&
            this.IsValidSecurity;

        public string Build() =>
            this.CanBuild() ? this.SafeBuild()
            : throw new InvalidOperationException("Cannot build a valid connection string.");

        public Func<string> AsFactory() =>
            this.CanBuild() ? (Func<string>)this.SafeBuild
            : throw new InvalidOperationException("Cannot construct a factory.");

        private string SafeBuild() =>
            $"{this.ProviderSegment}Data Source={Escape(this.DataSource)};" +
            $"Initial Catalog={Escape(this.InitialCatalog)};" +
            $"{this.Security}{this.ConnectTimeoutSegment}";

        private static string? Escape(string? value) =>
            ";' \t".Any(ch => value?.Contains(ch) ?? false) ? $"\"{value?.Replace("\"", "\"\"")}\""
            : value?.Contains('"') ?? false ? $"'{value}'"
            : value;
    }
}
