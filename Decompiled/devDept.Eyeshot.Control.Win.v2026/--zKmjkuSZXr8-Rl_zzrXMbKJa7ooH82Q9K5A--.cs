using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

internal sealed class _0023_003DzKmjkuSZXr8_0024Rl_zzrXMbKJa7ooH82Q9K5A_003D_003D
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static IsInScreenDelegate _0023_003Dzv6_0024lMQOwMDQzIzNU3g_003D_003D;

		public static IsInScreenDelegate _0023_003DzXCuz5FyShV_SXqSJuA_003D_003D;

		internal bool _0023_003DzanYHyx_0024UJkqMdA_18Xs9PJw_003D(Entity _0023_003DzpWC0efg_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024)
		{
			return ((IEntityInternal)_0023_003DzpWC0efg_003D).IsCrossingScreenPolygon((ScreenPolygonParams)_0023_003DzCBM7XJK4_5H_0024);
		}

		internal bool _0023_003DzNdloQsDMJ9qgD0h_00241DKYd6g_003D(Entity _0023_003DzpWC0efg_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024)
		{
			return ((IEntityInternal)_0023_003DzpWC0efg_003D).AllVerticesInScreenPolygon((ScreenPolygonParams)_0023_003DzCBM7XJK4_5H_0024);
		}
	}

	internal List<Point2D> _0023_003Dzc9XpdZjCbZ5c = new List<Point2D>();

	internal List<int> _0023_003DzUBV_0024WokiThq_UVteLw_003D_003D = new List<int>();

	private int _0023_003DzwXzrcF_0024vKNIp;

	public void _0023_003DzxEpSi5o_003D()
	{
		_0023_003Dzc9XpdZjCbZ5c.Clear();
		_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Clear();
	}

	public bool _0023_003Dz0sYWuTi_0024wtyB(MouseEventArgs _0023_003Dz1SmHC4c_003D, Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		System.Drawing.Point point = _0023_003DzYzWi5Yw_003D._0023_003Dzc1MVb2VApXOF(_0023_003Dz1SmHC4c_003D.Location);
		Point2D point2D = new Point2D(point.X, point.Y);
		if (_0023_003Dz1SmHC4c_003D.Button == MouseButtons.Right)
		{
			_0023_003DzxEpSi5o_003D();
		}
		else if (_0023_003Dz1SmHC4c_003D.Button == MouseButtons.Left)
		{
			if (_0023_003Dzc9XpdZjCbZ5c.Count == 0)
			{
				_0023_003DzwXzrcF_0024vKNIp = _0023_003DzU0f5_qE_003D._0023_003DzBn2ByFKdwrou;
			}
			if (_0023_003Dzc9XpdZjCbZ5c.Count > 0)
			{
				if (_0023_003DzU0f5_qE_003D._0023_003DzBn2ByFKdwrou != _0023_003DzwXzrcF_0024vKNIp)
				{
					_0023_003DzxEpSi5o_003D();
					return false;
				}
				if (Point2D.Distance(point2D, _0023_003Dzc9XpdZjCbZ5c[0]) < 10.0)
				{
					_0023_003Dzc9XpdZjCbZ5c.Add(_0023_003Dzc9XpdZjCbZ5c[0]);
					return true;
				}
			}
			if (_0023_003Dzc9XpdZjCbZ5c.Count >= 2)
			{
				_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Add(0);
				_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Add(_0023_003Dzc9XpdZjCbZ5c.Count - 1);
				_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Add(_0023_003Dzc9XpdZjCbZ5c.Count);
			}
			_0023_003Dzc9XpdZjCbZ5c.Add(point2D);
		}
		return false;
	}

	public void _0023_003DzXAS3U8Q_003D(Workspace _0023_003DzU0f5_qE_003D, IList<Point2D> _0023_003Dzp4f5WRL0NMHY, bool _0023_003Dz7MoFvcekkC14, SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e)
	{
		_0023_003DzTpZvGLfXRihX(_0023_003DzU0f5_qE_003D, _0023_003Dzp4f5WRL0NMHY, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e, _0023_003Dzc_0024FDVjzZMRWW: true, _0023_003Dz_bIfLEkNPFmB: false, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, out var _, actionType.None);
		_0023_003DzxEpSi5o_003D();
	}

	public bool _0023_003DzF3HKD2trntQC()
	{
		return _0023_003Dzc9XpdZjCbZ5c.Count > 0;
	}

	internal SelectedItem[] _0023_003DzTpZvGLfXRihX(Workspace _0023_003DzU0f5_qE_003D, IList<Point2D> _0023_003DzIvGwfgmz0eT80srGXQ_003D_003D, bool _0023_003Dz7MoFvcekkC14, SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e, bool _0023_003Dzc_0024FDVjzZMRWW, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, out int[] _0023_003Dz5IUleg8WwUAm, actionType _0023_003DzfcUzrRi_0024u6FZ)
	{
		_0023_003Dz5IUleg8WwUAm = null;
		if (!_0023_003Dzc_0024FDVjzZMRWW && (_0023_003DzIvGwfgmz0eT80srGXQ_003D_003D.Count < 3 || _0023_003DzIvGwfgmz0eT80srGXQ_003D_003D.First() != _0023_003DzIvGwfgmz0eT80srGXQ_003D_003D.Last()))
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587328));
		}
		if (_0023_003DzU0f5_qE_003D.Entities.Count == 0 || _0023_003DzIvGwfgmz0eT80srGXQ_003D_003D.Count <= 3 || Math.Abs(Utility.PolygonArea(_0023_003DzIvGwfgmz0eT80srGXQ_003D_003D)) < 1E-06)
		{
			if (!_0023_003Dzc_0024FDVjzZMRWW)
			{
				return new SelectedItem[0];
			}
			return null;
		}
		Point2D maxValue = Point2D.MaxValue;
		Point2D minValue = Point2D.MinValue;
		Utility.UpdateMinMax(null, _0023_003DzIvGwfgmz0eT80srGXQ_003D_003D, _0023_003DzIvGwfgmz0eT80srGXQ_003D_003D.Count, maxValue, minValue);
		Viewport viewport = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp();
		int height = (int)(minValue.Y - maxValue.Y);
		int[] _0023_003DzBppTnBIbeUl = null;
		List<Segment2D> list = null;
		double[] _0023_003DzYgijFM_0024VNOEd = null;
		actionType actionType2 = ((_0023_003DzfcUzrRi_0024u6FZ == actionType.None) ? _0023_003DzU0f5_qE_003D.ActionMode : _0023_003DzfcUzrRi_0024u6FZ);
		if (actionType2 != actionType.SelectVisibleByPolygon)
		{
			list = new List<Segment2D>();
			for (int i = 0; i < _0023_003DzIvGwfgmz0eT80srGXQ_003D_003D.Count - 1; i++)
			{
				list.Add(new Segment2D(_0023_003DzIvGwfgmz0eT80srGXQ_003D_003D[i], _0023_003DzIvGwfgmz0eT80srGXQ_003D_003D[i + 1]));
			}
			_0023_003DzYgijFM_0024VNOEd = viewport.Camera.GetModelViewProjectionMatrix();
			_0023_003DzBppTnBIbeUl = new int[4]
			{
				0,
				0,
				viewport.Size.Width,
				viewport.Size.Height
			};
		}
		if (actionType2 != actionType.SelectByPolygon && _0023_003Dzc9XpdZjCbZ5c.Count == 0)
		{
			_0023_003Dzc9XpdZjCbZ5c = new List<Point2D>(_0023_003DzIvGwfgmz0eT80srGXQ_003D_003D);
			if (_0023_003Dzc9XpdZjCbZ5c.Count >= 2)
			{
				for (int j = 2; j < _0023_003Dzc9XpdZjCbZ5c.Count; j++)
				{
					_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Add(0);
					_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Add(j - 1);
					_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Add(j);
				}
			}
		}
		switch (actionType2)
		{
		case actionType.SelectVisibleByPolygon:
		{
			System.Drawing.Point point = viewport._0023_003Dz_0WcPl0XuxCA(new System.Drawing.Point((int)maxValue.X, (int)minValue.Y));
			System.Drawing.Point point2 = viewport._0023_003Dz_0WcPl0XuxCA(new System.Drawing.Point((int)minValue.X, (int)maxValue.Y));
			Rectangle rectangle = new Rectangle(point.X, point.Y, point2.X - point.X, height);
			if (_0023_003Dzc_0024FDVjzZMRWW)
			{
				_0023_003DzU0f5_qE_003D.ProcessSelectionVisibleOnly(rectangle, firstOnly: false, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e);
				break;
			}
			return _0023_003DzU0f5_qE_003D._0023_003Dz59_89Uw0jMUB7bKAfw_003D_003D(_0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp(), rectangle, _0023_003DzU0f5_qE_003D._0023_003DzOWfUZLjOSimJ(), _0023_003DzU0f5_qE_003D._0023_003Dzf4r6oggNIe3m(_0023_003DzU0f5_qE_003D._0023_003Dz28QCun7pbbWH), _0023_003Dz_bIfLEkNPFmB, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, _0023_003DzU0f5_qE_003D._0023_003DznugYzyWkU3Do == Workspace.assemblySelectionType.Leaf);
		}
		case actionType.SelectByPolygon:
		case actionType.SelectByPolygonEnclosed:
		{
			IsInScreenDelegate _0023_003DzHx8m_U_0ER_ = ((actionType2 == actionType.SelectByPolygon) ? ((IsInScreenDelegate)((Entity _0023_003DzpWC0efg_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024) => ((IEntityInternal)_0023_003DzpWC0efg_003D).IsCrossingScreenPolygon((ScreenPolygonParams)_0023_003DzCBM7XJK4_5H_0024))) : ((IsInScreenDelegate)((Entity _0023_003DzpWC0efg_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024) => ((IEntityInternal)_0023_003DzpWC0efg_003D).AllVerticesInScreenPolygon((ScreenPolygonParams)_0023_003DzCBM7XJK4_5H_0024))));
			_0023_003Dz5IUleg8WwUAm = _0023_003DzU0f5_qE_003D._0023_003DzZGKOM7ATzjE8QmOuTQ_003D_003D(_0023_003DzIvGwfgmz0eT80srGXQ_003D_003D, list, _0023_003DzBppTnBIbeUl, _0023_003DzYgijFM_0024VNOEd, maxValue, minValue, _0023_003DzU0f5_qE_003D._0023_003Dzb27idIA2SfmZ(), _0023_003Dz_bIfLEkNPFmB, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, _0023_003DzU0f5_qE_003D._0023_003Dz8YKEbEWNU93g(), out var _0023_003DzzDNdOMv1nCY_0024, _0023_003DzHx8m_U_0ER_, _0023_003DzU0f5_qE_003D._0023_003Dzkm9D6jYtZW1j);
			if (_0023_003Dzc_0024FDVjzZMRWW)
			{
				_0023_003DzU0f5_qE_003D._0023_003DzHeomB7BdNilY(_0023_003Dz7MoFvcekkC14, _0023_003DzzDNdOMv1nCY_0024, _0023_003DzdXQchgXOgG_0024e, _0023_003DzUsW18wvfQQpu: false);
				break;
			}
			return _0023_003DzzDNdOMv1nCY_0024;
		}
		}
		return null;
	}

	internal void _0023_003DzhXjMbKHjJh6K(RenderContextBase _0023_003DzoC62DbA_003D, Viewport _0023_003DzYzWi5Yw_003D, System.Drawing.Point _0023_003DzjTB3lws_003D, Workspace _0023_003DzA5OxWwM_003D, bool _0023_003DzhhJGE92__aK9, Color _0023_003DzeTmvM9c_003D, bool _0023_003Dz2Z9zjjRdA2Ai)
	{
		if (!_0023_003DzF3HKD2trntQC() || _0023_003DzA5OxWwM_003D._0023_003DzBn2ByFKdwrou != _0023_003DzwXzrcF_0024vKNIp)
		{
			return;
		}
		System.Drawing.Point point = _0023_003DzYzWi5Yw_003D._0023_003Dzc1MVb2VApXOF(_0023_003DzjTB3lws_003D);
		Point2D point2D = new Point2D(point.X, point.Y);
		if (_0023_003Dz2Z9zjjRdA2Ai)
		{
			_0023_003DzoC62DbA_003D.SetLineStipple(1, 3855, _0023_003DzYzWi5Yw_003D.Camera);
			_0023_003DzoC62DbA_003D.EnableLineStipple(enable: true);
		}
		_0023_003DzLWgY4_0024E8h8iL(_0023_003DzoC62DbA_003D, _0023_003DzhhJGE92__aK9, _0023_003DzeTmvM9c_003D, point2D, _0023_003DzA5OxWwM_003D._0023_003DzipBYly6zFKAp());
		if (_0023_003Dz2Z9zjjRdA2Ai)
		{
			_0023_003DzoC62DbA_003D.EnableLineStipple(enable: false);
		}
		if (point2D.X != -1.0 && Point2D.Distance(point2D, _0023_003Dzc9XpdZjCbZ5c[0]) < 10.0)
		{
			if (_0023_003DzhhJGE92__aK9)
			{
				_0023_003DzoC62DbA_003D.EnableXOR(enable: true);
			}
			else
			{
				_0023_003DzoC62DbA_003D.SetColorWireframe(Color.FromArgb(255, _0023_003DzeTmvM9c_003D));
			}
			_0023_003DzoC62DbA_003D.DrawLineStrip(new Point3D[5]
			{
				new Point3D(point2D.X - 4.0, point2D.Y - 4.0, 0.0),
				new Point3D(point2D.X + 4.0, point2D.Y - 4.0, 0.0),
				new Point3D(point2D.X + 4.0, point2D.Y + 4.0, 0.0),
				new Point3D(point2D.X - 4.0, point2D.Y + 4.0, 0.0),
				new Point3D(point2D.X - 4.0, point2D.Y - 4.0, 0.0)
			});
			if (_0023_003DzhhJGE92__aK9)
			{
				_0023_003DzoC62DbA_003D.EnableXOR(enable: false);
			}
		}
	}

	private void _0023_003DzLWgY4_0024E8h8iL(RenderContextBase _0023_003DzoC62DbA_003D, bool _0023_003DzhhJGE92__aK9, Color _0023_003DzeTmvM9c_003D, Point2D _0023_003Dz_0024Hgb1SUyD0DJ, Viewport _0023_003DzYzWi5Yw_003D)
	{
		int[] viewFrame = _0023_003DzYzWi5Yw_003D.GetViewFrame();
		if (_0023_003DzhhJGE92__aK9)
		{
			_0023_003DzoC62DbA_003D.EnableXOR(enable: true);
		}
		else
		{
			_0023_003DzoC62DbA_003D.SetColorWireframe(Color.FromArgb(255, _0023_003DzeTmvM9c_003D));
		}
		_0023_003DzoC62DbA_003D.DrawLineStrip(_0023_003Dzc9XpdZjCbZ5c.ToArray());
		if (_0023_003Dz_0024Hgb1SUyD0DJ.X != -1.0)
		{
			_0023_003DzoC62DbA_003D.DrawLine(_0023_003Dzc9XpdZjCbZ5c[_0023_003Dzc9XpdZjCbZ5c.Count - 1], _0023_003Dz_0024Hgb1SUyD0DJ);
		}
		if (_0023_003DzhhJGE92__aK9)
		{
			_0023_003DzoC62DbA_003D.EnableXOR(enable: false);
		}
		_0023_003DzoC62DbA_003D.SetColorWireframe(_0023_003DzeTmvM9c_003D);
		if (_0023_003Dzc9XpdZjCbZ5c.Count > 1)
		{
			_0023_003DzoC62DbA_003D.PushDepthStencilState();
			_0023_003DzoC62DbA_003D.PushBlendState();
			_0023_003DzoC62DbA_003D.PushShader();
			_0023_003DzoC62DbA_003D.SetShader(shaderType.NoLights);
			_0023_003DzENheZIRU3LFa8Y2D_Q_003D_003D(_0023_003DzoC62DbA_003D, _0023_003Dz_0024Hgb1SUyD0DJ);
			_0023_003DzoC62DbA_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Equal_1_1_Op_Keep_Keep_Keep);
			_0023_003DzoC62DbA_003D.SetState(blendStateType.Blend);
			_0023_003DzoC62DbA_003D.DrawQuad(new RectangleF(0f, 0f, viewFrame[2], viewFrame[3]));
			_0023_003DzoC62DbA_003D.PopShader();
			_0023_003DzoC62DbA_003D.PopBlendState();
			_0023_003DzoC62DbA_003D.PopDepthStencilState();
		}
	}

	private void _0023_003DzENheZIRU3LFa8Y2D_Q_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D, Point2D _0023_003Dz_0024Hgb1SUyD0DJ)
	{
		if (_0023_003DzoC62DbA_003D.HasStencil())
		{
			_0023_003DzoC62DbA_003D.SetColorMask(colorMaskFlags.None);
			_0023_003DzoC62DbA_003D.ClearDepthStencil(depthBuffer: false, stencilBuffer: true, 0);
			_0023_003DzoC62DbA_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Never_1_FF_Op_Invert_Keep_Keep);
			_0023_003DzoC62DbA_003D.PushRasterizerState();
			_0023_003DzoC62DbA_003D.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			int num = _0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Count;
			if (_0023_003Dzc9XpdZjCbZ5c.Count > 1 && _0023_003Dz_0024Hgb1SUyD0DJ != null)
			{
				num += 3;
			}
			Point2D[] array = new Point2D[num];
			int i;
			for (i = 0; i < _0023_003DzUBV_0024WokiThq_UVteLw_003D_003D.Count; i += 3)
			{
				array[i] = _0023_003Dzc9XpdZjCbZ5c[_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D[i]];
				array[i + 1] = _0023_003Dzc9XpdZjCbZ5c[_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D[i + 1]];
				array[i + 2] = _0023_003Dzc9XpdZjCbZ5c[_0023_003DzUBV_0024WokiThq_UVteLw_003D_003D[i + 2]];
			}
			if (_0023_003Dzc9XpdZjCbZ5c.Count > 1 && _0023_003Dz_0024Hgb1SUyD0DJ != null)
			{
				array[i++] = _0023_003Dzc9XpdZjCbZ5c[0];
				array[i++] = _0023_003Dzc9XpdZjCbZ5c[_0023_003Dzc9XpdZjCbZ5c.Count - 1];
				array[i++] = _0023_003Dz_0024Hgb1SUyD0DJ;
			}
			_0023_003DzoC62DbA_003D.DrawTriangles2D(array);
			_0023_003DzoC62DbA_003D.PopRasterizerState();
			_0023_003DzoC62DbA_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Never_1_FF_Op_Zero_Keep_Keep);
			_0023_003DzoC62DbA_003D.DrawLineStrip(_0023_003Dzc9XpdZjCbZ5c.ToArray());
			_0023_003DzoC62DbA_003D.SetColorMask(colorMaskFlags.RGBA);
			_0023_003DzoC62DbA_003D.SetState(blendStateType.NoBlend);
		}
	}

	public void _0023_003Dz2sqMfo1EXHui(RenderContextBase _0023_003DzoC62DbA_003D, Size _0023_003Dz0_0024_0024VbFw_003D, bool _0023_003DzYnfmtUMXwvNcBPuELQ_003D_003D)
	{
		if (_0023_003DzoC62DbA_003D.HasStencil())
		{
			_0023_003DzoC62DbA_003D.DisableClipPlanes();
			_0023_003DzoC62DbA_003D.PushMatrices();
			_0023_003DzoC62DbA_003D.SetMatrices(Camera.myOrtho(_0023_003DzoC62DbA_003D, 0.0, _0023_003Dz0_0024_0024VbFw_003D.Width, 0.0, _0023_003Dz0_0024_0024VbFw_003D.Height - 1, -1.0, 1.0), null);
			_0023_003DzENheZIRU3LFa8Y2D_Q_003D_003D(_0023_003DzoC62DbA_003D, null);
			_0023_003DzoC62DbA_003D.PopMatrices();
			_0023_003DzoC62DbA_003D.SetState((depthStencilStateType)(_0023_003DzYnfmtUMXwvNcBPuELQ_003D_003D ? 871081 : 805545));
		}
	}

	public void _0023_003DzwsOBM_pOKhnJ(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		_0023_003DzoC62DbA_003D.SetState(depthStencilStateType.DepthTestLess);
	}
}
