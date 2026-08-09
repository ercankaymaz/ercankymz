using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc;

public static class IIfcUnitExtensions
{
	public static string AsString(this IIfcMeasureWithUnit obj)
	{
		string text = $"{obj.ValueComponent.Value:N2}";
		string text2 = obj.UnitComponent.Symbol();
		if (!string.IsNullOrEmpty(text2))
		{
			text += text2;
		}
		return text;
	}

	public static string Name(this IIfcUnit ifcUnit)
	{
		return UnitExtensions.Name(ifcUnit);
	}

	public static string Symbol(this IIfcUnit ifcUnit)
	{
		return UnitExtensions.Symbol(ifcUnit);
	}

	public static string Symbol(this IIfcMonetaryUnit obj)
	{
		return UnitExtensions.Symbol(obj);
	}

	public static string FullEnglishName(this IIfcMonetaryUnit obj)
	{
		return UnitExtensions.FullEnglishName(obj);
	}

	public static string FullNativeName(this IIfcMonetaryUnit obj)
	{
		return UnitExtensions.FullNativeName(obj);
	}
}
