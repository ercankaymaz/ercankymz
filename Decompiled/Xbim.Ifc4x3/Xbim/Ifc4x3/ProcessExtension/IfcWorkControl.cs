using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ActorResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcWorkControl", 185)]
public abstract class IfcWorkControl : Xbim.Ifc4x3.Kernel.IfcControl, IIfcWorkControl, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcWorkControl>
{
	private Xbim.Ifc4x3.DateTimeResource.IfcDateTime _creationDate;

	private readonly OptionalItemSet<IfcPerson> _creators;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _purpose;

	private Xbim.Ifc4x3.DateTimeResource.IfcDuration? _duration;

	private Xbim.Ifc4x3.DateTimeResource.IfcDuration? _totalFloat;

	private Xbim.Ifc4x3.DateTimeResource.IfcDateTime _startTime;

	private Xbim.Ifc4x3.DateTimeResource.IfcDateTime? _finishTime;

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 7)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime IIfcWorkControl.CreationDate
	{
		get
		{
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(CreationDate);
		}
		set
		{
			CreationDate = new Xbim.Ifc4x3.DateTimeResource.IfcDateTime(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 8)]
	IItemSet<IIfcPerson> IIfcWorkControl.Creators => new ProxyItemSet<IfcPerson, IIfcPerson>(Creators);

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcWorkControl.Purpose
	{
		get
		{
			if (!Purpose.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Purpose.Value);
		}
		set
		{
			Purpose = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 10)]
	Xbim.Ifc4.DateTimeResource.IfcDuration? IIfcWorkControl.Duration
	{
		get
		{
			if (!Duration.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDuration(Duration.Value);
		}
		set
		{
			Duration = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDuration?(new Xbim.Ifc4x3.DateTimeResource.IfcDuration(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDuration?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 11)]
	Xbim.Ifc4.DateTimeResource.IfcDuration? IIfcWorkControl.TotalFloat
	{
		get
		{
			if (!TotalFloat.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDuration(TotalFloat.Value);
		}
		set
		{
			TotalFloat = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDuration?(new Xbim.Ifc4x3.DateTimeResource.IfcDuration(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDuration?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 12)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime IIfcWorkControl.StartTime
	{
		get
		{
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(StartTime);
		}
		set
		{
			StartTime = new Xbim.Ifc4x3.DateTimeResource.IfcDateTime(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 13)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcWorkControl.FinishTime
	{
		get
		{
			if (!FinishTime.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(FinishTime.Value);
		}
		set
		{
			FinishTime = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDateTime?(new Xbim.Ifc4x3.DateTimeResource.IfcDateTime(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDateTime?)null));
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDateTime CreationDate
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDateTime v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Purpose
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_purpose = v;
			}, _purpose, value, "Purpose", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDuration? Duration
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDuration? v)
			{
				_duration = v;
			}, _duration, value, "Duration", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 23)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDuration? TotalFloat
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDuration? v)
			{
				_totalFloat = v;
			}, _totalFloat, value, "TotalFloat", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDateTime StartTime
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDateTime v)
			{
				_startTime = v;
			}, _startTime, value, "StartTime", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDateTime? FinishTime
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDateTime? v)
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
