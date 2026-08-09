using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcTimePeriod", 1302)]
public class IfcTimePeriod : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcTimePeriod>, IIfcTimePeriod
{
	private IfcTime _startTime;

	private IfcTime _endTime;

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

	[CrossSchemaAttribute(typeof(IIfcTimePeriod), 1)]
	Xbim.Ifc4.DateTimeResource.IfcTime IIfcTimePeriod.StartTime
	{
		get
		{
			return new Xbim.Ifc4.DateTimeResource.IfcTime(StartTime);
		}
		set
		{
			StartTime = new IfcTime(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTimePeriod), 2)]
	Xbim.Ifc4.DateTimeResource.IfcTime IIfcTimePeriod.EndTime
	{
		get
		{
			return new Xbim.Ifc4.DateTimeResource.IfcTime(EndTime);
		}
		set
		{
			EndTime = new IfcTime(value);
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
