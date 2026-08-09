using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.IfcFunctions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcStructuredDimensionCallout", 752)]
public class IfcStructuredDimensionCallout : IfcDraughtingCallout, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcStructuredDimensionCallout>, IExpressValidatable
{
	public enum IfcStructuredDimensionCalloutClause
	{
		WR31
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcDraughtingCalloutElement content in base.Contents)
			{
				yield return content;
			}
		}
	}

	internal IfcStructuredDimensionCallout(IModel model, int label, bool activated)
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

	public bool Equals(IfcStructuredDimensionCallout other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuredDimensionCalloutClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuredDimensionCalloutClause.WR31)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.Contents, (IfcDraughtingCalloutElement Con) => Functions.TYPEOF(Con).Contains("IFC2X3.IFCANNOTATIONTEXTOCCURRENCE")).Where(delegate(IfcDraughtingCalloutElement Ato)
				{
					ValuesArray<string> valuesArray = Functions.NewArray<string>("dimension value", "tolerance value", "unit text", "prefix text", "suffix text");
					IfcLabel? name = Ato.AsIfcAnnotationTextOccurrence().Name;
					return !valuesArray.Contains(name.HasValue ? ((string)name.GetValueOrDefault()) : null);
				})) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuredDimensionCallout>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuredDimensionCallout.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcStructuredDimensionCalloutClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuredDimensionCallout.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
