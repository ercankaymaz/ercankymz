using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcSurfaceTexture", 722)]
public abstract class IfcSurfaceTexture : IfcPresentationItem, IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist, IEquatable<IfcSurfaceTexture>
{
	private IfcBoolean _repeatS;

	private IfcBoolean _repeatT;

	private IfcIdentifier? _mode;

	private IfcCartesianTransformationOperator2D _textureTransform;

	private readonly OptionalItemSet<IfcIdentifier> _parameter;

	IfcBoolean IIfcSurfaceTexture.RepeatS
	{
		get
		{
			return RepeatS;
		}
		set
		{
			RepeatS = value;
		}
	}

	IfcBoolean IIfcSurfaceTexture.RepeatT
	{
		get
		{
			return RepeatT;
		}
		set
		{
			RepeatT = value;
		}
	}

	IfcIdentifier? IIfcSurfaceTexture.Mode
	{
		get
		{
			return Mode;
		}
		set
		{
			Mode = value;
		}
	}

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

	IItemSet<IfcIdentifier> IIfcSurfaceTexture.Parameter => Parameter;

	IEnumerable<IIfcTextureCoordinate> IIfcSurfaceTexture.IsMappedBy => IsMappedBy;

	IEnumerable<IIfcSurfaceStyleWithTextures> IIfcSurfaceTexture.UsedInStyles => UsedInStyles;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcBoolean RepeatS
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
			SetValue(delegate(IfcBoolean v)
			{
				_repeatS = v;
			}, _repeatS, value, "RepeatS", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcBoolean RepeatT
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
			SetValue(delegate(IfcBoolean v)
			{
				_repeatT = v;
			}, _repeatT, value, "RepeatT", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcIdentifier? Mode
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
			SetValue(delegate(IfcIdentifier? v)
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
	public IOptionalItemSet<IfcIdentifier> Parameter
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
		_parameter = new OptionalItemSet<IfcIdentifier>(this, 0, 5);
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
