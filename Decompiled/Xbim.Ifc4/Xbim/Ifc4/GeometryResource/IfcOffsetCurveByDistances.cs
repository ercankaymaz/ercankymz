using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcOffsetCurveByDistances", 1351)]
public class IfcOffsetCurveByDistances : IfcOffsetCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcOffsetCurveByDistances, IIfcOffsetCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IContainsEntityReferences, IEquatable<IfcOffsetCurveByDistances>
{
	private readonly ItemSet<IfcDistanceExpression> _offsetValues;

	private IfcLabel? _tag;

	IItemSet<IIfcDistanceExpression> IIfcOffsetCurveByDistances.OffsetValues => new ProxyItemSet<IfcDistanceExpression, IIfcDistanceExpression>(OffsetValues);

	IfcLabel? IIfcOffsetCurveByDistances.Tag
	{
		get
		{
			return Tag;
		}
		set
		{
			Tag = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcDistanceExpression> OffsetValues
	{
		get
		{
			if (_activated)
			{
				return _offsetValues;
			}
			Activate();
			return _offsetValues;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLabel? Tag
	{
		get
		{
			if (_activated)
			{
				return _tag;
			}
			Activate();
			return _tag;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_tag = v;
			}, _tag, value, "Tag", 3);
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
			foreach (IfcDistanceExpression offsetValue in OffsetValues)
			{
				yield return offsetValue;
			}
		}
	}

	internal IfcOffsetCurveByDistances(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_offsetValues = new ItemSet<IfcDistanceExpression>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_offsetValues.InternalAdd((IfcDistanceExpression)value.EntityVal);
			break;
		case 2:
			_tag = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOffsetCurveByDistances other)
	{
		return this == other;
	}
}
