using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTreeState : PaletteDouble
{
	private PaletteTriple _nodeTriple;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _nodeTriple.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining node appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple Node => _nodeTriple;

	public PaletteTreeState(PaletteTreeStateRedirect inherit, PaletteBack back, PaletteBorder border, NeedPaintHandler needPaint)
		: base(inherit, back, border, needPaint)
	{
		_nodeTriple = new PaletteTriple(inherit.Node, needPaint);
	}

	public override void PopulateFromBase(PaletteState state)
	{
		base.PopulateFromBase(state);
		_nodeTriple.PopulateFromBase(state);
	}

	private bool ShouldSerializeItem()
	{
		return !_nodeTriple.IsDefault;
	}
}
