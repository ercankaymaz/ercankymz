using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPresentationLayerWithStyle : IIfcPresentationLayerAssignment, IPersistEntity, IPersist
{
	IfcLogical LayerOn { get; set; }

	IfcLogical LayerFrozen { get; set; }

	IfcLogical LayerBlocked { get; set; }

	IItemSet<IIfcPresentationStyle> LayerStyles { get; }
}
