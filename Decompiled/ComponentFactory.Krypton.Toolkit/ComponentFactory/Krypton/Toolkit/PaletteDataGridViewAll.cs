#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDataGridViewAll : PaletteDataGridViewCells
{
	private PaletteDouble _background;

	[Browsable(false)]
	public override bool IsDefault => Background.IsDefault && base.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining data grid view background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteBack Background => _background.Back;

	public PaletteDataGridViewAll(PaletteDataGridViewRedirect inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
		Debug.Assert(inherit != null);
		_background = new PaletteDouble(inherit.BackgroundDouble, needPaint);
	}

	public override void PopulateFromBase(KryptonPaletteCommon common, PaletteState state, GridStyle gridStyle)
	{
		base.PopulateFromBase(common, state, gridStyle);
		if (gridStyle == GridStyle.List)
		{
			common.StateCommon.BackStyle = PaletteBackStyle.GridBackgroundList;
		}
		else
		{
			common.StateCommon.BackStyle = PaletteBackStyle.GridBackgroundSheet;
		}
		_background.PopulateFromBase(state);
	}

	public override void SetInherit(PaletteDataGridViewRedirect inherit)
	{
		base.SetInherit(inherit);
		_background.SetInherit(inherit.BackgroundDouble);
	}

	private bool ShouldSerializeBackground()
	{
		return !_background.IsDefault;
	}
}
