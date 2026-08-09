using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssigns : IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcObjectDefinition> RelatedObjects { get; }

	IfcObjectTypeEnum? RelatedObjectsType { get; set; }
}
