using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrivialArchitecture.DAL.Entities.Books;

namespace TrivialArchitecture.DAL.EntityTypeConfigurations.Books
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Books");

			builder.HasMany(item => item.Tags);
		}
	}
}
