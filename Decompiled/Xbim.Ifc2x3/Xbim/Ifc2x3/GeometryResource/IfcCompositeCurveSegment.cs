using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcCompositeCurveSegment", 460)]
public class IfcCompositeCurveSegment : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCompositeCurveSegment>, IIfcCompositeCurveSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IExpressValidatable
{
	public enum IfcCompositeCurveSegmentClause
	{
		WR1
	}

	private IfcTransitionCode _transition;

	private bool _sameSense;

	private IfcCurve _parentCurve;

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
	public bool SameSense
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
			SetValue(delegate(bool v)
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

	[CrossSchemaAttribute(typeof(IIfcCompositeCurveSegment), 1)]
	Xbim.Ifc4.Interfaces.IfcTransitionCode IIfcCompositeCurveSegment.Transition
	{
		get
		{
			return Transition switch
			{
				IfcTransitionCode.DISCONTINUOUS => Xbim.Ifc4.Interfaces.IfcTransitionCode.DISCONTINUOUS, 
				IfcTransitionCode.CONTINUOUS => Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTINUOUS, 
				IfcTransitionCode.CONTSAMEGRADIENT => Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTSAMEGRADIENT, 
				IfcTransitionCode.CONTSAMEGRADIENTSAMECURVATURE => Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTSAMEGRADIENTSAMECURVATURE, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTransitionCode.DISCONTINUOUS:
				Transition = IfcTransitionCode.DISCONTINUOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTINUOUS:
				Transition = IfcTransitionCode.CONTINUOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTSAMEGRADIENT:
				Transition = IfcTransitionCode.CONTSAMEGRADIENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTSAMEGRADIENTSAMECURVATURE:
				Transition = IfcTransitionCode.CONTSAMEGRADIENTSAMECURVATURE;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCompositeCurveSegment), 2)]
	IfcBoolean IIfcCompositeCurveSegment.SameSense
	{
		get
		{
			return new IfcBoolean(SameSense);
		}
		set
		{
			SameSense = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCompositeCurveSegment), 3)]
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

	IEnumerable<IIfcCompositeCurve> IIfcCompositeCurveSegment.UsingCurves => base.Model.Instances.Where((IIfcCompositeCurve e) => e.Segments != null && e.Segments.Contains(this), "Segments", this);

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcCompositeCurveSegment.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

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
			if (clause == IfcCompositeCurveSegmentClause.WR1)
			{
				result = Functions.TYPEOF(ParentCurve).Contains("IFC2X3.IFCBOUNDEDCURVE");
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
		if (!ValidateClause(IfcCompositeCurveSegmentClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeCurveSegment.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
