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
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcRationalBSplineCurveWithKnots", 1241)]
public class IfcRationalBSplineCurveWithKnots : IfcBSplineCurveWithKnots, IInstantiableEntity, IPersistEntity, IPersist, IIfcRationalBSplineCurveWithKnots, IIfcBSplineCurveWithKnots, IIfcBSplineCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcRationalBSplineCurveWithKnots>, IExpressValidatable
{
	public enum IfcRationalBSplineCurveWithKnotsClause
	{
		SameNumOfWeightsAndPoints,
		WeightsGreaterZero
	}

	private readonly ItemSet<IfcReal> _weightsData;

	IItemSet<IfcReal> IIfcRationalBSplineCurveWithKnots.WeightsData => WeightsData;

	List<IfcReal> IIfcRationalBSplineCurveWithKnots.Weights => new List<IfcReal>(Weights);

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 11)]
	public IItemSet<IfcReal> WeightsData
	{
		get
		{
			if (_activated)
			{
				return _weightsData;
			}
			Activate();
			return _weightsData;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Array, EntityAttributeType.None, new int[] { 0 }, new int[] { -1 }, 0)]
	public List<IfcReal> Weights => WeightsData.ToList();

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCartesianPoint controlPoints in base.ControlPointsList)
			{
				yield return controlPoints;
			}
		}
	}

	internal IfcRationalBSplineCurveWithKnots(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_weightsData = new ItemSet<IfcReal>(this, 0, 9);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_weightsData.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRationalBSplineCurveWithKnots other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRationalBSplineCurveWithKnotsClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRationalBSplineCurveWithKnotsClause.SameNumOfWeightsAndPoints:
				result = Functions.SIZEOF(WeightsData) == Functions.SIZEOF(base.ControlPointsList);
				break;
			case IfcRationalBSplineCurveWithKnotsClause.WeightsGreaterZero:
				result = Functions.IfcCurveWeightsPositive(this);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRationalBSplineCurveWithKnots>()?.LogError($"Exception thrown evaluating where-clause 'IfcRationalBSplineCurveWithKnots.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRationalBSplineCurveWithKnotsClause.SameNumOfWeightsAndPoints))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRationalBSplineCurveWithKnots.SameNumOfWeightsAndPoints",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRationalBSplineCurveWithKnotsClause.WeightsGreaterZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRationalBSplineCurveWithKnots.WeightsGreaterZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
