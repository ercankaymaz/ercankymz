#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawToday : ViewDrawButton, IContentValues
{
	private IKryptonMonthCalendar _calendar;

	public event EventHandler Click;

	public ViewDrawToday(IKryptonMonthCalendar calendar, IPaletteTriple paletteDisabled, IPaletteTriple paletteNormal, IPaletteTriple paletteTracking, IPaletteTriple palettePressed, NeedPaintHandler needPaintHandler)
		: base(paletteDisabled, paletteNormal, paletteTracking, palettePressed, paletteNormal, paletteTracking, palettePressed, null, null, VisualOrientation.Top, useMnemonic: false)
	{
		_calendar = calendar;
		base.ButtonValues = this;
		ButtonController buttonController = new ButtonController(this, needPaintHandler);
		buttonController.Click += OnClick;
		MouseController = buttonController;
		SourceController = buttonController;
		KeyController = buttonController;
	}

	public override string ToString()
	{
		return "ViewDrawToday:" + base.Id;
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return KryptonManager.Strings.Today + " " + _calendar.TodayDate.ToString(_calendar.TodayFormat);
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	private void OnClick(object sender, MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, EventArgs.Empty);
		}
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		base.Layout(context);
	}
}
