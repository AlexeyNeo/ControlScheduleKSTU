namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class auth_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public auth_user()
        {
            auth_user_groups = new HashSet<auth_user_groups>();
            auth_user_user_permissions = new HashSet<auth_user_user_permissions>();
            django_admin_log = new HashSet<django_admin_log>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string password { get; set; }

        public DateTime? last_login { get; set; }

        public bool is_superuser { get; set; }

        [Required]
        [StringLength(150)]
        public string username { get; set; }

        [Required]
        [StringLength(30)]
        public string first_name { get; set; }

        [Required]
        [StringLength(30)]
        public string last_name { get; set; }

        [Required]
        [StringLength(254)]
        public string email { get; set; }

        public bool is_staff { get; set; }

        public bool is_active { get; set; }

        public DateTime date_joined { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<auth_user_groups> auth_user_groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<auth_user_user_permissions> auth_user_user_permissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<django_admin_log> django_admin_log { get; set; }
    }
}
