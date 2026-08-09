using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcDraughtingPreDefinedColour", 607)]
public class IfcDraughtingPreDefinedColour : IfcPreDefinedColour, IInstantiableEntity, IPersistEntity, IPersist, IIfcDraughtingPreDefinedColour, IIfcPreDefinedColour, IIfcPreDefinedItem, IIfcPresentationItem, IfcColour, IfcFillStyleSelect, IIfcFillStyleSelect, IExpressSelectType, IIfcColour, IEquatable<IfcDraughtingPreDefinedColour>, IExpressValidatable
{
	public enum IfcDraughtingPreDefinedColourClause
	{
		PreDefinedColourNames
	}

	internal IfcDraughtingPreDefinedColour(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcDraughtingPreDefinedColour other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDraughtingPreDefinedColourClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDraughtingPreDefinedColourClause.PreDefinedColourNames)
			{
				result = Functions.NewTypesArray("black", "red", "green", "blue", "yellow", "magenta", "cyan", "white", "by layer").Contains(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDraughtingPreDefinedColour>()?.LogError($"Exception thrown evaluating where-clause 'IfcDraughtingPreDefinedColour.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDraughtingPreDefinedColourClause.PreDefinedColourNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDraughtingPreDefinedColour.PreDefinedColourNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
