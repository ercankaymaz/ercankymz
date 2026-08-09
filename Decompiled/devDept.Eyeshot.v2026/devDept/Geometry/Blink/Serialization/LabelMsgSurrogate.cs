using System.Drawing;
using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink.Serialization;

internal class LabelMsgSurrogate : BlinkMsgSurrogate
{
	public string Content;

	public Color Color;

	public Point3D Position;

	public float FontSize;

	public LabelMsgSurrogate(LabelMsg obj)
		: base(obj)
	{
	}

	protected override BlinkMsg ConvertToObject()
	{
		LabelMsg labelMsg = new LabelMsg();
		CopyDataToObject(labelMsg);
		return labelMsg;
	}

	protected override void CopyDataToObject(BlinkMsg obj)
	{
		LabelMsg obj2 = (LabelMsg)obj;
		obj2.Position = Position;
		obj2.Color = Color;
		obj2.Content = Content;
		obj2.FontSize = FontSize;
	}

	protected override void CopyDataFromObject(BlinkMsg obj)
	{
		LabelMsg labelMsg = (LabelMsg)obj;
		Position = labelMsg.Position;
		Color = labelMsg.Color;
		Content = labelMsg.Content;
		FontSize = labelMsg.FontSize;
	}
}
