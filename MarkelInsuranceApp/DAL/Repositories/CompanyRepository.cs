namespace MarkelInsuranceApp.Repositories
{
    using Dapper;
    using MarkelInsuranceApp.DAL.Polly.ConnectionFactory;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Models.Company;
    using MarkelInsuranceApp.Models.Configuration;
    using Microsoft.Extensions.Options;
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class CompanyRepository : ICompanyRepository
    {
        private readonly IPollyConnectionFactory ConnectionFactory;
        private readonly CompanyRepositorySettings CompanyRepositorySettings;

        public CompanyRepository(IPollyConnectionFactory connectionFactory, IOptions<CompanyRepositorySettings> companyRepositorySettings)
        {
            this.ConnectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            this.CompanyRepositorySettings = companyRepositorySettings.Value;
        }

        public async Task<Company> Get(int companyId)
        {
            using (IDbConnection connection = this.ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);

                var result = await connection.QueryAsync<Company>(this.CompanyRepositorySettings.GetCompanyProc, parameters, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }
    }
}
