using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
//\using InsurancePolicy.Services;


// namespace InsurancePolicy.Entity // Corrected namespace
// {
    [Table("insurance_policies")]
    public class InsurancePolicyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PolicyId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Policy number cannot exceed 50 characters.")]
        public string PolicyNumber { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Policy type cannot exceed 30 characters.")]
        public string PolicyType { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Premium amount must be greater than or equal to 0.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PremiumAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public InsurancePolicyEntity() { }

        public InsurancePolicyEntity(long policyId, string policyNumber, string policyType, decimal premiumAmount,
                                DateTime startDate, DateTime endDate, bool isActive, int customerId)
        {
            PolicyId = policyId;
            PolicyNumber = policyNumber;
            PolicyType = policyType;
            PremiumAmount = premiumAmount;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            CustomerId = customerId;
        }

        public override string ToString()
        {
            return $"InsurancePolicy [PolicyId={PolicyId}, PolicyNumber={PolicyNumber}, PolicyType={PolicyType}, " +
                   $"PremiumAmount={PremiumAmount}, StartDate={StartDate}, EndDate={EndDate}, IsActive={IsActive}, " +
                   $"CustomerId={CustomerId}]";
        }
    }
//}