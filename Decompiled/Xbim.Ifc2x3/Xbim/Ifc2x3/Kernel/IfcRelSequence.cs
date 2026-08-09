using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Interfaces.Conversions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelSequence", 490)]
public class IfcRelSequence : IfcRelConnects, IIfcRelSequence, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSequence>, IExpressValidatable
{
	public enum IfcRelSequenceClause
	{
		WR1
	}

	private Xbim.Ifc4.MeasureResource.IfcLabel? _userDefinedSequenceType;

	private Xbim.Ifc4.Interfaces.IfcSequenceEnum? _sequenceType4;

	private IfcProcess _relatingProcess;

	private IfcProcess _relatedProcess;

	private Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure _timeLag;

	private IfcSequenceEnum _sequenceType;

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 5)]
	IIfcProcess IIfcRelSequence.RelatingProcess
	{
		get
		{
			return RelatingProcess;
		}
		set
		{
			RelatingProcess = value as IfcProcess;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 6)]
	IIfcProcess IIfcRelSequence.RelatedProcess
	{
		get
		{
			return RelatedProcess;
		}
		set
		{
			RelatedProcess = value as IfcProcess;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 7)]
	IIfcLagTime IIfcRelSequence.TimeLag
	{
		get
		{
			return new IfcLagTimeTransient(TimeLag.ToISODateTimeString());
		}
		set
		{
			throw new PlatformNotSupportedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 8)]
	Xbim.Ifc4.Interfaces.IfcSequenceEnum? IIfcRelSequence.SequenceType
	{
		get
		{
			if (_sequenceType4.HasValue)
			{
				return _sequenceType4;
			}
			return SequenceType switch
			{
				IfcSequenceEnum.START_START => Xbim.Ifc4.Interfaces.IfcSequenceEnum.START_START, 
				IfcSequenceEnum.START_FINISH => Xbim.Ifc4.Interfaces.IfcSequenceEnum.START_FINISH, 
				IfcSequenceEnum.FINISH_START => Xbim.Ifc4.Interfaces.IfcSequenceEnum.FINISH_START, 
				IfcSequenceEnum.FINISH_FINISH => Xbim.Ifc4.Interfaces.IfcSequenceEnum.FINISH_FINISH, 
				IfcSequenceEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSequenceEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			if (_sequenceType4.HasValue && value != Xbim.Ifc4.Interfaces.IfcSequenceEnum.USERDEFINED)
			{
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcSequenceEnum? v)
				{
					_sequenceType4 = v;
				}, _sequenceType4, null, "SequenceType", -8);
			}
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.START_START:
				SequenceType = IfcSequenceEnum.START_START;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.START_FINISH:
				SequenceType = IfcSequenceEnum.START_FINISH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.FINISH_START:
				SequenceType = IfcSequenceEnum.FINISH_START;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.FINISH_FINISH:
				SequenceType = IfcSequenceEnum.FINISH_FINISH;
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.USERDEFINED:
				SequenceType = IfcSequenceEnum.NOTDEFINED;
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcSequenceEnum? v)
				{
					_sequenceType4 = v;
				}, _sequenceType4, value, "SequenceType", -8);
				break;
			case Xbim.Ifc4.Interfaces.IfcSequenceEnum.NOTDEFINED:
				SequenceType = IfcSequenceEnum.NOTDEFINED;
				break;
			case null:
				SequenceType = IfcSequenceEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelSequence), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRelSequence.UserDefinedSequenceType
	{
		get
		{
			return _userDefinedSequenceType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_userDefinedSequenceType = v;
			}, _userDefinedSequenceType, value, "UserDefinedSequenceType", -9);
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcProcess RelatingProcess
	{
		get
		{
			if (_activated)
			{
				return _relatingProcess;
			}
			Activate();
			return _relatingProcess;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProcess v)
			{
				_relatingProcess = v;
			}, _relatingProcess, value, "RelatingProcess", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcProcess RelatedProcess
	{
		get
		{
			if (_activated)
			{
				return _relatedProcess;
			}
			Activate();
			return _relatedProcess;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProcess v)
			{
				_relatedProcess = v;
			}, _relatedProcess, value, "RelatedProcess", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure TimeLag
	{
		get
		{
			if (_activated)
			{
				return _timeLag;
			}
			Activate();
			return _timeLag;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure v)
			{
				_timeLag = v;
			}, _timeLag, value, "TimeLag", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 8)]
	public IfcSequenceEnum SequenceType
	{
		get
		{
			if (_activated)
			{
				return _sequenceType;
			}
			Activate();
			return _sequenceType;
		}
		set
		{
			SetValue(delegate(IfcSequenceEnum v)
			{
				_sequenceType = v;
			}, _sequenceType, value, "SequenceType", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (RelatingProcess != null)
			{
				yield return RelatingProcess;
			}
			if (RelatedProcess != null)
			{
				yield return RelatedProcess;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingProcess != null)
			{
				yield return RelatingProcess;
			}
			if (RelatedProcess != null)
			{
				yield return RelatedProcess;
			}
		}
	}

	internal IfcRelSequence(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatingProcess = (IfcProcess)value.EntityVal;
			break;
		case 5:
			_relatedProcess = (IfcProcess)value.EntityVal;
			break;
		case 6:
			_timeLag = value.RealVal;
			break;
		case 7:
			_sequenceType = (IfcSequenceEnum)Enum.Parse(typeof(IfcSequenceEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelSequence other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelSequenceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelSequenceClause.WR1)
			{
				result = (object)RelatingProcess != RelatedProcess;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelSequence>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelSequence.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelSequenceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelSequence.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
