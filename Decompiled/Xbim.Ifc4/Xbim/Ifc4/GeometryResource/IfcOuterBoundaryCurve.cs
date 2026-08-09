using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcOuterBoundaryCurve", 1218)]
public class IfcOuterBoundaryCurve : IfcBoundaryCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcOuterBoundaryCurve, IIfcBoundaryCurve, IIfcCompositeCurveOnSurface, IIfcCompositeCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IfcCurveOnSurface, IIfcCurveOnSurface, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOuterBoundaryCurve>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCompositeCurveSegment segment in base.Segments)
			{
				yield return segment;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcCompositeCurveSegment segment in base.Segments)
			{
				yield return segment;
			}
		}
	}

	internal IfcOuterBoundaryCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 1u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcOuterBoundaryCurve other)
	{
		return this == other;
	}
}
