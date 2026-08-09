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

[ExpressType("IfcDimensionPair", 745)]
public class IfcDimensionPair : IfcDraughtingCalloutRelationship, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDimensionPair>, IExpressValidatable
{
	public enum IfcDimensionPairClause
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

	internal IfcDimensionPair(IModel model, int label, bool activated)
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

	public bool Equals(IfcDimensionPair other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDimensionPairClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcDimensionPairClause.WR11:
			{
				ValuesArray<string> valuesArray = Functions.NewArray<string>("chained", "parallel");
				IfcLabel? name = base.Name;
				result = valuesArray.Contains(name.HasValue ? ((string)name.GetValueOrDefault()) : null);
				break;
			}
			case IfcDimensionPairClause.WR12:
				result = Functions.SIZEOF(Functions.TYPEOF(base.RelatingDraughtingCallout) * Functions.NewArray<string>("IFC2X3.IFCANGULARDIMENSION", "IFC2X3.IFCDIAMETERDIMENSION", "IFC2X3.IFCLINEARDIMENSION", "IFC2X3.IFCRADIUSDIMENSION")) == 1;
				break;
			case IfcDimensionPairClause.WR13:
				result = Functions.SIZEOF(Functions.TYPEOF(base.RelatedDraughtingCallout) * Functions.NewArray<string>("IFC2X3.IFCANGULARDIMENSION", "IFC2X3.IFCDIAMETERDIMENSION", "IFC2X3.IFCLINEARDIMENSION", "IFC2X3.IFCRADIUSDIMENSION")) == 1;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDimensionPair>()?.LogError($"Exception thrown evaluating where-clause 'IfcDimensionPair.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDimensionPairClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionPair.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDimensionPairClause.WR12))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionPair.WR12",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDimensionPairClause.WR13))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDimensionPair.WR13",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
