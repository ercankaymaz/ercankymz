using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLightSource : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcLabel? Name { get; set; }

	IIfcColourRgb LightColour { get; set; }

	IfcNormalisedRatioMeasure? AmbientIntensity { get; set; }

	IfcNormalisedRatioMeasure? Intensity { get; set; }
}
