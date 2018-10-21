using CHC.Entities.Customers.Map;
using CHC.Entities.Services.OilDelivery.Map;
using Microsoft.EntityFrameworkCore;

namespace CHC.Common
{
	public class ChcDbContext : DbContext
	{
		static ChcDbContext()
		{
			// This tells EF that we are working with a pre-existing database and are not using the migrations 
			// feature.
			//Database.SetInitializer<ChcDbContext>(null);
		}

		public ChcDbContext( DbContextOptions<ChcDbContext> options )
		 : base( options )
		{ }

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			/* Customer models */
			modelBuilder.ApplyConfiguration( new CustomerMap());
			modelBuilder.ApplyConfiguration( new AccountMap());
			modelBuilder.ApplyConfiguration( new AddressMap());
			modelBuilder.ApplyConfiguration( new OilTankMap());
			modelBuilder.ApplyConfiguration( new FillPipeLocationMap());

			/* Oil Delivery Service Models*/
			modelBuilder.ApplyConfiguration( new ServiceAreaMap());
			modelBuilder.ApplyConfiguration( new ServiceAreaTownMap());
			modelBuilder.ApplyConfiguration( new PricingTierMap());
			modelBuilder.ApplyConfiguration( new PriceLevelMap());
			modelBuilder.ApplyConfiguration( new PriceLevelFeeMap());
			modelBuilder.ApplyConfiguration( new DeliveryRequestMap());
			modelBuilder.ApplyConfiguration( new DeliveryRequestFeeMap());

			modelBuilder.ApplyConfiguration( new ContactRequestMap());
		}
	}
}
