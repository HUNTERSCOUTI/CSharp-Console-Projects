using Microsoft.EntityFrameworkCore;

namespace SchoolTaskSQLite;

public class StudentDbContext : DbContext
{
	// The following configures EF to create a Sqlite database file in the
	// special "local" folder for your platform.
	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source=students.db");

	public DbSet<Student> Students { get; set; }
	public DbSet<Subject> Subjects { get; set; }
}