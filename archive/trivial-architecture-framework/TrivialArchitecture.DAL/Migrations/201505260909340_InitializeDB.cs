using System.Data.Entity.Migrations;

namespace TrivialArchitecture.DAL.Migrations
{
	public partial class InitializeDB : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.CarDrivers",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						FirstName = c.String(maxLength: 255),
						LastName = c.String(maxLength: 255),
						Age = c.Int(nullable: false),
						CarId = c.Long(),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Cars", t => t.CarId)
				.Index(t => t.CarId);

			CreateTable(
				"dbo.Cars",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						Brand = c.Int(nullable: false),
						Color = c.Int(nullable: false),
						Number = c.String(),
						Odometer = c.Double(nullable: false),
						NumberOfSeats = c.Int(),
						Discriminator = c.String(maxLength: 128),
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.Tags",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						Name = c.String(),
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.Books",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						Name = c.String(),
						Language = c.Int(nullable: false),
						PublisherId = c.Long(),
						AuthorId = c.Long(nullable: false),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
				.ForeignKey("dbo.Publishers", t => t.PublisherId)
				.Index(t => t.PublisherId)
				.Index(t => t.AuthorId);

			CreateTable(
				"dbo.Authors",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						FirstName = c.String(),
						LastName = c.String(),
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.Publishers",
				c => new
					{
						Id = c.Long(nullable: false, identity: true),
						Name = c.String(),
						Address = c.String(nullable: false),
						Test = c.String(),
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.BookTags",
				c => new
					{
						Book_Id = c.Long(nullable: false),
						Tag_Id = c.Long(nullable: false),
					})
				.PrimaryKey(t => new { t.Book_Id, t.Tag_Id })
				.ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
				.ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
				.Index(t => t.Book_Id)
				.Index(t => t.Tag_Id);

			CreateTable(
				"dbo.Trucks",
				c => new
					{
						Id = c.Long(nullable: false),
						Name = c.String(),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Cars", t => t.Id)
				.Index(t => t.Id);

		}

		public override void Down()
		{
			DropForeignKey("dbo.Trucks", "Id", "dbo.Cars");
			DropForeignKey("dbo.BookTags", "Tag_Id", "dbo.Tags");
			DropForeignKey("dbo.BookTags", "Book_Id", "dbo.Books");
			DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
			DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
			DropForeignKey("dbo.CarDrivers", "CarId", "dbo.Cars");
			DropIndex("dbo.Trucks", new[] { "Id" });
			DropIndex("dbo.BookTags", new[] { "Tag_Id" });
			DropIndex("dbo.BookTags", new[] { "Book_Id" });
			DropIndex("dbo.Books", new[] { "AuthorId" });
			DropIndex("dbo.Books", new[] { "PublisherId" });
			DropIndex("dbo.CarDrivers", new[] { "CarId" });
			DropTable("dbo.Trucks");
			DropTable("dbo.BookTags");
			DropTable("dbo.Publishers");
			DropTable("dbo.Authors");
			DropTable("dbo.Books");
			DropTable("dbo.Tags");
			DropTable("dbo.Cars");
			DropTable("dbo.CarDrivers");
		}
	}
}
