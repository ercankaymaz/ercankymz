using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcMeasureWithUnit", 7)]
public class IfcMeasureWithUnit : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcMeasureWithUnit, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IfcMetricValueSelect, IIfcMetricValueSelect, IContainsEntityReferences, IEquatable<IfcMeasureWithUnit>
{
	private IfcValue _valueComponent;

	private IfcUnit _unitComponent;

	IIfcValue IIfcMeasureWithUnit.ValueComponent
	{
		get
		{
			return ValueComponent;
		}
		set
		{
			ValueComponent = value as IfcValue;
		}
	}

	IIfcUnit IIfcMeasureWithUnit.UnitComponent
	{
		get
		{
			return UnitComponent;
		}
		set
		{
			UnitComponent = value as IfcUnit;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcValue ValueComponent
	{
		get
		{
			if (_activated)
			{
				return _valueComponent;
			}
			Activate();
			return _valueComponent;
		}
		set
		{
			SetValue(delegate(IfcValue v)
			{
				_valueComponent = v;
			}, _valueComponent, value, "ValueComponent", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcUnit UnitComponent
	{
		get
		{
			if (_activated)
			{
				return _unitComponent;
			}
			Activate();
			return _unitComponent;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_unitComponent = v;
			}, _unitComponent, value, "UnitComponent", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (UnitComponent != null)
			{
				yield return UnitComponent;
			}
		}
	}

	internal IfcMeasureWithUnit(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_valueComponent = (IfcValue)value.EntityVal;
			break;
		case 1:
			_unitComponent = (IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMeasureWithUnit other)
	{
		return this == other;
	}

	public string AsString()
	{
		string text = $"{ValueComponent.Value:N2}";
		string text2 = UnitComponent.Symbol();
		if (!string.IsNullOrEmpty(text2))
		{
			text += text2;
		}
		return text;
	}
}
