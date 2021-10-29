using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<game> game { get; set; }
        public virtual DbSet<game_moves> game_moves { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<game>()
                .HasMany(e => e.game_moves)
                .WithRequired(e => e.game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.game)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.whiteUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.game1)
                .WithRequired(e => e.users1)
                .HasForeignKey(e => e.blackUserId)
                .WillCascadeOnDelete(false);
        }
    }
}
