using CHC.Entites.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Customers.Map
{
    public class ContactRequestMap : IEntityTypeConfiguration<ContactRequest>
    {
		public void Configure( EntityTypeBuilder<ContactRequest> builder )
		{
			builder.HasKey( obj => obj.ContactRequestID );
			builder.ToTable( "tblContactRequest" );
		}
	}
}
