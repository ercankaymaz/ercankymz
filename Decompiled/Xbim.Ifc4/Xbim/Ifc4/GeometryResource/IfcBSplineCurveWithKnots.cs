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
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcBSplineCurveWithKnots", 1101)]
public class IfcBSplineCurveWithKnots : IfcBSplineCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcBSplineCurveWithKnots, IIfcBSplineCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcBSplineCurveWithKnots>, IExpressValidatable
{
	public enum IfcBSplineCurveWithKnotsClause
	{
		ConsistentBSpline,
		CorrespondingKnotLists
	}

	private readonly ItemSet<IfcInteger> _knotMultiplicities;

	private readonly ItemSet<IfcParameterValue> _knots;

	private IfcKnotType _knotSpec;

	IItemSet<IfcInteger> IIfcBSplineCurveWithKnots.KnotMultiplicities => KnotMultiplicities;

	IItemSet<IfcParameterValue> IIfcBSplineCurveWithKnots.Knots => Knots;

	IfcKnotType IIfcBSplineCurveWithKnots.KnotSpec
	{
		get
		{
			return KnotSpec;
		}
		set
		{
			KnotSpec = value;
		}
	}

	IfcInteger IIfcBSplineCurveWithKnots.UpperIndexOnKnots => UpperIndexOnKnots;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 8)]
	public IItemSet<IfcInteger> KnotMultiplicities
	{
		get
		{
			if (_activated)
			{
				return _knotMultiplicities;
			}
			Activate();
			return _knotMultiplicities;
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 9)]
	public IItemSet<IfcParameterValue> Knots
	{
		get
		{
			if (_activated)
			{
				return _knots;
			}
			Activate();
			return _knots;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcKnotType KnotSpec
	{
		get
		{
			if (_activated)
			{
				return _knotSpec;
			}
			Activate();
			return _knotSpec;
		}
		set
		{
			SetValue(delegate(IfcKnotType v)
			{
				_knotSpec = v;
			}, _knotSpec, value, "KnotSpec", 8);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger UpperIndexOnKnots => Knots.Count;

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

	internal IfcBSplineCurveWithKnots(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_knotMultiplicities = new ItemSet<IfcInteger>(this, 0, 6);
		_knots = new ItemSet<IfcParameterValue>(this, 0, 7);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_knotMultiplicities.InternalAdd(value.IntegerVal);
			break;
		case 6:
			_knots.InternalAdd(value.RealVal);
			break;
		case 7:
			_knotSpec = (IfcKnotType)Enum.Parse(typeof(IfcKnotType), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBSplineCurveWithKnots other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBSplineCurveWithKnotsClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcBSplineCurveWithKnotsClause.ConsistentBSpline:
				result = Functions.IfcConstraintsParamBSpline(base.Degree, UpperIndexOnKnots, base.UpperIndexOnControlPoints, KnotMultiplicities, Knots);
				break;
			case IfcBSplineCurveWithKnotsClause.CorrespondingKnotLists:
				result = Functions.SIZEOF(KnotMultiplicities) == UpperIndexOnKnots;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBSplineCurveWithKnots>()?.LogError($"Exception thrown evaluating where-clause 'IfcBSplineCurveWithKnots.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcBSplineCurveWithKnotsClause.ConsistentBSpline))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBSplineCurveWithKnots.ConsistentBSpline",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBSplineCurveWithKnotsClause.CorrespondingKnotLists))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBSplineCurveWithKnots.CorrespondingKnotLists",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
