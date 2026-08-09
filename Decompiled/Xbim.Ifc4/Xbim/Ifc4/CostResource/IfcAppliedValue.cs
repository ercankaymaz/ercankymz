using System;
using System.Collections.Generic;
using System.Text;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.CostResource;

[ExpressType("IfcAppliedValue", 79)]
public class IfcAppliedValue : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcAppliedValue, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcAppliedValue>
{
	private IfcLabel? _name;

	private IfcText? _description;

	private IfcAppliedValueSelect _appliedValue;

	private IfcMeasureWithUnit _unitBasis;

	private IfcDate? _applicableDate;

	private IfcDate? _fixedUntilDate;

	private IfcLabel? _category;

	private IfcLabel? _condition;

	private IfcArithmeticOperatorEnum? _arithmeticOperator;

	private readonly OptionalItemSet<IfcAppliedValue> _components;

	IfcLabel? IIfcAppliedValue.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcAppliedValue.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IIfcAppliedValueSelect IIfcAppliedValue.AppliedValue
	{
		get
		{
			return AppliedValue;
		}
		set
		{
			AppliedValue = value as IfcAppliedValueSelect;
		}
	}

	IIfcMeasureWithUnit IIfcAppliedValue.UnitBasis
	{
		get
		{
			return UnitBasis;
		}
		set
		{
			UnitBasis = value as IfcMeasureWithUnit;
		}
	}

	IfcDate? IIfcAppliedValue.ApplicableDate
	{
		get
		{
			return ApplicableDate;
		}
		set
		{
			ApplicableDate = value;
		}
	}

	IfcDate? IIfcAppliedValue.FixedUntilDate
	{
		get
		{
			return FixedUntilDate;
		}
		set
		{
			FixedUntilDate = value;
		}
	}

	IfcLabel? IIfcAppliedValue.Category
	{
		get
		{
			return Category;
		}
		set
		{
			Category = value;
		}
	}

	IfcLabel? IIfcAppliedValue.Condition
	{
		get
		{
			return Condition;
		}
		set
		{
			Condition = value;
		}
	}

	IfcArithmeticOperatorEnum? IIfcAppliedValue.ArithmeticOperator
	{
		get
		{
			return ArithmeticOperator;
		}
		set
		{
			ArithmeticOperator = value;
		}
	}

	IEnumerable<IIfcAppliedValue> IIfcAppliedValue.Components => new ProxyItemSet<IfcAppliedValue, IIfcAppliedValue>(Components);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcAppliedValue.HasExternalReference => HasExternalReference;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcAppliedValueSelect AppliedValue
	{
		get
		{
			if (_activated)
			{
				return _appliedValue;
			}
			Activate();
			return _appliedValue;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAppliedValueSelect v)
			{
				_appliedValue = v;
			}, _appliedValue, value, "AppliedValue", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcMeasureWithUnit UnitBasis
	{
		get
		{
			if (_activated)
			{
				return _unitBasis;
			}
			Activate();
			return _unitBasis;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMeasureWithUnit v)
			{
				_unitBasis = v;
			}, _unitBasis, value, "UnitBasis", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcDate? ApplicableDate
	{
		get
		{
			if (_activated)
			{
				return _applicableDate;
			}
			Activate();
			return _applicableDate;
		}
		set
		{
			SetValue(delegate(IfcDate? v)
			{
				_applicableDate = v;
			}, _applicableDate, value, "ApplicableDate", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcDate? FixedUntilDate
	{
		get
		{
			if (_activated)
			{
				return _fixedUntilDate;
			}
			Activate();
			return _fixedUntilDate;
		}
		set
		{
			SetValue(delegate(IfcDate? v)
			{
				_fixedUntilDate = v;
			}, _fixedUntilDate, value, "FixedUntilDate", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLabel? Category
	{
		get
		{
			if (_activated)
			{
				return _category;
			}
			Activate();
			return _category;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_category = v;
			}, _category, value, "Category", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLabel? Condition
	{
		get
		{
			if (_activated)
			{
				return _condition;
			}
			Activate();
			return _condition;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_condition = v;
			}, _condition, value, "Condition", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcArithmeticOperatorEnum? ArithmeticOperator
	{
		get
		{
			if (_activated)
			{
				return _arithmeticOperator;
			}
			Activate();
			return _arithmeticOperator;
		}
		set
		{
			SetValue(delegate(IfcArithmeticOperatorEnum? v)
			{
				_arithmeticOperator = v;
			}, _arithmeticOperator, value, "ArithmeticOperator", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcAppliedValue> Components
	{
		get
		{
			if (_activated)
			{
				return _components;
			}
			Activate();
			return _components;
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<IfcExternalReferenceRelationship> HasExternalReference => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (UnitBasis != null)
			{
				yield return UnitBasis;
			}
			foreach (IfcAppliedValue component in Components)
			{
				yield return component;
			}
		}
	}

	internal IfcAppliedValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_components = new OptionalItemSet<IfcAppliedValue>(this, 0, 10);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_appliedValue = (IfcAppliedValueSelect)value.EntityVal;
			break;
		case 3:
			_unitBasis = (IfcMeasureWithUnit)value.EntityVal;
			break;
		case 4:
			_applicableDate = value.StringVal;
			break;
		case 5:
			_fixedUntilDate = value.StringVal;
			break;
		case 6:
			_category = value.StringVal;
			break;
		case 7:
			_condition = value.StringVal;
			break;
		case 8:
			_arithmeticOperator = (IfcArithmeticOperatorEnum)Enum.Parse(typeof(IfcArithmeticOperatorEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_components.InternalAdd((IfcAppliedValue)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAppliedValue other)
	{
		return this == other;
	}

	public string AsString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		IfcText? description = Description;
		if (!string.IsNullOrEmpty(description.HasValue ? ((string)description.GetValueOrDefault()) : null))
		{
			description = Description;
			stringBuilder.Append(description.HasValue ? ((string)description.GetValueOrDefault()) : null);
			stringBuilder.Append(", ");
		}
		if (AppliedValue != null)
		{
			stringBuilder.Append("AppliedValue: ");
			if (AppliedValue is IfcRatioMeasure)
			{
				stringBuilder.Append($"{((IfcRatioMeasure)(object)AppliedValue).Value:N2}");
			}
			if (AppliedValue is IfcMonetaryMeasure)
			{
				stringBuilder.Append($"{((IfcMonetaryMeasure)(object)AppliedValue).Value:N2}");
			}
			IfcMeasureWithUnit ifcMeasureWithUnit = AppliedValue as IfcMeasureWithUnit;
			if (ifcMeasureWithUnit != null)
			{
				stringBuilder.Append(ifcMeasureWithUnit.AsString());
			}
			stringBuilder.Append(", ");
		}
		if (UnitBasis != null)
		{
			stringBuilder.Append("UnitBase: ");
			stringBuilder.Append(UnitBasis.AsString());
			stringBuilder.Append(", ");
		}
		if (ApplicableDate.HasValue)
		{
			stringBuilder.Append("ApplicableDate: ");
			stringBuilder.Append(ApplicableDate.ToString());
			stringBuilder.Append(", ");
		}
		if (FixedUntilDate.HasValue)
		{
			stringBuilder.Append("FixedUntilDate: ");
			stringBuilder.Append(FixedUntilDate.ToString());
			stringBuilder.Append(", ");
		}
		return stringBuilder.ToString();
	}
}
