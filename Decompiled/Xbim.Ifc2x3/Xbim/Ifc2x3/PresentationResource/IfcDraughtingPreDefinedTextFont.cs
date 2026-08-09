using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationResource;

[ExpressType("IfcDraughtingPreDefinedTextFont", 761)]
public class IfcDraughtingPreDefinedTextFont : IfcPreDefinedTextFont, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcDraughtingPreDefinedTextFont>, IExpressValidatable
{
	public enum IfcDraughtingPreDefinedTextFontClause
	{
		WR31
	}

	internal IfcDraughtingPreDefinedTextFont(IModel model, int label, bool activated)
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

	public bool Equals(IfcDraughtingPreDefinedTextFont other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDraughtingPreDefinedTextFontClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDraughtingPreDefinedTextFontClause.WR31)
			{
				result = Functions.NewArray<string>("ISO 3098-1 font A", "ISO 3098-1 font B").Contains(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDraughtingPreDefinedTextFont>()?.LogError($"Exception thrown evaluating where-clause 'IfcDraughtingPreDefinedTextFont.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDraughtingPreDefinedTextFontClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDraughtingPreDefinedTextFont.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
