using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.MeasureResource;

public static class UnitExtensions
{
	public static string Name(this IfcUnit ifcUnit)
	{
		return Xbim.Ifc4.MeasureResource.UnitExtensions.Name(ifcUnit);
	}

	public static string Symbol(this IfcUnit ifcUnit)
	{
		return Xbim.Ifc4.MeasureResource.UnitExtensions.Symbol(ifcUnit);
	}
}
