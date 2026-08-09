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

[ExpressType("IfcRamp", 414)]
public class IfcRamp : IfcBuildingElement, IIfcRamp, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRamp>, IExpressValidatable
{
	public enum IfcRampClause
	{
		WR1
	}

	private IfcRampTypeEnum _shapeType;

	[CrossSchemaAttribute(typeof(IIfcRamp), 9)]
	Xbim.Ifc4.Interfaces.IfcRampTypeEnum? IIfcRamp.PredefinedType
	{
		get
		{
			return ShapeType switch
			{
				IfcRampTypeEnum.STRAIGHT_RUN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.STRAIGHT_RUN_RAMP, 
				IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP, 
				IfcRampTypeEnum.QUARTER_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.QUARTER_TURN_RAMP, 
				IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP, 
				IfcRampTypeEnum.HALF_TURN_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.HALF_TURN_RAMP, 
				IfcRampTypeEnum.SPIRAL_RAMP => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.SPIRAL_RAMP, 
				IfcRampTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.USERDEFINED, 
				IfcRampTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcRampTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.STRAIGHT_RUN_RAMP:
				ShapeType = IfcRampTypeEnum.STRAIGHT_RUN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP:
				ShapeType = IfcRampTypeEnum.TWO_STRAIGHT_RUN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.QUARTER_TURN_RAMP:
				ShapeType = IfcRampTypeEnum.QUARTER_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP:
				ShapeType = IfcRampTypeEnum.TWO_QUARTER_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.HALF_TURN_RAMP:
				ShapeType = IfcRampTypeEnum.HALF_TURN_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.SPIRAL_RAMP:
				ShapeType = IfcRampTypeEnum.SPIRAL_RAMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.USERDEFINED:
				ShapeType = IfcRampTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcRampTypeEnum.NOTDEFINED:
				ShapeType = IfcRampTypeEnum.NOTDEFINED;
				break;
			case null:
				ShapeType = IfcRampTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcRampTypeEnum ShapeType
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
			SetValue(delegate(IfcRampTypeEnum v)
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

	internal IfcRamp(IModel model, int label, bool activated)
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
			_shapeType = (IfcRampTypeEnum)Enum.Parse(typeof(IfcRampTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRamp other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRampClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRampClause.WR1)
			{
				result = Functions.HIINDEX(base.IsDecomposedBy) == 0 || (Functions.HIINDEX(base.IsDecomposedBy) == 1 && !Functions.EXISTS(base.Representation));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRamp>()?.LogError($"Exception thrown evaluating where-clause 'IfcRamp.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRampClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRamp.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
