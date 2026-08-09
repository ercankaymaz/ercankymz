using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcVector : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcHatchLineDistanceSelect, IIfcHatchLineDistanceSelect, IfcVectorOrDirection, IIfcVectorOrDirection
{
	IIfcDirection Orientation { get; set; }

	IfcLengthMeasure Magnitude { get; set; }

	IfcDimensionCount Dim { get; }
}
