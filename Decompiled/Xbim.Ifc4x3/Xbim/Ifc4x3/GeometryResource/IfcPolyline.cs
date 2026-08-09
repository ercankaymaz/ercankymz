using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcPolyline", 500)]
public class IfcPolyline : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPolyline>, IIfcPolyline, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	private readonly ItemSet<IfcCartesianPoint> _points;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 3)]
	public IItemSet<IfcCartesianPoint> Points
	{
		get
		{
			if (_activated)
			{
				return _points;
			}
			Activate();
			return _points;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCartesianPoint point in Points)
			{
				yield return point;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPolyline), 1)]
	IItemSet<IIfcCartesianPoint> IIfcPolyline.Points => new ProxyItemSet<IfcCartesianPoint, IIfcCartesianPoint>(Points);

	internal IfcPolyline(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_points = new ItemSet<IfcCartesianPoint>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_points.InternalAdd((IfcCartesianPoint)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPolyline other)
	{
		return this == other;
	}
}
