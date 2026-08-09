using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAlignment2DHorizontal : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcLengthMeasure? StartDistAlong { get; set; }

	IItemSet<IIfcAlignment2DHorizontalSegment> Segments { get; }

	IEnumerable<IIfcAlignmentCurve> ToAlignmentCurve { get; }
}
