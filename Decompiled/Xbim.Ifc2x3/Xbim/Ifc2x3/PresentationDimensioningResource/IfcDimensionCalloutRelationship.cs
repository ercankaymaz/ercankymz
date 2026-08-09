using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.IfcFunctions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationDimensioningResource;

[ExpressType("IfcDimensionCalloutRelationship", 741)]
public class IfcDimensionCalloutRelationship : IfcDraughtingCalloutRelationship, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDimensionCalloutRelationship>, IExpressValidatable
{
	public enum IfcDimensionCalloutRelationshipClause
	{
		WR11,
		WR12,
		WR13
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.RelatingDraughtingCallout != null)
			{
				yield return base.RelatingDraughtingCallout;
			}
			if (base.RelatedDraughtingCallout != null)
			{
				yield return base.RelatedDraughtingCallout;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.RelatingDraughtingCallout != null)
			{
				yield return base.RelatingDraughtingCallout;
			}
			if (base.RelatedDraughtingCallout != null)
			{
				yield return base.RelatedDraughtingCallout;
			}
		}
	}

	internal IfcDimensionCalloutRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcDimensionCalloutRelationship other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDimensionCalloutRelationshipClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcDimensionCalloutRelationshipClause.WR11:
			{
				ValuesArray<string> valuesArray = Functions.NewArray<string>("primary", "secondary");
				IfcLabel? name = base.Name;
				result = valuesArray.Contains(name.HasValue ? ((string)name.GetValueOrDefault()) : null);
				break;
			}
			case IfcDimensionCalloutRelationshipClause.WR12:
				result = Functions.SIZEOF(Functions.TYPEOF(base.RelatingDraughtingCallout) * Functions.NewArray<string>("IFC2X3.IFCANGULARDIMENSION", "IFC2X3.IFCDIAMETERDIMENSION", "IFC2X3.IFCLINEARDIMENSION", "IFC2X3.IFCRADIUSDIMENSION")) == 1;
				break;
			case IfcDimensionCalloutRelationshipClause.WR13:
				result = !Functions.TYPEOF(base.RelatedDraughtingCallout).Contains("IFC2X3.IFCDIMENSIONCURVEDIRECTEDCALLOUT");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDimensionCalloutRelationship>()?.LogError($"Exception thrown evaluating where-clause 'IfcDimensionCalloutRelationship.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDimensionCalloutRelationshipClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCalloutRelationship.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDimensionCalloutRelationshipClause.WR12))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCalloutRelationship.WR12",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDimensionCalloutRelationshipClause.WR13))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionCalloutRelationship.WR13",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
