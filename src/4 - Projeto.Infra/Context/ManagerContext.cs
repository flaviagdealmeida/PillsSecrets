using Microsoft.EntityFrameworkCore;

namespace Projeto.Infra.Context{
    public class ManagerContext : DBContext{

        public ManagerContext(){}

        public ManagerContext(DbContextOptions <ManagerContext> options) : base(options) { }

        public override void OnConfiguring(DbContextOptionsBuilder optionsbuilder){
           optionsbuilder.UseSqlServer(@"Data Source=SQL5018.site4now.net;Initial Catalog=DB_A49C81_Banco;User Id=DB_A49C81_Banco_admin;Password=FGA12345678;");
        }
        public virtual DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new UserMap());
        }

    }
}