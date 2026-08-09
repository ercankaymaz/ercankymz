using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PresentationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyleLighting", 117)]
public class IfcSurfaceStyleLighting : PersistEntity, IIfcSurfaceStyleLighting, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IInstantiableEntity, IfcSurfaceStyleElementSelect, IContainsEntityReferences, IEquatable<IfcSurfaceStyleLighting>
{
	private Xbim.Ifc2x3.PresentationResource.IfcColourRgb _diffuseTransmissionColour;

	private Xbim.Ifc2x3.PresentationResource.IfcColourRgb _diffuseReflectionColour;

	private Xbim.Ifc2x3.PresentationResource.IfcColourRgb _transmissionColour;

	private Xbim.Ifc2x3.PresentationResource.IfcColourRgb _reflectanceColour;

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleLighting), 1)]
	IIfcColourRgb IIfcSurfaceStyleLighting.DiffuseTransmissionColour
	{
		get
		{
			return DiffuseTransmissionColour;
		}
		set
		{
			DiffuseTransmissionColour = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleLighting), 2)]
	IIfcColourRgb IIfcSurfaceStyleLighting.DiffuseReflectionColour
	{
		get
		{
			return DiffuseReflectionColour;
		}
		set
		{
			DiffuseReflectionColour = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleLighting), 3)]
	IIfcColourRgb IIfcSurfaceStyleLighting.TransmissionColour
	{
		get
		{
			return TransmissionColour;
		}
		set
		{
			TransmissionColour = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleLighting), 4)]
	IIfcColourRgb IIfcSurfaceStyleLighting.ReflectanceColour
	{
		get
		{
			return ReflectanceColour;
		}
		set
		{
			ReflectanceColour = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.PresentationResource.IfcColourRgb DiffuseTransmissionColour
	{
		get
		{
			if (_activated)
			{
				return _diffuseTransmissionColour;
			}
			Activate();
			return _diffuseTransmissionColour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcColourRgb v)
			{
				_diffuseTransmissionColour = v;
			}, _diffuseTransmissionColour, value, "DiffuseTransmissionColour", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.PresentationResource.IfcColourRgb DiffuseReflectionColour
	{
		get
		{
			if (_activated)
			{
				return _diffuseReflectionColour;
			}
			Activate();
			return _diffuseReflectionColour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcColourRgb v)
			{
				_diffuseReflectionColour = v;
			}, _diffuseReflectionColour, value, "DiffuseReflectionColour", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.PresentationResource.IfcColourRgb TransmissionColour
	{
		get
		{
			if (_activated)
			{
				return _transmissionColour;
			}
			Activate();
			return _transmissionColour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcColourRgb v)
			{
				_transmissionColour = v;
			}, _transmissionColour, value, "TransmissionColour", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.PresentationResource.IfcColourRgb ReflectanceColour
	{
		get
		{
			if (_activated)
			{
				return _reflectanceColour;
			}
			Activate();
			return _reflectanceColour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcColourRgb v)
			{
				_reflectanceColour = v;
			}, _reflectanceColour, value, "ReflectanceColour", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (DiffuseTransmissionColour != null)
			{
				yield return DiffuseTransmissionColour;
			}
			if (DiffuseReflectionColour != null)
			{
				yield return DiffuseReflectionColour;
			}
			if (TransmissionColour != null)
			{
				yield return TransmissionColour;
			}
			if (ReflectanceColour != null)
			{
				yield return ReflectanceColour;
			}
		}
	}

	internal IfcSurfaceStyleLighting(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_diffuseTransmissionColour = (Xbim.Ifc2x3.PresentationResource.IfcColourRgb)value.EntityVal;
			break;
		case 1:
			_diffuseReflectionColour = (Xbim.Ifc2x3.PresentationResource.IfcColourRgb)value.EntityVal;
			break;
		case 2:
			_transmissionColour = (Xbim.Ifc2x3.PresentationResource.IfcColourRgb)value.EntityVal;
			break;
		case 3:
			_reflectanceColour = (Xbim.Ifc2x3.PresentationResource.IfcColourRgb)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceStyleLighting other)
	{
		return this == other;
	}
}
