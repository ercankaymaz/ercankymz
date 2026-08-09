using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextureCoordinate", 732)]
public abstract class IfcTextureCoordinate : IfcPresentationItem, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist, IEquatable<IfcTextureCoordinate>
{
	private readonly ItemSet<IfcSurfaceTexture> _maps;

	[CrossSchemaAttribute(typeof(IIfcTextureCoordinate), 1)]
	IItemSet<IIfcSurfaceTexture> IIfcTextureCoordinate.Maps => new ProxyItemSet<IfcSurfaceTexture, IIfcSurfaceTexture>(Maps);

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcSurfaceTexture> Maps
	{
		get
		{
			if (_activated)
			{
				return _maps;
			}
			Activate();
			return _maps;
		}
	}

	internal IfcTextureCoordinate(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_maps = new ItemSet<IfcSurfaceTexture>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_maps.InternalAdd((IfcSurfaceTexture)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcTextureCoordinate other)
	{
		return this == other;
	}
}
