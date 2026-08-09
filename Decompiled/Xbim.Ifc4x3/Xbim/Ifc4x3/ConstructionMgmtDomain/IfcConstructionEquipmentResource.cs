using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcConstructionEquipmentResource", 408)]
public class IfcConstructionEquipmentResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConstructionEquipmentResource>, IIfcConstructionEquipmentResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	private IfcConstructionEquipmentResourceTypeEnum? _predefinedType;

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcConstructionEquipmentResourceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcConstructionEquipmentResourceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 11);
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
			if (base.Usage != null)
			{
				yield return base.Usage;
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

	[CrossSchemaAttribute(typeof(IIfcConstructionEquipmentResource), 11)]
	Xbim.Ifc4.Interfaces.IfcConstructionEquipmentResourceTypeEnum? IIfcConstructionEquipmentResource.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcConstructionEquipmentResource(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 10:
			_predefinedType = (IfcConstructionEquipmentResourceTypeEnum)Enum.Parse(typeof(IfcConstructionEquipmentResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionEquipmentResource other)
	{
		return this == other;
	}
}
