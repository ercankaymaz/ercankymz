namespace Xbim.Common.Geometry;

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
}
