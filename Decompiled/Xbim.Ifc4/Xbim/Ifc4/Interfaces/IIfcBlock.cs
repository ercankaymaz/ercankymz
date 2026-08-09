using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBlock : IIfcCsgPrimitive3D, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect
{
	IfcPositiveLengthMeasure XLength { get; set; }

	IfcPositiveLengthMeasure YLength { get; set; }

	IfcPositiveLengthMeasure ZLength { get; set; }
}
