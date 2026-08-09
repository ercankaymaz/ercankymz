using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConnectionSurfaceGeometry : IIfcConnectionGeometry, IPersistEntity, IPersist
{
	IIfcSurfaceOrFaceSurface SurfaceOnRelatingElement { get; set; }

	IIfcSurfaceOrFaceSurface SurfaceOnRelatedElement { get; set; }
}
