using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Customers.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
  		public void Configure( EntityTypeBuilder<Customer> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "CustomerID" );
			builder.HasMany( obj => obj.Addresses );
			builder.HasOne( obj => obj.Account )
				.WithOne()
				.HasForeignKey<Customer>( c => c.ID );

			builder.ToTable( "tblCustomer" );
		}
	}
}
