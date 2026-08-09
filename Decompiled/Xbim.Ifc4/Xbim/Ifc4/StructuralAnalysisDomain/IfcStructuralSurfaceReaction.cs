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

[ExpressType("IfcStructuralSurfaceReaction", 1285)]
public class IfcStructuralSurfaceReaction : IfcStructuralReaction, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralSurfaceReaction, IIfcStructuralReaction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralSurfaceReaction>, IExpressValidatable
{
	public enum IfcStructuralSurfaceReactionClause
	{
		HasPredefinedType
	}

	private IfcStructuralSurfaceActivityTypeEnum _predefinedType;

	IfcStructuralSurfaceActivityTypeEnum IIfcStructuralSurfaceReaction.PredefinedType
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

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
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
			}, _predefinedType, value, "PredefinedType", 10);
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

	internal IfcStructuralSurfaceReaction(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcStructuralSurfaceActivityTypeEnum)Enum.Parse(typeof(IfcStructuralSurfaceActivityTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralSurfaceReaction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralSurfaceReactionClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralSurfaceReactionClause.HasPredefinedType)
			{
				result = PredefinedType != IfcStructuralSurfaceActivityTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralSurfaceReaction>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralSurfaceReaction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralSurfaceReactionClause.HasPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralSurfaceReaction.HasPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
