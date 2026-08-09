using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.ProfileResource;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcReinforcingBarType", 1245)]
public class IfcReinforcingBarType : IfcReinforcingElementType, IIfcReinforcingBarType, IIfcReinforcingElementType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReinforcingBarType>
{
	private IItemSet<IIfcBendingParameterSelect> _bendingParametersIfc4;

	private IfcReinforcingBarTypeEnum _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _nominalDiameter;

	private Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? _crossSectionArea;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _barLength;

	private Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum? _barSurface;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _bendingShapeCode;

	private readonly OptionalItemSet<IfcBendingParameterSelect> _bendingParameters;

	[CrossSchemaAttribute(typeof(IIfcReinforcingBarType), 10)]
	Xbim.Ifc4.Interfaces.IfcReinforcingBarTypeEnum IIfcReinforcingBarType.PredefinedType
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBarType), 11)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingBarType.NominalDiameter
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingBarType), 12)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcReinforcingBarType.CrossSectionArea
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingBarType), 13)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingBarType.BarLength
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingBarType), 14)]
	Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum? IIfcReinforcingBarType.BarSurface
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingBarType), 15)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcReinforcingBarType.BendingShapeCode
	{
		get
		{
			if (!BendingShapeCode.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(BendingShapeCode.Value);
		}
		set
		{
			BendingShapeCode = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBarType), 16)]
	IItemSet<IIfcBendingParameterSelect> IIfcReinforcingBarType.BendingParameters => _bendingParametersIfc4 ?? (_bendingParametersIfc4 = new ExtendedItemSet<IfcBendingParameterSelect, IIfcBendingParameterSelect>(BendingParameters, new ItemSet<IIfcBendingParameterSelect>(this, 0, -16), BendingParametersToIfc4, BendingParametersToIfc2X3));

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcReinforcingBarTypeEnum PredefinedType
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
			SetValue(delegate(IfcReinforcingBarTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
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
			}, _nominalDiameter, value, "NominalDiameter", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
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
			}, _crossSectionArea, value, "CrossSectionArea", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
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
			}, _barLength, value, "BarLength", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
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

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? BendingShapeCode
	{
		get
		{
			if (_activated)
			{
				return _bendingShapeCode;
			}
			Activate();
			return _bendingShapeCode;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_bendingShapeCode = v;
			}, _bendingShapeCode, value, "BendingShapeCode", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 25)]
	public IOptionalItemSet<IfcBendingParameterSelect> BendingParameters
	{
		get
		{
			if (_activated)
			{
				return _bendingParameters;
			}
			Activate();
			return _bendingParameters;
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	private static IIfcBendingParameterSelect BendingParametersToIfc4(IfcBendingParameterSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcLengthMeasure"))
		{
			if (name == "IfcPlaneAngleMeasure")
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)(object)member);
			}
			throw new NotSupportedException();
		}
		return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)member);
	}

	private static IfcBendingParameterSelect BendingParametersToIfc2X3(IIfcBendingParameterSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcLengthMeasure"))
		{
			if (name == "IfcPlaneAngleMeasure")
			{
				return new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)member);
			}
			throw new NotSupportedException();
		}
		return new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)member);
	}

	internal IfcReinforcingBarType(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_bendingParameters = new OptionalItemSet<IfcBendingParameterSelect>(this, 0, 16);
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
			_predefinedType = (IfcReinforcingBarTypeEnum)Enum.Parse(typeof(IfcReinforcingBarTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_nominalDiameter = value.RealVal;
			break;
		case 11:
			_crossSectionArea = value.RealVal;
			break;
		case 12:
			_barLength = value.RealVal;
			break;
		case 13:
			_barSurface = (Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum)Enum.Parse(typeof(Xbim.Ifc4x3.ProfileResource.IfcReinforcingBarSurfaceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 14:
			_bendingShapeCode = value.StringVal;
			break;
		case 15:
			_bendingParameters.InternalAdd((IfcBendingParameterSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingBarType other)
	{
		return this == other;
	}
}
