using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.QuantityResource;

[ExpressType("IfcQuantityTime", 254)]
public class IfcQuantityTime : IfcPhysicalSimpleQuantity, IIfcQuantityTime, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityTime>
{
	private Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure _timeValue;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _formula;

	[CrossSchemaAttribute(typeof(IIfcQuantityTime), 4)]
	Xbim.Ifc4.MeasureResource.IfcTimeMeasure IIfcQuantityTime.TimeValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure(TimeValue);
		}
		set
		{
			TimeValue = new Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityTime), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityTime.Formula
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
	public Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure TimeValue
	{
		get
		{
			if (_activated)
			{
				return _timeValue;
			}
			Activate();
			return _timeValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure v)
			{
				_timeValue = v;
			}, _timeValue, value, "TimeValue", 4);
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

	internal IfcQuantityTime(IModel model, int label, bool activated)
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
			_timeValue = value.RealVal;
			break;
		case 4:
			_formula = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityTime other)
	{
		return this == other;
	}
}
