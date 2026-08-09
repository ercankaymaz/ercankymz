using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcSurfaceTexture", 722)]
public abstract class IfcSurfaceTexture : PersistEntity, IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist, IEquatable<IfcSurfaceTexture>
{
	private IfcIdentifier? _mode;

	private bool _repeatS;

	private bool _repeatT;

	private IfcSurfaceTextureEnum _textureType;

	private IfcCartesianTransformationOperator2D _textureTransform;

	[CrossSchemaAttribute(typeof(IIfcSurfaceTexture), 1)]
	IfcBoolean IIfcSurfaceTexture.RepeatS
	{
		get
		{
			return new IfcBoolean(RepeatS);
		}
		set
		{
			RepeatS = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceTexture), 2)]
	IfcBoolean IIfcSurfaceTexture.RepeatT
	{
		get
		{
			return new IfcBoolean(RepeatT);
		}
		set
		{
			RepeatT = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceTexture), 3)]
	IfcIdentifier? IIfcSurfaceTexture.Mode
	{
		get
		{
			return _mode;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_mode = v;
			}, _mode, value, "Mode", -3);
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
	IItemSet<IfcIdentifier> IIfcSurfaceTexture.Parameter => null;

	IEnumerable<IIfcTextureCoordinate> IIfcSurfaceTexture.IsMappedBy => base.Model.Instances.Where((IIfcTextureCoordinate e) => e.Maps != null && e.Maps.Contains(this), "Maps", this);

	IEnumerable<IIfcSurfaceStyleWithTextures> IIfcSurfaceTexture.UsedInStyles => base.Model.Instances.Where((IIfcSurfaceStyleWithTextures e) => e.Textures != null && e.Textures.Contains(this), "Textures", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public bool RepeatS
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
			SetValue(delegate(bool v)
			{
				_repeatS = v;
			}, _repeatS, value, "RepeatS", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public bool RepeatT
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
			SetValue(delegate(bool v)
			{
				_repeatT = v;
			}, _repeatT, value, "RepeatT", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcSurfaceTextureEnum TextureType
	{
		get
		{
			if (_activated)
			{
				return _textureType;
			}
			Activate();
			return _textureType;
		}
		set
		{
			SetValue(delegate(IfcSurfaceTextureEnum v)
			{
				_textureType = v;
			}, _textureType, value, "TextureType", 3);
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

	internal IfcSurfaceTexture(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			_textureType = (IfcSurfaceTextureEnum)Enum.Parse(typeof(IfcSurfaceTextureEnum), value.EnumVal, ignoreCase: true);
			break;
		case 3:
			_textureTransform = (IfcCartesianTransformationOperator2D)value.EntityVal;
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
