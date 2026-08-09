using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.UtilityResource;

[ExpressType("IfcOwnerHistory", 519)]
public class IfcOwnerHistory : PersistEntity, IIfcOwnerHistory, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcOwnerHistory>
{
	private Xbim.Ifc4.Interfaces.IfcChangeActionEnum? _changeAction4;

	private IfcPersonAndOrganization _owningUser;

	private IfcApplication _owningApplication;

	private IfcStateEnum? _state;

	private IfcChangeActionEnum _changeAction;

	private Xbim.Ifc2x3.MeasureResource.IfcTimeStamp? _lastModifiedDate;

	private IfcPersonAndOrganization _lastModifyingUser;

	private IfcApplication _lastModifyingApplication;

	private Xbim.Ifc2x3.MeasureResource.IfcTimeStamp _creationDate;

	[CrossSchemaAttribute(typeof(IIfcOwnerHistory), 1)]
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

	[CrossSchemaAttribute(typeof(IIfcOwnerHistory), 2)]
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

	[CrossSchemaAttribute(typeof(IIfcOwnerHistory), 3)]
	Xbim.Ifc4.Interfaces.IfcStateEnum? IIfcOwnerHistory.State
	{
		get
		{
			return State switch
			{
				IfcStateEnum.READWRITE => Xbim.Ifc4.Interfaces.IfcStateEnum.READWRITE, 
				IfcStateEnum.READONLY => Xbim.Ifc4.Interfaces.IfcStateEnum.READONLY, 
				IfcStateEnum.LOCKED => Xbim.Ifc4.Interfaces.IfcStateEnum.LOCKED, 
				IfcStateEnum.READWRITELOCKED => Xbim.Ifc4.Interfaces.IfcStateEnum.READWRITELOCKED, 
				IfcStateEnum.READONLYLOCKED => Xbim.Ifc4.Interfaces.IfcStateEnum.READONLYLOCKED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStateEnum.READWRITE:
				State = IfcStateEnum.READWRITE;
				break;
			case Xbim.Ifc4.Interfaces.IfcStateEnum.READONLY:
				State = IfcStateEnum.READONLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcStateEnum.LOCKED:
				State = IfcStateEnum.LOCKED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStateEnum.READWRITELOCKED:
				State = IfcStateEnum.READWRITELOCKED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStateEnum.READONLYLOCKED:
				State = IfcStateEnum.READONLYLOCKED;
				break;
			case null:
				State = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOwnerHistory), 4)]
	Xbim.Ifc4.Interfaces.IfcChangeActionEnum? IIfcOwnerHistory.ChangeAction
	{
		get
		{
			if (_changeAction4.HasValue)
			{
				return _changeAction4;
			}
			return ChangeAction switch
			{
				IfcChangeActionEnum.NOCHANGE => Xbim.Ifc4.Interfaces.IfcChangeActionEnum.NOCHANGE, 
				IfcChangeActionEnum.MODIFIED => Xbim.Ifc4.Interfaces.IfcChangeActionEnum.MODIFIED, 
				IfcChangeActionEnum.ADDED => Xbim.Ifc4.Interfaces.IfcChangeActionEnum.ADDED, 
				IfcChangeActionEnum.DELETED => Xbim.Ifc4.Interfaces.IfcChangeActionEnum.DELETED, 
				IfcChangeActionEnum.MODIFIEDADDED => Xbim.Ifc4.Interfaces.IfcChangeActionEnum.ADDED, 
				IfcChangeActionEnum.MODIFIEDDELETED => Xbim.Ifc4.Interfaces.IfcChangeActionEnum.DELETED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			if (_changeAction4.HasValue && _changeAction4.Value != Xbim.Ifc4.Interfaces.IfcChangeActionEnum.NOTDEFINED)
			{
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcChangeActionEnum? v)
				{
					_changeAction4 = v;
				}, _changeAction4, null, "ChangeAction", -4);
			}
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcChangeActionEnum.NOCHANGE:
				ChangeAction = IfcChangeActionEnum.NOCHANGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcChangeActionEnum.MODIFIED:
				ChangeAction = IfcChangeActionEnum.MODIFIED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChangeActionEnum.ADDED:
				ChangeAction = IfcChangeActionEnum.ADDED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChangeActionEnum.DELETED:
				ChangeAction = IfcChangeActionEnum.DELETED;
				break;
			case Xbim.Ifc4.Interfaces.IfcChangeActionEnum.NOTDEFINED:
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcChangeActionEnum? v)
				{
					_changeAction4 = v;
				}, _changeAction4, value, "ChangeAction", -4);
				break;
			case null:
				ChangeAction = IfcChangeActionEnum.NOCHANGE;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOwnerHistory), 5)]
	Xbim.Ifc4.DateTimeResource.IfcTimeStamp? IIfcOwnerHistory.LastModifiedDate
	{
		get
		{
			if (!LastModifiedDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp(LastModifiedDate.Value);
		}
		set
		{
			LastModifiedDate = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcTimeStamp?(new Xbim.Ifc2x3.MeasureResource.IfcTimeStamp(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcTimeStamp?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOwnerHistory), 6)]
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

	[CrossSchemaAttribute(typeof(IIfcOwnerHistory), 7)]
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

	[CrossSchemaAttribute(typeof(IIfcOwnerHistory), 8)]
	Xbim.Ifc4.DateTimeResource.IfcTimeStamp IIfcOwnerHistory.CreationDate
	{
		get
		{
			return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp(CreationDate);
		}
		set
		{
			CreationDate = new Xbim.Ifc2x3.MeasureResource.IfcTimeStamp(value);
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

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 4)]
	public IfcChangeActionEnum ChangeAction
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
			SetValue(delegate(IfcChangeActionEnum v)
			{
				_changeAction = v;
			}, _changeAction, value, "ChangeAction", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcTimeStamp? LastModifiedDate
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTimeStamp? v)
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
	public Xbim.Ifc2x3.MeasureResource.IfcTimeStamp CreationDate
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTimeStamp v)
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
}
