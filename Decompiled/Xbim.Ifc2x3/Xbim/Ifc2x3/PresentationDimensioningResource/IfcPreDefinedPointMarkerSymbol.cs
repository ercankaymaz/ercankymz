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

[ExpressType("IfcPreDefinedPointMarkerSymbol", 748)]
public class IfcPreDefinedPointMarkerSymbol : IfcPreDefinedSymbol, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcPreDefinedPointMarkerSymbol>, IExpressValidatable
{
	public enum IfcPreDefinedPointMarkerSymbolClause
	{
		WR31
	}

	internal IfcPreDefinedPointMarkerSymbol(IModel model, int label, bool activated)
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

	public bool Equals(IfcPreDefinedPointMarkerSymbol other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPreDefinedPointMarkerSymbolClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPreDefinedPointMarkerSymbolClause.WR31)
			{
				result = Functions.NewArray<string>("asterisk", "circle", "dot", "plus", "square", "triangle", "x").Contains(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPreDefinedPointMarkerSymbol>()?.LogError($"Exception thrown evaluating where-clause 'IfcPreDefinedPointMarkerSymbol.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPreDefinedPointMarkerSymbolClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPreDefinedPointMarkerSymbol.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
