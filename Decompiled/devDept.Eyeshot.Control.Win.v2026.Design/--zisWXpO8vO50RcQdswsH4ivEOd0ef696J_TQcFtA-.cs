using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Designer;
using devDept.Geometry;

internal sealed class _0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D : PictureBox
{
	private sealed class _0023_003Dz7E4lOUOqhCQt
	{
		public bool _0023_003Dzw9F_M20_003D;

		public IUserInterfaceElement _0023_003DzxwTupVc_003D;

		public _0023_003Dz7E4lOUOqhCQt(IUserInterfaceElement _0023_003DzxwTupVc_003D)
		{
			this._0023_003DzxwTupVc_003D = _0023_003DzxwTupVc_003D;
		}
	}

	public delegate void _0023_003DzLjkddSBFPDOE();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzLjkddSBFPDOE _0023_003Dz1le6exU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, _0023_003Dz7E4lOUOqhCQt> _0023_003Dz1fRkZKo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Panel _0023_003DzfijAliOFx7hL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Viewport _0023_003Dz7Tv1nWI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ISite _0023_003Dz9iWEovk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzO7pN9PeNdPIG = string.Empty;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Rectangle _0023_003DzxVj9rXisF9sY;

	public void _0023_003DzbTfUwZ0fkNPR(_0023_003DzLjkddSBFPDOE _0023_003Dzu52ZPXg_003D)
	{
		_0023_003DzLjkddSBFPDOE _0023_003DzLjkddSBFPDOE2 = _0023_003Dz1le6exU_003D;
		_0023_003DzLjkddSBFPDOE _0023_003DzLjkddSBFPDOE3;
		do
		{
			_0023_003DzLjkddSBFPDOE3 = _0023_003DzLjkddSBFPDOE2;
			_0023_003DzLjkddSBFPDOE value = (_0023_003DzLjkddSBFPDOE)Delegate.Combine(_0023_003DzLjkddSBFPDOE3, _0023_003Dzu52ZPXg_003D);
			_0023_003DzLjkddSBFPDOE2 = Interlocked.CompareExchange(ref _0023_003Dz1le6exU_003D, value, _0023_003DzLjkddSBFPDOE3);
		}
		while ((object)_0023_003DzLjkddSBFPDOE2 != _0023_003DzLjkddSBFPDOE3);
	}

	public void _0023_003Dz4USa9ElFVuw_0024(_0023_003DzLjkddSBFPDOE _0023_003Dzu52ZPXg_003D)
	{
		_0023_003DzLjkddSBFPDOE _0023_003DzLjkddSBFPDOE2 = _0023_003Dz1le6exU_003D;
		_0023_003DzLjkddSBFPDOE _0023_003DzLjkddSBFPDOE3;
		do
		{
			_0023_003DzLjkddSBFPDOE3 = _0023_003DzLjkddSBFPDOE2;
			_0023_003DzLjkddSBFPDOE value = (_0023_003DzLjkddSBFPDOE)Delegate.Remove(_0023_003DzLjkddSBFPDOE3, _0023_003Dzu52ZPXg_003D);
			_0023_003DzLjkddSBFPDOE2 = Interlocked.CompareExchange(ref _0023_003Dz1le6exU_003D, value, _0023_003DzLjkddSBFPDOE3);
		}
		while ((object)_0023_003DzLjkddSBFPDOE2 != _0023_003DzLjkddSBFPDOE3);
	}

	public void _0023_003Dzdjd7G7o_003D(Viewport _0023_003Dz7Tv1nWI_003D, Panel _0023_003DzfijAliOFx7hL, _0023_003DzLjkddSBFPDOE _0023_003DzLjkddSBFPDOE, ISite _0023_003Dz9iWEovk_003D)
	{
		this._0023_003DzfijAliOFx7hL = _0023_003DzfijAliOFx7hL;
		this._0023_003Dz7Tv1nWI_003D = _0023_003Dz7Tv1nWI_003D;
		this._0023_003Dz9iWEovk_003D = _0023_003Dz9iWEovk_003D;
		_0023_003Dz1fRkZKo_003D = new Dictionary<string, _0023_003Dz7E4lOUOqhCQt>();
		_0023_003DzrPgD_eAQJt6e(_0023_003Dz7Tv1nWI_003D);
		_0023_003DzbTfUwZ0fkNPR(_0023_003DzLjkddSBFPDOE);
	}

