using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.GeometryResource;

public interface IfcAxis2Placement : IExpressSelectType, IPersist, IPersistEntity, IIfcAxis2Placement
{
	IfcDimensionCount Dim { get; }

	List<XbimVector3D> P { get; }
}
