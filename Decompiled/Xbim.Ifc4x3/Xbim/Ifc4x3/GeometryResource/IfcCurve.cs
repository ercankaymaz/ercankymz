using System;
using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometricModelResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCurve", 68)]
public abstract class IfcCurve : IfcGeometricRepresentationItem, Xbim.Ifc4x3.GeometricModelResource.IfcGeometricSetSelect, IExpressSelectType, IPersist, IPersistEntity, IIfcGeometricSetSelect, IEquatable<IfcCurve>, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim
	{
		get
		{
			if (this is IfcLine ifcLine)
			{
				return ifcLine.Pnt.Dim;
			}
			if (this is IfcConic ifcConic)
			{
				return ifcConic.Position.Dim;
			}
			if (this is IfcPolyline ifcPolyline)
			{
				return ifcPolyline.Points[1].Dim;
			}
			if (this is IfcTrimmedCurve ifcTrimmedCurve)
			{
				return ifcTrimmedCurve.BasisCurve.Dim;
			}
			if (this is IfcBSplineCurve ifcBSplineCurve)
			{
				return ifcBSplineCurve.ControlPointsList[1].Dim;
			}
			if (this is IfcOffsetCurve2D)
			{
				return 2L;
			}
			if (this is IfcOffsetCurve3D)
			{
				return 3L;
			}
			if (this is IfcOffsetCurveByDistances)
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
			if (this is IfcSegmentedReferenceCurve)
			{
				return 3L;
			}
			if (this is IfcGradientCurve)
			{
				return 3L;
			}
			if (this is IfcCompositeCurve ifcCompositeCurve)
			{
				IfcSegment ifcSegment = ifcCompositeCurve.Segments[1];
				if (ifcSegment is IfcCompositeCurveSegment ifcCompositeCurveSegment)
				{
					return ifcCompositeCurveSegment.Dim;
				}
				if (ifcSegment is IfcCurveSegment ifcCurveSegment)
				{
					return ifcCurveSegment.ParentCurve.Dim;
				}
				return 0L;
			}
			if (this is IfcPolynomialCurve ifcPolynomialCurve)
			{
				return ifcPolynomialCurve.Position.Dim;
			}
			if (this is IfcSpiral)
			{
				return 2L;
			}
			if (this is IfcSurfaceCurve ifcSurfaceCurve)
			{
				return ifcSurfaceCurve.Curve3D.Dim;
			}
			throw new NotSupportedException();
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
