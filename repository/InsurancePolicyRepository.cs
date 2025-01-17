using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class InsurancePolicyRepository : IInsurancePolicyRepository
{
    private readonly ApplicationDbContext _context;

    public InsurancePolicyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<InsurancePolicyEntity>> GetAllAsync()
    {
        return await _context.InsurancePolicies.ToListAsync();
    }

    public async Task<InsurancePolicyEntity> GetByIdAsync(long id)
    {
        return await _context.InsurancePolicies.FindAsync(id);
    }

    public async Task AddAsync(InsurancePolicyEntity policy)
    {
        await _context.InsurancePolicies.AddAsync(policy);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(InsurancePolicyEntity policy)
    {
        var existingPolicy = await _context.InsurancePolicies.FindAsync(policy.PolicyId);
        if (existingPolicy == null)
        {
            throw new KeyNotFoundException("Insurance Policy not found.");
        }

        _context.InsurancePolicies.Update(policy);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var policy = await _context.InsurancePolicies.FindAsync(id);
        if (policy == null)
        {
            throw new KeyNotFoundException("Insurance Policy not found.");
        }

        _context.InsurancePolicies.Remove(policy);
        await _context.SaveChangesAsync();
    }
}
