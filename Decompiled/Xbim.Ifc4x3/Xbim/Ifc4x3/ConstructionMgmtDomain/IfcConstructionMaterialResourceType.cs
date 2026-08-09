using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcConstructionMaterialResourceType", 1135)]
public class IfcConstructionMaterialResourceType : IfcConstructionResourceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcConstructionMaterialResourceType>, IIfcConstructionMaterialResourceType, IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcResourceSelect, IIfcResourceSelect
{
	private IfcConstructionMaterialResourceTypeEnum _predefinedType;

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcConstructionMaterialResourceTypeEnum PredefinedType
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
			SetValue(delegate(IfcConstructionMaterialResourceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcConstructionMaterialResourceType), 12)]
	Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum IIfcConstructionMaterialResourceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcConstructionMaterialResourceTypeEnum.AGGREGATES => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.AGGREGATES, 
				IfcConstructionMaterialResourceTypeEnum.CONCRETE => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.CONCRETE, 
				IfcConstructionMaterialResourceTypeEnum.DRYWALL => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.DRYWALL, 
				IfcConstructionMaterialResourceTypeEnum.FUEL => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.FUEL, 
				IfcConstructionMaterialResourceTypeEnum.GYPSUM => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.GYPSUM, 
				IfcConstructionMaterialResourceTypeEnum.MASONRY => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.MASONRY, 
				IfcConstructionMaterialResourceTypeEnum.METAL => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.METAL, 
				IfcConstructionMaterialResourceTypeEnum.PLASTIC => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.PLASTIC, 
				IfcConstructionMaterialResourceTypeEnum.WOOD => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.WOOD, 
				IfcConstructionMaterialResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.USERDEFINED, 
				IfcConstructionMaterialResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.AGGREGATES:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.AGGREGATES;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.CONCRETE:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.CONCRETE;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.DRYWALL:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.DRYWALL;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.FUEL:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.FUEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.GYPSUM:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.GYPSUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.MASONRY:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.MASONRY;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.METAL:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.METAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.PLASTIC:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.PLASTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.WOOD:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.WOOD;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.NOTDEFINED:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.NOTDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionMaterialResourceTypeEnum.USERDEFINED:
				PredefinedType = IfcConstructionMaterialResourceTypeEnum.USERDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcConstructionMaterialResourceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcConstructionMaterialResourceTypeEnum)Enum.Parse(typeof(IfcConstructionMaterialResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionMaterialResourceType other)
	{
		return this == other;
	}
}
