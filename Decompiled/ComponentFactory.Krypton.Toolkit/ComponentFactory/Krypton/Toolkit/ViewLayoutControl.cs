#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutControl : ViewLeaf
{
	private ViewControl _viewControl;

	private ViewBase _viewChild;

	private Point _layoutOffset;

	public override bool Visible
	{
		get
		{
			return base.Visible;
		}
		set
		{
			if (base.Visible != value)
			{
				base.Visible = value;
				if (_viewControl != null)
				{
					_viewControl.Visible = value;
				}
			}
		}
	}

	public Point LayoutOffset
	{
		get
		{
			return _layoutOffset;
		}
		set
		{
			_layoutOffset = value;
		}
	}

	public ViewBase ChildView => _viewChild;

	public ViewControl ChildControl => _viewControl;

	public NeedPaintHandler ChildPaintDelegate => _viewControl.NeedPaintDelegate;

	public bool ChildTransparentBackground
	{
		get
		{
			return _viewControl.TransparentBackground;
		}
		set
		{
			_viewControl.TransparentBackground = value;
		}
	}

	public bool InDesignMode
	{
		get
		{
			return _viewControl.InDesignMode;
		}
		set
		{
			_viewControl.InDesignMode = value;
		}
	}

	public ViewLayoutControl(VisualControl rootControl, ViewBase viewChild)
		: this(new ViewControl(rootControl), rootControl, viewChild)
	{
	}

	public ViewLayoutControl(ViewControl viewControl, VisualControl rootControl, ViewBase viewChild)
	{
		Debug.Assert(viewControl != null);
		Debug.Assert(rootControl != null);
		Debug.Assert(viewChild != null);
		_layoutOffset = Point.Empty;
		_viewChild = viewChild;
		_viewChild.Parent = this;
		_viewControl = viewControl;
		_viewControl.ViewLayoutControl = this;
		_viewControl.Visible = false;
		OwningControl = _viewControl;
		CommonHelper.AddControlToParent(rootControl, _viewControl);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_viewControl != null)
			{
				try
				{
					ViewControl viewControl = _viewControl;
					_viewControl = null;
					CommonHelper.RemoveControlFromParent(viewControl);
				}
				catch
				{
				}
			}
			if (_viewChild != null)
			{
				_viewChild.Dispose();
				_viewChild = null;
			}
		}
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewLayoutControl:" + base.Id + " ClientLocation:" + ClientLocation.ToString();
	}

	public void MakeParent(Control c)
	{
		CommonHelper.RemoveControlFromParent(c);
		CommonHelper.AddControlToParent(_viewControl, c);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (_viewControl != null)
		{
			UpdateParent(context.Control);
			using (new CorrectContextControl(context, _viewControl))
			{
				if (_viewChild != null)
				{
					return _viewChild.GetPreferredSize(context);
				}
			}
		}
		return Size.Empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (_viewControl == null)
		{
			return;
		}
		using (new CorrectContextControl(context, _viewControl))
		{
			ClientRectangle = context.DisplayRectangle;
			if (!context.ViewManager.DoNotLayoutControls && _viewControl != null)
			{
				_viewControl.SetBounds(ClientLocation.X, ClientLocation.Y, ClientWidth, ClientHeight);
				_viewControl.Visible = Visible;
				_viewControl.Enabled = Enabled;
				_viewControl.Invalidate();
			}
			context.DisplayRectangle = new Rectangle(LayoutOffset, ClientSize);
			if (_viewChild != null)
			{
				_viewChild.Layout(context);
			}
			context.DisplayRectangle = ClientRectangle;
		}
	}

	public override ViewBase ViewFromPoint(Point pt)
	{
		if (_viewChild != null && ClientRectangle.Contains(pt))
		{
			return _viewChild.ViewFromPoint(new Point(pt.X - ClientLocation.X, pt.Y - ClientLocation.Y));
		}
		return null;
	}

	private void UpdateParent(Control parentControl)
	{
		if (_viewControl != null && parentControl != _viewControl.Parent)
		{
			_viewControl.Location = new Point(-_viewControl.Width, -_viewControl.Height);
			CommonHelper.AddControlToParent(parentControl, _viewControl);
			_viewControl.UpdateParent(parentControl);
		}
	}
}
