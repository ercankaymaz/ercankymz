using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralLoadCase", 1281)]
public class IfcStructuralLoadCase : IfcStructuralLoadGroup, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLoadCase, IIfcStructuralLoadGroup, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcStructuralLoadCase>, IExpressValidatable
{
	public enum IfcStructuralLoadCaseClause
	{
		IsLoadCasePredefinedType
	}

	private readonly OptionalItemSet<IfcRatioMeasure> _selfWeightCoefficients;

	IItemSet<IfcRatioMeasure> IIfcStructuralLoadCase.SelfWeightCoefficients => SelfWeightCoefficients;

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 3 }, new int[] { 3 }, 25)]
	public IOptionalItemSet<IfcRatioMeasure> SelfWeightCoefficients
	{
		get
		{
			if (_activated)
			{
				return _selfWeightCoefficients;
			}
			Activate();
			return _selfWeightCoefficients;
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
		}
	}

	internal IfcStructuralLoadCase(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_selfWeightCoefficients = new OptionalItemSet<IfcRatioMeasure>(this, 3, 11);
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
			_selfWeightCoefficients.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadCase other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralLoadCaseClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralLoadCaseClause.IsLoadCasePredefinedType)
			{
				result = base.PredefinedType == IfcLoadGroupTypeEnum.LOAD_CASE;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralLoadCase>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralLoadCase.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralLoadCaseClause.IsLoadCasePredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralLoadCase.IsLoadCasePredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
