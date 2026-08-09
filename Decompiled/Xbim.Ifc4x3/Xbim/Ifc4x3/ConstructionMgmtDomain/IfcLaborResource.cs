using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.ConstructionMgmtDomain;

[ExpressType("IfcLaborResource", 156)]
public class IfcLaborResource : IfcConstructionResource, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcLaborResource>, IIfcLaborResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	private IfcLaborResourceTypeEnum? _predefinedType;

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcLaborResourceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcLaborResourceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcLaborResource), 11)]
	Xbim.Ifc4.Interfaces.IfcLaborResourceTypeEnum? IIfcLaborResource.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcLaborResource(IModel model, int label, bool activated)
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
			_predefinedType = (IfcLaborResourceTypeEnum)Enum.Parse(typeof(IfcLaborResourceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLaborResource other)
	{
		return this == other;
	}
}
