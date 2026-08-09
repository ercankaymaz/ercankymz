#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteInputControlTripleStates : Storage, IPaletteTriple
{
	private PaletteBorder _border;

	private PaletteInputControlBackStates _back;

	private PaletteInputControlContentStates _content;

	[Browsable(false)]
	public override bool IsDefault => Back.IsDefault && Border.IsDefault && Content.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlBackStates Back => _back;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteBack PaletteBack => Back;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBorder Border => _border;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteBorder PaletteBorder => Border;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining content appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlContentStates Content => _content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteContent PaletteContent => Content;

	public PaletteInputControlTripleStates(IPaletteTriple inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		NeedPaint = needPaint;
		_back = new PaletteInputControlBackStates(inherit.PaletteBack, needPaint);
		_border = new PaletteBorder(inherit.PaletteBorder, needPaint);
		_content = new PaletteInputControlContentStates(inherit.PaletteContent, needPaint);
	}

	public void SetInherit(IPaletteTriple inherit)
	{
		_back.SetInherit(inherit.PaletteBack);
		_border.SetInherit(inherit.PaletteBorder);
		_content.SetInherit(inherit.PaletteContent);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_back.PopulateFromBase(state);
		_border.PopulateFromBase(state);
		_content.PopulateFromBase(state);
	}

	private bool ShouldSerializeBack()
	{
		return !_back.IsDefault;
	}

	private bool ShouldSerializeBorder()
	{
		return !_border.IsDefault;
	}

	private bool ShouldSerializeContent()
	{
		return !_content.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
