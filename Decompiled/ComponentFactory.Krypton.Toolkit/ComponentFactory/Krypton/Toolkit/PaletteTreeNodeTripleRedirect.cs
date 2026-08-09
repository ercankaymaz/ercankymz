#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTreeNodeTripleRedirect : Storage
{
	private PaletteTripleRedirect _nodeRedirect;

	[Browsable(false)]
	public override bool IsDefault => _nodeRedirect.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining node appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Node => _nodeRedirect;

	public PaletteTreeNodeTripleRedirect(PaletteRedirect redirect, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_nodeRedirect = new PaletteTripleRedirect(redirect, backStyle, borderStyle, contentStyle, needPaint);
	}

	private bool ShouldSerializeItem()
	{
		return !_nodeRedirect.IsDefault;
	}
}
