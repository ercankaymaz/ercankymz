using System;
using System.Collections.Generic;
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

namespace Xbim.Ifc4.ConstraintResource;

[ExpressType("IfcObjective", 518)]
public class IfcObjective : IfcConstraint, IInstantiableEntity, IPersistEntity, IPersist, IIfcObjective, IIfcConstraint, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcObjective>, IExpressValidatable
{
	public enum IfcObjectiveClause
	{
		WR21
	}

	private readonly OptionalItemSet<IfcConstraint> _benchmarkValues;

	private IfcLogicalOperatorEnum? _logicalAggregator;

	private IfcObjectiveEnum _objectiveQualifier;

	private IfcLabel? _userDefinedQualifier;

	IItemSet<IIfcConstraint> IIfcObjective.BenchmarkValues => new ProxyItemSet<IfcConstraint, IIfcConstraint>(BenchmarkValues);

	IfcLogicalOperatorEnum? IIfcObjective.LogicalAggregator
	{
		get
		{
			return LogicalAggregator;
		}
		set
		{
			LogicalAggregator = value;
		}
	}

	IfcObjectiveEnum IIfcObjective.ObjectiveQualifier
	{
		get
		{
			return ObjectiveQualifier;
		}
		set
		{
			ObjectiveQualifier = value;
		}
	}

	IfcLabel? IIfcObjective.UserDefinedQualifier
	{
		get
		{
			return UserDefinedQualifier;
		}
		set
		{
			UserDefinedQualifier = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcConstraint> BenchmarkValues
	{
		get
		{
			if (_activated)
			{
				return _benchmarkValues;
			}
			Activate();
			return _benchmarkValues;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 11)]
	public IfcLogicalOperatorEnum? LogicalAggregator
	{
		get
		{
			if (_activated)
			{
				return _logicalAggregator;
			}
			Activate();
			return _logicalAggregator;
		}
		set
		{
			SetValue(delegate(IfcLogicalOperatorEnum? v)
			{
				_logicalAggregator = v;
			}, _logicalAggregator, value, "LogicalAggregator", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 12)]
	public IfcObjectiveEnum ObjectiveQualifier
	{
		get
		{
			if (_activated)
			{
				return _objectiveQualifier;
			}
			Activate();
			return _objectiveQualifier;
		}
		set
		{
			SetValue(delegate(IfcObjectiveEnum v)
			{
				_objectiveQualifier = v;
			}, _objectiveQualifier, value, "ObjectiveQualifier", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcLabel? UserDefinedQualifier
	{
		get
		{
			if (_activated)
			{
				return _userDefinedQualifier;
			}
			Activate();
			return _userDefinedQualifier;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedQualifier = v;
			}, _userDefinedQualifier, value, "UserDefinedQualifier", 11);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.CreatingActor != null)
			{
				yield return base.CreatingActor;
			}
			foreach (IfcConstraint benchmarkValue in BenchmarkValues)
			{
				yield return benchmarkValue;
			}
		}
	}

	internal IfcObjective(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_benchmarkValues = new OptionalItemSet<IfcConstraint>(this, 0, 8);
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
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_benchmarkValues.InternalAdd((IfcConstraint)value.EntityVal);
			break;
		case 8:
			_logicalAggregator = (IfcLogicalOperatorEnum)Enum.Parse(typeof(IfcLogicalOperatorEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_objectiveQualifier = (IfcObjectiveEnum)Enum.Parse(typeof(IfcObjectiveEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_userDefinedQualifier = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcObjective other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcObjectiveClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcObjectiveClause.WR21)
			{
				result = ObjectiveQualifier != IfcObjectiveEnum.USERDEFINED || (ObjectiveQualifier == IfcObjectiveEnum.USERDEFINED && Functions.EXISTS(UserDefinedQualifier));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcObjective>()?.LogError($"Exception thrown evaluating where-clause 'IfcObjective.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcObjectiveClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcObjective.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
