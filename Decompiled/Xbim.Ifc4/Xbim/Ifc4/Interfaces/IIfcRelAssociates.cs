using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssociates : IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcDefinitionSelect> RelatedObjects { get; }
}
