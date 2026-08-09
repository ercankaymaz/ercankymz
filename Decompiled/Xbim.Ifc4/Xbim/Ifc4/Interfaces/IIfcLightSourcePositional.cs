using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLightSourcePositional : IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcCartesianPoint Position { get; set; }

	IfcPositiveLengthMeasure Radius { get; set; }

	IfcReal ConstantAttenuation { get; set; }

	IfcReal DistanceAttenuation { get; set; }

	IfcReal QuadricAttenuation { get; set; }
}
