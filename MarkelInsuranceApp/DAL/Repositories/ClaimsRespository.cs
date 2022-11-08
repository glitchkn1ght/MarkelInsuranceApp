namespace MarkelInsuranceApp.Repositories
{
    using Dapper;
    using MarkelInsuranceApp.DAL.Polly.ConnectionFactory;
    using MarkelInsuranceApp.Interfaces.Repositories;
    using MarkelInsuranceApp.Models.Claim;
    using MarkelInsuranceApp.Models.Configuration;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class ClaimsRespository : IClaimsRepository
    {
        private readonly IPollyConnectionFactory ConnectionFactory;
        private readonly ClaimsRepositorySettings ClaimsRepositorySettings;
            
        public ClaimsRespository(IPollyConnectionFactory connectionFactory, IOptions<ClaimsRepositorySettings> claimsRepositorySettings)
        {
            this.ConnectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            this.ClaimsRepositorySettings = claimsRepositorySettings.Value;
        }

        public async Task<InsuranceClaim> Get(string universalClaimsReference)
        {
            using (IDbConnection connection = this.ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@UCR", universalClaimsReference);

                var result = await connection.QueryAsync<InsuranceClaim>(this.ClaimsRepositorySettings.GetSingleClaimProc, parameters, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<InsuranceClaim>> GetAllByCompany(int companyId)
        {
            using (IDbConnection connection = this.ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@CompanyId", companyId);

                var result = await connection.QueryAsync<InsuranceClaim>(this.ClaimsRepositorySettings.GetAllClaimsForCompanyProc, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<int> Update(InsuranceClaim claimToUpdate)
        {
            using (IDbConnection connection = this.ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@UCR", claimToUpdate.UCR);
                parameters.Add("@Closed", claimToUpdate.Closed);
                parameters.Add("@retVal", dbType: DbType.Int32 , direction: ParameterDirection.ReturnValue);

               await connection.ExecuteAsync(this.ClaimsRepositorySettings.UpdateSingleClaimProc, parameters, commandType: CommandType.StoredProcedure);

                var result = parameters.Get<int>("@retVal");

                return result;
            }
        }
    }
}
