using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.ProfileResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcSectionedSpine", 300)]
public class IfcSectionedSpine : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcSectionedSpine, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSectionedSpine>, IExpressValidatable
{
	public enum IfcSectionedSpineClause
	{
		CorrespondingSectionPositions,
		ConsistentProfileTypes,
		SpineCurveDim
	}

	private IfcCompositeCurve _spineCurve;

	private readonly ItemSet<IfcProfileDef> _crossSections;

	private readonly ItemSet<IfcAxis2Placement3D> _crossSectionPositions;

	IIfcCompositeCurve IIfcSectionedSpine.SpineCurve
	{
		get
		{
			return SpineCurve;
		}
		set
		{
			SpineCurve = value as IfcCompositeCurve;
		}
	}

	IItemSet<IIfcProfileDef> IIfcSectionedSpine.CrossSections => new ProxyItemSet<IfcProfileDef, IIfcProfileDef>(CrossSections);

	IItemSet<IIfcAxis2Placement3D> IIfcSectionedSpine.CrossSectionPositions => new ProxyItemSet<IfcAxis2Placement3D, IIfcAxis2Placement3D>(CrossSectionPositions);

	IfcDimensionCount IIfcSectionedSpine.Dim => Dim;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCompositeCurve SpineCurve
	{
		get
		{
			if (_activated)
			{
				return _spineCurve;
			}
			Activate();
			return _spineCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCompositeCurve v)
			{
				_spineCurve = v;
			}, _spineCurve, value, "SpineCurve", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 4)]
	public IItemSet<IfcProfileDef> CrossSections
	{
		get
		{
			if (_activated)
			{
				return _crossSections;
			}
			Activate();
			return _crossSections;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 5)]
	public IItemSet<IfcAxis2Placement3D> CrossSectionPositions
	{
		get
		{
			if (_activated)
			{
				return _crossSectionPositions;
			}
			Activate();
			return _crossSectionPositions;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => 3L;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (SpineCurve != null)
			{
				yield return SpineCurve;
			}
			foreach (IfcProfileDef crossSection in CrossSections)
			{
				yield return crossSection;
			}
			foreach (IfcAxis2Placement3D crossSectionPosition in CrossSectionPositions)
			{
				yield return crossSectionPosition;
			}
		}
	}

	internal IfcSectionedSpine(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_crossSections = new ItemSet<IfcProfileDef>(this, 0, 2);
		_crossSectionPositions = new ItemSet<IfcAxis2Placement3D>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_spineCurve = (IfcCompositeCurve)value.EntityVal;
			break;
		case 1:
			_crossSections.InternalAdd((IfcProfileDef)value.EntityVal);
			break;
		case 2:
			_crossSectionPositions.InternalAdd((IfcAxis2Placement3D)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSectionedSpine other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSectionedSpineClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcSectionedSpineClause.CorrespondingSectionPositions:
				result = Functions.SIZEOF(CrossSections) == Functions.SIZEOF(CrossSectionPositions);
				break;
			case IfcSectionedSpineClause.ConsistentProfileTypes:
				result = Functions.SIZEOF(Enumerable.Where(CrossSections, (IfcProfileDef temp) => CrossSections.ItemAt(0L).ProfileType != temp.ProfileType)) == 0;
				break;
			case IfcSectionedSpineClause.SpineCurveDim:
				result = SpineCurve.Dim == 3L;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSectionedSpine>()?.LogError($"Exception thrown evaluating where-clause 'IfcSectionedSpine.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcSectionedSpineClause.CorrespondingSectionPositions))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSectionedSpine.CorrespondingSectionPositions",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSectionedSpineClause.ConsistentProfileTypes))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSectionedSpine.ConsistentProfileTypes",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSectionedSpineClause.SpineCurveDim))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSectionedSpine.SpineCurveDim",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
