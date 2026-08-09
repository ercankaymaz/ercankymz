using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcShapeRepresentation", 664)]
public class IfcShapeRepresentation : IfcShapeModel, IInstantiableEntity, IPersistEntity, IPersist, IIfcShapeRepresentation, IIfcShapeModel, IIfcRepresentation, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcShapeRepresentation>, IExpressValidatable
{
	public enum IfcShapeRepresentationClause
	{
		CorrectContext,
		NoTopologicalItem,
		HasRepresentationType,
		CorrectItemsForType,
		HasRepresentationIdentifier
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ContextOfItems != null)
			{
				yield return base.ContextOfItems;
			}
			foreach (IfcRepresentationItem item in base.Items)
			{
				yield return item;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ContextOfItems != null)
			{
				yield return base.ContextOfItems;
			}
		}
	}

	internal IfcShapeRepresentation(IModel model, int label, bool activated)
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

	public bool Equals(IfcShapeRepresentation other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcShapeRepresentationClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcShapeRepresentationClause.CorrectContext:
				result = Functions.TYPEOF(base.ContextOfItems).Contains("IFC4.IFCGEOMETRICREPRESENTATIONCONTEXT");
				break;
			case IfcShapeRepresentationClause.NoTopologicalItem:
				result = Functions.SIZEOF(Enumerable.Where(base.Items, (IfcRepresentationItem temp) => Functions.TYPEOF(temp).Contains("IFC4.IFCTOPOLOGICALREPRESENTATIONITEM") && Functions.SIZEOF(Functions.NewTypesArray("IFC4.IFCVERTEXPOINT", "IFC4.IFCEDGECURVE", "IFC4.IFCFACESURFACE") * Functions.TYPEOF(temp)) != 1)) == 0;
				break;
			case IfcShapeRepresentationClause.HasRepresentationType:
				result = Functions.EXISTS(base.RepresentationType);
				break;
			case IfcShapeRepresentationClause.CorrectItemsForType:
				result = Functions.IfcShapeRepresentationTypes(base.RepresentationType, base.Items);
				break;
			case IfcShapeRepresentationClause.HasRepresentationIdentifier:
				result = Functions.EXISTS(base.RepresentationIdentifier);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcShapeRepresentation>()?.LogError($"Exception thrown evaluating where-clause 'IfcShapeRepresentation.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcShapeRepresentationClause.CorrectContext))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.CorrectContext",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcShapeRepresentationClause.NoTopologicalItem))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.NoTopologicalItem",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcShapeRepresentationClause.HasRepresentationType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.HasRepresentationType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcShapeRepresentationClause.CorrectItemsForType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.CorrectItemsForType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcShapeRepresentationClause.HasRepresentationIdentifier))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.HasRepresentationIdentifier",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
