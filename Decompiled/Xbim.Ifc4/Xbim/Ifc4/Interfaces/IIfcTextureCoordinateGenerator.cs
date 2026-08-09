using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextureCoordinateGenerator : IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist
{
	IfcLabel Mode { get; set; }

	IEnumerable<IfcReal> Parameter { get; }
}
