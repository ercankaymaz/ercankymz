using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcConversionBasedUnitWithOffset", 1140)]
public class IfcConversionBasedUnitWithOffset : IfcConversionBasedUnit, IInstantiableEntity, IPersistEntity, IPersist, IIfcConversionBasedUnitWithOffset, IIfcConversionBasedUnit, IIfcNamedUnit, IfcUnit, IIfcUnit, IExpressSelectType, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcConversionBasedUnitWithOffset>
{
	private IfcReal _conversionOffset;

	IfcReal IIfcConversionBasedUnitWithOffset.ConversionOffset
	{
		get
		{
			return ConversionOffset;
		}
		set
		{
			ConversionOffset = value;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcReal ConversionOffset
	{
		get
		{
			if (_activated)
			{
				return _conversionOffset;
			}
			Activate();
			return _conversionOffset;
		}
		set
		{
			SetValue(delegate(IfcReal v)
			{
				_conversionOffset = v;
			}, _conversionOffset, value, "ConversionOffset", 5);
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
			if (base.ConversionFactor != null)
			{
				yield return base.ConversionFactor;
			}
		}
	}

	internal IfcConversionBasedUnitWithOffset(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_conversionOffset = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConversionBasedUnitWithOffset other)
	{
		return this == other;
	}
}
