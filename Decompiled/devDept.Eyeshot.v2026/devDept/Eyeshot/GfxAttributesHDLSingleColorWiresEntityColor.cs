using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class GfxAttributesHDLSingleColorWiresEntityColor : GfxAttributesHDLSingleColor
{
	public GfxAttributesHDLSingleColorWiresEntityColor()
	{
	}

	protected GfxAttributesHDLSingleColorWiresEntityColor(GfxAttributesHDLSingleColorWiresEntityColor other)
		: base(other)
	{
	}

	public GfxAttributesHDLSingleColorWiresEntityColor(Color color, Color wireColor, LayerKeyedCollection layers)
		: base(color, wireColor, layers)
	{
	}

	internal override void Propagate(Entity ent, Layer layer, MaterialKeyedCollection materials)
	{
		base.Propagate(ent, layer, materials);
		switch (ent.ColorMethod)
		{
		case colorMethodType.byLayer:
			WireColor = layer.Color;
			break;
		case colorMethodType.byEntity:
			WireColor = ent.Color;
			break;
		}
	}

	public override object Clone()
	{
		return new GfxAttributesHDLSingleColorWiresEntityColor(this);
	}

	public override void AssignColor(Color color)
	{
	}
}
