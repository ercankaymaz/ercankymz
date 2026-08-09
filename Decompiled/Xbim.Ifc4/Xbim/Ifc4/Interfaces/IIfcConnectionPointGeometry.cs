using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConnectionPointGeometry : IIfcConnectionGeometry, IPersistEntity, IPersist
{
	IIfcPointOrVertexPoint PointOnRelatingElement { get; set; }

	IIfcPointOrVertexPoint PointOnRelatedElement { get; set; }
}
