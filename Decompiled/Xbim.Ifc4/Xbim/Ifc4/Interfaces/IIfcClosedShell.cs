using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcClosedShell : IIfcConnectedFaceSet, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcShell, IIfcShell, IfcSolidOrShell, IIfcSolidOrShell
{
}
