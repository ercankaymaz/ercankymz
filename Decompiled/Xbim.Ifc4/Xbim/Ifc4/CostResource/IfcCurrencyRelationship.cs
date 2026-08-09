using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.CostResource;

[ExpressType("IfcCurrencyRelationship", 195)]
public class IfcCurrencyRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IIfcCurrencyRelationship, IIfcResourceLevelRelationship, IContainsEntityReferences, IEquatable<IfcCurrencyRelationship>
{
	private IfcMonetaryUnit _relatingMonetaryUnit;

	private IfcMonetaryUnit _relatedMonetaryUnit;

	private IfcPositiveRatioMeasure _exchangeRate;

	private IfcDateTime? _rateDateTime;

	private IfcLibraryInformation _rateSource;

	IIfcMonetaryUnit IIfcCurrencyRelationship.RelatingMonetaryUnit
	{
		get
		{
			return RelatingMonetaryUnit;
		}
		set
		{
			RelatingMonetaryUnit = value as IfcMonetaryUnit;
		}
	}

	IIfcMonetaryUnit IIfcCurrencyRelationship.RelatedMonetaryUnit
	{
		get
		{
			return RelatedMonetaryUnit;
		}
		set
		{
			RelatedMonetaryUnit = value as IfcMonetaryUnit;
		}
	}

	IfcPositiveRatioMeasure IIfcCurrencyRelationship.ExchangeRate
	{
		get
		{
			return ExchangeRate;
		}
		set
		{
			ExchangeRate = value;
		}
	}

	IfcDateTime? IIfcCurrencyRelationship.RateDateTime
	{
		get
		{
			return RateDateTime;
		}
		set
		{
			RateDateTime = value;
		}
	}

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

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcMonetaryUnit RelatingMonetaryUnit
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
			SetValue(delegate(IfcMonetaryUnit v)
			{
				_relatingMonetaryUnit = v;
			}, _relatingMonetaryUnit, value, "RelatingMonetaryUnit", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcMonetaryUnit RelatedMonetaryUnit
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
			SetValue(delegate(IfcMonetaryUnit v)
			{
				_relatedMonetaryUnit = v;
			}, _relatedMonetaryUnit, value, "RelatedMonetaryUnit", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveRatioMeasure ExchangeRate
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
			SetValue(delegate(IfcPositiveRatioMeasure v)
			{
				_exchangeRate = v;
			}, _exchangeRate, value, "ExchangeRate", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcDateTime? RateDateTime
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
			SetValue(delegate(IfcDateTime? v)
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
			_relatingMonetaryUnit = (IfcMonetaryUnit)value.EntityVal;
			break;
		case 3:
			_relatedMonetaryUnit = (IfcMonetaryUnit)value.EntityVal;
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
