using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextureVertexList : IIfcPresentationItem, IPersistEntity, IPersist
{
	IItemSet<IItemSet<IfcParameterValue>> TexCoordsList { get; }
}
