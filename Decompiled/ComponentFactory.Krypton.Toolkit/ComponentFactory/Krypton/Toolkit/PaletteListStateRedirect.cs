#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteListStateRedirect : PaletteDoubleRedirect
{
	private PaletteRedirect _redirect;

	private PaletteTripleRedirect _itemRedirect;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _itemRedirect.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Item => _itemRedirect;

	public PaletteListStateRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, NeedPaintHandler needPaint)
		: base(redirect, backStyle, borderStyle, needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_itemRedirect = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonListItem, PaletteBorderStyle.ButtonListItem, PaletteContentStyle.ButtonListItem, needPaint);
	}

	private bool ShouldSerializeItem()
	{
		return !_itemRedirect.IsDefault;
	}
}
