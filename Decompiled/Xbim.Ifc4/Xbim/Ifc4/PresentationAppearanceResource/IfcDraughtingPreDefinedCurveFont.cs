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

[ExpressType("IfcDraughtingPreDefinedCurveFont", 286)]
public class IfcDraughtingPreDefinedCurveFont : IfcPreDefinedCurveFont, IInstantiableEntity, IPersistEntity, IPersist, IIfcDraughtingPreDefinedCurveFont, IIfcPreDefinedCurveFont, IIfcPreDefinedItem, IIfcPresentationItem, IfcCurveStyleFontSelect, IfcCurveFontOrScaledCurveFontSelect, IIfcCurveFontOrScaledCurveFontSelect, IExpressSelectType, IIfcCurveStyleFontSelect, IEquatable<IfcDraughtingPreDefinedCurveFont>, IExpressValidatable
{
	public enum IfcDraughtingPreDefinedCurveFontClause
	{
		PreDefinedCurveFontNames
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
			if (clause == IfcDraughtingPreDefinedCurveFontClause.PreDefinedCurveFontNames)
			{
				result = Functions.NewTypesArray("continuous", "chain", "chain double dash", "dashed", "dotted", "by layer").Contains(base.Name);
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
		if (!ValidateClause(IfcDraughtingPreDefinedCurveFontClause.PreDefinedCurveFontNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDraughtingPreDefinedCurveFont.PreDefinedCurveFontNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
