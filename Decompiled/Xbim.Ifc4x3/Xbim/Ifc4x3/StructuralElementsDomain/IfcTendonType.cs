using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcTendonType", 1298)]
public class IfcTendonType : IfcReinforcingElementType, IIfcTendonType, IIfcReinforcingElementType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTendonType>
{
	private IfcTendonTypeEnum _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _nominalDiameter;

	private Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? _crossSectionArea;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _sheathDiameter;

	[CrossSchemaAttribute(typeof(IIfcTendonType), 10)]
	Xbim.Ifc4.Interfaces.IfcTendonTypeEnum IIfcTendonType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcTendonTypeEnum.BAR => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.BAR, 
				IfcTendonTypeEnum.COATED => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.COATED, 
				IfcTendonTypeEnum.STRAND => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.STRAND, 
				IfcTendonTypeEnum.WIRE => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.WIRE, 
				IfcTendonTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.USERDEFINED, 
				IfcTendonTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.BAR:
				PredefinedType = IfcTendonTypeEnum.BAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.COATED:
				PredefinedType = IfcTendonTypeEnum.COATED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.STRAND:
				PredefinedType = IfcTendonTypeEnum.STRAND;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.WIRE:
				PredefinedType = IfcTendonTypeEnum.WIRE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.USERDEFINED:
				PredefinedType = IfcTendonTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTendonTypeEnum.NOTDEFINED:
				PredefinedType = IfcTendonTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTendonType), 11)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcTendonType.NominalDiameter
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

	[CrossSchemaAttribute(typeof(IIfcTendonType), 12)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcTendonType.CrossSectionArea
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

	[CrossSchemaAttribute(typeof(IIfcTendonType), 13)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcTendonType.SheathDiameter
	{
		get
		{
			if (!SheathDiameter.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(SheathDiameter.Value);
		}
		set
		{
			SheathDiameter = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcTendonTypeEnum PredefinedType
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
			SetValue(delegate(IfcTendonTypeEnum v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? SheathDiameter
	{
		get
		{
			if (_activated)
			{
				return _sheathDiameter;
			}
			Activate();
			return _sheathDiameter;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_sheathDiameter = v;
			}, _sheathDiameter, value, "SheathDiameter", 13);
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

	internal IfcTendonType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcTendonTypeEnum)Enum.Parse(typeof(IfcTendonTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_nominalDiameter = value.RealVal;
			break;
		case 11:
			_crossSectionArea = value.RealVal;
			break;
		case 12:
			_sheathDiameter = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTendonType other)
	{
		return this == other;
	}
}
