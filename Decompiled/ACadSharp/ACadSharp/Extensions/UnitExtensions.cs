using ACadSharp.Objects;
using ACadSharp.Types.Units;

namespace ACadSharp.Extensions;

public static class UnitExtensions
{
	public static UnitsType ToUnits(this PlotPaperUnits units)
	{
		return units switch
		{
			PlotPaperUnits.Inches => UnitsType.Inches, 
			PlotPaperUnits.Millimeters => UnitsType.Millimeters, 
			_ => UnitsType.Unitless, 
		};
	}
}
