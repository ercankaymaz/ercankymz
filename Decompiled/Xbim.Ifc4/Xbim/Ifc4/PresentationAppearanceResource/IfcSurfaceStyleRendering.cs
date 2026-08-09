using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyleRendering", 317)]
public class IfcSurfaceStyleRendering : IfcSurfaceStyleShading, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceStyleRendering, IIfcSurfaceStyleShading, IIfcPresentationItem, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSurfaceStyleRendering>
{
	private IfcColourOrFactor _diffuseColour;

	private IfcColourOrFactor _transmissionColour;

	private IfcColourOrFactor _diffuseTransmissionColour;

	private IfcColourOrFactor _reflectionColour;

	private IfcColourOrFactor _specularColour;

	private IfcSpecularHighlightSelect _specularHighlight;

	private IfcReflectanceMethodEnum _reflectanceMethod;

	IIfcColourOrFactor IIfcSurfaceStyleRendering.DiffuseColour
	{
		get
		{
			return DiffuseColour;
		}
		set
		{
			DiffuseColour = value as IfcColourOrFactor;
		}
	}

	IIfcColourOrFactor IIfcSurfaceStyleRendering.TransmissionColour
	{
		get
		{
			return TransmissionColour;
		}
		set
		{
			TransmissionColour = value as IfcColourOrFactor;
		}
	}

	IIfcColourOrFactor IIfcSurfaceStyleRendering.DiffuseTransmissionColour
	{
		get
		{
			return DiffuseTransmissionColour;
		}
		set
		{
			DiffuseTransmissionColour = value as IfcColourOrFactor;
		}
	}

	IIfcColourOrFactor IIfcSurfaceStyleRendering.ReflectionColour
	{
		get
		{
			return ReflectionColour;
		}
		set
		{
			ReflectionColour = value as IfcColourOrFactor;
		}
	}

	IIfcColourOrFactor IIfcSurfaceStyleRendering.SpecularColour
	{
		get
		{
			return SpecularColour;
		}
		set
		{
			SpecularColour = value as IfcColourOrFactor;
		}
	}

	IIfcSpecularHighlightSelect IIfcSurfaceStyleRendering.SpecularHighlight
	{
		get
		{
			return SpecularHighlight;
		}
		set
		{
			SpecularHighlight = value as IfcSpecularHighlightSelect;
		}
	}

	IfcReflectanceMethodEnum IIfcSurfaceStyleRendering.ReflectanceMethod
	{
		get
		{
			return ReflectanceMethod;
		}
		set
		{
			ReflectanceMethod = value;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcColourOrFactor DiffuseColour
	{
		get
		{
			if (_activated)
			{
				return _diffuseColour;
			}
			Activate();
			return _diffuseColour;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_diffuseColour = v;
			}, _diffuseColour, value, "DiffuseColour", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcColourOrFactor TransmissionColour
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
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_transmissionColour = v;
			}, _transmissionColour, value, "TransmissionColour", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcColourOrFactor DiffuseTransmissionColour
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
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_diffuseTransmissionColour = v;
			}, _diffuseTransmissionColour, value, "DiffuseTransmissionColour", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcColourOrFactor ReflectionColour
	{
		get
		{
			if (_activated)
			{
				return _reflectionColour;
			}
			Activate();
			return _reflectionColour;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_reflectionColour = v;
			}, _reflectionColour, value, "ReflectionColour", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcColourOrFactor SpecularColour
	{
		get
		{
			if (_activated)
			{
				return _specularColour;
			}
			Activate();
			return _specularColour;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_specularColour = v;
			}, _specularColour, value, "SpecularColour", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcSpecularHighlightSelect SpecularHighlight
	{
		get
		{
			if (_activated)
			{
				return _specularHighlight;
			}
			Activate();
			return _specularHighlight;
		}
		set
		{
			SetValue(delegate(IfcSpecularHighlightSelect v)
			{
				_specularHighlight = v;
			}, _specularHighlight, value, "SpecularHighlight", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcReflectanceMethodEnum ReflectanceMethod
	{
		get
		{
			if (_activated)
			{
				return _reflectanceMethod;
			}
			Activate();
			return _reflectanceMethod;
		}
		set
		{
			SetValue(delegate(IfcReflectanceMethodEnum v)
			{
				_reflectanceMethod = v;
			}, _reflectanceMethod, value, "ReflectanceMethod", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SurfaceColour != null)
			{
				yield return base.SurfaceColour;
			}
		}
	}

	internal IfcSurfaceStyleRendering(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_diffuseColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 3:
			_transmissionColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 4:
			_diffuseTransmissionColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 5:
			_reflectionColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 6:
			_specularColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 7:
			_specularHighlight = (IfcSpecularHighlightSelect)value.EntityVal;
			break;
		case 8:
			_reflectanceMethod = (IfcReflectanceMethodEnum)Enum.Parse(typeof(IfcReflectanceMethodEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceStyleRendering other)
	{
		return this == other;
	}
}
