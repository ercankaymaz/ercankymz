using System;
using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class GfxAttributesWire : GfxAttributesColor
{
	public GfxAttributesWire()
	{
	}

	protected GfxAttributesWire(GfxAttributesWire other)
		: base(other)
	{
	}

	public GfxAttributesWire(Color defaultColor, LayerKeyedCollection layers)
		: base(defaultColor, layers)
	{
	}

	[Obsolete("Use the constructor with the default color instead.")]
	public GfxAttributesWire(LayerKeyedCollection layers)
		: this(Color.Black, layers)
	{
	}

	protected internal override void Init(Color defaultColor, LayerKeyedCollection layers)
	{
		base.Init(defaultColor, layers);
	}

	internal override void Propagate(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D)
	{
		base.Propagate(_0023_003Dzs_0024uS8LA_003D, _0023_003DztIaJjPw_003D, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
		switch (_0023_003Dzs_0024uS8LA_003D.LineWeightMethod)
		{
		case colorMethodType.byLayer:
			LineWeight = _0023_003DztIaJjPw_003D.LineWeight;
			break;
		case colorMethodType.byEntity:
			LineWeight = _0023_003Dzs_0024uS8LA_003D.LineWeight;
			break;
		}
		switch (_0023_003Dzs_0024uS8LA_003D.LineTypeMethod)
		{
		case colorMethodType.byLayer:
			LineTypeName = _0023_003DztIaJjPw_003D.LineTypeName;
			break;
		case colorMethodType.byEntity:
			LineTypeName = _0023_003Dzs_0024uS8LA_003D.LineTypeName;
			break;
		}
	}

	internal void PropagateColorAndLineWeight(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D)
	{
		switch (_0023_003Dzs_0024uS8LA_003D.ColorMethod)
		{
		case colorMethodType.byLayer:
			Color = _0023_003DztIaJjPw_003D.Color;
			break;
		case colorMethodType.byEntity:
			Color = _0023_003Dzs_0024uS8LA_003D.Color;
			break;
		}
		switch (_0023_003Dzs_0024uS8LA_003D.LineWeightMethod)
		{
		case colorMethodType.byLayer:
			LineWeight = _0023_003DztIaJjPw_003D.LineWeight;
			break;
		case colorMethodType.byEntity:
			LineWeight = _0023_003Dzs_0024uS8LA_003D.LineWeight;
			break;
		}
	}

	public override object Clone()
	{
		return new GfxAttributesWire(this);
	}

	public void AssignColorAndLineWeight(GfxAttributes other)
	{
		Assign(other);
		GfxAttributesWire gfxAttributesWire = (GfxAttributesWire)other;
		LineWeight = gfxAttributesWire.LineWeight;
	}
}
