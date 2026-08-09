using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class GfxAttributesHDLWiresSingleColor : GfxAttributesWire
{
	public Color WireColor;

	public static Material WhiteMaterial = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985801), Color.White, Color.White, Color.Black, 0f, 0f);

	public GfxAttributesHDLWiresSingleColor()
	{
	}

	protected GfxAttributesHDLWiresSingleColor(GfxAttributesHDLWiresSingleColor other)
		: base(other)
	{
	}

	public GfxAttributesHDLWiresSingleColor(Color color, Color wireColor, LayerKeyedCollection layers)
	{
		Init(color, wireColor, layers);
	}

	internal void Init(Color defaultColor, Color wireColor, LayerKeyedCollection layers)
	{
		Init(defaultColor, layers);
		WireColor = wireColor;
	}

	public override object Clone()
	{
		return new GfxAttributesHDLWiresSingleColor(this);
	}

	public override void Assign(GfxAttributes other)
	{
		base.Assign(other);
		if (other is GfxAttributesHDLWiresSingleColor gfxAttributesHDLWiresSingleColor)
		{
			WireColor = gfxAttributesHDLWiresSingleColor.WireColor;
		}
	}

	internal override Material GetMaterial(MaterialKeyedCollection materials, Material defaultMaterial, bool forceGray, IWorkspace ws, Entity entity)
	{
		if (forceGray)
		{
			return Material._0023_003DzovlSUnojZWZr;
		}
		return WhiteMaterial;
	}

	internal virtual int GetAlpha(MaterialKeyedCollection materials, Material defaultMaterial, bool forceGray, IWorkspace ws, Entity entity)
	{
		return GetColor(forceGray, ws, entity).A;
	}

	internal Color GetWireColor(bool forceGray, IWorkspaceInternal ws, Entity entity)
	{
		if (!forceGray)
		{
			return WireColor;
		}
		return ws.ComputeNonCurrentEntityColor(entity, WireColor);
	}
}
