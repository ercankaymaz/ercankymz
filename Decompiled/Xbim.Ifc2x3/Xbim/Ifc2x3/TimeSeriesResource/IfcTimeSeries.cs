using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ConstraintResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.TimeSeriesResource;

[ExpressType("IfcTimeSeries", 418)]
public abstract class IfcTimeSeries : PersistEntity, IIfcTimeSeries, IPersistEntity, IPersist, Xbim.Ifc4.ConstraintResource.IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc2x3.ConstraintResource.IfcMetricValueSelect, Xbim.Ifc2x3.PropertyResource.IfcObjectReferenceSelect, IEquatable<IfcTimeSeries>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private IfcDateTimeSelect _startTime;

	private IfcDateTimeSelect _endTime;

	private IfcTimeSeriesDataTypeEnum _timeSeriesDataType;

	private IfcDataOriginEnum _dataOrigin;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _userDefinedDataOrigin;

	private Xbim.Ifc2x3.MeasureResource.IfcUnit _unit;

	[CrossSchemaAttribute(typeof(IIfcTimeSeries), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcTimeSeries.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTimeSeries), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcTimeSeries.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTimeSeries), 3)]
	IfcDateTime IIfcTimeSeries.StartTime
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

	[CrossSchemaAttribute(typeof(IIfcTimeSeries), 4)]
	IfcDateTime IIfcTimeSeries.EndTime
	{
		get
		{
			return new IfcDateTime(EndTime.ToISODateTimeString());
		}
		set
		{
			DateTime d = value;
			EndTime = base.Model.Instances.New(delegate(IfcDateAndTime dt)
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

	[CrossSchemaAttribute(typeof(IIfcTimeSeries), 5)]
	Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum IIfcTimeSeries.TimeSeriesDataType
	{
		get
		{
			return TimeSeriesDataType switch
			{
				IfcTimeSeriesDataTypeEnum.CONTINUOUS => Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.CONTINUOUS, 
				IfcTimeSeriesDataTypeEnum.DISCRETE => Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.DISCRETE, 
				IfcTimeSeriesDataTypeEnum.DISCRETEBINARY => Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.DISCRETEBINARY, 
				IfcTimeSeriesDataTypeEnum.PIECEWISEBINARY => Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.PIECEWISEBINARY, 
				IfcTimeSeriesDataTypeEnum.PIECEWISECONSTANT => Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.PIECEWISECONSTANT, 
				IfcTimeSeriesDataTypeEnum.PIECEWISECONTINUOUS => Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.PIECEWISECONTINUOUS, 
				IfcTimeSeriesDataTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.CONTINUOUS:
				TimeSeriesDataType = IfcTimeSeriesDataTypeEnum.CONTINUOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.DISCRETE:
				TimeSeriesDataType = IfcTimeSeriesDataTypeEnum.DISCRETE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.DISCRETEBINARY:
				TimeSeriesDataType = IfcTimeSeriesDataTypeEnum.DISCRETEBINARY;
				break;
			case Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.PIECEWISEBINARY:
				TimeSeriesDataType = IfcTimeSeriesDataTypeEnum.PIECEWISEBINARY;
				break;
			case Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.PIECEWISECONSTANT:
				TimeSeriesDataType = IfcTimeSeriesDataTypeEnum.PIECEWISECONSTANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.PIECEWISECONTINUOUS:
				TimeSeriesDataType = IfcTimeSeriesDataTypeEnum.PIECEWISECONTINUOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcTimeSeriesDataTypeEnum.NOTDEFINED:
				TimeSeriesDataType = IfcTimeSeriesDataTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTimeSeries), 6)]
	Xbim.Ifc4.Interfaces.IfcDataOriginEnum IIfcTimeSeries.DataOrigin
	{
		get
		{
			return DataOrigin switch
			{
				IfcDataOriginEnum.MEASURED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.MEASURED, 
				IfcDataOriginEnum.PREDICTED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.PREDICTED, 
				IfcDataOriginEnum.SIMULATED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.SIMULATED, 
				IfcDataOriginEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.USERDEFINED, 
				IfcDataOriginEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDataOriginEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.MEASURED:
				DataOrigin = IfcDataOriginEnum.MEASURED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.PREDICTED:
				DataOrigin = IfcDataOriginEnum.PREDICTED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.SIMULATED:
				DataOrigin = IfcDataOriginEnum.SIMULATED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.USERDEFINED:
				DataOrigin = IfcDataOriginEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDataOriginEnum.NOTDEFINED:
				DataOrigin = IfcDataOriginEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTimeSeries), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTimeSeries.UserDefinedDataOrigin
	{
		get
		{
			if (!UserDefinedDataOrigin.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedDataOrigin.Value);
		}
		set
		{
			UserDefinedDataOrigin = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTimeSeries), 8)]
	IIfcUnit IIfcTimeSeries.Unit
	{
		get
		{
			if (Unit == null)
			{
				return null;
			}
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				Unit = null;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				Unit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				Unit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				Unit = ifcNamedUnit;
			}
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcTimeSeries.HasExternalReference => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
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
			}, _startTime, value, "StartTime", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDateTimeSelect EndTime
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_endTime = v;
			}, _endTime, value, "EndTime", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 5)]
	public IfcTimeSeriesDataTypeEnum TimeSeriesDataType
	{
		get
		{
			if (_activated)
			{
				return _timeSeriesDataType;
			}
			Activate();
			return _timeSeriesDataType;
		}
		set
		{
			SetValue(delegate(IfcTimeSeriesDataTypeEnum v)
			{
				_timeSeriesDataType = v;
			}, _timeSeriesDataType, value, "TimeSeriesDataType", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 6)]
	public IfcDataOriginEnum DataOrigin
	{
		get
		{
			if (_activated)
			{
				return _dataOrigin;
			}
			Activate();
			return _dataOrigin;
		}
		set
		{
			SetValue(delegate(IfcDataOriginEnum v)
			{
				_dataOrigin = v;
			}, _dataOrigin, value, "DataOrigin", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? UserDefinedDataOrigin
	{
		get
		{
			if (_activated)
			{
				return _userDefinedDataOrigin;
			}
			Activate();
			return _userDefinedDataOrigin;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedDataOrigin = v;
			}, _userDefinedDataOrigin, value, "UserDefinedDataOrigin", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc2x3.MeasureResource.IfcUnit Unit
	{
		get
		{
			if (_activated)
			{
				return _unit;
			}
			Activate();
			return _unit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 8);
		}
	}

	[InverseProperty("ReferencedTimeSeries")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 9)]
	public IEnumerable<IfcTimeSeriesReferenceRelationship> DocumentedBy => base.Model.Instances.Where((IfcTimeSeriesReferenceRelationship e) => Equals(e.ReferencedTimeSeries), "ReferencedTimeSeries", this);

	internal IfcTimeSeries(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_startTime = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 3:
			_endTime = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 4:
			_timeSeriesDataType = (IfcTimeSeriesDataTypeEnum)Enum.Parse(typeof(IfcTimeSeriesDataTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 5:
			_dataOrigin = (IfcDataOriginEnum)Enum.Parse(typeof(IfcDataOriginEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_userDefinedDataOrigin = value.StringVal;
			break;
		case 7:
			_unit = (Xbim.Ifc2x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTimeSeries other)
	{
		return this == other;
	}
}
