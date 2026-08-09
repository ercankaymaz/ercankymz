using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCompositeCurveSegment : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcTransitionCode Transition { get; set; }

	IfcBoolean SameSense { get; set; }

	IIfcCurve ParentCurve { get; set; }

	IEnumerable<IIfcCompositeCurve> UsingCurves { get; }

	IfcDimensionCount Dim { get; }
}
