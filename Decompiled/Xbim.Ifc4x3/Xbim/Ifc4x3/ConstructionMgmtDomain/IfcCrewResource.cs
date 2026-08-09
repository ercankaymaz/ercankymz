using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcCrewResource", 659)]
public class IfcCrewResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCrewResource>, IIfcCrewResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	private IfcCrewResourceTypeEnum? _predefinedType;

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcCrewResourceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCrewResourceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcCrewResource), 11)]
	Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum? IIfcCrewResource.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCrewResourceTypeEnum.OFFICE => Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.OFFICE, 
				IfcCrewResourceTypeEnum.SITE => Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.SITE, 
				IfcCrewResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.USERDEFINED, 
				IfcCrewResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCrewResourceTypeEnum.NOTDEFINED, 
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCrewResource(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCrewResourceTypeEnum)Enum.Parse(typeof(IfcCrewResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCrewResource other)
	{
		return this == other;
	}
}
