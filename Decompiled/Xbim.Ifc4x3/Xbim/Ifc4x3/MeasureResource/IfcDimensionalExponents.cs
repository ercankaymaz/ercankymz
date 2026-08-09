using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcDimensionalExponents", 303)]
public class IfcDimensionalExponents : PersistEntity, IIfcDimensionalExponents, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcDimensionalExponents>
{
	private long _lengthExponent;

	private long _massExponent;

	private long _timeExponent;

	private long _electricCurrentExponent;

	private long _thermodynamicTemperatureExponent;

	private long _amountOfSubstanceExponent;

	private long _luminousIntensityExponent;

	[CrossSchemaAttribute(typeof(IIfcDimensionalExponents), 1)]
	long IIfcDimensionalExponents.LengthExponent
	{
		get
		{
			return LengthExponent;
		}
		set
		{
			LengthExponent = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDimensionalExponents), 2)]
	long IIfcDimensionalExponents.MassExponent
	{
		get
		{
			return MassExponent;
		}
		set
		{
			MassExponent = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDimensionalExponents), 3)]
	long IIfcDimensionalExponents.TimeExponent
	{
		get
		{
			return TimeExponent;
		}
		set
		{
			TimeExponent = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDimensionalExponents), 4)]
	long IIfcDimensionalExponents.ElectricCurrentExponent
	{
		get
		{
			return ElectricCurrentExponent;
		}
		set
		{
			ElectricCurrentExponent = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDimensionalExponents), 5)]
	long IIfcDimensionalExponents.ThermodynamicTemperatureExponent
	{
		get
		{
			return ThermodynamicTemperatureExponent;
		}
		set
		{
			ThermodynamicTemperatureExponent = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDimensionalExponents), 6)]
	long IIfcDimensionalExponents.AmountOfSubstanceExponent
	{
		get
		{
			return AmountOfSubstanceExponent;
		}
		set
		{
			AmountOfSubstanceExponent = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDimensionalExponents), 7)]
	long IIfcDimensionalExponents.LuminousIntensityExponent
	{
		get
		{
			return LuminousIntensityExponent;
		}
		set
		{
			LuminousIntensityExponent = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public long LengthExponent
	{
		get
		{
			if (_activated)
			{
				return _lengthExponent;
			}
			Activate();
			return _lengthExponent;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_lengthExponent = v;
			}, _lengthExponent, value, "LengthExponent", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public long MassExponent
	{
		get
		{
			if (_activated)
			{
				return _massExponent;
			}
			Activate();
			return _massExponent;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_massExponent = v;
			}, _massExponent, value, "MassExponent", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public long TimeExponent
	{
		get
		{
			if (_activated)
			{
				return _timeExponent;
			}
			Activate();
			return _timeExponent;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_timeExponent = v;
			}, _timeExponent, value, "TimeExponent", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public long ElectricCurrentExponent
	{
		get
		{
			if (_activated)
			{
				return _electricCurrentExponent;
			}
			Activate();
			return _electricCurrentExponent;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_electricCurrentExponent = v;
			}, _electricCurrentExponent, value, "ElectricCurrentExponent", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public long ThermodynamicTemperatureExponent
	{
		get
		{
			if (_activated)
			{
				return _thermodynamicTemperatureExponent;
			}
			Activate();
			return _thermodynamicTemperatureExponent;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_thermodynamicTemperatureExponent = v;
			}, _thermodynamicTemperatureExponent, value, "ThermodynamicTemperatureExponent", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public long AmountOfSubstanceExponent
	{
		get
		{
			if (_activated)
			{
				return _amountOfSubstanceExponent;
			}
			Activate();
			return _amountOfSubstanceExponent;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_amountOfSubstanceExponent = v;
			}, _amountOfSubstanceExponent, value, "AmountOfSubstanceExponent", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public long LuminousIntensityExponent
	{
		get
		{
			if (_activated)
			{
				return _luminousIntensityExponent;
			}
			Activate();
			return _luminousIntensityExponent;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_luminousIntensityExponent = v;
			}, _luminousIntensityExponent, value, "LuminousIntensityExponent", 7);
		}
	}

	internal IfcDimensionalExponents(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_lengthExponent = value.IntegerVal;
			break;
		case 1:
			_massExponent = value.IntegerVal;
			break;
		case 2:
			_timeExponent = value.IntegerVal;
			break;
		case 3:
			_electricCurrentExponent = value.IntegerVal;
			break;
		case 4:
			_thermodynamicTemperatureExponent = value.IntegerVal;
			break;
		case 5:
			_amountOfSubstanceExponent = value.IntegerVal;
			break;
		case 6:
			_luminousIntensityExponent = value.IntegerVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDimensionalExponents other)
	{
		return this == other;
	}
}
