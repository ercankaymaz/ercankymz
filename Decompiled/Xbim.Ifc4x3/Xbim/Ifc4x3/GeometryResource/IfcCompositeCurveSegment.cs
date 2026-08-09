using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCompositeCurveSegment", 460)]
public class IfcCompositeCurveSegment : IfcSegment, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCompositeCurveSegment>, IIfcCompositeCurveSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _sameSense;

	private IfcCurve _parentCurve;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean SameSense
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean v)
			{
				_sameSense = v;
			}, _sameSense, value, "SameSense", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
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
			return base.Transition switch
			{
				IfcTransitionCode.CONTINUOUS => Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTINUOUS, 
				IfcTransitionCode.CONTSAMEGRADIENT => Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTSAMEGRADIENT, 
				IfcTransitionCode.CONTSAMEGRADIENTSAMECURVATURE => Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTSAMEGRADIENTSAMECURVATURE, 
				IfcTransitionCode.DISCONTINUOUS => Xbim.Ifc4.Interfaces.IfcTransitionCode.DISCONTINUOUS, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTransitionCode.DISCONTINUOUS:
				base.Transition = IfcTransitionCode.DISCONTINUOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTINUOUS:
				base.Transition = IfcTransitionCode.CONTINUOUS;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTSAMEGRADIENT:
				base.Transition = IfcTransitionCode.CONTSAMEGRADIENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransitionCode.CONTSAMEGRADIENTSAMECURVATURE:
				base.Transition = IfcTransitionCode.CONTSAMEGRADIENTSAMECURVATURE;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCompositeCurveSegment), 2)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcCompositeCurveSegment.SameSense
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(SameSense);
		}
		set
		{
			SameSense = new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value);
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

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcCompositeCurveSegment.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(base.Dim);

	internal IfcCompositeCurveSegment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
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
}
