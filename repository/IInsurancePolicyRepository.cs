using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInsurancePolicyRepository
{
    Task<List<InsurancePolicyEntity>> GetAllAsync();
    Task<InsurancePolicyEntity> GetByIdAsync(long id);
    Task AddAsync(InsurancePolicyEntity policy);
    Task UpdateAsync(InsurancePolicyEntity policy);
    Task DeleteAsync(long id);
}
