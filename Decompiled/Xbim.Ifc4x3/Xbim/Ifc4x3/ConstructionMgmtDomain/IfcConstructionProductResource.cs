using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcConstructionProductResource", 660)]
public class IfcConstructionProductResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConstructionProductResource>, IIfcConstructionProductResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	private IfcConstructionProductResourceTypeEnum? _predefinedType;

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcConstructionProductResourceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcConstructionProductResourceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcConstructionProductResource), 11)]
	Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum? IIfcConstructionProductResource.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcConstructionProductResourceTypeEnum.ASSEMBLY => Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.ASSEMBLY, 
				IfcConstructionProductResourceTypeEnum.FORMWORK => Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.FORMWORK, 
				IfcConstructionProductResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.USERDEFINED, 
				IfcConstructionProductResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.ASSEMBLY:
				PredefinedType = IfcConstructionProductResourceTypeEnum.ASSEMBLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.FORMWORK:
				PredefinedType = IfcConstructionProductResourceTypeEnum.FORMWORK;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.USERDEFINED:
				PredefinedType = IfcConstructionProductResourceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.NOTDEFINED:
				PredefinedType = IfcConstructionProductResourceTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcConstructionProductResource(IModel model, int label, bool activated)
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
			_predefinedType = (IfcConstructionProductResourceTypeEnum)Enum.Parse(typeof(IfcConstructionProductResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionProductResource other)
	{
		return this == other;
	}
}
