using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAlignment2DHorizontalSegment : IIfcAlignment2DSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcCurveSegment2D CurveGeometry { get; set; }

	IEnumerable<IIfcAlignment2DHorizontal> ToHorizontal { get; }
}
