using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuHeading), "ToolboxBitmaps.KryptonContextMenuHeading.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Text")]
public class KryptonContextMenuHeading : KryptonContextMenuItemBase
{
	private string _text;

	private string _extraText;

	private Image _image;

	private Color _imageTransparentColor;

	private PaletteTripleRedirect _stateNormal;

	private PaletteRedirectTriple _redirectHeading;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Heading menu item text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	[DefaultValue("Heading")]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (_text != value)
			{
				_text = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Text"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Heading menu item extra text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	[DefaultValue(null)]
	public string ExtraText
	{
		get
		{
			return _extraText;
		}
		set
		{
			if (_extraText != value)
			{
				_extraText = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ExtraText"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Heading menu item image.")]
	[Localizable(true)]
	[DefaultValue(null)]
	public Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			if (_image != value)
			{
				_image = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Image"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Heading image color to make transparent.")]
	[Localizable(true)]
	public Color ImageTransparentColor
	{
		get
		{
			return _imageTransparentColor;
		}
		set
		{
			if (_imageTransparentColor != value)
			{
				_imageTransparentColor = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageTransparentColor"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining header instance specific appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect StateNormal => _stateNormal;

	public KryptonContextMenuHeading()
		: this("Heading")
	{
	}

	public KryptonContextMenuHeading(string initialText)
	{
		_text = initialText;
		_extraText = string.Empty;
		_image = null;
		_imageTransparentColor = Color.Empty;
		_redirectHeading = new PaletteRedirectTriple();
		_stateNormal = new PaletteTripleRedirect(_redirectHeading, PaletteBackStyle.ContextMenuHeading, PaletteBorderStyle.ContextMenuHeading, PaletteContentStyle.ContextMenuHeading);
	}

	public override string ToString()
	{
		return Text;
	}

	public override bool ProcessShortcut(Keys keyData)
	{
		return false;
	}

	public override ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		return new ViewDrawMenuHeading(this, provider.ProviderStateCommon.Heading);
	}

	private bool ShouldSerializeImageTransparentColor()
	{
		_ = _imageTransparentColor;
		return !_imageTransparentColor.Equals(Color.Empty);
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	internal void SetPaletteRedirect(PaletteTripleRedirect redirector)
	{
		_redirectHeading.SetRedirectStates(redirector, redirector);
	}
}
