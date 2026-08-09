using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConnectionCurveGeometry : IIfcConnectionGeometry, IPersistEntity, IPersist
{
	IIfcCurveOrEdgeCurve CurveOnRelatingElement { get; set; }

	IIfcCurveOrEdgeCurve CurveOnRelatedElement { get; set; }
}
