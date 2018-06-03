namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class django_session
    {
        [Key]
        [StringLength(40)]
        public string session_key { get; set; }

        [Required]
        public string session_data { get; set; }

        public DateTime expire_date { get; set; }
    }
}
