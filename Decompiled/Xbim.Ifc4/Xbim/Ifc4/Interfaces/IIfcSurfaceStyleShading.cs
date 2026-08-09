using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceStyleShading : IIfcPresentationItem, IPersistEntity, IPersist, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType
{
	IIfcColourRgb SurfaceColour { get; set; }

	IfcNormalisedRatioMeasure? Transparency { get; set; }
}
