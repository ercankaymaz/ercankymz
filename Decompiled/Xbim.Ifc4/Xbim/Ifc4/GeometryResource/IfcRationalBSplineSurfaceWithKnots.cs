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

[ExpressType("IfcRationalBSplineSurfaceWithKnots", 1242)]
public class IfcRationalBSplineSurfaceWithKnots : IfcBSplineSurfaceWithKnots, IInstantiableEntity, IPersistEntity, IPersist, IIfcRationalBSplineSurfaceWithKnots, IIfcBSplineSurfaceWithKnots, IIfcBSplineSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcRationalBSplineSurfaceWithKnots>, IExpressValidatable
{
	public enum IfcRationalBSplineSurfaceWithKnotsClause
	{
		CorrespondingWeightsDataLists,
		WeightValuesGreaterZero
	}

	private readonly ItemSet<IItemSet<IfcReal>> _weightsData;

	IItemSet<IItemSet<IfcReal>> IIfcRationalBSplineSurfaceWithKnots.WeightsData => WeightsData;

	List<List<IfcReal>> IIfcRationalBSplineSurfaceWithKnots.Weights => new List<List<IfcReal>>(Weights);

	[EntityAttribute(13, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 2, 2 }, new int[] { -1, -1 }, 15)]
	public IItemSet<IItemSet<IfcReal>> WeightsData
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

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Array, EntityAttributeType.Array, new int[] { 0, 0 }, new int[] { -1, -1 }, 0)]
	public List<List<IfcReal>> Weights => WeightsData.Select((IItemSet<IfcReal> wd) => wd.ToList()).ToList();

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IItemSet<IfcCartesianPoint> controlPoints in base.ControlPointsList)
			{
				foreach (IfcCartesianPoint item in controlPoints)
				{
					yield return item;
				}
			}
		}
	}

	internal IfcRationalBSplineSurfaceWithKnots(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_weightsData = new ItemSet<IItemSet<IfcReal>>(this, 0, 13);
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
		case 8:
		case 9:
		case 10:
		case 11:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 12:
			((ItemSet<IfcReal>)_weightsData.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRationalBSplineSurfaceWithKnots other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRationalBSplineSurfaceWithKnotsClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcRationalBSplineSurfaceWithKnotsClause.CorrespondingWeightsDataLists:
				result = Functions.SIZEOF(WeightsData) == Functions.SIZEOF(base.ControlPointsList) && Functions.SIZEOF(WeightsData.ItemAt(0L)) == Functions.SIZEOF(base.ControlPointsList.ItemAt(0L));
				break;
			case IfcRationalBSplineSurfaceWithKnotsClause.WeightValuesGreaterZero:
				result = Functions.IfcSurfaceWeightsPositive(this);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRationalBSplineSurfaceWithKnots>()?.LogError($"Exception thrown evaluating where-clause 'IfcRationalBSplineSurfaceWithKnots.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRationalBSplineSurfaceWithKnotsClause.CorrespondingWeightsDataLists))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRationalBSplineSurfaceWithKnots.CorrespondingWeightsDataLists",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcRationalBSplineSurfaceWithKnotsClause.WeightValuesGreaterZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRationalBSplineSurfaceWithKnots.WeightValuesGreaterZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
