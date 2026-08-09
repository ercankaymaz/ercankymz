using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Step21;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcSIUnit", 164)]
public class IfcSIUnit : IfcNamedUnit, IInstantiableEntity, IPersistEntity, IPersist, IIfcSIUnit, IIfcNamedUnit, IfcUnit, IIfcUnit, IExpressSelectType, IEquatable<IfcSIUnit>
{
	private class PropVal : IPropertyValue
	{
		public bool BooleanVal { get; private set; }

		public string EnumVal { get; private set; }

		public object EntityVal { get; private set; }

		public byte[] HexadecimalVal { get; private set; }

		public long IntegerVal { get; private set; }

		public double NumberVal { get; private set; }

		public double RealVal { get; private set; }

		public string StringVal { get; private set; }

		public StepParserType Type { get; private set; }

		public PropVal(long integer)
		{
			IntegerVal = integer;
			Type = StepParserType.Integer;
		}
	}

	private IfcSIPrefix? _prefix;

	private IfcSIUnitName _name;

	private readonly Dictionary<IfcSIUnitName, IfcDimensionalExponents> ExponentsCache = new Dictionary<IfcSIUnitName, IfcDimensionalExponents>();

	IfcSIPrefix? IIfcSIUnit.Prefix
	{
		get
		{
			return Prefix;
		}
		set
		{
			Prefix = value;
		}
	}

