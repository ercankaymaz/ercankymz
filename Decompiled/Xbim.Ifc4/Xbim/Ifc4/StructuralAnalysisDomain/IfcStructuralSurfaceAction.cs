using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralSurfaceAction", 1284)]
public class IfcStructuralSurfaceAction : IfcStructuralAction, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralSurfaceAction, IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralSurfaceAction>, IExpressValidatable
{
	public enum IfcStructuralSurfaceActionClause
	{
		ProjectedIsGlobal,
		HasObjectType
	}

	private IfcProjectedOrTrueLengthEnum? _projectedOrTrue;

	private IfcStructuralSurfaceActivityTypeEnum _predefinedType;

	IfcProjectedOrTrueLengthEnum? IIfcStructuralSurfaceAction.ProjectedOrTrue
	{
		get
		{
			return ProjectedOrTrue;
		}
		set
		{
			ProjectedOrTrue = value;
		}
	}

	IfcStructuralSurfaceActivityTypeEnum IIfcStructuralSurfaceAction.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 24)]
	public IfcProjectedOrTrueLengthEnum? ProjectedOrTrue
	{
		get
		{
			if (_activated)
			{
				return _projectedOrTrue;
			}
			Activate();
			return _projectedOrTrue;
		}
		set
		{
			SetValue(delegate(IfcProjectedOrTrueLengthEnum? v)
			{
				_projectedOrTrue = v;
			}, _projectedOrTrue, value, "ProjectedOrTrue", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 25)]
	public IfcStructuralSurfaceActivityTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralSurfaceActivityTypeEnum v)
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			if (base.AppliedLoad != null)
			{
				yield return base.AppliedLoad;
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

	internal IfcStructuralSurfaceAction(IModel model, int label, bool activated)
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
			_projectedOrTrue = (IfcProjectedOrTrueLengthEnum)Enum.Parse(typeof(IfcProjectedOrTrueLengthEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_predefinedType = (IfcStructuralSurfaceActivityTypeEnum)Enum.Parse(typeof(IfcStructuralSurfaceActivityTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralSurfaceAction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralSurfaceActionClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcStructuralSurfaceActionClause.ProjectedIsGlobal:
				result = !Functions.EXISTS(ProjectedOrTrue) || ProjectedOrTrue != IfcProjectedOrTrueLengthEnum.PROJECTED_LENGTH || base.GlobalOrLocal == IfcGlobalOrLocalEnum.GLOBAL_COORDS;
				break;
			case IfcStructuralSurfaceActionClause.HasObjectType:
				result = PredefinedType != IfcStructuralSurfaceActivityTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralSurfaceAction>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralSurfaceAction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralSurfaceActionClause.ProjectedIsGlobal))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSurfaceAction.ProjectedIsGlobal",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStructuralSurfaceActionClause.HasObjectType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSurfaceAction.HasObjectType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
