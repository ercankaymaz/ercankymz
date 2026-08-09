using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcIntersectionCurve", 1323)]
public class IfcIntersectionCurve : IfcSurfaceCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcIntersectionCurve>, IIfcIntersectionCurve, IIfcSurfaceCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, Xbim.Ifc4.GeometryResource.IfcCurveOnSurface, IIfcCurveOnSurface
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Curve3D != null)
			{
				yield return base.Curve3D;
			}
			foreach (IfcPcurve item in base.AssociatedGeometry)
			{
				yield return item;
			}
		}
	}

	internal IfcIntersectionCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcIntersectionCurve other)
	{
		return this == other;
	}
}
