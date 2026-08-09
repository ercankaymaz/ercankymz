using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.PresentationDimensioningResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcAnnotationTextOccurrence", 122)]
public class IfcAnnotationTextOccurrence : IfcAnnotationOccurrence, IInstantiableEntity, IPersistEntity, IPersist, IfcDraughtingCalloutElement, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAnnotationTextOccurrence>, IExpressValidatable
{
	public enum IfcAnnotationTextOccurrenceClause
	{
		WR31
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Item != null)
			{
				yield return base.Item;
			}
			foreach (IfcPresentationStyleAssignment style in base.Styles)
			{
				yield return style;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.Item != null)
			{
				yield return base.Item;
			}
		}
	}

	internal IfcAnnotationTextOccurrence(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcAnnotationTextOccurrence other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAnnotationTextOccurrenceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAnnotationTextOccurrenceClause.WR31)
			{
				result = !Functions.EXISTS(base.Item) || Functions.TYPEOF(base.Item).Contains("IFC2X3.IFCTEXTLITERAL");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAnnotationTextOccurrence>()?.LogError($"Exception thrown evaluating where-clause 'IfcAnnotationTextOccurrence.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcAnnotationTextOccurrenceClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAnnotationTextOccurrence.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
