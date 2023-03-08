namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment()
        {
            Consultations = new HashSet<Consultation>();
        }

        [Key]
        public int AppointmentFormId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DesiredDate { get; set; }

        public string CaseDescription { get; set; }

        public byte[] Document { get; set; }

        public int? ClientFid { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}
