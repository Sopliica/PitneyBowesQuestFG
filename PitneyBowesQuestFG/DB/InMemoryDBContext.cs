using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PitneyBowesQuestFG.Models;

namespace PitneyBowesQuestFG.DB;

public class InMemoryDBContext : DbContext
{
	public DbSet<Address> Addresses { get; set; }
	public InMemoryDBContext(DbContextOptions<InMemoryDBContext> options) : base(options)
	{

	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Address>().HasKey(x => x.Id);
	}
	
}
