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

[ExpressType("IfcBSplineSurfaceWithKnots", 1103)]
public class IfcBSplineSurfaceWithKnots : IfcBSplineSurface, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcBSplineSurfaceWithKnots>, IIfcBSplineSurfaceWithKnots, IIfcBSplineSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> _uMultiplicities;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> _vMultiplicities;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue> _uKnots;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue> _vKnots;

	private IfcKnotType _knotSpec;

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 10)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> UMultiplicities
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
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> VMultiplicities
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
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue> UKnots
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
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue> VKnots
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
	public Xbim.Ifc4x3.MeasureResource.IfcInteger KnotVUpper => VKnots.Count;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger KnotUUpper => UKnots.Count;

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

	[CrossSchemaAttribute(typeof(IIfcBSplineSurfaceWithKnots), 8)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcInteger> IIfcBSplineSurfaceWithKnots.UMultiplicities => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcInteger, Xbim.Ifc4.MeasureResource.IfcInteger>(UMultiplicities, (Xbim.Ifc4x3.MeasureResource.IfcInteger s) => new Xbim.Ifc4.MeasureResource.IfcInteger(s), (Xbim.Ifc4.MeasureResource.IfcInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcInteger(t));

	[CrossSchemaAttribute(typeof(IIfcBSplineSurfaceWithKnots), 9)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcInteger> IIfcBSplineSurfaceWithKnots.VMultiplicities => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcInteger, Xbim.Ifc4.MeasureResource.IfcInteger>(VMultiplicities, (Xbim.Ifc4x3.MeasureResource.IfcInteger s) => new Xbim.Ifc4.MeasureResource.IfcInteger(s), (Xbim.Ifc4.MeasureResource.IfcInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcInteger(t));

	[CrossSchemaAttribute(typeof(IIfcBSplineSurfaceWithKnots), 10)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcParameterValue> IIfcBSplineSurfaceWithKnots.UKnots => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue, Xbim.Ifc4.MeasureResource.IfcParameterValue>(UKnots, (Xbim.Ifc4x3.MeasureResource.IfcParameterValue s) => new Xbim.Ifc4.MeasureResource.IfcParameterValue(s), (Xbim.Ifc4.MeasureResource.IfcParameterValue t) => new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(t));

	[CrossSchemaAttribute(typeof(IIfcBSplineSurfaceWithKnots), 11)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcParameterValue> IIfcBSplineSurfaceWithKnots.VKnots => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue, Xbim.Ifc4.MeasureResource.IfcParameterValue>(VKnots, (Xbim.Ifc4x3.MeasureResource.IfcParameterValue s) => new Xbim.Ifc4.MeasureResource.IfcParameterValue(s), (Xbim.Ifc4.MeasureResource.IfcParameterValue t) => new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(t));

	[CrossSchemaAttribute(typeof(IIfcBSplineSurfaceWithKnots), 12)]
	Xbim.Ifc4.Interfaces.IfcKnotType IIfcBSplineSurfaceWithKnots.KnotSpec
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

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcBSplineSurfaceWithKnots.KnotVUpper => new Xbim.Ifc4.MeasureResource.IfcInteger(KnotVUpper);

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcBSplineSurfaceWithKnots.KnotUUpper => new Xbim.Ifc4.MeasureResource.IfcInteger(KnotUUpper);

	internal IfcBSplineSurfaceWithKnots(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_uMultiplicities = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger>(this, 0, 8);
		_vMultiplicities = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger>(this, 0, 9);
		_uKnots = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>(this, 0, 10);
		_vKnots = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>(this, 0, 11);
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
}
