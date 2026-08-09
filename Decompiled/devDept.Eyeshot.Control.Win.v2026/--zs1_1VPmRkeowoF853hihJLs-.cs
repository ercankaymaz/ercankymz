using System.Collections.Generic;
using System.Diagnostics;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept;
using devDept.Geometry;
using devDept.Graphics;

internal class _0023_003Dzs1_1VPmRkeowoF853hihJLs_003D : _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8p0L55RRLe_P;

	public _0023_003Dzs1_1VPmRkeowoF853hihJLs_003D(SharpDX.Direct3D11.Device _0023_003DzJ_0024CASPE_003D, int _0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D, int _0023_003Dz8p0L55RRLe_P)
	{
		_0023_003Dz6ym_OKwKktrt = new List<List<float>>();
		_0023_003DzVQdby4Uk73jo52ylew_003D_003D = new List<List<int>>();
		_0023_003Dzz24Nt6INMxnn = new List<Buffer>(new Buffer[1] { Buffer.Create(_0023_003DzJ_0024CASPE_003D, BindFlags.VertexBuffer, new float[_0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D], 0, ResourceUsage.Dynamic, CpuAccessFlags.Write) });
		if (_0023_003Dz8p0L55RRLe_P > 0)
		{
			_0023_003DzK6YdNow_003D = new List<Buffer>(new Buffer[1] { Buffer.Create(_0023_003DzJ_0024CASPE_003D, BindFlags.IndexBuffer, new int[_0023_003Dz8p0L55RRLe_P], 0, ResourceUsage.Dynamic, CpuAccessFlags.Write) });
		}
		this._0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D = _0023_003DzIl_GzESL37hq74GQ_0024w_003D_003D;
		this._0023_003Dz8p0L55RRLe_P = _0023_003Dz8p0L55RRLe_P;
		_0023_003Dzz8j8G7g_003D = new List<vertexBufferData>();
		vertexBufferData obj = new vertexBufferData();
		obj._0023_003Dz_002475wn_0024QGlEFt(primitiveType.Undefined);
		vertexBufferData vertexBufferData2 = obj;
		vertexBufferData2.nElementsPerChunk.Add(0);
		_0023_003Dzz8j8G7g_003D.Add(vertexBufferData2);
	}

	public _0023_003Dzs1_1VPmRkeowoF853hihJLs_003D(SharpDX.Direct3D11.Device _0023_003DzJ_0024CASPE_003D, float[] _0023_003DzSrKEDXr8vHLe, int[] _0023_003Dz8jxIMMQ_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D)
		: this(_0023_003DzJ_0024CASPE_003D, _0023_003DzSrKEDXr8vHLe.Length, (_0023_003Dz8jxIMMQ_003D != null) ? _0023_003Dz8jxIMMQ_003D.Length : 0)
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
			_0023_003Dz1NZMGoaZMMI2(_0023_003Dzt5jpbHs_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, _0023_003Dz4Im51Qk_003D, _0023_003Dzp_0024qFwgs_003D: true, 0);
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

	public override void _0023_003Dz99kJFjE_003D(D3DRenderContext _0023_003DzmNZD0Zs_003D, int _0023_003Dz0ERCPQk_003D, uint? _0023_003Dz0nGtLL0_003D = null, uint? _0023_003DzF1puTpc_003D = null)
	{
		if (_0023_003Dzz8j8G7g_003D.Count == 0)
		{
			return;
		}
		_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerObject();
		_0023_003DzULN3aTft2IcNuw2ZxQ_003D_003D(_0023_003Dz0ERCPQk_003D);
		DeviceContext _0023_003DzP7fhLh8_003D = _0023_003DzmNZD0Zs_003D._0023_003DzP7fhLh8_003D;
		_0023_003DzP7fhLh8_003D.InputAssembler.PrimitiveTopology = _0023_003Dzz8j8G7g_003D[_0023_003Dz0ERCPQk_003D]._0023_003DzDX_IlROkgDgt()._0023_003DzmQgruD9wOlD3();
		vertexBufferData vertexBufferData2 = _0023_003Dzz8j8G7g_003D[_0023_003Dz0ERCPQk_003D];
		_0023_003DzP7fhLh8_003D.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(_0023_003Dzz24Nt6INMxnn[0], _0023_003DzXeW6cikb01JX(), 0));
		DataStream stream;
		if (vertexBufferData2.startIndex >= 0)
		{
			if (_0023_003DzVQdby4Uk73jo52ylew_003D_003D[0].Count > _0023_003Dz8p0L55RRLe_P)
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603288));
			}
			_0023_003DzP7fhLh8_003D.MapSubresource(_0023_003Dzz24Nt6INMxnn[0], MapMode.WriteDiscard, SharpDX.Direct3D11.MapFlags.None, out stream);
			stream.WriteRange(_0023_003Dz6ym_OKwKktrt[0].ToArray(), vertexBufferData2.startVertex, _0023_003Dz6ym_OKwKktrt[0].Count);
			_0023_003DzP7fhLh8_003D.UnmapSubresource(_0023_003Dzz24Nt6INMxnn[0], 0);
			_0023_003DzP7fhLh8_003D.MapSubresource(_0023_003DzK6YdNow_003D[0], MapMode.WriteDiscard, SharpDX.Direct3D11.MapFlags.None, out stream);
			stream.WriteRange(_0023_003DzVQdby4Uk73jo52ylew_003D_003D[0].ToArray(), vertexBufferData2.startIndex, _0023_003DzVQdby4Uk73jo52ylew_003D_003D[0].Count);
			_0023_003DzP7fhLh8_003D.UnmapSubresource(_0023_003DzK6YdNow_003D[0], 0);
			_0023_003DzP7fhLh8_003D.InputAssembler.SetIndexBuffer(_0023_003DzK6YdNow_003D[0], Format.R32_UInt, 0);
			_0023_003DzP7fhLh8_003D.DrawIndexed(vertexBufferData2.nElementsPerChunk[0], vertexBufferData2.startIndex, vertexBufferData2.startVertex);
		}
		else
		{
			for (int i = vertexBufferData2.firstChunk; i <= vertexBufferData2.lastChunk; i++)
			{
				_0023_003DzP7fhLh8_003D.MapSubresource(_0023_003Dzz24Nt6INMxnn[0], MapMode.WriteDiscard, SharpDX.Direct3D11.MapFlags.None, out stream);
				stream.WriteRange(_0023_003Dz6ym_OKwKktrt[i].ToArray(), (i == 0) ? vertexBufferData2.startVertex : 0, _0023_003Dz6ym_OKwKktrt[i].Count);
				_0023_003DzP7fhLh8_003D.UnmapSubresource(_0023_003Dzz24Nt6INMxnn[0], 0);
				_0023_003DzP7fhLh8_003D.Draw(vertexBufferData2.nElementsPerChunk[i], (i == 0) ? vertexBufferData2.startVertex : 0);
			}
		}
	}
}
