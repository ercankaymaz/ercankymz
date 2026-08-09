using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcTimeSeries", 418)]
public abstract class IfcTimeSeries : PersistEntity, IIfcTimeSeries, IPersistEntity, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IEquatable<IfcTimeSeries>
{
	private IfcLabel _name;

	private IfcText? _description;

	private IfcDateTime _startTime;

	private IfcDateTime _endTime;

	private IfcTimeSeriesDataTypeEnum _timeSeriesDataType;

	private IfcDataOriginEnum _dataOrigin;

	private IfcLabel? _userDefinedDataOrigin;

	private IfcUnit _unit;

	IfcLabel IIfcTimeSeries.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcTimeSeries.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IfcDateTime IIfcTimeSeries.StartTime
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

	IfcDateTime IIfcTimeSeries.EndTime
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

	IfcTimeSeriesDataTypeEnum IIfcTimeSeries.TimeSeriesDataType
	{
		get
		{
			return TimeSeriesDataType;
		}
		set
		{
			TimeSeriesDataType = value;
		}
	}

	IfcDataOriginEnum IIfcTimeSeries.DataOrigin
	{
		get
		{
			return DataOrigin;
		}
		set
		{
			DataOrigin = value;
		}
	}

	IfcLabel? IIfcTimeSeries.UserDefinedDataOrigin
	{
		get
		{
			return UserDefinedDataOrigin;
		}
		set
		{
			UserDefinedDataOrigin = value;
		}
	}

	IIfcUnit IIfcTimeSeries.Unit
	{
		get
		{
			return Unit;
		}
		set
		{
			Unit = value as IfcUnit;
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcTimeSeries.HasExternalReference => HasExternalReference;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel Name
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
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcText? Description
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
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _startTime, value, "StartTime", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcDateTime EndTime
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
			SetValue(delegate(IfcDateTime v)
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
	public IfcLabel? UserDefinedDataOrigin
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
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedDataOrigin = v;
			}, _userDefinedDataOrigin, value, "UserDefinedDataOrigin", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcUnit Unit
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
			SetValue(delegate(IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 8);
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcExternalReferenceRelationship> HasExternalReference => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

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
			_startTime = value.StringVal;
			break;
		case 3:
			_endTime = value.StringVal;
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
			_unit = (IfcUnit)value.EntityVal;
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
