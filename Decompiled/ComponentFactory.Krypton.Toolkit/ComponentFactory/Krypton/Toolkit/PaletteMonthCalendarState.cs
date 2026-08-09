using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteMonthCalendarState : Storage
{
	private PaletteTriple _paletteDay;

	[Browsable(false)]
	public override bool IsDefault => _paletteDay.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining day appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple Day => _paletteDay;

	public PaletteMonthCalendarState(PaletteMonthCalendarRedirect redirect)
		: this(redirect, null)
	{
	}

	public PaletteMonthCalendarState(PaletteMonthCalendarRedirect redirect, NeedPaintHandler needPaint)
	{
		_paletteDay = new PaletteTriple(redirect.Day, needPaint);
	}

	private bool ShouldSerializeContent()
	{
		return !_paletteDay.IsDefault;
	}
}
