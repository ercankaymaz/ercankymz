using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDimensionalExponents : IPersistEntity, IPersist
{
	long LengthExponent { get; set; }

	long MassExponent { get; set; }

	long TimeExponent { get; set; }

	long ElectricCurrentExponent { get; set; }

	long ThermodynamicTemperatureExponent { get; set; }

	long AmountOfSubstanceExponent { get; set; }

	long LuminousIntensityExponent { get; set; }
}
