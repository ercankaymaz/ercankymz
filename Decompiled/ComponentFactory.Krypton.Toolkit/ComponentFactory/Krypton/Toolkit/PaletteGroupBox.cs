using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteGroupBox : PaletteDouble
{
	private PaletteContent _content;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining content appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent Content => _content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteContent PaletteContent => Content;

	public PaletteGroupBox(PaletteGroupBoxRedirect inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
		_content = new PaletteContent(inherit.PaletteContent, needPaint);
	}

	private bool ShouldSerializeContent()
	{
		return !_content.IsDefault;
	}
}
