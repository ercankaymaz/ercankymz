using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcBSplineCurve", 167)]
public abstract class IfcBSplineCurve : IfcBoundedCurve, IEquatable<IfcBSplineCurve>, IIfcBSplineCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IExpressValidatable
{
	public enum IfcBSplineCurveClause
	{
		WR41
	}

	private long _degree;

	private readonly ItemSet<IfcCartesianPoint> _controlPointsList;

	private IfcBSplineCurveForm _curveForm;

	private bool? _closedCurve;

	private bool? _selfIntersect;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public long Degree
	{
		get
		{
			if (_activated)
			{
				return _degree;
			}
			Activate();
			return _degree;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_degree = v;
			}, _degree, value, "Degree", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { -1 }, 4)]
	public IItemSet<IfcCartesianPoint> ControlPointsList
	{
		get
		{
			if (_activated)
			{
				return _controlPointsList;
			}
			Activate();
			return _controlPointsList;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 5)]
	public IfcBSplineCurveForm CurveForm
	{
		get
		{
			if (_activated)
			{
				return _curveForm;
			}
			Activate();
			return _curveForm;
		}
		set
		{
			SetValue(delegate(IfcBSplineCurveForm v)
			{
				_curveForm = v;
			}, _curveForm, value, "CurveForm", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public bool? ClosedCurve
	{
		get
		{
			if (_activated)
			{
				return _closedCurve;
			}
			Activate();
			return _closedCurve;
		}
		set
		{
			SetValue(delegate(bool? v)
			{
				_closedCurve = v;
			}, _closedCurve, value, "ClosedCurve", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public bool? SelfIntersect
	{
		get
		{
			if (_activated)
			{
				return _selfIntersect;
			}
			Activate();
			return _selfIntersect;
		}
		set
		{
			SetValue(delegate(bool? v)
			{
				_selfIntersect = v;
			}, _selfIntersect, value, "SelfIntersect", 5);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Array, EntityAttributeType.Class, new int[] { 0 }, new int[] { 255 }, 0)]
	public List<XbimPoint3D> ControlPoints => ControlPointsList.Select((IfcCartesianPoint p) => new XbimPoint3D(p.X, p.Y, p.Z)).ToList();

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public long UpperIndexOnControlPoints => ControlPointsList.Count - 1;

	[CrossSchemaAttribute(typeof(IIfcBSplineCurve), 1)]
	IfcInteger IIfcBSplineCurve.Degree
	{
		get
		{
			return new IfcInteger(Degree);
		}
		set
		{
			Degree = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineCurve), 2)]
	IItemSet<IIfcCartesianPoint> IIfcBSplineCurve.ControlPointsList => new ProxyItemSet<IfcCartesianPoint, IIfcCartesianPoint>(ControlPointsList);

	[CrossSchemaAttribute(typeof(IIfcBSplineCurve), 3)]
	Xbim.Ifc4.Interfaces.IfcBSplineCurveForm IIfcBSplineCurve.CurveForm
	{
		get
		{
			return CurveForm switch
			{
				IfcBSplineCurveForm.POLYLINE_FORM => Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.POLYLINE_FORM, 
				IfcBSplineCurveForm.CIRCULAR_ARC => Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.CIRCULAR_ARC, 
				IfcBSplineCurveForm.ELLIPTIC_ARC => Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.ELLIPTIC_ARC, 
				IfcBSplineCurveForm.PARABOLIC_ARC => Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.PARABOLIC_ARC, 
				IfcBSplineCurveForm.HYPERBOLIC_ARC => Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.HYPERBOLIC_ARC, 
				IfcBSplineCurveForm.UNSPECIFIED => Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.UNSPECIFIED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.POLYLINE_FORM:
				CurveForm = IfcBSplineCurveForm.POLYLINE_FORM;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.CIRCULAR_ARC:
				CurveForm = IfcBSplineCurveForm.CIRCULAR_ARC;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.ELLIPTIC_ARC:
				CurveForm = IfcBSplineCurveForm.ELLIPTIC_ARC;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.PARABOLIC_ARC:
				CurveForm = IfcBSplineCurveForm.PARABOLIC_ARC;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.HYPERBOLIC_ARC:
				CurveForm = IfcBSplineCurveForm.HYPERBOLIC_ARC;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineCurveForm.UNSPECIFIED:
				CurveForm = IfcBSplineCurveForm.UNSPECIFIED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineCurve), 4)]
	IfcLogical IIfcBSplineCurve.ClosedCurve
	{
		get
		{
			return new IfcLogical(ClosedCurve);
		}
		set
		{
			ClosedCurve = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineCurve), 5)]
	IfcLogical IIfcBSplineCurve.SelfIntersect
	{
		get
		{
			return new IfcLogical(SelfIntersect);
		}
		set
		{
			SelfIntersect = value;
		}
	}

	IfcInteger IIfcBSplineCurve.UpperIndexOnControlPoints => new IfcInteger(UpperIndexOnControlPoints);

	List<XbimPoint3D> IIfcBSplineCurve.ControlPoints => ControlPoints;

	internal IfcBSplineCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_controlPointsList = new ItemSet<IfcCartesianPoint>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_degree = value.IntegerVal;
			break;
		case 1:
			_controlPointsList.InternalAdd((IfcCartesianPoint)value.EntityVal);
			break;
		case 2:
			_curveForm = (IfcBSplineCurveForm)Enum.Parse(typeof(IfcBSplineCurveForm), value.EnumVal, ignoreCase: true);
			break;
		case 3:
			_closedCurve = value.BooleanVal;
			break;
		case 4:
			_selfIntersect = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBSplineCurve other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBSplineCurveClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcBSplineCurveClause.WR41)
			{
				result = Functions.SIZEOF(Enumerable.Where(ControlPointsList, (IfcCartesianPoint Temp) => Temp.Dim != ControlPointsList.ItemAt(0L).Dim)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBSplineCurve>()?.LogError($"Exception thrown evaluating where-clause 'IfcBSplineCurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcBSplineCurveClause.WR41))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBSplineCurve.WR41",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
