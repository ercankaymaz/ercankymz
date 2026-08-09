using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupGallery), "ToolboxBitmaps.KryptonGallery.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupGalleryDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Visible")]
public class KryptonRibbonGroupGallery : KryptonRibbonGroupContainer
{
	private static readonly Image _defaultButtonImageLarge = Resources.ButtonImageLarge;

	private bool _visible;

	private bool _enabled;

	private string _textLine1;

	private string _textLine2;

	private Image _imageLarge;

	private string _keyTip;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonGallery _gallery;

	private KryptonGallery _lastGallery;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _galleryView;

	private GroupItemSize _itemSizeMax;

	private GroupItemSize _itemSizeMin;

	private GroupItemSize _itemSizeCurrent;

	private int _largeItemCount;

	private int _mediumItemCount;

	private int _itemCount;

	private int _dropButtonItemWidth;

	private Image _toolTipImage;

	private Color _toolTipImageTransparentColor;

	private LabelStyle _toolTipStyle;

	private string _toolTipTitle;

	private string _toolTipBody;

	[Description("Access to the actual embedded KryptonGallery instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonGallery Gallery => _gallery;

	[Category("Visuals")]
	[Description("Collection of drop down ranges")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonGalleryRangeCollection DropButtonRanges => _gallery.DropButtonRanges;

	[Category("Visuals")]
	[Description("Determines if scrolling is animated or a jump straight to target.")]
	[DefaultValue(true)]
	public bool SmoothScrolling
	{
		get
		{
			return _gallery.SmoothScrolling;
		}
		set
		{
			_gallery.SmoothScrolling = value;
			OnPropertyChanged("SmoothScrolling");
		}
	}

	[Category("Visuals")]
	[Description("Collection of images for display and selection.")]
	public ImageList ImageList
	{
		get
		{
			return _gallery.ImageList;
		}
		set
		{
			if (_gallery.ImageList != value)
			{
				_gallery.ImageList = value;
				OnPropertyChanged("ImageList");
			}
		}
	}

	[Category("Visuals")]
	[Description("The index of the selected image.")]
	[DefaultValue(-1)]
	public int SelectedIndex
	{
		get
		{
			return _gallery.SelectedIndex;
		}
		set
		{
			if (_gallery.SelectedIndex != value)
			{
				_gallery.SelectedIndex = value;
				OnPropertyChanged("SelectedIndex");
			}
		}
	}

	[Category("Visuals")]
	[Description("Number of horizontal displayed items when in large setting.")]
	[DefaultValue(9)]
	public int LargeItemCount
	{
		get
		{
			return _largeItemCount;
		}
		set
		{
			if (_largeItemCount != value)
			{
				_largeItemCount = value;
				if (_largeItemCount < _mediumItemCount)
				{
					_mediumItemCount = _largeItemCount;
				}
				OnPropertyChanged("LargeItemCount");
			}
		}
	}

	[Category("Visuals")]
	[Description("Number of horizontal displayed items when in medium setting.")]
	[DefaultValue(3)]
	public int MediumItemCount
	{
		get
		{
			return _mediumItemCount;
		}
		set
		{
			if (_mediumItemCount != value)
			{
				_mediumItemCount = value;
				if (_mediumItemCount > _largeItemCount)
				{
					_largeItemCount = _mediumItemCount;
				}
				OnPropertyChanged("MediumItemCount");
			}
		}
	}

	[Category("Visuals")]
	[Description("Number of horizontal displayed items when showing drop menu from the large button.")]
	[DefaultValue(9)]
	public int DropButtonItemWidth
	{
		get
		{
			return _dropButtonItemWidth;
		}
		set
		{
			if (_dropButtonItemWidth != value)
			{
				value = Math.Max(1, value);
				_dropButtonItemWidth = value;
				OnPropertyChanged("DropButtonItemWidth");
			}
		}
	}

	[Category("Visuals")]
	[Description("Maximum number of line items for the drop down menu.")]
	[DefaultValue(128)]
	public int DropMaxItemWidth
	{
		get
		{
			return _gallery.DropMaxItemWidth;
		}
		set
		{
			if (_gallery.DropMaxItemWidth != value)
			{
				_gallery.DropMaxItemWidth = value;
				OnPropertyChanged("DropMaxItemWidth");
			}
		}
	}

	[Category("Visuals")]
	[Description("Minimum number of line items for the drop down menu.")]
	[DefaultValue(3)]
	public int DropMinItemWidth
	{
		get
		{
			return _gallery.DropMinItemWidth;
		}
		set
		{
			if (_gallery.DropMinItemWidth != value)
			{
				_gallery.DropMinItemWidth = value;
				OnPropertyChanged("DropMinItemWidth");
			}
		}
	}

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _gallery.ContextMenuStrip;
		}
		set
		{
			_gallery.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the gallery is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _gallery.KryptonContextMenu;
		}
		set
		{
			_gallery.KryptonContextMenu = value;
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group gallery key tip.")]
	[DefaultValue("X")]
	public string KeyTip
	{
		get
		{
			return _keyTip;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "X";
			}
			_keyTip = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Large gallery button image.")]
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
	[Description("Gallery button display text line 1.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("Gallery")]
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
				value = "Gallery";
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
	[Description("Gallery button display text line 2.")]
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

	[Category("Appearance")]
	[Description("Tooltip style for the group button.")]
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

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the group gallery is visible or hidden.")]
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
	[Description("Determines whether the group gallery is enabled.")]
	[DefaultValue(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (_enabled != value)
			{
				_enabled = value;
				OnPropertyChanged("Enabled");
			}
		}
	}

	[Category("Visuals")]
	[Description("Maximum size of the gallery.")]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DefaultValue(typeof(GroupItemSize), "Large")]
	[RefreshProperties(RefreshProperties.All)]
	public GroupItemSize MaximumSize
	{
		get
		{
			return ItemSizeMaximum;
		}
		set
		{
			ItemSizeMaximum = value;
		}
	}

	[Category("Visuals")]
	[Description("Minimum size of the gallery.")]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DefaultValue(typeof(GroupItemSize), "Small")]
	[RefreshProperties(RefreshProperties.All)]
	public GroupItemSize MinimumSize
	{
		get
		{
			return ItemSizeMinimum;
		}
		set
		{
			ItemSizeMinimum = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMaximum
	{
		get
		{
			return _itemSizeMax;
		}
		set
		{
			if (_itemSizeMax != value)
			{
				_itemSizeMax = value;
				OnPropertyChanged("ItemSizeMaximum");
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMinimum
	{
		get
		{
			return _itemSizeMin;
		}
		set
		{
			if (_itemSizeMin != value)
			{
				_itemSizeMin = value;
				OnPropertyChanged("ItemSizeMinimum");
			}
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
			_itemSizeCurrent = value;
			switch (value)
			{
			case GroupItemSize.Large:
				_gallery.InternalPreferredItemSize = new Size(InternalItemCount, 1);
				break;
			case GroupItemSize.Medium:
				_gallery.InternalPreferredItemSize = new Size(MediumItemCount, 1);
				break;
			}
			OnPropertyChanged("ItemSizeCurrent");
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public IKryptonDesignObject GalleryDesigner
	{
		get
		{
			return _designer;
		}
		set
		{
			_designer = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase GalleryView
	{
		get
		{
			return _galleryView;
		}
		set
		{
			_galleryView = value;
		}
	}

	internal Control LastParentControl
	{
		get
		{
			return _lastParentControl;
		}
		set
		{
			_lastParentControl = value;
		}
	}

	internal KryptonGallery LastGallery
	{
		get
		{
			return _lastGallery;
		}
		set
		{
			_lastGallery = value;
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

	internal int InternalItemCount
	{
		get
		{
			return _itemCount;
		}
		set
		{
			_itemCount = value;
		}
	}

	internal override LabelStyle InternalToolTipStyle => ToolTipStyle;

	internal override Image InternalToolTipImage => ToolTipImage;

	internal override Color InternalToolTipImageTransparentColor => ToolTipImageTransparentColor;

	internal override string InternalToolTipTitle => ToolTipTitle;

	internal override string InternalToolTipBody => ToolTipBody;

	[Category("Property Changed")]
	[Description("Occurs when the value of the ImageList property changes.")]
	public event EventHandler ImageListChanged;

	[Category("Property Changed")]
	[Description("Occurs when the value of the SelectedIndex property changes.")]
	public event EventHandler SelectedIndexChanged;

	[Category("Action")]
	[Description("Occurs when user is tracking over an image.")]
	public event EventHandler<ImageSelectEventArgs> TrackingImage;

	[Category("Action")]
	[Description("Occurs when user invokes the drop down menu.")]
	public event EventHandler<GalleryDropMenuEventArgs> GalleryDropMenu;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler GotFocus;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event EventHandler LostFocus;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	internal event EventHandler MouseEnterControl;

	internal event EventHandler MouseLeaveControl;

	public KryptonRibbonGroupGallery()
	{
		_visible = true;
		_enabled = true;
		_keyTip = "X";
		_itemSizeMax = GroupItemSize.Large;
		_itemSizeMin = GroupItemSize.Small;
		_itemSizeCurrent = GroupItemSize.Large;
		_largeItemCount = 9;
		_mediumItemCount = 3;
		_dropButtonItemWidth = 9;
		_imageLarge = _defaultButtonImageLarge;
		_textLine1 = "Gallery";
		_textLine2 = string.Empty;
		_toolTipImageTransparentColor = Color.Empty;
		_toolTipTitle = string.Empty;
		_toolTipBody = string.Empty;
		_toolTipStyle = LabelStyle.SuperTip;
		_gallery = new KryptonGallery();
		_gallery.AlwaysActive = false;
		_gallery.TabStop = false;
		_gallery.InternalPreferredItemSize = new Size(_largeItemCount, 1);
		_gallery.SelectedIndexChanged += OnGallerySelectedIndexChanged;
		_gallery.ImageListChanged += OnGalleryImageListChanged;
		_gallery.TrackingImage += OnGalleryTrackingImage;
		_gallery.GalleryDropMenu += OnGalleryGalleryDropMenu;
		_gallery.GotFocus += OnGalleryGotFocus;
		_gallery.LostFocus += OnGalleryLostFocus;
		MonitorControl(_gallery);
	}

	private bool ShouldSerializeImageLarge()
	{
		return ImageLarge != _defaultButtonImageLarge;
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupGallery(ribbon, this, needPaint);
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

	protected virtual void OnImageListChanged(EventArgs e)
	{
		if (this.ImageListChanged != null)
		{
			this.ImageListChanged(this, e);
		}
	}

	protected virtual void OnSelectedIndexChanged(EventArgs e)
	{
		if (this.SelectedIndexChanged != null)
		{
			this.SelectedIndexChanged(this, e);
		}
	}

	protected virtual void OnTrackingImage(ImageSelectEventArgs e)
	{
		if (this.TrackingImage != null)
		{
			this.TrackingImage(this, e);
		}
	}

	protected virtual void OnGalleryDropMenu(GalleryDropMenuEventArgs e)
	{
		if (this.GalleryDropMenu != null)
		{
			this.GalleryDropMenu(this, e);
		}
	}

	protected virtual void OnGotFocus(EventArgs e)
	{
		if (this.GotFocus != null)
		{
			this.GotFocus(this, e);
		}
	}

	protected virtual void OnLostFocus(EventArgs e)
	{
		if (this.LostFocus != null)
		{
			this.LostFocus(this, e);
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	private void MonitorControl(KryptonGallery c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonGallery c)
	{
		c.MouseEnter -= OnControlEnter;
		c.MouseLeave -= OnControlLeave;
	}

	private void OnControlEnter(object sender, EventArgs e)
	{
		if (this.MouseEnterControl != null)
		{
			this.MouseEnterControl(this, e);
		}
	}

	private void OnControlLeave(object sender, EventArgs e)
	{
		if (this.MouseLeaveControl != null)
		{
			this.MouseLeaveControl(this, e);
		}
	}

	private void OnGalleryImageListChanged(object sender, EventArgs e)
	{
		OnImageListChanged(e);
	}

	private void OnGallerySelectedIndexChanged(object sender, EventArgs e)
	{
		OnSelectedIndexChanged(e);
	}

	private void OnGalleryTrackingImage(object sender, ImageSelectEventArgs e)
	{
		OnTrackingImage(e);
	}

	private void OnGalleryGalleryDropMenu(object sender, GalleryDropMenuEventArgs e)
	{
		OnGalleryDropMenu(e);
	}

	private void OnGalleryGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnGalleryLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}
}
