namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int FeedbackId { get; set; }

        [Column("Feedback")]
        public string Feedback1 { get; set; }

        public string Rating { get; set; }

        public int? ClientFid { get; set; }

        public int? LawyerFid { get; set; }

        public virtual Client Client { get; set; }

        public virtual Lawyer Lawyer { get; set; }
    }
}
