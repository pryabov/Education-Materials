namespace TrivialArchitecture.DAL.Base.Enums
{
	internal enum EntityState
	{
		NotSpecified = 0,

		Detached,
		Unchanged,
		Deleted,
		Modified,
		Added
	}
}
