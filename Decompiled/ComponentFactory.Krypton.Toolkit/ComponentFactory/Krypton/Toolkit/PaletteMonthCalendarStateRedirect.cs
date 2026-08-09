using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteMonthCalendarStateRedirect : Storage
{
	private PaletteTripleRedirect _paletteDay;

	[Browsable(false)]
	public override bool IsDefault => _paletteDay.IsDefault;

	internal ButtonStyle DayStyle
	{
		set
		{
			_paletteDay.SetStyles(value);
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining day appearance entries.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Day => _paletteDay;

	public PaletteMonthCalendarStateRedirect()
		: this(null, null)
	{
	}

	public PaletteMonthCalendarStateRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_paletteDay = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay, needPaint);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_paletteDay.SetRedirector(redirect);
	}

	private bool ShouldSerializeContent()
	{
		return !_paletteDay.IsDefault;
	}
}
