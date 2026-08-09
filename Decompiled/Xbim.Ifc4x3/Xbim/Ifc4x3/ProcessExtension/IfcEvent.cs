using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcEvent", 1168)]
public class IfcEvent : Xbim.Ifc4x3.Kernel.IfcProcess, IIfcEvent, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProcessSelect, IIfcProcessSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcEvent>
{
	private IfcEventTypeEnum? _predefinedType;

	private IfcEventTriggerTypeEnum? _eventTriggerType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedEventTriggerType;

	private IfcEventTime _eventOccurenceTime;

	[CrossSchemaAttribute(typeof(IIfcEvent), 8)]
	Xbim.Ifc4.Interfaces.IfcEventTypeEnum? IIfcEvent.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcEventTypeEnum.ENDEVENT => Xbim.Ifc4.Interfaces.IfcEventTypeEnum.ENDEVENT, 
				IfcEventTypeEnum.INTERMEDIATEEVENT => Xbim.Ifc4.Interfaces.IfcEventTypeEnum.INTERMEDIATEEVENT, 
				IfcEventTypeEnum.STARTEVENT => Xbim.Ifc4.Interfaces.IfcEventTypeEnum.STARTEVENT, 
				IfcEventTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcEventTypeEnum.USERDEFINED, 
				IfcEventTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcEventTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcEventTypeEnum.STARTEVENT:
				PredefinedType = IfcEventTypeEnum.STARTEVENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTypeEnum.ENDEVENT:
				PredefinedType = IfcEventTypeEnum.ENDEVENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTypeEnum.INTERMEDIATEEVENT:
				PredefinedType = IfcEventTypeEnum.INTERMEDIATEEVENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTypeEnum.USERDEFINED:
				PredefinedType = IfcEventTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTypeEnum.NOTDEFINED:
				PredefinedType = IfcEventTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEvent), 9)]
	Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum? IIfcEvent.EventTriggerType
	{
		get
		{
			return EventTriggerType switch
			{
				IfcEventTriggerTypeEnum.EVENTCOMPLEX => Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.EVENTCOMPLEX, 
				IfcEventTriggerTypeEnum.EVENTMESSAGE => Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.EVENTMESSAGE, 
				IfcEventTriggerTypeEnum.EVENTRULE => Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.EVENTRULE, 
				IfcEventTriggerTypeEnum.EVENTTIME => Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.EVENTTIME, 
				IfcEventTriggerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.USERDEFINED, 
				IfcEventTriggerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.EVENTRULE:
				EventTriggerType = IfcEventTriggerTypeEnum.EVENTRULE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.EVENTMESSAGE:
				EventTriggerType = IfcEventTriggerTypeEnum.EVENTMESSAGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.EVENTTIME:
				EventTriggerType = IfcEventTriggerTypeEnum.EVENTTIME;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.EVENTCOMPLEX:
				EventTriggerType = IfcEventTriggerTypeEnum.EVENTCOMPLEX;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.USERDEFINED:
				EventTriggerType = IfcEventTriggerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum.NOTDEFINED:
				EventTriggerType = IfcEventTriggerTypeEnum.NOTDEFINED;
				break;
			case null:
				EventTriggerType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEvent), 10)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcEvent.UserDefinedEventTriggerType
	{
		get
		{
			if (!UserDefinedEventTriggerType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedEventTriggerType.Value);
		}
		set
		{
			UserDefinedEventTriggerType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEvent), 11)]
	IIfcEventTime IIfcEvent.EventOccurenceTime
	{
		get
		{
			return EventOccurenceTime;
		}
		set
		{
			EventOccurenceTime = value as IfcEventTime;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 22)]
	public IfcEventTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcEventTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcEventTriggerTypeEnum? EventTriggerType
	{
		get
		{
			if (_activated)
			{
				return _eventTriggerType;
			}
			Activate();
			return _eventTriggerType;
		}
		set
		{
			SetValue(delegate(IfcEventTriggerTypeEnum? v)
			{
				_eventTriggerType = v;
			}, _eventTriggerType, value, "EventTriggerType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedEventTriggerType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedEventTriggerType;
			}
			Activate();
			return _userDefinedEventTriggerType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedEventTriggerType = v;
			}, _userDefinedEventTriggerType, value, "UserDefinedEventTriggerType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 25)]
	public IfcEventTime EventOccurenceTime
	{
		get
		{
			if (_activated)
			{
				return _eventOccurenceTime;
			}
			Activate();
			return _eventOccurenceTime;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcEventTime v)
			{
				_eventOccurenceTime = v;
			}, _eventOccurenceTime, value, "EventOccurenceTime", 11);
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
			if (EventOccurenceTime != null)
			{
				yield return EventOccurenceTime;
			}
		}
	}

	internal IfcEvent(IModel model, int label, bool activated)
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
			_predefinedType = (IfcEventTypeEnum)Enum.Parse(typeof(IfcEventTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_eventTriggerType = (IfcEventTriggerTypeEnum)Enum.Parse(typeof(IfcEventTriggerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_userDefinedEventTriggerType = value.StringVal;
			break;
		case 10:
			_eventOccurenceTime = (IfcEventTime)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEvent other)
	{
		return this == other;
	}
}
