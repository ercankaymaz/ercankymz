using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcElectricApplianceType", 192)]
public class IfcElectricApplianceType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricApplianceType>, IIfcElectricApplianceType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect
{
	private IfcElectricApplianceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcElectricApplianceTypeEnum PredefinedType
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
			SetValue(delegate(IfcElectricApplianceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcElectricApplianceType), 10)]
	Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum IIfcElectricApplianceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElectricApplianceTypeEnum.DISHWASHER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.DISHWASHER, 
				IfcElectricApplianceTypeEnum.ELECTRICCOOKER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.ELECTRICCOOKER, 
				IfcElectricApplianceTypeEnum.FREESTANDINGELECTRICHEATER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGELECTRICHEATER, 
				IfcElectricApplianceTypeEnum.FREESTANDINGFAN => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGFAN, 
				IfcElectricApplianceTypeEnum.FREESTANDINGWATERCOOLER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGWATERCOOLER, 
				IfcElectricApplianceTypeEnum.FREESTANDINGWATERHEATER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGWATERHEATER, 
				IfcElectricApplianceTypeEnum.FREEZER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREEZER, 
				IfcElectricApplianceTypeEnum.FRIDGE_FREEZER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FRIDGE_FREEZER, 
				IfcElectricApplianceTypeEnum.HANDDRYER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.HANDDRYER, 
				IfcElectricApplianceTypeEnum.KITCHENMACHINE => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.KITCHENMACHINE, 
				IfcElectricApplianceTypeEnum.MICROWAVE => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.MICROWAVE, 
				IfcElectricApplianceTypeEnum.PHOTOCOPIER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.PHOTOCOPIER, 
				IfcElectricApplianceTypeEnum.REFRIGERATOR => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.REFRIGERATOR, 
				IfcElectricApplianceTypeEnum.TUMBLEDRYER => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.TUMBLEDRYER, 
				IfcElectricApplianceTypeEnum.VENDINGMACHINE => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.VENDINGMACHINE, 
				IfcElectricApplianceTypeEnum.WASHINGMACHINE => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.WASHINGMACHINE, 
				IfcElectricApplianceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED, 
				IfcElectricApplianceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.DISHWASHER:
				PredefinedType = IfcElectricApplianceTypeEnum.DISHWASHER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.ELECTRICCOOKER:
				PredefinedType = IfcElectricApplianceTypeEnum.ELECTRICCOOKER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGELECTRICHEATER:
				PredefinedType = IfcElectricApplianceTypeEnum.FREESTANDINGELECTRICHEATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGFAN:
				PredefinedType = IfcElectricApplianceTypeEnum.FREESTANDINGFAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGWATERHEATER:
				PredefinedType = IfcElectricApplianceTypeEnum.FREESTANDINGWATERHEATER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGWATERCOOLER:
				PredefinedType = IfcElectricApplianceTypeEnum.FREESTANDINGWATERCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREEZER:
				PredefinedType = IfcElectricApplianceTypeEnum.FREEZER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FRIDGE_FREEZER:
				PredefinedType = IfcElectricApplianceTypeEnum.FRIDGE_FREEZER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.HANDDRYER:
				PredefinedType = IfcElectricApplianceTypeEnum.HANDDRYER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.KITCHENMACHINE:
				PredefinedType = IfcElectricApplianceTypeEnum.KITCHENMACHINE;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.MICROWAVE:
				PredefinedType = IfcElectricApplianceTypeEnum.MICROWAVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.PHOTOCOPIER:
				PredefinedType = IfcElectricApplianceTypeEnum.PHOTOCOPIER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.REFRIGERATOR:
				PredefinedType = IfcElectricApplianceTypeEnum.REFRIGERATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.TUMBLEDRYER:
				PredefinedType = IfcElectricApplianceTypeEnum.TUMBLEDRYER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.VENDINGMACHINE:
				PredefinedType = IfcElectricApplianceTypeEnum.VENDINGMACHINE;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.WASHINGMACHINE:
				PredefinedType = IfcElectricApplianceTypeEnum.WASHINGMACHINE;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED:
				PredefinedType = IfcElectricApplianceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.NOTDEFINED:
				PredefinedType = IfcElectricApplianceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricApplianceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricApplianceTypeEnum)Enum.Parse(typeof(IfcElectricApplianceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricApplianceType other)
	{
		return this == other;
	}
}
