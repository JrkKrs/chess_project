using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace
{
    public partial class ChessSQL : DbContext
    {
        public ChessSQL()
            : base("name=ChessSQL")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
