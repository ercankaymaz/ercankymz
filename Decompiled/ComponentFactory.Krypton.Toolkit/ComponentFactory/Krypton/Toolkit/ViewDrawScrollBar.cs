#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawScrollBar : ViewLeaf
{
	private ScrollBar _scrollBar;

	private bool _vertical;

	private bool _removing;

	private bool _shortSize;

	private int _min;

	private int _max;

	private int _largeChange;

	private int _smallChange;

	private int _offset;

	public bool Vertical
	{
		get
		{
			return _vertical;
		}
		set
		{
			if (_vertical != value)
			{
				_vertical = value;
				RemoveScrollBar();
			}
		}
	}

	public bool ShortSize
	{
		get
		{
			return _shortSize;
		}
		set
		{
			_shortSize = value;
		}
	}

	public int ScrollPosition
	{
		get
		{
			if (_scrollBar != null)
			{
				return _scrollBar.Value;
			}
			return 0;
		}
	}

	public event EventHandler ScrollChanged;

	public ViewDrawScrollBar(bool vertical)
	{
		_vertical = vertical;
		_removing = false;
		_shortSize = false;
		_min = 0;
		_max = 100;
		_largeChange = 20;
		_smallChange = 1;
		_offset = 0;
	}

	public override string ToString()
	{
		return "ViewDrawScrollBar:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _scrollBar != null)
		{
			Debug.Assert(!_scrollBar.InvokeRequired);
			if (!_scrollBar.InvokeRequired)
			{
				RemoveScrollBar();
			}
		}
		base.Dispose(disposing);
	}

	public void SetScrollValues(int min, int max, int smallChange, int largeChange, int offset)
	{
		_min = Math.Max(min, 0);
		_max = Math.Max(max, 0);
		_smallChange = Math.Max(smallChange, 0);
		_largeChange = Math.Max(largeChange, 0);
		_offset = Math.Max(offset, 0);
		if (_scrollBar != null)
		{
			_scrollBar.Minimum = _min;
			_scrollBar.Maximum = _max;
			_scrollBar.SmallChange = _smallChange;
			_scrollBar.LargeChange = _largeChange;
			_scrollBar.Value = Math.Max(_min, Math.Min(_max, _offset));
		}
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return new Size(SystemInformation.VerticalScrollBarWidth, SystemInformation.HorizontalScrollBarHeight);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (base.IsDisposed || _removing)
		{
			return;
		}
		ClientRectangle = context.DisplayRectangle;
		if (context.ViewManager.DoNotLayoutControls)
		{
			return;
		}
		CreateScrollBar(context.Control);
		if (!Visible)
		{
			_scrollBar.Hide();
		}
		if (!Enabled)
		{
			_scrollBar.Enabled = false;
		}
		if (ShortSize)
		{
			if (Vertical)
			{
				_scrollBar.SetBounds(ClientLocation.X, ClientLocation.Y, ClientWidth, ClientHeight - SystemInformation.HorizontalScrollBarHeight);
			}
			else
			{
				_scrollBar.SetBounds(ClientLocation.X, ClientLocation.Y, ClientWidth - SystemInformation.VerticalScrollBarWidth, ClientHeight);
			}
		}
		else
		{
			_scrollBar.SetBounds(ClientLocation.X, ClientLocation.Y, ClientWidth, ClientHeight);
		}
		if (Visible)
		{
			_scrollBar.Show();
		}
		if (Enabled)
		{
			_scrollBar.Enabled = true;
		}
	}

	private void CreateScrollBar(Control parent)
	{
		if (_scrollBar == null)
		{
			if (Vertical)
			{
				_scrollBar = new VScrollBar();
			}
			else
			{
				_scrollBar = new HScrollBar();
			}
			_scrollBar.Scroll += OnScrollBarChange;
			_scrollBar.Hide();
			_scrollBar.Minimum = _min;
			_scrollBar.Maximum = _max;
			_scrollBar.SmallChange = _smallChange;
			_scrollBar.LargeChange = _largeChange;
			_scrollBar.Value = _offset;
			CommonHelper.AddControlToParent(parent, _scrollBar);
		}
	}

	private void RemoveScrollBar()
	{
		if (_scrollBar != null && !_removing)
		{
			_removing = true;
			_scrollBar.Scroll -= OnScrollBarChange;
			_scrollBar.Hide();
			CommonHelper.RemoveControlFromParent(_scrollBar);
			_scrollBar.Dispose();
			_scrollBar = null;
			_removing = false;
		}
	}

	private void OnScrollBarChange(object sender, ScrollEventArgs e)
	{
		_scrollBar.Value = e.NewValue;
		if (this.ScrollChanged != null)
		{
			this.ScrollChanged(this, EventArgs.Empty);
		}
	}
}
