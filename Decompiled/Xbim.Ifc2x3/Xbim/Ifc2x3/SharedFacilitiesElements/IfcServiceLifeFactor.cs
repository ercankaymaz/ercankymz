using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.SharedFacilitiesElements;

[ExpressType("IfcServiceLifeFactor", 770)]
public class IfcServiceLifeFactor : IfcPropertySetDefinition, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcServiceLifeFactor>
{
	private IfcServiceLifeFactorTypeEnum _predefinedType;

	private IfcMeasureValue _upperValue;

	private IfcMeasureValue _mostUsedValue;

	private IfcMeasureValue _lowerValue;

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 8)]
	public IfcServiceLifeFactorTypeEnum PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcServiceLifeFactorTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 9)]
	public IfcMeasureValue UpperValue
	{
		get
		{
			if (_activated)
			{
				return _upperValue;
			}
			Activate();
			return _upperValue;
		}
		set
		{
			SetValue(delegate(IfcMeasureValue v)
			{
				_upperValue = v;
			}, _upperValue, value, "UpperValue", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public IfcMeasureValue MostUsedValue
	{
		get
		{
			if (_activated)
			{
				return _mostUsedValue;
			}
			Activate();
			return _mostUsedValue;
		}
		set
		{
			SetValue(delegate(IfcMeasureValue v)
			{
				_mostUsedValue = v;
			}, _mostUsedValue, value, "MostUsedValue", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
	public IfcMeasureValue LowerValue
	{
		get
		{
			if (_activated)
			{
				return _lowerValue;
			}
			Activate();
			return _lowerValue;
		}
		set
		{
			SetValue(delegate(IfcMeasureValue v)
			{
				_lowerValue = v;
			}, _lowerValue, value, "LowerValue", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
		}
	}

	internal IfcServiceLifeFactor(IModel model, int label, bool activated)
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
			_predefinedType = (IfcServiceLifeFactorTypeEnum)Enum.Parse(typeof(IfcServiceLifeFactorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 5:
			_upperValue = (IfcMeasureValue)value.EntityVal;
			break;
		case 6:
			_mostUsedValue = (IfcMeasureValue)value.EntityVal;
			break;
		case 7:
			_lowerValue = (IfcMeasureValue)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcServiceLifeFactor other)
	{
		return this == other;
	}
}
