using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class DropDownButtonThemed : DropDownButtonBase
{
	private DropDownButton mStandardButton = new DropDownButton();

	public override ButtonStyle Style
	{
		get
		{
			return base.Style;
		}
		set
		{
			base.Style = value;
			mStandardButton.Style = value;
		}
	}

	public DropDownButtonThemed()
	{
	}

	public DropDownButtonThemed(DropDownButtonThemed other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new DropDownButtonThemed(this);
	}

	protected VisualStyleElement GetBackgroundElement()
	{
		if (Style != ButtonStyle.Hot)
		{
			if (Style != ButtonStyle.Pressed)
			{
				if (Style != ButtonStyle.Disabled)
				{
					return VisualStyleElement.ComboBox.DropDownButton.Normal;
				}
				return VisualStyleElement.ComboBox.DropDownButton.Disabled;
			}
			return VisualStyleElement.ComboBox.DropDownButton.Pressed;
		}
		return VisualStyleElement.ComboBox.DropDownButton.Hot;
	}

	protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
	{
		return new VisualStyleRenderer(element);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			mStandardButton.Draw(graphics, area);
			return;
		}
		GetRenderer(GetBackgroundElement()).DrawBackground(graphics.Graphics, Rectangle.Round(area));
		if (Style != ButtonStyle.Focus)
		{
			return;
		}
		using (new MeasureHelper(graphics))
		{
			ControlPaint.DrawFocusRectangle(graphics.Graphics, Rectangle.Round(area));
		}
	}

	protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
	{
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			return mStandardButton.Measure(measure, Size.Empty, maxSize);
		}
		Size partSize = GetRenderer(GetBackgroundElement()).GetPartSize(measure.Graphics, ThemeSizeType.True);
		if (partSize.Width < 16)
		{
			partSize.Width = 16;
		}
		return partSize;
	}
}
