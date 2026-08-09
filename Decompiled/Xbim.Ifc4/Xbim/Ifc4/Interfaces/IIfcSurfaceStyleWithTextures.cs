using Xbim.Common;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceStyleWithTextures : IIfcPresentationItem, IPersistEntity, IPersist, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType
{
	IItemSet<IIfcSurfaceTexture> Textures { get; }
}
