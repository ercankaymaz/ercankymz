using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcDraughtingPreDefinedCurveFont", 286)]
public class IfcDraughtingPreDefinedCurveFont : IfcPreDefinedCurveFont, IIfcDraughtingPreDefinedCurveFont, IIfcPreDefinedCurveFont, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcCurveStyleFontSelect, Xbim.Ifc4.PresentationAppearanceResource.IfcCurveFontOrScaledCurveFontSelect, IIfcCurveFontOrScaledCurveFontSelect, IExpressSelectType, IIfcCurveStyleFontSelect, IInstantiableEntity, IEquatable<IfcDraughtingPreDefinedCurveFont>, IExpressValidatable
{
	public enum IfcDraughtingPreDefinedCurveFontClause
	{
		WR31
	}

	internal IfcDraughtingPreDefinedCurveFont(IModel model, int label, bool activated)
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

	public bool Equals(IfcDraughtingPreDefinedCurveFont other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDraughtingPreDefinedCurveFontClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDraughtingPreDefinedCurveFontClause.WR31)
			{
				result = Functions.NewArray<string>("continuous", "chain", "chain double dash", "dashed", "dotted", "by layer").Contains(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDraughtingPreDefinedCurveFont>()?.LogError($"Exception thrown evaluating where-clause 'IfcDraughtingPreDefinedCurveFont.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDraughtingPreDefinedCurveFontClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDraughtingPreDefinedCurveFont.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
