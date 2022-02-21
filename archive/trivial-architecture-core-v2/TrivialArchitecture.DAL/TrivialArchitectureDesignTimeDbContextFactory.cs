using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TrivialArchitecture.DAL
{
	// https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation?ranMID=24542&ranEAID=je6NUbpObpQ&ranSiteID=je6NUbpObpQ-9LpFRnRU0hqsW_Ld.gQkQA&epi=je6NUbpObpQ-9LpFRnRU0hqsW_Ld.gQkQA&irgwc=1&OCID=AID2000142_aff_7593_1243925&tduid=(ir__kzfkvneosskft0ohkk0sohz3x22xltlxbdhlz9n200)(7593)(1243925)(je6NUbpObpQ-9LpFRnRU0hqsW_Ld.gQkQA)()&irclickid=_kzfkvneosskft0ohkk0sohz3x22xltlxbdhlz9n200
	public class TrivialArchitectureDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TrivialArchitectureDbContext>
	{
		public TrivialArchitectureDbContext CreateDbContext(string[] args)
		{
			DbContextOptionsBuilder<TrivialArchitectureDbContext> builder = new DbContextOptionsBuilder<TrivialArchitectureDbContext>();
			builder.UseSqlServer("Data Source =.\\; Initial Catalog = TrivialArchitecture; Integrated Security = true");
			return new TrivialArchitectureDbContext(builder.Options);
		}
	}
}
