using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Online_Law_Services_Management_System.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<Expertise> Expertises { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Lawyer> Lawyers { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Consultations)
                .WithOptional(e => e.Appointment)
                .HasForeignKey(e => e.AppointmentFormFid);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.ClientFid);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Appointments)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.ClientFid);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Consultations)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.ClientFid);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Feedbacks)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.ClientFid);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Fees)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.ClientFid);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Reports)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.ClientFid);

            modelBuilder.Entity<Expertise>()
                .HasMany(e => e.Lawyers)
                .WithOptional(e => e.Expertise)
                .HasForeignKey(e => e.ExpertiseFid);

            modelBuilder.Entity<Fee>()
                .HasMany(e => e.Consultations)
                .WithOptional(e => e.Fee)
                .HasForeignKey(e => e.FeesFid);

            modelBuilder.Entity<Lawyer>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Lawyer)
                .HasForeignKey(e => e.LawyerFId);

            modelBuilder.Entity<Lawyer>()
                .HasMany(e => e.Consultations)
                .WithOptional(e => e.Lawyer)
                .HasForeignKey(e => e.LawyerFid);

            modelBuilder.Entity<Lawyer>()
                .HasMany(e => e.Feedbacks)
                .WithOptional(e => e.Lawyer)
                .HasForeignKey(e => e.LawyerFid);

            modelBuilder.Entity<Lawyer>()
                .HasMany(e => e.Fees)
                .WithOptional(e => e.Lawyer)
                .HasForeignKey(e => e.LawyerFid);

            modelBuilder.Entity<Lawyer>()
                .HasMany(e => e.Reports)
                .WithOptional(e => e.Lawyer)
                .HasForeignKey(e => e.LawyerFid);

            modelBuilder.Entity<Qualification>()
                .HasMany(e => e.Lawyers)
                .WithOptional(e => e.Qualification)
                .HasForeignKey(e => e.QualificationFid);

            modelBuilder.Entity<Report>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Report)
                .HasForeignKey(e => e.ReportFid);
        }
    }
}
