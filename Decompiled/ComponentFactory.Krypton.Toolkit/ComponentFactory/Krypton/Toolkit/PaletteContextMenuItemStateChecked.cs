using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContextMenuItemStateChecked : Storage
{
	private PaletteTripleJustImage _paletteItemImage;

	[Browsable(false)]
	public override bool IsDefault => _paletteItemImage.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item image appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleJustImage ItemImage => _paletteItemImage;

	public PaletteContextMenuItemStateChecked(PaletteContextMenuRedirect redirect)
		: this(redirect.ItemImage)
	{
	}

	public PaletteContextMenuItemStateChecked(PaletteContextMenuItemStateRedirect redirect)
		: this(redirect.ItemImage)
	{
	}

	public PaletteContextMenuItemStateChecked(PaletteTripleJustImageRedirect redirectItemImage)
	{
		_paletteItemImage = new PaletteTripleJustImage(redirectItemImage);
	}

	public void PopulateFromBase(KryptonPaletteCommon common, PaletteState state)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.ContextMenuItemImage;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ContextMenuItemImage;
		common.StateCommon.ContentStyle = PaletteContentStyle.ContextMenuItemImage;
		_paletteItemImage.PopulateFromBase(state);
	}

	private bool ShouldSerializeItemImage()
	{
		return !_paletteItemImage.IsDefault;
	}
}
