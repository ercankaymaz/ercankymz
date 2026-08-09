using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

[Serializable]
public class SheetKeyedCollection : EyeshotDisposableKeyedCollection<Sheet>
{
	public SheetKeyedCollection()
		: base((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	public SheetKeyedCollection(IEnumerable<Sheet> collection)
		: base(collection, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	internal RenderContextBase _0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D()
	{
		return _0023_003Dzo60vEkkaRGxX()?.RenderContext;
	}

	protected override string GetKeyForItem(Sheet item)
	{
		return item.Name;
	}

	public Sheet Add(linearUnitsType units, double width, double height, string name, angleProjectionType angleProjection)
	{
		Sheet sheet = new Sheet(units, width, height, name, angleProjection);
		Add(sheet);
		return sheet;
	}

	protected override bool AreEntitiesWith(HashSet<string> names, IList<Entity> entities)
	{
		return false;
	}

	protected override void RemoveItem(int index)
	{
		base.RemoveItem(index);
		if (base.Document is DrawingDocument drawingDocument && base.Items.Count == 0)
		{
			drawingDocument.ActiveSheet = null;
		}
	}

	internal override void _0023_003DzOcZnt98_003D(Document _0023_003DzoPlwCJA_003D)
	{
		if (_0023_003DzoPlwCJA_003D == null)
		{
			_0023_003DzhM3qURBkRYYd();
		}
		base._0023_003DzOcZnt98_003D(_0023_003DzoPlwCJA_003D);
	}
}
