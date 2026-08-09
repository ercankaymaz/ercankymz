using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class CheckBox : CheckBoxBase
{
	public CheckBox()
	{
	}

	public CheckBox(CheckBox other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new CheckBox(this);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		ButtonState buttonState = ((Style == ControlDrawStyle.Disabled) ? ButtonState.Inactive : ((Style == ControlDrawStyle.Pressed) ? ButtonState.Pushed : ((Style == ControlDrawStyle.Hot) ? ButtonState.Normal : ButtonState.Normal)));
		if (CheckBoxState == CheckBoxState.Checked)
		{
			buttonState |= ButtonState.Checked;
		}
		ControlPaint.DrawCheckBox(graphics.Graphics, Rectangle.Round(area), buttonState);
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		return new SizeF(16f, 16f);
	}
}
