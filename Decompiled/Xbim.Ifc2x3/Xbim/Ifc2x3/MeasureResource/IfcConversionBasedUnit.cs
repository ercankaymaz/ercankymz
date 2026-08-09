using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcConversionBasedUnit", 92)]
public class IfcConversionBasedUnit : IfcNamedUnit, IIfcConversionBasedUnit, IIfcNamedUnit, IPersistEntity, IPersist, Xbim.Ifc4.MeasureResource.IfcUnit, IIfcUnit, IExpressSelectType, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcConversionBasedUnit>
{
	private IfcLabel _name;

	private IfcMeasureWithUnit _conversionFactor;

	[CrossSchemaAttribute(typeof(IIfcConversionBasedUnit), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcConversionBasedUnit.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConversionBasedUnit), 4)]
	IIfcMeasureWithUnit IIfcConversionBasedUnit.ConversionFactor
	{
		get
		{
			return ConversionFactor;
		}
		set
		{
			ConversionFactor = value as IfcMeasureWithUnit;
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcConversionBasedUnit.HasExternalReference => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel Name
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
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcMeasureWithUnit ConversionFactor
	{
		get
		{
			if (_activated)
			{
				return _conversionFactor;
			}
			Activate();
			return _conversionFactor;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMeasureWithUnit v)
			{
				_conversionFactor = v;
			}, _conversionFactor, value, "ConversionFactor", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Dimensions != null)
			{
				yield return Dimensions;
			}
			if (ConversionFactor != null)
			{
				yield return ConversionFactor;
			}
		}
	}

	public new string Symbol
	{
		get
		{
			string text = Name;
			if (base.UnitType == IfcUnitEnum.LENGTHUNIT || base.UnitType == IfcUnitEnum.AREAUNIT || base.UnitType == IfcUnitEnum.VOLUMEUNIT)
			{
				string text2 = string.Empty;
				if (Dimensions.LengthExponent == 2)
				{
					text2 += "²";
				}
				if (Dimensions.LengthExponent == 3)
				{
					text2 += "³";
				}
				if (text.ToUpper().Contains("FEET") || text.ToUpper().Contains("FOOT"))
				{
					return "ft" + text2;
				}
				if (text.ToUpper().Contains("INCH"))
				{
					return "in" + text2;
				}
				return text + text2;
			}
			return text;
		}
	}

	internal IfcConversionBasedUnit(IModel model, int label, bool activated)
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
			_name = value.StringVal;
			break;
		case 3:
			_conversionFactor = (IfcMeasureWithUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConversionBasedUnit other)
	{
		return this == other;
	}
}
