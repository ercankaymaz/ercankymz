using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelDefinesByProperties : IIfcRelDefines, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcObjectDefinition> RelatedObjects { get; }

	IIfcPropertySetDefinitionSelect RelatingPropertyDefinition { get; set; }
}
