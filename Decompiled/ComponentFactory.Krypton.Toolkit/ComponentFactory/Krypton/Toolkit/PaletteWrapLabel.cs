using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteWrapLabel : Storage
{
	private Font _font;

	private Color _textColor;

	private PaletteTextHint _hint;

	private KryptonWrapLabel _wrapLabel;

	[Browsable(false)]
	public override bool IsDefault => _font == null && _textColor == Color.Empty && _hint == PaletteTextHint.Inherit;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Font for drawing the label text.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Font Font
	{
		get
		{
			return _font;
		}
		set
		{
			_font = value;
			_wrapLabel.PerformLayout();
			_wrapLabel.Invalidate();
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color for the text.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color TextColor
	{
		get
		{
			return _textColor;
		}
		set
		{
			_textColor = value;
			_wrapLabel.Invalidate();
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Text rendering hint for the content text.")]
	[DefaultValue(typeof(PaletteTextHint), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteTextHint Hint
	{
		get
		{
			return _hint;
		}
		set
		{
			_hint = value;
			_wrapLabel.Invalidate();
		}
	}

	public PaletteWrapLabel(KryptonWrapLabel wrapLabel)
	{
		_wrapLabel = wrapLabel;
		_font = null;
		_textColor = Color.Empty;
		_hint = PaletteTextHint.Inherit;
	}
}
