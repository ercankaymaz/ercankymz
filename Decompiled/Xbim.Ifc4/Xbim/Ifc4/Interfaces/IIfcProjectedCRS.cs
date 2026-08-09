using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProjectedCRS : IIfcCoordinateReferenceSystem, IPersistEntity, IPersist, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType
{
	IfcIdentifier? MapProjection { get; set; }

	IfcIdentifier? MapZone { get; set; }

	IIfcNamedUnit MapUnit { get; set; }
}
