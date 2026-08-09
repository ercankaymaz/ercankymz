using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCurveBoundedPlane", 334)]
public class IfcCurveBoundedPlane : IfcBoundedSurface, IInstantiableEntity, IPersistEntity, IPersist, IIfcCurveBoundedPlane, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcCurveBoundedPlane>
{
	private IfcPlane _basisSurface;

	private IfcCurve _outerBoundary;

	private readonly ItemSet<IfcCurve> _innerBoundaries;

	IIfcPlane IIfcCurveBoundedPlane.BasisSurface
	{
		get
		{
			return BasisSurface;
		}
		set
		{
			BasisSurface = value as IfcPlane;
		}
	}

	IIfcCurve IIfcCurveBoundedPlane.OuterBoundary
	{
		get
		{
			return OuterBoundary;
		}
		set
		{
			OuterBoundary = value as IfcCurve;
		}
	}

	IItemSet<IIfcCurve> IIfcCurveBoundedPlane.InnerBoundaries => new ProxyItemSet<IfcCurve, IIfcCurve>(InnerBoundaries);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcPlane BasisSurface
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
			SetValue(delegate(IfcPlane v)
			{
				_basisSurface = v;
			}, _basisSurface, value, "BasisSurface", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcCurve OuterBoundary
	{
		get
		{
			if (_activated)
			{
				return _outerBoundary;
			}
			Activate();
			return _outerBoundary;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_outerBoundary = v;
			}, _outerBoundary, value, "OuterBoundary", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IItemSet<IfcCurve> InnerBoundaries
	{
		get
		{
			if (_activated)
			{
				return _innerBoundaries;
			}
			Activate();
			return _innerBoundaries;
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
			if (OuterBoundary != null)
			{
				yield return OuterBoundary;
			}
			foreach (IfcCurve innerBoundary in InnerBoundaries)
			{
				yield return innerBoundary;
			}
		}
	}

	internal IfcCurveBoundedPlane(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_innerBoundaries = new ItemSet<IfcCurve>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_basisSurface = (IfcPlane)value.EntityVal;
			break;
		case 1:
			_outerBoundary = (IfcCurve)value.EntityVal;
			break;
		case 2:
			_innerBoundaries.InternalAdd((IfcCurve)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurveBoundedPlane other)
	{
		return this == other;
	}
}
