using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.CostResource;

[ExpressType("IfcCurrencyRelationship", 195)]
public class IfcCurrencyRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCurrencyRelationship>, IIfcCurrencyRelationship, IIfcResourceLevelRelationship
{
	private Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit _relatingMonetaryUnit;

	private Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit _relatedMonetaryUnit;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure _exchangeRate;

	private Xbim.Ifc4x3.DateTimeResource.IfcDateTime? _rateDateTime;

	private IfcLibraryInformation _rateSource;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit RelatingMonetaryUnit
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit v)
			{
				_relatingMonetaryUnit = v;
			}, _relatingMonetaryUnit, value, "RelatingMonetaryUnit", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit RelatedMonetaryUnit
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit v)
			{
				_relatedMonetaryUnit = v;
			}, _relatedMonetaryUnit, value, "RelatedMonetaryUnit", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure ExchangeRate
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure v)
			{
				_exchangeRate = v;
			}, _exchangeRate, value, "ExchangeRate", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDateTime? RateDateTime
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDateTime? v)
			{
				_rateDateTime = v;
			}, _rateDateTime, value, "RateDateTime", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
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
			}, _rateSource, value, "RateSource", 7);
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
			RelatingMonetaryUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
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
			RelatedMonetaryUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
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
			ExchangeRate = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurrencyRelationship), 6)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcCurrencyRelationship.RateDateTime
	{
		get
		{
			if (!RateDateTime.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(RateDateTime.Value);
		}
		set
		{
			RateDateTime = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDateTime?(new Xbim.Ifc4x3.DateTimeResource.IfcDateTime(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDateTime?)null));
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

	internal IfcCurrencyRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_relatingMonetaryUnit = (Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit)value.EntityVal;
			break;
		case 3:
			_relatedMonetaryUnit = (Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit)value.EntityVal;
			break;
		case 4:
			_exchangeRate = value.RealVal;
			break;
		case 5:
			_rateDateTime = value.StringVal;
			break;
		case 6:
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
