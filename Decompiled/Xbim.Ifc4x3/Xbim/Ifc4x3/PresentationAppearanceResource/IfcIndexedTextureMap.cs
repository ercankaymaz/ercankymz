using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometricModelResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcIndexedTextureMap", 1191)]
public abstract class IfcIndexedTextureMap : IfcTextureCoordinate, IIfcIndexedTextureMap, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist, IEquatable<IfcIndexedTextureMap>
{
	private IfcTessellatedFaceSet _mappedTo;

	private IfcTextureVertexList _texCoords;

	[CrossSchemaAttribute(typeof(IIfcIndexedTextureMap), 2)]
	IIfcTessellatedFaceSet IIfcIndexedTextureMap.MappedTo
	{
		get
		{
			return MappedTo;
		}
		set
		{
			MappedTo = value as IfcTessellatedFaceSet;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIndexedTextureMap), 3)]
	IIfcTextureVertexList IIfcIndexedTextureMap.TexCoords
	{
		get
		{
			return TexCoords;
		}
		set
		{
			TexCoords = value as IfcTextureVertexList;
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcTessellatedFaceSet MappedTo
	{
		get
		{
			if (_activated)
			{
				return _mappedTo;
			}
			Activate();
			return _mappedTo;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTessellatedFaceSet v)
			{
				_mappedTo = v;
			}, _mappedTo, value, "MappedTo", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcTextureVertexList TexCoords
	{
		get
		{
			if (_activated)
			{
				return _texCoords;
			}
			Activate();
			return _texCoords;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTextureVertexList v)
			{
				_texCoords = v;
			}, _texCoords, value, "TexCoords", 3);
		}
	}

	internal IfcIndexedTextureMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_mappedTo = (IfcTessellatedFaceSet)value.EntityVal;
			break;
		case 2:
			_texCoords = (IfcTextureVertexList)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIndexedTextureMap other)
	{
		return this == other;
	}
}
