using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.SharedMgmtElements;

[ExpressType("IfcRelSchedulesCostItems", 700)]
public class IfcRelSchedulesCostItems : IfcRelAssignsToControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelSchedulesCostItems>, IExpressValidatable
{
	public enum IfcRelSchedulesCostItemsClause
	{
		WR11,
		WR12
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (base.RelatingControl != null)
			{
				yield return base.RelatingControl;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (base.RelatingControl != null)
			{
				yield return base.RelatingControl;
			}
		}
	}

	internal IfcRelSchedulesCostItems(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 6u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcRelSchedulesCostItems other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelSchedulesCostItemsClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRelSchedulesCostItemsClause.WR11:
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCCOSTITEM"))) == 0;
				break;
			case IfcRelSchedulesCostItemsClause.WR12:
				result = Functions.TYPEOF(base.RelatingControl).Contains("IFC2X3.IFCCOSTSCHEDULE");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelSchedulesCostItems>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelSchedulesCostItems.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelSchedulesCostItemsClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelSchedulesCostItems.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRelSchedulesCostItemsClause.WR12))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelSchedulesCostItems.WR12",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
