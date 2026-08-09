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

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCurveBoundedSurface", 1146)]
public class IfcCurveBoundedSurface : IfcBoundedSurface, IInstantiableEntity, IPersistEntity, IPersist, IIfcCurveBoundedSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcCurveBoundedSurface>
{
	private IfcSurface _basisSurface;

	private readonly ItemSet<IfcBoundaryCurve> _boundaries;

	private IfcBoolean _implicitOuter;

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

	IItemSet<IIfcBoundaryCurve> IIfcCurveBoundedSurface.Boundaries => new ProxyItemSet<IfcBoundaryCurve, IIfcBoundaryCurve>(Boundaries);

	IfcBoolean IIfcCurveBoundedSurface.ImplicitOuter
	{
		get
		{
			return ImplicitOuter;
		}
		set
		{
			ImplicitOuter = value;
		}
	}

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
	public IfcBoolean ImplicitOuter
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
			SetValue(delegate(IfcBoolean v)
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
