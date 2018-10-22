using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
    public class ServiceAreaMap : IEntityTypeConfiguration<ServiceArea>
    {
		public void Configure( EntityTypeBuilder<ServiceArea> builder )
		{
			builder.HasKey( obj => new { obj.OilDeliveryPricingTierID, obj.Zip } );
			builder.HasOne( obj => obj.PricingTier )
				.WithMany()
				.HasForeignKey( obj => obj.OilDeliveryPricingTierID );
			builder.ToTable( "tblOilDeliveryServiceArea" );
		}
	}
}
