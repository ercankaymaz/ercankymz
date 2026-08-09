using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProcessExtension;

[ExpressType("IfcWorkControl", 185)]
public abstract class IfcWorkControl : Xbim.Ifc2x3.Kernel.IfcControl, IIfcWorkControl, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcWorkControl>, IExpressValidatable
{
	public enum IfcWorkControlClause
	{
		WR1
	}

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _identifier;

	private IfcDateTimeSelect _creationDate;

	private readonly OptionalItemSet<IfcPerson> _creators;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _purpose;

	private Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure? _duration;

	private Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure? _totalFloat;

	private IfcDateTimeSelect _startTime;

	private IfcDateTimeSelect _finishTime;

	private IfcWorkControlTypeEnum? _workControlType;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _userDefinedControlType;

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 7)]
	IfcDateTime IIfcWorkControl.CreationDate
	{
		get
		{
			return new IfcDateTime(CreationDate.ToISODateTimeString());
		}
		set
		{
			DateTime d = value;
			CreationDate = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
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
			Purpose = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 10)]
	IfcDuration? IIfcWorkControl.Duration
	{
		get
		{
			if (!Duration.HasValue)
			{
				return null;
			}
			return new IfcDuration(Duration.Value.ToISODateTimeString());
		}
		set
		{
			if (!value.HasValue)
			{
				Duration = null;
			}
			else
			{
				Duration = new Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure(((TimeSpan)value.Value).TotalSeconds);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 11)]
	IfcDuration? IIfcWorkControl.TotalFloat
	{
		get
		{
			if (!TotalFloat.HasValue)
			{
				return null;
			}
			return new IfcDuration(TotalFloat.Value.ToISODateTimeString());
		}
		set
		{
			if (!value.HasValue)
			{
				Duration = null;
			}
			else
			{
				TotalFloat = new Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure(((TimeSpan)value.Value).TotalSeconds);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 12)]
	IfcDateTime IIfcWorkControl.StartTime
	{
		get
		{
			return new IfcDateTime(StartTime.ToISODateTimeString());
		}
		set
		{
			DateTime d = value;
			StartTime = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkControl), 13)]
	IfcDateTime? IIfcWorkControl.FinishTime
	{
		get
		{
			return new IfcDateTime(FinishTime.ToISODateTimeString());
		}
		set
		{
			if (!value.HasValue)
			{
				FinishTime = null;
				return;
			}
			DateTime d = value.Value;
			FinishTime = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier Identifier
	{
		get
		{
			if (_activated)
			{
				return _identifier;
			}
			Activate();
			return _identifier;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_identifier = v;
			}, _identifier, value, "Identifier", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcDateTimeSelect CreationDate
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_creationDate = v;
			}, _creationDate, value, "CreationDate", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 14)]
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Purpose
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_purpose = v;
			}, _purpose, value, "Purpose", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure? Duration
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure? v)
			{
				_duration = v;
			}, _duration, value, "Duration", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure? TotalFloat
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure? v)
			{
				_totalFloat = v;
			}, _totalFloat, value, "TotalFloat", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 18)]
	public IfcDateTimeSelect StartTime
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_startTime = v;
			}, _startTime, value, "StartTime", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 19)]
	public IfcDateTimeSelect FinishTime
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_finishTime = v;
			}, _finishTime, value, "FinishTime", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcWorkControlTypeEnum? WorkControlType
	{
		get
		{
			if (_activated)
			{
				return _workControlType;
			}
			Activate();
			return _workControlType;
		}
		set
		{
			SetValue(delegate(IfcWorkControlTypeEnum? v)
			{
				_workControlType = v;
			}, _workControlType, value, "WorkControlType", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? UserDefinedControlType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedControlType;
			}
			Activate();
			return _userDefinedControlType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedControlType = v;
			}, _userDefinedControlType, value, "UserDefinedControlType", 15);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_identifier = value.StringVal;
			break;
		case 6:
			_creationDate = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 7:
			_creators.InternalAdd((IfcPerson)value.EntityVal);
			break;
		case 8:
			_purpose = value.StringVal;
			break;
		case 9:
			_duration = value.RealVal;
			break;
		case 10:
			_totalFloat = value.RealVal;
			break;
		case 11:
			_startTime = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 12:
			_finishTime = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 13:
			_workControlType = (IfcWorkControlTypeEnum)Enum.Parse(typeof(IfcWorkControlTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 14:
			_userDefinedControlType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWorkControl other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcWorkControlClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcWorkControlClause.WR1)
			{
				result = WorkControlType != IfcWorkControlTypeEnum.USERDEFINED || (WorkControlType == IfcWorkControlTypeEnum.USERDEFINED && Functions.EXISTS(UserDefinedControlType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcWorkControl>()?.LogError($"Exception thrown evaluating where-clause 'IfcWorkControl.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcWorkControlClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWorkControl.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
