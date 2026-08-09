using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class GfxAttributesHDL : GfxAttributesHDLWiresSingleColor
{
	public GfxAttributesHDL()
	{
	}

	protected GfxAttributesHDL(GfxAttributesHDL other)
		: base(other)
	{
	}

	public GfxAttributesHDL(Color color, Color wireColor, LayerKeyedCollection layers)
		: base(color, wireColor, layers)
	{
	}

	internal override void Propagate(Entity ent, Layer layer, MaterialKeyedCollection materials)
	{
		base.Propagate(ent, layer, materials);
		WireColor = Color;
	}

	public override object Clone()
	{
		return new GfxAttributesHDL(this);
	}
}
