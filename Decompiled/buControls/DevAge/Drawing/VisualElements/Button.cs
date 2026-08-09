using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Button : ButtonBase
{
	public Button()
	{
	}

	public Button(Button other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new Button(this);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		base.OnDraw(graphics, area);
		ControlPaint.DrawButton(state: (Style == ButtonStyle.Disabled) ? ButtonState.Inactive : ((Style == ButtonStyle.Pressed) ? ButtonState.Pushed : ((Style == ButtonStyle.Hot) ? ButtonState.Normal : ButtonState.Normal)), graphics: graphics.Graphics, rectangle: Rectangle.Round(area));
		if (Style == ButtonStyle.NormalDefault)
		{
			graphics.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(area));
		}
		if (Style == ButtonStyle.Focus)
		{
			using (MeasureHelper measure = new MeasureHelper(graphics))
			{
				ControlPaint.DrawFocusRectangle(graphics.Graphics, Rectangle.Round(GetBackgroundContentRectangle(measure, area)));
			}
		}
	}

	public override RectangleF GetBackgroundContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
	{
		backGroundArea = base.GetBackgroundContentRectangle(measure, backGroundArea);
		if (backGroundArea.Width > 4f)
		{
			backGroundArea.X += 2f;
			backGroundArea.Width -= 4f;
		}
		if (backGroundArea.Height > 4f)
		{
			backGroundArea.Y += 2f;
			backGroundArea.Height -= 4f;
		}
		return backGroundArea;
	}

	public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
	{
		contentSize = new SizeF(contentSize.Width + 4f, contentSize.Height + 4f);
		return base.GetBackgroundExtent(measure, contentSize);
	}
}
