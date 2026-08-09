using System.Collections.Generic;
using System.Diagnostics;
using OpenGL;
using devDept;
using devDept.Geometry;
using devDept.Graphics;

internal class _0023_003DzxMfii5FvRHCf7KMoYW35TB7JQjEk : OGLEntityBuffer
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8p0L55RRLe_P;

	public _0023_003DzxMfii5FvRHCf7KMoYW35TB7JQjEk(int _0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D, int _0023_003Dz8p0L55RRLe_P, _0023_003DzvOg1ehyRaBmw? _0023_003DzzNEWOmE_003D, bool _0023_003DzvwmFS1TFv_X5)
	{
		_0023_003Dz6ym_OKwKktrt = new List<List<float>>();
		_0023_003DzVQdby4Uk73jo52ylew_003D_003D = new List<List<int>>();
		VertexBuffer = new List<int>(gl.GenBuffersARB(1));
		if (_0023_003Dz8p0L55RRLe_P > 0)
		{
			IndexBuffer = new List<int>(gl.GenBuffersARB(1));
		}
		this._0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D = _0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D;
		this._0023_003Dz8p0L55RRLe_P = _0023_003Dz8p0L55RRLe_P;
		_0023_003Dzz8j8G7g_003D = new List<vertexBufferData>();
		vertexBufferData obj = new vertexBufferData();
		obj._0023_003Dz_002475wn_0024QGlEFt(primitiveType.Undefined);
		vertexBufferData vertexBufferData2 = obj;
		vertexBufferData2.nElementsPerChunk.Add(0);
		_0023_003Dzz8j8G7g_003D.Add(vertexBufferData2);
		_0023_003Dz_0024AE2Y_s_003D = _0023_003DzzNEWOmE_003D;
		_resetLayout = _0023_003DzvwmFS1TFv_X5;
	}

	public _0023_003DzxMfii5FvRHCf7KMoYW35TB7JQjEk(float[] _0023_003DzSrKEDXr8vHLe, int[] _0023_003Dz8jxIMMQ_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, _0023_003DzvOg1ehyRaBmw? _0023_003DzzNEWOmE_003D, bool _0023_003DzvwmFS1TFv_X5)
		: this(_0023_003DzSrKEDXr8vHLe.Length, (_0023_003Dz8jxIMMQ_003D != null) ? _0023_003Dz8jxIMMQ_003D.Length : 0, _0023_003DzzNEWOmE_003D, _0023_003DzvwmFS1TFv_X5)
	{
		_0023_003DzhzizObU_003D(_0023_003DzSrKEDXr8vHLe, 0, _0023_003DzSrKEDXr8vHLe.Length, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, _0023_003Dz8jxIMMQ_003D, 0, (_0023_003Dz8jxIMMQ_003D != null) ? _0023_003Dz8jxIMMQ_003D.Length : 0, _0023_003DzQZ1JmC0_003D);
	}

	public int _0023_003DzpGRLDJ0OtMj0()
	{
		return _0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D;
	}

	public int _0023_003DzTVoJvfDySKX6()
	{
		return _0023_003Dz8p0L55RRLe_P;
	}

	public void _0023_003DzOqYnQ5jjGuT9(IList<Point2D> _0023_003Dzt5jpbHs_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D)
	{
		_0023_003DzhzizObU_003D(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(_0023_003Dzt5jpbHs_003D), _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D);
	}

	public void _0023_003DzhQeEkCjQWpqU(IList<Point3D> _0023_003Dzt5jpbHs_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D)
	{
		_0023_003DzhzizObU_003D(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(_0023_003Dzt5jpbHs_003D), _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D);
	}

	public void _0023_003Dzjh9GzO4DfNRe(IList<PointRGB> _0023_003Dzt5jpbHs_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D)
	{
		_0023_003DzhzizObU_003D(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzE8czomGZ4WksTGP5mw_003D_003D(_0023_003Dzt5jpbHs_003D), _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D);
	}

	public void _0023_003DzhzizObU_003D(float[] _0023_003Dzt5jpbHs_003D, int _0023_003Dzsdr_I1A_003D, int _0023_003Dz41WMpX4bFzL8, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D)
	{
		_0023_003DzhzizObU_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzsdr_I1A_003D, _0023_003Dz41WMpX4bFzL8, _0023_003DzRbrcOgQ_003D, null, 0, 0, _0023_003DzQZ1JmC0_003D);
	}

	public void _0023_003DzhzizObU_003D(float[] _0023_003Dzt5jpbHs_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D)
	{
		_0023_003DzhzizObU_003D(_0023_003Dzt5jpbHs_003D, 0, _0023_003Dzt5jpbHs_003D.Length, _0023_003DzRbrcOgQ_003D, null, 0, 0, _0023_003DzQZ1JmC0_003D);
	}

	public void _0023_003DzhzizObU_003D()
	{
		if (_0023_003DzVQdby4Uk73jo52ylew_003D_003D.Count > 0)
		{
			_0023_003DzhzizObU_003D(_0023_003Dz6ym_OKwKktrt[0].ToArray(), 0, _0023_003Dz6ym_OKwKktrt[0].Count, _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D, _0023_003DzVQdby4Uk73jo52ylew_003D_003D[0].ToArray(), 0, _0023_003DzVQdby4Uk73jo52ylew_003D_003D[0].Count, _0023_003Dzz8j8G7g_003D[0]._0023_003DzDX_IlROkgDgt());
		}
		else
		{
			_0023_003DzhzizObU_003D(_0023_003Dz6ym_OKwKktrt[0].ToArray(), 0, _0023_003Dz6ym_OKwKktrt[0].Count, _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D, null, 0, 0, _0023_003Dzz8j8G7g_003D[0]._0023_003DzDX_IlROkgDgt());
		}
	}

	public void _0023_003DzhzizObU_003D(float[] _0023_003Dzt5jpbHs_003D, int _0023_003DzvCiVCyw_003D, int _0023_003Dz41WMpX4bFzL8, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, int _0023_003DzkbUJcIeg6_00245r, int _0023_003Dz4Im51Qk_003D, primitiveType _0023_003DzQZ1JmC0_003D)
	{
		if (_0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D != 0)
		{
			_0023_003DzKRkQnBj3UOcc();
			_0023_003Dzz8j8G7g_003D.Clear();
			_0023_003DzXkFkuX_0024T7lH9(_0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D, _0023_003Dz41WMpX4bFzL8, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D);
			SplitInChunks(_0023_003Dzt5jpbHs_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, _0023_003Dz4Im51Qk_003D, newPart: true, 0);
			Create(_0023_003Dz6ym_OKwKktrt, _0023_003DzVQdby4Uk73jo52ylew_003D_003D, forceBuffersCreation: false);
		}
	}

	internal void _0023_003DzKRkQnBj3UOcc()
	{
		_0023_003Dz6ym_OKwKktrt.Clear();
		_0023_003DzVQdby4Uk73jo52ylew_003D_003D.Clear();
		_0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D = 0;
	}

	internal bool _0023_003Dz_0024_DPFp19tOjE(int _0023_003Dzo2rsr9j4stUl)
	{
		if (_0023_003Dzo2rsr9j4stUl > _0023_003DzpGRLDJ0OtMj0())
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602976));
		}
		if (_0023_003Dz6ym_OKwKktrt.Count != 0)
		{
			return _0023_003Dz6ym_OKwKktrt[0].Count + _0023_003Dzo2rsr9j4stUl <= _0023_003DzpGRLDJ0OtMj0();
		}
		return true;
	}

	public override void Draw(OglRenderContext _0023_003DzmNZD0Zs_003D, int _0023_003Dz0ERCPQk_003D, uint? _0023_003Dz0nGtLL0_003D = null, uint? _0023_003DzF1puTpc_003D = null)
	{
		if (_0023_003Dzz8j8G7g_003D.Count == 0)
		{
			return;
		}
		_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerObject();
		base.currPartToDraw = _0023_003Dz0ERCPQk_003D;
		int mode = _0023_003Dzz8j8G7g_003D[_0023_003Dz0ERCPQk_003D]._0023_003DzDX_IlROkgDgt()._0023_003DzbCW6hty7CJbs();
		vertexBufferData vertexBufferData2 = _0023_003Dzz8j8G7g_003D[_0023_003Dz0ERCPQk_003D];
		gl.BindVertexArrays_(_0023_003DzE5oFKs4_003D[0]);
		if (vertexBufferData2.startIndex >= 0)
		{
			if (_0023_003DzVQdby4Uk73jo52ylew_003D_003D[0].Count > _0023_003Dz8p0L55RRLe_P)
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603288));
			}
			gl.BindBufferARB(34962, VertexBuffer[0]);
			gl.BufferData(34962, 4 * _0023_003Dz6ym_OKwKktrt[0].Count, _0023_003Dz6ym_OKwKktrt[0].ToArray(), 35048);
			gl.BindBufferARB(34963, IndexBuffer[0]);
			gl.BufferData(34963, 4 * _0023_003DzVQdby4Uk73jo52ylew_003D_003D[0].Count, _0023_003DzVQdby4Uk73jo52ylew_003D_003D[0].ToArray(), 35048);
			gl.DrawElements(mode, vertexBufferData2.nElementsPerChunk[0], 5125, vertexBufferData2.startIndex);
		}
		else
		{
			gl.BindBufferARB(34962, VertexBuffer[0]);
			for (int i = vertexBufferData2.firstChunk; i <= vertexBufferData2.lastChunk; i++)
			{
				gl.BufferData(34962, 4 * _0023_003Dz6ym_OKwKktrt[i].Count, _0023_003Dz6ym_OKwKktrt[i].ToArray(), 35048);
				gl.DrawArrays(mode, (i == 0) ? vertexBufferData2.startVertex : 0, _0023_003Dz6ym_OKwKktrt[i].Count / base.FloatPerVertex);
			}
		}
	}
}
