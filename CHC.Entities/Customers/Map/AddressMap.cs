using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Customers.Map
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
		public void Configure( EntityTypeBuilder<Address> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "CustomerAddressID" );
			builder.HasMany( obj => obj.OilTanks )
				.WithOne( obj => obj.Address )
				.HasForeignKey( obj => obj.AddressID );
			builder.HasMany( obj => obj.DeliveryRequests )
				.WithOne( obj => obj.CustomerAddress )
				.HasForeignKey( obj => obj.CustomerAddressID );
			builder.ToTable( "tblCustomerAddress" );
		}
	}
}
