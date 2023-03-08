namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Report()
        {
            Admins = new HashSet<Admin>();
        }

        public int ReportId { get; set; }

        public string Description { get; set; }

        public int? ClientFid { get; set; }

        public int? LawyerFid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin> Admins { get; set; }

        public virtual Client Client { get; set; }

        public virtual Lawyer Lawyer { get; set; }
    }
}
