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
			builder.HasOne( obj => obj.DeliveryRequest )
				.WithMany()
				.HasForeignKey( f => f.DeliveryRequestID );// TODO May need IsRequired here
			builder.ToTable( "tblOilDeliveryRequestFee" );
		}
	}
}
