using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcAdvancedFace", 1094)]
public class IfcAdvancedFace : IfcFaceSurface, IInstantiableEntity, IPersistEntity, IPersist, IIfcAdvancedFace, IIfcFaceSurface, IIfcFace, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcAdvancedFace>, IExpressValidatable
{
	public enum IfcAdvancedFaceClause
	{
		ApplicableSurface,
		RequiresEdgeCurve,
		ApplicableEdgeCurves
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcFaceBound bound in base.Bounds)
			{
				yield return bound;
			}
			if (base.FaceSurface != null)
			{
				yield return base.FaceSurface;
			}
		}
	}

	internal IfcAdvancedFace(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcAdvancedFace other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAdvancedFaceClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcAdvancedFaceClause.ApplicableSurface:
				result = Functions.SIZEOF(Functions.NewTypesArray("IFC4.IFCELEMENTARYSURFACE", "IFC4.IFCSWEPTSURFACE", "IFC4.IFCBSPLINESURFACE") * Functions.TYPEOF(base.FaceSurface)) == 1;
				break;
			case IfcAdvancedFaceClause.RequiresEdgeCurve:
				result = Functions.SIZEOF(from ElpFbnds in Enumerable.Where(base.Bounds, (IfcFaceBound Bnds) => Functions.TYPEOF(Bnds.Bound).Contains("IFC4.IFCEDGELOOP"))
					where Functions.SIZEOF(Enumerable.Where(ElpFbnds.Bound.AsIfcEdgeLoop().EdgeList, (IfcOrientedEdge Oe) => !Functions.TYPEOF(Oe.EdgeElement).Contains("IFC4.IFCEDGECURVE"))) != 0
					select ElpFbnds) == 0;
				break;
			case IfcAdvancedFaceClause.ApplicableEdgeCurves:
				result = Functions.SIZEOF(from ElpFbnds in Enumerable.Where(base.Bounds, (IfcFaceBound Bnds) => Functions.TYPEOF(Bnds.Bound).Contains("IFC4.IFCEDGELOOP"))
					where Functions.SIZEOF(Enumerable.Where(ElpFbnds.Bound.AsIfcEdgeLoop().EdgeList, (IfcOrientedEdge Oe) => Functions.SIZEOF(Functions.NewTypesArray("IFC4.IFCLINE", "IFC4.IFCCONIC", "IFC4.IFCPOLYLINE", "IFC4.IFCBSPLINECURVE") * Functions.TYPEOF(Oe.EdgeElement.AsIfcEdgeCurve().EdgeGeometry)) != 1)) != 0
					select ElpFbnds) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAdvancedFace>()?.LogError($"Exception thrown evaluating where-clause 'IfcAdvancedFace.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcAdvancedFaceClause.ApplicableSurface))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAdvancedFace.ApplicableSurface",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAdvancedFaceClause.RequiresEdgeCurve))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAdvancedFace.RequiresEdgeCurve",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAdvancedFaceClause.ApplicableEdgeCurves))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAdvancedFace.ApplicableEdgeCurves",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
