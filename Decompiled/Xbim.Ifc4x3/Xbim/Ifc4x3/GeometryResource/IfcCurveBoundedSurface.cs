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

[ExpressType("IfcCurveBoundedSurface", 1146)]
public class IfcCurveBoundedSurface : IfcBoundedSurface, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCurveBoundedSurface>, IIfcCurveBoundedSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	private IfcSurface _basisSurface;

	private readonly ItemSet<IfcBoundaryCurve> _boundaries;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _implicitOuter;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcSurface BasisSurface
	{
		get
		{
			if (_activated)
			{
				return _basisSurface;
			}
			Activate();
			return _basisSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurface v)
			{
				_basisSurface = v;
			}, _basisSurface, value, "BasisSurface", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcBoundaryCurve> Boundaries
	{
		get
		{
			if (_activated)
			{
				return _boundaries;
			}
			Activate();
			return _boundaries;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean ImplicitOuter
	{
		get
		{
			if (_activated)
			{
				return _implicitOuter;
			}
			Activate();
			return _implicitOuter;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean v)
			{
				_implicitOuter = v;
			}, _implicitOuter, value, "ImplicitOuter", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (BasisSurface != null)
			{
				yield return BasisSurface;
			}
			foreach (IfcBoundaryCurve boundary in Boundaries)
			{
				yield return boundary;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveBoundedSurface), 1)]
	IIfcSurface IIfcCurveBoundedSurface.BasisSurface
	{
		get
		{
			return BasisSurface;
		}
		set
		{
			BasisSurface = value as IfcSurface;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveBoundedSurface), 2)]
	IItemSet<IIfcBoundaryCurve> IIfcCurveBoundedSurface.Boundaries => new ProxyItemSet<IfcBoundaryCurve, IIfcBoundaryCurve>(Boundaries);

	[CrossSchemaAttribute(typeof(IIfcCurveBoundedSurface), 3)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcCurveBoundedSurface.ImplicitOuter
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(ImplicitOuter);
		}
		set
		{
			ImplicitOuter = new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value);
		}
	}

	internal IfcCurveBoundedSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_boundaries = new ItemSet<IfcBoundaryCurve>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_basisSurface = (IfcSurface)value.EntityVal;
			break;
		case 1:
			_boundaries.InternalAdd((IfcBoundaryCurve)value.EntityVal);
			break;
		case 2:
			_implicitOuter = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurveBoundedSurface other)
	{
		return this == other;
	}
}
