using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupLabel), "ToolboxBitmaps.KryptonRibbonGroupLabel.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabelDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Text")]
public class KryptonRibbonGroupLabel : KryptonRibbonGroupItem
{
	private bool _visible;

	private bool _enabled;

	private Image _imageSmall;

	private Image _imageLarge;

	private Image _toolTipImage;

	private string _toolTipTitle;

	private string _toolTipBody;

	private string _textLine1;

	private string _textLine2;

	private Color _toolTipImageTransparentColor;

	private LabelStyle _toolTipStyle;

	private GroupItemSize _itemSizeCurrent;

	private KryptonCommand _command;

	private NeedPaintHandler _needPaintDelegate;

	private NeedPaintHandler _viewPaintDelegate;

	private PaletteRibbonText _stateNormal;

	private PaletteRibbonText _stateDisabled;

	private ViewBase _labelView;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Small label image.")]
	[RefreshProperties(RefreshProperties.All)]
	public Image ImageSmall
	{
		get
		{
			return _imageSmall;
		}
		set
		{
			if (_imageSmall != value)
			{
				_imageSmall = value;
				OnPropertyChanged("ImageSmall");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Large label image.")]
	[RefreshProperties(RefreshProperties.All)]
	public Image ImageLarge
	{
		get
		{
			return _imageLarge;
		}
		set
		{
			if (_imageLarge != value)
			{
				_imageLarge = value;
				OnPropertyChanged("ImageLarge");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Label display text line 1.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("Label")]
	public string TextLine1
	{
		get
		{
			return _textLine1;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "Label";
			}
			if (value != _textLine1)
			{
				_textLine1 = value;
				OnPropertyChanged("TextLine1");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Label display text line 2.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("")]
	public string TextLine2
	{
		get
		{
			return _textLine2;
		}
		set
		{
			if (value != _textLine2)
			{
				_textLine2 = value;
				OnPropertyChanged("TextLine2");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the label is visible or hidden.")]
	[DefaultValue(true)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool Visible
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
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the group label is enabled.")]
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
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining label text normal appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining label text disabled appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText StateDisabled => _stateDisabled;

	[Category("Appearance")]
	[Description("Tooltip style for the group label.")]
	[DefaultValue(typeof(LabelStyle), "SuperTip")]
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
	[Description("Command associated with the group label.")]
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
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMaximum
	{
		get
		{
			return GroupItemSize.Large;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMinimum
	{
		get
		{
			return GroupItemSize.Small;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeCurrent
	{
		get
		{
			return _itemSizeCurrent;
		}
		set
		{
			if (_itemSizeCurrent != value)
			{
				_itemSizeCurrent = value;
				OnPropertyChanged("ItemSizeCurrent");
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase LabelView
	{
		get
		{
			return _labelView;
		}
		set
		{
			_labelView = value;
		}
	}

	internal NeedPaintHandler ViewPaintDelegate
	{
		get
		{
			return _viewPaintDelegate;
		}
		set
		{
			_viewPaintDelegate = value;
		}
	}

	internal override LabelStyle InternalToolTipStyle => ToolTipStyle;

	internal override Image InternalToolTipImage => ToolTipImage;

	internal override Color InternalToolTipImageTransparentColor => ToolTipImageTransparentColor;

	internal override string InternalToolTipTitle => ToolTipTitle;

	internal override string InternalToolTipBody => ToolTipBody;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[Category("Design Time")]
	[Description("Occurs when the design time context menu is requested.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonGroupLabel()
	{
		_visible = true;
		_enabled = true;
		_imageSmall = null;
		_imageLarge = null;
		_textLine1 = "Label";
		_textLine2 = string.Empty;
		_itemSizeCurrent = GroupItemSize.Medium;
		_toolTipImageTransparentColor = Color.Empty;
		_toolTipTitle = string.Empty;
		_toolTipBody = string.Empty;
		_toolTipStyle = LabelStyle.SuperTip;
		_needPaintDelegate = OnPaletteNeedPaint;
		_stateNormal = new PaletteRibbonText(_needPaintDelegate);
		_stateDisabled = new PaletteRibbonText(_needPaintDelegate);
	}

	private bool ShouldSerializeImageSmall()
	{
		return ImageSmall != null;
	}

	private bool ShouldSerializeImageLarge()
	{
		return ImageLarge != null;
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupLabel(ribbon, this, needPaint);
	}

	protected virtual void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "TextLine1":
			OnPropertyChanged("TextLine1");
			break;
		case "ExtraText":
			OnPropertyChanged("TextLine2");
			break;
		case "ImageSmall":
			OnPropertyChanged("ImageSmall");
			break;
		case "ImageLarge":
			OnPropertyChanged("ImageLarge");
			break;
		case "Enabled":
			OnPropertyChanged("Enabled");
			break;
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	internal void OnDesignTimeContextMenu(MouseEventArgs e)
	{
		if (this.DesignTimeContextMenu != null)
		{
			this.DesignTimeContextMenu(this, e);
		}
	}

	internal override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		return false;
	}

	private void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (_viewPaintDelegate != null)
		{
			_viewPaintDelegate(this, e);
		}
	}
}
