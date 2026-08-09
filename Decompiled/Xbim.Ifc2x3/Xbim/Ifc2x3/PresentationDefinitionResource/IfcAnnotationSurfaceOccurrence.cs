using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcAnnotationSurfaceOccurrence", 509)]
public class IfcAnnotationSurfaceOccurrence : IfcAnnotationOccurrence, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAnnotationSurfaceOccurrence>, IExpressValidatable
{
	public enum IfcAnnotationSurfaceOccurrenceClause
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

	internal IfcAnnotationSurfaceOccurrence(IModel model, int label, bool activated)
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

	public bool Equals(IfcAnnotationSurfaceOccurrence other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAnnotationSurfaceOccurrenceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAnnotationSurfaceOccurrenceClause.WR31)
			{
				result = !Functions.EXISTS(base.Item) || Functions.SIZEOF(Functions.NewArray<string>("IFC2X3.IFCSURFACE", "IFC2X3.IFCFACEBASEDSURFACEMODEL", "IFC2X3.IFCSHELLBASEDSURFACEMODEL", "IFC2X3.IFCSOLIDMODEL") * Functions.TYPEOF(base.Item)) > 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAnnotationSurfaceOccurrence>()?.LogError($"Exception thrown evaluating where-clause 'IfcAnnotationSurfaceOccurrence.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcAnnotationSurfaceOccurrenceClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAnnotationSurfaceOccurrence.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
