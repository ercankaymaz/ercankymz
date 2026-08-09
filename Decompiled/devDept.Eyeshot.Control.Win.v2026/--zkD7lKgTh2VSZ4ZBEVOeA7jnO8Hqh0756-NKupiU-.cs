using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using devDept.Diagnostic;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.MultiTouch;
using devDept.Eyeshot.Control.MultiTouch.Manipulation;
using devDept.Eyeshot.Control.MultiTouch.Win32Helper;
using devDept.Geometry;

internal sealed class _0023_003DzkD7lKgTh2VSZ4ZBEVOeA7jnO8Hqh0756_0024NKupiU_003D
{
	private struct _0023_003DzTnYmsrxMA7s0(Point _0023_003DzFcXCpKE_003D, Point _0023_003DzZtyBgtw_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point _0023_003DzpBTIMwo_003D = _0023_003DzFcXCpKE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point _0023_003Dz_0024YfjOuY_003D = _0023_003DzZtyBgtw_003D;
	}

	private TouchHandler _0023_003Dz8bcwa6F0_0024iPFyc7okw_003D_003D;

	private ManipulationProcessor _0023_003Dz8ssHCIs_003D;

	private _0023_003DzTnYmsrxMA7s0 _0023_003DzX_6VGrAXIa3X;

	private _0023_003DzTnYmsrxMA7s0 _0023_003Dz4931B1GZD8u4;

	private Workspace _0023_003Dz0TvaYNo_003D;

	private bool _0023_003DzEzFEfbg_003D;

	internal int _0023_003DzFxG1C65aynj9;

	private int _0023_003DzGgCJSJSkWGZW = -1;

	private bool _0023_003Dzt7wuDQyUa9jphQUSvw_003D_003D;

	public _0023_003DzkD7lKgTh2VSZ4ZBEVOeA7jnO8Hqh0756_0024NKupiU_003D(Workspace _0023_003Dz0TvaYNo_003D)
	{
		this._0023_003Dz0TvaYNo_003D = _0023_003Dz0TvaYNo_003D;
		OperatingSystem oSVersion = Environment.OSVersion;
		if (oSVersion.Platform == PlatformID.Win32NT && oSVersion.Version.Major >= 6 && Handler.DigitizerCapabilities.IsMultiTouchReady)
		{
			_0023_003Dz8ssHCIs_003D = new ManipulationProcessor(ProcessorManipulations.ALL);
			_0023_003Dz8bcwa6F0_0024iPFyc7okw_003D_003D = Factory.CreateHandler<TouchHandler>(_0023_003Dz0TvaYNo_003D._0023_003DzZUohT3Y_003D);
			_0023_003Dz8bcwa6F0_0024iPFyc7okw_003D_003D.ParentWF = _0023_003Dz0TvaYNo_003D;
			_0023_003Dz0TvaYNo_003D._0023_003DzoOUvN_zrx2mU0zQebQ_003D_003D();
			_0023_003Dz8ssHCIs_003D.ManipulationDelta += delegate(object _0023_003DzxwGby4M_003D, ManipulationDeltaEventArgs _0023_003Dzs9Vs9Ak_003D)
			{
				double _0023_003DzlR7ZGDJcqXQdqIFx1gxUvvE_003D = Utility.RadToDeg(_0023_003Dzs9Vs9Ak_003D.RotationDelta);
				float width = _0023_003Dzs9Vs9Ak_003D.TranslationDelta.Width;
				float height = _0023_003Dzs9Vs9Ak_003D.TranslationDelta.Height;
				_0023_003DzEIL_0024cMhm38DE(_0023_003DzlR7ZGDJcqXQdqIFx1gxUvvE_003D, width, height);
			};
			_0023_003Dz8ssHCIs_003D.PivotRadius = 2f;
			_0023_003DzEzFEfbg_003D = true;
		}
		_0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D = (_0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D = (_0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D = (_0023_003Dz4931B1GZD8u4._0023_003Dz_0024YfjOuY_003D = Point.Empty)));
	}

	internal bool _0023_003DzxpoNvry1jysi()
	{
		return _0023_003DzEzFEfbg_003D;
	}

	internal bool _0023_003Dz7CxbweiemEDy(TouchEventArgs _0023_003Dzs9Vs9Ak_003D)
	{
		return _0023_003Dzs9Vs9Ak_003D.IsPrimaryContact;
	}

	public bool _0023_003Dzw1jKay_0024z8meP()
	{
		return _0023_003DzGgCJSJSkWGZW != -1;
	}

