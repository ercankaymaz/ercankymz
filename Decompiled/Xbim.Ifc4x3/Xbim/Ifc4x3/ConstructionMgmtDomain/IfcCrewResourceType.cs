using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcCrewResourceType", 1145)]
public class IfcCrewResourceType : IfcConstructionResourceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCrewResourceType>, IIfcCrewResourceType, IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcResourceSelect, IIfcResourceSelect
{
	private IfcCrewResourceTypeEnum _predefinedType;

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcCrewResourceTypeEnum PredefinedType
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
			SetValue(delegate(IfcCrewResourceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcCrewResourceType), 12)]
	Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum IIfcCrewResourceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCrewResourceTypeEnum.OFFICE => Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.OFFICE, 
				IfcCrewResourceTypeEnum.SITE => Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.SITE, 
				IfcCrewResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.USERDEFINED, 
				IfcCrewResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.OFFICE:
				PredefinedType = IfcCrewResourceTypeEnum.OFFICE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.SITE:
				PredefinedType = IfcCrewResourceTypeEnum.SITE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.USERDEFINED:
				PredefinedType = IfcCrewResourceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.NOTDEFINED:
				PredefinedType = IfcCrewResourceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCrewResourceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCrewResourceTypeEnum)Enum.Parse(typeof(IfcCrewResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCrewResourceType other)
	{
		return this == other;
	}
}
