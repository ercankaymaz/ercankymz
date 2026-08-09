using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.CostResource;

[ExpressType("IfcCurrencyRelationship", 195)]
public class IfcCurrencyRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCurrencyRelationship>, IIfcCurrencyRelationship, IIfcResourceLevelRelationship
{
	private Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit _relatingMonetaryUnit;

	private Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit _relatedMonetaryUnit;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure _exchangeRate;

	private IfcDateAndTime _rateDateTime;

	private IfcLibraryInformation _rateSource;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4.MeasureResource.IfcText? _description;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit RelatingMonetaryUnit
	{
		get
		{
			if (_activated)
			{
				return _relatingMonetaryUnit;
			}
			Activate();
			return _relatingMonetaryUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit v)
			{
				_relatingMonetaryUnit = v;
			}, _relatingMonetaryUnit, value, "RelatingMonetaryUnit", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit RelatedMonetaryUnit
	{
		get
		{
			if (_activated)
			{
				return _relatedMonetaryUnit;
			}
			Activate();
			return _relatedMonetaryUnit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit v)
			{
				_relatedMonetaryUnit = v;
			}, _relatedMonetaryUnit, value, "RelatedMonetaryUnit", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure ExchangeRate
	{
		get
		{
			if (_activated)
			{
				return _exchangeRate;
			}
			Activate();
			return _exchangeRate;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure v)
			{
				_exchangeRate = v;
			}, _exchangeRate, value, "ExchangeRate", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDateAndTime RateDateTime
	{
		get
		{
			if (_activated)
			{
				return _rateDateTime;
			}
			Activate();
			return _rateDateTime;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateAndTime v)
			{
				_rateDateTime = v;
			}, _rateDateTime, value, "RateDateTime", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcLibraryInformation RateSource
	{
		get
		{
			if (_activated)
			{
				return _rateSource;
			}
			Activate();
			return _rateSource;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcLibraryInformation v)
			{
				_rateSource = v;
			}, _rateSource, value, "RateSource", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingMonetaryUnit != null)
			{
				yield return RelatingMonetaryUnit;
			}
			if (RelatedMonetaryUnit != null)
			{
				yield return RelatedMonetaryUnit;
			}
			if (RateDateTime != null)
			{
				yield return RateDateTime;
			}
			if (RateSource != null)
			{
				yield return RateSource;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurrencyRelationship), 3)]
	IIfcMonetaryUnit IIfcCurrencyRelationship.RelatingMonetaryUnit
	{
		get
		{
			return RelatingMonetaryUnit;
		}
		set
		{
			RelatingMonetaryUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurrencyRelationship), 4)]
	IIfcMonetaryUnit IIfcCurrencyRelationship.RelatedMonetaryUnit
	{
		get
		{
			return RelatedMonetaryUnit;
		}
		set
		{
			RelatedMonetaryUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurrencyRelationship), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure IIfcCurrencyRelationship.ExchangeRate
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure(ExchangeRate);
		}
		set
		{
			ExchangeRate = new Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurrencyRelationship), 6)]
	IfcDateTime? IIfcCurrencyRelationship.RateDateTime
	{
		get
		{
			return (RateDateTime != null) ? new IfcDateTime(RateDateTime.ToISODateTimeString()) : ((IfcDateTime)null);
		}
		set
		{
			if (!value.HasValue)
			{
				RateDateTime = null;
				return;
			}
			DateTime d = value.Value;
			RateDateTime = base.Model.Instances.New(delegate(IfcDateAndTime dt)
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

	[CrossSchemaAttribute(typeof(IIfcCurrencyRelationship), 7)]
	IIfcLibraryInformation IIfcCurrencyRelationship.RateSource
	{
		get
		{
			return RateSource;
		}
		set
		{
			RateSource = value as IfcLibraryInformation;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurrencyRelationship), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcResourceLevelRelationship.Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", -1);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurrencyRelationship), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcResourceLevelRelationship.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -2);
		}
	}

	internal IfcCurrencyRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_relatingMonetaryUnit = (Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit)value.EntityVal;
			break;
		case 1:
			_relatedMonetaryUnit = (Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit)value.EntityVal;
			break;
		case 2:
			_exchangeRate = value.RealVal;
			break;
		case 3:
			_rateDateTime = (IfcDateAndTime)value.EntityVal;
			break;
		case 4:
			_rateSource = (IfcLibraryInformation)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurrencyRelationship other)
	{
		return this == other;
	}
}
