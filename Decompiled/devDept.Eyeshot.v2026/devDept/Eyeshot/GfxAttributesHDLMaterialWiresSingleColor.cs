using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class GfxAttributesHDLMaterialWiresSingleColor : GfxAttributesHDLWiresSingleColor
{
	public GfxAttributesHDLMaterialWiresSingleColor()
	{
	}

	protected GfxAttributesHDLMaterialWiresSingleColor(GfxAttributesHDLMaterialWiresSingleColor other)
		: base(other)
	{
	}

	public GfxAttributesHDLMaterialWiresSingleColor(Color color, Color wireColor, string materialName, LayerKeyedCollection layers)
		: base(color, wireColor, layers)
	{
		MaterialName = materialName;
	}

	internal override void Propagate(Entity ent, Layer layer, MaterialKeyedCollection materials)
	{
		base.Propagate(ent, layer, materials);
		GfxAttributesRendered._0023_003Dzez_SlzbWDQSh(ent, layer, ref MaterialName);
	}

	public override object Clone()
	{
		return new GfxAttributesHDLMaterialWiresSingleColor(this);
	}

	internal override Material GetMaterial(MaterialKeyedCollection materials, Material defaultMaterial, bool forceGray, IWorkspace ws, Entity entity)
	{
		if (forceGray)
		{
			return GfxAttributesColor.GetMaterial(materials, null, Color, defaultMaterial, forceGray, ws, entity);
		}
		return GfxAttributesColor.GetMaterial(materials, MaterialName, Color, defaultMaterial, forceGray, ws, entity);
	}

	internal override int GetAlpha(MaterialKeyedCollection materials, Material defaultMaterial, bool forceGray, IWorkspace ws, Entity entity)
	{
		return GetMaterial(materials, defaultMaterial, forceGray, ws, entity).Diffuse.A;
	}
}
