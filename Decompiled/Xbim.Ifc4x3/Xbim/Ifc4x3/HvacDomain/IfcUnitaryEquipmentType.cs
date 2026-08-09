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

[ExpressType("IfcUnitaryEquipmentType", 234)]
public class IfcUnitaryEquipmentType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcUnitaryEquipmentType>, IIfcUnitaryEquipmentType, IIfcEnergyConversionDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcUnitaryEquipmentTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcUnitaryEquipmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcUnitaryEquipmentTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcUnitaryEquipmentType), 10)]
	Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum IIfcUnitaryEquipmentType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcUnitaryEquipmentTypeEnum.AIRCONDITIONINGUNIT => Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.AIRCONDITIONINGUNIT, 
				IfcUnitaryEquipmentTypeEnum.AIRHANDLER => Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.AIRHANDLER, 
				IfcUnitaryEquipmentTypeEnum.DEHUMIDIFIER => Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.DEHUMIDIFIER, 
				IfcUnitaryEquipmentTypeEnum.ROOFTOPUNIT => Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.ROOFTOPUNIT, 
				IfcUnitaryEquipmentTypeEnum.SPLITSYSTEM => Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.SPLITSYSTEM, 
				IfcUnitaryEquipmentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.USERDEFINED, 
				IfcUnitaryEquipmentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.AIRHANDLER:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.AIRHANDLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.AIRCONDITIONINGUNIT:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.AIRCONDITIONINGUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.DEHUMIDIFIER:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.DEHUMIDIFIER;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.SPLITSYSTEM:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.SPLITSYSTEM;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.ROOFTOPUNIT:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.ROOFTOPUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.USERDEFINED:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitaryEquipmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcUnitaryEquipmentTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcUnitaryEquipmentType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcUnitaryEquipmentTypeEnum)Enum.Parse(typeof(IfcUnitaryEquipmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcUnitaryEquipmentType other)
	{
		return this == other;
	}
}
