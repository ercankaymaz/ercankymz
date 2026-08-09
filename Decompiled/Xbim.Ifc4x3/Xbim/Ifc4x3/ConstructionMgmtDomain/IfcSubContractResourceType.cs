using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcSubContractResourceType", 1286)]
public class IfcSubContractResourceType : IfcConstructionResourceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSubContractResourceType>, IIfcSubContractResourceType, IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcResourceSelect, IIfcResourceSelect
{
	private IfcSubContractResourceTypeEnum _predefinedType;

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcSubContractResourceTypeEnum PredefinedType
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
			SetValue(delegate(IfcSubContractResourceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcSubContractResourceType), 12)]
	Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum IIfcSubContractResourceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSubContractResourceTypeEnum.PURCHASE => Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.PURCHASE, 
				IfcSubContractResourceTypeEnum.WORK => Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.WORK, 
				IfcSubContractResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.USERDEFINED, 
				IfcSubContractResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.PURCHASE:
				PredefinedType = IfcSubContractResourceTypeEnum.PURCHASE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.WORK:
				PredefinedType = IfcSubContractResourceTypeEnum.WORK;
				break;
			case Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.USERDEFINED:
				PredefinedType = IfcSubContractResourceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.NOTDEFINED:
				PredefinedType = IfcSubContractResourceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcSubContractResourceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSubContractResourceTypeEnum)Enum.Parse(typeof(IfcSubContractResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSubContractResourceType other)
	{
		return this == other;
	}
}
