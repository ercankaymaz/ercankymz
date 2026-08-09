using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcOffsetCurve2D", 687)]
public class IfcOffsetCurve2D : IfcOffsetCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcOffsetCurve2D>, IIfcOffsetCurve2D, IIfcOffsetCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure _distance;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _selfIntersect;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure Distance
	{
		get
		{
			if (_activated)
			{
				return _distance;
			}
			Activate();
			return _distance;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure v)
			{
				_distance = v;
			}, _distance, value, "Distance", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical SelfIntersect
	{
		get
		{
			if (_activated)
			{
				return _selfIntersect;
			}
			Activate();
			return _selfIntersect;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_selfIntersect = v;
			}, _selfIntersect, value, "SelfIntersect", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.BasisCurve != null)
			{
				yield return base.BasisCurve;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOffsetCurve2D), 2)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcOffsetCurve2D.Distance
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(Distance);
		}
		set
		{
			Distance = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOffsetCurve2D), 3)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcOffsetCurve2D.SelfIntersect
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(SelfIntersect);
		}
		set
		{
			SelfIntersect = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	internal IfcOffsetCurve2D(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_distance = value.RealVal;
			break;
		case 2:
			_selfIntersect = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOffsetCurve2D other)
	{
		return this == other;
	}
}
