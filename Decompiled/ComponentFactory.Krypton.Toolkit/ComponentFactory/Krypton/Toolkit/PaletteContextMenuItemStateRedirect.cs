namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContextMenuItemStateRedirect : Storage
{
	private PaletteRedirectDouble _itemHighlight;

	private PaletteRedirectTriple _itemImage;

	private PaletteRedirectContent _itemShortcutText;

	private PaletteRedirectDouble _itemSplit;

	private PaletteRedirectContent _itemStandard;

	private PaletteRedirectContent _itemAlternate;

	private PaletteDoubleMetricRedirect _redirectItemHighlight;

	private PaletteTripleJustImageRedirect _redirectItemImage;

	private PaletteContentInheritRedirect _redirectItemShortcutText;

	private PaletteDoubleRedirect _redirectItemSplit;

	private PaletteContentInheritRedirect _redirectItemTextStandard;

	private PaletteContentInheritRedirect _redirectItemTextAlternate;

	public override bool IsDefault => true;

	public PaletteDoubleMetricRedirect ItemHighlight => _redirectItemHighlight;

	public PaletteTripleJustImageRedirect ItemImage => _redirectItemImage;

	public PaletteContentInheritRedirect ItemShortcutText => _redirectItemShortcutText;

	public PaletteDoubleRedirect ItemSplit => _redirectItemSplit;

	public PaletteContentInheritRedirect ItemTextAlternate => _redirectItemTextAlternate;

	public PaletteContentInheritRedirect ItemTextStandard => _redirectItemTextStandard;

	public PaletteContextMenuItemStateRedirect()
	{
		_itemHighlight = new PaletteRedirectDouble();
		_itemImage = new PaletteRedirectTriple();
		_itemShortcutText = new PaletteRedirectContent();
		_itemSplit = new PaletteRedirectDouble();
		_itemStandard = new PaletteRedirectContent();
		_itemAlternate = new PaletteRedirectContent();
		_redirectItemHighlight = new PaletteDoubleMetricRedirect(_itemHighlight, PaletteBackStyle.ContextMenuItemHighlight, PaletteBorderStyle.ContextMenuItemHighlight);
		_redirectItemImage = new PaletteTripleJustImageRedirect(_itemImage, PaletteBackStyle.ContextMenuItemImage, PaletteBorderStyle.ContextMenuItemImage, PaletteContentStyle.ContextMenuItemImage);
		_redirectItemShortcutText = new PaletteContentInheritRedirect(_itemShortcutText, PaletteContentStyle.ContextMenuItemShortcutText);
		_redirectItemSplit = new PaletteDoubleRedirect(_itemSplit, PaletteBackStyle.ContextMenuSeparator, PaletteBorderStyle.ContextMenuSeparator);
		_redirectItemTextStandard = new PaletteContentInheritRedirect(_itemStandard, PaletteContentStyle.ContextMenuItemTextStandard);
		_redirectItemTextAlternate = new PaletteContentInheritRedirect(_itemAlternate, PaletteContentStyle.ContextMenuItemTextAlternate);
	}

	public void SetRedirector(IContextMenuProvider provider)
	{
		_itemHighlight.Target = provider.ProviderStateCommon.ItemHighlight.GetRedirector();
		_itemImage.Target = provider.ProviderStateCommon.ItemImage.GetRedirector();
		_itemShortcutText.Target = provider.ProviderStateCommon.ItemShortcutTextRedirect.GetRedirector();
		_itemSplit.Target = provider.ProviderStateCommon.ItemSplit.GetRedirector();
		_itemStandard.Target = provider.ProviderStateCommon.ItemTextStandardRedirect.GetRedirector();
		_itemAlternate.Target = provider.ProviderStateCommon.ItemTextAlternateRedirect.GetRedirector();
		_itemHighlight.SetRedirectStates(provider.ProviderStateDisabled.ItemHighlight, provider.ProviderStateNormal.ItemHighlight);
		_itemImage.SetRedirectStates(provider.ProviderStateDisabled.ItemImage, provider.ProviderStateNormal.ItemImage);
		_itemShortcutText.SetRedirectStates(provider.ProviderStateDisabled.ItemShortcutText, provider.ProviderStateNormal.ItemShortcutText);
		_itemSplit.SetRedirectStates(provider.ProviderStateDisabled.ItemSplit, provider.ProviderStateNormal.ItemSplit, provider.ProviderStateHighlight.ItemSplit, provider.ProviderStateHighlight.ItemSplit);
		_itemStandard.SetRedirectStates(provider.ProviderStateDisabled.ItemTextStandard, provider.ProviderStateNormal.ItemTextStandard);
		_itemAlternate.SetRedirectStates(provider.ProviderStateDisabled.ItemTextAlternate, provider.ProviderStateNormal.ItemTextAlternate);
	}
}
