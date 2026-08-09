using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcConstructionProductResourceType", 1136)]
public class IfcConstructionProductResourceType : IfcConstructionResourceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcConstructionProductResourceType>, IIfcConstructionProductResourceType, IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcResourceSelect, IIfcResourceSelect
{
	private IfcConstructionProductResourceTypeEnum _predefinedType;

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcConstructionProductResourceTypeEnum PredefinedType
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
			SetValue(delegate(IfcConstructionProductResourceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcConstructionProductResourceType), 12)]
	Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum IIfcConstructionProductResourceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcConstructionProductResourceTypeEnum.ASSEMBLY => Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.ASSEMBLY, 
				IfcConstructionProductResourceTypeEnum.FORMWORK => Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.FORMWORK, 
				IfcConstructionProductResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.USERDEFINED, 
				IfcConstructionProductResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcConstructionProductResourceTypeEnum.NOTDEFINED, 
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcConstructionProductResourceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcConstructionProductResourceTypeEnum)Enum.Parse(typeof(IfcConstructionProductResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionProductResourceType other)
	{
		return this == other;
	}
}
