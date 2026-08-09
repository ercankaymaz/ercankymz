using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSubedge : IIfcEdge, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcEdge ParentEdge { get; set; }
}
