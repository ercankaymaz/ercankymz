#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteListItemTripleRedirect : Storage
{
	private PaletteTripleRedirect _itemRedirect;

	[Browsable(false)]
	public override bool IsDefault => _itemRedirect.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Item => _itemRedirect;

	public PaletteListItemTripleRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_itemRedirect = new PaletteTripleRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
	}

	private bool ShouldSerializeItem()
	{
		return !_itemRedirect.IsDefault;
	}
}
