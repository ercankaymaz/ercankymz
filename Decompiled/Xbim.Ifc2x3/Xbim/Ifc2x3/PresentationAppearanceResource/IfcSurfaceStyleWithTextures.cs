using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyleWithTextures", 392)]
public class IfcSurfaceStyleWithTextures : PersistEntity, IIfcSurfaceStyleWithTextures, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IInstantiableEntity, IfcSurfaceStyleElementSelect, IContainsEntityReferences, IEquatable<IfcSurfaceStyleWithTextures>
{
	private readonly ItemSet<IfcSurfaceTexture> _textures;

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleWithTextures), 1)]
	IItemSet<IIfcSurfaceTexture> IIfcSurfaceStyleWithTextures.Textures => new ProxyItemSet<IfcSurfaceTexture, IIfcSurfaceTexture>(Textures);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcSurfaceTexture> Textures
	{
		get
		{
			if (_activated)
			{
				return _textures;
			}
			Activate();
			return _textures;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcSurfaceTexture texture in Textures)
			{
				yield return texture;
			}
		}
	}

	internal IfcSurfaceStyleWithTextures(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_textures = new ItemSet<IfcSurfaceTexture>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_textures.InternalAdd((IfcSurfaceTexture)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcSurfaceStyleWithTextures other)
	{
		return this == other;
	}
}
