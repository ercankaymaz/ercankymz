using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProcessExtension;

[ExpressType("IfcWorkControl", 185)]
public abstract class IfcWorkControl : IfcControl, IIfcWorkControl, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcWorkControl>
{
	private IfcDateTime _creationDate;

	private readonly OptionalItemSet<IfcPerson> _creators;

	private IfcLabel? _purpose;

	private IfcDuration? _duration;

	private IfcDuration? _totalFloat;

	private IfcDateTime _startTime;

	private IfcDateTime? _finishTime;

	IfcDateTime IIfcWorkControl.CreationDate
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

	IItemSet<IIfcPerson> IIfcWorkControl.Creators => new ProxyItemSet<IfcPerson, IIfcPerson>(Creators);

	IfcLabel? IIfcWorkControl.Purpose
	{
		get
		{
			return Purpose;
		}
		set
		{
			Purpose = value;
		}
	}

	IfcDuration? IIfcWorkControl.Duration
	{
		get
		{
			return Duration;
		}
		set
		{
			Duration = value;
		}
	}

	IfcDuration? IIfcWorkControl.TotalFloat
	{
		get
		{
			return TotalFloat;
		}
		set
		{
			TotalFloat = value;
		}
	}

	IfcDateTime IIfcWorkControl.StartTime
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

	IfcDateTime? IIfcWorkControl.FinishTime
	{
		get
		{
			return FinishTime;
		}
		set
		{
			FinishTime = value;
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public IfcDateTime CreationDate
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
			SetValue(delegate(IfcDateTime v)
			{
				_creationDate = v;
			}, _creationDate, value, "CreationDate", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 20)]
	public IOptionalItemSet<IfcPerson> Creators
	{
		get
		{
			if (_activated)
			{
				return _creators;
			}
			Activate();
			return _creators;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcLabel? Purpose
	{
		get
		{
			if (_activated)
			{
				return _purpose;
			}
			Activate();
			return _purpose;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_purpose = v;
			}, _purpose, value, "Purpose", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public IfcDuration? Duration
	{
		get
		{
			if (_activated)
			{
				return _duration;
			}
			Activate();
			return _duration;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_duration = v;
			}, _duration, value, "Duration", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 23)]
	public IfcDuration? TotalFloat
	{
		get
		{
			if (_activated)
			{
				return _totalFloat;
			}
			Activate();
			return _totalFloat;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_totalFloat = v;
			}, _totalFloat, value, "TotalFloat", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public IfcDateTime StartTime
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
			SetValue(delegate(IfcDateTime v)
			{
				_startTime = v;
			}, _startTime, value, "StartTime", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public IfcDateTime? FinishTime
	{
		get
		{
			if (_activated)
			{
				return _finishTime;
			}
			Activate();
			return _finishTime;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_finishTime = v;
			}, _finishTime, value, "FinishTime", 13);
		}
	}

	internal IfcWorkControl(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_creators = new OptionalItemSet<IfcPerson>(this, 0, 8);
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
			_creationDate = value.StringVal;
			break;
		case 7:
			_creators.InternalAdd((IfcPerson)value.EntityVal);
			break;
		case 8:
			_purpose = value.StringVal;
			break;
		case 9:
			_duration = value.StringVal;
			break;
		case 10:
			_totalFloat = value.StringVal;
			break;
		case 11:
			_startTime = value.StringVal;
			break;
		case 12:
			_finishTime = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWorkControl other)
	{
		return this == other;
	}
}
