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

namespace Xbim.Ifc4x3.SharedComponentElements;

[ExpressType("IfcMechanicalFastenerType", 643)]
public class IfcMechanicalFastenerType : IfcElementComponentType, IIfcMechanicalFastenerType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMechanicalFastenerType>
{
	private IfcMechanicalFastenerTypeEnum _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _nominalDiameter;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _nominalLength;

	[CrossSchemaAttribute(typeof(IIfcMechanicalFastenerType), 10)]
	Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum IIfcMechanicalFastenerType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcMechanicalFastenerTypeEnum.ANCHORBOLT => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.ANCHORBOLT, 
				IfcMechanicalFastenerTypeEnum.BOLT => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.BOLT, 
				IfcMechanicalFastenerTypeEnum.CHAIN => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum>(), 
				IfcMechanicalFastenerTypeEnum.COUPLER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum>(), 
				IfcMechanicalFastenerTypeEnum.DOWEL => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.DOWEL, 
				IfcMechanicalFastenerTypeEnum.NAIL => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.NAIL, 
				IfcMechanicalFastenerTypeEnum.NAILPLATE => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.NAILPLATE, 
				IfcMechanicalFastenerTypeEnum.RAILFASTENING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum>(), 
				IfcMechanicalFastenerTypeEnum.RAILJOINT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum>(), 
				IfcMechanicalFastenerTypeEnum.RIVET => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.RIVET, 
				IfcMechanicalFastenerTypeEnum.ROPE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum>(), 
				IfcMechanicalFastenerTypeEnum.SCREW => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.SCREW, 
				IfcMechanicalFastenerTypeEnum.SHEARCONNECTOR => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.SHEARCONNECTOR, 
				IfcMechanicalFastenerTypeEnum.STAPLE => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.STAPLE, 
				IfcMechanicalFastenerTypeEnum.STUDSHEARCONNECTOR => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.STUDSHEARCONNECTOR, 
				IfcMechanicalFastenerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.USERDEFINED, 
				IfcMechanicalFastenerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.ANCHORBOLT:
				PredefinedType = IfcMechanicalFastenerTypeEnum.ANCHORBOLT;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.BOLT:
				PredefinedType = IfcMechanicalFastenerTypeEnum.BOLT;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.DOWEL:
				PredefinedType = IfcMechanicalFastenerTypeEnum.DOWEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.NAIL:
				PredefinedType = IfcMechanicalFastenerTypeEnum.NAIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.NAILPLATE:
				PredefinedType = IfcMechanicalFastenerTypeEnum.NAILPLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.RIVET:
				PredefinedType = IfcMechanicalFastenerTypeEnum.RIVET;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.SCREW:
				PredefinedType = IfcMechanicalFastenerTypeEnum.SCREW;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.SHEARCONNECTOR:
				PredefinedType = IfcMechanicalFastenerTypeEnum.SHEARCONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.STAPLE:
				PredefinedType = IfcMechanicalFastenerTypeEnum.STAPLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.STUDSHEARCONNECTOR:
				PredefinedType = IfcMechanicalFastenerTypeEnum.STUDSHEARCONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.USERDEFINED:
				PredefinedType = IfcMechanicalFastenerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcMechanicalFastenerTypeEnum.NOTDEFINED:
				PredefinedType = IfcMechanicalFastenerTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMechanicalFastenerType), 11)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcMechanicalFastenerType.NominalDiameter
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

	[CrossSchemaAttribute(typeof(IIfcMechanicalFastenerType), 12)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcMechanicalFastenerType.NominalLength
	{
		get
		{
			if (!NominalLength.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(NominalLength.Value);
		}
		set
		{
			NominalLength = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcMechanicalFastenerTypeEnum PredefinedType
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
			SetValue(delegate(IfcMechanicalFastenerTypeEnum v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? NominalLength
	{
		get
		{
			if (_activated)
			{
				return _nominalLength;
			}
			Activate();
			return _nominalLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_nominalLength = v;
			}, _nominalLength, value, "NominalLength", 12);
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

	internal IfcMechanicalFastenerType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcMechanicalFastenerTypeEnum)Enum.Parse(typeof(IfcMechanicalFastenerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_nominalDiameter = value.RealVal;
			break;
		case 11:
			_nominalLength = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMechanicalFastenerType other)
	{
		return this == other;
	}
}
