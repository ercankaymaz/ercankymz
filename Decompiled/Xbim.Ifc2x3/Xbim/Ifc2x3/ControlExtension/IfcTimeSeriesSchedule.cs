using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.TimeSeriesResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.ControlExtension;

[ExpressType("IfcTimeSeriesSchedule", 712)]
public class IfcTimeSeriesSchedule : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcTimeSeriesSchedule>, IExpressValidatable
{
	public enum IfcTimeSeriesScheduleClause
	{
		WR41
	}

	private readonly OptionalItemSet<IfcDateTimeSelect> _applicableDates;

	private IfcTimeSeriesScheduleTypeEnum _timeSeriesScheduleType;

	private IfcTimeSeries _timeSeries;

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 12)]
	public IOptionalItemSet<IfcDateTimeSelect> ApplicableDates
	{
		get
		{
			if (_activated)
			{
				return _applicableDates;
			}
			Activate();
			return _applicableDates;
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 13)]
	public IfcTimeSeriesScheduleTypeEnum TimeSeriesScheduleType
	{
		get
		{
			if (_activated)
			{
				return _timeSeriesScheduleType;
			}
			Activate();
			return _timeSeriesScheduleType;
		}
		set
		{
			SetValue(delegate(IfcTimeSeriesScheduleTypeEnum v)
			{
				_timeSeriesScheduleType = v;
			}, _timeSeriesScheduleType, value, "TimeSeriesScheduleType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public IfcTimeSeries TimeSeries
	{
		get
		{
			if (_activated)
			{
				return _timeSeries;
			}
			Activate();
			return _timeSeries;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTimeSeries v)
			{
				_timeSeries = v;
			}, _timeSeries, value, "TimeSeries", 8);
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
			foreach (IfcDateTimeSelect applicableDate in ApplicableDates)
			{
				yield return applicableDate;
			}
			if (TimeSeries != null)
			{
				yield return TimeSeries;
			}
		}
	}

	internal IfcTimeSeriesSchedule(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_applicableDates = new OptionalItemSet<IfcDateTimeSelect>(this, 0, 6);
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
			_applicableDates.InternalAdd((IfcDateTimeSelect)value.EntityVal);
			break;
		case 6:
			_timeSeriesScheduleType = (IfcTimeSeriesScheduleTypeEnum)Enum.Parse(typeof(IfcTimeSeriesScheduleTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_timeSeries = (IfcTimeSeries)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTimeSeriesSchedule other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTimeSeriesScheduleClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTimeSeriesScheduleClause.WR41)
			{
				result = TimeSeriesScheduleType != IfcTimeSeriesScheduleTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTimeSeriesSchedule>()?.LogError($"Exception thrown evaluating where-clause 'IfcTimeSeriesSchedule.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTimeSeriesScheduleClause.WR41))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTimeSeriesSchedule.WR41",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
