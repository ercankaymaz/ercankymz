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

[ExpressType("IfcOffsetCurveByDistances", 1351)]
public class IfcOffsetCurveByDistances : IfcOffsetCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcOffsetCurveByDistances>, IIfcOffsetCurveByDistances, IIfcOffsetCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect
{
	private readonly ItemSet<IfcPointByDistanceExpression> _offsetValues;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _tag;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcPointByDistanceExpression> OffsetValues
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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Tag
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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
			foreach (IfcPointByDistanceExpression offsetValue in OffsetValues)
			{
				yield return offsetValue;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOffsetCurveByDistances), 2)]
	IItemSet<IIfcDistanceExpression> IIfcOffsetCurveByDistances.OffsetValues
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOffsetCurveByDistances), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcOffsetCurveByDistances.Tag
	{
		get
		{
			if (!Tag.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Tag.Value);
		}
		set
		{
			Tag = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	internal IfcOffsetCurveByDistances(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_offsetValues = new ItemSet<IfcPointByDistanceExpression>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_offsetValues.InternalAdd((IfcPointByDistanceExpression)value.EntityVal);
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
