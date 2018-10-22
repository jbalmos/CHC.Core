using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
    public class PricingTierMap : IEntityTypeConfiguration<PricingTier>
    {
		public void Configure( EntityTypeBuilder<PricingTier> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "OilDeliveryPricingTierID" );
			builder.HasMany( obj => obj.ServiceAreas )
				.WithOne( obj => obj.PricingTier )
				.HasForeignKey( obj => obj.OilDeliveryPricingTierID );
			builder.HasMany( obj => obj.PriceLevels )
				.WithOne( obj => obj.PricingTier )
				.HasForeignKey( obj => obj.OilDeliveryPricingTierID );
			builder.ToTable( "tblOilDeliveryPricingTier" );
		}
	}
}
