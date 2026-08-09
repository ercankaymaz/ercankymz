using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcElectricAppliance", 1156)]
public class IfcElectricAppliance : IfcFlowTerminal, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricAppliance>, IIfcElectricAppliance, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcElectricApplianceTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcElectricApplianceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcElectricApplianceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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

	[CrossSchemaAttribute(typeof(IIfcElectricAppliance), 9)]
	Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum? IIfcElectricAppliance.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricAppliance(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcElectricApplianceTypeEnum)Enum.Parse(typeof(IfcElectricApplianceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricAppliance other)
	{
		return this == other;
	}
}
