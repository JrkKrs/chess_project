namespace WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("game")]
    public partial class game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public game()
        {
            game_moves = new HashSet<game_moves>();
        }

        public int id { get; set; }

        public int whiteUserId { get; set; }

        public int blackUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime startDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? endDate { get; set; }

        public short? winner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<game_moves> game_moves { get; set; }

        public virtual users users { get; set; }

        public virtual users users1 { get; set; }
    }
}
