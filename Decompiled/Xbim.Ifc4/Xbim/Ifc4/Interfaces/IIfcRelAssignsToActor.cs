using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssignsToActor : IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcActor RelatingActor { get; set; }

	IIfcActorRole ActingRole { get; set; }
}
