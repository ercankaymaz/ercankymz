#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawDateTimeButton : ViewDrawButton
{
	public enum DrawDateTimeGlyph
	{
		DropDownButton,
		UpButton,
		DownButton
	}

	private DrawDateTimeGlyph _glyph;

	private KryptonDateTimePicker _dateTimePicker;

	private ButtonController _controller;

	public event EventHandler Click;

	public event MouseEventHandler MouseSelect;

	public ViewDrawDateTimeButton(KryptonDateTimePicker dateTimePicker, IPaletteTriple paletteState, IPaletteMetric paletteMetric, IContentValues buttonValues, DrawDateTimeGlyph glyph, NeedPaintHandler needPaintHandler, bool repeat)
		: base(paletteState, paletteState, paletteState, paletteState, paletteMetric, buttonValues, VisualOrientation.Top, useMnemonic: false)
	{
		_dateTimePicker = dateTimePicker;
		_glyph = glyph;
		_controller = new ButtonController(this, needPaintHandler);
		_controller.BecomesFixed = !repeat;
		_controller.Click += OnButtonClick;
		_controller.MouseSelect += OnButtonMouseSelect;
		_controller.Repeat = repeat;
		_controller.ClickOnDown = true;
		MouseController = _controller;
	}

	public override string ToString()
	{
		return "ViewDrawDateTimeButton:" + base.Id;
	}

	public void RemoveFixed()
	{
		_controller.RemoveFixed();
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
		case DrawDateTimeGlyph.DropDownButton:
			context.DisplayRectangle = new Rectangle(displayRectangle.X, displayRectangle.Y + 1, displayRectangle.Width, displayRectangle.Height - 2);
			break;
		case DrawDateTimeGlyph.UpButton:
			context.DisplayRectangle = new Rectangle(displayRectangle.X, displayRectangle.Y + 1, displayRectangle.Width, displayRectangle.Height - 1);
			break;
		case DrawDateTimeGlyph.DownButton:
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
		case DrawDateTimeGlyph.DropDownButton:
			context.Renderer.RenderGlyph.DrawInputControlDropDownGlyph(context, ClientRectangle, base.CurrentPalette.PaletteContent, State);
			break;
		case DrawDateTimeGlyph.UpButton:
			context.Renderer.RenderGlyph.DrawInputControlNumericUpGlyph(context, ClientRectangle, base.CurrentPalette.PaletteContent, State);
			break;
		case DrawDateTimeGlyph.DownButton:
			context.Renderer.RenderGlyph.DrawInputControlNumericDownGlyph(context, ClientRectangle, base.CurrentPalette.PaletteContent, State);
			break;
		}
	}

	protected override void CheckPaletteState(ViewContext context)
	{
		PaletteState elementState = ElementState;
		if (_dateTimePicker.IsDropped)
		{
			elementState = PaletteState.Pressed;
		}
		else if (ElementState == PaletteState.Normal || ElementState == PaletteState.CheckedNormal)
		{
			elementState = ((!_dateTimePicker.IsActive && (!_dateTimePicker.IsFixedActive || _dateTimePicker.InputControlStyle != InputControlStyle.Standalone)) ? PaletteState.Normal : PaletteState.CheckedNormal);
		}
		ElementState = elementState;
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			current.ElementState = elementState;
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