	internal bool _0023_003DzUg2nzQZLoTnT(object _0023_003DzxwGby4M_003D, TouchEventArgs _0023_003Dzs9Vs9Ak_003D)
	{
		_0023_003DzjrrtsPfw5AMu(_0023_003Dzs9Vs9Ak_003D.Id, _0023_003Dz7CxbweiemEDy(_0023_003Dzs9Vs9Ak_003D), _0023_003Dzs9Vs9Ak_003D.Location);
		return false;
	}

	internal void _0023_003DzjrrtsPfw5AMu(int _0023_003DzfW0EDazYNQItFlcYew_003D_003D, bool _0023_003DzCOTV2ijDdZqA, Point _0023_003DzOwMThaLgcwyo)
	{
		Point point = _0023_003DzKDtwOYa8e7Yp(_0023_003DzOwMThaLgcwyo);
		_0023_003DzGgCJSJSkWGZW = _0023_003Dz0TvaYNo_003D._0023_003DzPVBjq_q_0024E6tt(point);
		Viewport viewport = _0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp();
		Point _0023_003DzTYCHRugcseEq = viewport.ScreenToViewport(point);
		if (_0023_003DzCOTV2ijDdZqA)
		{
			_0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D = new Point(_0023_003DzTYCHRugcseEq.X, _0023_003DzTYCHRugcseEq.Y);
			viewport._0023_003DzjUZA_0024Ue8Set2(_0023_003DzTYCHRugcseEq, _0023_003Dz0TvaYNo_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D, viewport.Rotate.RotationMode);
		}
		else
		{
			_0023_003Dz4931B1GZD8u4._0023_003Dz_0024YfjOuY_003D = new Point(_0023_003DzTYCHRugcseEq.X, _0023_003DzTYCHRugcseEq.Y);
		}
		_0023_003Dz8ssHCIs_003D?.ProcessDown((uint)_0023_003DzfW0EDazYNQItFlcYew_003D_003D, point);
		_0023_003DzFxG1C65aynj9++;
		Telemetry.Instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587140), Telemetry.moduleType.Generic);
	}

	internal void _0023_003DzKCFeXLqW_00240pK(object _0023_003DzxwGby4M_003D, TouchEventArgs _0023_003Dzs9Vs9Ak_003D)
	{
		if (_0023_003Dzw1jKay_0024z8meP())
		{
			int id = _0023_003Dzs9Vs9Ak_003D.Id;
			Point location = _0023_003Dzs9Vs9Ak_003D.Location;
			_0023_003DzZMkR17zUYzX4(id, _0023_003Dz7CxbweiemEDy(_0023_003Dzs9Vs9Ak_003D), location);
		}
	}

	private void _0023_003DzZMkR17zUYzX4(int _0023_003DzfW0EDazYNQItFlcYew_003D_003D, bool _0023_003DzCOTV2ijDdZqA, Point _0023_003DzOwMThaLgcwyo)
	{
		Point point = _0023_003DzKDtwOYa8e7Yp(_0023_003DzOwMThaLgcwyo);
		_0023_003Dz0TvaYNo_003D._0023_003DzPVBjq_q_0024E6tt(point);
		Point point2 = _0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp().ScreenToViewport(point);
		if (_0023_003DzCOTV2ijDdZqA)
		{
			_0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D = new Point(point2.X, point2.Y);
		}
		else
		{
			_0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D = new Point(point2.X, point2.Y);
		}
		_0023_003Dz8ssHCIs_003D?.ProcessMove((uint)_0023_003DzfW0EDazYNQItFlcYew_003D_003D, point);
		if (!_0023_003Dzt7wuDQyUa9jphQUSvw_003D_003D && _0023_003Dz0TvaYNo_003D.ActionMode == actionType.None)
		{
			bool flag = _0023_003DzFxG1C65aynj9 == 1 && _0023_003Dz0TvaYNo_003D.MultiTouch.Rotate;
			flag |= _0023_003DzFxG1C65aynj9 > 1 && (_0023_003Dz0TvaYNo_003D.MultiTouch.Pan || _0023_003Dz0TvaYNo_003D.MultiTouch.Zoom);
			_0023_003Dz0TvaYNo_003D.Moving = flag;
			if (flag)
			{
				_0023_003Dz0TvaYNo_003D._0023_003DzSGfimhJkGdqe(_0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp());
				_0023_003Dzt7wuDQyUa9jphQUSvw_003D_003D = true;
			}
		}
	}

	internal Point _0023_003DzKDtwOYa8e7Yp(Point _0023_003DzunVj9yQ_003D)
	{
		return _0023_003DzunVj9yQ_003D;
	}

	internal void _0023_003Dzdu4bLzoDDwoi(object _0023_003DzxwGby4M_003D, TouchEventArgs _0023_003Dzs9Vs9Ak_003D)
	{
		Point location = _0023_003Dzs9Vs9Ak_003D.Location;
		int id = _0023_003Dzs9Vs9Ak_003D.Id;
		_0023_003Dz6gRQJKeCJvcy(id, location);
	}

	private void _0023_003Dz6gRQJKeCJvcy(int _0023_003DzfW0EDazYNQItFlcYew_003D_003D, Point _0023_003DzOwMThaLgcwyo)
	{
		Point point = _0023_003DzKDtwOYa8e7Yp(_0023_003DzOwMThaLgcwyo);
		_0023_003Dz0TvaYNo_003D._0023_003DzPVBjq_q_0024E6tt(point);
		_0023_003Dz4931B1GZD8u4 = new _0023_003DzTnYmsrxMA7s0(Point.Empty, Point.Empty);
		_0023_003Dz8ssHCIs_003D?.ProcessUp((uint)_0023_003DzfW0EDazYNQItFlcYew_003D_003D, point);
		_0023_003DzFxG1C65aynj9--;
		if (_0023_003Dzt7wuDQyUa9jphQUSvw_003D_003D)
		{
			if (_0023_003Dzw1jKay_0024z8meP())
			{
				_0023_003Dz0TvaYNo_003D.Moving = false;
				_0023_003Dz0TvaYNo_003D._0023_003DzBhiHJ1K9qQ76(_0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp());
			}
			_0023_003Dzt7wuDQyUa9jphQUSvw_003D_003D = false;
		}
		_0023_003DzGgCJSJSkWGZW = -1;
	}

	internal void _0023_003DzFUZ_00243GspB_h4(object _0023_003DzxwGby4M_003D, ManipulationDeltaEventArgs _0023_003Dzs9Vs9Ak_003D)
	{
		double _0023_003DzlR7ZGDJcqXQdqIFx1gxUvvE_003D = Utility.RadToDeg(_0023_003Dzs9Vs9Ak_003D.RotationDelta);
		float width = _0023_003Dzs9Vs9Ak_003D.TranslationDelta.Width;
		float height = _0023_003Dzs9Vs9Ak_003D.TranslationDelta.Height;
		_0023_003DzEIL_0024cMhm38DE(_0023_003DzlR7ZGDJcqXQdqIFx1gxUvvE_003D, width, height);
	}

	private void _0023_003DzEIL_0024cMhm38DE(double _0023_003DzlR7ZGDJcqXQdqIFx1gxUvvE_003D, double _0023_003Dz4PolkneUXGPg6W0ZX2maGZQ_003D, double _0023_003DzFnR1V3ijKwmtdQgnptPV2ws_003D)
	{
		if (_0023_003Dz0TvaYNo_003D.ActionMode != actionType.None)
		{
			return;
		}
		Viewport viewport = _0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp();
		viewport.Camera.GetFrame(out var _, out var camX, out var camY, out var camZ);
		bool flag = false;
		if (!_0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D.IsEmpty && !_0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D.IsEmpty)
		{
			if (_0023_003Dz4931B1GZD8u4._0023_003Dz_0024YfjOuY_003D.IsEmpty && _0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D.IsEmpty)
			{
				if (_0023_003Dz0TvaYNo_003D.MultiTouch.Rotate && viewport.Rotate.Enabled && _0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D != _0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D)
				{
					if (viewport.Rotate.RotationMode == rotationType.Turntable)
					{
						_0023_003Dz0TvaYNo_003D._0023_003Dzk_0024_0024VvG_00245PP4u(-_0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D.X + _0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D.X, -_0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D.Y + _0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D.Y, _0023_003DzBQC8k3F0wJN4: false);
					}
					else
					{
						_0023_003Dz0TvaYNo_003D._0023_003Dzk_0024_0024VvG_00245PP4u(camX, _0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D.Y - _0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D.Y, _0023_003DzaDYRbvgbaa7a: false, _0023_003DzBQC8k3F0wJN4: false);
						_0023_003Dz0TvaYNo_003D._0023_003Dzk_0024_0024VvG_00245PP4u(camY, _0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D.X - _0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D.X, _0023_003DzaDYRbvgbaa7a: false, _0023_003DzBQC8k3F0wJN4: false);
					}
					flag = true;
				}
			}
			else if (!_0023_003Dz4931B1GZD8u4._0023_003Dz_0024YfjOuY_003D.IsEmpty && !_0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D.IsEmpty && (_0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D != _0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D || _0023_003Dz4931B1GZD8u4._0023_003Dz_0024YfjOuY_003D != _0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D))
			{
				Segment2D segment2D = new Segment2D(_0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D.X, _0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D.Y, _0023_003Dz4931B1GZD8u4._0023_003Dz_0024YfjOuY_003D.X, _0023_003Dz4931B1GZD8u4._0023_003Dz_0024YfjOuY_003D.Y);
				Point2D point2D = new Point2D((segment2D.P0.X + segment2D.P1.X) / 2.0, (segment2D.P0.Y + segment2D.P1.Y) / 2.0);
				Segment2D segment2D2 = new Segment2D(_0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D.X, _0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D.Y, _0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D.X, _0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D.Y);
				if (_0023_003Dz0TvaYNo_003D.MultiTouch.Rotate && viewport.Rotate.Enabled && viewport.Rotate.RotationMode != rotationType.Turntable)
				{
					rotationCenterType rotationCenter = viewport.Rotate.RotationCenter;
					viewport.Rotate.RotationCenter = rotationCenterType.ViewportCenter;
					_0023_003Dz0TvaYNo_003D._0023_003Dzk_0024_0024VvG_00245PP4u(camZ, 0.0 - _0023_003DzlR7ZGDJcqXQdqIFx1gxUvvE_003D, _0023_003DzaDYRbvgbaa7a: false, _0023_003DzBQC8k3F0wJN4: false);
					viewport.Rotate.RotationCenter = rotationCenter;
					flag = true;
				}
				if (_0023_003Dz0TvaYNo_003D.MultiTouch.Pan && viewport.Pan.Enabled)
				{
					_0023_003Dz0TvaYNo_003D.PanCamera(new Point((int)point2D.X, (int)point2D.Y), new Point((int)(point2D.X + _0023_003Dz4PolkneUXGPg6W0ZX2maGZQ_003D), (int)(point2D.Y + _0023_003DzFnR1V3ijKwmtdQgnptPV2ws_003D)), animate: false);
					flag = true;
				}
				if (_0023_003Dz0TvaYNo_003D.MultiTouch.Zoom && viewport.Zoom.Enabled)
				{
					double num = segment2D2.Length - segment2D.Length;
					if (Math.Abs(num) > 2.0)
					{
						_0023_003Dz0TvaYNo_003D.ZoomCamera(new Point((int)point2D.X, (int)point2D.Y), (int)num, animate: false);
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			_0023_003Dz0TvaYNo_003D.Invalidate();
		}
		_0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D = _0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D;
		_0023_003Dz4931B1GZD8u4._0023_003Dz_0024YfjOuY_003D = _0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D;
		_0023_003DzX_6VGrAXIa3X._0023_003DzpBTIMwo_003D = Point.Empty;
		_0023_003Dz4931B1GZD8u4._0023_003DzpBTIMwo_003D = Point.Empty;
	}

	public void _0023_003Dz1B3OeaD67M_T(object _0023_003DzxwGby4M_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003Dz0TvaYNo_003D._0023_003DzWct4wogVWy2w();
		if (!_0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D.IsEmpty)
		{
			_0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp()._0023_003Dz99_0024gH6eUUxNX(_0023_003DzX_6VGrAXIa3X._0023_003Dz_0024YfjOuY_003D, out var _0023_003DzDIQP2_0024FoL);
			actionType actionMode = _0023_003Dz0TvaYNo_003D.ActionMode;
			_0023_003Dz0TvaYNo_003D._0023_003DzXRmPWIn6oGDi();
			_0023_003Dz0TvaYNo_003D.ActionMode = actionType.SelectVisibleByPick;
			_0023_003Dz0TvaYNo_003D._0023_003Dzsf8k5Q5BH9Z_0024(MouseButtons.Left, new Rectangle(_0023_003DzDIQP2_0024FoL.X - 15, _0023_003DzDIQP2_0024FoL.Y - 15, 30, 30));
			_0023_003Dz0TvaYNo_003D.ActionMode = actionMode;
			_0023_003Dz0TvaYNo_003D._0023_003DzzznZbBezl6L_();
		}
	}

	public void _0023_003DzEuQb9yE_003D(object _0023_003DzxwGby4M_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
	}

	internal void _0023_003Dz2EeEWwA_003D()
	{
		_0023_003Dz0TvaYNo_003D._0023_003DzU_0024SPQYmSpAZq();
		if (_0023_003Dz8ssHCIs_003D != null)
		{
			_0023_003Dz8ssHCIs_003D.Dispose();
			_0023_003Dz8ssHCIs_003D = null;
		}
		if (_0023_003Dz8bcwa6F0_0024iPFyc7okw_003D_003D != null)
		{
			Handler._0023_003Dz2EeEWwA_003D(_0023_003Dz8bcwa6F0_0024iPFyc7okw_003D_003D);
		}
	}
}
