using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcDerivedUnit", 630)]
public class IfcDerivedUnit : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcDerivedUnit, IfcUnit, IIfcUnit, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcDerivedUnit>, IExpressValidatable
{
	public enum IfcDerivedUnitClause
	{
		WR1,
		WR2
	}

	private readonly ItemSet<IfcDerivedUnitElement> _elements;

	private IfcDerivedUnitEnum _unitType;

	private IfcLabel? _userDefinedType;

	IItemSet<IIfcDerivedUnitElement> IIfcDerivedUnit.Elements => new ProxyItemSet<IfcDerivedUnitElement, IIfcDerivedUnitElement>(Elements);

	IfcDerivedUnitEnum IIfcDerivedUnit.UnitType
	{
		get
		{
			return UnitType;
		}
		set
		{
			UnitType = value;
		}
	}

	IfcLabel? IIfcDerivedUnit.UserDefinedType
	{
		get
		{
			return UserDefinedType;
		}
		set
		{
			UserDefinedType = value;
		}
	}

	Xbim.Common.Geometry.XbimDimensionalExponents IIfcDerivedUnit.Dimensions => Dimensions;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcDerivedUnitElement> Elements
	{
		get
		{
			if (_activated)
			{
				return _elements;
			}
			Activate();
			return _elements;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
	public IfcDerivedUnitEnum UnitType
	{
		get
		{
			if (_activated)
			{
				return _unitType;
			}
			Activate();
			return _unitType;
		}
		set
		{
			SetValue(delegate(IfcDerivedUnitEnum v)
			{
				_unitType = v;
			}, _unitType, value, "UnitType", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? UserDefinedType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedType;
			}
			Activate();
			return _userDefinedType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedType = v;
			}, _userDefinedType, value, "UserDefinedType", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public Xbim.Common.Geometry.XbimDimensionalExponents Dimensions
	{
		get
		{
			if (this == null)
			{
				throw new NotSupportedException();
			}
			IList<IfcDerivedUnitElement> elements = Elements;
			IList<IfcDerivedUnitElement> obj = elements ?? Elements.ToList();
			if (!obj.Any())
			{
				throw new ArgumentNullException();
			}
			Xbim.Common.Geometry.XbimDimensionalExponents xbimDimensionalExponents = new Xbim.Common.Geometry.XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0);
			foreach (IfcDerivedUnitElement item in obj)
			{
				IfcDimensionalExponents dimensions = item.Unit.Dimensions;
				if (dimensions == null && item.Unit is IfcConversionBasedUnit)
				{
					IfcNamedUnit ifcNamedUnit = (item.Unit as IfcConversionBasedUnit).ConversionFactor.UnitComponent as IfcNamedUnit;
					if (ifcNamedUnit != null)
					{
						dimensions = ifcNamedUnit.Dimensions;
					}
				}
				if (!(dimensions == null))
				{
					xbimDimensionalExponents.LengthExponent += item.Exponent * dimensions.LengthExponent;
					xbimDimensionalExponents.MassExponent += item.Exponent * dimensions.MassExponent;
					xbimDimensionalExponents.TimeExponent += item.Exponent * dimensions.TimeExponent;
					xbimDimensionalExponents.ElectricCurrentExponent += item.Exponent * dimensions.ElectricCurrentExponent;
					xbimDimensionalExponents.ThermodynamicTemperatureExponent += item.Exponent * dimensions.ThermodynamicTemperatureExponent;
					xbimDimensionalExponents.AmountOfSubstanceExponent += item.Exponent * dimensions.AmountOfSubstanceExponent;
					xbimDimensionalExponents.LuminousIntensityExponent += item.Exponent * dimensions.LuminousIntensityExponent;
				}
			}
			return xbimDimensionalExponents;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcDerivedUnitElement element in Elements)
			{
				yield return element;
			}
		}
	}

	public string FullName
	{
		get
		{
			if (UserDefinedType.HasValue)
			{
				IfcLabel? userDefinedType = UserDefinedType;
				if (!userDefinedType.HasValue)
				{
					return null;
				}
				return userDefinedType.GetValueOrDefault();
			}
			List<string> list = new List<string>();
			foreach (IfcDerivedUnitElement element in Elements)
			{
				string text = element.Unit.Name();
				if (element.Exponent > 0)
				{
					text = ((element.Exponent == 2) ? (text + "²") : ((element.Exponent != 3) ? (text + "Pow:" + element.Exponent) : (text + "³")));
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(text);
				}
			}
			if (list.Count <= 1)
			{
				return string.Empty;
			}
			return string.Join("/", list);
		}
	}

	internal IfcDerivedUnit(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_elements = new ItemSet<IfcDerivedUnitElement>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_elements.InternalAdd((IfcDerivedUnitElement)value.EntityVal);
			break;
		case 1:
			_unitType = (IfcDerivedUnitEnum)Enum.Parse(typeof(IfcDerivedUnitEnum), value.EnumVal, ignoreCase: true);
			break;
		case 2:
			_userDefinedType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDerivedUnit other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDerivedUnitClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcDerivedUnitClause.WR1:
				result = Functions.SIZEOF(Elements) > 1 || (Functions.SIZEOF(Elements) == 1 && Elements.ItemAt(0L).Exponent != 1);
				break;
			case IfcDerivedUnitClause.WR2:
				result = UnitType != IfcDerivedUnitEnum.USERDEFINED || (UnitType == IfcDerivedUnitEnum.USERDEFINED && Functions.EXISTS(UserDefinedType));
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDerivedUnit>()?.LogError($"Exception thrown evaluating where-clause 'IfcDerivedUnit.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDerivedUnitClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDerivedUnit.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDerivedUnitClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDerivedUnit.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
