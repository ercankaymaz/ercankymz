using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLightIntensityDistribution : IPersistEntity, IPersist, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType
{
	IfcLightDistributionCurveEnum LightDistributionCurve { get; set; }

	IItemSet<IIfcLightDistributionData> DistributionData { get; }
}
