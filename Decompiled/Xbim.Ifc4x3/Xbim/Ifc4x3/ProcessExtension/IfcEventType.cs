using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcEventType", 1170)]
public class IfcEventType : Xbim.Ifc4x3.Kernel.IfcTypeProcess, IIfcEventType, IIfcTypeProcess, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProcessSelect, IIfcProcessSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcEventType>
{
	private IfcEventTypeEnum _predefinedType;

	private IfcEventTriggerTypeEnum _eventTriggerType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedEventTriggerType;

	[CrossSchemaAttribute(typeof(IIfcEventType), 10)]
	Xbim.Ifc4.Interfaces.IfcEventTypeEnum IIfcEventType.PredefinedType
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEventType), 11)]
	Xbim.Ifc4.Interfaces.IfcEventTriggerTypeEnum IIfcEventType.EventTriggerType
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEventType), 12)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcEventType.UserDefinedEventTriggerType
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

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcEventTypeEnum PredefinedType
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
			SetValue(delegate(IfcEventTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcEventTriggerTypeEnum EventTriggerType
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
			SetValue(delegate(IfcEventTriggerTypeEnum v)
			{
				_eventTriggerType = v;
			}, _eventTriggerType, value, "EventTriggerType", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
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
			}, _userDefinedEventTriggerType, value, "UserDefinedEventTriggerType", 12);
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcEventType(IModel model, int label, bool activated)
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
		case 7:
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcEventTypeEnum)Enum.Parse(typeof(IfcEventTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_eventTriggerType = (IfcEventTriggerTypeEnum)Enum.Parse(typeof(IfcEventTriggerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_userDefinedEventTriggerType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEventType other)
	{
		return this == other;
	}
}
