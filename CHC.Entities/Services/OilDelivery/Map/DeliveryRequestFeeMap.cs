using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
	public class DeliveryRequestFeeMap : IEntityTypeConfiguration<DeliveryRequestFee>
    {
		public void Configure( EntityTypeBuilder<DeliveryRequestFee> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "OilDeliveryRequestFeeID" );
			builder.Property( obj => obj.DeliveryRequestID ).HasColumnName( "OilDeliveryRequestID" );
			
			builder.ToTable( "tblOilDeliveryRequestFee" );
		}
	}
}
