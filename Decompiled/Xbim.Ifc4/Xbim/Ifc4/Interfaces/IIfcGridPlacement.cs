using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcGridPlacement : IIfcObjectPlacement, IPersistEntity, IPersist
{
	IIfcVirtualGridIntersection PlacementLocation { get; set; }

	IIfcGridPlacementDirectionSelect PlacementRefDirection { get; set; }
}
