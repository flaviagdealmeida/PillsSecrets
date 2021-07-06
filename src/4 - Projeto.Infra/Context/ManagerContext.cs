using Microsoft.EntityFrameworkCore;

namespace Projeto.Infra.Context{
    public class ManagerContext : DBContext{

        public ManagerContext(){}

        public ManagerContext(DbContextOptions <ManagerContext> options) : base(options) { }

        public override void OnConfiguring(DbContextOptionsBuilder optionsbuilder){
           
        }
        public virtual DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new UserMap());
        }

    }
}