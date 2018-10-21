using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
    public class ServiceAreaMap : IEntityTypeConfiguration<ServiceArea>
    {
		public void Configure( EntityTypeBuilder<ServiceArea> builder )
		{
			builder.HasKey( obj => new { obj.OilDeliveryPricingTierID, obj.Zip } );
			//builder.HasRequired(l => l.PricingTier).WithMany(p => p.ServiceAreas).HasForeignKey(a => a.OilDeliveryPricingTierID);

			builder.HasOne( obj => obj.Town )
				.WithMany()
				.HasForeignKey( f => f.Zip );// TODO May need IsRequired here
			builder.ToTable( "tblOilDeliveryServiceArea" );
		}
	}
}
