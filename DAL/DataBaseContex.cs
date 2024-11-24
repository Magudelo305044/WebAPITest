using Microsoft.EntityFrameworkCore;
using WebAPITest.DAL.Entities;

namespace WebAPITest.DAL
{
    public class DataBaseContex :DbContext
    {
        //Así me conecto a la BD por medio de este constructor
        public DataBaseContex(DbContextOptions<DataBaseContex> options) : base(options) 
        {
            
        }

        //Este método que es propio de EF CORE me sirve para configurar unos indices de cada campo deuna tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c=> c.Name).IsUnique();//Aqui creo un indice del campo name para la tabla coutries
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }

        #endregion
    }
}
