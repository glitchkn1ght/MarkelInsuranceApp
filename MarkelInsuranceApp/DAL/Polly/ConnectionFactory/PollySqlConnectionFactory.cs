using MarkelInsuranceApp.Models.Configuration;
using Microsoft.Extensions.Options;
using MarkelInsuranceApp.DAL.Polly;
using MarkelInsuranceApp.DAL.Polly.Policies;
using System;
using System.Data;

namespace MarkelInsuranceApp.DAL.Polly.ConnectionFactory
{
    public interface IPollyConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }
    
    public class PollySqlConnectionFactory : IPollyConnectionFactory
    {
        private SqlConnectionSettings ConnectionSettings { get; set; }
        private IPollyRetryPolicy RetryPolicy { get; set; }

        public PollySqlConnectionFactory(IOptions<SqlConnectionSettings> connectionSettings, IPollyRetryPolicy retryPolicy)
        {
            this.RetryPolicy = retryPolicy ?? throw new ArgumentNullException(nameof(retryPolicy));

            this.ConnectionSettings = connectionSettings.Value ?? throw new ArgumentNullException(nameof(connectionSettings));

            if (string.IsNullOrWhiteSpace(this.ConnectionSettings.ConnectionString))
            {
                throw new ArgumentException("SqlConnectionString is null or whitespace");
            }
        }

        public IDbConnection CreateOpenConnection()
        {
            var conn = new PollySqlDbConnection(this.ConnectionSettings.ConnectionString, this.RetryPolicy);
            conn.Open();

            return conn;
        }
    }
}
