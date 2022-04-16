using Microsoft.Extensions.DependencyInjection;

namespace SchoolTaskSQLite;

public class Program
{
	public static void Main()
	{
		var services = new ServiceCollection();
		services.AddDbContext<StudentDbContext>();
		services.AddTransient<Application>();
		var provider = services.BuildServiceProvider();
		var mainProgram = provider.GetRequiredService<Application>();

		mainProgram.Main();
	}
}
