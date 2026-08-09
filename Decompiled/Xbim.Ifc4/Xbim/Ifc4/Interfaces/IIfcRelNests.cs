using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelNests : IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcObjectDefinition RelatingObject { get; set; }

	IItemSet<IIfcObjectDefinition> RelatedObjects { get; }
}
