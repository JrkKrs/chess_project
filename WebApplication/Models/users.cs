using System.Web.UI.WebControls;

namespace WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            game = new HashSet<game>();
            game1 = new HashSet<game>();
        }

        public int id { get; set; }

        [StringLength(20)]
        [DisplayName("User name")]
        [Index(IsUnique = true)]
        [Required(ErrorMessage = "This field is required.")]
        public string username { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        [DisplayName("Display Name")]
        public string displayName { get; set; }

        [StringLength(128)]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string passwd { get; set; }

        [NotMapped]
        [DisplayName("Repeat Password ")]
        [DataType(DataType.Password)]
        public string passwdRepeat { get; set; }

        [StringLength(128)]
        [Index(IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Column(TypeName = "datetime2")] public DateTime registerDate { get; set; }

        [Column(TypeName = "datetime2")] public DateTime lastLogin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<game> game { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<game> game1 { get; set; }

        public string LoginMsgError { get; set; }

        [NotMapped] 
        public string registerMsg { get; set; }

        [StringLength(110)] 
        public string userApiToken { get; set; }

        [Column(TypeName = "datetime2")] 
        public DateTime lastActive { get; set; }


        public bool inGame { get; set; }
    }
}