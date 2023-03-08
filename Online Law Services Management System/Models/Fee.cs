namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fee()
        {
            Consultations = new HashSet<Consultation>();
        }

        [Key]
        public int FeesId { get; set; }

        public string Profit { get; set; }

        public string FeesStatus { get; set; }

        public int? ClientFid { get; set; }

        public int? LawyerFid { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consultation> Consultations { get; set; }

        public virtual Lawyer Lawyer { get; set; }
    }
}
