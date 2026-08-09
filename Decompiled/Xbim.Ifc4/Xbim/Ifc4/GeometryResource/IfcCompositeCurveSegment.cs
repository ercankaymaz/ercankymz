using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCompositeCurveSegment", 460)]
public class IfcCompositeCurveSegment : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcCompositeCurveSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCompositeCurveSegment>, IExpressValidatable
{
	public enum IfcCompositeCurveSegmentClause
	{
		ParentIsBoundedCurve
	}

	private IfcTransitionCode _transition;

	private IfcBoolean _sameSense;

	private IfcCurve _parentCurve;

	IfcTransitionCode IIfcCompositeCurveSegment.Transition
	{
		get
		{
			return Transition;
		}
		set
		{
			Transition = value;
		}
	}

	IfcBoolean IIfcCompositeCurveSegment.SameSense
	{
		get
		{
			return SameSense;
		}
		set
		{
			SameSense = value;
		}
	}

	IIfcCurve IIfcCompositeCurveSegment.ParentCurve
	{
		get
		{
			return ParentCurve;
		}
		set
		{
			ParentCurve = value as IfcCurve;
		}
	}

	IfcDimensionCount IIfcCompositeCurveSegment.Dim => Dim;

	IEnumerable<IIfcCompositeCurve> IIfcCompositeCurveSegment.UsingCurves => UsingCurves;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcTransitionCode Transition
	{
		get
		{
			if (_activated)
			{
				return _transition;
			}
			Activate();
			return _transition;
		}
		set
		{
			SetValue(delegate(IfcTransitionCode v)
			{
				_transition = v;
			}, _transition, value, "Transition", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcBoolean SameSense
	{
		get
		{
			if (_activated)
			{
				return _sameSense;
			}
			Activate();
			return _sameSense;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_sameSense = v;
			}, _sameSense, value, "SameSense", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcCurve ParentCurve
	{
		get
		{
			if (_activated)
			{
				return _parentCurve;
			}
			Activate();
			return _parentCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_parentCurve = v;
			}, _parentCurve, value, "ParentCurve", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim => ParentCurve.Dim;

	[InverseProperty("Segments")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IEnumerable<IfcCompositeCurve> UsingCurves => base.Model.Instances.Where((IfcCompositeCurve e) => e.Segments != null && e.Segments.Contains(this), "Segments", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ParentCurve != null)
			{
				yield return ParentCurve;
			}
		}
	}

	internal IfcCompositeCurveSegment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_transition = (IfcTransitionCode)Enum.Parse(typeof(IfcTransitionCode), value.EnumVal, ignoreCase: true);
			break;
		case 1:
			_sameSense = value.BooleanVal;
			break;
		case 2:
			_parentCurve = (IfcCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCompositeCurveSegment other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCompositeCurveSegmentClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCompositeCurveSegmentClause.ParentIsBoundedCurve)
			{
				result = Functions.TYPEOF(ParentCurve).Contains("IFC4.IFCBOUNDEDCURVE");
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCompositeCurveSegment>()?.LogError($"Exception thrown evaluating where-clause 'IfcCompositeCurveSegment.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCompositeCurveSegmentClause.ParentIsBoundedCurve))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeCurveSegment.ParentIsBoundedCurve",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
