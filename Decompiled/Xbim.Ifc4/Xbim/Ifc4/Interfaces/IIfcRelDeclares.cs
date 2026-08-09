using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelDeclares : IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcContext RelatingContext { get; set; }

	IItemSet<IIfcDefinitionSelect> RelatedDefinitions { get; }
}
