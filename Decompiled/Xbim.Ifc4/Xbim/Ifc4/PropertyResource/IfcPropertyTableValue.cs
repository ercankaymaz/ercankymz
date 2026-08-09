using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PropertyResource;

[ExpressType("IfcPropertyTableValue", 557)]
public class IfcPropertyTableValue : IfcSimpleProperty, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertyTableValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPropertyTableValue>, IExpressValidatable
{
	public enum IfcPropertyTableValueClause
	{
		WR21,
		WR22,
		WR23
	}

	private readonly OptionalItemSet<IfcValue> _definingValues;

	private readonly OptionalItemSet<IfcValue> _definedValues;

	private IfcText? _expression;

	private IfcUnit _definingUnit;

	private IfcUnit _definedUnit;

	private IfcCurveInterpolationEnum? _curveInterpolation;

	IItemSet<IIfcValue> IIfcPropertyTableValue.DefiningValues => new ProxyItemSet<IfcValue, IIfcValue>(DefiningValues);

	IItemSet<IIfcValue> IIfcPropertyTableValue.DefinedValues => new ProxyItemSet<IfcValue, IIfcValue>(DefinedValues);

	IfcText? IIfcPropertyTableValue.Expression
	{
		get
		{
			return Expression;
		}
		set
		{
			Expression = value;
		}
	}

	IIfcUnit IIfcPropertyTableValue.DefiningUnit
	{
		get
		{
			return DefiningUnit;
		}
		set
		{
			DefiningUnit = value as IfcUnit;
		}
	}

	IIfcUnit IIfcPropertyTableValue.DefinedUnit
	{
		get
		{
			return DefinedUnit;
		}
		set
		{
			DefinedUnit = value as IfcUnit;
		}
	}

	IfcCurveInterpolationEnum? IIfcPropertyTableValue.CurveInterpolation
	{
		get
		{
			return CurveInterpolation;
		}
		set
		{
			CurveInterpolation = value;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcValue> DefiningValues
	{
		get
		{
			if (_activated)
			{
				return _definingValues;
			}
			Activate();
			return _definingValues;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 11)]
	public IOptionalItemSet<IfcValue> DefinedValues
	{
		get
		{
			if (_activated)
			{
				return _definedValues;
			}
			Activate();
			return _definedValues;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcText? Expression
	{
		get
		{
			if (_activated)
			{
				return _expression;
			}
			Activate();
			return _expression;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_expression = v;
			}, _expression, value, "Expression", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcUnit DefiningUnit
	{
		get
		{
			if (_activated)
			{
				return _definingUnit;
			}
			Activate();
			return _definingUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_definingUnit = v;
			}, _definingUnit, value, "DefiningUnit", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public IfcUnit DefinedUnit
	{
		get
		{
			if (_activated)
			{
				return _definedUnit;
			}
			Activate();
			return _definedUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_definedUnit = v;
			}, _definedUnit, value, "DefinedUnit", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcCurveInterpolationEnum? CurveInterpolation
	{
		get
		{
			if (_activated)
			{
				return _curveInterpolation;
			}
			Activate();
			return _curveInterpolation;
		}
		set
		{
			SetValue(delegate(IfcCurveInterpolationEnum? v)
			{
				_curveInterpolation = v;
			}, _curveInterpolation, value, "CurveInterpolation", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (DefiningUnit != null)
			{
				yield return DefiningUnit;
			}
			if (DefinedUnit != null)
			{
				yield return DefinedUnit;
			}
		}
	}

	internal IfcPropertyTableValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_definingValues = new OptionalItemSet<IfcValue>(this, 0, 3);
		_definedValues = new OptionalItemSet<IfcValue>(this, 0, 4);
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
			_definingValues.InternalAdd((IfcValue)value.EntityVal);
			break;
		case 3:
			_definedValues.InternalAdd((IfcValue)value.EntityVal);
			break;
		case 4:
			_expression = value.StringVal;
			break;
		case 5:
			_definingUnit = (IfcUnit)value.EntityVal;
			break;
		case 6:
			_definedUnit = (IfcUnit)value.EntityVal;
			break;
		case 7:
			_curveInterpolation = (IfcCurveInterpolationEnum)Enum.Parse(typeof(IfcCurveInterpolationEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyTableValue other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPropertyTableValueClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcPropertyTableValueClause.WR21:
				result = (!Functions.EXISTS(DefiningValues) && !Functions.EXISTS(DefinedValues)) || Functions.SIZEOF(DefiningValues) == Functions.SIZEOF(DefinedValues);
				break;
			case IfcPropertyTableValueClause.WR22:
				result = !Functions.EXISTS(DefiningValues) || Functions.SIZEOF(Enumerable.Where(DefiningValues, (IfcValue temp) => Functions.TYPEOF(temp) != Functions.TYPEOF(DefiningValues.ItemAt(0L)))) == 0;
				break;
			case IfcPropertyTableValueClause.WR23:
				result = !Functions.EXISTS(DefinedValues) || Functions.SIZEOF(Enumerable.Where(DefinedValues, (IfcValue temp) => Functions.TYPEOF(temp) != Functions.TYPEOF(DefinedValues.ItemAt(0L)))) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPropertyTableValue>()?.LogError($"Exception thrown evaluating where-clause 'IfcPropertyTableValue.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPropertyTableValueClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyTableValue.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPropertyTableValueClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyTableValue.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcPropertyTableValueClause.WR23))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPropertyTableValue.WR23",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
