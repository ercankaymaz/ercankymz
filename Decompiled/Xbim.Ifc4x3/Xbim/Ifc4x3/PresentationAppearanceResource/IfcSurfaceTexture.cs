using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcSurfaceTexture", 722)]
public abstract class IfcSurfaceTexture : IfcPresentationItem, IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist, IEquatable<IfcSurfaceTexture>
{
	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _repeatS;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _repeatT;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _mode;

	private IfcCartesianTransformationOperator2D _textureTransform;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcIdentifier> _parameter;

	[CrossSchemaAttribute(typeof(IIfcSurfaceTexture), 1)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcSurfaceTexture.RepeatS
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(RepeatS);
		}
		set
		{
			RepeatS = new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceTexture), 2)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcSurfaceTexture.RepeatT
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(RepeatT);
		}
		set
		{
			RepeatT = new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceTexture), 3)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcSurfaceTexture.Mode
	{
		get
		{
			if (!Mode.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Mode.Value);
		}
		set
		{
			Mode = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceTexture), 4)]
	IIfcCartesianTransformationOperator2D IIfcSurfaceTexture.TextureTransform
	{
		get
		{
			return TextureTransform;
		}
		set
		{
			TextureTransform = value as IfcCartesianTransformationOperator2D;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceTexture), 5)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcIdentifier> IIfcSurfaceTexture.Parameter => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcIdentifier, Xbim.Ifc4.MeasureResource.IfcIdentifier>(Parameter, (Xbim.Ifc4x3.MeasureResource.IfcIdentifier s) => new Xbim.Ifc4.MeasureResource.IfcIdentifier(s), (Xbim.Ifc4.MeasureResource.IfcIdentifier t) => new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(t));

	IEnumerable<IIfcTextureCoordinate> IIfcSurfaceTexture.IsMappedBy => base.Model.Instances.Where((IIfcTextureCoordinate e) => e.Maps != null && e.Maps.Contains(this), "Maps", this);

	IEnumerable<IIfcSurfaceStyleWithTextures> IIfcSurfaceTexture.UsedInStyles => base.Model.Instances.Where((IIfcSurfaceStyleWithTextures e) => e.Textures != null && e.Textures.Contains(this), "Textures", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean RepeatS
	{
		get
		{
			if (_activated)
			{
				return _repeatS;
			}
			Activate();
			return _repeatS;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean v)
			{
				_repeatS = v;
			}, _repeatS, value, "RepeatS", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean RepeatT
	{
		get
		{
			if (_activated)
			{
				return _repeatT;
			}
			Activate();
			return _repeatT;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean v)
			{
				_repeatT = v;
			}, _repeatT, value, "RepeatT", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? Mode
	{
		get
		{
			if (_activated)
			{
				return _mode;
			}
			Activate();
			return _mode;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_mode = v;
			}, _mode, value, "Mode", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcCartesianTransformationOperator2D TextureTransform
	{
		get
		{
			if (_activated)
			{
				return _textureTransform;
			}
			Activate();
			return _textureTransform;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianTransformationOperator2D v)
			{
				_textureTransform = v;
			}, _textureTransform, value, "TextureTransform", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 5)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcIdentifier> Parameter
	{
		get
		{
			if (_activated)
			{
				return _parameter;
			}
			Activate();
			return _parameter;
		}
	}

	[InverseProperty("Maps")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 6)]
	public IEnumerable<IfcTextureCoordinate> IsMappedBy => base.Model.Instances.Where((IfcTextureCoordinate e) => e.Maps != null && e.Maps.Contains(this), "Maps", this);

	[InverseProperty("Textures")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcSurfaceStyleWithTextures> UsedInStyles => base.Model.Instances.Where((IfcSurfaceStyleWithTextures e) => e.Textures != null && e.Textures.Contains(this), "Textures", this);

	internal IfcSurfaceTexture(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_parameter = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcIdentifier>(this, 0, 5);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_repeatS = value.BooleanVal;
			break;
		case 1:
			_repeatT = value.BooleanVal;
			break;
		case 2:
			_mode = value.StringVal;
			break;
		case 3:
			_textureTransform = (IfcCartesianTransformationOperator2D)value.EntityVal;
			break;
		case 4:
			_parameter.InternalAdd(value.StringVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceTexture other)
	{
		return this == other;
	}
}
