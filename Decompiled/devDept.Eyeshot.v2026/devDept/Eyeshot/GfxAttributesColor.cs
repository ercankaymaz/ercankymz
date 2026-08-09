using System;
using System.Diagnostics;
using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class GfxAttributesColor : GfxAttributes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzK8rC_ew_003D;

	public GfxAttributesColor()
	{
	}

	protected GfxAttributesColor(GfxAttributesColor other)
		: base(other)
	{
	}

	public GfxAttributesColor(Color defaultColor, LayerKeyedCollection layers)
	{
		Init(defaultColor, layers);
	}

	[Obsolete("Use the constructor with the default color instead.")]
	public GfxAttributesColor(LayerKeyedCollection layers)
		: this(Color.Black, layers)
	{
	}

	protected internal override void Init(Color defaultColor, LayerKeyedCollection layers)
	{
		base.Init(defaultColor, layers);
		if (layers != null && layers.TryGetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746), out var value))
		{
			_0023_003DzK8rC_ew_003D = value.Color;
		}
	}

	internal override void PropagateLayer0(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D)
	{
		if (_0023_003DztIaJjPw_003D.Name != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746))
		{
			_0023_003DzK8rC_ew_003D = _0023_003DztIaJjPw_003D.Color;
		}
	}

	internal override void Propagate(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D)
	{
		switch (_0023_003Dzs_0024uS8LA_003D.ColorMethod)
		{
		case colorMethodType.byLayer:
			Color = ((_0023_003DztIaJjPw_003D.Name != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746)) ? _0023_003DztIaJjPw_003D.Color : _0023_003DzK8rC_ew_003D);
			break;
		case colorMethodType.byEntity:
			Color = _0023_003Dzs_0024uS8LA_003D.Color;
			break;
		}
	}

	public override void Assign(GfxAttributes other)
	{
		base.Assign(other);
		if (other is GfxAttributesColor gfxAttributesColor)
		{
			_0023_003DzK8rC_ew_003D = gfxAttributesColor._0023_003DzK8rC_ew_003D;
		}
	}

	public override void AssignColor(Color color)
	{
		Color = color;
	}

	public override object Clone()
	{
		return new GfxAttributesColor(this);
	}

	protected internal static Material GetMaterial(MaterialKeyedCollection materials, string materialName, Color color, Material defaultMaterial, bool forceGray, IWorkspace ws, Entity entity, bool forBlending = false)
	{
		Material material;
		if (string.IsNullOrEmpty(materialName))
		{
			material = defaultMaterial;
			material.Diffuse = color;
		}
		else
		{
			material = materials[materialName];
		}
		if (forceGray)
		{
			defaultMaterial.Diffuse = ((IWorkspaceInternal)ws).ComputeNonCurrentEntityColor(entity, material.Diffuse, edge: false, forBlending);
			return defaultMaterial;
		}
		return material;
	}

	internal virtual Material GetMaterial(MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, Material _0023_003DzV4_0024P_0024OTTy48l, bool _0023_003Dz4mEOnvdgjJv0, IWorkspace _0023_003DzFM3KC0w_003D, Entity _0023_003Dz9j7EUB0_003D)
	{
		if (!_0023_003Dz4mEOnvdgjJv0)
		{
			return _0023_003DzV4_0024P_0024OTTy48l;
		}
		return Material._0023_003DzovlSUnojZWZr;
	}
}
