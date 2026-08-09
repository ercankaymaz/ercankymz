using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcImageTexture : IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist
{
	IfcURIReference URLReference { get; set; }
}
