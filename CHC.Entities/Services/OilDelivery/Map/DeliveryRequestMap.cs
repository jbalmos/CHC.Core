using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
    public class DeliveryRequestMap : IEntityTypeConfiguration<DeliveryRequest>
    {
		public void Configure( EntityTypeBuilder<DeliveryRequest> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "OilDeliveryRequestID" );
			builder.HasMany( obj => obj.DeliveryRequestFees )
				.WithOne( obj => obj.DeliveryRequest )
				.HasForeignKey( f => f.DeliveryRequestID );// TODO May need IsRequired here
			builder.ToTable( "tblOilDeliveryRequest" );
		}
	}
}
