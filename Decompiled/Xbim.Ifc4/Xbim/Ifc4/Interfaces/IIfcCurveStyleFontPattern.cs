using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCurveStyleFontPattern : IIfcPresentationItem, IPersistEntity, IPersist
{
	IfcLengthMeasure VisibleSegmentLength { get; set; }

	IfcPositiveLengthMeasure InvisibleSegmentLength { get; set; }
}
