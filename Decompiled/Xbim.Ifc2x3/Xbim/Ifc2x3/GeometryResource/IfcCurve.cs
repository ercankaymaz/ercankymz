using System;
using Xbim.Common;
using Xbim.Ifc2x3.GeometricModelResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcCurve", 68)]
public abstract class IfcCurve : IfcGeometricRepresentationItem, Xbim.Ifc2x3.GeometricModelResource.IfcGeometricSetSelect, IExpressSelectType, IPersist, IPersistEntity, IIfcGeometricSetSelect, IEquatable<IfcCurve>, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim
	{
		get
		{
			IfcLine ifcLine = this as IfcLine;
			if (ifcLine != null)
			{
				return ifcLine.Pnt.Dim;
			}
			IfcConic ifcConic = this as IfcConic;
			if (ifcConic != null)
			{
				return ifcConic.Position.Dim;
			}
			IfcPolyline ifcPolyline = this as IfcPolyline;
			if (ifcPolyline != null)
			{
				return ifcPolyline.Points[1].Dim;
			}
			IfcTrimmedCurve ifcTrimmedCurve = this as IfcTrimmedCurve;
			if (ifcTrimmedCurve != null)
			{
				return ifcTrimmedCurve.BasisCurve.Dim;
			}
			IfcCompositeCurve ifcCompositeCurve = this as IfcCompositeCurve;
			if (ifcCompositeCurve != null && ifcCompositeCurve.Segments.Count > 0)
			{
				if (ifcCompositeCurve.Segments.Count != 1)
				{
					return ifcCompositeCurve.Segments[1].Dim;
				}
				return ifcCompositeCurve.Segments[0].Dim;
			}
			IfcBSplineCurve ifcBSplineCurve = this as IfcBSplineCurve;
			if (ifcBSplineCurve != null && ifcBSplineCurve.ControlPointsList.Count > 0)
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
			return new IfcDimensionCount(0L);
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

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
