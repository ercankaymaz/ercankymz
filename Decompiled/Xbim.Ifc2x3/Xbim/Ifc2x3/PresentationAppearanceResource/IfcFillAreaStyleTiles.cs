using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcFillAreaStyleTiles", 725)]
public class IfcFillAreaStyleTiles : IfcGeometricRepresentationItem, IIfcFillAreaStyleTiles, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.PresentationAppearanceResource.IfcFillStyleSelect, IIfcFillStyleSelect, IInstantiableEntity, IfcFillStyleSelect, IContainsEntityReferences, IEquatable<IfcFillAreaStyleTiles>
{
	private IfcOneDirectionRepeatFactor _tilingPattern;

	private readonly ItemSet<IfcFillAreaStyleTileShapeSelect> _tiles;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure _tilingScale;

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyleTiles), 1)]
	IEnumerable<IIfcVector> IIfcFillAreaStyleTiles.TilingPattern
	{
		get
		{
			yield return TilingPattern.RepeatFactor;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyleTiles), 2)]
	IEnumerable<IIfcStyledItem> IIfcFillAreaStyleTiles.Tiles => (from tile in Tiles.OfType<IfcFillAreaStyleTileSymbolWithStyle>()
		select tile.Symbol.Item).OfType<IIfcStyledItem>();

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyleTiles), 3)]
	Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure IIfcFillAreaStyleTiles.TilingScale
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure(TilingScale);
		}
		set
		{
			TilingScale = new Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure(value);
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcOneDirectionRepeatFactor TilingPattern
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
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcOneDirectionRepeatFactor v)
			{
				_tilingPattern = v;
			}, _tilingPattern, value, "TilingPattern", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcFillAreaStyleTileShapeSelect> Tiles
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
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure TilingScale
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure v)
			{
				_tilingScale = v;
			}, _tilingScale, value, "TilingScale", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (TilingPattern != null)
			{
				yield return TilingPattern;
			}
			foreach (IfcFillAreaStyleTileShapeSelect tile in Tiles)
			{
				yield return tile;
			}
		}
	}

	internal IfcFillAreaStyleTiles(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_tiles = new ItemSet<IfcFillAreaStyleTileShapeSelect>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_tilingPattern = (IfcOneDirectionRepeatFactor)value.EntityVal;
			break;
		case 1:
			_tiles.InternalAdd((IfcFillAreaStyleTileShapeSelect)value.EntityVal);
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
