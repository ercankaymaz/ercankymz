using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyleLighting", 117)]
public class IfcSurfaceStyleLighting : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceStyleLighting, IIfcPresentationItem, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSurfaceStyleLighting>
{
	private IfcColourRgb _diffuseTransmissionColour;

	private IfcColourRgb _diffuseReflectionColour;

	private IfcColourRgb _transmissionColour;

	private IfcColourRgb _reflectanceColour;

	IIfcColourRgb IIfcSurfaceStyleLighting.DiffuseTransmissionColour
	{
		get
		{
			return DiffuseTransmissionColour;
		}
		set
		{
			DiffuseTransmissionColour = value as IfcColourRgb;
		}
	}

	IIfcColourRgb IIfcSurfaceStyleLighting.DiffuseReflectionColour
	{
		get
		{
			return DiffuseReflectionColour;
		}
		set
		{
			DiffuseReflectionColour = value as IfcColourRgb;
		}
	}

	IIfcColourRgb IIfcSurfaceStyleLighting.TransmissionColour
	{
		get
		{
			return TransmissionColour;
		}
		set
		{
			TransmissionColour = value as IfcColourRgb;
		}
	}

	IIfcColourRgb IIfcSurfaceStyleLighting.ReflectanceColour
	{
		get
		{
			return ReflectanceColour;
		}
		set
		{
			ReflectanceColour = value as IfcColourRgb;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcColourRgb DiffuseTransmissionColour
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
			SetValue(delegate(IfcColourRgb v)
			{
				_diffuseTransmissionColour = v;
			}, _diffuseTransmissionColour, value, "DiffuseTransmissionColour", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcColourRgb DiffuseReflectionColour
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
			SetValue(delegate(IfcColourRgb v)
			{
				_diffuseReflectionColour = v;
			}, _diffuseReflectionColour, value, "DiffuseReflectionColour", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcColourRgb TransmissionColour
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
			SetValue(delegate(IfcColourRgb v)
			{
				_transmissionColour = v;
			}, _transmissionColour, value, "TransmissionColour", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcColourRgb ReflectanceColour
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
			SetValue(delegate(IfcColourRgb v)
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
			_diffuseTransmissionColour = (IfcColourRgb)value.EntityVal;
			break;
		case 1:
			_diffuseReflectionColour = (IfcColourRgb)value.EntityVal;
			break;
		case 2:
			_transmissionColour = (IfcColourRgb)value.EntityVal;
			break;
		case 3:
			_reflectanceColour = (IfcColourRgb)value.EntityVal;
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
