using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuLinkLabel), "ToolboxBitmaps.KryptonLinkLabel.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Text")]
[DefaultEvent("Click")]
public class KryptonContextMenuLinkLabel : KryptonContextMenuItemBase
{
	private bool _autoClose;

	private string _text;

	private string _extraText;

	private Image _image;

	private Color _imageTransparentColor;

	private PaletteContent _stateNormal;

	private PaletteContent _stateVisited;

	private PaletteContent _stateNotVisited;

	private PaletteContent _statePressed;

	private PaletteContent _stateFocus;

	private PaletteContentInheritRedirect _stateNormalRedirect;

	private PaletteContentInheritRedirect _stateVisitedRedirect;

	private PaletteContentInheritRedirect _stateNotVisitedRedirect;

	private PaletteContentInheritRedirect _statePressedRedirect;

	private PaletteContentInheritRedirect _stateFocusRedirect;

	private PaletteContentInheritOverride _overrideVisited;

	private PaletteContentInheritOverride _overrideNotVisited;

	private PaletteContentInheritOverride _overrideFocusNotVisited;

	private PaletteContentInheritOverride _overridePressed;

	private PaletteContentInheritOverride _overridePressedFocus;

	private LinkLabelBehaviorInherit _inheritBehavior;

	private KryptonCommand _command;

