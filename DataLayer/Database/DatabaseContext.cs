using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Welcome.Others;

namespace DataLayer.Database;

public class DatabaseContext: DbContext
{
    public DbSet<DatabaseUser> Users { get; set; }
    public DbSet<DatabaseLog> Logs { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string databaseFile = "Welcome.db";
        string databasePath = Path.Combine(solutionFolder, databaseFile);
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<DatabaseLog>().Property(e => e.Id).ValueGeneratedOnAdd();
        
        var user = new DatabaseUser() {Id = 1, Name = "admin", Email = "admin@tu-sofia.bg", Password = "1234", Role = UserRolesEnum.ADMIN, Expires = DateTime.Now.AddYears(10)};
        var userStudent = new DatabaseUser() {Id = 2, Name = "student", Email = "student@tu-sofia.bg", Password = "student", Role = UserRolesEnum.STUDENT, Expires = DateTime.Now.AddYears(1)};
        var userPro = new DatabaseUser() {Id = 3, Name = "prof", Email = "prof@tu-sofia.bg", Password = "prof", Role = UserRolesEnum.PROFESSOR, Expires = DateTime.Now.AddYears(25)};
        var userAnon = new DatabaseUser() {Id = 4, Name = "anonymous", Email = "anonymous@tu-sofia.bg", Password = "anon", Role = UserRolesEnum.ANONYMOUS, Expires = DateTime.Now.AddYears(2)};
        var userInspector = new DatabaseUser() {Id = 5, Name = "inspector", Email = "inspector@tu-sofia.bg", Password = "inspector", Role = UserRolesEnum.INSPECTOR, Expires = DateTime.Now.AddYears(10)};

        modelBuilder.Entity<DatabaseUser>()
            .HasData([user, userStudent, userPro, userAnon, userInspector]);
    }
}