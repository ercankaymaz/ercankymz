using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLightDistributionData : IPersistEntity, IPersist
{
	IfcPlaneAngleMeasure MainPlaneAngle { get; set; }

	IItemSet<IfcPlaneAngleMeasure> SecondaryPlaneAngle { get; }

	IItemSet<IfcLuminousIntensityDistributionMeasure> LuminousIntensity { get; }
}
