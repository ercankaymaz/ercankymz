using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class DropDownButton : DropDownButtonBase
{
	public DropDownButton()
	{
	}

	public DropDownButton(DropDownButton other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new DropDownButton(this);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		ControlPaint.DrawComboButton(state: (Style == ButtonStyle.Disabled) ? ButtonState.Inactive : ((Style == ButtonStyle.Pressed) ? ButtonState.Pushed : ((Style == ButtonStyle.Hot) ? ButtonState.Normal : ButtonState.Normal)), graphics: graphics.Graphics, rectangle: Rectangle.Round(area));
		if (Style == ButtonStyle.NormalDefault)
		{
			graphics.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(area));
		}
		if (Style == ButtonStyle.Focus)
		{
			using (new MeasureHelper(graphics))
			{
				ControlPaint.DrawFocusRectangle(graphics.Graphics, Rectangle.Round(area));
			}
		}
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		return new SizeF(16f, 16f);
	}
}
