using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcVertexBasedTextureMap", 736)]
public class IfcVertexBasedTextureMap : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcVertexBasedTextureMap>
{
	private readonly ItemSet<IfcTextureVertex> _textureVertices;

	private readonly ItemSet<IfcCartesianPoint> _texturePoints;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 3 }, new int[] { -1 }, 1)]
	public IItemSet<IfcTextureVertex> TextureVertices
	{
		get
		{
			if (_activated)
			{
				return _textureVertices;
			}
			Activate();
			return _textureVertices;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 3 }, new int[] { -1 }, 2)]
	public IItemSet<IfcCartesianPoint> TexturePoints
	{
		get
		{
			if (_activated)
			{
				return _texturePoints;
			}
			Activate();
			return _texturePoints;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcTextureVertex textureVertex in TextureVertices)
			{
				yield return textureVertex;
			}
			foreach (IfcCartesianPoint texturePoint in TexturePoints)
			{
				yield return texturePoint;
			}
		}
	}

	internal IfcVertexBasedTextureMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_textureVertices = new ItemSet<IfcTextureVertex>(this, 0, 1);
		_texturePoints = new ItemSet<IfcCartesianPoint>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_textureVertices.InternalAdd((IfcTextureVertex)value.EntityVal);
			break;
		case 1:
			_texturePoints.InternalAdd((IfcCartesianPoint)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVertexBasedTextureMap other)
	{
		return this == other;
	}
}
