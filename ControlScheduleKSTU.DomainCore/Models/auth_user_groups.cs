namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class auth_user_groups
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public int group_id { get; set; }

        public virtual auth_group auth_group { get; set; }

        public virtual auth_user auth_user { get; set; }
    }
}
