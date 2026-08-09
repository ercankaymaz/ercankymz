using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcConstructionEquipmentResourceType", 1134)]
public class IfcConstructionEquipmentResourceType : IfcConstructionResourceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcConstructionEquipmentResourceType>, IIfcConstructionEquipmentResourceType, IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcResourceSelect, IIfcResourceSelect
{
	private IfcConstructionEquipmentResourceTypeEnum _predefinedType;

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcConstructionEquipmentResourceTypeEnum PredefinedType
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
			SetValue(delegate(IfcConstructionEquipmentResourceTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 12);
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
			foreach (IfcAppliedValue baseCost in base.BaseCosts)
			{
				yield return baseCost;
			}
			if (base.BaseQuantity != null)
			{
				yield return base.BaseQuantity;
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

	[CrossSchemaAttribute(typeof(IIfcConstructionEquipmentResourceType), 12)]
	Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum IIfcConstructionEquipmentResourceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcConstructionEquipmentResourceTypeEnum.DEMOLISHING => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.DEMOLISHING, 
				IfcConstructionEquipmentResourceTypeEnum.EARTHMOVING => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.EARTHMOVING, 
				IfcConstructionEquipmentResourceTypeEnum.ERECTING => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.ERECTING, 
				IfcConstructionEquipmentResourceTypeEnum.HEATING => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.HEATING, 
				IfcConstructionEquipmentResourceTypeEnum.LIGHTING => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.LIGHTING, 
				IfcConstructionEquipmentResourceTypeEnum.PAVING => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.PAVING, 
				IfcConstructionEquipmentResourceTypeEnum.PUMPING => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.PUMPING, 
				IfcConstructionEquipmentResourceTypeEnum.TRANSPORTING => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.TRANSPORTING, 
				IfcConstructionEquipmentResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.USERDEFINED, 
				IfcConstructionEquipmentResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.DEMOLISHING:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.DEMOLISHING;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.EARTHMOVING:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.EARTHMOVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.ERECTING:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.ERECTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.HEATING:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.HEATING;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.LIGHTING:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.LIGHTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.PAVING:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.PAVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.PUMPING:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.PUMPING;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.TRANSPORTING:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.TRANSPORTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.USERDEFINED:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum.NOTDEFINED:
				PredefinedType = IfcConstructionEquipmentResourceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcConstructionEquipmentResourceType(IModel model, int label, bool activated)
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
		case 9:
		case 10:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 11:
			_predefinedType = (IfcConstructionEquipmentResourceTypeEnum)Enum.Parse(typeof(IfcConstructionEquipmentResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionEquipmentResourceType other)
	{
		return this == other;
	}
}
