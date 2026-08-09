using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcWorkCalendar", 1318)]
public class IfcWorkCalendar : Xbim.Ifc4x3.Kernel.IfcControl, IIfcWorkCalendar, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcWorkCalendar>
{
	private readonly OptionalItemSet<IfcWorkTime> _workingTimes;

	private readonly OptionalItemSet<IfcWorkTime> _exceptionTimes;

	private IfcWorkCalendarTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWorkCalendar), 7)]
	IItemSet<IIfcWorkTime> IIfcWorkCalendar.WorkingTimes => new ProxyItemSet<IfcWorkTime, IIfcWorkTime>(WorkingTimes);

	[CrossSchemaAttribute(typeof(IIfcWorkCalendar), 8)]
	IItemSet<IIfcWorkTime> IIfcWorkCalendar.ExceptionTimes => new ProxyItemSet<IfcWorkTime, IIfcWorkTime>(ExceptionTimes);

	[CrossSchemaAttribute(typeof(IIfcWorkCalendar), 9)]
	Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum? IIfcWorkCalendar.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcWorkCalendarTypeEnum.FIRSTSHIFT => Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.FIRSTSHIFT, 
				IfcWorkCalendarTypeEnum.SECONDSHIFT => Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.SECONDSHIFT, 
				IfcWorkCalendarTypeEnum.THIRDSHIFT => Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.THIRDSHIFT, 
				IfcWorkCalendarTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.USERDEFINED, 
				IfcWorkCalendarTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.FIRSTSHIFT:
				PredefinedType = IfcWorkCalendarTypeEnum.FIRSTSHIFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.SECONDSHIFT:
				PredefinedType = IfcWorkCalendarTypeEnum.SECONDSHIFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.THIRDSHIFT:
				PredefinedType = IfcWorkCalendarTypeEnum.THIRDSHIFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.USERDEFINED:
				PredefinedType = IfcWorkCalendarTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkCalendarTypeEnum.NOTDEFINED:
				PredefinedType = IfcWorkCalendarTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 19)]
	public IOptionalItemSet<IfcWorkTime> WorkingTimes
	{
		get
		{
			if (_activated)
			{
				return _workingTimes;
			}
			Activate();
			return _workingTimes;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 20)]
	public IOptionalItemSet<IfcWorkTime> ExceptionTimes
	{
		get
		{
			if (_activated)
			{
				return _exceptionTimes;
			}
			Activate();
			return _exceptionTimes;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcWorkCalendarTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWorkCalendarTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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
			foreach (IfcWorkTime workingTime in WorkingTimes)
			{
				yield return workingTime;
			}
			foreach (IfcWorkTime exceptionTime in ExceptionTimes)
			{
				yield return exceptionTime;
			}
		}
	}

	internal IfcWorkCalendar(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_workingTimes = new OptionalItemSet<IfcWorkTime>(this, 0, 7);
		_exceptionTimes = new OptionalItemSet<IfcWorkTime>(this, 0, 8);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_workingTimes.InternalAdd((IfcWorkTime)value.EntityVal);
			break;
		case 7:
			_exceptionTimes.InternalAdd((IfcWorkTime)value.EntityVal);
			break;
		case 8:
			_predefinedType = (IfcWorkCalendarTypeEnum)Enum.Parse(typeof(IfcWorkCalendarTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWorkCalendar other)
	{
		return this == other;
	}
}
