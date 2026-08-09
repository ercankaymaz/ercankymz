#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuImageSelectItem : ViewDrawButton, IContentValues
{
	private KryptonContextMenuImageSelect _imageSelect;

	private ViewLayoutMenuItemSelect _layout;

	private MenuImageSelectController _controller;

	private NeedPaintHandler _needPaint;

	private ImageList _imageList;

	private int _imageIndex;

	public bool IsTracking => _imageSelect.TrackingIndex == _imageIndex;

	public ImageList ImageList
	{
		set
		{
			_imageList = value;
		}
	}

	public int ImageIndex
	{
		set
		{
			_imageIndex = value;
		}
	}

	public ViewDrawMenuImageSelectItem(ViewContextMenuManager viewManager, KryptonContextMenuImageSelect imageSelect, IPaletteTriple palette, ViewLayoutMenuItemSelect layout, NeedPaintHandler needPaint)
		: base(palette, palette, palette, palette, null, null, VisualOrientation.Top, useMnemonic: false)
	{
		_imageSelect = imageSelect;
		_layout = layout;
		_needPaint = needPaint;
		base.ButtonValues = this;
		_controller = new MenuImageSelectController(viewManager, this, layout, needPaint);
		_controller.Click += OnItemClick;
		MouseController = _controller;
		SourceController = _controller;
		KeyController = _controller;
	}

	public override string ToString()
	{
		return "ViewDrawMenuImageSelectItem:" + base.Id;
	}

	public void Track()
	{
		if (_imageSelect.TrackingIndex != _imageIndex)
		{
			_imageSelect.TrackingIndex = _imageIndex;
		}
	}

	public void Untrack()
	{
		if (_imageSelect.TrackingIndex == _imageIndex)
		{
			_imageSelect.TrackingIndex = -1;
		}
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		PaletteState elementState = ElementState;
		if (_imageSelect.TrackingIndex == _imageIndex)
		{
			switch (elementState)
			{
			case PaletteState.Normal:
				ElementState = PaletteState.Tracking;
				break;
			case PaletteState.CheckedNormal:
				ElementState = PaletteState.CheckedTracking;
				break;
			}
		}
		base.Render(context);
		ElementState = elementState;
	}

	public virtual Image GetImage(PaletteState state)
	{
		if (_imageList != null && _imageIndex >= 0)
		{
			return _imageList.Images[_imageIndex];
		}
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return string.Empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	private void OnItemClick(object sender, MouseEventArgs e)
	{
		_imageSelect.SelectedIndex = _imageIndex;
		if (_imageSelect.AutoClose && _layout.CanCloseMenu)
		{
			CancelEventArgs e2 = new CancelEventArgs();
			_layout.Closing(e2);
			if (!e2.Cancel)
			{
				_layout.Close(new CloseReasonEventArgs(ToolStripDropDownCloseReason.ItemClicked));
			}
		}
		_needPaint(this, new NeedLayoutEventArgs(needLayout: true));
	}
}
