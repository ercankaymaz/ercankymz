using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcMonetaryUnit", 545)]
public class IfcMonetaryUnit : PersistEntity, IIfcMonetaryUnit, IPersistEntity, IPersist, Xbim.Ifc4.MeasureResource.IfcUnit, IIfcUnit, IExpressSelectType, IInstantiableEntity, IfcUnit, IEquatable<IfcMonetaryUnit>
{
	private IfcLabel _currency;

	[CrossSchemaAttribute(typeof(IIfcMonetaryUnit), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcMonetaryUnit.Currency
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Currency);
		}
		set
		{
			Currency = new IfcLabel(value);
		}
	}

	public string FullName => this.FullEnglishName();

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
