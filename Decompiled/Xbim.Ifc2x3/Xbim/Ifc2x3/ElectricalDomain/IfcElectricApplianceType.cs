using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ElectricalDomain;

[ExpressType("IfcElectricApplianceType", 192)]
public class IfcElectricApplianceType : IfcFlowTerminalType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricApplianceType>, IIfcElectricApplianceType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	private IfcElectricApplianceTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
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

	[CrossSchemaAttribute(typeof(IIfcElectricApplianceType), 10)]
	Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum IIfcElectricApplianceType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcElectricApplianceTypeEnum.COMPUTER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.DIRECTWATERHEATER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.DISHWASHER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.DISHWASHER;
			case IfcElectricApplianceTypeEnum.ELECTRICCOOKER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.ELECTRICCOOKER;
			case IfcElectricApplianceTypeEnum.ELECTRICHEATER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.FACSIMILE:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.FREESTANDINGFAN:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGFAN;
			case IfcElectricApplianceTypeEnum.FREEZER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREEZER;
			case IfcElectricApplianceTypeEnum.FRIDGE_FREEZER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FRIDGE_FREEZER;
			case IfcElectricApplianceTypeEnum.HANDDRYER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.HANDDRYER;
			case IfcElectricApplianceTypeEnum.INDIRECTWATERHEATER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.MICROWAVE:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.MICROWAVE;
			case IfcElectricApplianceTypeEnum.PHOTOCOPIER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.PHOTOCOPIER;
			case IfcElectricApplianceTypeEnum.PRINTER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.REFRIGERATOR:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.REFRIGERATOR;
			case IfcElectricApplianceTypeEnum.RADIANTHEATER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.SCANNER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.TELEPHONE:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.TUMBLEDRYER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.TUMBLEDRYER;
			case IfcElectricApplianceTypeEnum.TV:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.VENDINGMACHINE:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.VENDINGMACHINE;
			case IfcElectricApplianceTypeEnum.WASHINGMACHINE:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.WASHINGMACHINE;
			case IfcElectricApplianceTypeEnum.WATERHEATER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.WATERCOOLER:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			case IfcElectricApplianceTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.USERDEFINED;
			}
			case IfcElectricApplianceTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
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
				base.ElementType = value.ToString();
				PredefinedType = IfcElectricApplianceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGFAN:
				PredefinedType = IfcElectricApplianceTypeEnum.FREESTANDINGFAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGWATERHEATER:
				base.ElementType = value.ToString();
				PredefinedType = IfcElectricApplianceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricApplianceTypeEnum.FREESTANDINGWATERCOOLER:
				base.ElementType = value.ToString();
				PredefinedType = IfcElectricApplianceTypeEnum.USERDEFINED;
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
				base.ElementType = value.ToString();
				PredefinedType = IfcElectricApplianceTypeEnum.USERDEFINED;
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

	IfcLabel? IIfcElementType.ElementType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcElectricApplianceTypeEnum.COMPUTER:
			case IfcElectricApplianceTypeEnum.DIRECTWATERHEATER:
			case IfcElectricApplianceTypeEnum.ELECTRICHEATER:
			case IfcElectricApplianceTypeEnum.FACSIMILE:
			case IfcElectricApplianceTypeEnum.INDIRECTWATERHEATER:
			case IfcElectricApplianceTypeEnum.PRINTER:
			case IfcElectricApplianceTypeEnum.RADIANTHEATER:
			case IfcElectricApplianceTypeEnum.SCANNER:
			case IfcElectricApplianceTypeEnum.TELEPHONE:
			case IfcElectricApplianceTypeEnum.TV:
			case IfcElectricApplianceTypeEnum.WATERHEATER:
			case IfcElectricApplianceTypeEnum.WATERCOOLER:
				return new IfcLabel(Enum.GetName(typeof(IfcElectricApplianceTypeEnum), PredefinedType));
			default:
				return (!base.ElementType.HasValue) ? ((IfcLabel)null) : new IfcLabel(base.ElementType.Value);
			}
		}
		set
		{
			base.ElementType = (value.HasValue ? value.Value.ToString() : null);
			if (value.HasValue && Enum.TryParse<IfcElectricApplianceTypeEnum>(value.Value.ToString(), ignoreCase: true, out var result))
			{
				PredefinedType = result;
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
