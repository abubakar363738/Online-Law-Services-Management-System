namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expertise")]
    public partial class Expertise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expertise()
        {
            Lawyers = new HashSet<Lawyer>();
        }

        public int ExpertiseId { get; set; }

        [Column("Expertise")]
        public string Expertise1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lawyer> Lawyers { get; set; }
    }
}
