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

[ExpressType("IfcStructuralCurveReaction", 1280)]
public class IfcStructuralCurveReaction : IfcStructuralReaction, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralCurveReaction, IIfcStructuralReaction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralCurveReaction>, IExpressValidatable
{
	public enum IfcStructuralCurveReactionClause
	{
		HasObjectType,
		SuitablePredefinedType
	}

	private IfcStructuralCurveActivityTypeEnum _predefinedType;

	IfcStructuralCurveActivityTypeEnum IIfcStructuralCurveReaction.PredefinedType
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
	public IfcStructuralCurveActivityTypeEnum PredefinedType
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
			SetValue(delegate(IfcStructuralCurveActivityTypeEnum v)
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

	internal IfcStructuralCurveReaction(IModel model, int label, bool activated)
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
			_predefinedType = (IfcStructuralCurveActivityTypeEnum)Enum.Parse(typeof(IfcStructuralCurveActivityTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralCurveReaction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralCurveReactionClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcStructuralCurveReactionClause.HasObjectType:
				result = PredefinedType != IfcStructuralCurveActivityTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
				break;
			case IfcStructuralCurveReactionClause.SuitablePredefinedType:
				result = PredefinedType != IfcStructuralCurveActivityTypeEnum.SINUS && PredefinedType != IfcStructuralCurveActivityTypeEnum.PARABOLA;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralCurveReaction>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralCurveReaction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralCurveReactionClause.HasObjectType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralCurveReaction.HasObjectType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStructuralCurveReactionClause.SuitablePredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralCurveReaction.SuitablePredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
