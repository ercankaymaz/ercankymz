using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCartesianTransformationOperator3DnonUniform : IIfcCartesianTransformationOperator3D, IIfcCartesianTransformationOperator, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcReal? Scale2 { get; set; }

	IfcReal? Scale3 { get; set; }

	IfcReal Scl2 { get; }

	IfcReal Scl3 { get; }
}
