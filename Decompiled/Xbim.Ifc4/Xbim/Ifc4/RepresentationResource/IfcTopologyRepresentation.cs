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

[ExpressType("IfcTopologyRepresentation", 88)]
public class IfcTopologyRepresentation : IfcShapeModel, IInstantiableEntity, IPersistEntity, IPersist, IIfcTopologyRepresentation, IIfcShapeModel, IIfcRepresentation, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTopologyRepresentation>, IExpressValidatable
{
	public enum IfcTopologyRepresentationClause
	{
		WR21,
		WR22,
		WR23
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

	internal IfcTopologyRepresentation(IModel model, int label, bool activated)
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

	public bool Equals(IfcTopologyRepresentation other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTopologyRepresentationClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcTopologyRepresentationClause.WR21:
				result = Functions.SIZEOF(Enumerable.Where(base.Items, (IfcRepresentationItem temp) => !Functions.TYPEOF(temp).Contains("IFC4.IFCTOPOLOGICALREPRESENTATIONITEM"))) == 0;
				break;
			case IfcTopologyRepresentationClause.WR22:
				result = Functions.EXISTS(base.RepresentationType);
				break;
			case IfcTopologyRepresentationClause.WR23:
				result = Functions.IfcTopologyRepresentationTypes(base.RepresentationType, base.Items);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTopologyRepresentation>()?.LogError($"Exception thrown evaluating where-clause 'IfcTopologyRepresentation.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTopologyRepresentationClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTopologyRepresentation.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTopologyRepresentationClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTopologyRepresentation.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTopologyRepresentationClause.WR23))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTopologyRepresentation.WR23",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
