using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcOpticalMaterialProperties", 718)]
public class IfcOpticalMaterialProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcOpticalMaterialProperties>
{
	private IfcPositiveRatioMeasure? _visibleTransmittance;

	private IfcPositiveRatioMeasure? _solarTransmittance;

	private IfcPositiveRatioMeasure? _thermalIrTransmittance;

	private IfcPositiveRatioMeasure? _thermalIrEmissivityBack;

	private IfcPositiveRatioMeasure? _thermalIrEmissivityFront;

	private IfcPositiveRatioMeasure? _visibleReflectanceBack;

	private IfcPositiveRatioMeasure? _visibleReflectanceFront;

	private IfcPositiveRatioMeasure? _solarReflectanceFront;

	private IfcPositiveRatioMeasure? _solarReflectanceBack;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcPositiveRatioMeasure? VisibleTransmittance
	{
		get
		{
			if (_activated)
			{
				return _visibleTransmittance;
			}
			Activate();
			return _visibleTransmittance;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_visibleTransmittance = v;
			}, _visibleTransmittance, value, "VisibleTransmittance", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcPositiveRatioMeasure? SolarTransmittance
	{
		get
		{
			if (_activated)
			{
				return _solarTransmittance;
			}
			Activate();
			return _solarTransmittance;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_solarTransmittance = v;
			}, _solarTransmittance, value, "SolarTransmittance", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveRatioMeasure? ThermalIrTransmittance
	{
		get
		{
			if (_activated)
			{
				return _thermalIrTransmittance;
			}
			Activate();
			return _thermalIrTransmittance;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_thermalIrTransmittance = v;
			}, _thermalIrTransmittance, value, "ThermalIrTransmittance", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveRatioMeasure? ThermalIrEmissivityBack
	{
		get
		{
			if (_activated)
			{
				return _thermalIrEmissivityBack;
			}
			Activate();
			return _thermalIrEmissivityBack;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_thermalIrEmissivityBack = v;
			}, _thermalIrEmissivityBack, value, "ThermalIrEmissivityBack", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveRatioMeasure? ThermalIrEmissivityFront
	{
		get
		{
			if (_activated)
			{
				return _thermalIrEmissivityFront;
			}
			Activate();
			return _thermalIrEmissivityFront;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_thermalIrEmissivityFront = v;
			}, _thermalIrEmissivityFront, value, "ThermalIrEmissivityFront", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveRatioMeasure? VisibleReflectanceBack
	{
		get
		{
			if (_activated)
			{
				return _visibleReflectanceBack;
			}
			Activate();
			return _visibleReflectanceBack;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_visibleReflectanceBack = v;
			}, _visibleReflectanceBack, value, "VisibleReflectanceBack", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveRatioMeasure? VisibleReflectanceFront
	{
		get
		{
			if (_activated)
			{
				return _visibleReflectanceFront;
			}
			Activate();
			return _visibleReflectanceFront;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_visibleReflectanceFront = v;
			}, _visibleReflectanceFront, value, "VisibleReflectanceFront", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcPositiveRatioMeasure? SolarReflectanceFront
	{
		get
		{
			if (_activated)
			{
				return _solarReflectanceFront;
			}
			Activate();
			return _solarReflectanceFront;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_solarReflectanceFront = v;
			}, _solarReflectanceFront, value, "SolarReflectanceFront", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcPositiveRatioMeasure? SolarReflectanceBack
	{
		get
		{
			if (_activated)
			{
				return _solarReflectanceBack;
			}
			Activate();
			return _solarReflectanceBack;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_solarReflectanceBack = v;
			}, _solarReflectanceBack, value, "SolarReflectanceBack", 10);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Material != null)
			{
				yield return base.Material;
			}
		}
	}

	internal IfcOpticalMaterialProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_visibleTransmittance = value.RealVal;
			break;
		case 2:
			_solarTransmittance = value.RealVal;
			break;
		case 3:
			_thermalIrTransmittance = value.RealVal;
			break;
		case 4:
			_thermalIrEmissivityBack = value.RealVal;
			break;
		case 5:
			_thermalIrEmissivityFront = value.RealVal;
			break;
		case 6:
			_visibleReflectanceBack = value.RealVal;
			break;
		case 7:
			_visibleReflectanceFront = value.RealVal;
			break;
		case 8:
			_solarReflectanceFront = value.RealVal;
			break;
		case 9:
			_solarReflectanceBack = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOpticalMaterialProperties other)
	{
		return this == other;
	}
}
