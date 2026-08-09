using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ConstraintResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.CostResource;

[ExpressType("IfcCostValue", 658)]
public class IfcCostValue : IfcAppliedValue, IInstantiableEntity, IPersistEntity, IPersist, Xbim.Ifc2x3.ConstraintResource.IfcMetricValueSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCostValue>, IIfcCostValue, IIfcAppliedValue, Xbim.Ifc4.ConstraintResource.IfcMetricValueSelect, IIfcMetricValueSelect, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	private IfcLabel _costType;

	private IfcText? _condition;

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcLabel CostType
	{
		get
		{
			if (_activated)
			{
				return _costType;
			}
			Activate();
			return _costType;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_costType = v;
			}, _costType, value, "CostType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcText? Condition
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
			SetValue(delegate(IfcText? v)
			{
				_condition = v;
			}, _condition, value, "Condition", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.UnitBasis != null)
			{
				yield return base.UnitBasis;
			}
			if (base.ApplicableDate != null)
			{
				yield return base.ApplicableDate;
			}
			if (base.FixedUntilDate != null)
			{
				yield return base.FixedUntilDate;
			}
		}
	}

	internal IfcCostValue(IModel model, int label, bool activated)
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
		case 3:
		case 4:
		case 5:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_costType = value.StringVal;
			break;
		case 7:
			_condition = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCostValue other)
	{
		return this == other;
	}
}
