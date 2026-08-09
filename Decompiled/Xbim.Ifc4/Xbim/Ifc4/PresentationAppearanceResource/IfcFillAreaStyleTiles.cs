using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcFillAreaStyleTiles", 725)]
public class IfcFillAreaStyleTiles : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcFillAreaStyleTiles, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcFillStyleSelect, IIfcFillStyleSelect, IContainsEntityReferences, IEquatable<IfcFillAreaStyleTiles>
{
	private readonly ItemSet<IfcVector> _tilingPattern;

	private readonly ItemSet<IfcStyledItem> _tiles;

	private IfcPositiveRatioMeasure _tilingScale;

	IEnumerable<IIfcVector> IIfcFillAreaStyleTiles.TilingPattern => new ProxyItemSet<IfcVector, IIfcVector>(TilingPattern);

	IEnumerable<IIfcStyledItem> IIfcFillAreaStyleTiles.Tiles => new ProxyItemSet<IfcStyledItem, IIfcStyledItem>(Tiles);

	IfcPositiveRatioMeasure IIfcFillAreaStyleTiles.TilingScale
	{
		get
		{
			return TilingScale;
		}
		set
		{
			TilingScale = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 2 }, new int[] { 2 }, 3)]
	public IItemSet<IfcVector> TilingPattern
	{
		get
		{
			if (_activated)
			{
				return _tilingPattern;
			}
			Activate();
			return _tilingPattern;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcStyledItem> Tiles
	{
		get
		{
			if (_activated)
			{
				return _tiles;
			}
			Activate();
			return _tiles;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveRatioMeasure TilingScale
	{
		get
		{
			if (_activated)
			{
				return _tilingScale;
			}
			Activate();
			return _tilingScale;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure v)
			{
				_tilingScale = v;
			}, _tilingScale, value, "TilingScale", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcVector item in TilingPattern)
			{
				yield return item;
			}
			foreach (IfcStyledItem tile in Tiles)
			{
				yield return tile;
			}
		}
	}

	internal IfcFillAreaStyleTiles(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_tilingPattern = new ItemSet<IfcVector>(this, 2, 1);
		_tiles = new ItemSet<IfcStyledItem>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_tilingPattern.InternalAdd((IfcVector)value.EntityVal);
			break;
		case 1:
			_tiles.InternalAdd((IfcStyledItem)value.EntityVal);
			break;
		case 2:
			_tilingScale = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFillAreaStyleTiles other)
	{
		return this == other;
	}
}
