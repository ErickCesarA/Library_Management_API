namespace Library_ManagementAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\ERICKCESAR;Database=LibManagementdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<BooksModels> BooksPropety { get; set; }
        public DbSet<GenresModels> GenresPropety { get; set; }
    }
}
