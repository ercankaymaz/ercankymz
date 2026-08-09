using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ElectricalDomain;

[ExpressType("IfcElectricFlowStorageDeviceType", 372)]
public class IfcElectricFlowStorageDeviceType : IfcFlowStorageDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricFlowStorageDeviceType>, IIfcElectricFlowStorageDeviceType, IIfcFlowStorageDeviceType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcElectricFlowStorageDeviceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcElectricFlowStorageDeviceTypeEnum PredefinedType
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
			SetValue(delegate(IfcElectricFlowStorageDeviceTypeEnum v)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcElectricFlowStorageDeviceType), 10)]
	Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum IIfcElectricFlowStorageDeviceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElectricFlowStorageDeviceTypeEnum.BATTERY => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.BATTERY, 
				IfcElectricFlowStorageDeviceTypeEnum.CAPACITORBANK => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.CAPACITORBANK, 
				IfcElectricFlowStorageDeviceTypeEnum.HARMONICFILTER => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.HARMONICFILTER, 
				IfcElectricFlowStorageDeviceTypeEnum.INDUCTORBANK => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.INDUCTORBANK, 
				IfcElectricFlowStorageDeviceTypeEnum.UPS => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.UPS, 
				IfcElectricFlowStorageDeviceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.USERDEFINED, 
				IfcElectricFlowStorageDeviceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.BATTERY:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.BATTERY;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.CAPACITORBANK:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.CAPACITORBANK;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.HARMONICFILTER:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.HARMONICFILTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.INDUCTORBANK:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.INDUCTORBANK;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.UPS:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.UPS;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.USERDEFINED:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricFlowStorageDeviceTypeEnum.NOTDEFINED:
				PredefinedType = IfcElectricFlowStorageDeviceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricFlowStorageDeviceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricFlowStorageDeviceTypeEnum)Enum.Parse(typeof(IfcElectricFlowStorageDeviceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricFlowStorageDeviceType other)
	{
		return this == other;
	}
}
