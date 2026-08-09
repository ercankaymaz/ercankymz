using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcHumidifierType", 64)]
public class IfcHumidifierType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcHumidifierType>, IIfcHumidifierType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcHumidifierTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcHumidifierTypeEnum PredefinedType
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
			SetValue(delegate(IfcHumidifierTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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

	[CrossSchemaAttribute(typeof(IIfcHumidifierType), 10)]
	Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum IIfcHumidifierType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcHumidifierTypeEnum.ADIABATICAIRWASHER => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICAIRWASHER, 
				IfcHumidifierTypeEnum.ADIABATICATOMIZING => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICATOMIZING, 
				IfcHumidifierTypeEnum.ADIABATICCOMPRESSEDAIRNOZZLE => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICCOMPRESSEDAIRNOZZLE, 
				IfcHumidifierTypeEnum.ADIABATICPAN => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICPAN, 
				IfcHumidifierTypeEnum.ADIABATICRIGIDMEDIA => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICRIGIDMEDIA, 
				IfcHumidifierTypeEnum.ADIABATICULTRASONIC => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICULTRASONIC, 
				IfcHumidifierTypeEnum.ADIABATICWETTEDELEMENT => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICWETTEDELEMENT, 
				IfcHumidifierTypeEnum.ASSISTEDBUTANE => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDBUTANE, 
				IfcHumidifierTypeEnum.ASSISTEDELECTRIC => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDELECTRIC, 
				IfcHumidifierTypeEnum.ASSISTEDNATURALGAS => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDNATURALGAS, 
				IfcHumidifierTypeEnum.ASSISTEDPROPANE => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDPROPANE, 
				IfcHumidifierTypeEnum.ASSISTEDSTEAM => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDSTEAM, 
				IfcHumidifierTypeEnum.STEAMINJECTION => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.STEAMINJECTION, 
				IfcHumidifierTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.USERDEFINED, 
				IfcHumidifierTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.STEAMINJECTION:
				PredefinedType = IfcHumidifierTypeEnum.STEAMINJECTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICAIRWASHER:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICAIRWASHER;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICPAN:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICPAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICWETTEDELEMENT:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICWETTEDELEMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICATOMIZING:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICATOMIZING;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICULTRASONIC:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICULTRASONIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICRIGIDMEDIA:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICRIGIDMEDIA;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ADIABATICCOMPRESSEDAIRNOZZLE:
				PredefinedType = IfcHumidifierTypeEnum.ADIABATICCOMPRESSEDAIRNOZZLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDELECTRIC:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDELECTRIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDNATURALGAS:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDNATURALGAS;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDPROPANE:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDPROPANE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDBUTANE:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDBUTANE;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.ASSISTEDSTEAM:
				PredefinedType = IfcHumidifierTypeEnum.ASSISTEDSTEAM;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.USERDEFINED:
				PredefinedType = IfcHumidifierTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcHumidifierTypeEnum.NOTDEFINED:
				PredefinedType = IfcHumidifierTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcHumidifierType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcHumidifierTypeEnum)Enum.Parse(typeof(IfcHumidifierTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcHumidifierType other)
	{
		return this == other;
	}
}
