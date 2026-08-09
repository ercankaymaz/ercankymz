using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Control.Labels;

[Serializable]
public class OutlinedText : TextOnly
{
	public Color OutlineColor
	{
		get
		{
			return labelFillColor;
		}
		set
		{
			labelFillColor = value;
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public OutlinedText(double x, double y, double z, string text, Font textFont)
		: base(x, y, z, text, textFont, Color.White)
	{
		labelFillColor = Color.Black;
	}

	public OutlinedText(double x, double y, double z, string text, Font textFont, Color textColor, Color outlineColor, ContentAlignment alignment)
		: base(x, y, z, text, textFont, textColor, alignment)
	{
		labelFillColor = outlineColor;
	}

	public OutlinedText(Point3D p, string text, Font textFont, Color textColor)
		: base(p, text, textFont, textColor)
	{
	}

	public OutlinedText(Point3D p, string text, Font textFont, Color textColor, Color outlineColor, ContentAlignment alignment)
		: base(p, text, textFont, textColor, alignment)
	{
		labelFillColor = outlineColor;
	}

	protected OutlinedText(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	protected override Bitmap GetBitmapFromText(Font myScaledFont, float scale, Color color, Color fillColor)
	{
		return Workspace.GetTextOutlinedImage(base.Text, myScaledFont, color, fillColor, base.Vertical ? RotateFlipType.Rotate90FlipX : RotateFlipType.Rotate180FlipX, scale);
	}

	public override LabelSurrogate ConvertToSurrogate()
	{
		return new OutlinedTextSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}
