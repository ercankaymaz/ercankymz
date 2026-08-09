using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDouble : Storage, IPaletteDouble
{
	private PaletteBack _back;

	private PaletteBorder _border;

	[Browsable(false)]
	public override bool IsDefault => Back.IsDefault && Border.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteBack Back => _back;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual IPaletteBack PaletteBack => Back;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteBorder Border => _border;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual IPaletteBorder PaletteBorder => Border;

	public PaletteDouble(IPaletteDouble inherit)
		: this(inherit, null)
	{
	}

	public PaletteDouble(IPaletteDouble inherit, NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_back = new PaletteBack(inherit.PaletteBack, needPaint);
		_border = new PaletteBorder(inherit.PaletteBorder, needPaint);
	}

	public PaletteDouble(IPaletteDouble inherit, PaletteBack back, PaletteBorder border, NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_back = back;
		_border = border;
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		_back.PopulateFromBase(state);
		_border.PopulateFromBase(state);
	}

	public void SetInherit(IPaletteDouble inherit)
	{
		_back.SetInherit(inherit.PaletteBack);
		_border.SetInherit(inherit.PaletteBorder);
	}

	private bool ShouldSerializeBack()
	{
		return !_back.IsDefault;
	}

	private bool ShouldSerializeBorder()
	{
		return !_border.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
