using System;
using Xbim.Common;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.GeometricModelResource;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcPoint", 66)]
public abstract class IfcPoint : IfcGeometricRepresentationItem, Xbim.Ifc2x3.GeometricModelResource.IfcGeometricSetSelect, IExpressSelectType, IPersist, IPersistEntity, IIfcGeometricSetSelect, Xbim.Ifc2x3.GeometricConstraintResource.IfcPointOrVertexPoint, IIfcPointOrVertexPoint, IEquatable<IfcPoint>, IIfcPoint, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect, Xbim.Ifc4.GeometricConstraintResource.IfcPointOrVertexPoint
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public virtual IfcDimensionCount Dim
	{
		get
		{
			IfcCartesianPoint ifcCartesianPoint = this as IfcCartesianPoint;
			if (ifcCartesianPoint != null)
			{
				return ifcCartesianPoint.Dim;
			}
			IfcPointOnCurve ifcPointOnCurve = this as IfcPointOnCurve;
			if (ifcPointOnCurve != null)
			{
				return ifcPointOnCurve.Dim;
			}
			IfcPointOnSurface ifcPointOnSurface = this as IfcPointOnSurface;
			if (!(ifcPointOnSurface != null))
			{
				return 0L;
			}
			return ifcPointOnSurface.Dim;
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

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
