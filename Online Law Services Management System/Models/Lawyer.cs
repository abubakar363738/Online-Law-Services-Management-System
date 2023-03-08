namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lawyer")]
    public partial class Lawyer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lawyer()
        {
            Admins = new HashSet<Admin>();
            Consultations = new HashSet<Consultation>();
            Feedbacks = new HashSet<Feedback>();
            Fees = new HashSet<Fee>();
            Reports = new HashSet<Report>();
        }

        public int LawyerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string UserName { get; set; }

        public string LawyerEmail { get; set; }

        [Required]
        public string Password { get; set; }

        public byte[] Picture { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public int CNIC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        public string MartialStatus { get; set; }

        public string Gender { get; set; }

        public string MobileNumber { get; set; }

        public string WhatsappNumber { get; set; }

        [StringLength(250)]
        public string Language { get; set; }

        public string PracticeCity { get; set; }

        public string BarCouncil { get; set; }

        public string EnrollmentYear { get; set; }

        public string BarLicenseNumber { get; set; }

        public string LawFirm { get; set; }

        public string FirmAddress { get; set; }

        public string Contribution { get; set; }

        public string Facebook { get; set; }

        public string LinkedIn { get; set; }

        public string Status { get; set; }

        public string HandledCases { get; set; }

        public int? QualificationFid { get; set; }

        public int? ExpertiseFid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin> Admins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consultation> Consultations { get; set; }

        public virtual Expertise Expertise { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fee> Fees { get; set; }

        public virtual Qualification Qualification { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
    }
}
