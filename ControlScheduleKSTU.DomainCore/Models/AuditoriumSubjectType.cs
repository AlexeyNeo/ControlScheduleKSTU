namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AuditoriumSubjectType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        public byte AuditoriumTypeId { get; set; }

        public byte SubjectTypeId { get; set; }

        public virtual AuditoriumType AuditoriumType { get; set; }

        public virtual SubjectType SubjectType { get; set; }
    }
}
