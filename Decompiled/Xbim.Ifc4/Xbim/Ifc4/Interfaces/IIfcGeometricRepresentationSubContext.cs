using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcGeometricRepresentationSubContext : IIfcGeometricRepresentationContext, IIfcRepresentationContext, IPersistEntity, IPersist, IfcCoordinateReferenceSystemSelect, IIfcCoordinateReferenceSystemSelect, IExpressSelectType
{
	IIfcGeometricRepresentationContext ParentContext { get; set; }

	IfcPositiveRatioMeasure? TargetScale { get; set; }

	IfcGeometricProjectionEnum TargetView { get; set; }

	IfcLabel? UserDefinedTargetView { get; set; }
}
