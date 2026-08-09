using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteSplitContainerRedirect : PaletteDoubleRedirect
{
	private PaletteSeparatorPaddingRedirect _separator;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && Separator.IsDefault;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new PaletteBorder Border => base.Border;

	[Category("Visuals")]
	[Description("Overrides for defining separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPaddingRedirect Separator => _separator;

	public PaletteSplitContainerRedirect(PaletteRedirect redirect, PaletteBackStyle backContainerStyle, PaletteBorderStyle borderContainerStyle, PaletteBackStyle backSeparatorStyle, PaletteBorderStyle borderSeparatorStyle, NeedPaintHandler needPaint)
		: base(redirect, backContainerStyle, borderContainerStyle, needPaint)
	{
		_separator = new PaletteSeparatorPaddingRedirect(redirect, backSeparatorStyle, borderSeparatorStyle, needPaint);
	}

	private bool ShouldSerializeSeparator()
	{
		return !_separator.IsDefault;
	}
}
