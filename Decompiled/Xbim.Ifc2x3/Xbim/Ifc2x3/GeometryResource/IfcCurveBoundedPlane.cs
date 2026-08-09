using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcCurveBoundedPlane", 334)]
public class IfcCurveBoundedPlane : IfcBoundedSurface, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCurveBoundedPlane>, IIfcCurveBoundedPlane, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	private IfcPlane _basisSurface;

	private IfcCurve _outerBoundary;

	private readonly ItemSet<IfcCurve> _innerBoundaries;

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

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override IfcDimensionCount Dim => BasisSurface.Dim;

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

	[CrossSchemaAttribute(typeof(IIfcCurveBoundedPlane), 1)]
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

	[CrossSchemaAttribute(typeof(IIfcCurveBoundedPlane), 2)]
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

	[CrossSchemaAttribute(typeof(IIfcCurveBoundedPlane), 3)]
	IItemSet<IIfcCurve> IIfcCurveBoundedPlane.InnerBoundaries => new ProxyItemSet<IfcCurve, IIfcCurve>(InnerBoundaries);

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
