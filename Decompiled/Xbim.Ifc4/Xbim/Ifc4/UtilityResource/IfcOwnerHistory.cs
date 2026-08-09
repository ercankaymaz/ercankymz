using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.UtilityResource;

[ExpressType("IfcOwnerHistory", 519)]
public class IfcOwnerHistory : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcOwnerHistory, IContainsEntityReferences, IEquatable<IfcOwnerHistory>, IExpressValidatable
{
	public enum IfcOwnerHistoryClause
	{
		CorrectChangeAction
	}

	private IfcPersonAndOrganization _owningUser;

	private IfcApplication _owningApplication;

	private IfcStateEnum? _state;

	private IfcChangeActionEnum? _changeAction;

	private IfcTimeStamp? _lastModifiedDate;

	private IfcPersonAndOrganization _lastModifyingUser;

	private IfcApplication _lastModifyingApplication;

	private IfcTimeStamp _creationDate;

	IIfcPersonAndOrganization IIfcOwnerHistory.OwningUser
	{
		get
		{
			return OwningUser;
		}
		set
		{
			OwningUser = value as IfcPersonAndOrganization;
		}
	}

	IIfcApplication IIfcOwnerHistory.OwningApplication
	{
		get
		{
			return OwningApplication;
		}
		set
		{
			OwningApplication = value as IfcApplication;
		}
	}

	IfcStateEnum? IIfcOwnerHistory.State
	{
		get
		{
			return State;
		}
		set
		{
			State = value;
		}
	}

	IfcChangeActionEnum? IIfcOwnerHistory.ChangeAction
	{
		get
		{
			return ChangeAction;
		}
		set
		{
			ChangeAction = value;
		}
	}

	IfcTimeStamp? IIfcOwnerHistory.LastModifiedDate
	{
		get
		{
			return LastModifiedDate;
		}
		set
		{
			LastModifiedDate = value;
		}
	}

	IIfcPersonAndOrganization IIfcOwnerHistory.LastModifyingUser
	{
		get
		{
			return LastModifyingUser;
		}
		set
		{
			LastModifyingUser = value as IfcPersonAndOrganization;
		}
	}

	IIfcApplication IIfcOwnerHistory.LastModifyingApplication
	{
		get
		{
			return LastModifyingApplication;
		}
		set
		{
			LastModifyingApplication = value as IfcApplication;
		}
	}

	IfcTimeStamp IIfcOwnerHistory.CreationDate
	{
		get
		{
			return CreationDate;
		}
		set
		{
			CreationDate = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcPersonAndOrganization OwningUser
	{
		get
		{
			if (_activated)
			{
				return _owningUser;
			}
			Activate();
			return _owningUser;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPersonAndOrganization v)
			{
				_owningUser = v;
			}, _owningUser, value, "OwningUser", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcApplication OwningApplication
	{
		get
		{
			if (_activated)
			{
				return _owningApplication;
			}
			Activate();
			return _owningApplication;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcApplication v)
			{
				_owningApplication = v;
			}, _owningApplication, value, "OwningApplication", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcStateEnum? State
	{
		get
		{
			if (_activated)
			{
				return _state;
			}
			Activate();
			return _state;
		}
		set
		{
			SetValue(delegate(IfcStateEnum? v)
			{
				_state = v;
			}, _state, value, "State", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 4)]
	public IfcChangeActionEnum? ChangeAction
	{
		get
		{
			if (_activated)
			{
				return _changeAction;
			}
			Activate();
			return _changeAction;
		}
		set
		{
			SetValue(delegate(IfcChangeActionEnum? v)
			{
				_changeAction = v;
			}, _changeAction, value, "ChangeAction", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcTimeStamp? LastModifiedDate
	{
		get
		{
			if (_activated)
			{
				return _lastModifiedDate;
			}
			Activate();
			return _lastModifiedDate;
		}
		set
		{
			SetValue(delegate(IfcTimeStamp? v)
			{
				_lastModifiedDate = v;
			}, _lastModifiedDate, value, "LastModifiedDate", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcPersonAndOrganization LastModifyingUser
	{
		get
		{
			if (_activated)
			{
				return _lastModifyingUser;
			}
			Activate();
			return _lastModifyingUser;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPersonAndOrganization v)
			{
				_lastModifyingUser = v;
			}, _lastModifyingUser, value, "LastModifyingUser", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcApplication LastModifyingApplication
	{
		get
		{
			if (_activated)
			{
				return _lastModifyingApplication;
			}
			Activate();
			return _lastModifyingApplication;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcApplication v)
			{
				_lastModifyingApplication = v;
			}, _lastModifyingApplication, value, "LastModifyingApplication", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcTimeStamp CreationDate
	{
		get
		{
			if (_activated)
			{
				return _creationDate;
			}
			Activate();
			return _creationDate;
		}
		set
		{
			SetValue(delegate(IfcTimeStamp v)
			{
				_creationDate = v;
			}, _creationDate, value, "CreationDate", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (OwningUser != null)
			{
				yield return OwningUser;
			}
			if (OwningApplication != null)
			{
				yield return OwningApplication;
			}
			if (LastModifyingUser != null)
			{
				yield return LastModifyingUser;
			}
			if (LastModifyingApplication != null)
			{
				yield return LastModifyingApplication;
			}
		}
	}

	internal IfcOwnerHistory(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_owningUser = (IfcPersonAndOrganization)value.EntityVal;
			break;
		case 1:
			_owningApplication = (IfcApplication)value.EntityVal;
			break;
		case 2:
			_state = (IfcStateEnum)Enum.Parse(typeof(IfcStateEnum), value.EnumVal, ignoreCase: true);
			break;
		case 3:
			_changeAction = (IfcChangeActionEnum)Enum.Parse(typeof(IfcChangeActionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 4:
			_lastModifiedDate = value.IntegerVal;
			break;
		case 5:
			_lastModifyingUser = (IfcPersonAndOrganization)value.EntityVal;
			break;
		case 6:
			_lastModifyingApplication = (IfcApplication)value.EntityVal;
			break;
		case 7:
			_creationDate = value.IntegerVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOwnerHistory other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcOwnerHistoryClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcOwnerHistoryClause.CorrectChangeAction)
			{
				result = Functions.EXISTS(LastModifiedDate) || (!Functions.EXISTS(LastModifiedDate) && !Functions.EXISTS(ChangeAction)) || (!Functions.EXISTS(LastModifiedDate) && Functions.EXISTS(ChangeAction) && (ChangeAction == IfcChangeActionEnum.NOTDEFINED || ChangeAction == IfcChangeActionEnum.NOCHANGE));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcOwnerHistory>()?.LogError($"Exception thrown evaluating where-clause 'IfcOwnerHistory.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcOwnerHistoryClause.CorrectChangeAction))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcOwnerHistory.CorrectChangeAction",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
