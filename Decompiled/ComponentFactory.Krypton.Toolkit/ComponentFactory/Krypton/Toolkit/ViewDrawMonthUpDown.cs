#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawMonthUpDown : ViewDrawButton
{
	public enum DrawMonthCalendarGlyph
	{
		DropDownButton,
		UpButton,
		DownButton
	}

	private DrawMonthCalendarGlyph _glyph;

	private ButtonController _controller;

	public event EventHandler Click;

	public event MouseEventHandler MouseSelect;

	public ViewDrawMonthUpDown(IPaletteTriple paletteState, IPaletteMetric paletteMetric, IContentValues buttonValues, DrawMonthCalendarGlyph glyph, NeedPaintHandler needPaintHandler)
		: base(paletteState, paletteState, paletteState, paletteState, paletteMetric, buttonValues, VisualOrientation.Top, useMnemonic: false)
	{
		_glyph = glyph;
		_controller = new ButtonController(this, needPaintHandler);
		_controller.Click += OnButtonClick;
		_controller.MouseSelect += OnButtonMouseSelect;
		_controller.Repeat = true;
		_controller.ClickOnDown = true;
		MouseController = _controller;
	}

	public override string ToString()
	{
		return "ViewDrawMonthUpDown:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return new Size(SystemInformation.VerticalScrollBarWidth - 2, 0);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Rectangle displayRectangle = context.DisplayRectangle;
		switch (_glyph)
		{
		case DrawMonthCalendarGlyph.DropDownButton:
			context.DisplayRectangle = new Rectangle(displayRectangle.X, displayRectangle.Y + 1, displayRectangle.Width, displayRectangle.Height - 2);
			break;
		case DrawMonthCalendarGlyph.UpButton:
			context.DisplayRectangle = new Rectangle(displayRectangle.X, displayRectangle.Y + 1, displayRectangle.Width, displayRectangle.Height - 1);
			break;
		case DrawMonthCalendarGlyph.DownButton:
			context.DisplayRectangle = new Rectangle(displayRectangle.X, displayRectangle.Y, displayRectangle.Width, displayRectangle.Height - 1);
			break;
		}
		base.Layout(context);
		context.DisplayRectangle = displayRectangle;
		ClientRectangle = displayRectangle;
	}

	public override void RenderAfter(RenderContext context)
	{
		switch (_glyph)
		{
		case DrawMonthCalendarGlyph.DropDownButton:
			context.Renderer.RenderGlyph.DrawInputControlDropDownGlyph(context, ClientRectangle, base.CurrentPalette.PaletteContent, State);
			break;
		case DrawMonthCalendarGlyph.UpButton:
			context.Renderer.RenderGlyph.DrawInputControlNumericUpGlyph(context, ClientRectangle, base.CurrentPalette.PaletteContent, State);
			break;
		case DrawMonthCalendarGlyph.DownButton:
			context.Renderer.RenderGlyph.DrawInputControlNumericDownGlyph(context, ClientRectangle, base.CurrentPalette.PaletteContent, State);
			break;
		}
	}

	protected void OnButtonClick(object sender, MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
	}

	protected void OnButtonMouseSelect(object sender, MouseEventArgs e)
	{
		if (this.MouseSelect != null)
		{
			this.MouseSelect(this, e);
		}
	}
}
