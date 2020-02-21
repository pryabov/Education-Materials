namespace TrivialArchitecture.DAL.Entities.Books
{
	public class Author : IBaseEntity<long>
	{
		public long Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
