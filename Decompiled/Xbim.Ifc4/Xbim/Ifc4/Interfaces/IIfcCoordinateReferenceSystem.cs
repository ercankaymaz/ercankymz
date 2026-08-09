using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCoordinateReferenceSystem : IPersistEntity, IPersist, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType
{
	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IfcIdentifier? GeodeticDatum { get; set; }

	IfcIdentifier? VerticalDatum { get; set; }

	IEnumerable<IIfcCoordinateOperation> HasCoordinateOperation { get; }
}
