using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelDefinesByTemplate : IIfcRelDefines, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcPropertySetDefinition> RelatedPropertySets { get; }

	IIfcPropertySetTemplate RelatingTemplate { get; set; }
}
