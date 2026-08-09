using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelServicesBuildings : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcSystem RelatingSystem { get; set; }

	IItemSet<IIfcSpatialElement> RelatedBuildings { get; }
}
