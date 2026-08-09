#define WINFORMS
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Designer;

internal sealed class _0023_003Dz1pQv2xG5zAUyO0MXW1n8_0024KBPh9v5s3BVqULgqSE_003D<_0023_003DzMP6kxrk_003D> : _0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D where _0023_003DzMP6kxrk_003D : Workspace
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IDesigner _0023_003Dzz_00248bYUrqs_0024xg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected Design _0023_003Dz4KwknW4_003D;

	protected internal IDesigner _0023_003DzTTwFd2nkYe6u()
	{
		return _0023_003Dzz_00248bYUrqs_0024xg;
	}

	protected internal void _0023_003DzJrc__0024g2Ns9e1(IDesigner _0023_003Dzu52ZPXg_003D)
	{
		_0023_003Dzz_00248bYUrqs_0024xg = _0023_003Dzu52ZPXg_003D;
		_0023_003Dz4KwknW4_003D = _0023_003DzTTwFd2nkYe6u().Component as Design;
	}

	public override bool OnMouseUp(Glyph _0023_003DzBxpHhQ0_003D, MouseButtons _0023_003DzwrXhbYA_003D)
	{
		base.OnMouseUp(_0023_003DzBxpHhQ0_003D, _0023_003DzwrXhbYA_003D);
		if (_0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D._0023_003DzwrexRuA_003D != null && _0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D._0023_003DzwrexRuA_003D.Visible)
		{
			return true;
		}
		if (!(_0023_003DzBxpHhQ0_003D is global::_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D<_0023_003DzMP6kxrk_003D, global::_0023_003Dz1pQv2xG5zAUyO0MXW1n8_0024KBPh9v5s3BVqULgqSE_003D<_0023_003DzMP6kxrk_003D>> _0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2))
		{
			return true;
		}
		Point point = _0023_003Dz4KwknW4_003D.PointToClient(Control.MousePosition);
		if (_0023_003DzwrXhbYA_003D == MouseButtons.Left)
		{
			point = ((WorkspaceControlDesignerGeneric<_0023_003DzMP6kxrk_003D>)_0023_003DzTTwFd2nkYe6u())._0023_003DzvVRIqXnU6BzU.ScreenToAdornerWindow(Control.MousePosition);
			if (_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzZevBaRo_003D && _0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzAJGjmyzsrzeC(_0023_003Dz4KwknW4_003D.ActiveViewport, _0023_003Dz4KwknW4_003D.ActiveViewport).Contains(point))
			{
				_0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D._0023_003DzwrexRuA_003D = new ContextMenuStrip();
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312805));
				toolStripMenuItem.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003Dzzt5DLm_0024q0VK9();
				toolStripMenuItem.Click += _0023_003DzdYJEJ02NGaly85VK2g_003D_003D;
				_0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D._0023_003DzwrexRuA_003D.Items.Add(toolStripMenuItem);
				_0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D._0023_003DzwrexRuA_003D.Show(_0023_003Dz4KwknW4_003D, _0023_003Dz4KwknW4_003D.PointToClient(Control.MousePosition));
				_0023_003DzXNxd06nFXGzqshM0hYdwUwMb0uBqmga24tLqMXE_003D._0023_003DzwrexRuA_003D.Focus();
			}
			else
			{
				for (int i = 0; i < _0023_003Dz4KwknW4_003D.Viewports.Count; i++)
				{
					if (_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzbYWaMu9Dx18O(_0023_003Dz4KwknW4_003D.Viewports[i], _0023_003Dz4KwknW4_003D.Viewports[i]).Contains(point))
					{
						if (_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzGquDbrQYYCT8 != i)
						{
							_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzGquDbrQYYCT8 = i;
							_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzZevBaRo_003D = true;
						}
						_0023_003Dz4KwknW4_003D.ActiveViewportIndex = _0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzGquDbrQYYCT8;
						if (_0023_003Dz4KwknW4_003D is _0023_003Dz9yvIszad5kdpzWqoamfk8q5NGEfFxXmFXXZrywI_003D _0023_003Dz9yvIszad5kdpzWqoamfk8q5NGEfFxXmFXXZrywI_003D2)
						{
							_0023_003Dz9yvIszad5kdpzWqoamfk8q5NGEfFxXmFXXZrywI_003D2._0023_003Dzjq269z7u_14k();
						}
						break;
					}
				}
				_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzZevBaRo_003D = !_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D2._0023_003DzZevBaRo_003D;
				_0023_003Dz4KwknW4_003D.Invalidate();
				_0023_003Dz4KwknW4_003D.UpdateDesignModeScene();
			}
		}
		return true;
	}

	private void _0023_003DzdYJEJ02NGaly85VK2g_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzhJgtIpS0EV9xUtYcdg_003D_003D(new global::_0023_003DzRW_0024jW9nQffY2PQF66NmBPMsHZgFjqpF7bYSB0mk_003D<Viewport>(_0023_003Dz4KwknW4_003D.ActiveViewport, _0023_003Dz4KwknW4_003D.Site));
		_0023_003Dz4KwknW4_003D.UpdateDesignModeScene();
		WorkspaceControlDesignerGeneric<_0023_003DzMP6kxrk_003D> obj = (WorkspaceControlDesignerGeneric<_0023_003DzMP6kxrk_003D>)_0023_003DzTTwFd2nkYe6u();
		PropertyDescriptor member = TypeDescriptor.GetProperties(typeof(Design))[_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313322)];
		obj._0023_003DzwIQfEZg_003D.OnComponentChanging(_0023_003Dz4KwknW4_003D, member);
		obj._0023_003DzwIQfEZg_003D.OnComponentChanged(_0023_003Dz4KwknW4_003D, member, null, null);
		_0023_003Dz4KwknW4_003D.Invalidate();
	}
}
