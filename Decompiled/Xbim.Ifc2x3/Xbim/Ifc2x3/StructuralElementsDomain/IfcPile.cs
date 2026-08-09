using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralElementsDomain;

[ExpressType("IfcPile", 572)]
public class IfcPile : IfcBuildingElement, IIfcPile, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPile>, IExpressValidatable
{
	public enum IfcPileClause
	{
		WR1
	}

	private IfcPileTypeEnum _predefinedType;

	private IfcPileConstructionEnum? _constructionType;

	[CrossSchemaAttribute(typeof(IIfcPile), 9)]
	Xbim.Ifc4.Interfaces.IfcPileTypeEnum? IIfcPile.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcPileTypeEnum.COHESION:
				return Xbim.Ifc4.Interfaces.IfcPileTypeEnum.COHESION;
			case IfcPileTypeEnum.FRICTION:
				return Xbim.Ifc4.Interfaces.IfcPileTypeEnum.FRICTION;
			case IfcPileTypeEnum.SUPPORT:
				return Xbim.Ifc4.Interfaces.IfcPileTypeEnum.SUPPORT;
			case IfcPileTypeEnum.USERDEFINED:
				if (base.ObjectType.HasValue)
				{
					switch (base.ObjectType.Value)
					{
					case "BORED":
					case "DRIVEN":
					case "JETGROUTING":
						return (Xbim.Ifc4.Interfaces.IfcPileTypeEnum)Enum.Parse(typeof(Xbim.Ifc4.Interfaces.IfcPileTypeEnum), base.ObjectType.Value);
					}
				}
				return Xbim.Ifc4.Interfaces.IfcPileTypeEnum.USERDEFINED;
			case IfcPileTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcPileTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.BORED:
				base.ObjectType = Enum.GetName(typeof(Xbim.Ifc4.Interfaces.IfcPileTypeEnum), value);
				PredefinedType = IfcPileTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.DRIVEN:
				base.ObjectType = Enum.GetName(typeof(Xbim.Ifc4.Interfaces.IfcPileTypeEnum), value);
				PredefinedType = IfcPileTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPileTypeEnum.JETGROUTING:
				base.ObjectType = Enum.GetName(typeof(Xbim.Ifc4.Interfaces.IfcPileTypeEnum), value);
				PredefinedType = IfcPileTypeEnum.USERDEFINED;
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
				PredefinedType = IfcPileTypeEnum.NOTDEFINED;
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

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcPileTypeEnum PredefinedType
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
			SetValue(delegate(IfcPileTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 28)]
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

	public bool ValidateClause(IfcPileClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPileClause.WR1)
			{
				result = PredefinedType != IfcPileTypeEnum.USERDEFINED || (PredefinedType == IfcPileTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPile>()?.LogError($"Exception thrown evaluating where-clause 'IfcPile.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcPileClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPile.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
