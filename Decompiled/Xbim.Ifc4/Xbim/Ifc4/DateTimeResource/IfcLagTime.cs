using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcLagTime", 1197)]
public class IfcLagTime : IfcSchedulingTime, IInstantiableEntity, IPersistEntity, IPersist, IIfcLagTime, IIfcSchedulingTime, IEquatable<IfcLagTime>
{
	private IfcTimeOrRatioSelect _lagValue;

	private IfcTaskDurationEnum _durationType;

	IIfcTimeOrRatioSelect IIfcLagTime.LagValue
	{
		get
		{
			return LagValue;
		}
		set
		{
			LagValue = value as IfcTimeOrRatioSelect;
		}
	}

	IfcTaskDurationEnum IIfcLagTime.DurationType
	{
		get
		{
			return DurationType;
		}
		set
		{
			DurationType = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcTimeOrRatioSelect LagValue
	{
		get
		{
			if (_activated)
			{
				return _lagValue;
			}
			Activate();
			return _lagValue;
		}
		set
		{
			SetValue(delegate(IfcTimeOrRatioSelect v)
			{
				_lagValue = v;
			}, _lagValue, value, "LagValue", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 5)]
	public IfcTaskDurationEnum DurationType
	{
		get
		{
			if (_activated)
			{
				return _durationType;
			}
			Activate();
			return _durationType;
		}
		set
		{
			SetValue(delegate(IfcTaskDurationEnum v)
			{
				_durationType = v;
			}, _durationType, value, "DurationType", 5);
		}
	}

	internal IfcLagTime(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_lagValue = (IfcTimeOrRatioSelect)value.EntityVal;
			break;
		case 4:
			_durationType = (IfcTaskDurationEnum)Enum.Parse(typeof(IfcTaskDurationEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLagTime other)
	{
		return this == other;
	}
}
