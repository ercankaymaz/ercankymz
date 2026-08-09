using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcSectionedSpine", 300)]
public class IfcSectionedSpine : Xbim.Ifc2x3.GeometryResource.IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSectionedSpine>, IIfcSectionedSpine, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IExpressValidatable
{
	public enum IfcSectionedSpineClause
	{
		WR1,
		WR2,
		WR3
	}

	private Xbim.Ifc2x3.GeometryResource.IfcCompositeCurve _spineCurve;

	private readonly ItemSet<IfcProfileDef> _crossSections;

	private readonly ItemSet<Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D> _crossSectionPositions;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.GeometryResource.IfcCompositeCurve SpineCurve
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
			SetValue(delegate(Xbim.Ifc2x3.GeometryResource.IfcCompositeCurve v)
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
	public IItemSet<Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D> CrossSectionPositions
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
	public Xbim.Ifc2x3.GeometryResource.IfcDimensionCount Dim => 3L;

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
			foreach (Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D crossSectionPosition in CrossSectionPositions)
			{
				yield return crossSectionPosition;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionedSpine), 1)]
	IIfcCompositeCurve IIfcSectionedSpine.SpineCurve
	{
		get
		{
			return SpineCurve;
		}
		set
		{
			SpineCurve = value as Xbim.Ifc2x3.GeometryResource.IfcCompositeCurve;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSectionedSpine), 2)]
	IItemSet<IIfcProfileDef> IIfcSectionedSpine.CrossSections => new ProxyItemSet<IfcProfileDef, IIfcProfileDef>(CrossSections);

	[CrossSchemaAttribute(typeof(IIfcSectionedSpine), 3)]
	IItemSet<IIfcAxis2Placement3D> IIfcSectionedSpine.CrossSectionPositions => new ProxyItemSet<Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D, IIfcAxis2Placement3D>(CrossSectionPositions);

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcSectionedSpine.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcSectionedSpine(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_crossSections = new ItemSet<IfcProfileDef>(this, 0, 2);
		_crossSectionPositions = new ItemSet<Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_spineCurve = (Xbim.Ifc2x3.GeometryResource.IfcCompositeCurve)value.EntityVal;
			break;
		case 1:
			_crossSections.InternalAdd((IfcProfileDef)value.EntityVal);
			break;
		case 2:
			_crossSectionPositions.InternalAdd((Xbim.Ifc2x3.GeometryResource.IfcAxis2Placement3D)value.EntityVal);
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
			case IfcSectionedSpineClause.WR1:
				result = Functions.SIZEOF(CrossSections) == Functions.SIZEOF(CrossSectionPositions);
				break;
			case IfcSectionedSpineClause.WR2:
				result = Functions.SIZEOF(Enumerable.Where(CrossSections, (IfcProfileDef temp) => CrossSections.ItemAt(0L).ProfileType != temp.ProfileType)) == 0;
				break;
			case IfcSectionedSpineClause.WR3:
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
		if (!ValidateClause(IfcSectionedSpineClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSectionedSpine.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSectionedSpineClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSectionedSpine.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcSectionedSpineClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSectionedSpine.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
