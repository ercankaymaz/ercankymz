using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPresentationLayerAssignment : IPersistEntity, IPersist
{
	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IItemSet<IIfcLayeredItem> AssignedItems { get; }

	IfcIdentifier? Identifier { get; set; }
}
