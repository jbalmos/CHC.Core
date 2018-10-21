
using Microsoft.EntityFrameworkCore;

namespace CHC.Common
{
    public class DefaultDbContextFactory : IDbContextFactory
    {
        public string chcDbConnectionString;

        public DefaultDbContextFactory(
            string chcDbConnectionString)

        {
            this.chcDbConnectionString = chcDbConnectionString;
        }


        public ChcDbContext CreateChcDbContext()
        {
			//var dbContextOptions = new DbContextOptions<ChcDbContext>();
			//dbContextOptions.UseMySQL( Configuration.GetConnectionString( "DefaultConnection" ) ))

			//return new ChcDbContext(this.chcDbConnectionString);
			return null;
		}

    }
}
