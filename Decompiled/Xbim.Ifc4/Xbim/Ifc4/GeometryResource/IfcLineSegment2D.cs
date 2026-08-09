using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcLineSegment2D", 1343)]
public class IfcLineSegment2D : IfcCurveSegment2D, IInstantiableEntity, IPersistEntity, IPersist, IIfcLineSegment2D, IIfcCurveSegment2D, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcLineSegment2D>
{
	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.StartPoint != null)
			{
				yield return base.StartPoint;
			}
		}
	}

	internal IfcLineSegment2D(IModel model, int label, bool activated)
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

	public bool Equals(IfcLineSegment2D other)
	{
		return this == other;
	}
}