	IfcSIUnitName IIfcSIUnit.Name
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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcSIPrefix? Prefix
	{
		get
		{
			if (_activated)
			{
				return _prefix;
			}
			Activate();
			return _prefix;
		}
		set
		{
			SetValue(delegate(IfcSIPrefix? v)
			{
				_prefix = v;
			}, _prefix, value, "Prefix", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 4)]
	public IfcSIUnitName Name
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
			SetValue(delegate(IfcSIUnitName v)
			{
				_name = v;
			}, _name, value, "Name", 4);
		}
	}

	[EntityAttribute(1, EntityAttributeState.DerivedOverride, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public override IfcDimensionalExponents Dimensions
	{
		get
		{
			return IfcDimensionsForSiUnit(Name);
		}
		set
		{
			throw new Exception("It is not possible to set a value of derived property Dimensions in IfcSIUnit");
		}
	}

	public double Power
	{
		get
		{
			int num = 1;
			if (base.UnitType == IfcUnitEnum.AREAUNIT)
			{
				num = 2;
			}
			if (base.UnitType == IfcUnitEnum.VOLUMEUNIT)
			{
				num = 3;
			}
			if (Prefix.HasValue)
			{
				return Math.Pow(Prefix.Value switch
				{
					IfcSIPrefix.EXA => 1E+18, 
					IfcSIPrefix.PETA => 1000000000000000.0, 
					IfcSIPrefix.TERA => 1000000000000.0, 
					IfcSIPrefix.GIGA => 1000000000.0, 
					IfcSIPrefix.MEGA => 1000000.0, 
					IfcSIPrefix.KILO => 1000.0, 
					IfcSIPrefix.HECTO => 100.0, 
					IfcSIPrefix.DECA => 10.0, 
					IfcSIPrefix.DECI => 0.1, 
					IfcSIPrefix.CENTI => 0.01, 
					IfcSIPrefix.MILLI => 0.001, 
					IfcSIPrefix.MICRO => 1E-06, 
					IfcSIPrefix.NANO => 1E-09, 
					IfcSIPrefix.PICO => 1E-12, 
					IfcSIPrefix.FEMTO => 1E-15, 
					IfcSIPrefix.ATTO => 1E-18, 
					_ => 1.0, 
				}, num);
			}
			return 1.0;
		}
	}

	public new string Symbol
	{
		get
		{
			IfcSIUnitName name = Name;
			string text = string.Empty;
			if (Prefix.HasValue)
			{
				IfcSIPrefix value = Prefix.Value;
				text = value switch
				{
					IfcSIPrefix.EXA => "E", 
					IfcSIPrefix.PETA => "P", 
					IfcSIPrefix.TERA => "T", 
					IfcSIPrefix.GIGA => "G", 
					IfcSIPrefix.MEGA => "M", 
					IfcSIPrefix.KILO => "k", 
					IfcSIPrefix.HECTO => "h", 
					IfcSIPrefix.DECA => "da", 
					IfcSIPrefix.DECI => "d", 
					IfcSIPrefix.CENTI => "c", 
					IfcSIPrefix.MILLI => "m", 
					IfcSIPrefix.MICRO => "µ", 
					IfcSIPrefix.NANO => "n", 
					IfcSIPrefix.PICO => "p", 
					IfcSIPrefix.FEMTO => "f", 
					IfcSIPrefix.ATTO => "a", 
					_ => value.ToString(), 
				};
			}
			return name switch
			{
				IfcSIUnitName.AMPERE => text + "A", 
				IfcSIUnitName.BECQUEREL => text + "Bq", 
				IfcSIUnitName.CANDELA => text + "cd", 
				IfcSIUnitName.COULOMB => text + "C", 
				IfcSIUnitName.CUBIC_METRE => text + "m³", 
				IfcSIUnitName.DEGREE_CELSIUS => text + "°C", 
				IfcSIUnitName.FARAD => text + "F", 
				IfcSIUnitName.GRAM => text + "g", 
				IfcSIUnitName.GRAY => text + "Gy", 
				IfcSIUnitName.HENRY => text + "H", 
				IfcSIUnitName.HERTZ => text + "Hz", 
				IfcSIUnitName.JOULE => text + "J", 
				IfcSIUnitName.KELVIN => text + "K", 
				IfcSIUnitName.LUMEN => text + "lm", 
				IfcSIUnitName.LUX => text + "lx", 
				IfcSIUnitName.METRE => text + "m", 
				IfcSIUnitName.MOLE => text + "mol", 
				IfcSIUnitName.NEWTON => text + "N", 
				IfcSIUnitName.OHM => text + "Ω", 
				IfcSIUnitName.PASCAL => text + "Pa", 
				IfcSIUnitName.RADIAN => text + "rad", 
				IfcSIUnitName.SECOND => text + "s", 
				IfcSIUnitName.SIEMENS => text + "S", 
				IfcSIUnitName.SIEVERT => text + "Sv", 
				IfcSIUnitName.SQUARE_METRE => text + "m²", 
				IfcSIUnitName.STERADIAN => text + "sr", 
				IfcSIUnitName.TESLA => text + "T", 
				IfcSIUnitName.VOLT => text + "V", 
				IfcSIUnitName.WATT => text + "W", 
				IfcSIUnitName.WEBER => text + "Wb", 
				_ => ToString(), 
			};
		}
	}

	public new string FullName
	{
		get
		{
			string text = (Prefix.HasValue ? Prefix.ToString() : "");
			string text2 = Name.ToString();
			if (!string.IsNullOrEmpty(text2))
			{
				if (text2.Contains("_"))
				{
					return text2.Replace("_", text);
				}
				return text + text2;
			}
			return string.Format("{0}{1}", Prefix.HasValue ? Prefix.Value.ToString() : "", Name);
		}
	}

	internal IfcSIUnit(IModel model, int label, bool activated)
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
			_prefix = (IfcSIPrefix)Enum.Parse(typeof(IfcSIPrefix), value.EnumVal, ignoreCase: true);
			break;
		case 3:
			_name = (IfcSIUnitName)Enum.Parse(typeof(IfcSIUnitName), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSIUnit other)
	{
		return this == other;
	}

	internal IfcDimensionalExponents IfcDimensionsForSiUnit(IfcSIUnitName name)
	{
		if (ExponentsCache.TryGetValue(name, out var value))
		{
			return value;
		}
		value = name switch
		{
			IfcSIUnitName.METRE => GetOrCreateExponents(new List<int> { 1, 0, 0, 0, 0, 0, 0 }), 
			IfcSIUnitName.SQUARE_METRE => GetOrCreateExponents(new List<int> { 2, 0, 0, 0, 0, 0, 0 }), 
			IfcSIUnitName.CUBIC_METRE => GetOrCreateExponents(new List<int> { 3, 0, 0, 0, 0, 0, 0 }), 
			IfcSIUnitName.GRAM => GetOrCreateExponents(new List<int> { 0, 1, 0, 0, 0, 0, 0 }), 
			IfcSIUnitName.SECOND => GetOrCreateExponents(new List<int> { 0, 0, 1, 0, 0, 0, 0 }), 
			IfcSIUnitName.AMPERE => GetOrCreateExponents(new List<int> { 0, 0, 0, 1, 0, 0, 0 }), 
			IfcSIUnitName.KELVIN => GetOrCreateExponents(new List<int> { 0, 0, 0, 0, 1, 0, 0 }), 
			IfcSIUnitName.MOLE => GetOrCreateExponents(new List<int> { 0, 0, 0, 0, 0, 1, 0 }), 
			IfcSIUnitName.CANDELA => GetOrCreateExponents(new List<int> { 0, 0, 0, 0, 0, 0, 1 }), 
			IfcSIUnitName.RADIAN => GetOrCreateExponents(new List<int> { 0, 0, 0, 0, 0, 0, 0 }), 
			IfcSIUnitName.STERADIAN => GetOrCreateExponents(new List<int> { 0, 0, 0, 0, 0, 0, 0 }), 
			IfcSIUnitName.HERTZ => GetOrCreateExponents(new List<int> { 0, 0, -1, 0, 0, 0, 0 }), 
			IfcSIUnitName.NEWTON => GetOrCreateExponents(new List<int> { 1, 1, -2, 0, 0, 0, 0 }), 
			IfcSIUnitName.PASCAL => GetOrCreateExponents(new List<int> { -1, 1, -2, 0, 0, 0, 0 }), 
			IfcSIUnitName.JOULE => GetOrCreateExponents(new List<int> { 2, 1, -2, 0, 0, 0, 0 }), 
			IfcSIUnitName.WATT => GetOrCreateExponents(new List<int> { 2, 1, -3, 0, 0, 0, 0 }), 
			IfcSIUnitName.COULOMB => GetOrCreateExponents(new List<int> { 0, 0, 1, 1, 0, 0, 0 }), 
			IfcSIUnitName.VOLT => GetOrCreateExponents(new List<int> { 2, 1, -3, -1, 0, 0, 0 }), 
			IfcSIUnitName.FARAD => GetOrCreateExponents(new List<int> { -2, -1, 4, 1, 0, 0, 0 }), 
			IfcSIUnitName.OHM => GetOrCreateExponents(new List<int> { 2, 1, -3, -2, 0, 0, 0 }), 
			IfcSIUnitName.SIEMENS => GetOrCreateExponents(new List<int> { -2, -1, 3, 2, 0, 0, 0 }), 
			IfcSIUnitName.WEBER => GetOrCreateExponents(new List<int> { 2, 1, -2, -1, 0, 0, 0 }), 
			IfcSIUnitName.TESLA => GetOrCreateExponents(new List<int> { 0, 1, -2, -1, 0, 0, 0 }), 
			IfcSIUnitName.HENRY => GetOrCreateExponents(new List<int> { 2, 1, -2, -2, 0, 0, 0 }), 
			IfcSIUnitName.DEGREE_CELSIUS => GetOrCreateExponents(new List<int> { 0, 0, 0, 0, 1, 0, 0 }), 
			IfcSIUnitName.LUMEN => GetOrCreateExponents(new List<int> { 0, 0, 0, 0, 0, 0, 1 }), 
			IfcSIUnitName.LUX => GetOrCreateExponents(new List<int> { -2, 0, 0, 0, 0, 0, 1 }), 
			IfcSIUnitName.BECQUEREL => GetOrCreateExponents(new List<int> { 0, 0, -1, 0, 0, 0, 0 }), 
			IfcSIUnitName.GRAY => GetOrCreateExponents(new List<int> { 2, 0, -2, 0, 0, 0, 0 }), 
			IfcSIUnitName.SIEVERT => GetOrCreateExponents(new List<int> { 2, 0, -2, 0, 0, 0, 0 }), 
			_ => GetOrCreateExponents(new List<int> { 0, 0, 0, 0, 0, 0, 0 }), 
		};
		ExponentsCache.Add(name, value);
		return value;
	}

	private IfcDimensionalExponents GetOrCreateExponents(IList<int> exponents)
	{
		IfcDimensionalExponents ifcDimensionalExponents = base.Model.Instances.FirstOrDefault((IfcDimensionalExponents e) => e.LengthExponent == exponents[0] && e.MassExponent == exponents[1] && e.TimeExponent == exponents[2] && e.ElectricCurrentExponent == exponents[3] && e.ThermodynamicTemperatureExponent == exponents[4] && e.AmountOfSubstanceExponent == exponents[5] && e.LuminousIntensityExponent == exponents[6]);
		if (ifcDimensionalExponents != null)
		{
			return ifcDimensionalExponents;
		}
		ifcDimensionalExponents = new IfcDimensionalExponents(null, -1, activated: true);
		for (int num = 0; num < 7; num++)
		{
			ifcDimensionalExponents.Parse(num, new PropVal(exponents[num]), null);
		}
		return ifcDimensionalExponents;
	}
}
