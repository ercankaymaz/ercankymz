using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcDimensionCurveDirectedCallout", 737)]
public class IfcDimensionCurveDirectedCallout : IfcDraughtingCallout, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcDimensionCurveDirectedCallout>, IExpressValidatable
{
	public enum IfcDimensionCurveDirectedCalloutClause
	{
		WR41,
		WR42
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

	internal IfcDimensionCurveDirectedCallout(IModel model, int label, bool activated)
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

	public bool Equals(IfcDimensionCurveDirectedCallout other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDimensionCurveDirectedCalloutClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcDimensionCurveDirectedCalloutClause.WR41:
				result = Functions.SIZEOF(Enumerable.Where(base.Contents, (IfcDraughtingCalloutElement Dc) => Functions.TYPEOF(Dc).Contains("IFC2X3.IFCDIMENSIONCURVE"))) == 1;
				break;
			case IfcDimensionCurveDirectedCalloutClause.WR42:
				result = Functions.SIZEOF(Enumerable.Where(base.Contents, (IfcDraughtingCalloutElement Dc) => Functions.TYPEOF(Dc).Contains("IFC2X3.IFCPROJECTIONCURVE"))) <= 2;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDimensionCurveDirectedCallout>()?.LogError($"Exception thrown evaluating where-clause 'IfcDimensionCurveDirectedCallout.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDimensionCurveDirectedCalloutClause.WR41))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCurveDirectedCallout.WR41",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDimensionCurveDirectedCalloutClause.WR42))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCurveDirectedCallout.WR42",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
