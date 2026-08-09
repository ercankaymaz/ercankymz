using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Designer;

internal sealed class _0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D<_0023_003DzMP6kxrk_003D, _0023_003Dz9jrlnWk_003D> : Glyph where _0023_003DzMP6kxrk_003D : Workspace where _0023_003Dz9jrlnWk_003D : global::_0023_003Dz1pQv2xG5zAUyO0MXW1n8_0024KBPh9v5s3BVqULgqSE_003D<_0023_003DzMP6kxrk_003D>, new()
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected Cursor _0023_003Dz0Oiwgb5BYXps = Cursors.Hand;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BehaviorService _0023_003Dzp_0024plObs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IComponentChangeService _0023_003DzwIQfEZg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ISelectionService _0023_003DzQtRuhbs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IDesigner _0023_003DzdBfD8S3WU4jE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Adorner _0023_003DzEhrC2rk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected Design _0023_003Dz4KwknW4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzRqw49EiafQv3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Rectangle _0023_003Dz9mjC4DzfhATt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz9DwsgoGgfxV9PmC65CSoWHE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int _0023_003DzGquDbrQYYCT8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected internal bool _0023_003DzZevBaRo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzgNbO6GmBljl7 = -1;

	public _0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D(BehaviorService _0023_003Dzp_0024plObs_003D, IComponentChangeService _0023_003DzwIQfEZg_003D, ISelectionService _0023_003DzQtRuhbs_003D, IDesigner _0023_003DzdBfD8S3WU4jE, Adorner _0023_003DzFK5bL10_003D)
	{
		_0023_003Dz9jrlnWk_003D val = new _0023_003Dz9jrlnWk_003D();
		val._0023_003DzJrc__0024g2Ns9e1(_0023_003DzdBfD8S3WU4jE);
		base._002Ector(val);
		_0023_003DzcQOlKrMUke_00249(10);
		this._0023_003Dzp_0024plObs_003D = _0023_003Dzp_0024plObs_003D;
		this._0023_003DzwIQfEZg_003D = _0023_003DzwIQfEZg_003D;
		this._0023_003DzQtRuhbs_003D = _0023_003DzQtRuhbs_003D;
		this._0023_003DzdBfD8S3WU4jE = _0023_003DzdBfD8S3WU4jE;
		_0023_003DzEhrC2rk_003D = _0023_003DzFK5bL10_003D;
		_0023_003Dz4KwknW4_003D = this._0023_003DzdBfD8S3WU4jE.Component as Design;
		this._0023_003DzQtRuhbs_003D.SelectionChanged += delegate
		{
			if (this._0023_003DzQtRuhbs_003D.PrimarySelection == _0023_003Dz4KwknW4_003D)
			{
				_0023_003DzEhrC2rk_003D.Enabled = true;
			}
			else
			{
				_0023_003DzEhrC2rk_003D.Enabled = false;
			}
		};
		this._0023_003DzwIQfEZg_003D.ComponentChanged += _0023_003Dz_Yj30M32HonS;
	}

	private Rectangle _0023_003DzV6ZoCYprxYRuQyZqYw_003D_003D()
	{
		return new Rectangle(default(Point), _0023_003Dz4KwknW4_003D.Parent.Parent.ClientSize);
	}

	protected internal Rectangle _0023_003DzbYWaMu9Dx18O(IUserInterfaceElement _0023_003DzxwTupVc_003D, Viewport _0023_003Dz7Tv1nWI_003D)
	{
		Rectangle result = _0023_003DzyCEhQyU_003D(_0023_003DzxwTupVc_003D, _0023_003Dz7Tv1nWI_003D);
		result.Inflate(4, 4);
		return result;
	}

	public Rectangle _0023_003DzyCEhQyU_003D(IUserInterfaceElement _0023_003DzxwTupVc_003D, Viewport _0023_003Dz7Tv1nWI_003D)
	{
		Rectangle bounds = _0023_003DzxwTupVc_003D.GetBounds(_0023_003Dz7Tv1nWI_003D);
		Point point = _0023_003Dzp_0024plObs_003D.ControlToAdornerWindow(_0023_003Dz4KwknW4_003D);
		return new Rectangle(point.X + bounds.X + _0023_003Dz8R9EWzxJZLUi(), point.Y + bounds.Y + _0023_003Dz8R9EWzxJZLUi(), bounds.Width - 2 * _0023_003Dz8R9EWzxJZLUi(), bounds.Height - 2 * _0023_003Dz8R9EWzxJZLUi());
	}

	protected int _0023_003Dz8R9EWzxJZLUi()
	{
		return _0023_003Dz9DwsgoGgfxV9PmC65CSoWHE_003D;
	}

	protected void _0023_003DzcQOlKrMUke_00249(int _0023_003Dzu52ZPXg_003D)
	{
		_0023_003Dz9DwsgoGgfxV9PmC65CSoWHE_003D = _0023_003Dzu52ZPXg_003D;
	}

	public override void Paint(PaintEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		if (_0023_003DzgNbO6GmBljl7 >= 0 && _0023_003DzgNbO6GmBljl7 < _0023_003Dz4KwknW4_003D.Viewports.Count)
		{
			if (!_0023_003DzZevBaRo_003D || _0023_003DzgNbO6GmBljl7 != _0023_003DzGquDbrQYYCT8)
			{
				Rectangle _0023_003DztGtfeZY_003D = _0023_003DzyCEhQyU_003D(_0023_003Dz4KwknW4_003D.Viewports[_0023_003DzgNbO6GmBljl7], _0023_003Dz4KwknW4_003D.Viewports[_0023_003DzgNbO6GmBljl7]);
				_0023_003DzcBBeFSeUGn44AZICvg_003D_003D(_0023_003Dz9I8ZVlc_003D, _0023_003DztGtfeZY_003D);
			}
			if (_0023_003DzZevBaRo_003D)
			{
				Rectangle _0023_003DztGtfeZY_003D2 = _0023_003DzyCEhQyU_003D(_0023_003Dz4KwknW4_003D.Viewports[_0023_003DzGquDbrQYYCT8], _0023_003Dz4KwknW4_003D.Viewports[_0023_003DzGquDbrQYYCT8]);
				_0023_003DzQvJf4RbBCbds(_0023_003Dz9I8ZVlc_003D, _0023_003DztGtfeZY_003D2, _0023_003Dz4KwknW4_003D.ActiveViewport, _0023_003Dz4KwknW4_003D.ActiveViewport);
			}
		}
	}

	protected void _0023_003DzQvJf4RbBCbds(PaintEventArgs _0023_003Dz9I8ZVlc_003D, Rectangle _0023_003DztGtfeZY_003D, IUserInterfaceElement _0023_003DzxwTupVc_003D, Viewport _0023_003Dz7Tv1nWI_003D)
	{
		Pen pen = new Pen(Color.White, 3f);
		_0023_003Dz9I8ZVlc_003D.Graphics.DrawRectangle(pen, _0023_003DztGtfeZY_003D);
		Pen pen2 = new Pen(Color.Black);
		_0023_003Dz9I8ZVlc_003D.Graphics.DrawRectangle(pen2, _0023_003DztGtfeZY_003D);
		Rectangle rect = _0023_003DzAJGjmyzsrzeC(_0023_003DzxwTupVc_003D, _0023_003Dz7Tv1nWI_003D);
		_0023_003Dz9I8ZVlc_003D.Graphics.DrawImage(_0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzVEqH2ECjZgkk(), rect);
	}

	protected static void _0023_003DzcBBeFSeUGn44AZICvg_003D_003D(PaintEventArgs _0023_003Dz9I8ZVlc_003D, Rectangle _0023_003DztGtfeZY_003D)
	{
		Pen pen = new Pen(Color.Blue);
		pen.DashStyle = DashStyle.Dash;
		_0023_003Dz9I8ZVlc_003D.Graphics.DrawRectangle(pen, _0023_003DztGtfeZY_003D);
	}

	internal Rectangle _0023_003DzAJGjmyzsrzeC(IUserInterfaceElement _0023_003DzxwTupVc_003D, Viewport _0023_003Dz7Tv1nWI_003D)
	{
		if (_0023_003DzGquDbrQYYCT8 < 0)
		{
			return Rectangle.Empty;
		}
		return WorkspaceControlDesigner._0023_003DzAJGjmyzsrzeC(_0023_003DzyCEhQyU_003D(_0023_003DzxwTupVc_003D, _0023_003Dz7Tv1nWI_003D));
	}

	protected bool _0023_003DzyrxfwLHzioD6fBxdJA_003D_003D(Point _0023_003DzekdNBIU_003D)
	{
		Rectangle rectangle = _0023_003DzV6ZoCYprxYRuQyZqYw_003D_003D();
		Point pt = new Point(_0023_003DzekdNBIU_003D.X + _0023_003Dz4KwknW4_003D.Parent.Location.X, _0023_003DzekdNBIU_003D.Y + _0023_003Dz4KwknW4_003D.Parent.Location.Y);
		return rectangle.Contains(pt);
	}

	public override Cursor GetHitTest(Point _0023_003DzekdNBIU_003D)
	{
		Cursor result = null;
		if (_0023_003DzSKXLdewNZ3P5(_0023_003DzekdNBIU_003D))
		{
			return null;
		}
		int num = -1;
		for (int i = 0; i < _0023_003Dz4KwknW4_003D.Viewports.Count; i++)
		{
			Viewport viewport = _0023_003Dz4KwknW4_003D.Viewports[i];
			if (_0023_003DzbYWaMu9Dx18O(viewport, viewport).Contains(_0023_003DzekdNBIU_003D))
			{
				result = _0023_003Dz0Oiwgb5BYXps;
				num = i;
			}
		}
		if (num != _0023_003DzgNbO6GmBljl7)
		{
			_0023_003Dz4KwknW4_003D.Invalidate();
			_0023_003DzgNbO6GmBljl7 = num;
		}
		return result;
	}

	protected bool _0023_003DzSKXLdewNZ3P5(Point _0023_003DzekdNBIU_003D)
	{
		if (_0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D._0023_003DzwrexRuA_003D != null && _0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D._0023_003DzwrexRuA_003D.Visible)
		{
			return true;
		}
		if (!_0023_003DzyrxfwLHzioD6fBxdJA_003D_003D(_0023_003DzekdNBIU_003D))
		{
			return true;
		}
		if (_0023_003DztNoF0uYNHYg0(_0023_003DzekdNBIU_003D))
		{
			return true;
		}
		return false;
	}

	private bool _0023_003DztNoF0uYNHYg0(Point _0023_003DzekdNBIU_003D)
	{
		for (int i = 0; i < _0023_003Dz4KwknW4_003D.Parent.Controls.Count; i++)
		{
			Control control = _0023_003Dz4KwknW4_003D.Parent.Controls[i];
			if (control != _0023_003Dz4KwknW4_003D)
			{
				Rectangle rectangle = new Rectangle(_0023_003Dzp_0024plObs_003D.ControlToAdornerWindow(control), control.ClientRectangle.Size);
				if (rectangle.Contains(_0023_003DzekdNBIU_003D))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void _0023_003Dz5pw_wO4u_0024nG_0024(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		if (_0023_003DzQtRuhbs_003D.PrimarySelection == _0023_003Dz4KwknW4_003D)
		{
			_0023_003DzEhrC2rk_003D.Enabled = true;
		}
		else
		{
			_0023_003DzEhrC2rk_003D.Enabled = false;
		}
	}

	private void _0023_003Dz_Yj30M32HonS(object _0023_003DzUNNLWvM_003D, ComponentChangedEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		if (_0023_003Dz9I8ZVlc_003D.Component != _0023_003Dz4KwknW4_003D || _0023_003Dz9I8ZVlc_003D.Member == null)
		{
			return;
		}
		if (_0023_003Dz9I8ZVlc_003D.Member.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318314) || _0023_003Dz9I8ZVlc_003D.Member.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318301) || _0023_003Dz9I8ZVlc_003D.Member.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318274) || _0023_003Dz9I8ZVlc_003D.Member.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318133) || _0023_003Dz9I8ZVlc_003D.Member.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318137))
		{
			_0023_003DzEhrC2rk_003D.Invalidate();
		}
		else if (_0023_003Dz9I8ZVlc_003D.Member.Name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318122))
		{
			if (_0023_003DzGquDbrQYYCT8 >= _0023_003Dz4KwknW4_003D.Viewports.Count)
			{
				_0023_003DzGquDbrQYYCT8 = -1;
			}
			if (_0023_003DzgNbO6GmBljl7 >= _0023_003Dz4KwknW4_003D.Viewports.Count)
			{
				_0023_003DzgNbO6GmBljl7 = -1;
			}
		}
	}
}
