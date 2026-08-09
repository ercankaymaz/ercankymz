using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLinearPlacement : IIfcObjectPlacement, IPersistEntity, IPersist
{
	IIfcCurve PlacementRelTo { get; set; }

	IIfcDistanceExpression Distance { get; set; }

	IIfcOrientationExpression Orientation { get; set; }

	IIfcAxis2Placement3D CartesianPosition { get; set; }
}
