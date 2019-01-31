namespace TrivialArchitecture.DAL.Entities.Cars.Enums
{
	public enum CarBrand
	{
		// Numbering not from 0 important in the reason of 0 is default value for enum.
		// When numbering starts from other number it prevents issues with forgotten initialization.
		None = 0,
		Lada = 1,
		Maz = 2,
		Volga = 3
	}
}
