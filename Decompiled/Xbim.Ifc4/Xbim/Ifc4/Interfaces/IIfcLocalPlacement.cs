using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLocalPlacement : IIfcObjectPlacement, IPersistEntity, IPersist
{
	IIfcObjectPlacement PlacementRelTo { get; set; }

	IIfcAxis2Placement RelativePlacement { get; set; }
}
