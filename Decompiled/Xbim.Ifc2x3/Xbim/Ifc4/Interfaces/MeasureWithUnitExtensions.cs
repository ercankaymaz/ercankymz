using Xbim.Ifc2x3.Interfaces.Conversions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

internal static class MeasureWithUnitExtensions
{
	public static IIfcPhysicalSimpleQuantity ToPhysicalSimpleQuantity(this IfcMeasureWithUnit measure)
	{
		IfcValue valueComponent = measure.ValueComponent;
		if (valueComponent is IfcAreaMeasure)
		{
			return new IfcQuantityAreaTransient(measure);
		}
		if (valueComponent is IfcCountMeasure)
		{
			return new IfcQuantityCountTransient(measure);
		}
		if (valueComponent is IfcLengthMeasure)
		{
			return new IfcQuantityLengthTransient(measure);
		}
		if (valueComponent is IfcTimeMeasure)
		{
			return new IfcQuantityTimeTransient(measure);
		}
		if (valueComponent is IfcVolumeMeasure)
		{
			return new IfcQuantityVolumeTransient(measure);
		}
		if (valueComponent is IfcMassMeasure)
		{
			return new IfcQuantityWeightTransient(measure);
		}
		return null;
	}
}
