using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.GeometryResource;

public interface IfcAxis2Placement : IIfcAxis2Placement, IExpressSelectType, IPersist, IPersistEntity
{
	IfcDimensionCount Dim { get; }

	List<XbimVector3D> P { get; }
}
