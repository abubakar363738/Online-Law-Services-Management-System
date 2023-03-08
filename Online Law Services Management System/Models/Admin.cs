namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public int AdminId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int? ClientFid { get; set; }

        public int? LawyerFId { get; set; }

        public int? ReportFid { get; set; }

        public string Status { get; set; }

        public virtual Client Client { get; set; }

        public virtual Lawyer Lawyer { get; set; }

        public virtual Report Report { get; set; }
    }
}
