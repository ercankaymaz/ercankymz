#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContextMenuRedirect : Storage
{
	private PaletteDoubleRedirect _paletteControlInner;

	private PaletteDoubleRedirect _paletteControlOuter;

	private PaletteTripleRedirect _paletteHeading;

	private PaletteDoubleMetricRedirect _paletteItemHighlight;

	private PaletteTripleJustImageRedirect _paletteItemImage;

	private PaletteDoubleRedirect _paletteItemImageColumn;

	private PaletteContentInheritRedirect _paletteItemShortcutTextRedirect;

	private PaletteContentJustShortText _paletteItemShortcutText;

	private PaletteDoubleRedirect _paletteItemSplit;

	private PaletteContentInheritRedirect _paletteItemTextAlternateRedirect;

	private PaletteContentJustText _paletteItemTextAlternate;

	private PaletteContentInheritRedirect _paletteItemTextStandardRedirect;

	private PaletteContentJustText _paletteItemTextStandard;

	private PaletteDoubleRedirect _paletteSeparator;

	[Browsable(false)]
	public override bool IsDefault => _paletteControlInner.IsDefault && _paletteControlOuter.IsDefault && _paletteHeading.IsDefault && _paletteItemHighlight.IsDefault && _paletteItemImage.IsDefault && _paletteItemImageColumn.IsDefault && _paletteItemShortcutText.IsDefault && _paletteItemSplit.IsDefault && _paletteItemTextAlternate.IsDefault && _paletteItemTextStandard.IsDefault && _paletteSeparator.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining inner control window appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect ControlInner => _paletteControlInner;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining outer control window appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect ControlOuter => _paletteControlOuter;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining header entry appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Heading => _paletteHeading;

	[Category("Visuals")]
	[Description("Overrides for defining item highlight appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleMetricRedirect ItemHighlight => _paletteItemHighlight;

	[Category("Visuals")]
	[Description("Overrides for defining item image appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleJustImageRedirect ItemImage => _paletteItemImage;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item image column appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect ItemImageColumn => _paletteItemImageColumn;

	[Category("Visuals")]
	[Description("Overrides for defining item shortcut text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContentJustShortText ItemShortcutText => _paletteItemShortcutText;

	[Category("Visuals")]
	[Description("Overrides for defining item split appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect ItemSplit => _paletteItemSplit;

	[Category("Visuals")]
	[Description("Overrides for defining alternate item text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContentJustText ItemTextAlternate => _paletteItemTextAlternate;

	[Category("Visuals")]
	[Description("Overrides for defining standard item text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContentJustText ItemTextStandard => _paletteItemTextStandard;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining separator items appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect Separator => _paletteSeparator;

	internal PaletteContentInheritRedirect ItemShortcutTextRedirect => _paletteItemShortcutTextRedirect;

	internal PaletteContentInheritRedirect ItemTextStandardRedirect => _paletteItemTextStandardRedirect;

	internal PaletteContentInheritRedirect ItemTextAlternateRedirect => _paletteItemTextAlternateRedirect;

	public PaletteContextMenuRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_paletteControlInner = new PaletteDoubleRedirect(redirect, PaletteBackStyle.ContextMenuInner, PaletteBorderStyle.ContextMenuInner, needPaint);
		_paletteControlOuter = new PaletteDoubleRedirect(redirect, PaletteBackStyle.ContextMenuOuter, PaletteBorderStyle.ContextMenuOuter, needPaint);
		_paletteHeading = new PaletteTripleRedirect(redirect, PaletteBackStyle.ContextMenuHeading, PaletteBorderStyle.ContextMenuHeading, PaletteContentStyle.ContextMenuHeading, needPaint);
		_paletteItemHighlight = new PaletteDoubleMetricRedirect(redirect, PaletteBackStyle.ContextMenuItemHighlight, PaletteBorderStyle.ContextMenuItemHighlight, needPaint);
		_paletteItemImage = new PaletteTripleJustImageRedirect(redirect, PaletteBackStyle.ContextMenuItemImage, PaletteBorderStyle.ContextMenuItemImage, PaletteContentStyle.ContextMenuItemImage, needPaint);
		_paletteItemImageColumn = new PaletteDoubleRedirect(redirect, PaletteBackStyle.ContextMenuItemImageColumn, PaletteBorderStyle.ContextMenuItemImageColumn, needPaint);
		_paletteItemShortcutTextRedirect = new PaletteContentInheritRedirect(redirect, PaletteContentStyle.ContextMenuItemShortcutText);
		_paletteItemShortcutText = new PaletteContentJustShortText(_paletteItemShortcutTextRedirect, needPaint);
		_paletteItemSplit = new PaletteDoubleRedirect(redirect, PaletteBackStyle.ContextMenuItemSplit, PaletteBorderStyle.ContextMenuItemSplit, needPaint);
		_paletteItemTextAlternateRedirect = new PaletteContentInheritRedirect(redirect, PaletteContentStyle.ContextMenuItemTextAlternate);
		_paletteItemTextAlternate = new PaletteContentJustText(_paletteItemTextAlternateRedirect, needPaint);
		_paletteItemTextStandardRedirect = new PaletteContentInheritRedirect(redirect, PaletteContentStyle.ContextMenuItemTextStandard);
		_paletteItemTextStandard = new PaletteContentJustText(_paletteItemTextStandardRedirect, needPaint);
		_paletteSeparator = new PaletteDoubleRedirect(redirect, PaletteBackStyle.ContextMenuSeparator, PaletteBorderStyle.ContextMenuSeparator, needPaint);
	}

	public void PopulateFromBase(KryptonPaletteCommon common, PaletteState state)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuInner;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuInner;
		_paletteControlInner.PopulateFromBase(state);
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuOuter;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuOuter;
		_paletteControlOuter.PopulateFromBase(state);
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuHeading;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuHeading;
		common.StateCommon.ContentStyle = PaletteContentStyle.ContextMenuHeading;
		_paletteHeading.PopulateFromBase(state);
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuItemImageColumn;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuItemImageColumn;
		_paletteItemImageColumn.PopulateFromBase(state);
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuSeparator;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuSeparator;
		_paletteSeparator.PopulateFromBase(state);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_paletteControlInner.SetRedirector(redirect);
		_paletteControlOuter.SetRedirector(redirect);
		_paletteHeading.SetRedirector(redirect);
		_paletteItemHighlight.SetRedirector(redirect);
		_paletteItemImage.SetRedirector(redirect);
		_paletteItemImageColumn.SetRedirector(redirect);
		_paletteItemShortcutTextRedirect.SetRedirector(redirect);
		_paletteItemSplit.SetRedirector(redirect);
		_paletteItemTextAlternateRedirect.SetRedirector(redirect);
		_paletteItemTextStandardRedirect.SetRedirector(redirect);
		_paletteSeparator.SetRedirector(redirect);
	}

	private bool ShouldSerializeControlInner()
	{
		return !_paletteControlInner.IsDefault;
	}

	private bool ShouldSerializeControlOuter()
	{
		return !_paletteControlOuter.IsDefault;
	}

	private bool ShouldSerializeHeading()
	{
		return !_paletteHeading.IsDefault;
	}

	private bool ShouldSerializeItemHighlight()
	{
		return !_paletteItemHighlight.IsDefault;
	}

	private bool ShouldSerializeItemImage()
	{
		return !_paletteItemImage.IsDefault;
	}

	private bool ShouldSerializeItemImageColumn()
	{
		return !_paletteItemImageColumn.IsDefault;
	}

	private bool ShouldSerializeItemShortcutText()
	{
		return !_paletteItemShortcutText.IsDefault;
	}

	private bool ShouldSerializeItemItemSplit()
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

	private bool ShouldSerializeSeparator()
	{
		return !_paletteSeparator.IsDefault;
	}
}
