using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometricConstraintResource;
using Xbim.Ifc4x3.GeometricModelResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcPoint", 66)]
public abstract class IfcPoint : IfcGeometricRepresentationItem, Xbim.Ifc4x3.GeometricModelResource.IfcGeometricSetSelect, IExpressSelectType, IPersist, IPersistEntity, IIfcGeometricSetSelect, Xbim.Ifc4x3.GeometricConstraintResource.IfcPointOrVertexPoint, IIfcPointOrVertexPoint, IEquatable<IfcPoint>, IIfcPoint, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect, Xbim.Ifc4.GeometricConstraintResource.IfcPointOrVertexPoint
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => Dimension;

	public IfcDimensionCount Dimension
	{
		get
		{
			if (this is IfcCartesianPoint ifcCartesianPoint)
			{
				return ifcCartesianPoint.Coordinates.Count;
			}
			if (this is IfcPointByDistanceExpression ifcPointByDistanceExpression)
			{
				return ifcPointByDistanceExpression.BasisCurve.Dim;
			}
			if (this is IfcPointOnCurve ifcPointOnCurve)
			{
				return ifcPointOnCurve.BasisCurve.Dim;
			}
			if (this is IfcPointOnSurface ifcPointOnSurface)
			{
				return ifcPointOnSurface.BasisSurface.Dim;
			}
			throw new XbimException("Unexpected point type");
		}
	}

	IfcDimensionCount Xbim.Ifc4x3.GeometricModelResource.IfcGeometricSetSelect.Dim => 0L;

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect.Dim => 0L;

	internal IfcPoint(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcPoint other)
	{
		return this == other;
	}
}
