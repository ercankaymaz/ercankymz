using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceStyleRefraction : IIfcPresentationItem, IPersistEntity, IPersist, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType
{
	IfcReal? RefractionIndex { get; set; }

	IfcReal? DispersionFactor { get; set; }
}
