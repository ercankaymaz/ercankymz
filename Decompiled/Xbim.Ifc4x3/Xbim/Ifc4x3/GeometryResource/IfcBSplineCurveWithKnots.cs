using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcBSplineCurveWithKnots", 1101)]
public class IfcBSplineCurveWithKnots : IfcBSplineCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcBSplineCurveWithKnots>, IIfcBSplineCurveWithKnots, IIfcBSplineCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> _knotMultiplicities;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue> _knots;

	private IfcKnotType _knotSpec;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 8)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> KnotMultiplicities
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
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue> Knots
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
	public Xbim.Ifc4x3.MeasureResource.IfcInteger UpperIndexOnKnots => Knots.Count;

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

	[CrossSchemaAttribute(typeof(IIfcBSplineCurveWithKnots), 6)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcInteger> IIfcBSplineCurveWithKnots.KnotMultiplicities => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcInteger, Xbim.Ifc4.MeasureResource.IfcInteger>(KnotMultiplicities, (Xbim.Ifc4x3.MeasureResource.IfcInteger s) => new Xbim.Ifc4.MeasureResource.IfcInteger(s), (Xbim.Ifc4.MeasureResource.IfcInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcInteger(t));

	[CrossSchemaAttribute(typeof(IIfcBSplineCurveWithKnots), 7)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcParameterValue> IIfcBSplineCurveWithKnots.Knots => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue, Xbim.Ifc4.MeasureResource.IfcParameterValue>(Knots, (Xbim.Ifc4x3.MeasureResource.IfcParameterValue s) => new Xbim.Ifc4.MeasureResource.IfcParameterValue(s), (Xbim.Ifc4.MeasureResource.IfcParameterValue t) => new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(t));

	[CrossSchemaAttribute(typeof(IIfcBSplineCurveWithKnots), 8)]
	Xbim.Ifc4.Interfaces.IfcKnotType IIfcBSplineCurveWithKnots.KnotSpec
	{
		get
		{
			return KnotSpec switch
			{
				IfcKnotType.PIECEWISE_BEZIER_KNOTS => Xbim.Ifc4.Interfaces.IfcKnotType.PIECEWISE_BEZIER_KNOTS, 
				IfcKnotType.QUASI_UNIFORM_KNOTS => Xbim.Ifc4.Interfaces.IfcKnotType.QUASI_UNIFORM_KNOTS, 
				IfcKnotType.UNIFORM_KNOTS => Xbim.Ifc4.Interfaces.IfcKnotType.UNIFORM_KNOTS, 
				IfcKnotType.UNSPECIFIED => Xbim.Ifc4.Interfaces.IfcKnotType.UNSPECIFIED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcKnotType.UNIFORM_KNOTS:
				KnotSpec = IfcKnotType.UNIFORM_KNOTS;
				break;
			case Xbim.Ifc4.Interfaces.IfcKnotType.QUASI_UNIFORM_KNOTS:
				KnotSpec = IfcKnotType.QUASI_UNIFORM_KNOTS;
				break;
			case Xbim.Ifc4.Interfaces.IfcKnotType.PIECEWISE_BEZIER_KNOTS:
				KnotSpec = IfcKnotType.PIECEWISE_BEZIER_KNOTS;
				break;
			case Xbim.Ifc4.Interfaces.IfcKnotType.UNSPECIFIED:
				KnotSpec = IfcKnotType.UNSPECIFIED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcBSplineCurveWithKnots.UpperIndexOnKnots => new Xbim.Ifc4.MeasureResource.IfcInteger(UpperIndexOnKnots);

	internal IfcBSplineCurveWithKnots(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_knotMultiplicities = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger>(this, 0, 6);
		_knots = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>(this, 0, 7);
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
}
