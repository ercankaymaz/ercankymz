using Xbim.Common;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceStyleLighting : IIfcPresentationItem, IPersistEntity, IPersist, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType
{
	IIfcColourRgb DiffuseTransmissionColour { get; set; }

	IIfcColourRgb DiffuseReflectionColour { get; set; }

	IIfcColourRgb TransmissionColour { get; set; }

	IIfcColourRgb ReflectanceColour { get; set; }
}
