using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcPile", 572)]
public class IfcPile : IfcDeepFoundation, IIfcPile, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPile>
{
	private IfcPileTypeEnum? _predefinedType;

	private IfcPileConstructionEnum? _constructionType;

	[CrossSchemaAttribute(typeof(IIfcPile), 9)]
	Xbim.Ifc4.Interfaces.IfcPileTypeEnum? IIfcPile.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcPileTypeEnum.BORED => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.BORED, 
				IfcPileTypeEnum.COHESION => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.COHESION, 
				IfcPileTypeEnum.DRIVEN => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.DRIVEN, 
				IfcPileTypeEnum.FRICTION => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.FRICTION, 
				IfcPileTypeEnum.JETGROUTING => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.JETGROUTING, 
				IfcPileTypeEnum.SUPPORT => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.SUPPORT, 
				IfcPileTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.USERDEFINED, 
				IfcPileTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPileTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.BORED:
				PredefinedType = IfcPileTypeEnum.BORED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.DRIVEN:
				PredefinedType = IfcPileTypeEnum.DRIVEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.JETGROUTING:
				PredefinedType = IfcPileTypeEnum.JETGROUTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.COHESION:
				PredefinedType = IfcPileTypeEnum.COHESION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.FRICTION:
				PredefinedType = IfcPileTypeEnum.FRICTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.SUPPORT:
				PredefinedType = IfcPileTypeEnum.SUPPORT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.USERDEFINED:
				PredefinedType = IfcPileTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.NOTDEFINED:
				PredefinedType = IfcPileTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPile), 10)]
	Xbim.Ifc4.Interfaces.IfcPileConstructionEnum? IIfcPile.ConstructionType
	{
		get
		{
			return ConstructionType switch
			{
				IfcPileConstructionEnum.CAST_IN_PLACE => Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.CAST_IN_PLACE, 
				IfcPileConstructionEnum.COMPOSITE => Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.COMPOSITE, 
				IfcPileConstructionEnum.PRECAST_CONCRETE => Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.PRECAST_CONCRETE, 
				IfcPileConstructionEnum.PREFAB_STEEL => Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.PREFAB_STEEL, 
				IfcPileConstructionEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.USERDEFINED, 
				IfcPileConstructionEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.CAST_IN_PLACE:
				ConstructionType = IfcPileConstructionEnum.CAST_IN_PLACE;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.COMPOSITE:
				ConstructionType = IfcPileConstructionEnum.COMPOSITE;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.PRECAST_CONCRETE:
				ConstructionType = IfcPileConstructionEnum.PRECAST_CONCRETE;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.PREFAB_STEEL:
				ConstructionType = IfcPileConstructionEnum.PREFAB_STEEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.USERDEFINED:
				ConstructionType = IfcPileConstructionEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileConstructionEnum.NOTDEFINED:
				ConstructionType = IfcPileConstructionEnum.NOTDEFINED;
				break;
			case null:
				ConstructionType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcPileTypeEnum? PredefinedType
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
			SetValue(delegate(IfcPileTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 36)]
	public IfcPileConstructionEnum? ConstructionType
	{
		get
		{
			if (_activated)
			{
				return _constructionType;
			}
			Activate();
			return _constructionType;
		}
		set
		{
			SetValue(delegate(IfcPileConstructionEnum? v)
			{
				_constructionType = v;
			}, _constructionType, value, "ConstructionType", 10);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcPile(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcPileTypeEnum)Enum.Parse(typeof(IfcPileTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_constructionType = (IfcPileConstructionEnum)Enum.Parse(typeof(IfcPileConstructionEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPile other)
	{
		return this == other;
	}
}
