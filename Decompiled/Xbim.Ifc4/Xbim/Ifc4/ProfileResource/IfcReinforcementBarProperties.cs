using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcReinforcementBarProperties", 684)]
public class IfcReinforcementBarProperties : IfcPreDefinedProperties, IInstantiableEntity, IPersistEntity, IPersist, IIfcReinforcementBarProperties, IIfcPreDefinedProperties, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcReinforcementBarProperties>
{
	private IfcAreaMeasure _totalCrossSectionArea;

	private IfcLabel _steelGrade;

	private IfcReinforcingBarSurfaceEnum? _barSurface;

	private IfcLengthMeasure? _effectiveDepth;

	private IfcPositiveLengthMeasure? _nominalBarDiameter;

	private IfcCountMeasure? _barCount;

	IfcAreaMeasure IIfcReinforcementBarProperties.TotalCrossSectionArea
	{
		get
		{
			return TotalCrossSectionArea;
		}
		set
		{
			TotalCrossSectionArea = value;
		}
	}

	IfcLabel IIfcReinforcementBarProperties.SteelGrade
	{
		get
		{
			return SteelGrade;
		}
		set
		{
			SteelGrade = value;
		}
	}

	IfcReinforcingBarSurfaceEnum? IIfcReinforcementBarProperties.BarSurface
	{
		get
		{
			return BarSurface;
		}
		set
		{
			BarSurface = value;
		}
	}

	IfcLengthMeasure? IIfcReinforcementBarProperties.EffectiveDepth
	{
		get
		{
			return EffectiveDepth;
		}
		set
		{
			EffectiveDepth = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcReinforcementBarProperties.NominalBarDiameter
	{
		get
		{
			return NominalBarDiameter;
		}
		set
		{
			NominalBarDiameter = value;
		}
	}

	IfcCountMeasure? IIfcReinforcementBarProperties.BarCount
	{
		get
		{
			return BarCount;
		}
		set
		{
			BarCount = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcAreaMeasure TotalCrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _totalCrossSectionArea;
			}
			Activate();
			return _totalCrossSectionArea;
		}
		set
		{
			SetValue(delegate(IfcAreaMeasure v)
			{
				_totalCrossSectionArea = v;
			}, _totalCrossSectionArea, value, "TotalCrossSectionArea", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel SteelGrade
	{
		get
		{
			if (_activated)
			{
				return _steelGrade;
			}
			Activate();
			return _steelGrade;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_steelGrade = v;
			}, _steelGrade, value, "SteelGrade", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 4)]
	public IfcReinforcingBarSurfaceEnum? BarSurface
	{
		get
		{
			if (_activated)
			{
				return _barSurface;
			}
			Activate();
			return _barSurface;
		}
		set
		{
			SetValue(delegate(IfcReinforcingBarSurfaceEnum? v)
			{
				_barSurface = v;
			}, _barSurface, value, "BarSurface", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure? EffectiveDepth
	{
		get
		{
			if (_activated)
			{
				return _effectiveDepth;
			}
			Activate();
			return _effectiveDepth;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_effectiveDepth = v;
			}, _effectiveDepth, value, "EffectiveDepth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure? NominalBarDiameter
	{
		get
		{
			if (_activated)
			{
				return _nominalBarDiameter;
			}
			Activate();
			return _nominalBarDiameter;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_nominalBarDiameter = v;
			}, _nominalBarDiameter, value, "NominalBarDiameter", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcCountMeasure? BarCount
	{
		get
		{
			if (_activated)
			{
				return _barCount;
			}
			Activate();
			return _barCount;
		}
		set
		{
			SetValue(delegate(IfcCountMeasure? v)
			{
				_barCount = v;
			}, _barCount, value, "BarCount", 6);
		}
	}

	internal IfcReinforcementBarProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_totalCrossSectionArea = value.RealVal;
			break;
		case 1:
			_steelGrade = value.StringVal;
			break;
		case 2:
			_barSurface = (IfcReinforcingBarSurfaceEnum)Enum.Parse(typeof(IfcReinforcingBarSurfaceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 3:
			_effectiveDepth = value.RealVal;
			break;
		case 4:
			_nominalBarDiameter = value.RealVal;
			break;
		case 5:
			_barCount = value.NumberVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcementBarProperties other)
	{
		return this == other;
	}
}
