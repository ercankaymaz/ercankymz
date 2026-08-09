using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.TopologyResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextureMap", 734)]
public class IfcTextureMap : IfcTextureCoordinate, IIfcTextureMap, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTextureMap>
{
	private readonly ItemSet<IfcTextureVertex> _vertices;

	private IfcFace _mappedTo;

	[CrossSchemaAttribute(typeof(IIfcTextureMap), 2)]
	IEnumerable<IIfcTextureVertex> IIfcTextureMap.Vertices => new ProxyItemSet<IfcTextureVertex, IIfcTextureVertex>(Vertices);

	[CrossSchemaAttribute(typeof(IIfcTextureMap), 3)]
	IIfcFace IIfcTextureMap.MappedTo
	{
		get
		{
			return MappedTo;
		}
		set
		{
			MappedTo = value as IfcFace;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 3 }, new int[] { -1 }, 2)]
	public IItemSet<IfcTextureVertex> Vertices
	{
		get
		{
			if (_activated)
			{
				return _vertices;
			}
			Activate();
			return _vertices;
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcFace MappedTo
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
			SetValue(delegate(IfcFace v)
			{
				_mappedTo = v;
			}, _mappedTo, value, "MappedTo", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcSurfaceTexture map in base.Maps)
			{
				yield return map;
			}
			foreach (IfcTextureVertex vertex in Vertices)
			{
				yield return vertex;
			}
			if (MappedTo != null)
			{
				yield return MappedTo;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcSurfaceTexture map in base.Maps)
			{
				yield return map;
			}
			if (MappedTo != null)
			{
				yield return MappedTo;
			}
		}
	}

	internal IfcTextureMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_vertices = new ItemSet<IfcTextureVertex>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_vertices.InternalAdd((IfcTextureVertex)value.EntityVal);
			break;
		case 2:
			_mappedTo = (IfcFace)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextureMap other)
	{
		return this == other;
	}
}
