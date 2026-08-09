using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteSplitContainer : PaletteDouble
{
	private PaletteSeparatorPadding _separator;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && Separator.IsDefault;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new PaletteBorder Border => base.Border;

	[Category("Visuals")]
	[Description("Overrides for defining separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteSeparatorPadding Separator => _separator;

	public PaletteSplitContainer(IPaletteDouble inheritSplitContainer, IPaletteDouble inheritSeparator, IPaletteMetric inheritMetric, NeedPaintHandler needPaint)
		: base(inheritSplitContainer, needPaint)
	{
		_separator = new PaletteSeparatorPadding(inheritSeparator, inheritMetric, needPaint);
	}

	private bool ShouldSerializeSeparator()
	{
		return !_separator.IsDefault;
	}
}
