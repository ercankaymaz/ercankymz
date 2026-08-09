using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcMonetaryUnit", 545)]
public class IfcMonetaryUnit : PersistEntity, IIfcMonetaryUnit, IPersistEntity, IPersist, Xbim.Ifc4.MeasureResource.IfcUnit, IIfcUnit, IExpressSelectType, IInstantiableEntity, IfcUnit, IEquatable<IfcMonetaryUnit>
{
	private Xbim.Ifc4.MeasureResource.IfcLabel _currencyLabel;

	private IfcCurrencyEnum _currency;

	[CrossSchemaAttribute(typeof(IIfcMonetaryUnit), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcMonetaryUnit.Currency
	{
		get
		{
			if (string.IsNullOrWhiteSpace(_currencyLabel))
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel(Enum.GetName(typeof(IfcCurrencyEnum), Currency));
			}
			return _currencyLabel;
		}
		set
		{
			if (Enum.TryParse<IfcCurrencyEnum>(value.ToString(), ignoreCase: true, out var result))
			{
				Currency = result;
				return;
			}
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel v)
			{
				_currencyLabel = v;
			}, _currencyLabel, value, "Currency", -1);
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 1)]
	public IfcCurrencyEnum Currency
	{
		get
		{
			if (_activated)
			{
				return _currency;
			}
			Activate();
			return _currency;
		}
		set
		{
			SetValue(delegate(IfcCurrencyEnum v)
			{
				_currency = v;
			}, _currency, value, "Currency", 1);
		}
	}

	public string Symbol => this.Symbol();

	public string FullEnglishName => this.FullEnglishName();

	public string FullNativeName => this.FullNativeName();

	public string FullName => FullEnglishName;

	internal IfcMonetaryUnit(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_currency = (IfcCurrencyEnum)Enum.Parse(typeof(IfcCurrencyEnum), value.EnumVal, ignoreCase: true);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcMonetaryUnit other)
	{
		return this == other;
	}
}
