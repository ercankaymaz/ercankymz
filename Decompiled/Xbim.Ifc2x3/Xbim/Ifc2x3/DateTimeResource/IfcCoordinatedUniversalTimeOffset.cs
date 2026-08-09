using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.DateTimeResource;

[ExpressType("IfcCoordinatedUniversalTimeOffset", 690)]
public class IfcCoordinatedUniversalTimeOffset : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcCoordinatedUniversalTimeOffset>
{
	private IfcHourInDay _hourOffset;

	private IfcMinuteInHour? _minuteOffset;

	private IfcAheadOrBehind _sense;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcHourInDay HourOffset
	{
		get
		{
			if (_activated)
			{
				return _hourOffset;
			}
			Activate();
			return _hourOffset;
		}
		set
		{
			SetValue(delegate(IfcHourInDay v)
			{
				_hourOffset = v;
			}, _hourOffset, value, "HourOffset", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcMinuteInHour? MinuteOffset
	{
		get
		{
			if (_activated)
			{
				return _minuteOffset;
			}
			Activate();
			return _minuteOffset;
		}
		set
		{
			SetValue(delegate(IfcMinuteInHour? v)
			{
				_minuteOffset = v;
			}, _minuteOffset, value, "MinuteOffset", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcAheadOrBehind Sense
	{
		get
		{
			if (_activated)
			{
				return _sense;
			}
			Activate();
			return _sense;
		}
		set
		{
			SetValue(delegate(IfcAheadOrBehind v)
			{
				_sense = v;
			}, _sense, value, "Sense", 3);
		}
	}

	internal IfcCoordinatedUniversalTimeOffset(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_hourOffset = value.IntegerVal;
			break;
		case 1:
			_minuteOffset = value.IntegerVal;
			break;
		case 2:
			_sense = (IfcAheadOrBehind)Enum.Parse(typeof(IfcAheadOrBehind), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoordinatedUniversalTimeOffset other)
	{
		return this == other;
	}
}
