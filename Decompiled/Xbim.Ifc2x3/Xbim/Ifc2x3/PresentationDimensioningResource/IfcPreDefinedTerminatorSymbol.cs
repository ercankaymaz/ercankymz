using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PresentationDefinitionResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcPreDefinedTerminatorSymbol", 749)]
public class IfcPreDefinedTerminatorSymbol : IfcPreDefinedSymbol, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcPreDefinedTerminatorSymbol>, IExpressValidatable
{
	public enum IfcPreDefinedTerminatorSymbolClause
	{
		WR31
	}

	internal IfcPreDefinedTerminatorSymbol(IModel model, int label, bool activated)
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

	public bool Equals(IfcPreDefinedTerminatorSymbol other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPreDefinedTerminatorSymbolClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPreDefinedTerminatorSymbolClause.WR31)
			{
				result = Functions.NewArray<string>("blanked arrow", "blanked box", "blanked dot", "dimension origin", "filled arrow", "filled box", "filled dot", "integral symbol", "open arrow", "slash", "unfilled arrow").Contains(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPreDefinedTerminatorSymbol>()?.LogError($"Exception thrown evaluating where-clause 'IfcPreDefinedTerminatorSymbol.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPreDefinedTerminatorSymbolClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPreDefinedTerminatorSymbol.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
