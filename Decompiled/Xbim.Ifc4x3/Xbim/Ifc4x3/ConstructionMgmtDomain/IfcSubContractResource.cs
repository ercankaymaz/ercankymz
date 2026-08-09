using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcSubContractResource", 594)]
public class IfcSubContractResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSubContractResource>, IIfcSubContractResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	private IfcSubContractResourceTypeEnum? _predefinedType;

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcSubContractResourceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSubContractResourceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcSubContractResource), 11)]
	Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum? IIfcSubContractResource.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSubContractResourceTypeEnum.PURCHASE => Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.PURCHASE, 
				IfcSubContractResourceTypeEnum.WORK => Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.WORK, 
				IfcSubContractResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.USERDEFINED, 
				IfcSubContractResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSubContractResourceTypeEnum.NOTDEFINED, 
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcSubContractResource(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSubContractResourceTypeEnum)Enum.Parse(typeof(IfcSubContractResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSubContractResource other)
	{
		return this == other;
	}
}
