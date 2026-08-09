using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcLaborResourceType", 1196)]
public class IfcLaborResourceType : IfcConstructionResourceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLaborResourceType>, IIfcLaborResourceType, IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcResourceSelect, IIfcResourceSelect
{
	private IfcLaborResourceTypeEnum _predefinedType;

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcLaborResourceTypeEnum PredefinedType
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
			SetValue(delegate(IfcLaborResourceTypeEnum v)
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

	[CrossSchemaAttribute(typeof(IIfcLaborResourceType), 12)]
	Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum IIfcLaborResourceType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcLaborResourceTypeEnum.ADMINISTRATION => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.ADMINISTRATION, 
				IfcLaborResourceTypeEnum.CARPENTRY => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.CARPENTRY, 
				IfcLaborResourceTypeEnum.CLEANING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.CLEANING, 
				IfcLaborResourceTypeEnum.CONCRETE => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.CONCRETE, 
				IfcLaborResourceTypeEnum.DRYWALL => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.DRYWALL, 
				IfcLaborResourceTypeEnum.ELECTRIC => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.ELECTRIC, 
				IfcLaborResourceTypeEnum.FINISHING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.FINISHING, 
				IfcLaborResourceTypeEnum.FLOORING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.FLOORING, 
				IfcLaborResourceTypeEnum.GENERAL => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.GENERAL, 
				IfcLaborResourceTypeEnum.HVAC => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.HVAC, 
				IfcLaborResourceTypeEnum.LANDSCAPING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.LANDSCAPING, 
				IfcLaborResourceTypeEnum.MASONRY => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.MASONRY, 
				IfcLaborResourceTypeEnum.PAINTING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.PAINTING, 
				IfcLaborResourceTypeEnum.PAVING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.PAVING, 
				IfcLaborResourceTypeEnum.PLUMBING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.PLUMBING, 
				IfcLaborResourceTypeEnum.ROOFING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.ROOFING, 
				IfcLaborResourceTypeEnum.SITEGRADING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.SITEGRADING, 
				IfcLaborResourceTypeEnum.STEELWORK => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.STEELWORK, 
				IfcLaborResourceTypeEnum.SURVEYING => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.SURVEYING, 
				IfcLaborResourceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.USERDEFINED, 
				IfcLaborResourceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.ADMINISTRATION:
				PredefinedType = IfcLaborResourceTypeEnum.ADMINISTRATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.CARPENTRY:
				PredefinedType = IfcLaborResourceTypeEnum.CARPENTRY;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.CLEANING:
				PredefinedType = IfcLaborResourceTypeEnum.CLEANING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.CONCRETE:
				PredefinedType = IfcLaborResourceTypeEnum.CONCRETE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.DRYWALL:
				PredefinedType = IfcLaborResourceTypeEnum.DRYWALL;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.ELECTRIC:
				PredefinedType = IfcLaborResourceTypeEnum.ELECTRIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.FINISHING:
				PredefinedType = IfcLaborResourceTypeEnum.FINISHING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.FLOORING:
				PredefinedType = IfcLaborResourceTypeEnum.FLOORING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.GENERAL:
				PredefinedType = IfcLaborResourceTypeEnum.GENERAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.HVAC:
				PredefinedType = IfcLaborResourceTypeEnum.HVAC;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.LANDSCAPING:
				PredefinedType = IfcLaborResourceTypeEnum.LANDSCAPING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.MASONRY:
				PredefinedType = IfcLaborResourceTypeEnum.MASONRY;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.PAINTING:
				PredefinedType = IfcLaborResourceTypeEnum.PAINTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.PAVING:
				PredefinedType = IfcLaborResourceTypeEnum.PAVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.PLUMBING:
				PredefinedType = IfcLaborResourceTypeEnum.PLUMBING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.ROOFING:
				PredefinedType = IfcLaborResourceTypeEnum.ROOFING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.SITEGRADING:
				PredefinedType = IfcLaborResourceTypeEnum.SITEGRADING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.STEELWORK:
				PredefinedType = IfcLaborResourceTypeEnum.STEELWORK;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.SURVEYING:
				PredefinedType = IfcLaborResourceTypeEnum.SURVEYING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.USERDEFINED:
				PredefinedType = IfcLaborResourceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum.NOTDEFINED:
				PredefinedType = IfcLaborResourceTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcLaborResourceType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcLaborResourceTypeEnum)Enum.Parse(typeof(IfcLaborResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLaborResourceType other)
	{
		return this == other;
	}
}
