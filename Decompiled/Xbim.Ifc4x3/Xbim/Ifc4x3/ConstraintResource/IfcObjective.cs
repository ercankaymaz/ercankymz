using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ConstraintResource;

[ExpressType("IfcObjective", 518)]
public class IfcObjective : IfcConstraint, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcObjective>, IIfcObjective, IIfcConstraint, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private readonly OptionalItemSet<IfcConstraint> _benchmarkValues;

	private IfcLogicalOperatorEnum? _logicalAggregator;

	private IfcObjectiveEnum _objectiveQualifier;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedQualifier;

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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedQualifier
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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

	[CrossSchemaAttribute(typeof(IIfcObjective), 8)]
	IItemSet<IIfcConstraint> IIfcObjective.BenchmarkValues => new ProxyItemSet<IfcConstraint, IIfcConstraint>(BenchmarkValues);

	[CrossSchemaAttribute(typeof(IIfcObjective), 9)]
	Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum? IIfcObjective.LogicalAggregator
	{
		get
		{
			return LogicalAggregator switch
			{
				IfcLogicalOperatorEnum.LOGICALAND => Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALAND, 
				IfcLogicalOperatorEnum.LOGICALNOTAND => Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALNOTAND, 
				IfcLogicalOperatorEnum.LOGICALNOTOR => Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALNOTOR, 
				IfcLogicalOperatorEnum.LOGICALOR => Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALOR, 
				IfcLogicalOperatorEnum.LOGICALXOR => Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALXOR, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALAND:
				LogicalAggregator = IfcLogicalOperatorEnum.LOGICALAND;
				break;
			case Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALOR:
				LogicalAggregator = IfcLogicalOperatorEnum.LOGICALOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALXOR:
				LogicalAggregator = IfcLogicalOperatorEnum.LOGICALXOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALNOTAND:
				LogicalAggregator = IfcLogicalOperatorEnum.LOGICALNOTAND;
				break;
			case Xbim.Ifc4.Interfaces.IfcLogicalOperatorEnum.LOGICALNOTOR:
				LogicalAggregator = IfcLogicalOperatorEnum.LOGICALNOTOR;
				break;
			case null:
				LogicalAggregator = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcObjective), 10)]
	Xbim.Ifc4.Interfaces.IfcObjectiveEnum IIfcObjective.ObjectiveQualifier
	{
		get
		{
			return ObjectiveQualifier switch
			{
				IfcObjectiveEnum.CODECOMPLIANCE => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.CODECOMPLIANCE, 
				IfcObjectiveEnum.CODEWAIVER => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.CODEWAIVER, 
				IfcObjectiveEnum.DESIGNINTENT => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.DESIGNINTENT, 
				IfcObjectiveEnum.EXTERNAL => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.EXTERNAL, 
				IfcObjectiveEnum.HEALTHANDSAFETY => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.HEALTHANDSAFETY, 
				IfcObjectiveEnum.MERGECONFLICT => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.MERGECONFLICT, 
				IfcObjectiveEnum.MODELVIEW => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.MODELVIEW, 
				IfcObjectiveEnum.PARAMETER => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.PARAMETER, 
				IfcObjectiveEnum.REQUIREMENT => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.REQUIREMENT, 
				IfcObjectiveEnum.SPECIFICATION => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.SPECIFICATION, 
				IfcObjectiveEnum.TRIGGERCONDITION => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.TRIGGERCONDITION, 
				IfcObjectiveEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.USERDEFINED, 
				IfcObjectiveEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcObjectiveEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.CODECOMPLIANCE:
				ObjectiveQualifier = IfcObjectiveEnum.CODECOMPLIANCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.CODEWAIVER:
				ObjectiveQualifier = IfcObjectiveEnum.CODEWAIVER;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.DESIGNINTENT:
				ObjectiveQualifier = IfcObjectiveEnum.DESIGNINTENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.EXTERNAL:
				ObjectiveQualifier = IfcObjectiveEnum.EXTERNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.HEALTHANDSAFETY:
				ObjectiveQualifier = IfcObjectiveEnum.HEALTHANDSAFETY;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.MERGECONFLICT:
				ObjectiveQualifier = IfcObjectiveEnum.MERGECONFLICT;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.MODELVIEW:
				ObjectiveQualifier = IfcObjectiveEnum.MODELVIEW;
				break;
			case Xbim.Ifc4.Interfaces.IfcObjectiveEnum.PARAMETER:
				ObjectiveQualifier = IfcObjectiveEnum.PARAMETER;
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
			UserDefinedQualifier = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
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
}
