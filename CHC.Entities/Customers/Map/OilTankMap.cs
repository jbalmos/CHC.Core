using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Customers.Map
{
    public class OilTankMap : IEntityTypeConfiguration<OilTank>
    {
		public void Configure( EntityTypeBuilder<OilTank> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "CustomerOilTankID" );
			builder.Property( obj => obj.AddressID ).HasColumnName( "CustomerAddressID" );
			builder.ToTable( "tblCustomerOilTank" );
		}
	}
}
