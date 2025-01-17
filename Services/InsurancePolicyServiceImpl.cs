using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class InsurancePolicyServiceImpl : IInsurancePolicyService
{
    private readonly IInsurancePolicyRepository _repository;

    public InsurancePolicyServiceImpl(IInsurancePolicyRepository repository)
    {
        _repository = repository;
    }

    public async Task<InsurancePolicyDTO> CreatePolicyAsync(InsurancePolicyDTO policy)
    {
        var entity = new InsurancePolicyEntity
        {
            PolicyNumber = policy.PolicyNumber,
            PolicyType = policy.PolicyType,
            PremiumAmount = policy.PremiumAmount,
            StartDate = policy.StartDate,
            EndDate = policy.EndDate,
            IsActive = policy.IsActive,
            CustomerId = policy.CustomerId
        };

        await _repository.AddAsync(entity);

        return new InsurancePolicyDTO
        {
            PolicyId = entity.PolicyId,
            PolicyNumber = entity.PolicyNumber,
            PolicyType = entity.PolicyType,
            PremiumAmount = entity.PremiumAmount,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            IsActive = entity.IsActive,
            CustomerId = entity.CustomerId
        };
    }

    public async Task<InsurancePolicyDTO> GetPolicyByIdAsync(long policyId)
    {
        var policy = await _repository.GetByIdAsync(policyId);
        if (policy == null)
        {
            throw new KeyNotFoundException("Insurance Policy not found.");
        }

        return new InsurancePolicyDTO
        {
            PolicyId = policy.PolicyId,
            PolicyNumber = policy.PolicyNumber,
            PolicyType = policy.PolicyType,
            PremiumAmount = policy.PremiumAmount,
            StartDate = policy.StartDate,
            EndDate = policy.EndDate,
            IsActive = policy.IsActive,
            CustomerId = policy.CustomerId
        };
    }

    public async Task<List<InsurancePolicyDTO>> GetAllPoliciesAsync()
    {
        var policies = await _repository.GetAllAsync();
        return policies.Select(policy => new InsurancePolicyDTO
        {
            PolicyId = policy.PolicyId,
            PolicyNumber = policy.PolicyNumber,
            PolicyType = policy.PolicyType,
            PremiumAmount = policy.PremiumAmount,
            StartDate = policy.StartDate,
            EndDate = policy.EndDate,
            IsActive = policy.IsActive,
            CustomerId = policy.CustomerId
        }).ToList();
    }

    public async Task<InsurancePolicyDTO> UpdatePolicyAsync(long policyId, InsurancePolicyDTO policy)
    {
        var entity = new InsurancePolicyEntity
        {
            PolicyId = policyId,
            PolicyNumber = policy.PolicyNumber,
            PolicyType = policy.PolicyType,
            PremiumAmount = policy.PremiumAmount,
            StartDate = policy.StartDate,
            EndDate = policy.EndDate,
            IsActive = policy.IsActive,
            CustomerId = policy.CustomerId
        };

        await _repository.UpdateAsync(entity);

        return new InsurancePolicyDTO
        {
            PolicyId = entity.PolicyId,
            PolicyNumber = entity.PolicyNumber,
            PolicyType = entity.PolicyType,
            PremiumAmount = entity.PremiumAmount,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            IsActive = entity.IsActive,
            CustomerId = entity.CustomerId
        };
    }

    public async Task<bool> DeletePolicyAsync(long policyId)
    {
        await _repository.DeleteAsync(policyId);
        return true;
    }
}
