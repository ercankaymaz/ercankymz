using System;
using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCurve", 68)]
public abstract class IfcCurve : IfcGeometricRepresentationItem, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IEquatable<IfcCurve>
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim
	{
		get
		{
			if (this as IfcLine != null)
			{
				return (this as IfcLine).Pnt.Dim;
			}
			if (this as IfcConic != null)
			{
				return (this as IfcConic).Position.Dim;
			}
			if (this as IfcPolyline != null)
			{
				return (this as IfcPolyline).Points[1].Dim;
			}
			if (this as IfcTrimmedCurve != null)
			{
				return (this as IfcTrimmedCurve).BasisCurve.Dim;
			}
			if (this is IfcCompositeCurve ifcCompositeCurve && ifcCompositeCurve.Segments.Count > 0)
			{
				if (ifcCompositeCurve.Segments.Count != 1)
				{
					return ifcCompositeCurve.Segments[1].Dim;
				}
				return ifcCompositeCurve.Segments[0].Dim;
			}
			if (this is IfcBSplineCurve ifcBSplineCurve && ifcBSplineCurve.ControlPointsList.Count > 0)
			{
				if (ifcBSplineCurve.ControlPointsList.Count != 1)
				{
					return ifcBSplineCurve.ControlPointsList[1].Dim;
				}
				return ifcBSplineCurve.ControlPointsList[0].Dim;
			}
			if (this is IfcOffsetCurve2D)
			{
				return 2L;
			}
			if (this is IfcOffsetCurve3D)
			{
				return 3L;
			}
			if (this is IfcPcurve)
			{
				return 3L;
			}
			if (this is IfcIndexedPolyCurve ifcIndexedPolyCurve)
			{
				return ifcIndexedPolyCurve.Points.Dim;
			}
			return new IfcDimensionCount(0L);
		}
	}

	internal IfcCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcCurve other)
	{
		return this == other;
	}
}
