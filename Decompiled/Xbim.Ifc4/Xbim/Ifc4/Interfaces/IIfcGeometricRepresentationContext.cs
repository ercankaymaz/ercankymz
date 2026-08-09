using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcGeometricRepresentationContext : IIfcRepresentationContext, IPersistEntity, IPersist, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType
{
	IfcDimensionCount CoordinateSpaceDimension { get; set; }

	IfcReal? Precision { get; set; }

	IIfcAxis2Placement WorldCoordinateSystem { get; set; }

	IIfcDirection TrueNorth { get; set; }

	IEnumerable<IIfcGeometricRepresentationSubContext> HasSubContexts { get; }

	IEnumerable<IIfcCoordinateOperation> HasCoordinateOperation { get; }
}
