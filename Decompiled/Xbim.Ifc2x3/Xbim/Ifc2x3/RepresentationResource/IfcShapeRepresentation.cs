using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.RepresentationResource;

[ExpressType("IfcShapeRepresentation", 664)]
public class IfcShapeRepresentation : IfcShapeModel, IIfcShapeRepresentation, IIfcShapeModel, IIfcRepresentation, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcShapeRepresentation>, IExpressValidatable
{
	public enum IfcShapeRepresentationClause
	{
		WR21,
		WR22,
		WR23,
		WR24
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
			case IfcShapeRepresentationClause.WR21:
				result = Functions.TYPEOF(base.ContextOfItems).Contains("IFC2X3.IFCGEOMETRICREPRESENTATIONCONTEXT");
				break;
			case IfcShapeRepresentationClause.WR22:
				result = Functions.SIZEOF(Enumerable.Where(base.Items, (IfcRepresentationItem temp) => Functions.TYPEOF(temp).Contains("IFC2X3.IFCTOPOLOGICALREPRESENTATIONITEM") && Functions.SIZEOF(Functions.NewArray<string>("IFC2X3.IFCVERTEXPOINT", "IFC2X3.IFCEDGECURVE", "IFC2X3.IFCFACESURFACE") * Functions.TYPEOF(temp)) != 1)) == 0;
				break;
			case IfcShapeRepresentationClause.WR23:
				result = Functions.EXISTS(base.RepresentationType);
				break;
			case IfcShapeRepresentationClause.WR24:
				result = Functions.IfcShapeRepresentationTypes(base.RepresentationType, base.Items);
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
		if (!ValidateClause(IfcShapeRepresentationClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcShapeRepresentationClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcShapeRepresentationClause.WR23))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.WR23",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcShapeRepresentationClause.WR24))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcShapeRepresentation.WR24",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
