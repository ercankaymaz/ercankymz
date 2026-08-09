using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBoundingBox : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcCartesianPoint Corner { get; set; }

	IfcPositiveLengthMeasure XDim { get; set; }

	IfcPositiveLengthMeasure YDim { get; set; }

	IfcPositiveLengthMeasure ZDim { get; set; }

	IfcDimensionCount Dim { get; }
}
