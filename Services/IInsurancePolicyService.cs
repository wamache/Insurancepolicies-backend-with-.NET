using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInsurancePolicyService
{
    Task<InsurancePolicyDTO> CreatePolicyAsync(InsurancePolicyDTO policy);
    Task<InsurancePolicyDTO> GetPolicyByIdAsync(long policyId);
    Task<List<InsurancePolicyDTO>> GetAllPoliciesAsync();
    Task<InsurancePolicyDTO> UpdatePolicyAsync(long policyId, InsurancePolicyDTO policy);
    Task<bool> DeletePolicyAsync(long policyId);
}
