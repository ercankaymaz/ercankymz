using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelConnectsWithRealizingElements : IIfcRelConnectsElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcElement> RealizingElements { get; }

	IfcLabel? ConnectionType { get; set; }
}
