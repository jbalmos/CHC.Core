using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
	public class PriceLevelMap : IEntityTypeConfiguration<PriceLevel>
	{
		public void Configure( EntityTypeBuilder<PriceLevel> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "OilDeliveryPriceLevelID" );
			builder.HasMany( obj => obj.Fees );
			builder.HasOne( obj => obj.PricingTier )
				.WithMany()
				.HasForeignKey( f => f.OilDeliveryPricingTierID );

			builder.Property( x => x.PricePerGallon );//.HasPrecision( precision: 18, scale: 3 );
			builder.ToTable( "tblOilDeliveryPriceLevel" );
		}
	}
}
