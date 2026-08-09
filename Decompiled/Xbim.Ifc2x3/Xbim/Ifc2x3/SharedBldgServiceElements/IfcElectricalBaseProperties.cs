using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.SharedBldgServiceElements;

[ExpressType("IfcElectricalBaseProperties", 177)]
public class IfcElectricalBaseProperties : IfcEnergyProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcElectricalBaseProperties>
{
	private IfcElectricCurrentEnum? _electricCurrentType;

	private IfcElectricVoltageMeasure _inputVoltage;

	private IfcFrequencyMeasure _inputFrequency;

	private IfcElectricCurrentMeasure? _fullLoadCurrent;

	private IfcElectricCurrentMeasure? _minimumCircuitCurrent;

	private IfcPowerMeasure? _maximumPowerInput;

	private IfcPowerMeasure? _ratedPowerInput;

	private long _inputPhase;

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcElectricCurrentEnum? ElectricCurrentType
	{
		get
		{
			if (_activated)
			{
				return _electricCurrentType;
			}
			Activate();
			return _electricCurrentType;
		}
		set
		{
			SetValue(delegate(IfcElectricCurrentEnum? v)
			{
				_electricCurrentType = v;
			}, _electricCurrentType, value, "ElectricCurrentType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcElectricVoltageMeasure InputVoltage
	{
		get
		{
			if (_activated)
			{
				return _inputVoltage;
			}
			Activate();
			return _inputVoltage;
		}
		set
		{
			SetValue(delegate(IfcElectricVoltageMeasure v)
			{
				_inputVoltage = v;
			}, _inputVoltage, value, "InputVoltage", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcFrequencyMeasure InputFrequency
	{
		get
		{
			if (_activated)
			{
				return _inputFrequency;
			}
			Activate();
			return _inputFrequency;
		}
		set
		{
			SetValue(delegate(IfcFrequencyMeasure v)
			{
				_inputFrequency = v;
			}, _inputFrequency, value, "InputFrequency", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcElectricCurrentMeasure? FullLoadCurrent
	{
		get
		{
			if (_activated)
			{
				return _fullLoadCurrent;
			}
			Activate();
			return _fullLoadCurrent;
		}
		set
		{
			SetValue(delegate(IfcElectricCurrentMeasure? v)
			{
				_fullLoadCurrent = v;
			}, _fullLoadCurrent, value, "FullLoadCurrent", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcElectricCurrentMeasure? MinimumCircuitCurrent
	{
		get
		{
			if (_activated)
			{
				return _minimumCircuitCurrent;
			}
			Activate();
			return _minimumCircuitCurrent;
		}
		set
		{
			SetValue(delegate(IfcElectricCurrentMeasure? v)
			{
				_minimumCircuitCurrent = v;
			}, _minimumCircuitCurrent, value, "MinimumCircuitCurrent", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcPowerMeasure? MaximumPowerInput
	{
		get
		{
			if (_activated)
			{
				return _maximumPowerInput;
			}
			Activate();
			return _maximumPowerInput;
		}
		set
		{
			SetValue(delegate(IfcPowerMeasure? v)
			{
				_maximumPowerInput = v;
			}, _maximumPowerInput, value, "MaximumPowerInput", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcPowerMeasure? RatedPowerInput
	{
		get
		{
			if (_activated)
			{
				return _ratedPowerInput;
			}
			Activate();
			return _ratedPowerInput;
		}
		set
		{
			SetValue(delegate(IfcPowerMeasure? v)
			{
				_ratedPowerInput = v;
			}, _ratedPowerInput, value, "RatedPowerInput", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public long InputPhase
	{
		get
		{
			if (_activated)
			{
				return _inputPhase;
			}
			Activate();
			return _inputPhase;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_inputPhase = v;
			}, _inputPhase, value, "InputPhase", 14);
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

	internal IfcElectricalBaseProperties(IModel model, int label, bool activated)
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
		case 4:
		case 5:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_electricCurrentType = (IfcElectricCurrentEnum)Enum.Parse(typeof(IfcElectricCurrentEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_inputVoltage = value.RealVal;
			break;
		case 8:
			_inputFrequency = value.RealVal;
			break;
		case 9:
			_fullLoadCurrent = value.RealVal;
			break;
		case 10:
			_minimumCircuitCurrent = value.RealVal;
			break;
		case 11:
			_maximumPowerInput = value.RealVal;
			break;
		case 12:
			_ratedPowerInput = value.RealVal;
			break;
		case 13:
			_inputPhase = value.IntegerVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricalBaseProperties other)
	{
		return this == other;
	}
}
