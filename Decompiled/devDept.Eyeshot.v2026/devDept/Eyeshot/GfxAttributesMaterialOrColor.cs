using System;
using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class GfxAttributesMaterialOrColor : GfxAttributesColor
{
	public GfxAttributesMaterialOrColor()
	{
	}

	protected GfxAttributesMaterialOrColor(GfxAttributesColor other)
		: base(other)
	{
	}

	public GfxAttributesMaterialOrColor(Color defaultColor, LayerKeyedCollection layers)
		: base(defaultColor, layers)
	{
	}

	[Obsolete("Use the constructor with the default color instead.")]
	public GfxAttributesMaterialOrColor(LayerKeyedCollection layers)
		: this(Color.Black, layers)
	{
	}

	internal override void Propagate(Entity ent, Layer layer, MaterialKeyedCollection materials)
	{
		string text = null;
		switch (ent.ColorMethod)
		{
		case colorMethodType.byLayer:
			Color = layer.Color;
			text = layer.MaterialName;
			break;
		case colorMethodType.byEntity:
			Color = ent.Color;
			text = ent.MaterialName;
			break;
		default:
			return;
		}
		if (!string.IsNullOrEmpty(text) && materials.TryGetValue(text, out var value))
		{
			Color = value.WireColor;
		}
	}

	public override object Clone()
	{
		return new GfxAttributesMaterialOrColor(this);
	}
}
