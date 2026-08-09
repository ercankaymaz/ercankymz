using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextureCoordinate : IIfcPresentationItem, IPersistEntity, IPersist
{
	IItemSet<IIfcSurfaceTexture> Maps { get; }
}
