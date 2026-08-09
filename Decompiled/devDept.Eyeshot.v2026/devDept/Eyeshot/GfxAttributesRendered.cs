using System;
using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class GfxAttributesRendered : GfxAttributesWire
{
	public GfxAttributesRendered()
	{
	}

	protected GfxAttributesRendered(GfxAttributesRendered other)
		: base(other)
	{
	}

	public GfxAttributesRendered(Color defaultColor, LayerKeyedCollection layers)
		: base(defaultColor, layers)
	{
	}

	[Obsolete("Use the constructor with the default color instead.")]
	public GfxAttributesRendered(LayerKeyedCollection layers)
		: this(Color.Black, layers)
	{
	}

	internal override void Propagate(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D)
	{
		base.Propagate(_0023_003Dzs_0024uS8LA_003D, _0023_003DztIaJjPw_003D, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
		string _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D = MaterialName;
		_0023_003Dzez_SlzbWDQSh(_0023_003Dzs_0024uS8LA_003D, _0023_003DztIaJjPw_003D, ref _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D);
		MaterialName = _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D;
	}

	internal static void _0023_003Dzez_SlzbWDQSh(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D, ref string _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D)
	{
		switch (_0023_003Dzs_0024uS8LA_003D.ColorMethod)
		{
		case colorMethodType.byLayer:
			_0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D = _0023_003DztIaJjPw_003D.MaterialName;
			break;
		case colorMethodType.byEntity:
			_0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D = _0023_003Dzs_0024uS8LA_003D.MaterialName;
			break;
		}
	}

	public override object Clone()
	{
		return new GfxAttributesRendered(this);
	}

	internal Material GetMaterial(MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, Material _0023_003DzV4_0024P_0024OTTy48l)
	{
		return GfxAttributesColor.GetMaterial(_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, MaterialName, Color, _0023_003DzV4_0024P_0024OTTy48l, forceGray: false, null, null);
	}

	internal Material GetMaterial(MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, Material _0023_003DzV4_0024P_0024OTTy48l, bool _0023_003Dz4mEOnvdgjJv0, IWorkspace _0023_003DzFM3KC0w_003D, Entity _0023_003Dz9j7EUB0_003D, bool _0023_003DzVzdmmKabr_jUbIwWbA_003D_003D = false)
	{
		return GfxAttributesColor.GetMaterial(_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, MaterialName, Color, _0023_003DzV4_0024P_0024OTTy48l, _0023_003Dz4mEOnvdgjJv0, _0023_003DzFM3KC0w_003D, _0023_003Dz9j7EUB0_003D, _0023_003DzVzdmmKabr_jUbIwWbA_003D_003D);
	}

	internal bool IsMaterialTransparent(MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, Material _0023_003DzV4_0024P_0024OTTy48l, bool _0023_003Dz4mEOnvdgjJv0, IWorkspace _0023_003DzFM3KC0w_003D, Entity _0023_003Dz9j7EUB0_003D, bool _0023_003DzVzdmmKabr_jUbIwWbA_003D_003D = false)
	{
		return GfxAttributesColor.GetMaterial(_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, MaterialName, Color, _0023_003DzV4_0024P_0024OTTy48l, _0023_003Dz4mEOnvdgjJv0, _0023_003DzFM3KC0w_003D, _0023_003Dz9j7EUB0_003D, _0023_003DzVzdmmKabr_jUbIwWbA_003D_003D).IsTransparent();
	}
}
