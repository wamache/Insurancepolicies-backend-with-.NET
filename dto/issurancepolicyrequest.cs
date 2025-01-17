using System;
using System.ComponentModel.DataAnnotations;

public class InsurancePolicyDTO
{
    public long? PolicyId { get; set; }

    [Required(ErrorMessage = "Policy number is required")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Policy number must be between 3 and 10 characters")]
    public string PolicyNumber { get; set; }

    [Required(ErrorMessage = "Policy type is required")]
    [StringLength(30, ErrorMessage = "Policy type cannot exceed 30 characters")]
    public string PolicyType { get; set; }

    [Required(ErrorMessage = "Premium amount is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Premium amount must be greater than or equal to 0")]
    public decimal PremiumAmount { get; set; }

    [Required(ErrorMessage = "Start date is required")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required")]
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; } = true; // Defaulting to true (active)

    [Required(ErrorMessage = "Customer ID is required")]
    public int CustomerId { get; set; }

    public InsurancePolicyDTO() { }

    public InsurancePolicyDTO(long? policyId, string policyNumber, string policyType, 
                              decimal premiumAmount, DateTime startDate, DateTime endDate, 
                              int customerId, bool isActive = true)
    {
        PolicyId = policyId;
        PolicyNumber = policyNumber;
        PolicyType = policyType;
        PremiumAmount = premiumAmount;
        StartDate = startDate;
        EndDate = endDate;
        CustomerId = customerId;
        IsActive = isActive;
    }

    public override string ToString()
    {
        return $"InsurancePolicyDTO [PolicyId={PolicyId}, PolicyNumber={PolicyNumber}, PolicyType={PolicyType}, " +
               $"PremiumAmount={PremiumAmount}, StartDate={StartDate}, EndDate={EndDate}, IsActive={IsActive}, " +
               $"CustomerId={CustomerId}]";
    }
}
