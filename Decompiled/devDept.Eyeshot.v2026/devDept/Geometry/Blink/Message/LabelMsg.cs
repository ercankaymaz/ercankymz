using System.Drawing;
using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink.Message;

internal class LabelMsg : BlinkMsg
{
	public string Content;

	public Point3D Position;

	public float FontSize;

	public Color Color;

	public LabelMsg(string content, Point3D position, Color color, float fontSize)
	{
		Content = content;
		Position = position;
		Color = color;
		FontSize = fontSize;
	}

	internal LabelMsg()
	{
	}

	internal override BlinkMsgSurrogate ConvertToSurrogate()
	{
		return new LabelMsgSurrogate(this);
	}
}
