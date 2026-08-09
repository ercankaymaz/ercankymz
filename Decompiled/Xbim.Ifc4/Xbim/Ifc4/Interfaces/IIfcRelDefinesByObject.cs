using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelDefinesByObject : IIfcRelDefines, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcObject> RelatedObjects { get; }

	IIfcObject RelatingObject { get; set; }
}
