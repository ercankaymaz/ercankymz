#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class SeparatorController : ButtonController, IDisposable
{
	public class SeparatorIndicator : Form
	{
		private Rectangle _solidRect;

		public Rectangle SolidRect
		{
			get
			{
				return _solidRect;
			}
			set
			{
				if (_solidRect != value)
				{
					_solidRect = value;
					base.DesktopBounds = _solidRect;
					Refresh();
				}
			}
		}

		public SeparatorIndicator()
		{
			base.FormBorderStyle = FormBorderStyle.None;
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.Manual;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.ShowInTaskbar = false;
			BackColor = Color.Black;
			base.TransparencyKey = Color.Magenta;
			base.Opacity = 0.5;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
			base.Dispose(disposing);
		}

		public void ShowWithoutActivate()
		{
			PI.ShowWindow(base.Handle, 4);
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 132)
			{
				m.Result = (IntPtr)(-1);
			}
			else
			{
				base.WndProc(ref m);
			}
		}
	}

	private static readonly Point _nullPoint = new Point(-1, -1);

	private static readonly Cursor _cursorHSplit = Resources.SplitHorizontal;

	private static readonly Cursor _cursorVSplit = Resources.SplitVertical;

	private static readonly Cursor _cursorHMove = Cursors.SizeNS;

	private static readonly Cursor _cursorVMove = Cursors.SizeWE;

	private bool _drawIndicator;

	private bool _splitCursors;

	private bool _moving;

	private Point _downPosition;

	private Point _movementPoint;

	private int _separatorIncrements;

	private Rectangle _separatorBox;

	private Orientation _separatorOrientation;

	private SeparatorMessageFilter _filter;

	private ISeparatorSource _source;

	private SeparatorIndicator _indicator;

	public bool DrawMoveIndicator
	{
		get
		{
			return _drawIndicator;
		}
		set
		{
			_drawIndicator = value;
		}
	}

	public bool IsMoving => _moving;

	protected override bool IsOperating
	{
		get
		{
			return _source.SeparatorCanMove;
		}
		set
		{
		}
	}

	protected override bool IsOnlyPressedWhenOver
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public SeparatorController(ISeparatorSource source, ViewBase target, bool splitCursors, bool drawIndicator, NeedPaintHandler needPaint)
		: base(target, needPaint)
	{
		Debug.Assert(source != null);
		_source = source;
		_splitCursors = splitCursors;
		_drawIndicator = drawIndicator;
	}

	public void Dispose()
	{
		UnregisterFilter();
	}

	public override void MouseMove(Control c, Point pt)
	{
		if (_source.SeparatorCanMove)
		{
			if (_source.SeparatorOrientation == Orientation.Vertical)
			{
				_source.SeparatorControl.Cursor = (_splitCursors ? _cursorVSplit : _cursorVMove);
			}
			else
			{
				_source.SeparatorControl.Cursor = (_splitCursors ? _cursorHSplit : _cursorHMove);
			}
		}
		if (_moving)
		{
			Point splitter = RecalcClient(pt);
			DrawSeparatorReposition(splitter);
			if (_source.SeparatorMoving(pt, splitter))
			{
				AbortMoving();
			}
		}
		base.MouseMove(c, pt);
	}

	public override bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		bool flag = base.MouseDown(c, pt, button);
		if (flag != _moving)
		{
			if (flag)
			{
				_downPosition = pt;
				_moving = true;
				_separatorBox = _source.SeparatorMoveBox;
				_separatorIncrements = _source.SeparatorIncrements;
				_separatorOrientation = _source.SeparatorOrientation;
				_source.SeparatorControl.Update();
				Point splitter = RecalcClient(pt);
				DrawSeparatorStarting(splitter);
				RegisterFilter();
			}
			else
			{
				_moving = false;
				UnregisterFilter();
				Point splitter2 = RecalcClient(pt);
				_source.SeparatorMoved(pt, splitter2);
			}
		}
		return flag;
	}

	public override void MouseUp(Control c, Point pt, MouseButtons button)
	{
		base.MouseUp(c, pt, button);
		if (base.Captured != _moving)
		{
			_moving = false;
			UnregisterFilter();
			DrawSeparatorRemoved();
			Point splitter = RecalcClient(pt);
			_source.SeparatorMoved(pt, splitter);
		}
	}

	public override void MouseLeave(Control c, ViewBase next)
	{
		if (_moving)
		{
			AbortMoving();
		}
		_source.SeparatorControl.Cursor = Cursors.Default;
		base.MouseLeave(c, next);
	}

	public override void KeyDown(Control c, KeyEventArgs e)
	{
	}

	public override bool KeyUp(Control c, KeyEventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (e.KeyCode == Keys.Escape && _moving)
		{
			AbortMoving();
		}
		return _moving;
	}

	public override void LostFocus(Control c)
	{
		if (_moving)
		{
			AbortMoving();
		}
	}

	public void AbortMoving()
	{
		if (_moving)
		{
			_moving = false;
			base.Captured = false;
			if (_source.SeparatorControl.Capture)
			{
				_source.SeparatorControl.Capture = false;
			}
			UnregisterFilter();
			DrawSeparatorRemoved();
			UpdateTargetState(_source.SeparatorControl);
			_source.SeparatorNotMoved();
		}
	}

	protected void DrawSeparatorStarting(Point splitter)
	{
		_movementPoint = _nullPoint;
		DrawSplitIndicator(splitter);
	}

	protected void DrawSeparatorReposition(Point splitter)
	{
		DrawSplitIndicator(splitter);
	}

	protected void DrawSeparatorRemoved()
	{
		DrawSplitIndicator(_nullPoint);
	}

	private Point RecalcClient(Point pt)
	{
		int num = pt.X - _downPosition.X;
		int num2 = pt.Y - _downPosition.Y;
		if (_separatorOrientation == Orientation.Vertical)
		{
			if (base.Target.ClientLocation.X + num < _separatorBox.Left)
			{
				num = _separatorBox.Left - base.Target.ClientLocation.X;
			}
			if (base.Target.ClientLocation.X + num > _separatorBox.Right)
			{
				num = _separatorBox.Right - base.Target.ClientLocation.X;
			}
		}
		else
		{
			if (base.Target.ClientLocation.Y + num2 < _separatorBox.Top)
			{
				num2 = _separatorBox.Top - base.Target.ClientLocation.Y;
			}
			if (base.Target.ClientLocation.Y + num2 > _separatorBox.Bottom)
			{
				num2 = _separatorBox.Bottom - base.Target.ClientLocation.Y;
			}
		}
		num -= num % _separatorIncrements;
		num2 -= num2 % _separatorIncrements;
		return new Point(base.Target.ClientLocation.X + num, base.Target.ClientLocation.Y + num2);
	}

	private void DrawSplitIndicator(Point newPoint)
	{
		if (DrawMoveIndicator)
		{
			if (newPoint == _nullPoint)
			{
				if (_indicator != null)
				{
					_indicator.Dispose();
					_indicator = null;
				}
			}
			else
			{
				if (_indicator == null)
				{
					_indicator = new SeparatorIndicator();
					_indicator.ShowWithoutActivate();
				}
				_indicator.SolidRect = SplitRectangleFromPoint(newPoint);
			}
		}
		else if (_indicator != null)
		{
			_indicator.Dispose();
			_indicator = null;
		}
		_movementPoint = newPoint;
	}

	private Rectangle SplitRectangleFromPoint(Point pt)
	{
		if (_separatorOrientation == Orientation.Vertical)
		{
			return SplitRectangleFromPoint(pt, base.Target.ClientWidth);
		}
		return SplitRectangleFromPoint(pt, base.Target.ClientHeight);
	}

	private Rectangle SplitRectangleFromPoint(Point pt, int length)
	{
		Rectangle r = ((_separatorOrientation != Orientation.Vertical) ? new Rectangle(_separatorBox.X, pt.Y, base.Target.ClientWidth, length) : new Rectangle(pt.X, _separatorBox.Y, length, base.Target.ClientHeight));
		return _source.SeparatorControl.RectangleToScreen(r);
	}

	private void RegisterFilter()
	{
		if (_filter == null)
		{
			new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Assert();
			try
			{
				_filter = new SeparatorMessageFilter(this);
				Application.AddMessageFilter(_filter);
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}
	}

	private void UnregisterFilter()
	{
		if (_filter != null)
		{
			Application.RemoveMessageFilter(_filter);
			_filter = null;
		}
	}

	private static void DrawSplitIndicator(Rectangle drawRect)
	{
		ControlPaint.FillReversibleRectangle(drawRect, Color.Black);
	}
}
