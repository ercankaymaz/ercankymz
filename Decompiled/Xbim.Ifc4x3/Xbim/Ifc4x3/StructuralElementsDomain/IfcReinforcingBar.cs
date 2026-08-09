using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProfileResource;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcReinforcingBar", 571)]
public class IfcReinforcingBar : IfcReinforcingElement, IIfcReinforcingBar, IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReinforcingBar>
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _nominalDiameter;

	private Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? _crossSectionArea;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _barLength;

	private IfcReinforcingBarTypeEnum? _predefinedType;

	private Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum? _barSurface;

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 10)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingBar.NominalDiameter
	{
		get
		{
			if (!NominalDiameter.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(NominalDiameter.Value);
		}
		set
		{
			NominalDiameter = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 11)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcReinforcingBar.CrossSectionArea
	{
		get
		{
			if (!CrossSectionArea.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(CrossSectionArea.Value);
		}
		set
		{
			CrossSectionArea = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 12)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingBar.BarLength
	{
		get
		{
			if (!BarLength.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(BarLength.Value);
		}
		set
		{
			BarLength = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 13)]
	Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum? IIfcReinforcingBar.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcReinforcingBarTypeEnum.ANCHORING => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.ANCHORING, 
				IfcReinforcingBarTypeEnum.EDGE => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.EDGE, 
				IfcReinforcingBarTypeEnum.LIGATURE => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.LIGATURE, 
				IfcReinforcingBarTypeEnum.MAIN => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.MAIN, 
				IfcReinforcingBarTypeEnum.PUNCHING => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.PUNCHING, 
				IfcReinforcingBarTypeEnum.RING => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.RING, 
				IfcReinforcingBarTypeEnum.SHEAR => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.SHEAR, 
				IfcReinforcingBarTypeEnum.SPACEBAR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum>(), 
				IfcReinforcingBarTypeEnum.STUD => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.STUD, 
				IfcReinforcingBarTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.USERDEFINED, 
				IfcReinforcingBarTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.ANCHORING:
				PredefinedType = IfcReinforcingBarTypeEnum.ANCHORING;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.EDGE:
				PredefinedType = IfcReinforcingBarTypeEnum.EDGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.LIGATURE:
				PredefinedType = IfcReinforcingBarTypeEnum.LIGATURE;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.MAIN:
				PredefinedType = IfcReinforcingBarTypeEnum.MAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.PUNCHING:
				PredefinedType = IfcReinforcingBarTypeEnum.PUNCHING;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.RING:
				PredefinedType = IfcReinforcingBarTypeEnum.RING;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.SHEAR:
				PredefinedType = IfcReinforcingBarTypeEnum.SHEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.STUD:
				PredefinedType = IfcReinforcingBarTypeEnum.STUD;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.USERDEFINED:
				PredefinedType = IfcReinforcingBarTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum.NOTDEFINED:
				PredefinedType = IfcReinforcingBarTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 14)]
	Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum? IIfcReinforcingBar.BarSurface
	{
		get
		{
			return BarSurface switch
			{
				Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum.PLAIN => Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.PLAIN, 
				Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum.TEXTURED => Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.TEXTURED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.PLAIN:
				BarSurface = Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum.PLAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.TEXTURED:
				BarSurface = Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum.TEXTURED;
				break;
			case null:
				BarSurface = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? NominalDiameter
	{
		get
		{
			if (_activated)
			{
				return _nominalDiameter;
			}
			Activate();
			return _nominalDiameter;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_nominalDiameter = v;
			}, _nominalDiameter, value, "NominalDiameter", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 37)]
	public Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? CrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _crossSectionArea;
			}
			Activate();
			return _crossSectionArea;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? v)
			{
				_crossSectionArea = v;
			}, _crossSectionArea, value, "CrossSectionArea", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 38)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? BarLength
	{
		get
		{
			if (_activated)
			{
				return _barLength;
			}
			Activate();
			return _barLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_barLength = v;
			}, _barLength, value, "BarLength", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 39)]
	public IfcReinforcingBarTypeEnum? PredefinedType
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
			SetValue(delegate(IfcReinforcingBarTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 40)]
	public Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum? BarSurface
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
			SetValue(delegate(Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum? v)
			{
				_barSurface = v;
			}, _barSurface, value, "BarSurface", 14);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcReinforcingBar(IModel model, int label, bool activated)
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
		case 6:
		case 7:
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_nominalDiameter = value.RealVal;
			break;
		case 10:
			_crossSectionArea = value.RealVal;
			break;
		case 11:
			_barLength = value.RealVal;
			break;
		case 12:
			_predefinedType = (IfcReinforcingBarTypeEnum)Enum.Parse(typeof(IfcReinforcingBarTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 13:
			_barSurface = (Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum)Enum.Parse(typeof(Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingBar other)
	{
		return this == other;
	}
}
