using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcLagTime", 1197)]
public class IfcLagTime : IfcSchedulingTime, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcLagTime>, IIfcLagTime, IIfcSchedulingTime
{
	private IfcTimeOrRatioSelect _lagValue;

	private IfcTaskDurationEnum _durationType;

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

	[CrossSchemaAttribute(typeof(IIfcLagTime), 4)]
	IIfcTimeOrRatioSelect IIfcLagTime.LagValue
	{
		get
		{
			if (LagValue == null)
			{
				return null;
			}
			if (LagValue is IfcDuration)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDuration((IfcDuration)(object)LagValue);
			}
			if (LagValue is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)LagValue);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				LagValue = null;
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDuration)
			{
				LagValue = new IfcDuration((Xbim.Ifc4.DateTimeResource.IfcDuration)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				LagValue = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLagTime), 5)]
	Xbim.Ifc4.Interfaces.IfcTaskDurationEnum IIfcLagTime.DurationType
	{
		get
		{
			return DurationType switch
			{
				IfcTaskDurationEnum.ELAPSEDTIME => Xbim.Ifc4.Interfaces.IfcTaskDurationEnum.ELAPSEDTIME, 
				IfcTaskDurationEnum.WORKTIME => Xbim.Ifc4.Interfaces.IfcTaskDurationEnum.WORKTIME, 
				IfcTaskDurationEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTaskDurationEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTaskDurationEnum.ELAPSEDTIME:
				DurationType = IfcTaskDurationEnum.ELAPSEDTIME;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskDurationEnum.WORKTIME:
				DurationType = IfcTaskDurationEnum.WORKTIME;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskDurationEnum.NOTDEFINED:
				DurationType = IfcTaskDurationEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
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
