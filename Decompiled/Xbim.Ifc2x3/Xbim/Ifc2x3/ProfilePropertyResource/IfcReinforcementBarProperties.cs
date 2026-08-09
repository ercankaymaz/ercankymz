using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfilePropertyResource;

[ExpressType("IfcReinforcementBarProperties", 684)]
public class IfcReinforcementBarProperties : PersistEntity, IIfcReinforcementBarProperties, IIfcPreDefinedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IEquatable<IfcReinforcementBarProperties>
{
	private Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure _totalCrossSectionArea;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _steelGrade;

	private IfcReinforcingBarSurfaceEnum? _barSurface;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _effectiveDepth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _nominalBarDiameter;

	private Xbim.Ifc2x3.MeasureResource.IfcCountMeasure? _barCount;

	[CrossSchemaAttribute(typeof(IIfcReinforcementBarProperties), 1)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure IIfcReinforcementBarProperties.TotalCrossSectionArea
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(TotalCrossSectionArea);
		}
		set
		{
			TotalCrossSectionArea = new Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcementBarProperties), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcReinforcementBarProperties.SteelGrade
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(SteelGrade);
		}
		set
		{
			SteelGrade = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcementBarProperties), 3)]
	Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum? IIfcReinforcementBarProperties.BarSurface
	{
		get
		{
			return BarSurface switch
			{
				IfcReinforcingBarSurfaceEnum.PLAIN => Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.PLAIN, 
				IfcReinforcingBarSurfaceEnum.TEXTURED => Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.TEXTURED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.PLAIN:
				BarSurface = IfcReinforcingBarSurfaceEnum.PLAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.TEXTURED:
				BarSurface = IfcReinforcingBarSurfaceEnum.TEXTURED;
				break;
			case null:
				BarSurface = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcementBarProperties), 4)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcReinforcementBarProperties.EffectiveDepth
	{
		get
		{
			if (!EffectiveDepth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(EffectiveDepth.Value);
		}
		set
		{
			EffectiveDepth = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcementBarProperties), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcementBarProperties.NominalBarDiameter
	{
		get
		{
			if (!NominalBarDiameter.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(NominalBarDiameter.Value);
		}
		set
		{
			NominalBarDiameter = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcementBarProperties), 6)]
	Xbim.Ifc4.MeasureResource.IfcCountMeasure? IIfcReinforcementBarProperties.BarCount
	{
		get
		{
			if (!BarCount.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcCountMeasure(BarCount.Value);
		}
		set
		{
			BarCount = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcCountMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcCountMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcCountMeasure?)null));
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure TotalCrossSectionArea
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure v)
			{
				_totalCrossSectionArea = v;
			}, _totalCrossSectionArea, value, "TotalCrossSectionArea", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel SteelGrade
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_steelGrade = v;
			}, _steelGrade, value, "SteelGrade", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
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

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? EffectiveDepth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_effectiveDepth = v;
			}, _effectiveDepth, value, "EffectiveDepth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? NominalBarDiameter
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_nominalBarDiameter = v;
			}, _nominalBarDiameter, value, "NominalBarDiameter", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcCountMeasure? BarCount
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcCountMeasure? v)
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
