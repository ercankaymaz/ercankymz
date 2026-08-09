using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ConstraintResource;

[ExpressType("IfcObjective", 518)]
public class IfcObjective : IfcConstraint, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcObjective>, IIfcObjective, IIfcConstraint, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IExpressValidatable
{
	public enum IfcObjectiveClause
	{
		WR21
	}

	private IfcMetric _benchmarkValues;

	private IfcMetric _resultValues;

	private IfcObjectiveEnum _objectiveQualifier;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _userDefinedQualifier;

	private Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum? _logicalAggregator;

	private IItemSet<IIfcConstraint> _benchmarkValues4;

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public IfcMetric BenchmarkValues
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
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMetric v)
			{
				_benchmarkValues = v;
			}, _benchmarkValues, value, "BenchmarkValues", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 15)]
	public IfcMetric ResultValues
	{
		get
		{
			if (_activated)
			{
				return _resultValues;
			}
			Activate();
			return _resultValues;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMetric v)
			{
				_resultValues = v;
			}, _resultValues, value, "ResultValues", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 16)]
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? UserDefinedQualifier
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
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
			if (base.CreationTime != null)
			{
				yield return base.CreationTime;
			}
			if (BenchmarkValues != null)
			{
				yield return BenchmarkValues;
			}
			if (ResultValues != null)
			{
				yield return ResultValues;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcObjective), 8)]
	IItemSet<IIfcConstraint> IIfcObjective.BenchmarkValues => _benchmarkValues4 ?? (_benchmarkValues4 = new ExtendedSingleSet<IfcMetric, IIfcConstraint>(() => BenchmarkValues, delegate(IfcMetric v)
	{
		BenchmarkValues = v;
	}, new ItemSet<IIfcConstraint>(this, 0, -8), (IfcMetric s) => s, (IIfcConstraint t) => t as IfcMetric));

	[CrossSchemaAttribute(typeof(IIfcObjective), 9)]
	Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum? IIfcObjective.LogicalAggregator
	{
		get
		{
			return _logicalAggregator;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum? v)
			{
				_logicalAggregator = v;
			}, _logicalAggregator, value, "LogicalAggregator", -9);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcObjective), 10)]
	Xbim.Ifc4.Interfaces.IfcObjectiveEnum IIfcObjective.ObjectiveQualifier
	{
		get
		{
			switch (ObjectiveQualifier)
			{
			case IfcObjectiveEnum.CODECOMPLIANCE:
				return Xbim.Ifc4.Interfaces.IfcObjectiveEnum.CODECOMPLIANCE;
			case IfcObjectiveEnum.DESIGNINTENT:
				return Xbim.Ifc4.Interfaces.IfcObjectiveEnum.DESIGNINTENT;
			case IfcObjectiveEnum.HEALTHANDSAFETY:
				return Xbim.Ifc4.Interfaces.IfcObjectiveEnum.HEALTHANDSAFETY;
			case IfcObjectiveEnum.REQUIREMENT:
				return Xbim.Ifc4.Interfaces.IfcObjectiveEnum.REQUIREMENT;
			case IfcObjectiveEnum.SPECIFICATION:
				return Xbim.Ifc4.Interfaces.IfcObjectiveEnum.SPECIFICATION;
			case IfcObjectiveEnum.TRIGGERCONDITION:
				return Xbim.Ifc4.Interfaces.IfcObjectiveEnum.TRIGGERCONDITION;
			case IfcObjectiveEnum.USERDEFINED:
				if (UserDefinedQualifier.HasValue)
				{
					switch (UserDefinedQualifier.Value)
					{
					case "CODEWAIVER":
					case "EXTERNAL":
					case "MERGECONFLICT":
					case "MODELVIEW":
					case "PARAMETER":
						return (Xbim.Ifc4.Interfaces.IfcObjectiveEnum)Enum.Parse(typeof(Xbim.Ifc4.Interfaces.IfcObjectiveEnum), UserDefinedQualifier.Value);
					}
				}
				return Xbim.Ifc4.Interfaces.IfcObjectiveEnum.USERDEFINED;
			case IfcObjectiveEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcObjectiveEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.CODECOMPLIANCE:
				ObjectiveQualifier = IfcObjectiveEnum.CODECOMPLIANCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.CODEWAIVER:
				UserDefinedQualifier = "CODEWAIVER";
				ObjectiveQualifier = IfcObjectiveEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.DESIGNINTENT:
				ObjectiveQualifier = IfcObjectiveEnum.DESIGNINTENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.EXTERNAL:
				UserDefinedQualifier = "EXTERNAL";
				ObjectiveQualifier = IfcObjectiveEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.HEALTHANDSAFETY:
				ObjectiveQualifier = IfcObjectiveEnum.HEALTHANDSAFETY;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.MERGECONFLICT:
				UserDefinedQualifier = value.ToString();
				ObjectiveQualifier = IfcObjectiveEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.MODELVIEW:
				UserDefinedQualifier = value.ToString();
				ObjectiveQualifier = IfcObjectiveEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.PARAMETER:
				UserDefinedQualifier = value.ToString();
				ObjectiveQualifier = IfcObjectiveEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.REQUIREMENT:
				ObjectiveQualifier = IfcObjectiveEnum.REQUIREMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.SPECIFICATION:
				ObjectiveQualifier = IfcObjectiveEnum.SPECIFICATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.TRIGGERCONDITION:
				ObjectiveQualifier = IfcObjectiveEnum.TRIGGERCONDITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.USERDEFINED:
				ObjectiveQualifier = IfcObjectiveEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.NOTDEFINED:
				ObjectiveQualifier = IfcObjectiveEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcObjective), 11)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcObjective.UserDefinedQualifier
	{
		get
		{
			if (!UserDefinedQualifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedQualifier.Value);
		}
		set
		{
			UserDefinedQualifier = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	internal IfcObjective(IModel model, int label, bool activated)
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
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_benchmarkValues = (IfcMetric)value.EntityVal;
			break;
		case 8:
			_resultValues = (IfcMetric)value.EntityVal;
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
