using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAlignment2DVerticalSegment : IIfcAlignment2DSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcLengthMeasure StartDistAlong { get; set; }

	IfcPositiveLengthMeasure HorizontalLength { get; set; }

	IfcLengthMeasure StartHeight { get; set; }

	IfcRatioMeasure StartGradient { get; set; }

	IEnumerable<IIfcAlignment2DVertical> ToVertical { get; }
}
