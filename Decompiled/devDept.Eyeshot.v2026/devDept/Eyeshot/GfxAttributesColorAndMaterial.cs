using System;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class GfxAttributesColorAndMaterial : GfxAttributesColor
{
	public float EnvironmentIntensity;

	public Color RenderedColor;

	public Material Material;

	public IEnvironment EnvironmentMap;

	protected GfxAttributesColorAndMaterial(GfxAttributesColorAndMaterial other)
		: base(other)
	{
	}

	public GfxAttributesColorAndMaterial(Color defaultColor, LayerKeyedCollection layers, IWorkspace workspace)
		: base(defaultColor, layers)
	{
		RenderedColor = Color;
		EnvironmentMap = ((workspace != null) ? ((IWorkspaceInternal)workspace).EnvironmentMap : null);
	}

	[Obsolete("Use the constructor with the default color instead.")]
	public GfxAttributesColorAndMaterial(LayerKeyedCollection layers, IWorkspace workspace)
		: this(Color.Black, layers, workspace)
	{
	}

	public bool IsMaterialTransparent()
	{
		if (Material != null)
		{
			return Material.IsTransparent();
		}
		return false;
	}

	internal override void Propagate(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D)
	{
		string text = null;
		switch (_0023_003Dzs_0024uS8LA_003D.ColorMethod)
		{
		case colorMethodType.byLayer:
			Color = _0023_003DztIaJjPw_003D.Color;
			text = _0023_003DztIaJjPw_003D.MaterialName;
			break;
		case colorMethodType.byEntity:
			Color = _0023_003Dzs_0024uS8LA_003D.Color;
			text = _0023_003Dzs_0024uS8LA_003D.MaterialName;
			break;
		default:
			return;
		}
		if (!string.IsNullOrEmpty(text) && _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D.TryGetValue(text, out Material))
		{
			RenderedColor = Material.WireColor;
			EnvironmentIntensity = Material.Environment;
			if (Material.EnvironmentMappingTexture != null)
			{
				EnvironmentMap = Material.EnvironmentMappingTexture;
			}
		}
		else
		{
			RenderedColor = Color;
			Material = null;
		}
	}

	public override object Clone()
	{
		return new GfxAttributesColorAndMaterial(this);
	}

	public override void Assign(GfxAttributes other)
	{
		base.Assign(other);
		if (other is GfxAttributesColorAndMaterial gfxAttributesColorAndMaterial)
		{
			RenderedColor = gfxAttributesColorAndMaterial.RenderedColor;
			EnvironmentIntensity = gfxAttributesColorAndMaterial.EnvironmentIntensity;
			EnvironmentMap = gfxAttributesColorAndMaterial.EnvironmentMap;
			Material = gfxAttributesColorAndMaterial.Material;
		}
	}
}
