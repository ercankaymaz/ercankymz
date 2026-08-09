using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcGridAxis : IPersistEntity, IPersist
{
	IfcLabel? AxisTag { get; set; }

	IIfcCurve AxisCurve { get; set; }

	IfcBoolean SameSense { get; set; }

	IEnumerable<IIfcGrid> PartOfW { get; }

	IEnumerable<IIfcGrid> PartOfV { get; }

	IEnumerable<IIfcGrid> PartOfU { get; }

	IEnumerable<IIfcVirtualGridIntersection> HasIntersections { get; }
}
