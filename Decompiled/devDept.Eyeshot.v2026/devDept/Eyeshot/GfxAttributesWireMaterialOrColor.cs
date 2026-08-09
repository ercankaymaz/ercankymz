using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class GfxAttributesWireMaterialOrColor : GfxAttributesWire
{
	protected internal GfxAttributesWireMaterialOrColor(GfxAttributesWire other)
		: base(other)
	{
	}

	public GfxAttributesWireMaterialOrColor(LayerKeyedCollection layers)
		: base(layers)
	{
	}

	internal override void Propagate(Entity ent, Layer layer, MaterialKeyedCollection materials)
	{
		base.Propagate(ent, layer, materials);
		string _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D = null;
		GfxAttributesRendered._0023_003Dzez_SlzbWDQSh(ent, layer, ref _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D);
		if (!string.IsNullOrEmpty(_0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D) && materials.TryGetValue(_0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D, out var value))
		{
			Color = value.WireColor;
		}
	}

	public override object Clone()
	{
		return new GfxAttributesWireMaterialOrColor(this);
	}
}
