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

[ExpressType("IfcRoof", 347)]
public class IfcRoof : IfcBuildingElement, IIfcRoof, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRoof>, IExpressValidatable
{
	public enum IfcRoofClause
	{
		WR1
	}

	private IfcRoofTypeEnum _shapeType;

	[CrossSchemaAttribute(typeof(IIfcRoof), 9)]
	Xbim.Ifc4.Interfaces.IfcRoofTypeEnum? IIfcRoof.PredefinedType
	{
		get
		{
			if (base.ObjectType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcRoofTypeEnum>(base.ObjectType.Value, ignoreCase: false, out var result))
			{
				return result;
			}
			return ShapeType switch
			{
				IfcRoofTypeEnum.FLAT_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.FLAT_ROOF, 
				IfcRoofTypeEnum.SHED_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.SHED_ROOF, 
				IfcRoofTypeEnum.GABLE_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.GABLE_ROOF, 
				IfcRoofTypeEnum.HIP_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.HIP_ROOF, 
				IfcRoofTypeEnum.HIPPED_GABLE_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.HIPPED_GABLE_ROOF, 
				IfcRoofTypeEnum.GAMBREL_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.GAMBREL_ROOF, 
				IfcRoofTypeEnum.MANSARD_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.MANSARD_ROOF, 
				IfcRoofTypeEnum.BARREL_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.BARREL_ROOF, 
				IfcRoofTypeEnum.RAINBOW_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.RAINBOW_ROOF, 
				IfcRoofTypeEnum.BUTTERFLY_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.BUTTERFLY_ROOF, 
				IfcRoofTypeEnum.PAVILION_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.PAVILION_ROOF, 
				IfcRoofTypeEnum.DOME_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.DOME_ROOF, 
				IfcRoofTypeEnum.FREEFORM => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.FREEFORM, 
				IfcRoofTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.FLAT_ROOF:
				ShapeType = IfcRoofTypeEnum.FLAT_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.SHED_ROOF:
				ShapeType = IfcRoofTypeEnum.SHED_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.GABLE_ROOF:
				ShapeType = IfcRoofTypeEnum.GABLE_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.HIP_ROOF:
				ShapeType = IfcRoofTypeEnum.HIP_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.HIPPED_GABLE_ROOF:
				ShapeType = IfcRoofTypeEnum.HIPPED_GABLE_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.GAMBREL_ROOF:
				ShapeType = IfcRoofTypeEnum.GAMBREL_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.MANSARD_ROOF:
				ShapeType = IfcRoofTypeEnum.MANSARD_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.BARREL_ROOF:
				ShapeType = IfcRoofTypeEnum.BARREL_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.RAINBOW_ROOF:
				ShapeType = IfcRoofTypeEnum.RAINBOW_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.BUTTERFLY_ROOF:
				ShapeType = IfcRoofTypeEnum.BUTTERFLY_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.PAVILION_ROOF:
				ShapeType = IfcRoofTypeEnum.PAVILION_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.DOME_ROOF:
				ShapeType = IfcRoofTypeEnum.DOME_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.FREEFORM:
				ShapeType = IfcRoofTypeEnum.FREEFORM;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.USERDEFINED:
				base.ObjectType = value.ToString();
				ShapeType = IfcRoofTypeEnum.NOTDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.NOTDEFINED:
				ShapeType = IfcRoofTypeEnum.NOTDEFINED;
				break;
			case null:
				ShapeType = IfcRoofTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcRoofTypeEnum ShapeType
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
			SetValue(delegate(IfcRoofTypeEnum v)
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

	internal IfcRoof(IModel model, int label, bool activated)
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
			_shapeType = (IfcRoofTypeEnum)Enum.Parse(typeof(IfcRoofTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRoof other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRoofClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRoofClause.WR1)
			{
				result = Functions.HIINDEX(base.IsDecomposedBy) == 0 || (Functions.HIINDEX(base.IsDecomposedBy) == 1 && !Functions.EXISTS(base.Representation));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRoof>()?.LogError($"Exception thrown evaluating where-clause 'IfcRoof.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRoofClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRoof.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
