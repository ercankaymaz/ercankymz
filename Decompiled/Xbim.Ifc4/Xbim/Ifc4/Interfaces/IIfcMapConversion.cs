using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMapConversion : IIfcCoordinateOperation, IPersistEntity, IPersist
{
	IfcLengthMeasure Eastings { get; set; }

	IfcLengthMeasure Northings { get; set; }

	IfcLengthMeasure OrthogonalHeight { get; set; }

	IfcReal? XAxisAbscissa { get; set; }

	IfcReal? XAxisOrdinate { get; set; }

	IfcReal? Scale { get; set; }
}
