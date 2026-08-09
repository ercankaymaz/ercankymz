using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelDefinesByType : IIfcRelDefines, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcObject> RelatedObjects { get; }

	IIfcTypeObject RelatingType { get; set; }
}
