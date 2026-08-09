#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewLayoutMenuItemSelect : ViewComposite
{
	private ViewContextMenuManager _viewManager;

	private KryptonContextMenuImageSelect _itemSelect;

	private IContextMenuProvider _provider;

	private PaletteTripleToPalette _triple;

	private NeedPaintHandler _needPaint;

	private ImageList _imageList;

	private int _selectedIndex;

	private int _imageIndexStart;

	private int _imageIndexEnd;

	private int _imageIndexCount;

	private int _imageCount;

	private int _lineItems;

	private Padding _padding;

	private bool _enabled;

	public bool ItemEnabled => _enabled;

	public bool CanCloseMenu => _provider.ProviderCanCloseMenu;

	public ViewLayoutMenuItemSelect(KryptonContextMenuImageSelect itemSelect, IContextMenuProvider provider)
	{
		Debug.Assert(itemSelect != null);
		Debug.Assert(provider != null);
		_itemSelect = itemSelect;
		_provider = provider;
		_itemSelect.TrackingIndex = -1;
		_enabled = provider.ProviderEnabled;
		_viewManager = provider.ProviderViewManager;
		_imageList = _itemSelect.ImageList;
		_imageIndexStart = _itemSelect.ImageIndexStart;
		_imageIndexEnd = _itemSelect.ImageIndexEnd;
		_lineItems = _itemSelect.LineItems;
		_needPaint = provider.ProviderNeedPaintDelegate;
		_padding = _itemSelect.Padding;
		_imageCount = ((_imageList != null) ? _imageList.Images.Count : 0);
		_imageIndexStart = Math.Max(0, _imageIndexStart);
		_imageIndexEnd = Math.Min(_imageIndexEnd, _imageCount - 1);
		_imageIndexCount = Math.Max(0, _imageIndexEnd - _imageIndexStart + 1);
		IPalette palette = provider.ProviderPalette;
		if (palette == null)
		{
			palette = KryptonManager.GetPaletteForMode(provider.ProviderPaletteMode);
		}
		_triple = new PaletteTripleToPalette(palette, PaletteBackStyle.ButtonLowProfile, PaletteBorderStyle.ButtonLowProfile, PaletteContentStyle.ButtonLowProfile);
		_triple.SetStyles(itemSelect.ButtonStyle);
	}

	public override string ToString()
	{
		return "ViewLayoutMenuItemSelect:" + base.Id;
	}

	public void Closing(CancelEventArgs cea)
	{
		_provider.OnClosing(cea);
	}

	public void Close(CloseReasonEventArgs e)
	{
		_provider.OnClose(e);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		SyncChildren();
		Size result = Size.Empty;
		if (Count > 0)
		{
			result = this[0].GetPreferredSize(context);
			int num = Math.Max(1, _lineItems);
			result.Width *= num;
			result.Height *= (Count + (num - 1)) / num;
		}
		result.Width += _padding.Horizontal;
		result.Height += _padding.Vertical;
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
			Rectangle rectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, ClientRectangle, _padding);
			Size preferredSize = this[0].GetPreferredSize(context);
			Point location = rectangle.Location;
			for (int i = 0; i < Count; i++)
			{
				context.DisplayRectangle = new Rectangle(location, preferredSize);
				this[i].Layout(context);
				location.X += preferredSize.Width;
				if ((i + 1) % _lineItems == 0)
				{
					location.X = rectangle.X;
					location.Y += preferredSize.Height;
				}
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public void SyncChildren()
	{
		_selectedIndex = _itemSelect.SelectedIndex;
		if (Count < _imageIndexCount)
		{
			int num = _imageIndexCount - Count;
			for (int i = 0; i < num; i++)
			{
				Add(new ViewDrawMenuImageSelectItem(_viewManager, _itemSelect, _triple, this, _needPaint));
			}
		}
		else if (Count > _imageIndexCount)
		{
			int num2 = Count - _imageIndexCount;
			for (int j = 0; j < num2; j++)
			{
				RemoveAt(0);
			}
		}
		for (int k = 0; k < _imageIndexCount; k++)
		{
			int num3 = k + _imageIndexStart;
			ViewDrawMenuImageSelectItem viewDrawMenuImageSelectItem = (ViewDrawMenuImageSelectItem)this[k];
			viewDrawMenuImageSelectItem.ImageList = _imageList;
			viewDrawMenuImageSelectItem.ImageIndex = num3;
			viewDrawMenuImageSelectItem.Checked = _selectedIndex == num3;
			viewDrawMenuImageSelectItem.Enabled = _enabled;
		}
	}
}
