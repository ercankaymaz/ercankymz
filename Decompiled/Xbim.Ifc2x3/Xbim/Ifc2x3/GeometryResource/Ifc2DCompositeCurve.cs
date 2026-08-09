using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("Ifc2DCompositeCurve", 524)]
public class Ifc2DCompositeCurve : IfcCompositeCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<Ifc2DCompositeCurve>, IExpressValidatable
{
	public enum Ifc2DCompositeCurveClause
	{
		WR1,
		WR2
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

	internal Ifc2DCompositeCurve(IModel model, int label, bool activated)
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

	public bool Equals(Ifc2DCompositeCurve other)
	{
		return this == other;
	}

	public bool ValidateClause(Ifc2DCompositeCurveClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case Ifc2DCompositeCurveClause.WR1:
				result = base.ClosedCurve.Value;
				break;
			case Ifc2DCompositeCurveClause.WR2:
				result = base.Dim == 2L;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<Ifc2DCompositeCurve>()?.LogError($"Exception thrown evaluating where-clause 'Ifc2DCompositeCurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(Ifc2DCompositeCurveClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "Ifc2DCompositeCurve.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(Ifc2DCompositeCurveClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "Ifc2DCompositeCurve.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
