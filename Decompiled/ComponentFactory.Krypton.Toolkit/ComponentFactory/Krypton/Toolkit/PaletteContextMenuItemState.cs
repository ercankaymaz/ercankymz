using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContextMenuItemState : Storage
{
	private PaletteDoubleMetric _paletteItemHighlight;

	private PaletteTripleJustImage _paletteItemImage;

	private PaletteContentJustShortText _paletteItemShortcutText;

	private PaletteDouble _paletteItemSplit;

	private PaletteContentJustText _paletteItemTextStandard;

	private PaletteContentJustText _paletteItemTextAlternate;

	[Browsable(false)]
	public override bool IsDefault => _paletteItemHighlight.IsDefault && _paletteItemImage.IsDefault && _paletteItemShortcutText.IsDefault && _paletteItemSplit.IsDefault && _paletteItemTextStandard.IsDefault && _paletteItemTextAlternate.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item highlight appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleMetric ItemHighlight => _paletteItemHighlight;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item image appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleJustImage ItemImage => _paletteItemImage;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item shortcut text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContentJustShortText ItemShortcutText => _paletteItemShortcutText;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item split appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble ItemSplit => _paletteItemSplit;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining alternate item text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContentJustText ItemTextAlternate => _paletteItemTextAlternate;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining standard item text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContentJustText ItemTextStandard => _paletteItemTextStandard;

	public PaletteContextMenuItemState(PaletteContextMenuRedirect redirect)
		: this(redirect.ItemHighlight, redirect.ItemImage, redirect.ItemShortcutTextRedirect, redirect.ItemSplit, redirect.ItemTextStandardRedirect, redirect.ItemTextAlternateRedirect)
	{
	}

	public PaletteContextMenuItemState(PaletteContextMenuItemStateRedirect redirect)
		: this(redirect.ItemHighlight, redirect.ItemImage, redirect.ItemShortcutText, redirect.ItemSplit, redirect.ItemTextStandard, redirect.ItemTextAlternate)
	{
	}

	public PaletteContextMenuItemState(PaletteDoubleMetricRedirect redirectItemHighlight, PaletteTripleJustImageRedirect redirectItemImage, PaletteContentInheritRedirect redirectItemShortcutText, PaletteDoubleRedirect redirectItemSplit, PaletteContentInheritRedirect redirectItemTextStandard, PaletteContentInheritRedirect redirectItemTextAlternate)
	{
		_paletteItemHighlight = new PaletteDoubleMetric(redirectItemHighlight);
		_paletteItemImage = new PaletteTripleJustImage(redirectItemImage);
		_paletteItemShortcutText = new PaletteContentJustShortText(redirectItemShortcutText);
		_paletteItemSplit = new PaletteDouble(redirectItemSplit);
		_paletteItemTextStandard = new PaletteContentJustText(redirectItemTextStandard);
		_paletteItemTextAlternate = new PaletteContentJustText(redirectItemTextAlternate);
	}

	public void PopulateFromBase(KryptonPaletteCommon common, PaletteState state)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuItemHighlight;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuItemHighlight;
		_paletteItemHighlight.PopulateFromBase(state);
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuItemImage;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuItemImage;
		common.StateCommon.ContentStyle = PaletteContentStyle.ContextMenuItemImage;
		_paletteItemImage.PopulateFromBase(state);
		common.StateCommon.ContentStyle = PaletteContentStyle.ContextMenuItemShortcutText;
		_paletteItemShortcutText.PopulateFromBase(state);
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuSeparator;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuSeparator;
		_paletteItemSplit.PopulateFromBase(state);
		common.StateCommon.ContentStyle = PaletteContentStyle.ContextMenuItemTextStandard;
		_paletteItemTextStandard.PopulateFromBase(state);
		common.StateCommon.ContentStyle = PaletteContentStyle.ContextMenuItemTextAlternate;
		_paletteItemTextAlternate.PopulateFromBase(state);
	}

	private bool ShouldSerializeItemHighlight()
	{
		return !_paletteItemHighlight.IsDefault;
	}

	private bool ShouldSerializeItemImage()
	{
		return !_paletteItemImage.IsDefault;
	}

	private bool ShouldSerializeItemShortcutText()
	{
		return !_paletteItemShortcutText.IsDefault;
	}

	private bool ShouldSerializeItemSplit()
	{
		return !_paletteItemSplit.IsDefault;
	}

	private bool ShouldSerializeItemTextAlternate()
	{
		return !_paletteItemTextAlternate.IsDefault;
	}

	private bool ShouldSerializeItemTextStandard()
	{
		return !_paletteItemTextStandard.IsDefault;
	}
}
