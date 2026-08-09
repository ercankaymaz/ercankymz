using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ConstraintResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.DateTimeResource;

[ExpressType("IfcLocalTime", 483)]
public class IfcLocalTime : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcDateTimeSelect, IfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IContainsEntityReferences, IEquatable<IfcLocalTime>, IExpressValidatable
{
	public enum IfcLocalTimeClause
	{
		WR21
	}

	private IfcHourInDay _hourComponent;

	private IfcMinuteInHour? _minuteComponent;

	private IfcSecondInMinute? _secondComponent;

	private IfcCoordinatedUniversalTimeOffset _zone;

	private IfcDaylightSavingHour? _daylightSavingOffset;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcHourInDay HourComponent
	{
		get
		{
			if (_activated)
			{
				return _hourComponent;
			}
			Activate();
			return _hourComponent;
		}
		set
		{
			SetValue(delegate(IfcHourInDay v)
			{
				_hourComponent = v;
			}, _hourComponent, value, "HourComponent", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcMinuteInHour? MinuteComponent
	{
		get
		{
			if (_activated)
			{
				return _minuteComponent;
			}
			Activate();
			return _minuteComponent;
		}
		set
		{
			SetValue(delegate(IfcMinuteInHour? v)
			{
				_minuteComponent = v;
			}, _minuteComponent, value, "MinuteComponent", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcSecondInMinute? SecondComponent
	{
		get
		{
			if (_activated)
			{
				return _secondComponent;
			}
			Activate();
			return _secondComponent;
		}
		set
		{
			SetValue(delegate(IfcSecondInMinute? v)
			{
				_secondComponent = v;
			}, _secondComponent, value, "SecondComponent", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcCoordinatedUniversalTimeOffset Zone
	{
		get
		{
			if (_activated)
			{
				return _zone;
			}
			Activate();
			return _zone;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCoordinatedUniversalTimeOffset v)
			{
				_zone = v;
			}, _zone, value, "Zone", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcDaylightSavingHour? DaylightSavingOffset
	{
		get
		{
			if (_activated)
			{
				return _daylightSavingOffset;
			}
			Activate();
			return _daylightSavingOffset;
		}
		set
		{
			SetValue(delegate(IfcDaylightSavingHour? v)
			{
				_daylightSavingOffset = v;
			}, _daylightSavingOffset, value, "DaylightSavingOffset", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Zone != null)
			{
				yield return Zone;
			}
		}
	}

	internal IfcLocalTime(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_hourComponent = value.IntegerVal;
			break;
		case 1:
			_minuteComponent = value.IntegerVal;
			break;
		case 2:
			_secondComponent = value.RealVal;
			break;
		case 3:
			_zone = (IfcCoordinatedUniversalTimeOffset)value.EntityVal;
			break;
		case 4:
			_daylightSavingOffset = value.IntegerVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLocalTime other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcLocalTimeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcLocalTimeClause.WR21)
			{
				result = Functions.IfcValidTime(this);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcLocalTime>()?.LogError($"Exception thrown evaluating where-clause 'IfcLocalTime.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcLocalTimeClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcLocalTime.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
