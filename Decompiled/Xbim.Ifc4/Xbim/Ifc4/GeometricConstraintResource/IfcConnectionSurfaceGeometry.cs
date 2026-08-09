using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcConnectionSurfaceGeometry", 69)]
public class IfcConnectionSurfaceGeometry : IfcConnectionGeometry, IInstantiableEntity, IPersistEntity, IPersist, IIfcConnectionSurfaceGeometry, IIfcConnectionGeometry, IContainsEntityReferences, IEquatable<IfcConnectionSurfaceGeometry>
{
	private IfcSurfaceOrFaceSurface _surfaceOnRelatingElement;

	private IfcSurfaceOrFaceSurface _surfaceOnRelatedElement;

	IIfcSurfaceOrFaceSurface IIfcConnectionSurfaceGeometry.SurfaceOnRelatingElement
	{
		get
		{
			return SurfaceOnRelatingElement;
		}
		set
		{
			SurfaceOnRelatingElement = value as IfcSurfaceOrFaceSurface;
		}
	}

	IIfcSurfaceOrFaceSurface IIfcConnectionSurfaceGeometry.SurfaceOnRelatedElement
	{
		get
		{
			return SurfaceOnRelatedElement;
		}
		set
		{
			SurfaceOnRelatedElement = value as IfcSurfaceOrFaceSurface;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcSurfaceOrFaceSurface SurfaceOnRelatingElement
	{
		get
		{
			if (_activated)
			{
				return _surfaceOnRelatingElement;
			}
			Activate();
			return _surfaceOnRelatingElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurfaceOrFaceSurface v)
			{
				_surfaceOnRelatingElement = v;
			}, _surfaceOnRelatingElement, value, "SurfaceOnRelatingElement", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcSurfaceOrFaceSurface SurfaceOnRelatedElement
	{
		get
		{
			if (_activated)
			{
				return _surfaceOnRelatedElement;
			}
			Activate();
			return _surfaceOnRelatedElement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurfaceOrFaceSurface v)
			{
				_surfaceOnRelatedElement = v;
			}, _surfaceOnRelatedElement, value, "SurfaceOnRelatedElement", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (SurfaceOnRelatingElement != null)
			{
				yield return SurfaceOnRelatingElement;
			}
			if (SurfaceOnRelatedElement != null)
			{
				yield return SurfaceOnRelatedElement;
			}
		}
	}

	internal IfcConnectionSurfaceGeometry(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_surfaceOnRelatingElement = (IfcSurfaceOrFaceSurface)value.EntityVal;
			break;
		case 1:
			_surfaceOnRelatedElement = (IfcSurfaceOrFaceSurface)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConnectionSurfaceGeometry other)
	{
		return this == other;
	}
}
