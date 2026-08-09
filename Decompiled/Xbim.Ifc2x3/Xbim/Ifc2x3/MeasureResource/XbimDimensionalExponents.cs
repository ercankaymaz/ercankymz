using System;
using System.Collections.Generic;
using System.Linq;

namespace Xbim.Ifc2x3.MeasureResource;

public class XbimDimensionalExponents
{
	private readonly long[] _exponents;

	public long LengthExponent { get; set; }

	public long MassExponent { get; set; }

	public long TimeExponent { get; set; }

	public long ElectricCurrentExponent { get; set; }

	public long ThermodynamicTemperatureExponent { get; set; }

	public long AmountOfSubstanceExponent { get; set; }

	public long LuminousIntensityExponent { get; set; }

	public long this[int index]
	{
		get
		{
			if (_exponents != null)
			{
				return _exponents[index];
			}
			return 0L;
		}
	}

	public XbimDimensionalExponents()
		: this(0, 0, 0, 0, 0, 0, 0)
	{
	}

	public XbimDimensionalExponents(int length, int mass, int time, int elec, int temp, int substs, int lumin)
	{
		_exponents = new long[7];
		_exponents[0] = length;
		_exponents[1] = mass;
		_exponents[2] = time;
		_exponents[3] = elec;
		_exponents[4] = temp;
		_exponents[5] = substs;
		_exponents[6] = lumin;
	}

