using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProcessExtension;

[ExpressType("IfcRelSequence", 490)]
public class IfcRelSequence : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelSequence, IIfcRelConnects, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSequence>, IExpressValidatable
{
	public enum IfcRelSequenceClause
	{
		AvoidInconsistentSequence,
		CorrectSequenceType
	}

	private IfcProcess _relatingProcess;

	private IfcProcess _relatedProcess;

	private IfcLagTime _timeLag;

	private IfcSequenceEnum? _sequenceType;

	private IfcLabel? _userDefinedSequenceType;

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

	IIfcLagTime IIfcRelSequence.TimeLag
	{
		get
		{
			return TimeLag;
		}
		set
		{
			TimeLag = value as IfcLagTime;
		}
	}

	IfcSequenceEnum? IIfcRelSequence.SequenceType
	{
		get
		{
			return SequenceType;
		}
		set
		{
			SequenceType = value;
		}
	}

	IfcLabel? IIfcRelSequence.UserDefinedSequenceType
	{
		get
		{
			return UserDefinedSequenceType;
		}
		set
		{
			UserDefinedSequenceType = value;
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

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcLagTime TimeLag
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcLagTime v)
			{
				_timeLag = v;
			}, _timeLag, value, "TimeLag", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 8)]
	public IfcSequenceEnum? SequenceType
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
			SetValue(delegate(IfcSequenceEnum? v)
			{
				_sequenceType = v;
			}, _sequenceType, value, "SequenceType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLabel? UserDefinedSequenceType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedSequenceType;
			}
			Activate();
			return _userDefinedSequenceType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedSequenceType = v;
			}, _userDefinedSequenceType, value, "UserDefinedSequenceType", 9);
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
			if (TimeLag != null)
			{
				yield return TimeLag;
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
			_timeLag = (IfcLagTime)value.EntityVal;
			break;
		case 7:
			_sequenceType = (IfcSequenceEnum)Enum.Parse(typeof(IfcSequenceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_userDefinedSequenceType = value.StringVal;
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
			switch (clause)
			{
			case IfcRelSequenceClause.AvoidInconsistentSequence:
				result = (object)RelatingProcess != RelatedProcess;
				break;
			case IfcRelSequenceClause.CorrectSequenceType:
				result = SequenceType != IfcSequenceEnum.USERDEFINED || (SequenceType == IfcSequenceEnum.USERDEFINED && Functions.EXISTS(UserDefinedSequenceType));
				break;
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
		if (!ValidateClause(IfcRelSequenceClause.AvoidInconsistentSequence))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelSequence.AvoidInconsistentSequence",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRelSequenceClause.CorrectSequenceType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelSequence.CorrectSequenceType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
