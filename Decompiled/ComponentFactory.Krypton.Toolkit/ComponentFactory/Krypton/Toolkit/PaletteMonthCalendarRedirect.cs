using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteMonthCalendarRedirect : PaletteDoubleMetricRedirect
{
	private PaletteTripleRedirect _paletteHeader;

	private PaletteTripleRedirect _paletteDayOfWeek;

	private PaletteTripleRedirect _paletteDay;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _paletteHeader.IsDefault && _paletteDayOfWeek.IsDefault && _paletteDay.IsDefault;

	internal ButtonStyle DayStyle
	{
		set
		{
			_paletteDay.SetStyles(value);
		}
	}

	internal ButtonStyle DayOfWeekStyle
	{
		set
		{
			_paletteDayOfWeek.SetStyles(value);
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining month/year header appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Header => _paletteHeader;

	[Category("Visuals")]
	[Description("Overrides for defining day appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Day => _paletteDay;

	[Category("Visuals")]
	[Description("Overrides for defining day of week appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect DayOfWeek => _paletteDayOfWeek;

	public PaletteMonthCalendarRedirect()
		: this(null, null)
	{
	}

	public PaletteMonthCalendarRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
		: base(redirect, PaletteBackStyle.ControlClient, PaletteBorderStyle.ControlClient)
	{
		_paletteHeader = new PaletteTripleRedirect(redirect, PaletteBackStyle.HeaderCalendar, PaletteBorderStyle.HeaderCalendar, PaletteContentStyle.HeaderCalendar, needPaint);
		_paletteDayOfWeek = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay, needPaint);
		_paletteDay = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay, needPaint);
	}

	public override void SetRedirector(PaletteRedirect redirect)
	{
		base.SetRedirector(redirect);
		_paletteHeader.SetRedirector(redirect);
		_paletteDayOfWeek.SetRedirector(redirect);
		_paletteDay.SetRedirector(redirect);
	}

	private bool ShouldSerializeHeader()
	{
		return !_paletteHeader.IsDefault;
	}

	private bool ShouldSerializeDay()
	{
		return !_paletteDay.IsDefault;
	}

	private bool ShouldSerializeDayOfWeek()
	{
		return !_paletteDayOfWeek.IsDefault;
	}
}
