using System;
using System.Collections.Generic;
using System.Diagnostics;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept.Geometry;
using devDept.Graphics;

internal class _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzFrThlsECtjr503rdhpAOQ5c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzn_JtMJeJm6gSunrgCBhvlemtdXpW2Bshog_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzm0KLVj8zcivGrIdW1kyK0dk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<SharpDX.Direct3D11.Buffer> _0023_003Dzz24Nt6INMxnn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<SharpDX.Direct3D11.Buffer> _0023_003DzK6YdNow_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<vertexBufferData> _0023_003Dzz8j8G7g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<List<int>> _0023_003DzVQdby4Uk73jo52ylew_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<List<float>> _0023_003Dz6ym_OKwKktrt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D;

	public _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU()
	{
		_0023_003Dzz8j8G7g_003D = new List<vertexBufferData>();
	}

	public _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU(int _0023_003DzHXE4tItuJJ_U, SharpDX.Direct3D11.Device _0023_003DzJ_0024CASPE_003D, IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D)
		: this(_0023_003DzHXE4tItuJJ_U, _0023_003DzJ_0024CASPE_003D, _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D), _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D)
	{
	}

	public _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU(int _0023_003DzHXE4tItuJJ_U, SharpDX.Direct3D11.Device _0023_003DzJ_0024CASPE_003D, float[] _0023_003Dzt5jpbHs_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D)
		: this()
	{
		_0023_003Dz6ym_OKwKktrt = new List<List<float>>();
		if (_0023_003Dzdo7ctlc_003D != null && _0023_003Dzdo7ctlc_003D.Length != 0)
		{
			_0023_003DzVQdby4Uk73jo52ylew_003D_003D = new List<List<int>>();
		}
		_0023_003DzgWaA5Nc_003D(_0023_003DzHXE4tItuJJ_U, _0023_003Dzt5jpbHs_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, (_0023_003Dzdo7ctlc_003D != null) ? _0023_003Dzdo7ctlc_003D.Length : 0, _0023_003Dzp_0024qFwgs_003D: true);
		_0023_003DzrloDkpQ_003D(_0023_003DzJ_0024CASPE_003D, _0023_003Dz6ym_OKwKktrt, _0023_003DzVQdby4Uk73jo52ylew_003D_003D);
		_0023_003Dz6ym_OKwKktrt = null;
		_0023_003DzVQdby4Uk73jo52ylew_003D_003D = null;
	}

	public int _0023_003DzXeW6cikb01JX()
	{
		return _0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D;
	}

	public void _0023_003DzIaOBTwcZYZsO(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DziOKzhETUWCQaAJH1_0024Q_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	protected int _0023_003DzauJapuqFAlch_UAGfA_003D_003D()
	{
		return _0023_003DzFrThlsECtjr503rdhpAOQ5c_003D;
	}

	protected void _0023_003DzwBmlOTeAMW0c1qCLrA_003D_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzFrThlsECtjr503rdhpAOQ5c_003D = _0023_003DzsLHxXyo_003D;
	}

	protected int _0023_003Dz0JKt0V3w3_0024d4oBoMt1GBryo_003D()
	{
		return _0023_003Dzn_JtMJeJm6gSunrgCBhvlemtdXpW2Bshog_003D_003D;
	}

	private void _0023_003DzK07cR4sQBofVr2yb5_YNFgY_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzn_JtMJeJm6gSunrgCBhvlemtdXpW2Bshog_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	internal void _0023_003DzrloDkpQ_003D(SharpDX.Direct3D11.Device _0023_003DzJ_0024CASPE_003D, List<List<float>> _0023_003Dzt5jpbHs_003D, List<List<int>> _0023_003Dzdo7ctlc_003D)
	{
		if (_0023_003Dzt5jpbHs_003D.Count == 0)
		{
			return;
		}
		_0023_003Dzz24Nt6INMxnn = new List<SharpDX.Direct3D11.Buffer>();
		if (_0023_003Dzdo7ctlc_003D != null && _0023_003Dzdo7ctlc_003D.Count > 0)
		{
			_0023_003DzK6YdNow_003D = new List<SharpDX.Direct3D11.Buffer>();
		}
		for (int i = 0; i < _0023_003Dzt5jpbHs_003D.Count; i++)
		{
			SharpDX.Direct3D11.Buffer item = SharpDX.Direct3D11.Buffer.Create(_0023_003DzJ_0024CASPE_003D, BindFlags.VertexBuffer, _0023_003Dzt5jpbHs_003D[i].ToArray());
			_0023_003Dzz24Nt6INMxnn.Add(item);
			if (_0023_003Dzdo7ctlc_003D != null && _0023_003Dzdo7ctlc_003D[i] != null && _0023_003Dzdo7ctlc_003D[i].Count > 0)
			{
				SharpDX.Direct3D11.Buffer item2 = SharpDX.Direct3D11.Buffer.Create(_0023_003DzJ_0024CASPE_003D, BindFlags.IndexBuffer, _0023_003Dzdo7ctlc_003D[i].ToArray());
				_0023_003DzK6YdNow_003D.Add(item2);
			}
		}
	}

	internal void _0023_003DzrloDkpQ_003D(SharpDX.Direct3D11.Device _0023_003DzJ_0024CASPE_003D)
	{
		_0023_003DzrloDkpQ_003D(_0023_003DzJ_0024CASPE_003D, _0023_003Dz6ym_OKwKktrt, _0023_003DzVQdby4Uk73jo52ylew_003D_003D);
		_0023_003Dz6ym_OKwKktrt = null;
		_0023_003DzVQdby4Uk73jo52ylew_003D_003D = null;
	}

	internal void _0023_003DzXkFkuX_0024T7lH9(int _0023_003DzWPCO3aE_003D, int _0023_003Dz0VB11flmJi_0024i, int _0023_003DzRbrcOgQ_003D)
	{
		_0023_003DzIaOBTwcZYZsO(_0023_003DzXkFkuX_0024T7lH9(_0023_003Dz0VB11flmJi_0024i, _0023_003DzRbrcOgQ_003D));
		_0023_003DzwBmlOTeAMW0c1qCLrA_003D_003D(_0023_003DzXeW6cikb01JX() / 4);
		_0023_003DzK07cR4sQBofVr2yb5_YNFgY_003D(_0023_003DzWPCO3aE_003D / _0023_003DzauJapuqFAlch_UAGfA_003D_003D());
	}

	private static int _0023_003DzXkFkuX_0024T7lH9(int _0023_003Dz0VB11flmJi_0024i, int _0023_003DzRbrcOgQ_003D)
	{
		return _0023_003Dz0VB11flmJi_0024i / _0023_003DzRbrcOgQ_003D * 4;
	}

	public void Dispose()
	{
		if (_0023_003Dzz24Nt6INMxnn != null)
		{
			foreach (SharpDX.Direct3D11.Buffer item in _0023_003Dzz24Nt6INMxnn)
			{
				item.Dispose();
			}
			_0023_003Dzz24Nt6INMxnn = null;
		}
		if (_0023_003DzK6YdNow_003D == null)
		{
			return;
		}
		foreach (SharpDX.Direct3D11.Buffer item2 in _0023_003DzK6YdNow_003D)
		{
			item2.Dispose();
		}
		_0023_003DzK6YdNow_003D = null;
	}

	public int _0023_003Dzp9_0024YmepwcPbCQuvl3A_003D_003D()
	{
		return _0023_003Dzm0KLVj8zcivGrIdW1kyK0dk_003D;
	}

	public void _0023_003DzULN3aTft2IcNuw2ZxQ_003D_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzm0KLVj8zcivGrIdW1kyK0dk_003D = _0023_003DzsLHxXyo_003D;
	}

	public void _0023_003Dz99kJFjE_003D(D3DRenderContext _0023_003DzmNZD0Zs_003D)
	{
		_0023_003Dz99kJFjE_003D(_0023_003DzmNZD0Zs_003D, 0, null, null);
	}

	public void _0023_003Dz99kJFjE_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, bool _0023_003DztUnIfaGIxq6w)
	{
		if (_0023_003DztUnIfaGIxq6w)
		{
			_0023_003Dz99kJFjE_003D((D3DRenderContext)_0023_003DzmNZD0Zs_003D, _0023_003Dzp9_0024YmepwcPbCQuvl3A_003D_003D() + 1, null, null);
		}
		else
		{
			_0023_003Dz99kJFjE_003D((D3DRenderContext)_0023_003DzmNZD0Zs_003D, _0023_003Dzp9_0024YmepwcPbCQuvl3A_003D_003D(), null, null);
		}
	}

	public void _0023_003Dz99kJFjE_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003Dz0ERCPQk_003D)
	{
		_0023_003Dz99kJFjE_003D((D3DRenderContext)_0023_003DzmNZD0Zs_003D, _0023_003Dz0ERCPQk_003D, null, null);
	}

	public virtual void _0023_003Dz99kJFjE_003D(D3DRenderContext _0023_003DzmNZD0Zs_003D, int _0023_003Dz0ERCPQk_003D, uint? _0023_003Dz0nGtLL0_003D, uint? _0023_003DzF1puTpc_003D)
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
		for (int i = vertexBufferData2.firstChunk; i <= vertexBufferData2.lastChunk; i++)
		{
			_0023_003DzP7fhLh8_003D.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(_0023_003Dzz24Nt6INMxnn[i], _0023_003DzXeW6cikb01JX(), 0));
			if (_0023_003DzK6YdNow_003D != null && vertexBufferData2.startIndex >= 0)
			{
				bool flag = _0023_003DzF1puTpc_003D.HasValue && _0023_003Dz0nGtLL0_003D.HasValue;
				_0023_003DzP7fhLh8_003D.InputAssembler.SetIndexBuffer(_0023_003DzK6YdNow_003D[0], Format.R32_UInt, 0);
				_0023_003DzP7fhLh8_003D.DrawIndexed(flag ? ((int)_0023_003DzF1puTpc_003D.Value) : vertexBufferData2.nElementsPerChunk[0], flag ? ((int)_0023_003Dz0nGtLL0_003D.Value) : vertexBufferData2.startIndex, vertexBufferData2.startVertex);
			}
			else
			{
				_0023_003DzP7fhLh8_003D.Draw(vertexBufferData2.nElementsPerChunk[i], (i == 0) ? vertexBufferData2.startVertex : 0);
			}
		}
	}

	internal void _0023_003DzgWaA5Nc_003D(int _0023_003DzHXE4tItuJJ_U, float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, int _0023_003Dz4Im51Qk_003D, bool _0023_003Dzp_0024qFwgs_003D)
	{
		if (_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length == 0)
		{
			return;
		}
		if (_0023_003Dz6ym_OKwKktrt.Count == 0)
		{
			_0023_003DzXkFkuX_0024T7lH9(_0023_003DzHXE4tItuJJ_U, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D);
			_0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D = 0;
			if (_0023_003Dzz8j8G7g_003D.Count > 0)
			{
				int index = _0023_003Dzz8j8G7g_003D.Count - 1;
				vertexBufferData obj = _0023_003Dzz8j8G7g_003D[index];
				obj._0023_003Dz_002475wn_0024QGlEFt(_0023_003DzQZ1JmC0_003D);
				obj.startIndex = ((_0023_003Dzdo7ctlc_003D == null) ? (-1) : 0);
			}
			_0023_003Dz6ym_OKwKktrt.Add(new List<float>());
		}
		int num = _0023_003Dz6ym_OKwKktrt.Count - 1;
		if (_0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D < _0023_003Dz0JKt0V3w3_0024d4oBoMt1GBryo_003D() || _0023_003Dzdo7ctlc_003D != null)
		{
			int _0023_003DzivjwkyA_003D = _0023_003DzHT7laFFWe738(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzdo7ctlc_003D, num, 0, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
			_0023_003DzhBa6N7vF9w1t(num, _0023_003DzQZ1JmC0_003D, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, _0023_003Dz4Im51Qk_003D, _0023_003Dzp_0024qFwgs_003D, _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D, _0023_003DzivjwkyA_003D);
		}
		else
		{
			_0023_003Dz1NZMGoaZMMI2(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, _0023_003Dz4Im51Qk_003D, _0023_003Dzp_0024qFwgs_003D, num);
		}
	}

	protected void _0023_003Dz1NZMGoaZMMI2(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, int _0023_003Dz4Im51Qk_003D, bool _0023_003Dzp_0024qFwgs_003D, int _0023_003Dz_0024Hi2ziW1e3rR)
	{
		int num = _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D - _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D;
		int num2 = Math.Min(_0023_003Dz0JKt0V3w3_0024d4oBoMt1GBryo_003D(), _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D);
		int _0023_003Dz7OF_4JtEUKui = _0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D;
		int num3 = 0;
		while (num2 > 0)
		{
			if (_0023_003Dz4Im51Qk_003D == 0)
			{
				switch (_0023_003DzQZ1JmC0_003D)
				{
				case primitiveType.LineList:
					if (num2 % 2 == 1)
					{
						num2--;
					}
					break;
				case primitiveType.TriangleList:
					num2 -= num2 % 3;
					break;
				case primitiveType.TriangleStrip:
					if (num2 < 3)
					{
						num2 = 0;
					}
					break;
				}
				if (num2 == 0)
				{
					break;
				}
			}
			if (_0023_003Dz_0024Hi2ziW1e3rR >= _0023_003Dz6ym_OKwKktrt.Count)
			{
				_0023_003Dz6ym_OKwKktrt.Add(new List<float>());
				_0023_003Dz7OF_4JtEUKui = 0;
			}
			int num4 = num2 * _0023_003DzauJapuqFAlch_UAGfA_003D_003D();
			int _0023_003DzivjwkyA_003D = _0023_003DzHT7laFFWe738(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzdo7ctlc_003D, _0023_003Dz_0024Hi2ziW1e3rR, num3, num4);
			_0023_003DzhBa6N7vF9w1t(_0023_003Dz_0024Hi2ziW1e3rR, _0023_003DzQZ1JmC0_003D, num2, _0023_003Dz4Im51Qk_003D, _0023_003Dzp_0024qFwgs_003D, _0023_003Dz7OF_4JtEUKui, _0023_003DzivjwkyA_003D);
			_0023_003Dz_0024Hi2ziW1e3rR++;
			if (_0023_003Dzp_0024qFwgs_003D)
			{
				_0023_003Dzp_0024qFwgs_003D = false;
			}
			num3 += num4;
			num -= num2;
			num2 = Math.Min(num, _0023_003Dz0JKt0V3w3_0024d4oBoMt1GBryo_003D());
			if (_0023_003Dz4Im51Qk_003D > 0)
			{
				break;
			}
		}
	}

	private int _0023_003DzHT7laFFWe738(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, int _0023_003Dz_0024Hi2ziW1e3rR, int _0023_003Dzgzqb1hl60HQU, int _0023_003Dz8UEy_0024xy_F4JX)
	{
		int num = _0023_003Dzgzqb1hl60HQU + _0023_003Dz8UEy_0024xy_F4JX;
		if (_0023_003Dzgzqb1hl60HQU == 0 && _0023_003Dz8UEy_0024xy_F4JX == _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length)
		{
			_0023_003Dz6ym_OKwKktrt[_0023_003Dz_0024Hi2ziW1e3rR].AddRange(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D);
		}
		else
		{
			float[] array = new float[num - _0023_003Dzgzqb1hl60HQU];
			Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzgzqb1hl60HQU, array, 0, array.Length);
			_0023_003Dz6ym_OKwKktrt[_0023_003Dz_0024Hi2ziW1e3rR].AddRange(array);
		}
		int result = -1;
		if (_0023_003Dzdo7ctlc_003D != null)
		{
			if (_0023_003DzVQdby4Uk73jo52ylew_003D_003D == null)
			{
				_0023_003DzVQdby4Uk73jo52ylew_003D_003D = new List<List<int>>();
			}
			if (_0023_003DzVQdby4Uk73jo52ylew_003D_003D.Count < _0023_003Dz_0024Hi2ziW1e3rR + 1)
			{
				_0023_003DzVQdby4Uk73jo52ylew_003D_003D.Add(new List<int>());
			}
			result = _0023_003DzVQdby4Uk73jo52ylew_003D_003D[_0023_003Dz_0024Hi2ziW1e3rR].Count;
			_0023_003DzVQdby4Uk73jo52ylew_003D_003D[_0023_003Dz_0024Hi2ziW1e3rR].AddRange(_0023_003Dzdo7ctlc_003D);
		}
		return result;
	}

	private void _0023_003DzhBa6N7vF9w1t(int _0023_003DzZdM3PQA_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D, int _0023_003Dz4Im51Qk_003D, bool _0023_003Dzp_0024qFwgs_003D, int _0023_003Dz7OF_4JtEUKui, int _0023_003DzivjwkyA_003D)
	{
		int num = ((_0023_003Dz4Im51Qk_003D == 0) ? _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D : _0023_003Dz4Im51Qk_003D);
		if (_0023_003Dzp_0024qFwgs_003D || _0023_003Dzz8j8G7g_003D.Count == 0)
		{
			vertexBufferData obj = new vertexBufferData();
			obj._0023_003Dz_002475wn_0024QGlEFt(_0023_003DzQZ1JmC0_003D);
			obj.startVertex = _0023_003Dz7OF_4JtEUKui;
			obj.startIndex = _0023_003DzivjwkyA_003D;
			vertexBufferData vertexBufferData2 = obj;
			vertexBufferData2.nElementsPerChunk.Add(num);
			_0023_003Dzz8j8G7g_003D.Add(vertexBufferData2);
		}
		else
		{
			vertexBufferData vertexBufferData3 = _0023_003Dzz8j8G7g_003D[_0023_003Dzz8j8G7g_003D.Count - 1];
			if (_0023_003DzZdM3PQA_003D > vertexBufferData3.lastChunk)
			{
				vertexBufferData3.lastChunk = _0023_003DzZdM3PQA_003D;
				vertexBufferData3.nElementsPerChunk.Add(num);
			}
			else
			{
				vertexBufferData3.nElementsPerChunk[vertexBufferData3.nElementsPerChunk.Count - 1] += num;
			}
		}
		_0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D += _0023_003DzBoKR9aQk1QdVgqRkIQ_003D_003D;
	}
}
