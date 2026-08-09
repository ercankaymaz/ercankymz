using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonGallery), "ToolboxBitmaps.KryptonGallery.bmp")]
[DefaultEvent("SelectedIndexChanged")]
[DefaultProperty("SelectedIndex")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonGalleryDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Select from a group of possible images.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonGallery : VisualSimpleBase
{
	private KryptonRibbon _ribbon;

	private KryptonGalleryRangeCollection _dropButtonRanges;

	private PaletteGalleryRedirect _stateCommon;

	private PaletteGalleryState _stateNormal;

	private PaletteGalleryState _stateDisabled;

	private PaletteGalleryState _stateActive;

	private PaletteGalleryBackBorder _backBorder;

	private ViewLayoutRibbonGalleryButtons _buttonsLayout;

	private ViewDrawRibbonGalleryButton _buttonUp;

	private ViewDrawRibbonGalleryButton _buttonDown;

	private ViewDrawRibbonGalleryButton _buttonContext;

	private ViewLayoutRibbonGalleryItems _drawItems;

	private ImageList _imageList;

	private GalleryImages _images;

	private ViewLayoutDocker _layoutDocker;

	private ViewDrawDocker _drawDocker;

	private bool? _fixedActive;

	private Size _preferredItemSize;

	private bool _inRibbonDesignMode;

	private bool _mouseOver;

	private bool _alwaysActive;

	private int _dropMaxItemWidth;

	private int _dropMinItemWidth;

	private int _selectedIndex;

	private int _trackingIndex;

	private int _cacheTrackingIndex;

	private int _eventTrackingIndex;

	private Timer _trackingEventTimer;

	private KryptonContextMenu _dropMenu;

	private EventHandler _finishDelegate;

	[Browsable(true)]
	[Localizable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[RefreshProperties(RefreshProperties.All)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			base.AutoSize = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[DefaultValue(typeof(Padding), "3,3,3,3")]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of drop down ranges")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonGalleryRangeCollection DropButtonRanges => _dropButtonRanges;

	[Category("Layout")]
	[Description("Preferred size measured in items per line and number of display lines.")]
	[DefaultValue(typeof(Size), "5,1")]
	public Size PreferredItemSize
	{
		get
		{
			return _preferredItemSize;
		}
		set
		{
			if (!_preferredItemSize.Equals(value))
			{
				value.Width = Math.Max(1, value.Width);
				value.Height = Math.Max(1, value.Height);
				_preferredItemSize = value;
				PerformLayout();
			}
		}
	}

	[Category("Layout")]
	[Description("Maximum number of line items for the drop down menu.")]
	[DefaultValue(128)]
	public int DropMaxItemWidth
	{
		get
		{
			return _dropMaxItemWidth;
		}
		set
		{
			if (_dropMaxItemWidth != value)
			{
				value = Math.Max(1, value);
				_dropMaxItemWidth = value;
			}
		}
	}

	[Category("Layout")]
	[Description("Minimum number of line items for the drop down menu.")]
	[DefaultValue(3)]
	public int DropMinItemWidth
	{
		get
		{
			return _dropMinItemWidth;
		}
		set
		{
			if (_dropMinItemWidth != value)
			{
				value = Math.Max(1, value);
				_dropMinItemWidth = value;
			}
		}
	}

	[Category("Visuals")]
	[Description("Button style used for each image item.")]
	[DefaultValue(typeof(ButtonStyle), "LowProfile")]
	public ButtonStyle ButtonStyle
	{
		get
		{
			return _drawItems.ButtonStyle;
		}
		set
		{
			_drawItems.ButtonStyle = value;
		}
	}

	[Category("Visuals")]
	[Description("Determines if scrolling is animated or a jump straight to target.")]
	[DefaultValue(true)]
	public bool SmoothScrolling
	{
		get
		{
			return _drawItems.ScrollIntoView;
		}
		set
		{
			_drawItems.ScrollIntoView = value;
		}
	}

	[Category("Visuals")]
	[Description("Determines if the control is always active or only when the mouse is over the control or has focus.")]
	[DefaultValue(true)]
	public bool AlwaysActive
	{
		get
		{
			return _alwaysActive;
		}
		set
		{
			if (_alwaysActive != value)
			{
				_alwaysActive = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Collection of images for display and selection.")]
	public ImageList ImageList
	{
		get
		{
			return _imageList;
		}
		set
		{
			_imageList = value;
			PerformNeedPaint(needLayout: true);
			OnImageListChanged(EventArgs.Empty);
		}
	}

	[Category("Visuals")]
	[Description("The index of the selected image.")]
	[DefaultValue(-1)]
	public int SelectedIndex
	{
		get
		{
			return _selectedIndex;
		}
		set
		{
			if (_selectedIndex != value)
			{
				_selectedIndex = value;
				BringIntoView(_selectedIndex);
				PerformNeedPaint(needLayout: true);
				OnSelectedIndexChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Visuals")]
	[Description("Gallery button image overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public GalleryImages Images => _images;

	[Category("Visuals")]
	[Description("Overrides for defining common gallery appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteGalleryRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled gallery appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteGalleryState StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal gallery appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteGalleryState StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining active gallery appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteGalleryState StateActive => _stateActive;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool InRibbonDesignMode
	{
		get
		{
			return _inRibbonDesignMode;
		}
		set
		{
			_inRibbonDesignMode = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsActive
	{
		get
		{
			if (_fixedActive.HasValue)
			{
				return _fixedActive.Value;
			}
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver;
		}
	}

	protected override Size DefaultSize => new Size(240, 30);

	internal int TrackingIndex
	{
		get
		{
			return _trackingIndex;
		}
		set
		{
			if (_trackingIndex != value)
			{
				_trackingIndex = value;
				_cacheTrackingIndex = _trackingIndex;
				_trackingEventTimer.Stop();
				_trackingEventTimer.Start();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	internal bool InTransparentDesignMode => InRibbonDesignMode;

	internal Size InternalPreferredItemSize
	{
		get
		{
			return _preferredItemSize;
		}
		set
		{
			_preferredItemSize = value;
		}
	}

	internal KryptonRibbon Ribbon
	{
		get
		{
			return _ribbon;
		}
		set
		{
			_ribbon = value;
		}
	}

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

	public KryptonGallery()
	{
		_mouseOver = false;
		_alwaysActive = true;
		_selectedIndex = -1;
		_trackingIndex = -1;
		_eventTrackingIndex = -1;
		_preferredItemSize = new Size(5, 1);
		_dropMaxItemWidth = 128;
		_dropMinItemWidth = 3;
		_trackingEventTimer = new Timer();
		_trackingEventTimer.Interval = 120;
		_trackingEventTimer.Tick += OnTrackingTick;
		_images = new GalleryImages(base.NeedPaintDelegate);
		_dropButtonRanges = new KryptonGalleryRangeCollection();
		_stateCommon = new PaletteGalleryRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateNormal = new PaletteGalleryState(_stateCommon, base.NeedPaintDelegate);
		_stateDisabled = new PaletteGalleryState(_stateCommon, base.NeedPaintDelegate);
		_stateActive = new PaletteGalleryState(_stateCommon, base.NeedPaintDelegate);
		_buttonUp = new ViewDrawRibbonGalleryButton(base.Redirector, PaletteRelativeAlign.Near, PaletteRibbonGalleryButton.Up, _images, base.NeedPaintDelegate);
		_buttonDown = new ViewDrawRibbonGalleryButton(base.Redirector, PaletteRelativeAlign.Center, PaletteRibbonGalleryButton.Down, _images, base.NeedPaintDelegate);
		_buttonContext = new ViewDrawRibbonGalleryButton(base.Redirector, PaletteRelativeAlign.Far, PaletteRibbonGalleryButton.DropDown, _images, base.NeedPaintDelegate);
		_buttonsLayout = new ViewLayoutRibbonGalleryButtons();
		_buttonsLayout.Add(_buttonUp);
		_buttonsLayout.Add(_buttonDown);
		_buttonsLayout.Add(_buttonContext);
		_backBorder = new PaletteGalleryBackBorder(_stateNormal);
		_drawDocker = new ViewDrawDocker(_backBorder, _backBorder);
		_drawItems = new ViewLayoutRibbonGalleryItems(base.Redirector, this, base.NeedPaintDelegate, _buttonUp, _buttonDown, _buttonContext);
		_drawDocker.Add(_drawItems, ViewDockStyle.Fill);
		_layoutDocker = new ViewLayoutDocker();
		_layoutDocker.Add(_drawDocker, ViewDockStyle.Fill);
		_layoutDocker.Add(_buttonsLayout, ViewDockStyle.Right);
		base.ViewManager = new ViewManager(this, _layoutDocker);
		base.Padding = new Padding(3);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeImages()
	{
		return !_images.IsDefault;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateActive()
	{
		return !_stateActive.IsDefault;
	}

	public void BringIntoView()
	{
		BringIntoView(SelectedIndex);
	}

	public void BringIntoView(int index)
	{
		int num = ((_imageList != null) ? _imageList.Images.Count : 0);
		if (index >= 0 && index < num)
		{
			_drawItems.BringIntoView(index);
		}
	}

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
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
		_eventTrackingIndex = e.ImageIndex;
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

	protected override void OnPaddingChanged(EventArgs e)
	{
		PerformNeedPaint(needLayout: true);
		base.OnPaddingChanged(e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		_mouseOver = true;
		PerformNeedPaint(needLayout: true);
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		_mouseOver = false;
		PerformNeedPaint(needLayout: true);
		base.OnMouseLeave(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		if (_imageList != null && _imageList.Images.Count > 0 && TrackingIndex < 0)
		{
			if (SelectedIndex < _imageList.Images.Count && SelectedIndex >= 0)
			{
				SetTrackingIndex(SelectedIndex, bringIntoView: true);
			}
			else
			{
				SetTrackingIndex(0, bringIntoView: true);
			}
		}
		PerformNeedPaint(needLayout: true);
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		PerformNeedPaint(needLayout: true);
		base.OnLostFocus(e);
		SetTrackingIndex(-1, bringIntoView: false);
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		if (base.ContainsFocus)
		{
			if (_trackingIndex == -1)
			{
				if (_imageList != null && _imageList.Images.Count > 0)
				{
					if (SelectedIndex < _imageList.Images.Count && SelectedIndex >= 0)
					{
						SetTrackingIndex(SelectedIndex, bringIntoView: true);
					}
					else
					{
						SetTrackingIndex(0, bringIntoView: true);
					}
					return true;
				}
			}
			else
			{
				switch (keyData)
				{
				case Keys.Prior:
				case Keys.Next:
				case Keys.End:
				case Keys.Home:
				case Keys.Left:
				case Keys.Up:
				case Keys.Right:
				case Keys.Down:
					if (_ribbon == null || (_ribbon != null && !_ribbon.InKeyboardMode))
					{
						_drawItems[_trackingIndex].KeyDown(new KeyEventArgs(keyData));
						return true;
					}
					break;
				case Keys.Return:
				case Keys.Space:
					_drawItems[_trackingIndex].KeyDown(new KeyEventArgs(keyData));
					return true;
				}
			}
		}
		return base.ProcessDialogKey(keyData);
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (base.IsHandleCreated)
		{
			UpdateStateAndPalettes();
		}
		base.OnNeedPaint(sender, e);
	}

	protected override bool EvalTransparentPaint()
	{
		return true;
	}

	protected override void WndProc(ref Message m)
	{
		int msg = m.Msg;
		int num = msg;
		if (num == 132)
		{
			if (InTransparentDesignMode)
			{
				m.Result = (IntPtr)(-1);
			}
			else
			{
				base.WndProc(ref m);
			}
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	internal void SetTrackingIndex(int index, bool bringIntoView)
	{
		TrackingIndex = index;
		if (_trackingIndex != -1 && bringIntoView)
		{
			BringIntoView(_trackingIndex);
		}
	}

	internal bool DesignerGetHitTest(Point pt)
	{
		return false;
	}

	internal Component DesignerComponentFromPoint(Point pt)
	{
		if (base.IsDisposed)
		{
			return null;
		}
		return base.ViewManager.ComponentFromPoint(pt);
	}

	internal void DesignerMouseLeave()
	{
		OnMouseLeave(EventArgs.Empty);
	}

	internal void OnDropButton()
	{
		ShownGalleryDropDown(RectangleToScreen(base.ClientRectangle), KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Top, null, _drawItems.ActualLineItems);
	}

	internal void ShownGalleryDropDown(Rectangle screenRect, KryptonContextMenuPositionH hPosition, KryptonContextMenuPositionV vPosition, EventHandler finishDelegate, int actualLineItems)
	{
		if (_dropMenu == null)
		{
			_dropMenu = new KryptonContextMenu();
		}
		int lineItems = Math.Max(DropMinItemWidth, Math.Min(DropMaxItemWidth, actualLineItems));
		if (_dropButtonRanges.Count == 0)
		{
			KryptonContextMenuImageSelect kryptonContextMenuImageSelect = new KryptonContextMenuImageSelect();
			kryptonContextMenuImageSelect.ImageList = ImageList;
			kryptonContextMenuImageSelect.ImageIndexStart = 0;
			kryptonContextMenuImageSelect.ImageIndexEnd = ((ImageList != null) ? (ImageList.Images.Count - 1) : 0);
			kryptonContextMenuImageSelect.SelectedIndex = SelectedIndex;
			kryptonContextMenuImageSelect.LineItems = lineItems;
			_dropMenu.Items.Add(kryptonContextMenuImageSelect);
		}
		else
		{
			foreach (KryptonGalleryRange dropButtonRange in _dropButtonRanges)
			{
				if (_dropMenu.Items.Count > 0)
				{
					_dropMenu.Items.Add(new KryptonContextMenuSeparator());
				}
				if (!string.IsNullOrEmpty(dropButtonRange.Heading))
				{
					KryptonContextMenuHeading kryptonContextMenuHeading = new KryptonContextMenuHeading();
					kryptonContextMenuHeading.Text = dropButtonRange.Heading;
					_dropMenu.Items.Add(kryptonContextMenuHeading);
				}
				KryptonContextMenuImageSelect kryptonContextMenuImageSelect2 = new KryptonContextMenuImageSelect();
				kryptonContextMenuImageSelect2.ImageList = ImageList;
				kryptonContextMenuImageSelect2.ImageIndexStart = Math.Max(0, dropButtonRange.ImageIndexStart);
				kryptonContextMenuImageSelect2.ImageIndexEnd = Math.Min(dropButtonRange.ImageIndexEnd, (ImageList != null) ? (ImageList.Images.Count - 1) : 0);
				kryptonContextMenuImageSelect2.SelectedIndex = SelectedIndex;
				kryptonContextMenuImageSelect2.LineItems = lineItems;
				_dropMenu.Items.Add(kryptonContextMenuImageSelect2);
			}
		}
		GalleryDropMenuEventArgs e = new GalleryDropMenuEventArgs(_dropMenu);
		OnGalleryDropMenu(e);
		if (!e.Cancel && CommonHelper.ValidKryptonContextMenu(e.KryptonContextMenu))
		{
			foreach (KryptonContextMenuItemBase item in _dropMenu.Items)
			{
				if (item is KryptonContextMenuImageSelect)
				{
					KryptonContextMenuImageSelect kryptonContextMenuImageSelect3 = (KryptonContextMenuImageSelect)item;
					kryptonContextMenuImageSelect3.SelectedIndexChanged += OnDropImageSelect;
					kryptonContextMenuImageSelect3.TrackingImage += OnDropImageTracking;
				}
			}
			e.KryptonContextMenu.Closed += OnDropMenuClosed;
			_finishDelegate = finishDelegate;
			e.KryptonContextMenu.Show(this, screenRect, hPosition, vPosition);
		}
		else
		{
			finishDelegate?.Invoke(this, EventArgs.Empty);
		}
	}

	private void OnDropMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
	{
		if (_dropMenu == null)
		{
			return;
		}
		TrackingIndex = -1;
		_dropMenu.Closed -= OnDropMenuClosed;
		foreach (KryptonContextMenuItemBase item in _dropMenu.Items)
		{
			if (item is KryptonContextMenuImageSelect)
			{
				KryptonContextMenuImageSelect kryptonContextMenuImageSelect = (KryptonContextMenuImageSelect)item;
				kryptonContextMenuImageSelect.SelectedIndexChanged -= OnDropImageSelect;
				kryptonContextMenuImageSelect.TrackingImage -= OnDropImageTracking;
			}
		}
		_dropMenu.Items.Clear();
		_dropMenu.Dispose();
		_dropMenu = null;
		if (_finishDelegate != null)
		{
			_finishDelegate(this, e);
			_finishDelegate = null;
		}
	}

	private void OnDropImageSelect(object sender, EventArgs e)
	{
		KryptonContextMenuImageSelect kryptonContextMenuImageSelect = (KryptonContextMenuImageSelect)sender;
		SelectedIndex = kryptonContextMenuImageSelect.SelectedIndex;
	}

	private void OnDropImageTracking(object sender, ImageSelectEventArgs e)
	{
		KryptonContextMenuImageSelect kryptonContextMenuImageSelect = (KryptonContextMenuImageSelect)sender;
		TrackingIndex = e.ImageIndex;
	}

	private void UpdateStateAndPalettes()
	{
		_backBorder.SetState(GetGalleryState());
		_drawDocker.Enabled = base.Enabled;
		PaletteState elementState = ((!IsActive) ? PaletteState.Normal : PaletteState.Tracking);
		_drawDocker.ElementState = elementState;
	}

	private PaletteGalleryState GetGalleryState()
	{
		if (base.Enabled)
		{
			if (IsActive)
			{
				return _stateActive;
			}
			return _stateNormal;
		}
		return _stateDisabled;
	}

	private void OnTrackingTick(object sender, EventArgs e)
	{
		if (_trackingIndex == _cacheTrackingIndex)
		{
			_trackingEventTimer.Stop();
			if (_eventTrackingIndex != _trackingIndex)
			{
				OnTrackingImage(new ImageSelectEventArgs(_imageList, _trackingIndex));
			}
		}
		else
		{
			_cacheTrackingIndex = _trackingIndex;
		}
	}
}
