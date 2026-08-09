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

[ExpressType("IfcPreDefinedDimensionSymbol", 747)]
public class IfcPreDefinedDimensionSymbol : IfcPreDefinedSymbol, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcPreDefinedDimensionSymbol>, IExpressValidatable
{
	public enum IfcPreDefinedDimensionSymbolClause
	{
		WR31
	}

	internal IfcPreDefinedDimensionSymbol(IModel model, int label, bool activated)
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

	public bool Equals(IfcPreDefinedDimensionSymbol other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPreDefinedDimensionSymbolClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPreDefinedDimensionSymbolClause.WR31)
			{
				result = Functions.NewArray<string>("arc length", "conical taper", "counterbore", "countersink", "depth", "diameter", "plus minus", "radius", "slope", "spherical diameter", "spherical radius", "square").Contains(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPreDefinedDimensionSymbol>()?.LogError($"Exception thrown evaluating where-clause 'IfcPreDefinedDimensionSymbol.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPreDefinedDimensionSymbolClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPreDefinedDimensionSymbol.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
