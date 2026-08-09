using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcMonetaryUnit", 545)]
public class IfcMonetaryUnit : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcMonetaryUnit, IfcUnit, IIfcUnit, IExpressSelectType, IEquatable<IfcMonetaryUnit>
{
	private IfcLabel _currency;

	IfcLabel IIfcMonetaryUnit.Currency
	{
		get
		{
			return Currency;
		}
		set
		{
			Currency = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel Currency
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
			SetValue(delegate(IfcLabel v)
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
			_currency = value.StringVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcMonetaryUnit other)
	{
		return this == other;
	}
}
