using Xbim.Common;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceStyleRendering : IIfcSurfaceStyleShading, IIfcPresentationItem, IPersistEntity, IPersist, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType
{
	IIfcColourOrFactor DiffuseColour { get; set; }

	IIfcColourOrFactor TransmissionColour { get; set; }

	IIfcColourOrFactor DiffuseTransmissionColour { get; set; }

	IIfcColourOrFactor ReflectionColour { get; set; }

	IIfcColourOrFactor SpecularColour { get; set; }

	IIfcSpecularHighlightSelect SpecularHighlight { get; set; }

	IfcReflectanceMethodEnum ReflectanceMethod { get; set; }
}
