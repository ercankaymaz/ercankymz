using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSweptDiskSolid : IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	IIfcCurve Directrix { get; set; }

	IfcPositiveLengthMeasure Radius { get; set; }

	IfcPositiveLengthMeasure? InnerRadius { get; set; }

	IfcParameterValue? StartParam { get; set; }

	IfcParameterValue? EndParam { get; set; }
}
