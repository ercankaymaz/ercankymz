using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCartesianTransformationOperator2D : IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	List<XbimVector3D> U { get; }
}
