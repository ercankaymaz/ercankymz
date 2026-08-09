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

[ExpressType("IfcBSplineSurfaceWithKnots", 1103)]
public class IfcBSplineSurfaceWithKnots : IfcBSplineSurface, IInstantiableEntity, IPersistEntity, IPersist, IIfcBSplineSurfaceWithKnots, IIfcBSplineSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcBSplineSurfaceWithKnots>, IExpressValidatable
{
	public enum IfcBSplineSurfaceWithKnotsClause
	{
		UDirectionConstraints,
		VDirectionConstraints,
		CorrespondingULists,
		CorrespondingVLists
	}

	private readonly ItemSet<IfcInteger> _uMultiplicities;

	private readonly ItemSet<IfcInteger> _vMultiplicities;

	private readonly ItemSet<IfcParameterValue> _uKnots;

	private readonly ItemSet<IfcParameterValue> _vKnots;

	private IfcKnotType _knotSpec;

	IItemSet<IfcInteger> IIfcBSplineSurfaceWithKnots.UMultiplicities => UMultiplicities;

	IItemSet<IfcInteger> IIfcBSplineSurfaceWithKnots.VMultiplicities => VMultiplicities;

	IItemSet<IfcParameterValue> IIfcBSplineSurfaceWithKnots.UKnots => UKnots;

	IItemSet<IfcParameterValue> IIfcBSplineSurfaceWithKnots.VKnots => VKnots;

	IfcKnotType IIfcBSplineSurfaceWithKnots.KnotSpec
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

	IfcInteger IIfcBSplineSurfaceWithKnots.KnotVUpper => KnotVUpper;

	IfcInteger IIfcBSplineSurfaceWithKnots.KnotUUpper => KnotUUpper;

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 10)]
	public IItemSet<IfcInteger> UMultiplicities
	{
		get
		{
			if (_activated)
			{
				return _uMultiplicities;
			}
			Activate();
			return _uMultiplicities;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 11)]
	public IItemSet<IfcInteger> VMultiplicities
	{
		get
		{
			if (_activated)
			{
				return _vMultiplicities;
			}
			Activate();
			return _vMultiplicities;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 12)]
	public IItemSet<IfcParameterValue> UKnots
	{
		get
		{
			if (_activated)
			{
				return _uKnots;
			}
			Activate();
			return _uKnots;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 13)]
	public IItemSet<IfcParameterValue> VKnots
	{
		get
		{
			if (_activated)
			{
				return _vKnots;
			}
			Activate();
			return _vKnots;
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 14)]
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
			}, _knotSpec, value, "KnotSpec", 12);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger KnotVUpper => VKnots.Count;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger KnotUUpper => UKnots.Count;

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

	internal IfcBSplineSurfaceWithKnots(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_uMultiplicities = new ItemSet<IfcInteger>(this, 0, 8);
		_vMultiplicities = new ItemSet<IfcInteger>(this, 0, 9);
		_uKnots = new ItemSet<IfcParameterValue>(this, 0, 10);
		_vKnots = new ItemSet<IfcParameterValue>(this, 0, 11);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_uMultiplicities.InternalAdd(value.IntegerVal);
			break;
		case 8:
			_vMultiplicities.InternalAdd(value.IntegerVal);
			break;
		case 9:
			_uKnots.InternalAdd(value.RealVal);
			break;
		case 10:
			_vKnots.InternalAdd(value.RealVal);
			break;
		case 11:
			_knotSpec = (IfcKnotType)Enum.Parse(typeof(IfcKnotType), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBSplineSurfaceWithKnots other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBSplineSurfaceWithKnotsClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcBSplineSurfaceWithKnotsClause.UDirectionConstraints:
				result = Functions.IfcConstraintsParamBSpline(base.UDegree, KnotUUpper, base.UUpper, UMultiplicities, UKnots);
				break;
			case IfcBSplineSurfaceWithKnotsClause.VDirectionConstraints:
				result = Functions.IfcConstraintsParamBSpline(base.VDegree, KnotVUpper, base.VUpper, VMultiplicities, VKnots);
				break;
			case IfcBSplineSurfaceWithKnotsClause.CorrespondingULists:
				result = Functions.SIZEOF(UMultiplicities) == KnotUUpper;
				break;
			case IfcBSplineSurfaceWithKnotsClause.CorrespondingVLists:
				result = Functions.SIZEOF(VMultiplicities) == KnotVUpper;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBSplineSurfaceWithKnots>()?.LogError($"Exception thrown evaluating where-clause 'IfcBSplineSurfaceWithKnots.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcBSplineSurfaceWithKnotsClause.UDirectionConstraints))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBSplineSurfaceWithKnots.UDirectionConstraints",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBSplineSurfaceWithKnotsClause.VDirectionConstraints))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBSplineSurfaceWithKnots.VDirectionConstraints",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBSplineSurfaceWithKnotsClause.CorrespondingULists))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBSplineSurfaceWithKnots.CorrespondingULists",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBSplineSurfaceWithKnotsClause.CorrespondingVLists))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBSplineSurfaceWithKnots.CorrespondingVLists",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
