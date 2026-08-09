using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcOpenShell : IIfcConnectedFaceSet, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcShell, IIfcShell
{
}
