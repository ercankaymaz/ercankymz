using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonQATButton), "ToolboxBitmaps.KryptonRibbonQATButton.bmp")]
[DefaultEvent("Click")]
[DefaultProperty("Image")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public class KryptonRibbonQATButton : Component, IQuickAccessToolbarButton
{
	private static readonly Image _defaultImage = Resources.QATButtonDefault;

	private object _tag;

	private Image _image;

	private Image _toolTipImage;

	private Color _toolTipImageTransparentColor;

	private LabelStyle _toolTipStyle;

	private bool _visible;

	private bool _enabled;

	private string _text;

	private string _toolTipTitle;

	private string _toolTipBody;

	private Keys _shortcutKeys;

	private KryptonCommand _command;

	private KryptonRibbon _ribbon;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonRibbon Ribbon => _ribbon;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Values")]
	[Description("Application button image.")]
	[RefreshProperties(RefreshProperties.All)]
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
				if (value != null && (value.Width > 16 || value.Height > 16))
				{
					throw new ArgumentOutOfRangeException("Image must be 16x16 or smaller.");
				}
				_image = value;
				OnPropertyChanged("Image");
				if (Visible && _ribbon != null)
				{
					_ribbon.PerformNeedPaint(needLayout: false);
				}
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the ribbon quick access toolbar entry is visible or hidden.")]
	[DefaultValue(true)]
	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (value != _visible)
			{
				_visible = value;
				OnPropertyChanged("Visible");
				if (_ribbon != null)
				{
					_ribbon.PerformNeedPaint(needLayout: true);
					_ribbon.UpdateQAT();
				}
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the ribbon quick access toolbar entry is enabled.")]
	[DefaultValue(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (value != _enabled)
			{
				_enabled = value;
				OnPropertyChanged("Enabled");
				if (Visible && _ribbon != null)
				{
					_ribbon.PerformNeedPaint(needLayout: false);
				}
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("QAT button text.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("QAT Button")]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "QAT Button";
			}
			if (value != _text)
			{
				_text = value;
				OnPropertyChanged("Text");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to fire click event of the quick access toolbar button.")]
	public Keys ShortcutKeys
	{
		get
		{
			return _shortcutKeys;
		}
		set
		{
			_shortcutKeys = value;
		}
	}

	[Category("Appearance")]
	[Description("Tooltip style for the quick access toolbar button.")]
	[DefaultValue(typeof(LabelStyle), "ToolTip")]
	public LabelStyle ToolTipStyle
	{
		get
		{
			return _toolTipStyle;
		}
		set
		{
			_toolTipStyle = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Display image associated ToolTip.")]
	[DefaultValue(null)]
	[Localizable(true)]
	public Image ToolTipImage
	{
		get
		{
			return _toolTipImage;
		}
		set
		{
			_toolTipImage = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Color to draw as transparent in the ToolTipImage.")]
	[KryptonDefaultColor]
	[Localizable(true)]
	public Color ToolTipImageTransparentColor
	{
		get
		{
			return _toolTipImageTransparentColor;
		}
		set
		{
			_toolTipImageTransparentColor = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Title text for use in associated ToolTip.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	public string ToolTipTitle
	{
		get
		{
			return _toolTipTitle;
		}
		set
		{
			_toolTipTitle = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Body text for use in associated ToolTip.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	public string ToolTipBody
	{
		get
		{
			return _toolTipBody;
		}
		set
		{
			_toolTipBody = value;
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the quick access toolbar button.")]
	[DefaultValue(null)]
	public KryptonCommand KryptonCommand
	{
		get
		{
			return _command;
		}
		set
		{
			if (_command != value)
			{
				if (_command != null)
				{
					_command.PropertyChanged -= OnCommandPropertyChanged;
				}
				_command = value;
				OnPropertyChanged("KryptonCommand");
				if (_command != null)
				{
					_command.PropertyChanged += OnCommandPropertyChanged;
				}
				if (Visible && _ribbon != null)
				{
					_ribbon.PerformNeedPaint(needLayout: false);
				}
			}
		}
	}

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			if (value != _tag)
			{
				_tag = value;
				OnPropertyChanged("Tag");
			}
		}
	}

	public event EventHandler Click;

	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonRibbonQATButton()
	{
		_image = _defaultImage;
		_visible = true;
		_enabled = true;
		_text = "QAT Button";
		_shortcutKeys = Keys.None;
		_toolTipImageTransparentColor = Color.Empty;
		_toolTipTitle = string.Empty;
		_toolTipBody = string.Empty;
		_toolTipStyle = LabelStyle.ToolTip;
	}

	private bool ShouldSerializeImage()
	{
		return Image != _defaultImage;
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	private bool ShouldSerializeShortcutKeys()
	{
		return ShortcutKeys != Keys.None;
	}

	public void ResetShortcutKeys()
	{
		ShortcutKeys = Keys.None;
	}

	private bool ShouldSerializeTag()
	{
		return Tag != null;
	}

	private void ResetTag()
	{
		Tag = null;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void SetRibbon(KryptonRibbon ribbon)
	{
		_ribbon = ribbon;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public Image GetImage()
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ImageSmall;
		}
		return Image;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public string GetText()
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.TextLine1;
		}
		return Text;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool GetEnabled()
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.Enabled;
		}
		return Enabled;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public Keys GetShortcutKeys()
	{
		return ShortcutKeys;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool GetVisible()
	{
		return Visible;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void SetVisible(bool visible)
	{
		Visible = visible;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public LabelStyle GetToolTipStyle()
	{
		return ToolTipStyle;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public Image GetToolTipImage()
	{
		return ToolTipImage;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public Color GetToolTipImageTransparentColor()
	{
		return ToolTipImageTransparentColor;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public string GetToolTipTitle()
	{
		return ToolTipTitle;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public string GetToolTipBody()
	{
		return ToolTipBody;
	}

	public void PerformClick()
	{
		OnClick(EventArgs.Empty);
	}

	protected virtual void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		switch (e.PropertyName)
		{
		case "Text":
			flag = true;
			OnPropertyChanged("Text");
			break;
		case "ImageSmall":
			flag = true;
			OnPropertyChanged("Image");
			break;
		case "Enabled":
			flag = true;
			OnPropertyChanged("Enabled");
			break;
		}
		if (flag && Visible && _ribbon != null)
		{
			_ribbon.PerformNeedPaint(needLayout: false);
		}
	}

	protected virtual void OnClick(EventArgs e)
	{
		if (Ribbon != null)
		{
			Ribbon.ActionOccured();
		}
		if (this.Click != null)
		{
			this.Click(this, e);
		}
		if (KryptonCommand != null)
		{
			KryptonCommand.PerformExecute();
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
