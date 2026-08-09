using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PropertyResource;

[ExpressType("IfcPropertyBoundedValue", 3)]
public class IfcPropertyBoundedValue : IfcSimpleProperty, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertyBoundedValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPropertyBoundedValue>, IExpressValidatable
{
	public enum IfcPropertyBoundedValueClause
	{
		SameUnitUpperLower,
		SameUnitUpperSet,
		SameUnitLowerSet
	}

	private IfcValue _upperBoundValue;

	private IfcValue _lowerBoundValue;

	private IfcUnit _unit;

	private IfcValue _setPointValue;

	IIfcValue IIfcPropertyBoundedValue.UpperBoundValue
	{
		get
		{
			return UpperBoundValue;
		}
		set
		{
			UpperBoundValue = value as IfcValue;
		}
	}

	IIfcValue IIfcPropertyBoundedValue.LowerBoundValue
	{
		get
		{
			return LowerBoundValue;
		}
		set
		{
			LowerBoundValue = value as IfcValue;
		}
	}

	IIfcUnit IIfcPropertyBoundedValue.Unit
	{
		get
		{
			return Unit;
		}
		set
		{
			Unit = value as IfcUnit;
		}
	}

	IIfcValue IIfcPropertyBoundedValue.SetPointValue
	{
		get
		{
			return SetPointValue;
		}
		set
		{
			SetPointValue = value as IfcValue;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public IfcValue UpperBoundValue
	{
		get
		{
			if (_activated)
			{
				return _upperBoundValue;
			}
			Activate();
			return _upperBoundValue;
		}
		set
		{
			SetValue(delegate(IfcValue v)
			{
				_upperBoundValue = v;
			}, _upperBoundValue, value, "UpperBoundValue", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
	public IfcValue LowerBoundValue
	{
		get
		{
			if (_activated)
			{
				return _lowerBoundValue;
			}
			Activate();
			return _lowerBoundValue;
		}
		set
		{
			SetValue(delegate(IfcValue v)
			{
				_lowerBoundValue = v;
			}, _lowerBoundValue, value, "LowerBoundValue", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcUnit Unit
	{
		get
		{
			if (_activated)
			{
				return _unit;
			}
			Activate();
			return _unit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcValue SetPointValue
	{
		get
		{
			if (_activated)
			{
				return _setPointValue;
			}
			Activate();
			return _setPointValue;
		}
		set
		{
			SetValue(delegate(IfcValue v)
			{
				_setPointValue = v;
			}, _setPointValue, value, "SetPointValue", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Unit != null)
			{
				yield return Unit;
			}
		}
	}

	internal IfcPropertyBoundedValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_upperBoundValue = (IfcValue)value.EntityVal;
			break;
		case 3:
			_lowerBoundValue = (IfcValue)value.EntityVal;
			break;
		case 4:
			_unit = (IfcUnit)value.EntityVal;
			break;
		case 5:
			_setPointValue = (IfcValue)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyBoundedValue other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertyBoundedValueClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcPropertyBoundedValueClause.SameUnitUpperLower:
				result = !Functions.EXISTS(UpperBoundValue) || !Functions.EXISTS(LowerBoundValue) || Functions.TYPEOF(UpperBoundValue) == Functions.TYPEOF(LowerBoundValue);
				break;
			case IfcPropertyBoundedValueClause.SameUnitUpperSet:
				result = !Functions.EXISTS(UpperBoundValue) || !Functions.EXISTS(SetPointValue) || Functions.TYPEOF(UpperBoundValue) == Functions.TYPEOF(SetPointValue);
				break;
			case IfcPropertyBoundedValueClause.SameUnitLowerSet:
				result = !Functions.EXISTS(LowerBoundValue) || !Functions.EXISTS(SetPointValue) || Functions.TYPEOF(LowerBoundValue) == Functions.TYPEOF(SetPointValue);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertyBoundedValue>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertyBoundedValue.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertyBoundedValueClause.SameUnitUpperLower))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyBoundedValue.SameUnitUpperLower",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPropertyBoundedValueClause.SameUnitUpperSet))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyBoundedValue.SameUnitUpperSet",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPropertyBoundedValueClause.SameUnitLowerSet))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyBoundedValue.SameUnitLowerSet",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
