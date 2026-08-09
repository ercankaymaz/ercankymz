using System;
using Xbim.Common;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometricConstraintResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcBoundedCurve", 144)]
public abstract class IfcBoundedCurve : IfcCurve, Xbim.Ifc4x3.GeometricConstraintResource.IfcCurveOrEdgeCurve, IExpressSelectType, IPersist, IPersistEntity, IIfcCurveOrEdgeCurve, IEquatable<IfcBoundedCurve>, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IfcGeometricSetSelect, IIfcGeometricSetSelect, Xbim.Ifc4.GeometricConstraintResource.IfcCurveOrEdgeCurve
{
	internal IfcBoundedCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcBoundedCurve other)
	{
		return this == other;
	}
}
