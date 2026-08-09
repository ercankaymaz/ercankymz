using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCartesianTransformationOperator : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcDirection Axis1 { get; set; }

	IIfcDirection Axis2 { get; set; }

	IIfcCartesianPoint LocalOrigin { get; set; }

	IfcReal? Scale { get; set; }

	IfcReal Scl { get; }

	IfcDimensionCount Dim { get; }
}
