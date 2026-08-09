using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcIndexedTriangleTextureMap : IIfcIndexedTextureMap, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist
{
	IItemSet<IItemSet<IfcPositiveInteger>> TexCoordIndex { get; }
}
