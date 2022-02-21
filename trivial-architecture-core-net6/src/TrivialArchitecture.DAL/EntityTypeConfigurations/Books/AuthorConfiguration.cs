using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrivialArchitecture.DAL.Entities.Books;

namespace TrivialArchitecture.DAL.EntityTypeConfigurations.Books
{
	public class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.ToTable("Authors");
		}
	}
}
