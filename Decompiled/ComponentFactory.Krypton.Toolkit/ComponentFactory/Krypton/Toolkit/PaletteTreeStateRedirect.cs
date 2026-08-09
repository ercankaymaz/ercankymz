#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTreeStateRedirect : PaletteDoubleRedirect
{
	private PaletteRedirect _redirect;

	private PaletteTripleRedirect _nodeRedirect;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _nodeRedirect.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining node appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Node => _nodeRedirect;

	public PaletteTreeStateRedirect(PaletteRedirect redirect, PaletteBack back, PaletteBackInheritRedirect backInherit, PaletteBorder border, PaletteBorderInheritRedirect borderInherit, NeedPaintHandler needPaint)
		: base(redirect, back, backInherit, border, borderInherit, needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_nodeRedirect = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonListItem, PaletteBorderStyle.ButtonListItem, PaletteContentStyle.ButtonListItem, needPaint);
	}

	private bool ShouldSerializeItem()
	{
		return !_nodeRedirect.IsDefault;
	}
}