	private LabelStyle _style;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Link label style.")]
	[DefaultValue(typeof(LabelStyle), "NormalControl")]
	public LabelStyle LabelStyle
	{
		get
		{
			return _style;
		}
		set
		{
			if (_style != value)
			{
				_style = value;
				SetLinkLabelStyle(_style);
				OnPropertyChanged(new PropertyChangedEventArgs("LabelStyle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Determines the underline behavior of the link label.")]
	[DefaultValue(typeof(KryptonLinkBehavior), "Always Underline")]
	public KryptonLinkBehavior LinkBehavior
	{
		get
		{
			return _inheritBehavior.LinkBehavior;
		}
		set
		{
			if (_inheritBehavior.LinkBehavior != value)
			{
				_inheritBehavior.LinkBehavior = value;
				OnPropertyChanged(new PropertyChangedEventArgs("LinkBehavior"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Indicates if the hyperlink has been visited already.")]
	[DefaultValue(false)]
	public bool LinkVisited
	{
		get
		{
			return _overrideVisited.Apply;
		}
		set
		{
			if (_overrideVisited.Apply != value)
			{
				_overrideVisited.Apply = value;
				_overrideNotVisited.Apply = !value;
				OnPropertyChanged(new PropertyChangedEventArgs("LinkVisited"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates if clicking the link label automatically closes the context menu.")]
	[DefaultValue(true)]
	public bool AutoClose
	{
		get
		{
			return _autoClose;
		}
		set
		{
			if (_autoClose != value)
			{
				_autoClose = value;
				OnPropertyChanged(new PropertyChangedEventArgs("AutoClose"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Main link label text.")]
	[DefaultValue("LinkLabel")]
	[Localizable(true)]
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
	[Description("Link label extra text.")]
	[DefaultValue(null)]
	[Localizable(true)]
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
	[Description("Link label image.")]
	[DefaultValue(null)]
	[Localizable(true)]
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
	[Description("Link label image color to make transparent.")]
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
	[Description("Overrides for defining link label normal instance specific appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed link label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverridePressed => _statePressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining link label appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideFocus => _stateFocus;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for modifying normal state when link label has been visited.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideVisited => _stateVisited;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for modifying normal state when link label has not been visited.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideNotVisited => _stateNotVisited;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Command associated with the menu check box.")]
	[DefaultValue(null)]
	public virtual KryptonCommand KryptonCommand
	{
		get
		{
			return _command;
		}
		set
		{
			if (_command != value)
			{
				_command = value;
				OnPropertyChanged(new PropertyChangedEventArgs("KryptonCommand"));
			}
		}
	}

	internal LinkLabelBehaviorInherit LinkBehaviorNormal => _inheritBehavior;

	internal PaletteContentInheritOverride OverrideFocusNotVisited => _overrideFocusNotVisited;

	internal PaletteContentInheritOverride OverridePressedFocus => _overridePressedFocus;

	[Category("Action")]
	[Description("Occurs when the link label item is clicked.")]
	public event EventHandler Click;

	public KryptonContextMenuLinkLabel()
		: this("LinkLabel")
	{
	}

	public KryptonContextMenuLinkLabel(string initialText)
	{
		_text = initialText;
		_extraText = string.Empty;
		_image = null;
		_imageTransparentColor = Color.Empty;
		_style = LabelStyle.NormalControl;
		_autoClose = true;
		_stateNormalRedirect = new PaletteContentInheritRedirect(PaletteContentStyle.LabelNormalControl);
		_stateVisitedRedirect = new PaletteContentInheritRedirect(PaletteContentStyle.LabelNormalControl);
		_stateNotVisitedRedirect = new PaletteContentInheritRedirect(PaletteContentStyle.LabelNormalControl);
		_statePressedRedirect = new PaletteContentInheritRedirect(PaletteContentStyle.LabelNormalControl);
		_stateFocusRedirect = new PaletteContentInheritRedirect(PaletteContentStyle.LabelNormalControl);
		_stateNormal = new PaletteContent(_stateNormalRedirect);
		_stateVisited = new PaletteContent(_stateVisitedRedirect);
		_stateNotVisited = new PaletteContent(_stateNotVisitedRedirect);
		_stateFocus = new PaletteContent(_stateFocusRedirect);
		_statePressed = new PaletteContent(_statePressedRedirect);
		_inheritBehavior = new LinkLabelBehaviorInherit(_stateNormal, KryptonLinkBehavior.AlwaysUnderline);
		_overrideVisited = new PaletteContentInheritOverride(_stateVisited, _inheritBehavior, PaletteState.LinkVisitedOverride, apply: false);
		_overrideNotVisited = new PaletteContentInheritOverride(_stateNotVisited, _overrideVisited, PaletteState.LinkNotVisitedOverride, apply: true);
		_overrideFocusNotVisited = new PaletteContentInheritOverride(_stateFocus, _overrideNotVisited, PaletteState.FocusOverride, apply: false);
		_overridePressed = new PaletteContentInheritOverride(_statePressed, _inheritBehavior, PaletteState.LinkPressedOverride, apply: true);
		_overridePressedFocus = new PaletteContentInheritOverride(_stateFocus, _overridePressed, PaletteState.FocusOverride, apply: false);
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
		return new ViewDrawMenuLinkLabel(provider, this);
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

	private bool ShouldSerializeOverridePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	private bool ShouldSerializeOverrideVisited()
	{
		return !_stateVisited.IsDefault;
	}

	private bool ShouldSerializeOverrideNotVisited()
	{
		return !_stateNotVisited.IsDefault;
	}

	public void PerformClick()
	{
		OnClick(EventArgs.Empty);
	}

	protected virtual void OnClick(EventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
		if (KryptonCommand != null)
		{
			KryptonCommand.PerformExecute();
		}
	}

	internal void SetPaletteRedirect(PaletteRedirect redirector)
	{
		_stateNormalRedirect.SetRedirector(redirector);
		_stateVisitedRedirect.SetRedirector(redirector);
		_stateNotVisitedRedirect.SetRedirector(redirector);
		_statePressedRedirect.SetRedirector(redirector);
		_stateFocusRedirect.SetRedirector(redirector);
	}

	private void SetLinkLabelStyle(LabelStyle style)
	{
		PaletteContentStyle style2 = CommonHelper.ContentStyleFromLabelStyle(style);
		_stateNormalRedirect.Style = style2;
		_stateVisitedRedirect.Style = style2;
		_stateNotVisitedRedirect.Style = style2;
		_statePressedRedirect.Style = style2;
		_stateFocusRedirect.Style = style2;
	}
}
