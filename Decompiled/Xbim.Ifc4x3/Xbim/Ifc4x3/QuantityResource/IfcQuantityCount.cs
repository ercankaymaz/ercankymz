using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.QuantityResource;

[ExpressType("IfcQuantityCount", 457)]
public class IfcQuantityCount : IfcPhysicalSimpleQuantity, IIfcQuantityCount, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityCount>
{
	private Xbim.Ifc4x3.MeasureResource.IfcCountMeasure _countValue;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _formula;

	[CrossSchemaAttribute(typeof(IIfcQuantityCount), 4)]
	Xbim.Ifc4.MeasureResource.IfcCountMeasure IIfcQuantityCount.CountValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcCountMeasure((long)CountValue);
		}
		set
		{
			CountValue = new Xbim.Ifc4x3.MeasureResource.IfcCountMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityCount), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityCount.Formula
	{
		get
		{
			if (!Formula.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Formula.Value);
		}
		set
		{
			Formula = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcCountMeasure CountValue
	{
		get
		{
			if (_activated)
			{
				return _countValue;
			}
			Activate();
			return _countValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcCountMeasure v)
			{
				_countValue = v;
			}, _countValue, value, "CountValue", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Formula
	{
		get
		{
			if (_activated)
			{
				return _formula;
			}
			Activate();
			return _formula;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_formula = v;
			}, _formula, value, "Formula", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Unit != null)
			{
				yield return base.Unit;
			}
		}
	}

	internal IfcQuantityCount(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_countValue = value.IntegerVal;
			break;
		case 4:
			_formula = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityCount other)
	{
		return this == other;
	}
}
