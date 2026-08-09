using System;
using System.Collections.Generic;
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

[ExpressType("IfcBoundaryCurve", 1106)]
public class IfcBoundaryCurve : IfcCompositeCurveOnSurface, IInstantiableEntity, IPersistEntity, IPersist, IIfcBoundaryCurve, IIfcCompositeCurveOnSurface, IIfcCompositeCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IfcCurveOnSurface, IIfcCurveOnSurface, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcBoundaryCurve>, IExpressValidatable
{
	public enum IfcBoundaryCurveClause
	{
		IsClosed
	}

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

	internal IfcBoundaryCurve(IModel model, int label, bool activated)
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

	public bool Equals(IfcBoundaryCurve other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBoundaryCurveClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcBoundaryCurveClause.IsClosed)
			{
				result = base.ClosedCurve.AsBool();
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBoundaryCurve>()?.LogError($"Exception thrown evaluating where-clause 'IfcBoundaryCurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcBoundaryCurveClause.IsClosed))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBoundaryCurve.IsClosed",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
