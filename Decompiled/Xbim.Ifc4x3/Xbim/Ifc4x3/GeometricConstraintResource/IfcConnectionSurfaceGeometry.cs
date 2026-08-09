using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometricModelResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.TopologyResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcConnectionSurfaceGeometry", 69)]
public class IfcConnectionSurfaceGeometry : IfcConnectionGeometry, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConnectionSurfaceGeometry>, IIfcConnectionSurfaceGeometry, IIfcConnectionGeometry
{
	private IfcSurfaceOrFaceSurface _surfaceOnRelatingElement;

	private IfcSurfaceOrFaceSurface _surfaceOnRelatedElement;

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

	[CrossSchemaAttribute(typeof(IIfcConnectionSurfaceGeometry), 1)]
	IIfcSurfaceOrFaceSurface IIfcConnectionSurfaceGeometry.SurfaceOnRelatingElement
	{
		get
		{
			if (SurfaceOnRelatingElement == null)
			{
				return null;
			}
			IfcFaceBasedSurfaceModel ifcFaceBasedSurfaceModel = SurfaceOnRelatingElement as IfcFaceBasedSurfaceModel;
			if (ifcFaceBasedSurfaceModel != null)
			{
				return ifcFaceBasedSurfaceModel;
			}
			IfcFaceSurface ifcFaceSurface = SurfaceOnRelatingElement as IfcFaceSurface;
			if (ifcFaceSurface != null)
			{
				return ifcFaceSurface;
			}
			IfcSurface ifcSurface = SurfaceOnRelatingElement as IfcSurface;
			if (ifcSurface != null)
			{
				return ifcSurface;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				SurfaceOnRelatingElement = null;
				return;
			}
			IfcFaceBasedSurfaceModel ifcFaceBasedSurfaceModel = value as IfcFaceBasedSurfaceModel;
			if (ifcFaceBasedSurfaceModel != null)
			{
				SurfaceOnRelatingElement = ifcFaceBasedSurfaceModel;
				return;
			}
			IfcFaceSurface ifcFaceSurface = value as IfcFaceSurface;
			if (ifcFaceSurface != null)
			{
				SurfaceOnRelatingElement = ifcFaceSurface;
				return;
			}
			IfcSurface ifcSurface = value as IfcSurface;
			if (ifcSurface != null)
			{
				SurfaceOnRelatingElement = ifcSurface;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConnectionSurfaceGeometry), 2)]
	IIfcSurfaceOrFaceSurface IIfcConnectionSurfaceGeometry.SurfaceOnRelatedElement
	{
		get
		{
			if (SurfaceOnRelatedElement == null)
			{
				return null;
			}
			IfcFaceBasedSurfaceModel ifcFaceBasedSurfaceModel = SurfaceOnRelatedElement as IfcFaceBasedSurfaceModel;
			if (ifcFaceBasedSurfaceModel != null)
			{
				return ifcFaceBasedSurfaceModel;
			}
			IfcFaceSurface ifcFaceSurface = SurfaceOnRelatedElement as IfcFaceSurface;
			if (ifcFaceSurface != null)
			{
				return ifcFaceSurface;
			}
			IfcSurface ifcSurface = SurfaceOnRelatedElement as IfcSurface;
			if (ifcSurface != null)
			{
				return ifcSurface;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				SurfaceOnRelatedElement = null;
				return;
			}
			IfcFaceBasedSurfaceModel ifcFaceBasedSurfaceModel = value as IfcFaceBasedSurfaceModel;
			if (ifcFaceBasedSurfaceModel != null)
			{
				SurfaceOnRelatedElement = ifcFaceBasedSurfaceModel;
				return;
			}
			IfcFaceSurface ifcFaceSurface = value as IfcFaceSurface;
			if (ifcFaceSurface != null)
			{
				SurfaceOnRelatedElement = ifcFaceSurface;
				return;
			}
			IfcSurface ifcSurface = value as IfcSurface;
			if (ifcSurface != null)
			{
				SurfaceOnRelatedElement = ifcSurface;
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
