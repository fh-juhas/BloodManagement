using BloodManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloodManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) 
        { 
        }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Donor -> BloodGroup relationship
            modelBuilder.Entity<Donor>()
                .HasOne(d => d.BloodGroup)  // Navigation property in Donor
                .WithMany(bg => bg.Donors)  // Navigation property in BloodGroup
                .HasForeignKey(d => d.BloodGroupId)  // Foreign key in Donor
                .OnDelete(DeleteBehavior.Restrict);  // Configure delete behavior

            // Configure Donor -> District relationship
            modelBuilder.Entity<Donor>()
                .HasOne(d => d.District)  // Navigation property in Donor
                .WithMany(d => d.Donors)  // Navigation property in District
                .HasForeignKey(d => d.DistrictId)  // Foreign key in Donor
                .OnDelete(DeleteBehavior.Restrict);  // Configure delete behavior

            // Configure Donation -> Donor relationship
            modelBuilder.Entity<Donation>()
                .HasOne(d => d.Donor)  // Navigation property in Donation
                .WithMany(d => d.Donations)  // Navigation property in Donor
                .HasForeignKey(d => d.DonorId)  // Foreign key in Donation
                .OnDelete(DeleteBehavior.Restrict);  // Configure delete behavior

            // Configure Donation -> BloodGroup relationship
            modelBuilder.Entity<Donation>()
                .HasOne(d => d.BloodGroup)  // Navigation property in Donation
                .WithMany(bg => bg.Donations)  // Navigation property in BloodGroup
                .HasForeignKey(d => d.BloodGroupId)  // Foreign key in Donation
                .OnDelete(DeleteBehavior.Restrict);  // Configure delete behavior

            // Configure District -> Donor relationship (if needed)
            modelBuilder.Entity<District>()
                .HasMany(d => d.Donors)  // Navigation property in District
                .WithOne(d => d.District)  // Navigation property in Donor
                .HasForeignKey(d => d.DistrictId)  // Foreign key in Donor
                .OnDelete(DeleteBehavior.Restrict);  // Configure delete behavior

            // Configure BloodGroup -> Donor relationship (if needed)
            modelBuilder.Entity<BloodGroup>()
                .HasMany(bg => bg.Donors)  // Navigation property in BloodGroup
                .WithOne(d => d.BloodGroup)  // Navigation property in Donor
                .HasForeignKey(d => d.BloodGroupId)  // Foreign key in Donor
                .OnDelete(DeleteBehavior.Restrict);  // Configure delete behavior

            // Configure BloodGroup -> Donation relationship (if needed)
            modelBuilder.Entity<BloodGroup>()
                .HasMany(bg => bg.Donations)  // Navigation property in BloodGroup
                .WithOne(d => d.BloodGroup)  // Navigation property in Donation
                .HasForeignKey(d => d.BloodGroupId)  // Foreign key in Donation
                .OnDelete(DeleteBehavior.Restrict);  // Configure delete behavior
        }



    }
}
