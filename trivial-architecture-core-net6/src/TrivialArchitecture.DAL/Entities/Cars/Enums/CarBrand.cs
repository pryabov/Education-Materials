namespace TrivialArchitecture.DAL.Entities.Cars.Enums
{
	public enum CarBrand
	{
		// Starting numbers not from 0 important due the reason that 0 is the default value for enum.
		// When numbering starts from other number it prevents issues with forgotten initialization.
		NotSpecified = 0,

		Lada = 1,
		Maz = 2,
		Volga = 3
	}
}
