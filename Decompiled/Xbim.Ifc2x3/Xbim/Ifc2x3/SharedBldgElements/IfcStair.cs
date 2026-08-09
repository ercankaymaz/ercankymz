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

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcStair", 346)]
public class IfcStair : IfcBuildingElement, IIfcStair, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStair>, IExpressValidatable
{
	public enum IfcStairClause
	{
		WR1
	}

	private IfcStairTypeEnum _shapeType;

	[CrossSchemaAttribute(typeof(IIfcStair), 9)]
	Xbim.Ifc4.Interfaces.IfcStairTypeEnum? IIfcStair.PredefinedType
	{
		get
		{
			return ShapeType switch
			{
				IfcStairTypeEnum.STRAIGHT_RUN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.STRAIGHT_RUN_STAIR, 
				IfcStairTypeEnum.TWO_STRAIGHT_RUN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_STRAIGHT_RUN_STAIR, 
				IfcStairTypeEnum.QUARTER_WINDING_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.QUARTER_WINDING_STAIR, 
				IfcStairTypeEnum.QUARTER_TURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.QUARTER_TURN_STAIR, 
				IfcStairTypeEnum.HALF_WINDING_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.HALF_WINDING_STAIR, 
				IfcStairTypeEnum.HALF_TURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.HALF_TURN_STAIR, 
				IfcStairTypeEnum.TWO_QUARTER_WINDING_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_QUARTER_WINDING_STAIR, 
				IfcStairTypeEnum.TWO_QUARTER_TURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_QUARTER_TURN_STAIR, 
				IfcStairTypeEnum.THREE_QUARTER_WINDING_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.THREE_QUARTER_WINDING_STAIR, 
				IfcStairTypeEnum.THREE_QUARTER_TURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.THREE_QUARTER_TURN_STAIR, 
				IfcStairTypeEnum.SPIRAL_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.SPIRAL_STAIR, 
				IfcStairTypeEnum.DOUBLE_RETURN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.DOUBLE_RETURN_STAIR, 
				IfcStairTypeEnum.CURVED_RUN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.CURVED_RUN_STAIR, 
				IfcStairTypeEnum.TWO_CURVED_RUN_STAIR => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_CURVED_RUN_STAIR, 
				IfcStairTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.USERDEFINED, 
				IfcStairTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcStairTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.STRAIGHT_RUN_STAIR:
				ShapeType = IfcStairTypeEnum.STRAIGHT_RUN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_STRAIGHT_RUN_STAIR:
				ShapeType = IfcStairTypeEnum.TWO_STRAIGHT_RUN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.QUARTER_WINDING_STAIR:
				ShapeType = IfcStairTypeEnum.QUARTER_WINDING_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.QUARTER_TURN_STAIR:
				ShapeType = IfcStairTypeEnum.QUARTER_TURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.HALF_WINDING_STAIR:
				ShapeType = IfcStairTypeEnum.HALF_WINDING_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.HALF_TURN_STAIR:
				ShapeType = IfcStairTypeEnum.HALF_TURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_QUARTER_WINDING_STAIR:
				ShapeType = IfcStairTypeEnum.TWO_QUARTER_WINDING_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_QUARTER_TURN_STAIR:
				ShapeType = IfcStairTypeEnum.TWO_QUARTER_TURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.THREE_QUARTER_WINDING_STAIR:
				ShapeType = IfcStairTypeEnum.THREE_QUARTER_WINDING_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.THREE_QUARTER_TURN_STAIR:
				ShapeType = IfcStairTypeEnum.THREE_QUARTER_TURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.SPIRAL_STAIR:
				ShapeType = IfcStairTypeEnum.SPIRAL_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.DOUBLE_RETURN_STAIR:
				ShapeType = IfcStairTypeEnum.DOUBLE_RETURN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.CURVED_RUN_STAIR:
				ShapeType = IfcStairTypeEnum.CURVED_RUN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.TWO_CURVED_RUN_STAIR:
				ShapeType = IfcStairTypeEnum.TWO_CURVED_RUN_STAIR;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.USERDEFINED:
				ShapeType = IfcStairTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcStairTypeEnum.NOTDEFINED:
				ShapeType = IfcStairTypeEnum.NOTDEFINED;
				break;
			case null:
				ShapeType = IfcStairTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcStairTypeEnum ShapeType
	{
		get
		{
			if (_activated)
			{
				return _shapeType;
			}
			Activate();
			return _shapeType;
		}
		set
		{
			SetValue(delegate(IfcStairTypeEnum v)
			{
				_shapeType = v;
			}, _shapeType, value, "ShapeType", 9);
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

	internal IfcStair(IModel model, int label, bool activated)
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
			_shapeType = (IfcStairTypeEnum)Enum.Parse(typeof(IfcStairTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStair other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStairClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStairClause.WR1)
			{
				result = Functions.HIINDEX(base.IsDecomposedBy) == 0 || (Functions.HIINDEX(base.IsDecomposedBy) == 1 && !Functions.EXISTS(base.Representation));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStair>()?.LogError($"Exception thrown evaluating where-clause 'IfcStair.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStairClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStair.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
