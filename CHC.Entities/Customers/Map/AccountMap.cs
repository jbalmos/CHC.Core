using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Customers.Map
{
	public class AccountMap : IEntityTypeConfiguration<Account>
	{
		public void Configure( EntityTypeBuilder<Account> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "AccountID" );

			builder.ToTable( "tblAccount" );
		}
	}
}
