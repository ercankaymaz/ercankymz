using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCompositeCurveOnSurface", 1130)]
public class IfcCompositeCurveOnSurface : IfcCompositeCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcCompositeCurveOnSurface, IIfcCompositeCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IfcCurveOnSurface, IIfcCurveOnSurface, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCompositeCurveOnSurface>, IExpressValidatable
{
	public enum IfcCompositeCurveOnSurfaceClause
	{
		SameSurface
	}

	List<IIfcSurface> IIfcCompositeCurveOnSurface.BasisSurface => new List<IIfcSurface>(BasisSurface);

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 0)]
	public List<IfcSurface> BasisSurface => IfcGetBasisSurface(this).ToList();

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCompositeCurveSegment segment in base.Segments)
			{
				yield return segment;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcCompositeCurveSegment segment in base.Segments)
			{
				yield return segment;
			}
		}
	}

	internal IfcCompositeCurveOnSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 1u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcCompositeCurveOnSurface other)
	{
		return this == other;
	}

	private static IEnumerable<IfcSurface> IfcGetBasisSurface(IfcCurveOnSurface curveOnSurface)
	{
		IfcPcurve ifcPcurve = curveOnSurface as IfcPcurve;
		if (ifcPcurve != null)
		{
			yield return ifcPcurve.BasisSurface;
			yield break;
		}
		IfcCompositeCurveOnSurface ifcCompositeCurveOnSurface = curveOnSurface as IfcCompositeCurveOnSurface;
		if (ifcCompositeCurveOnSurface == null)
		{
			yield break;
		}
		foreach (IfcCompositeCurveSegment segment in ifcCompositeCurveOnSurface.Segments)
		{
			if (!(segment.ParentCurve is IfcCurveOnSurface curveOnSurface2))
			{
				continue;
			}
			foreach (IfcSurface item in IfcGetBasisSurface(curveOnSurface2))
			{
				yield return item;
			}
		}
	}

	public bool ValidateClause(IfcCompositeCurveOnSurfaceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCompositeCurveOnSurfaceClause.SameSurface)
			{
				result = Functions.SIZEOF(BasisSurface) > 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCompositeCurveOnSurface>()?.LogError($"Exception thrown evaluating where-clause 'IfcCompositeCurveOnSurface.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcCompositeCurveOnSurfaceClause.SameSurface))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeCurveOnSurface.SameSurface",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
