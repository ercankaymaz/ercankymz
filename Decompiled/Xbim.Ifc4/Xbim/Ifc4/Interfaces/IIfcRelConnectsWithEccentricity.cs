using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelConnectsWithEccentricity : IIfcRelConnectsStructuralMember, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcConnectionGeometry ConnectionConstraint { get; set; }
}
