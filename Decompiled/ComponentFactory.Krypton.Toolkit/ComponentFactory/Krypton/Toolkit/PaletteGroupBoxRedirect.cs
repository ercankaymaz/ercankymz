#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteGroupBoxRedirect : PaletteDoubleRedirect
{
	private PaletteContent _content;

	private PaletteContentInheritRedirect _contentInherit;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _content.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining content appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent Content => _content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPaletteContent PaletteContent => Content;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteContentStyle ContentStyle
	{
		get
		{
			return _contentInherit.Style;
		}
		set
		{
			_contentInherit.Style = value;
		}
	}

	public PaletteGroupBoxRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
		: this(redirect, redirect, needPaint)
	{
	}

	public PaletteGroupBoxRedirect(PaletteRedirect redirectDouble, PaletteRedirect redirectContent, NeedPaintHandler needPaint)
		: base(redirectDouble, PaletteBackStyle.ControlGroupBox, PaletteBorderStyle.ControlGroupBox, needPaint)
	{
		Debug.Assert(redirectDouble != null);
		Debug.Assert(redirectContent != null);
		_contentInherit = new PaletteContentInheritRedirect(redirectContent, PaletteContentStyle.LabelGroupBoxCaption);
		_content = new PaletteContent(_contentInherit, needPaint);
	}

	private bool ShouldSerializeContent()
	{
		return !_content.IsDefault;
	}
}
