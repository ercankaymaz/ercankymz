#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteListItemTriple : Storage
{
	private PaletteTriple _paletteItem;

	[Browsable(false)]
	public override bool IsDefault => _paletteItem.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteTriple Item => _paletteItem;

	public PaletteListItemTriple(PaletteTripleRedirect inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		NeedPaint = needPaint;
		_paletteItem = new PaletteTriple(inherit, needPaint);
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		_paletteItem.PopulateFromBase(state);
	}

	public virtual void SetInherit(PaletteTripleRedirect inherit)
	{
		_paletteItem.SetInherit(inherit);
	}

	private bool ShouldSerializeItem()
	{
		return !_paletteItem.IsDefault;
	}
}