	public static XbimDimensionalExponents DimensionsForSiUnit(IfcSIUnitName? siUnit)
	{
		if (!siUnit.HasValue)
		{
			return null;
		}
		return siUnit switch
		{
			IfcSIUnitName.METRE => new XbimDimensionalExponents(1, 0, 0, 0, 0, 0, 0), 
			IfcSIUnitName.SQUARE_METRE => new XbimDimensionalExponents(2, 0, 0, 0, 0, 0, 0), 
			IfcSIUnitName.CUBIC_METRE => new XbimDimensionalExponents(3, 0, 0, 0, 0, 0, 0), 
			IfcSIUnitName.GRAM => new XbimDimensionalExponents(0, 1, 0, 0, 0, 0, 0), 
			IfcSIUnitName.SECOND => new XbimDimensionalExponents(0, 0, 1, 0, 0, 0, 0), 
			IfcSIUnitName.AMPERE => new XbimDimensionalExponents(0, 0, 0, 1, 0, 0, 0), 
			IfcSIUnitName.KELVIN => new XbimDimensionalExponents(0, 0, 0, 0, 1, 0, 0), 
			IfcSIUnitName.MOLE => new XbimDimensionalExponents(0, 0, 0, 0, 0, 1, 0), 
			IfcSIUnitName.CANDELA => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 1), 
			IfcSIUnitName.RADIAN => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0), 
			IfcSIUnitName.STERADIAN => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0), 
			IfcSIUnitName.HERTZ => new XbimDimensionalExponents(0, 0, -1, 0, 0, 0, 0), 
			IfcSIUnitName.NEWTON => new XbimDimensionalExponents(1, 1, -2, 0, 0, 0, 0), 
			IfcSIUnitName.PASCAL => new XbimDimensionalExponents(-1, 1, -2, 0, 0, 0, 0), 
			IfcSIUnitName.JOULE => new XbimDimensionalExponents(2, 1, -2, 0, 0, 0, 0), 
			IfcSIUnitName.WATT => new XbimDimensionalExponents(2, 1, -3, 0, 0, 0, 0), 
			IfcSIUnitName.COULOMB => new XbimDimensionalExponents(0, 0, 1, 1, 0, 0, 0), 
			IfcSIUnitName.VOLT => new XbimDimensionalExponents(2, 1, -3, -1, 0, 0, 0), 
			IfcSIUnitName.FARAD => new XbimDimensionalExponents(-2, -1, 4, 1, 0, 0, 0), 
			IfcSIUnitName.OHM => new XbimDimensionalExponents(2, 1, -3, -2, 0, 0, 0), 
			IfcSIUnitName.SIEMENS => new XbimDimensionalExponents(-2, -1, 3, 2, 0, 0, 0), 
			IfcSIUnitName.WEBER => new XbimDimensionalExponents(2, 1, -2, -1, 0, 0, 0), 
			IfcSIUnitName.TESLA => new XbimDimensionalExponents(0, 1, -2, -1, 0, 0, 0), 
			IfcSIUnitName.HENRY => new XbimDimensionalExponents(2, 1, -2, -2, 0, 0, 0), 
			IfcSIUnitName.DEGREE_CELSIUS => new XbimDimensionalExponents(0, 0, 0, 0, 1, 0, 0), 
			IfcSIUnitName.LUMEN => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 1), 
			IfcSIUnitName.LUX => new XbimDimensionalExponents(-2, 0, 0, 0, 0, 0, 1), 
			IfcSIUnitName.BECQUEREL => new XbimDimensionalExponents(0, 0, -1, 0, 0, 0, 0), 
			IfcSIUnitName.GRAY => new XbimDimensionalExponents(2, 0, -2, 0, 0, 0, 0), 
			IfcSIUnitName.SIEVERT => new XbimDimensionalExponents(2, 0, -2, 0, 0, 0, 0), 
			_ => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0), 
		};
	}

	public static bool CorrectDimensions(IfcUnitEnum unit, XbimDimensionalExponents dim)
	{
		return unit switch
		{
			IfcUnitEnum.LENGTHUNIT => dim == new XbimDimensionalExponents(1, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.MASSUNIT => dim == new XbimDimensionalExponents(0, 1, 0, 0, 0, 0, 0), 
			IfcUnitEnum.TIMEUNIT => dim == new XbimDimensionalExponents(0, 0, 1, 0, 0, 0, 0), 
			IfcUnitEnum.ELECTRICCURRENTUNIT => dim == new XbimDimensionalExponents(0, 0, 0, 1, 0, 0, 0), 
			IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT => dim == new XbimDimensionalExponents(0, 0, 0, 0, 1, 0, 0), 
			IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT => dim == new XbimDimensionalExponents(0, 0, 0, 0, 0, 1, 0), 
			IfcUnitEnum.LUMINOUSINTENSITYUNIT => dim == new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 1), 
			IfcUnitEnum.PLANEANGLEUNIT => dim == new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.SOLIDANGLEUNIT => dim == new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.AREAUNIT => dim == new XbimDimensionalExponents(2, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.VOLUMEUNIT => dim == new XbimDimensionalExponents(3, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.ABSORBEDDOSEUNIT => dim == new XbimDimensionalExponents(2, 0, -2, 0, 0, 0, 0), 
			IfcUnitEnum.RADIOACTIVITYUNIT => dim == new XbimDimensionalExponents(0, 0, -1, 0, 0, 0, 0), 
			IfcUnitEnum.ELECTRICCAPACITANCEUNIT => dim == new XbimDimensionalExponents(-2, 1, 4, 1, 0, 0, 0), 
			IfcUnitEnum.DOSEEQUIVALENTUNIT => dim == new XbimDimensionalExponents(2, 0, -2, 0, 0, 0, 0), 
			IfcUnitEnum.ELECTRICCHARGEUNIT => dim == new XbimDimensionalExponents(0, 0, 1, 1, 0, 0, 0), 
			IfcUnitEnum.ELECTRICCONDUCTANCEUNIT => dim == new XbimDimensionalExponents(-2, -1, 3, 2, 0, 0, 0), 
			IfcUnitEnum.ELECTRICVOLTAGEUNIT => dim == new XbimDimensionalExponents(2, 1, -3, -1, 0, 0, 0), 
			IfcUnitEnum.ELECTRICRESISTANCEUNIT => dim == new XbimDimensionalExponents(2, 1, -3, -2, 0, 0, 0), 
			IfcUnitEnum.ENERGYUNIT => dim == new XbimDimensionalExponents(2, 1, -2, 0, 0, 0, 0), 
			IfcUnitEnum.FORCEUNIT => dim == new XbimDimensionalExponents(1, 1, -2, 0, 0, 0, 0), 
			IfcUnitEnum.FREQUENCYUNIT => dim == new XbimDimensionalExponents(0, 0, -1, 0, 0, 0, 0), 
			IfcUnitEnum.INDUCTANCEUNIT => dim == new XbimDimensionalExponents(2, 1, -2, -2, 0, 0, 0), 
			IfcUnitEnum.ILLUMINANCEUNIT => dim == new XbimDimensionalExponents(-2, 0, 0, 0, 0, 0, 1), 
			IfcUnitEnum.LUMINOUSFLUXUNIT => dim == new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 1), 
			IfcUnitEnum.MAGNETICFLUXUNIT => dim == new XbimDimensionalExponents(2, 1, -2, -1, 0, 0, 0), 
			IfcUnitEnum.MAGNETICFLUXDENSITYUNIT => dim == new XbimDimensionalExponents(0, 1, -2, -1, 0, 0, 0), 
			IfcUnitEnum.POWERUNIT => dim == new XbimDimensionalExponents(2, 1, -3, 0, 0, 0, 0), 
			IfcUnitEnum.PRESSUREUNIT => dim == new XbimDimensionalExponents(-1, 1, -2, 0, 0, 0, 0), 
			_ => false, 
		};
	}

	public static XbimDimensionalExponents DimensionsForUnit(IfcUnitEnum unit)
	{
		return unit switch
		{
			IfcUnitEnum.LENGTHUNIT => new XbimDimensionalExponents(1, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.MASSUNIT => new XbimDimensionalExponents(0, 1, 0, 0, 0, 0, 0), 
			IfcUnitEnum.TIMEUNIT => new XbimDimensionalExponents(0, 0, 1, 0, 0, 0, 0), 
			IfcUnitEnum.ELECTRICCURRENTUNIT => new XbimDimensionalExponents(0, 0, 0, 1, 0, 0, 0), 
			IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT => new XbimDimensionalExponents(0, 0, 0, 0, 1, 0, 0), 
			IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT => new XbimDimensionalExponents(0, 0, 0, 0, 0, 1, 0), 
			IfcUnitEnum.LUMINOUSINTENSITYUNIT => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 1), 
			IfcUnitEnum.PLANEANGLEUNIT => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.SOLIDANGLEUNIT => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.AREAUNIT => new XbimDimensionalExponents(2, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.VOLUMEUNIT => new XbimDimensionalExponents(3, 0, 0, 0, 0, 0, 0), 
			IfcUnitEnum.ABSORBEDDOSEUNIT => new XbimDimensionalExponents(2, 0, -2, 0, 0, 0, 0), 
			IfcUnitEnum.RADIOACTIVITYUNIT => new XbimDimensionalExponents(0, 0, -1, 0, 0, 0, 0), 
			IfcUnitEnum.ELECTRICCAPACITANCEUNIT => new XbimDimensionalExponents(-2, 1, 4, 1, 0, 0, 0), 
			IfcUnitEnum.DOSEEQUIVALENTUNIT => new XbimDimensionalExponents(2, 0, -2, 0, 0, 0, 0), 
			IfcUnitEnum.ELECTRICCHARGEUNIT => new XbimDimensionalExponents(0, 0, 1, 1, 0, 0, 0), 
			IfcUnitEnum.ELECTRICCONDUCTANCEUNIT => new XbimDimensionalExponents(-2, -1, 3, 2, 0, 0, 0), 
			IfcUnitEnum.ELECTRICVOLTAGEUNIT => new XbimDimensionalExponents(2, 1, -3, -1, 0, 0, 0), 
			IfcUnitEnum.ELECTRICRESISTANCEUNIT => new XbimDimensionalExponents(2, 1, -3, -2, 0, 0, 0), 
			IfcUnitEnum.ENERGYUNIT => new XbimDimensionalExponents(2, 1, -2, 0, 0, 0, 0), 
			IfcUnitEnum.FORCEUNIT => new XbimDimensionalExponents(1, 1, -2, 0, 0, 0, 0), 
			IfcUnitEnum.FREQUENCYUNIT => new XbimDimensionalExponents(0, 0, -1, 0, 0, 0, 0), 
			IfcUnitEnum.INDUCTANCEUNIT => new XbimDimensionalExponents(2, 1, -2, -2, 0, 0, 0), 
			IfcUnitEnum.ILLUMINANCEUNIT => new XbimDimensionalExponents(-2, 0, 0, 0, 0, 0, 1), 
			IfcUnitEnum.LUMINOUSFLUXUNIT => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 1), 
			IfcUnitEnum.MAGNETICFLUXUNIT => new XbimDimensionalExponents(2, 1, -2, -1, 0, 0, 0), 
			IfcUnitEnum.MAGNETICFLUXDENSITYUNIT => new XbimDimensionalExponents(0, 1, -2, -1, 0, 0, 0), 
			IfcUnitEnum.POWERUNIT => new XbimDimensionalExponents(2, 1, -3, 0, 0, 0, 0), 
			IfcUnitEnum.PRESSUREUNIT => new XbimDimensionalExponents(-1, 1, -2, 0, 0, 0, 0), 
			_ => new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0), 
		};
	}

	public static XbimDimensionalExponents DeriveDimensionalExponents(IEnumerable<IfcDerivedUnitElement> unitElements)
	{
		IList<IfcDerivedUnitElement> obj = (unitElements as IList<IfcDerivedUnitElement>) ?? unitElements.ToList();
		if (!obj.Any())
		{
			throw new ArgumentNullException();
		}
		XbimDimensionalExponents xbimDimensionalExponents = new XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0);
		foreach (IfcDerivedUnitElement item in obj)
		{
			xbimDimensionalExponents.LengthExponent += item.Exponent * item.Unit.Dimensions.LengthExponent;
			xbimDimensionalExponents.MassExponent += item.Exponent * item.Unit.Dimensions.MassExponent;
			xbimDimensionalExponents.TimeExponent += item.Exponent * item.Unit.Dimensions.TimeExponent;
			xbimDimensionalExponents.ElectricCurrentExponent += item.Exponent * item.Unit.Dimensions.ElectricCurrentExponent;
			xbimDimensionalExponents.ThermodynamicTemperatureExponent += item.Exponent * item.Unit.Dimensions.ThermodynamicTemperatureExponent;
			xbimDimensionalExponents.AmountOfSubstanceExponent += item.Exponent * item.Unit.Dimensions.AmountOfSubstanceExponent;
			xbimDimensionalExponents.LuminousIntensityExponent += item.Exponent * item.Unit.Dimensions.LuminousIntensityExponent;
		}
		return xbimDimensionalExponents;
	}

	public static XbimDimensionalExponents DeriveDimensionalExponents(IfcUnit unit)
	{
		IfcDerivedUnit ifcDerivedUnit = unit as IfcDerivedUnit;
		if (ifcDerivedUnit != null)
		{
			return DeriveDimensionalExponents(ifcDerivedUnit.Elements);
		}
		throw new NotImplementedException();
	}

	public static XbimDimensionalExponents CorrectUnitAssignment(List<IfcUnit> units)
	{
		throw new NotImplementedException();
	}
}
