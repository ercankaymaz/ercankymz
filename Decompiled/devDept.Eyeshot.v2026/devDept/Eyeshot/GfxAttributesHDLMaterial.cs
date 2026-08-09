using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class GfxAttributesHDLMaterial : GfxAttributesHDLMaterialWiresSingleColor
{
	public GfxAttributesHDLMaterial()
	{
	}

	protected GfxAttributesHDLMaterial(GfxAttributesHDLMaterial other)
		: base(other)
	{
	}

	public GfxAttributesHDLMaterial(Color color, Color wireColor, string materialName, LayerKeyedCollection layers)
		: base(color, wireColor, materialName, layers)
	{
	}

	internal override void Propagate(Entity ent, Layer layer, MaterialKeyedCollection materials)
	{
		base.Propagate(ent, layer, materials);
		WireColor = Color;
	}

	public override object Clone()
	{
		return new GfxAttributesHDLMaterial(this);
	}
}
