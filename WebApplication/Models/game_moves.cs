namespace WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class game_moves
    {
        public int id { get; set; }

        public int gameId { get; set; }

        [Required]
        [StringLength(10)]
        public string whiteMove { get; set; }

        [StringLength(10)]
        public string blackMove { get; set; }

        public int moveOrder { get; set; }

        [StringLength(5)]
        public string annotation { get; set; }

        public virtual game game { get; set; }
    }
}