	private void _0023_003DzrPgD_eAQJt6e(Viewport _0023_003Dz7Tv1nWI_003D)
	{
		_0023_003Dz1fRkZKo_003D.Clear();
		if (_0023_003Dz7Tv1nWI_003D.ViewCubeIcon.Visible)
		{
			_0023_003Dz1fRkZKo_003D.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312935), new _0023_003Dz7E4lOUOqhCQt(_0023_003Dz7Tv1nWI_003D.ViewCubeIcon));
		}
		if (_0023_003Dz7Tv1nWI_003D.Histogram.Visible)
		{
			_0023_003Dz1fRkZKo_003D.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312920), new _0023_003Dz7E4lOUOqhCQt(_0023_003Dz7Tv1nWI_003D.Histogram));
		}
		for (int i = 0; i < _0023_003Dz7Tv1nWI_003D.OriginSymbols.Length; i++)
		{
			if (_0023_003Dz7Tv1nWI_003D.OriginSymbols[i].Visible)
			{
				_0023_003Dz1fRkZKo_003D.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312904) + i, new _0023_003Dz7E4lOUOqhCQt(_0023_003Dz7Tv1nWI_003D.OriginSymbols[i]));
			}
		}
		if (_0023_003Dz7Tv1nWI_003D.CoordinateSystemIcon.Visible)
		{
			_0023_003Dz1fRkZKo_003D.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312756), new _0023_003Dz7E4lOUOqhCQt(_0023_003Dz7Tv1nWI_003D.CoordinateSystemIcon));
		}
		for (int j = 0; j < _0023_003Dz7Tv1nWI_003D.ToolBars.Length; j++)
		{
			if (_0023_003Dz7Tv1nWI_003D.ToolBars[j].Visible)
			{
				_0023_003Dz1fRkZKo_003D.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312749) + j, new _0023_003Dz7E4lOUOqhCQt(_0023_003Dz7Tv1nWI_003D.ToolBars[j]));
			}
		}
		for (int k = 0; k < _0023_003Dz7Tv1nWI_003D.Legends.Length; k++)
		{
			if (_0023_003Dz7Tv1nWI_003D.Legends[k].Visible)
			{
				_0023_003Dz1fRkZKo_003D.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312734) + k, new _0023_003Dz7E4lOUOqhCQt(_0023_003Dz7Tv1nWI_003D.Legends[k]));
			}
		}
		for (int l = 0; l < _0023_003Dz7Tv1nWI_003D.Grids.Length; l++)
		{
			if (_0023_003Dz7Tv1nWI_003D.Grids[l].Visible)
			{
				_0023_003Dz1fRkZKo_003D.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312720) + l, new _0023_003Dz7E4lOUOqhCQt(_0023_003Dz7Tv1nWI_003D.Grids[l]));
			}
		}
		if (_0023_003Dz7Tv1nWI_003D.ScaleBar.Visible)
		{
			_0023_003Dz1fRkZKo_003D.Add(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312820), new _0023_003Dz7E4lOUOqhCQt(_0023_003Dz7Tv1nWI_003D.ScaleBar));
		}
	}

	public void _0023_003Dz3ELtEkrJanRt(Viewport _0023_003Dz7Tv1nWI_003D, MouseEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		bool flag = false;
		if (_0023_003DzxVj9rXisF9sY != Rectangle.Empty && _0023_003DzxVj9rXisF9sY.Contains(_0023_003Dz9I8ZVlc_003D.Location))
		{
			Cursor = Cursors.Hand;
			return;
		}
		if (Cursor == Cursors.Hand)
		{
			Cursor = Cursors.Default;
		}
		Rectangle _0023_003Dz9f56rAo_003D = Rectangle.Empty;
		string key = _0023_003DzO7pN9PeNdPIG;
		foreach (KeyValuePair<string, _0023_003Dz7E4lOUOqhCQt> item in _0023_003Dz1fRkZKo_003D)
		{
			Rectangle rectangle = _0023_003Dz_0024jqP_okXYYBwBL37hA_003D_003D(_0023_003Dz7Tv1nWI_003D, item.Value._0023_003DzxwTupVc_003D);
			if (rectangle.Contains(_0023_003Dz9I8ZVlc_003D.Location) && _0023_003DzfZepMI1z6gRQ(_0023_003Dz9I8ZVlc_003D.Location, rectangle, _0023_003Dz9f56rAo_003D))
			{
				_0023_003Dz9f56rAo_003D = rectangle;
				flag = true;
				if (item.Key != _0023_003DzO7pN9PeNdPIG)
				{
					key = item.Key;
				}
			}
		}
		if (key != _0023_003DzO7pN9PeNdPIG)
		{
			_0023_003DzO7pN9PeNdPIG = key;
			Invalidate();
		}
		if (!flag && !string.IsNullOrEmpty(_0023_003DzO7pN9PeNdPIG))
		{
			_0023_003DzO7pN9PeNdPIG = string.Empty;
			Invalidate();
		}
	}

	private bool _0023_003DzfZepMI1z6gRQ(Point _0023_003DzQyIXv0E_003D, Rectangle _0023_003Dz7pEmBP0_003D, Rectangle _0023_003Dz9f56rAo_003D)
	{
		if (_0023_003Dz9f56rAo_003D.IsEmpty)
		{
			return true;
		}
		Vector2D vector2D = Vector2D.Subtract(new Point2D(_0023_003Dz7pEmBP0_003D.X, _0023_003Dz7pEmBP0_003D.Y), new Point2D(_0023_003DzQyIXv0E_003D.X, _0023_003DzQyIXv0E_003D.Y));
		Vector2D vector2D2 = Vector2D.Subtract(new Point2D(_0023_003Dz9f56rAo_003D.X, _0023_003Dz9f56rAo_003D.Y), new Point2D(_0023_003DzQyIXv0E_003D.X, _0023_003DzQyIXv0E_003D.Y));
		if (vector2D.LengthSquared < vector2D2.LengthSquared)
		{
			return true;
		}
		return false;
	}

	private Rectangle _0023_003Dz_0024jqP_okXYYBwBL37hA_003D_003D(Viewport _0023_003Dz7Tv1nWI_003D, IUserInterfaceElement _0023_003DzWOPQrjk_003D)
	{
		Rectangle bounds = _0023_003DzWOPQrjk_003D.GetBounds(_0023_003Dz7Tv1nWI_003D);
		bounds.Location = new Point(bounds.Location.X - _0023_003Dz7Tv1nWI_003D.Location.X, bounds.Location.Y - _0023_003Dz7Tv1nWI_003D.Location.Y);
		int num = 4;
		int num2 = _0023_003Dz7Tv1nWI_003D.Size.Width - num;
		int num3 = _0023_003Dz7Tv1nWI_003D.Size.Height - num;
		if (bounds.Left < num)
		{
			bounds.Width -= num - bounds.Left;
			bounds.Location = new Point(num, bounds.Location.Y);
		}
		if (bounds.Top < num)
		{
			bounds.Height -= num - bounds.Top;
			bounds.Location = new Point(bounds.Location.X, num);
		}
		int num4 = num2 - bounds.Right - 3;
		int num5 = num3 - bounds.Bottom - 3;
		if (num4 < 0)
		{
			bounds.Size = new Size(bounds.Size.Width + num4, bounds.Size.Height);
		}
		if (num5 < 0)
		{
			bounds.Size = new Size(bounds.Size.Width, bounds.Size.Height + num5);
		}
		return bounds;
	}

	internal void _0023_003DzaFj_MrNl8OgL(Viewport _0023_003Dz7Tv1nWI_003D, PaintEventArgs _0023_003DzNoBwQrg_003D)
	{
		_0023_003DzxVj9rXisF9sY = Rectangle.Empty;
		foreach (KeyValuePair<string, _0023_003Dz7E4lOUOqhCQt> item in _0023_003Dz1fRkZKo_003D)
		{
			if (item.Value._0023_003Dzw9F_M20_003D)
			{
				Rectangle rectangle = _0023_003Dz_0024jqP_okXYYBwBL37hA_003D_003D(_0023_003Dz7Tv1nWI_003D, item.Value._0023_003DzxwTupVc_003D);
				Pen pen = new Pen(Color.White, 3f);
				_0023_003DzNoBwQrg_003D.Graphics.DrawRectangle(pen, rectangle);
				Pen pen2 = new Pen(Color.Black);
				_0023_003DzNoBwQrg_003D.Graphics.DrawRectangle(pen2, rectangle);
				_0023_003DzxVj9rXisF9sY = WorkspaceControlDesigner._0023_003DzAJGjmyzsrzeC(rectangle);
				Bitmap bitmap = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzVEqH2ECjZgkk();
				_0023_003DzNoBwQrg_003D.Graphics.DrawImage(bitmap, _0023_003DzxVj9rXisF9sY);
			}
		}
		if (_0023_003Dz1fRkZKo_003D.ContainsKey(_0023_003DzO7pN9PeNdPIG) && !_0023_003Dz1fRkZKo_003D[_0023_003DzO7pN9PeNdPIG]._0023_003Dzw9F_M20_003D)
		{
			Pen pen3 = new Pen(Color.Blue);
			pen3.DashStyle = DashStyle.Dash;
			_0023_003DzNoBwQrg_003D.Graphics.DrawRectangle(pen3, _0023_003Dz_0024jqP_okXYYBwBL37hA_003D_003D(_0023_003Dz7Tv1nWI_003D, _0023_003Dz1fRkZKo_003D[_0023_003DzO7pN9PeNdPIG]._0023_003DzxwTupVc_003D));
		}
	}

	internal void _0023_003Dzybt1vvbQ_0024v4i(object _0023_003DzUNNLWvM_003D, MouseEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		if (_0023_003DzxVj9rXisF9sY.Contains(_0023_003Dz9I8ZVlc_003D.Location))
		{
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312805));
			foreach (KeyValuePair<string, _0023_003Dz7E4lOUOqhCQt> item in _0023_003Dz1fRkZKo_003D)
			{
				if (item.Value._0023_003Dzw9F_M20_003D)
				{
					if (item.Key == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312935))
					{
						toolStripMenuItem.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz2tAdLapJks4G();
					}
					else if (item.Key == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312920))
					{
						toolStripMenuItem.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzoWqO4uF6s1B9();
					}
					else if (item.Key == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312786))
					{
						toolStripMenuItem.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzQdXUIb0GxLaB();
					}
					else if (item.Key == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312756))
					{
						toolStripMenuItem.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dz6jcsRYXDVi4a6RrGAw_003D_003D();
					}
					else if (item.Key.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433)))
					{
						toolStripMenuItem.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRqCycrvFUsVd();
					}
					else if (item.Key.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312783)))
					{
						toolStripMenuItem.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzRSsGqtH7p64jgyOwNg_003D_003D();
					}
					else if (item.Key.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312626)))
					{
						toolStripMenuItem.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dzs_Va_00246fxxzEt();
					}
				}
			}
			toolStripMenuItem.Click += _0023_003DzCArAPGA_003D;
			contextMenuStrip.Items.Add(toolStripMenuItem);
			contextMenuStrip.Show(this, PointToClient(Control.MousePosition));
			return;
		}
		if (!string.IsNullOrEmpty(_0023_003DzO7pN9PeNdPIG))
		{
			if (!_0023_003Dz1fRkZKo_003D[_0023_003DzO7pN9PeNdPIG]._0023_003Dzw9F_M20_003D)
			{
				foreach (KeyValuePair<string, _0023_003Dz7E4lOUOqhCQt> item2 in _0023_003Dz1fRkZKo_003D)
				{
					item2.Value._0023_003Dzw9F_M20_003D = false;
				}
				_0023_003Dz1fRkZKo_003D[_0023_003DzO7pN9PeNdPIG]._0023_003Dzw9F_M20_003D = true;
			}
			else
			{
				_0023_003Dz1fRkZKo_003D[_0023_003DzO7pN9PeNdPIG]._0023_003Dzw9F_M20_003D = false;
			}
		}
		Invalidate();
	}

	private void _0023_003DzCArAPGA_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		foreach (KeyValuePair<string, _0023_003Dz7E4lOUOqhCQt> item in _0023_003Dz1fRkZKo_003D)
		{
			if (item.Value._0023_003Dzw9F_M20_003D)
			{
				if (item.Key == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312935))
				{
					_0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D(new UIElementDesignerForm<ViewCubeIcon>(_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D.ViewCubeIcon, _0023_003Dz9iWEovk_003D));
					break;
				}
				if (item.Key == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312920))
				{
					_0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D(new UIElementDesignerForm<Histogram>(_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D.Histogram, _0023_003Dz9iWEovk_003D));
					break;
				}
				if (item.Key.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312786)))
				{
					int num = int.Parse(item.Key.Substring(12));
					_0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D(new UIElementDesignerForm<OriginSymbol>(_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D.OriginSymbols[num], _0023_003Dz9iWEovk_003D));
					break;
				}
				if (item.Key == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312756))
				{
					_0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D(new UIElementDesignerForm<CoordinateSystemIcon>(_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D.CoordinateSystemIcon, _0023_003Dz9iWEovk_003D));
					break;
				}
				if (item.Key.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433)))
				{
					int num2 = int.Parse(item.Key.Substring(8));
					_0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D(new UIElementDesignerForm<devDept.Eyeshot.Control.ToolBar>(_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D.ToolBars[num2], _0023_003Dz9iWEovk_003D));
					break;
				}
				if (item.Key.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312783)))
				{
					int num3 = int.Parse(item.Key.Substring(7));
					_0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D(new UIElementDesignerForm<Legend>(_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D.Legends[num3], _0023_003Dz9iWEovk_003D));
					break;
				}
				if (item.Key.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312626)))
				{
					int num4 = int.Parse(item.Key.Substring(5));
					_0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D(new UIElementDesignerForm<Grid>(_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D.Grids[num4], _0023_003Dz9iWEovk_003D));
					break;
				}
				if (item.Key.StartsWith(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312820)))
				{
					_0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D(new UIElementDesignerForm<ScaleBar>(_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D.ScaleBar, _0023_003Dz9iWEovk_003D));
					break;
				}
			}
		}
	}

	private void _0023_003DzcAUV7lnQ9ACpHOx1rVAVAfE_003D<T>(UIElementDesignerForm<T> _0023_003Dz7hb35l0_003D) where T : class, IUserInterfaceElement, ICloneable
	{
		_0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(_0023_003Dz7hb35l0_003D);
		_0023_003DzrPgD_eAQJt6e(_0023_003Dz7Tv1nWI_003D);
		_0023_003Dz1le6exU_003D();
	}

	internal static void _0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D<T>(UIElementDesignerForm<T> _0023_003Dz7hb35l0_003D) where T : class, IUserInterfaceElement, ICloneable
	{
		_0023_003Dz7hb35l0_003D._0023_003DzUTc9_dmeZ1_E();
		_0023_003Dz7hb35l0_003D.ShowDialog();
	}

	private Size _0023_003DzNluu7bBpdFIA()
	{
		return new Size(base.Size.Width - 2, base.Size.Height - 2);
	}

	internal static void _0023_003DzHDE0E4BX9W_c(Control _0023_003Dznpp9uyU_003D, Panel _0023_003DzfijAliOFx7hL)
	{
		int num = ((_0023_003DzfijAliOFx7hL.Width >= _0023_003Dznpp9uyU_003D.Width) ? ((_0023_003DzfijAliOFx7hL.Width - _0023_003Dznpp9uyU_003D.Width) / 2) : _0023_003Dznpp9uyU_003D.Location.X);
		int num2 = ((_0023_003DzfijAliOFx7hL.Height >= _0023_003Dznpp9uyU_003D.Height) ? ((_0023_003DzfijAliOFx7hL.Height - _0023_003Dznpp9uyU_003D.Height) / 2) : _0023_003Dznpp9uyU_003D.Location.Y);
		_0023_003Dznpp9uyU_003D.Location = new Point(num, num2);
	}

	internal void _0023_003Dzwty0fR0_003D(Viewport _0023_003Dz7Tv1nWI_003D)
	{
		_0023_003Dz1fRkZKo_003D.Clear();
		_0023_003DzrPgD_eAQJt6e(_0023_003Dz7Tv1nWI_003D);
	}
}
