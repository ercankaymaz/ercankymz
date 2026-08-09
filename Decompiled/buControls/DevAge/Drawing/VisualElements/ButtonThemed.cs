using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class ButtonThemed : ButtonBase
{
	private Button mStandardButton = new Button();

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

	public ButtonThemed()
	{
	}

	public ButtonThemed(ButtonThemed other)
		: base(other)
	{
	}

	public override object Clone()
	{
		return new ButtonThemed(this);
	}

	protected VisualStyleElement GetBackgroundElement()
	{
		if (Style != ButtonStyle.Hot)
		{
			if (Style != ButtonStyle.Pressed)
			{
				if (Style != ButtonStyle.Disabled)
				{
					if (Style != ButtonStyle.NormalDefault)
					{
						return VisualStyleElement.Button.PushButton.Normal;
					}
					return VisualStyleElement.Button.PushButton.Default;
				}
				return VisualStyleElement.Button.PushButton.Disabled;
			}
			return VisualStyleElement.Button.PushButton.Pressed;
		}
		return VisualStyleElement.Button.PushButton.Hot;
	}

	protected VisualStyleRenderer GetRenderer(VisualStyleElement element)
	{
		return new VisualStyleRenderer(element);
	}

	protected override void OnDraw(GraphicsCache graphics, RectangleF area)
	{
		base.OnDraw(graphics, area);
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
		using MeasureHelper measure = new MeasureHelper(graphics);
		ControlPaint.DrawFocusRectangle(graphics.Graphics, Rectangle.Round(GetBackgroundContentRectangle(measure, area)));
	}

	public override RectangleF GetBackgroundContentRectangle(MeasureHelper measure, RectangleF backGroundArea)
	{
		backGroundArea = base.GetBackgroundContentRectangle(measure, backGroundArea);
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			return mStandardButton.GetBackgroundContentRectangle(measure, backGroundArea);
		}
		return GetRenderer(GetBackgroundElement()).GetBackgroundContentRectangle(measure.Graphics, Rectangle.Round(backGroundArea));
	}

	public override SizeF GetBackgroundExtent(MeasureHelper measure, SizeF contentSize)
	{
		if (!Application.RenderWithVisualStyles || !VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
		{
			contentSize = mStandardButton.GetBackgroundExtent(measure, contentSize);
		}
		else
		{
			Rectangle contentBounds = new Rectangle(new Point(0, 0), Size.Ceiling(contentSize));
			contentSize = GetRenderer(GetBackgroundElement()).GetBackgroundExtent(measure.Graphics, contentBounds).Size;
		}
		return base.GetBackgroundExtent(measure, contentSize);
	}
}
