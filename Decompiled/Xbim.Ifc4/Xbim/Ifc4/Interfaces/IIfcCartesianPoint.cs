using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCartesianPoint : IIfcPoint, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcPointOrVertexPoint, IIfcPointOrVertexPoint, IfcTrimmingSelect, IIfcTrimmingSelect
{
	IItemSet<IfcLengthMeasure> Coordinates { get; }

	double X { get; }

	double Y { get; }

	double Z { get; }
}
