#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTreeNodeTriple : Storage
{
	private PaletteTriple _paletteNode;

	[Browsable(false)]
	public override bool IsDefault => _paletteNode.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining node appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteTriple Node => _paletteNode;

	public PaletteTreeNodeTriple(PaletteTripleRedirect inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		NeedPaint = needPaint;
		_paletteNode = new PaletteTriple(inherit, needPaint);
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		_paletteNode.PopulateFromBase(state);
	}

	public virtual void SetInherit(PaletteTripleRedirect inherit)
	{
		_paletteNode.SetInherit(inherit);
	}

	private bool ShouldSerializeItem()
	{
		return !_paletteNode.IsDefault;
	}
}
