using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteMonthCalendarDoubleState : PaletteDouble
{
	private PaletteTriple _paletteHeader;

	private PaletteTriple _paletteDay;

	private PaletteTriple _paletteDayOfWeek;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _paletteHeader.IsDefault && _paletteDay.IsDefault && _paletteDayOfWeek.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining month/year header appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple Header => _paletteHeader;

	[Category("Visuals")]
	[Description("Overrides for defining day appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple Day => _paletteDay;

	[Category("Visuals")]
	[Description("Overrides for defining day of week appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple DayOfWeek => _paletteDayOfWeek;

	public PaletteMonthCalendarDoubleState(PaletteMonthCalendarRedirect redirect)
		: this(redirect, null)
	{
	}

	public PaletteMonthCalendarDoubleState(PaletteMonthCalendarRedirect redirect, NeedPaintHandler needPaint)
		: base(redirect, needPaint)
	{
		_paletteHeader = new PaletteTriple(redirect.Header, needPaint);
		_paletteDay = new PaletteTriple(redirect.Day, needPaint);
		_paletteDayOfWeek = new PaletteTriple(redirect.DayOfWeek, needPaint);
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
