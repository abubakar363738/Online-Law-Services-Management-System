namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Qualification")]
    public partial class Qualification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Qualification()
        {
            Lawyers = new HashSet<Lawyer>();
        }

        public int QualificationId { get; set; }

        public string DegreeName { get; set; }

        public string University { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CompletionDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lawyer> Lawyers { get; set; }
    }
}
