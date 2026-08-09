using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContextMenuItemStateHighlight : Storage
{
	private PaletteDoubleMetric _paletteItemHighlight;

	private PaletteDouble _paletteItemSplit;

	[Browsable(false)]
	public override bool IsDefault => _paletteItemHighlight.IsDefault && _paletteItemSplit.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item highlight appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleMetric ItemHighlight => _paletteItemHighlight;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item split appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble ItemSplit => _paletteItemSplit;

	public PaletteContextMenuItemStateHighlight(PaletteContextMenuRedirect redirect)
		: this(redirect.ItemHighlight, redirect.ItemSplit)
	{
	}

	public PaletteContextMenuItemStateHighlight(PaletteContextMenuItemStateRedirect redirect)
		: this(redirect.ItemHighlight, redirect.ItemSplit)
	{
	}

	public PaletteContextMenuItemStateHighlight(PaletteDoubleMetricRedirect redirectItemHighlight, PaletteDoubleRedirect redirectItemSplit)
	{
		_paletteItemHighlight = new PaletteDoubleMetric(redirectItemHighlight);
		_paletteItemSplit = new PaletteDouble(redirectItemSplit);
	}

	public void PopulateFromBase(KryptonPaletteCommon common, PaletteState state)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuItemHighlight;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuItemHighlight;
		_paletteItemHighlight.PopulateFromBase(state);
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuSeparator;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuSeparator;
		_paletteItemSplit.PopulateFromBase(state);
	}

	private bool ShouldSerializeItemHighlight()
	{
		return !_paletteItemHighlight.IsDefault;
	}

	private bool ShouldSerializeItemSplit()
	{
		return !_paletteItemSplit.IsDefault;
	}
}
