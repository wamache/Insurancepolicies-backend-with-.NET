using Microsoft.EntityFrameworkCore;  // For DbContext and DbSet

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
	public DbSet<InsurancePolicyEntity> InsurancePolicies { get; set; }
}

// // public class InsurancePolicyContext : DbContext
// // {
// //     public InsurancePolicyContext(DbContextOptions<InsurancePolicyContext> options)
// //         : base(options)
// //     {
// //     }

// //     public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
// // }

//  using Microsoft.EntityFrameworkCore; // For DbContext and DbSet

// public class ApplicationDbContext : DbContext
// {
//     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

//     public DbSet<User> Users { get; set; }
// }

// public class InsurancePolicyContext : DbContext
// {
//     public InsurancePolicyContext(DbContextOptions<InsurancePolicyContext> options)
//         : base(options)
//     {
//     }

//     public DbSet<InsurancePolicyEntity> InsurancePolicies { get; set; } // Renamed class to avoid conflict
// }

