using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.TimeSeriesResource;

namespace Xbim.Ifc2x3.SharedBldgServiceElements;

[ExpressType("IfcSpaceThermalLoadProperties", 610)]
public class IfcSpaceThermalLoadProperties : IfcPropertySetDefinition, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSpaceThermalLoadProperties>
{
	private IfcPositiveRatioMeasure? _applicableValueRatio;

	private IfcThermalLoadSourceEnum _thermalLoadSource;

	private IfcPropertySourceEnum _propertySource;

	private IfcText? _sourceDescription;

	private IfcPowerMeasure _maximumValue;

	private IfcPowerMeasure? _minimumValue;

	private IfcTimeSeries _thermalLoadTimeSeriesValues;

	private IfcLabel? _userDefinedThermalLoadSource;

	private IfcLabel? _userDefinedPropertySource;

	private IfcThermalLoadTypeEnum _thermalLoadType;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveRatioMeasure? ApplicableValueRatio
	{
		get
		{
			if (_activated)
			{
				return _applicableValueRatio;
			}
			Activate();
			return _applicableValueRatio;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_applicableValueRatio = v;
			}, _applicableValueRatio, value, "ApplicableValueRatio", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcThermalLoadSourceEnum ThermalLoadSource
	{
		get
		{
			if (_activated)
			{
				return _thermalLoadSource;
			}
			Activate();
			return _thermalLoadSource;
		}
		set
		{
			SetValue(delegate(IfcThermalLoadSourceEnum v)
			{
				_thermalLoadSource = v;
			}, _thermalLoadSource, value, "ThermalLoadSource", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcPropertySourceEnum PropertySource
	{
		get
		{
			if (_activated)
			{
				return _propertySource;
			}
			Activate();
			return _propertySource;
		}
		set
		{
			SetValue(delegate(IfcPropertySourceEnum v)
			{
				_propertySource = v;
			}, _propertySource, value, "PropertySource", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcText? SourceDescription
	{
		get
		{
			if (_activated)
			{
				return _sourceDescription;
			}
			Activate();
			return _sourceDescription;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_sourceDescription = v;
			}, _sourceDescription, value, "SourceDescription", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcPowerMeasure MaximumValue
	{
		get
		{
			if (_activated)
			{
				return _maximumValue;
			}
			Activate();
			return _maximumValue;
		}
		set
		{
			SetValue(delegate(IfcPowerMeasure v)
			{
				_maximumValue = v;
			}, _maximumValue, value, "MaximumValue", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcPowerMeasure? MinimumValue
	{
		get
		{
			if (_activated)
			{
				return _minimumValue;
			}
			Activate();
			return _minimumValue;
		}
		set
		{
			SetValue(delegate(IfcPowerMeasure? v)
			{
				_minimumValue = v;
			}, _minimumValue, value, "MinimumValue", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public IfcTimeSeries ThermalLoadTimeSeriesValues
	{
		get
		{
			if (_activated)
			{
				return _thermalLoadTimeSeriesValues;
			}
			Activate();
			return _thermalLoadTimeSeriesValues;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTimeSeries v)
			{
				_thermalLoadTimeSeriesValues = v;
			}, _thermalLoadTimeSeriesValues, value, "ThermalLoadTimeSeriesValues", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcLabel? UserDefinedThermalLoadSource
	{
		get
		{
			if (_activated)
			{
				return _userDefinedThermalLoadSource;
			}
			Activate();
			return _userDefinedThermalLoadSource;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedThermalLoadSource = v;
			}, _userDefinedThermalLoadSource, value, "UserDefinedThermalLoadSource", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcLabel? UserDefinedPropertySource
	{
		get
		{
			if (_activated)
			{
				return _userDefinedPropertySource;
			}
			Activate();
			return _userDefinedPropertySource;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedPropertySource = v;
			}, _userDefinedPropertySource, value, "UserDefinedPropertySource", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 17)]
	public IfcThermalLoadTypeEnum ThermalLoadType
	{
		get
		{
			if (_activated)
			{
				return _thermalLoadType;
			}
			Activate();
			return _thermalLoadType;
		}
		set
		{
			SetValue(delegate(IfcThermalLoadTypeEnum v)
			{
				_thermalLoadType = v;
			}, _thermalLoadType, value, "ThermalLoadType", 14);
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
			if (ThermalLoadTimeSeriesValues != null)
			{
				yield return ThermalLoadTimeSeriesValues;
			}
		}
	}

	internal IfcSpaceThermalLoadProperties(IModel model, int label, bool activated)
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
			_applicableValueRatio = value.RealVal;
			break;
		case 5:
			_thermalLoadSource = (IfcThermalLoadSourceEnum)Enum.Parse(typeof(IfcThermalLoadSourceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_propertySource = (IfcPropertySourceEnum)Enum.Parse(typeof(IfcPropertySourceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_sourceDescription = value.StringVal;
			break;
		case 8:
			_maximumValue = value.RealVal;
			break;
		case 9:
			_minimumValue = value.RealVal;
			break;
		case 10:
			_thermalLoadTimeSeriesValues = (IfcTimeSeries)value.EntityVal;
			break;
		case 11:
			_userDefinedThermalLoadSource = value.StringVal;
			break;
		case 12:
			_userDefinedPropertySource = value.StringVal;
			break;
		case 13:
			_thermalLoadType = (IfcThermalLoadTypeEnum)Enum.Parse(typeof(IfcThermalLoadTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpaceThermalLoadProperties other)
	{
		return this == other;
	}
}
