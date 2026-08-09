using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcTimePeriod", 1302)]
public class IfcTimePeriod : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcTimePeriod, IEquatable<IfcTimePeriod>
{
	private IfcTime _startTime;

	private IfcTime _endTime;

	IfcTime IIfcTimePeriod.StartTime
	{
		get
		{
			return StartTime;
		}
		set
		{
			StartTime = value;
		}
	}

	IfcTime IIfcTimePeriod.EndTime
	{
		get
		{
			return EndTime;
		}
		set
		{
			EndTime = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcTime StartTime
	{
		get
		{
			if (_activated)
			{
				return _startTime;
			}
			Activate();
			return _startTime;
		}
		set
		{
			SetValue(delegate(IfcTime v)
			{
				_startTime = v;
			}, _startTime, value, "StartTime", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcTime EndTime
	{
		get
		{
			if (_activated)
			{
				return _endTime;
			}
			Activate();
			return _endTime;
		}
		set
		{
			SetValue(delegate(IfcTime v)
			{
				_endTime = v;
			}, _endTime, value, "EndTime", 2);
		}
	}

	internal IfcTimePeriod(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_startTime = value.StringVal;
			break;
		case 1:
			_endTime = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTimePeriod other)
	{
		return this == other;
	}
}
