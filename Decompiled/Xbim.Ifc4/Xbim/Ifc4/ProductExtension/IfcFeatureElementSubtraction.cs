using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcFeatureElementSubtraction", 499)]
public abstract class IfcFeatureElementSubtraction : IfcFeatureElement, IIfcFeatureElementSubtraction, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcFeatureElementSubtraction>, IExpressValidatable
{
	public enum IfcFeatureElementSubtractionClause
	{
		HasNoSubtraction,
		IsNotFilling
	}

	IIfcRelVoidsElement IIfcFeatureElementSubtraction.VoidsElements => VoidsElements;

	[InverseProperty("RelatedOpeningElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 33)]
	public IfcRelVoidsElement VoidsElements => base.Model.Instances.FirstOrDefault((IfcRelVoidsElement e) => Equals(e.RelatedOpeningElement), "RelatedOpeningElement", this);

	internal IfcFeatureElementSubtraction(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 7u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcFeatureElementSubtraction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcFeatureElementSubtractionClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcFeatureElementSubtractionClause.HasNoSubtraction:
				result = Functions.SIZEOF(base.HasOpenings) == 0;
				break;
			case IfcFeatureElementSubtractionClause.IsNotFilling:
				result = Functions.SIZEOF(base.FillsVoids) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFeatureElementSubtraction>()?.LogError($"Exception thrown evaluating where-clause 'IfcFeatureElementSubtraction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcFeatureElementSubtractionClause.HasNoSubtraction))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFeatureElementSubtraction.HasNoSubtraction",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcFeatureElementSubtractionClause.IsNotFilling))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFeatureElementSubtraction.IsNotFilling",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
