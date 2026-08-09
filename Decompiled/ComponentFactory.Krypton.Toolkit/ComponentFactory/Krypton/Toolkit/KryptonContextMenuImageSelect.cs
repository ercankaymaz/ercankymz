using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuImageSelect), "ToolboxBitmaps.KryptonContextMenuImageSelect.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("ImageList")]
[DefaultEvent("SelectedIndexChanged")]
public class KryptonContextMenuImageSelect : KryptonContextMenuItemBase
{
	private Padding _padding;

	private ImageList _imageList;

	private ButtonStyle _style;

	private bool _autoClose;

	private int _selectedIndex;

	private int _imageIndexStart;

	private int _imageIndexEnd;

	private int _lineItems;

	private int _trackingIndex;

	private int _cacheTrackingIndex;

	private int _eventTrackingIndex;

	private Timer _trackingEventTimer;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Padding used around the image selection area.")]
	[DefaultValue(typeof(Padding), "2,2,2,2")]
	public Padding Padding
	{
		get
		{
			return _padding;
		}
		set
		{
			if (_padding != value)
			{
				_padding = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Padding"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates if selecting an image automatically closes the context menu.")]
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
	[Category("Behavior")]
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
				OnSelectedIndexChanged(EventArgs.Empty);
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Button style used for each image item.")]
	[DefaultValue(typeof(ButtonStyle), "LowProfile")]
	public ButtonStyle ButtonStyle
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
				OnPropertyChanged(new PropertyChangedEventArgs("ButtonStyle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Collection of images for display and selection.")]
	[DefaultValue(null)]
	public ImageList ImageList
	{
		get
		{
			return _imageList;
		}
		set
		{
			if (_imageList != value)
			{
				_imageList = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageList"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Index of first image in the ImageList for display.")]
	[DefaultValue(-1)]
	public int ImageIndexStart
	{
		get
		{
			return _imageIndexStart;
		}
		set
		{
			if (_imageIndexStart != value)
			{
				_imageIndexStart = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageIndexStart"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Index of last image in the ImageList for display.")]
	[DefaultValue(-1)]
	public int ImageIndexEnd
	{
		get
		{
			return _imageIndexEnd;
		}
		set
		{
			if (_imageIndexEnd != value)
			{
				_imageIndexEnd = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageIndexEnd"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Number of items to place on each display line.")]
	[DefaultValue(5)]
	public int LineItems
	{
		get
		{
			return _lineItems;
		}
		set
		{
			if (_lineItems != value)
			{
				value = Math.Max(1, value);
				_lineItems = value;
				OnPropertyChanged(new PropertyChangedEventArgs("LineItems"));
			}
		}
	}

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
			}
		}
	}

	[Category("Property Changed")]
	[Description("Occurs when the value of the SelectedIndex property changes.")]
	public event EventHandler SelectedIndexChanged;

	[Category("Action")]
	[Description("Occurs when user is tracking over an image.")]
	public event EventHandler<ImageSelectEventArgs> TrackingImage;

	public KryptonContextMenuImageSelect()
	{
		_autoClose = true;
		_selectedIndex = -1;
		_trackingIndex = -1;
		_imageList = null;
		_imageIndexStart = -1;
		_imageIndexEnd = -1;
		_lineItems = 5;
		_padding = new Padding(2);
		_style = ButtonStyle.LowProfile;
		_trackingEventTimer = new Timer();
		_trackingEventTimer.Interval = 120;
		_trackingEventTimer.Tick += OnTrackingTick;
	}

	public override string ToString()
	{
		return "(ImageSelect)";
	}

	public override bool ProcessShortcut(Keys keyData)
	{
		return false;
	}

	public override ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		return new ViewLayoutMenuItemSelect(this, provider);
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
