#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGalleryItems : ViewComposite
{
	private static readonly int SCROLL_MOVE = 10;

	private ViewDrawRibbonGalleryButton _buttonUp;

	private ViewDrawRibbonGalleryButton _buttonDown;

	private ViewDrawRibbonGalleryButton _buttonContext;

	private NeedPaintHandler _needPaint;

	private PaletteTripleToPalette _triple;

	private KryptonGallery _gallery;

	private ButtonStyle _style;

	private Timer _scrollTimer;

	private Size _itemSize;

	private int _lineItems;

	private int _displayLines;

	private int _layoutLines;

	private int _topLine;

	private int _endLine;

	private int _offset;

	private int _beginLine;

	private int _bringIntoView;

	private bool _scrollIntoView;

	public bool ScrollIntoView
	{
		get
		{
			return _scrollIntoView;
		}
		set
		{
			_scrollIntoView = value;
		}
	}

	public int ActualLineItems => Math.Max(1, _lineItems);

	public bool CanNextLine => _topLine < _endLine;

	public bool CanPrevLine => _topLine > 0;

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
				_triple.SetStyles(_style);
				_needPaint(this, new NeedLayoutEventArgs(needLayout: true));
			}
		}
	}

	public ViewLayoutRibbonGalleryItems(IPalette palette, KryptonGallery gallery, NeedPaintHandler needPaint, ViewDrawRibbonGalleryButton buttonUp, ViewDrawRibbonGalleryButton buttonDown, ViewDrawRibbonGalleryButton buttonContext)
	{
		Debug.Assert(palette != null);
		Debug.Assert(gallery != null);
		Debug.Assert(needPaint != null);
		Debug.Assert(buttonUp != null);
		Debug.Assert(buttonDown != null);
		Debug.Assert(buttonContext != null);
		_gallery = gallery;
		_needPaint = needPaint;
		_buttonUp = buttonUp;
		_buttonDown = buttonDown;
		_buttonContext = buttonContext;
		_bringIntoView = -1;
		_scrollIntoView = true;
		_buttonUp.Click += OnButtonUp;
		_buttonDown.Click += OnButtonDown;
		_buttonContext.Click += OnButtonContext;
		_style = ButtonStyle.LowProfile;
		_triple = new PaletteTripleToPalette(palette, PaletteBackStyle.ButtonLowProfile, PaletteBorderStyle.ButtonLowProfile, PaletteContentStyle.ButtonLowProfile);
		_scrollTimer = new Timer();
		_scrollTimer.Interval = 40;
		_scrollTimer.Tick += OnScrollTick;
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonGalleryItems:" + base.Id;
	}

	public void TrackMoveHome()
	{
		if (Count > 0)
		{
			_gallery.SetTrackingIndex(0, bringIntoView: true);
		}
	}

	public void TrackMoveEnd()
	{
		if (Count > 0)
		{
			_gallery.SetTrackingIndex(Count - 1, bringIntoView: true);
		}
	}

	public void TrackMovePageUp()
	{
		if (Count > 0)
		{
			int trackingIndex = _gallery.TrackingIndex;
			trackingIndex -= _displayLines * _lineItems;
			trackingIndex = Math.Max(0, trackingIndex);
			_gallery.SetTrackingIndex(trackingIndex, bringIntoView: true);
		}
	}

	public void TrackMovePageDown()
	{
		if (Count > 0)
		{
			int trackingIndex = _gallery.TrackingIndex;
			trackingIndex += _displayLines * _lineItems;
			trackingIndex = Math.Min(trackingIndex, Count - 1);
			_gallery.SetTrackingIndex(trackingIndex, bringIntoView: true);
		}
	}

	public void TrackMoveUp()
	{
		if (Count > 0)
		{
			int trackingIndex = _gallery.TrackingIndex;
			if (trackingIndex >= _lineItems)
			{
				trackingIndex -= _lineItems;
				trackingIndex = Math.Max(0, trackingIndex);
				_gallery.SetTrackingIndex(trackingIndex, bringIntoView: true);
			}
		}
	}

	public void TrackMoveDown()
	{
		if (Count > 0 && _gallery.TrackingIndex + _lineItems < Count)
		{
			int trackingIndex = _gallery.TrackingIndex;
			trackingIndex += _lineItems;
			trackingIndex = Math.Min(trackingIndex, Count - 1);
			_gallery.SetTrackingIndex(trackingIndex, bringIntoView: true);
		}
	}

	public void TrackMoveLeft()
	{
		if (Count > 0)
		{
			int trackingIndex = _gallery.TrackingIndex;
			if (trackingIndex % _lineItems > 0)
			{
				trackingIndex--;
				trackingIndex = Math.Max(0, trackingIndex);
				_gallery.SetTrackingIndex(trackingIndex, bringIntoView: true);
			}
		}
	}

	public void TrackMoveRight()
	{
		if (Count > 0)
		{
			int trackingIndex = _gallery.TrackingIndex;
			if (trackingIndex % _lineItems < _lineItems - 1)
			{
				trackingIndex++;
				trackingIndex = Math.Min(trackingIndex, Count - 1);
				_gallery.SetTrackingIndex(trackingIndex, bringIntoView: true);
			}
		}
	}

	public void NextLine()
	{
		int topLine = _topLine;
		_topLine = Math.Min(_topLine + 1, _endLine);
		if (ScrollIntoView)
		{
			_offset -= _itemSize.Height;
			if (_offset < 0 && (_beginLine == -1 || _beginLine > topLine))
			{
				_beginLine = topLine;
			}
			_scrollTimer.Start();
		}
	}

	public void PrevLine()
	{
		int topLine = _topLine;
		_topLine = Math.Max(_topLine - 1, 0);
		if (ScrollIntoView)
		{
			_offset += _itemSize.Height;
			if (_offset > 0 && (_beginLine == -1 || _beginLine < topLine))
			{
				_beginLine = topLine;
			}
			_scrollTimer.Start();
		}
	}

	public void BringIntoView(int index)
	{
		_bringIntoView = index;
		_gallery.PerformNeedPaint(needLayout: true);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		SyncChildren();
		Size result = Size.Empty;
		if (Count > 0)
		{
			result = this[0].GetPreferredSize(context);
			result.Width *= _gallery.PreferredItemSize.Width;
			result.Height *= _gallery.PreferredItemSize.Height;
		}
		result.Width += _gallery.Padding.Horizontal;
		result.Height += _gallery.Padding.Vertical;
		return result;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		SyncChildren();
		if (Count > 0)
		{
			Rectangle rectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, ClientRectangle, _gallery.Padding);
			_itemSize = this[0].GetPreferredSize(context);
			_lineItems = Math.Max(1, rectangle.Width / _itemSize.Width);
			_layoutLines = Math.Max(1, (Count + _lineItems - 1) / _lineItems);
			_displayLines = Math.Max(1, Math.Min(_layoutLines, rectangle.Height / _itemSize.Height));
			_endLine = _layoutLines - _displayLines;
			ProcessBringIntoView();
			_topLine = Math.Max(0, Math.Min(_topLine, _endLine));
			_buttonUp.Enabled = _gallery.Enabled && CanPrevLine;
			_buttonDown.Enabled = _gallery.Enabled && CanNextLine;
			_buttonContext.Enabled = _gallery.Enabled && Count > 0;
			Point location = rectangle.Location;
			location.Y += (rectangle.Height - _displayLines * _itemSize.Height) / 2;
			int num = _topLine * _lineItems;
			int num2 = num + _displayLines * _lineItems;
			int num3 = _offset;
			if (num3 != 0)
			{
				if (num3 < 0)
				{
					int num4 = _topLine - _beginLine;
					if (_topLine - num4 < 0)
					{
						num4 = _topLine;
					}
					num -= num4 * _lineItems;
					num3 += num4 * _itemSize.Height;
				}
				else
				{
					int num5 = _beginLine - _topLine;
					num2 += num5 * _lineItems;
					if (num2 > Count)
					{
						num2 = Count;
					}
				}
			}
			location.Y -= num3;
			for (int i = 0; i < Count; i++)
			{
				ViewBase viewBase = this[i];
				if (i < num || i >= num2)
				{
					viewBase.Visible = false;
					continue;
				}
				viewBase.Visible = true;
				context.DisplayRectangle = new Rectangle(location, _itemSize);
				viewBase.Layout(context);
				location.X += _itemSize.Width;
				if (location.X + _itemSize.Width > rectangle.Right)
				{
					location.X = rectangle.X;
					location.Y += _itemSize.Height;
				}
			}
		}
		else
		{
			_buttonUp.Enabled = false;
			_buttonDown.Enabled = false;
			_buttonContext.Enabled = false;
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public void SyncChildren()
	{
		int num = 0;
		int selectedIndex = _gallery.SelectedIndex;
		ImageList imageList = _gallery.ImageList;
		if (imageList != null)
		{
			num = _gallery.ImageList.Images.Count;
		}
		if (Count < num)
		{
			int num2 = num - Count;
			for (int i = 0; i < num2; i++)
			{
				Add(new ViewDrawRibbonGalleryItem(_gallery, _triple, this, _needPaint));
			}
		}
		else if (Count > num)
		{
			int num3 = Count - num;
			for (int j = 0; j < num3; j++)
			{
				RemoveAt(0);
			}
		}
		for (int k = 0; k < num; k++)
		{
			ViewDrawRibbonGalleryItem viewDrawRibbonGalleryItem = (ViewDrawRibbonGalleryItem)this[k];
			viewDrawRibbonGalleryItem.ImageList = imageList;
			viewDrawRibbonGalleryItem.ImageIndex = k;
			viewDrawRibbonGalleryItem.Checked = selectedIndex == k;
		}
	}

	private void OnButtonUp(object sender, MouseEventArgs e)
	{
		PrevLine();
		_gallery.PerformNeedPaint(needLayout: true);
	}

	private void OnButtonDown(object sender, MouseEventArgs e)
	{
		NextLine();
		_gallery.PerformNeedPaint(needLayout: true);
	}

	private void OnButtonContext(object sender, MouseEventArgs e)
	{
		_buttonContext.ForceLeave();
		_gallery.OnDropButton();
	}

	private void OnScrollTick(object sender, EventArgs e)
	{
		if (_offset != 0)
		{
			if (_offset > 0)
			{
				_offset = Math.Max(0, _offset - SCROLL_MOVE);
			}
			else
			{
				_offset = Math.Min(0, _offset + SCROLL_MOVE);
			}
		}
		if (_offset == 0)
		{
			_beginLine = -1;
			_scrollTimer.Stop();
		}
		_needPaint(this, new NeedLayoutEventArgs(needLayout: true));
	}

	private void ProcessBringIntoView()
	{
		if (_bringIntoView < 0)
		{
			return;
		}
		if (_lineItems > 0)
		{
			int num = _bringIntoView / _lineItems;
			int num2 = num;
			if (num > _endLine)
			{
				num = _endLine;
			}
			int topLine = _topLine;
			if (num < _topLine)
			{
				int num3 = _topLine - num;
				_topLine = num;
				if (ScrollIntoView)
				{
					_offset += _itemSize.Height * num3;
					_scrollTimer.Start();
				}
				else
				{
					_offset = 0;
					_scrollTimer.Stop();
				}
			}
			else if (num2 >= _topLine + _displayLines)
			{
				int num4 = num2 - (_topLine + (_displayLines - 1));
				_topLine = num2 - (_displayLines - 1);
				if (ScrollIntoView)
				{
					_offset -= _itemSize.Height * num4;
					_scrollTimer.Start();
				}
				else
				{
					_offset = 0;
					_scrollTimer.Stop();
				}
			}
			if (_offset < 0)
			{
				if (_beginLine == -1 || _beginLine > topLine)
				{
					_beginLine = topLine;
				}
			}
			else if (_offset > 0 && (_beginLine == -1 || _beginLine < topLine))
			{
				_beginLine = topLine;
			}
		}
		_bringIntoView = -1;
	}
}
