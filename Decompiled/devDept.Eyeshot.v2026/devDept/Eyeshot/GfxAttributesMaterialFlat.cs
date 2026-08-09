using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class GfxAttributesMaterialFlat : GfxAttributesRendered
{
	public GfxAttributesMaterialFlat()
	{
	}

	protected GfxAttributesMaterialFlat(GfxAttributesMaterialFlat other)
		: base(other)
	{
	}

	public GfxAttributesMaterialFlat(LayerKeyedCollection layers)
		: base(layers)
	{
	}

	internal override void Propagate(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D)
	{
		base.Propagate(_0023_003Dzs_0024uS8LA_003D, _0023_003DztIaJjPw_003D, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
		if (!string.IsNullOrEmpty(MaterialName) && _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D.TryGetValue(MaterialName, out var value))
		{
			Color = ((value.TextureImage != null) ? value.Diffuse : value.WireColor);
		}
	}

	public override object Clone()
	{
		return new GfxAttributesMaterialFlat(this);
	}
}
