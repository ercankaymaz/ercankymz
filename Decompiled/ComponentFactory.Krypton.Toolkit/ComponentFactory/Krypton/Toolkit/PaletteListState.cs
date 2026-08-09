using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteListState : PaletteDouble
{
	private PaletteTriple _itemTriple;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _itemTriple.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple Item => _itemTriple;

	public PaletteListState(PaletteListStateRedirect inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
		_itemTriple = new PaletteTriple(inherit.Item, needPaint);
	}

	public override void PopulateFromBase(PaletteState state)
	{
		base.PopulateFromBase(state);
		_itemTriple.PopulateFromBase(state);
	}

	private bool ShouldSerializeItem()
	{
		return !_itemTriple.IsDefault;
	}
}
