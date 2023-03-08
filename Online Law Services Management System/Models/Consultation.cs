namespace Online_Law_Services_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Consultation")]
    public partial class Consultation
    {
        public int ConsultationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ConsultationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DesiredDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AssignedDate { get; set; }

        public int? AppointmentFormFid { get; set; }

        public int? ClientFid { get; set; }

        public int? LawyerFid { get; set; }

        public int? CurrentNoOfCasses { get; set; }

        public int? FeesFid { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual Client Client { get; set; }

        public virtual Fee Fee { get; set; }

        public virtual Lawyer Lawyer { get; set; }
    }
}
