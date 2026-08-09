using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCartesianTransformationOperator3D : IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcDirection Axis3 { get; set; }

	List<XbimVector3D> U { get; }
}
