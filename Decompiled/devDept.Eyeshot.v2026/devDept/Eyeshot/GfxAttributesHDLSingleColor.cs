using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class GfxAttributesHDLSingleColor : GfxAttributesHDLWiresSingleColor
{
	public GfxAttributesHDLSingleColor()
	{
	}

	protected GfxAttributesHDLSingleColor(GfxAttributesHDLSingleColor other)
		: base(other)
	{
	}

	public GfxAttributesHDLSingleColor(Color color, Color wireColor, LayerKeyedCollection layers)
		: base(color, wireColor, layers)
	{
	}

	internal override void Propagate(Entity ent, Layer layer, MaterialKeyedCollection materials)
	{
		switch (ent.LineTypeMethod)
		{
		case colorMethodType.byLayer:
			LineTypeName = layer.LineTypeName;
			break;
		case colorMethodType.byEntity:
			LineTypeName = ent.LineTypeName;
			break;
		}
	}

	public override object Clone()
	{
		return new GfxAttributesHDLSingleColor(this);
	}

	public override void AssignColor(Color color)
	{
	}
}
