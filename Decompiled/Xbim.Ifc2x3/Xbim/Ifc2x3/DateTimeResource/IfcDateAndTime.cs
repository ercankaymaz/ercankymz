using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ConstraintResource;
using Xbim.Ifc2x3.PropertyResource;

namespace Xbim.Ifc2x3.DateTimeResource;

[ExpressType("IfcDateAndTime", 373)]
public class IfcDateAndTime : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcDateTimeSelect, IfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IContainsEntityReferences, IEquatable<IfcDateAndTime>
{
	private IfcCalendarDate _dateComponent;

	private IfcLocalTime _timeComponent;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcCalendarDate DateComponent
	{
		get
		{
			if (_activated)
			{
				return _dateComponent;
			}
			Activate();
			return _dateComponent;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCalendarDate v)
			{
				_dateComponent = v;
			}, _dateComponent, value, "DateComponent", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcLocalTime TimeComponent
	{
		get
		{
			if (_activated)
			{
				return _timeComponent;
			}
			Activate();
			return _timeComponent;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcLocalTime v)
			{
				_timeComponent = v;
			}, _timeComponent, value, "TimeComponent", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (DateComponent != null)
			{
				yield return DateComponent;
			}
			if (TimeComponent != null)
			{
				yield return TimeComponent;
			}
		}
	}

	internal IfcDateAndTime(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_dateComponent = (IfcCalendarDate)value.EntityVal;
			break;
		case 1:
			_timeComponent = (IfcLocalTime)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDateAndTime other)
	{
		return this == other;
	}
}
