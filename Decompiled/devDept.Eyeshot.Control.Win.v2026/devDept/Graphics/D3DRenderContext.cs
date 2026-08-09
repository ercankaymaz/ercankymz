using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.Mathematics.Interop;
using devDept.Diagnostic;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Geometry;

namespace devDept.Graphics;

public abstract class D3DRenderContext : RenderContext
{
	internal struct _0023_003DzB_00241i16ya3eUx(RenderTargetView _0023_003DzfIJXGx0_003D, DepthStencilView _0023_003Dz52pY7YIbaCdt)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RenderTargetView _0023_003DzfIJXGx0_003D = _0023_003DzfIJXGx0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DepthStencilView _0023_003Dz52pY7YIbaCdt = _0023_003Dz52pY7YIbaCdt;
	}

	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static DrawEntityCallBack _0023_003DzaBSOLvxBbZSQy9lB2A_003D_003D;

		internal void _0023_003DzJue_0024SHJbBT2JPKmZVpmXmWs9pP1_gjIUjdcnd30_003D(RenderContextBase _0023_003DzD6Th82s_003D, object _0023_003DzCBM7XJK4_5H_0024)
		{
			_0023_003DzD6Th82s_003D.DrawIndexedTriangles((VBOParams)_0023_003DzCBM7XJK4_5H_0024);
		}
	}

	internal delegate void _0023_003Dzh1pLMX6wbsARaRfWQQ_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private D3DTexture2D[] _0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal SharpDX.Direct3D11.Device _0023_003DzTzFVZ_00240_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Texture2D _0023_003DzsGYT27WsV_Oyoej_0024GHn1kPc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected Factory _0023_003Dz3DjOiC4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected RenderTargetView _0023_003DzipqsQZ_p852_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected DepthStencilView _0023_003DzL1RoIs5YJ6eF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected DepthStencilView _0023_003Dz52pY7YIbaCdt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected SwapChainDescription _0023_003DzSTDofQueqO4i;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Texture2D _0023_003DzGgYOIY9UjYous_0024b3mQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Texture2D _0023_003DzJhCjKSkYMq6V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Texture2D _0023_003DzG4rPuZTbi_V4gPxQJg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal DeviceContext _0023_003DzP7fhLh8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private D3DTexture2D _0023_003DzfX3UC9sZfg8E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Texture2D _0023_003DzQWdRhF_o_CD4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RenderTargetView _0023_003Dz0Q1ekG6zDfXL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzB_00241i16ya3eUx _0023_003Dz7XlCveSvJ5fF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal SampleDescription _0023_003DzoZFDtSI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal FeatureLevel _0023_003DzGIPo6pY0ShMi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz2Rda4kX181D8_0UgXg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<rasterizerStateType, RasterizerState> _0023_003DzioVUVbUUjXikAY3FaO9C77g_003D = new Dictionary<rasterizerStateType, RasterizerState>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<rasterizerStateType, RasterizerState> _0023_003DzCq2MbKjLVwa2eLteTm8qc8CfbMK85AuhZQ_003D_003D = new Dictionary<rasterizerStateType, RasterizerState>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<depthStencilStateType, DepthStencilState> _0023_003DzOcMxhmqWn4cmb0mNJA_003D_003D = new Dictionary<depthStencilStateType, DepthStencilState>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<blendStateType, BlendState> _0023_003DzaYnyroaiPk1g = new Dictionary<blendStateType, BlendState>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _0023_003Dz5PxKZP0_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Texture2DDescription _0023_003Dz9BXbES9OsYCS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzIIjZpH_kq1FIi9sU4NDjTUmSj7Ht _0023_003Dz_BT7SDwEbLrP = new _0023_003DzIIjZpH_kq1FIi9sU4NDjTUmSj7Ht();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzfSTec3RRfG0OTIPHxA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D _0023_003DzxbCbL_0024mWtybX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D _0023_003DzYpDxbNl_WsmZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D _0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D _0023_003DzhNCOIdKjRgee;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D _0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU _0023_003Dzze_0024GKgWNSzacnVEOXA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzraM_0024_00240ZTZX6Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzOc6QOxFoErNQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<_0023_003DzB_00241i16ya3eUx> _0023_003DzgliipBi37pmb = new Stack<_0023_003DzB_00241i16ya3eUx>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<SamplerState> _0023_003DzCs9juxBz5x1N = new List<SamplerState>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D _0023_003DzTx0khkogHMfe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D _0023_003DzcsNzRnBprL0v;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dzh1pLMX6wbsARaRfWQQ_003D_003D _0023_003DzVphhjzI_0024J3_0024AxPOI0w_003D_003D;

	protected bool drawForBitmap;

	public override Version RendererVersion
	{
		get
		{
			string text = _0023_003DzGIPo6pY0ShMi.ToString();
			string text2 = text.Substring(text.IndexOf('_') + 1);
			int num = text2.IndexOf('_');
			return new Version(minor: int.Parse(text2.Substring(num + 1)), major: int.Parse(text2.Substring(0, num)));
		}
	}

	public override string RendererName => _0023_003Dz2Rda4kX181D8_0UgXg_003D_003D;

	public override bool ReflectionsSupported => _0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3;

	public override bool SupportShadows => base.ControlData.useFrameBufferObject;

	public D3DRenderContext(Size size, ControlData data, IWorkspace parentWorkspace)
		: base(size, data, parentWorkspace)
	{
	}

	private void _0023_003Dz2CJ_0024wXE_003D(float[] _0023_003Dzt5jpbHs_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, bool _0023_003DzKs6hunzjen4G)
	{
		if (CompilingEntity != null)
		{
			_0023_003Dzped9ZPq4ahes(_0023_003Dzt5jpbHs_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G);
			return;
		}
		_0023_003DzxbCbL_0024mWtybX._0023_003DzhzizObU_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D);
		_0023_003DzxbCbL_0024mWtybX._0023_003Dz99kJFjE_003D(this);
	}

	private void _0023_003Dz8UwOt6tpkImF(_0023_003Dzs1_1VPmRkeowoF853hihJLs_003D _0023_003DzSVpkYxU_003D, float[] _0023_003Dzt5jpbHs_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, bool _0023_003DzKs6hunzjen4G, bool _0023_003Dz9Yc_0024ROw_003D, shaderType _0023_003DzqP_0024Pj_0_003D)
	{
		if (CompilingEntity != null)
		{
			_0023_003Dzped9ZPq4ahes(_0023_003Dzt5jpbHs_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G);
			return;
		}
		if (!_0023_003DzSVpkYxU_003D._0023_003Dz_0024_DPFp19tOjE(_0023_003Dzt5jpbHs_003D.Length))
		{
			_0023_003DzW5PWAngs9S9h(_0023_003DzSVpkYxU_003D, _0023_003Dz9Yc_0024ROw_003D, _0023_003DzqP_0024Pj_0_003D);
		}
		_0023_003DzSVpkYxU_003D._0023_003DzgWaA5Nc_003D(_0023_003DzSVpkYxU_003D._0023_003DzpGRLDJ0OtMj0(), _0023_003Dzt5jpbHs_003D, null, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, 0, _0023_003Dzp_0024qFwgs_003D: false);
	}

	private void _0023_003Dz2CJ_0024wXE_003D(float[] _0023_003Dzt5jpbHs_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, int _0023_003Dz4Im51Qk_003D)
	{
		if (CompilingEntity != null)
		{
			_0023_003Dzped9ZPq4ahes(_0023_003Dzt5jpbHs_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, _0023_003Dz4Im51Qk_003D, _0023_003DzKs6hunzjen4G: false);
			return;
		}
		_0023_003DzxbCbL_0024mWtybX._0023_003DzhzizObU_003D(_0023_003Dzt5jpbHs_003D, 0, _0023_003Dzt5jpbHs_003D.Length, _0023_003DzRbrcOgQ_003D, _0023_003Dzdo7ctlc_003D, 0, _0023_003Dz4Im51Qk_003D, _0023_003DzQZ1JmC0_003D);
		_0023_003DzxbCbL_0024mWtybX._0023_003Dz99kJFjE_003D(this);
	}

	public override void DrawLine(float[] linePoints)
	{
		_0023_003Dz2CJ_0024wXE_003D(linePoints, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLine(float x0, float y0, float z0, float x1, float y1, float z1)
	{
		DrawLine(new float[6] { x0, y0, z0, x1, y1, z1 });
	}

	public override void DrawLine(Point2D p0, Point2D p1)
	{
		DrawLine((float)p0.X, (float)p0.Y, 0f, (float)p1.X, (float)p1.Y, 0f);
	}

	public override void DrawLine(Point3D p0, Point3D p1)
	{
		DrawLine((float)p0.X, (float)p0.Y, (float)p0.Z, (float)p1.X, (float)p1.Y, (float)p1.Z);
	}

	public override void DrawLine(PointRGB p0, PointRGB p1)
	{
		PushShader();
		SetShader(shaderType.MultiColorNoLights);
		float[] _0023_003Dzt5jpbHs_003D = new float[14]
		{
			(float)p0.X,
			(float)p0.Y,
			(float)p0.Z,
			(float)(int)p0.R / 256f,
			(float)(int)p0.G / 256f,
			(float)(int)p0.B / 256f,
			1f,
			(float)p1.X,
			(float)p1.Y,
			(float)p1.Z,
			(float)(int)p1.R / 256f,
			(float)(int)p1.G / 256f,
			(float)(int)p1.B / 256f,
			1f
		};
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: false);
		PopShader();
	}

	public override void DrawLine(Point3D p0, Point3D p1, Point2D texCoords)
	{
		_0023_003Dz2CJ_0024wXE_003D(new float[14]
		{
			(float)p0.X,
			(float)p0.Y,
			(float)p0.Z,
			0f,
			0f,
			0f,
			(float)texCoords.X,
			(float)p1.X,
			(float)p1.Y,
			(float)p1.Z,
			0f,
			0f,
			0f,
			(float)texCoords.Y
		}, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLines(float[] vertices, int first, int count)
	{
		PackData(ref vertices, 3, first, count);
		_0023_003Dz0Bcc8cVsLrG4(vertices, 3, count);
	}

	private void _0023_003Dz0Bcc8cVsLrG4(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int _0023_003Dzk1qYfgmbcPgvVkTW_g_003D_003D, int _0023_003DzPH_0024hvqk_003D)
	{
		if (CompilingEntity != null)
		{
			_0023_003Dzped9ZPq4ahes(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, primitiveType.LineList, _0023_003DzPH_0024hvqk_003D, _0023_003DzKs6hunzjen4G: false);
			return;
		}
		_0023_003DzxbCbL_0024mWtybX._0023_003DzhzizObU_003D(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, 0, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, primitiveType.LineList, _0023_003DzPH_0024hvqk_003D);
		_0023_003DzxbCbL_0024mWtybX._0023_003Dz99kJFjE_003D(this);
	}

	public override void DrawLines(Point3D[] vertices, int first, int count)
	{
		DrawLines(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(vertices, first, count, _0023_003DzN_MOKU7jsa0t: false));
	}

	public override void DrawLines(Point3D[] vertices, System.Drawing.Color[] colors, int first, int count)
	{
		float[] array = new float[count * 7];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = first; i < count; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, colors[i], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz0Bcc8cVsLrG4(array, 7, count);
	}

	public override void DrawLines(Point3D[] vertices, System.Drawing.Color[] colors, float[] lineWidths, int first, int count)
	{
		float[] array = new float[count * 8];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = first; i < count; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, colors[i], ref _0023_003DzPH_0024hvqk_003D);
			array[_0023_003DzPH_0024hvqk_003D++] = lineWidths[i / 2];
		}
		_0023_003Dz0Bcc8cVsLrG4(array, 8, count);
	}

	public override void DrawLineStrip(float[] vertices, int first, int count)
	{
		PackData(ref vertices, 3, first, count);
		_0023_003Dz2CJ_0024wXE_003D(vertices, primitiveType.LineStrip, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineStripRGBA(float[] vertices, int first, int count)
	{
		PackData(ref vertices, 7, first, count);
		_0023_003Dz2CJ_0024wXE_003D(vertices, primitiveType.LineStrip, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineStrip(Point2D[] vertices, int first, int count)
	{
		DrawLineStrip(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(vertices), first, count);
	}

	public override void DrawLineStrip(Point3D[] vertices, int first, int count)
	{
		DrawLineStrip(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(vertices), first, count);
	}

	public override void DrawLineStrip(PointRGB[] vertices, int first, int count)
	{
		DrawLineStripRGBA(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzE8czomGZ4WksTGP5mw_003D_003D(vertices), first, count);
	}

	public override void DrawLineStrip(Point3D[] vertices, float[] texCoords, int first, int count)
	{
		float[] array = new float[(count - first) * 7];
		int num = 0;
		for (int i = first; i < count; i++)
		{
			Point3D point3D = vertices[i];
			array[num++] = (float)point3D.X;
			array[num++] = (float)point3D.Y;
			array[num++] = (float)point3D.Z;
			array[num++] = 0f;
			array[num++] = 0f;
			array[num++] = 0f;
			array[num++] = texCoords[i];
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.LineStrip, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLines(Point3D[] vertices, float[] texCoords, int first, int count)
	{
		float[] array = new float[count * 7];
		int _0023_003DzPH_0024hvqk_003D = 0;
		Vector3D _0023_003Dz3kjjQlQ_003D = new Vector3D();
		for (int i = first; i < count; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, _0023_003Dz3kjjQlQ_003D, ref _0023_003DzPH_0024hvqk_003D);
			array[_0023_003DzPH_0024hvqk_003D++] = texCoords[i];
		}
		_0023_003Dz0Bcc8cVsLrG4(array, 7, count);
	}

	public override void DrawPointsIndeterminate(float[] points, int first, int count)
	{
		DrawPoints(points, first, count);
	}

	public override void DrawPointsWithNormalsIndeterminate(float[] points, float[] normals, int first, int count)
	{
		int num = count * 3;
		float[] array = new float[points.Length * 2];
		int num2 = first * 3;
		int num3 = first * 3;
		while (num2 < num)
		{
			array[num2] = points[num2++];
			array[num2] = points[num2++];
			array[num2] = points[num2++];
			array[num3] = normals[num3++];
			array[num3] = normals[num3++];
			array[num3] = normals[num3++];
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPoints(float[] points, int first, int count)
	{
		PackData(ref points, 3, first, count);
		_0023_003Dz2CJ_0024wXE_003D(points, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsIndeterminate(Point3D[] points, int first, int count)
	{
		DrawPoints(points, first, count);
	}

	public override void DrawPointsWithColorsRGBIndeterminate(float[] points, byte[] colors, int first, int count)
	{
		float[] array = new float[count * 7];
		int num = first * 3;
		int num2 = first * 3;
		int num3 = 0;
		for (int i = 0; i < count; i++)
		{
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = 1f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsWithColorsRGBAIndeterminate(float[] points, byte[] colors, int first, int count)
	{
		float[] array = new float[count * 7];
		int num = first * 3;
		int num2 = first * 4;
		int num3 = 0;
		for (int i = 0; i < count; i++)
		{
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsWithColorIntensitiesIndeterminate(float[] points, byte[] colors, int first, int count)
	{
		float[] array = new float[count * 7];
		int num = first * 3;
		int num2 = first;
		int num3 = 0;
		for (int i = 0; i < count; i++)
		{
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = 1f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsRGB(Point3D[] points, int first, int count)
	{
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DztEk3ypKZZaD9(points, first, count), primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsRGBIndeterminate(Point3D[] points, int first, int count)
	{
		DrawPointsRGB(points, first, count);
	}

	public override void DrawPoints(Point3D[] points, int first, int count)
	{
		DrawPoints(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(points, 0, count, _0023_003DzN_MOKU7jsa0t: false), first, count);
	}

	public override void DrawPointsWithNormals(Point3D[] points, Vector3D[] normals, int first, int count)
	{
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzt5OBdcRczGuHRDp_002432bsClw_003D(points, normals, first, count), primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsWithNormalsIndeterminate(Point3D[] points, Vector3D[] normals, int first, int count)
	{
		DrawPointsWithNormals(points, normals, first, count);
	}

	public override void DrawIndeterminateAsPoints(EntityGraphicsData data)
	{
		_0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU _0023_003DzyO_593HDldkn = ((D3DEntityGraphicsData)data)._0023_003DzyO_593HDldkn;
		if (_0023_003DzyO_593HDldkn == null)
		{
			ThrowEntityNotCompiledError(data);
		}
		_0023_003DzyO_593HDldkn._0023_003Dzz8j8G7g_003D[0]._0023_003Dz_002475wn_0024QGlEFt(primitiveType.PointList);
		_0023_003DzyO_593HDldkn._0023_003Dz99kJFjE_003D(this);
	}

	public override void DrawIndeterminateAsLineStrip(EntityGraphicsData data)
	{
		_0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU _0023_003DzyO_593HDldkn = ((D3DEntityGraphicsData)data)._0023_003DzyO_593HDldkn;
		if (_0023_003DzyO_593HDldkn == null)
		{
			ThrowEntityNotCompiledError(data);
		}
		_0023_003DzyO_593HDldkn._0023_003Dzz8j8G7g_003D[0]._0023_003Dz_002475wn_0024QGlEFt(primitiveType.LineStrip);
		_0023_003DzyO_593HDldkn._0023_003Dz99kJFjE_003D(this);
	}

	public override void DrawIndeterminateAsLineList(EntityGraphicsData data)
	{
		_0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU _0023_003DzyO_593HDldkn = ((D3DEntityGraphicsData)data)._0023_003DzyO_593HDldkn;
		if (_0023_003DzyO_593HDldkn == null)
		{
			ThrowEntityNotCompiledError(data);
		}
		_0023_003DzyO_593HDldkn._0023_003Dzz8j8G7g_003D[0]._0023_003Dz_002475wn_0024QGlEFt(primitiveType.LineList);
		_0023_003DzyO_593HDldkn._0023_003Dz99kJFjE_003D(this);
	}

	public override void DrawQuadsOutlines(Point3D[] vertices)
	{
		List<float> list = new List<float>(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(vertices));
		int num = 0;
		for (int i = 0; i < vertices.Length; i += 4)
		{
			List<float> range = list.GetRange(num, num + 12);
			range.Add(range[0]);
			range.Add(range[1]);
			range.Add(range[2]);
			_0023_003Dz2CJ_0024wXE_003D(range.ToArray(), primitiveType.LineStrip, 5, _0023_003DzKs6hunzjen4G: false);
			num += 12;
		}
	}

	public override void DrawQuad(System.Drawing.RectangleF rect, float zCoord)
	{
		float[] _0023_003Dzt5jpbHs_003D = new float[12]
		{
			rect.Left, rect.Bottom, zCoord, rect.Left, rect.Top, zCoord, rect.Right, rect.Bottom, zCoord, rect.Right,
			rect.Top, zCoord
		};
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleStrip, 4, _0023_003DzKs6hunzjen4G: false);
	}

	protected override void DrawQuadWithColorRange(System.Drawing.RectangleF rect, System.Drawing.Color color1, System.Drawing.Color color2)
	{
		Vector4 vector = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(color1);
		Vector4 vector2 = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(color2);
		float[] _0023_003Dzt5jpbHs_003D = new float[28]
		{
			rect.Left,
			rect.Bottom,
			0f,
			vector2[0],
			vector2[1],
			vector2[2],
			vector2[3],
			rect.Left,
			rect.Top,
			0f,
			vector[0],
			vector[1],
			vector[2],
			vector[3],
			rect.Right,
			rect.Bottom,
			0f,
			vector2[0],
			vector2[1],
			vector2[2],
			vector2[3],
			rect.Right,
			rect.Top,
			0f,
			vector[0],
			vector[1],
			vector[2],
			vector[3]
		};
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleStrip, 4, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawQuadWithTextures(TextureBase texture, float[] texCoords, byte alpha, System.Drawing.RectangleF rect, float zCoord, bool buffered)
	{
		SetTexture(texture);
		float[] array = ((!(texture is D3DTexture2D) && !(texture is D3DTextureDepth)) ? new float[28]
		{
			rect.Left,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[4],
			rect.Left,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[0],
			rect.Right,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[6],
			rect.Right,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[2]
		} : new float[32]
		{
			rect.Left,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[6],
			texCoords[7],
			rect.Left,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[0],
			texCoords[1],
			rect.Right,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[4],
			texCoords[5],
			rect.Right,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[2],
			texCoords[3]
		});
		if (buffered)
		{
			int[] _0023_003Dzdo7ctlc_003D = new int[6]
			{
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 1,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 2,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 1,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 3,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 2
			};
			if (!_0023_003DzxbCbL_0024mWtybX._0023_003Dz_0024_DPFp19tOjE(array.Length))
			{
				DrawCurrentBuffer();
			}
			_0023_003DzxbCbL_0024mWtybX._0023_003DzgWaA5Nc_003D(_0023_003DzxbCbL_0024mWtybX._0023_003DzpGRLDJ0OtMj0(), array, _0023_003Dzdo7ctlc_003D, primitiveType.TriangleList, 4, 6, _0023_003Dzp_0024qFwgs_003D: false);
		}
		else
		{
			_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleStrip, 4, _0023_003DzKs6hunzjen4G: false);
		}
	}

	protected internal override void DrawQuadWithTextures(TextureBase[] textures, float[] texCoords, byte alpha, System.Drawing.RectangleF rect, float zCoord, bool buffered)
	{
		for (int i = 0; i < textures.Length; i++)
		{
			SetTexture(textures[i], (TextureBase.textureUnitType)i);
		}
		float[] array = ((!(textures[0] is D3DTexture2D) && !(textures[0] is D3DTextureDepth)) ? new float[28]
		{
			rect.Left,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[4],
			rect.Left,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[0],
			rect.Right,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[6],
			rect.Right,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[2]
		} : new float[32]
		{
			rect.Left,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[6],
			texCoords[7],
			rect.Left,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[0],
			texCoords[1],
			rect.Right,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[4],
			texCoords[5],
			rect.Right,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[2],
			texCoords[3]
		});
		if (buffered)
		{
			int[] _0023_003Dzdo7ctlc_003D = new int[6]
			{
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 1,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 2,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 1,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 3,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 2
			};
			if (!_0023_003DzxbCbL_0024mWtybX._0023_003Dz_0024_DPFp19tOjE(array.Length))
			{
				DrawCurrentBuffer();
			}
			_0023_003DzxbCbL_0024mWtybX._0023_003DzgWaA5Nc_003D(_0023_003DzxbCbL_0024mWtybX._0023_003DzpGRLDJ0OtMj0(), array, _0023_003Dzdo7ctlc_003D, primitiveType.TriangleList, 4, 6, _0023_003Dzp_0024qFwgs_003D: false);
		}
		else
		{
			_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleStrip, 4, _0023_003DzKs6hunzjen4G: false);
		}
		for (int j = 0; j < textures.Length; j++)
		{
			CloseTexture((TextureBase.textureUnitType)j);
		}
	}

	private void _0023_003DzW5PWAngs9S9h(_0023_003Dzs1_1VPmRkeowoF853hihJLs_003D _0023_003DzSVpkYxU_003D, bool _0023_003Dz9Yc_0024ROw_003D, shaderType _0023_003DzqP_0024Pj_0_003D)
	{
		if (_0023_003DzSVpkYxU_003D._0023_003Dz6ym_OKwKktrt.Count > 0 && _0023_003DzSVpkYxU_003D._0023_003Dz6ym_OKwKktrt[0].Count > 0)
		{
			if (_0023_003Dz9Yc_0024ROw_003D)
			{
				PushRasterizerState();
				PushShader();
				SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
				SetShader(_0023_003DzqP_0024Pj_0_003D);
			}
			_0023_003DzSVpkYxU_003D._0023_003DzhzizObU_003D();
			_0023_003DzSVpkYxU_003D._0023_003Dz99kJFjE_003D(this);
			if (_0023_003Dz9Yc_0024ROw_003D)
			{
				PopRasterizerState();
				PopShader();
			}
		}
	}

	public override void DrawCurrentBuffer()
	{
		_0023_003DzW5PWAngs9S9h(_0023_003DzxbCbL_0024mWtybX, _0023_003Dz9Yc_0024ROw_003D: false, shaderType.None);
	}

	public override void EndDrawBufferedLines()
	{
		_0023_003DzW5PWAngs9S9h(_0023_003DzYpDxbNl_WsmZ, !lineStipple, shaderType.MultiColorNoLights);
		_0023_003DzW5PWAngs9S9h(_0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D, !lineStipple, shaderType.MultiColorNoLightsThickLinesPerVertex);
		_0023_003DzW5PWAngs9S9h(_0023_003DzhNCOIdKjRgee, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLights);
		_0023_003DzW5PWAngs9S9h(_0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLightsThickPointsPerVertex);
	}

	public override void DrawQuads(Point3D[] vertices, Vector3D[] normals, int first, int count)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzYD8zfIi355st(vertices, normals, first, count);
		int[] array = new int[count / 4 * 6];
		int num = 0;
		for (int i = 0; i < count; i += 4)
		{
			array[num++] = i;
			array[num++] = i + 1;
			array[num++] = i + 3;
			array[num++] = i + 1;
			array[num++] = i + 2;
			array[num++] = i + 3;
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, array, primitiveType.TriangleList, count, array.Length);
	}

	public override void DrawSilhouettes(GfxSilhoData silho)
	{
		if (silho.VertexArrayData.indicesCount * 2 != 0)
		{
			int indicesCount = silho.VertexArrayData.indicesCount;
			float[] array = new float[indicesCount * 6];
			int num = 0;
			for (int i = 0; i < indicesCount; i++)
			{
				int num2 = silho.VertexArrayData.indices[i, 0];
				int num3 = silho.VertexArrayData.indices[i, 1];
				array[num++] = silho.Vertices[num2, 0];
				array[num++] = silho.Vertices[num2, 1];
				array[num++] = silho.Vertices[num2, 2];
				array[num++] = silho.Vertices[num3, 0];
				array[num++] = silho.Vertices[num3, 1];
				array[num++] = silho.Vertices[num3, 2];
			}
			_0023_003DzxbCbL_0024mWtybX._0023_003DzhzizObU_003D(array, primitiveType.LineList, indicesCount * 2);
			_0023_003DzxbCbL_0024mWtybX._0023_003Dz99kJFjE_003D(this);
		}
	}

	public override void DrawLinesAndPointsOnTheFly(Point3D[] linesVertices, Point3D[] pointsVertices)
	{
		if (linesVertices.Length != 0)
		{
			int num = linesVertices.Length * 3;
			if (_0023_003DzTx0khkogHMfe == null)
			{
				_0023_003DzTx0khkogHMfe = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, num, 0);
			}
			else if (num > _0023_003DzTx0khkogHMfe._0023_003DzpGRLDJ0OtMj0())
			{
				_0023_003DzTx0khkogHMfe.Dispose();
				_0023_003DzTx0khkogHMfe = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, num, 0);
			}
			SetShader((base.CurrentLineWidth > 1f) ? shaderType.NoLightsThickLines : shaderType.NoLights);
			_0023_003DzTx0khkogHMfe._0023_003DzhQeEkCjQWpqU(linesVertices, primitiveType.LineList, linesVertices.Length);
			_0023_003DzTx0khkogHMfe._0023_003Dz99kJFjE_003D(this);
		}
		DrawPointsOnTheFly(pointsVertices);
	}

	public override void DrawPointsOnTheFly(Point3D[] pointsVertices)
	{
		if (pointsVertices.Length != 0)
		{
			int num = pointsVertices.Length * 3;
			if (_0023_003DzcsNzRnBprL0v == null)
			{
				_0023_003DzcsNzRnBprL0v = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, num, 0);
			}
			else if (num > _0023_003DzcsNzRnBprL0v._0023_003DzpGRLDJ0OtMj0())
			{
				_0023_003DzcsNzRnBprL0v.Dispose();
				_0023_003DzcsNzRnBprL0v = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, num, 0);
			}
			SetShader((base.CurrentLineWidth > 1f) ? shaderType.NoLightsThickPoints : shaderType.NoLights);
			_0023_003DzcsNzRnBprL0v._0023_003DzhQeEkCjQWpqU(pointsVertices, primitiveType.PointList, pointsVertices.Length);
			_0023_003DzcsNzRnBprL0v._0023_003Dz99kJFjE_003D(this);
		}
	}

	public override void DrawNormals(Point3D[] vertices, Vector3D diffVector)
	{
		Point3D[] array = new Point3D[12];
		int num = vertices.Length / 6;
		int num2 = vertices.Length % 6;
		int num3 = 0;
		int num4 = 0;
		while (num4 < num)
		{
			int num5 = 0;
			int num6 = 0;
			while (num6 < 6)
			{
				array[num5++] = vertices[num3];
				array[num5++] = vertices[num3] + diffVector;
				num6++;
				num3++;
			}
			DrawLines(array);
			num4++;
			num3++;
		}
		if (num2 > 0)
		{
			array = new Point3D[num2 * 2];
			int num7 = 0;
			int num8 = 0;
			while (num8 < num2)
			{
				array[num7++] = vertices[num3];
				array[num7++] = vertices[num3] + diffVector;
				num8++;
				num3++;
			}
			DrawLines(array);
		}
	}

	private void _0023_003DzI0krhr3o0LGChFWi9Q_003D_003D(Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, Vector3D[] _0023_003DzQPpxw1Hu0Rft)
	{
		Point3D[] array = new Point3D[12];
		int num = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length / 6;
		int num2 = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length % 6;
		int num3 = 0;
		for (int i = 0; i < num; i++)
		{
			int num4 = 0;
			int num5 = 0;
			while (num5 < 6)
			{
				array[num4++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3];
				array[num4++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3] + _0023_003DzQPpxw1Hu0Rft[num3];
				num5++;
				num3++;
			}
			DrawLines(array);
		}
		if (num2 > 0)
		{
			array = new Point3D[num2 * 2];
			int num6 = 0;
			int num7 = 0;
			while (num7 < num2)
			{
				array[num6++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3];
				array[num6++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3] + _0023_003DzQPpxw1Hu0Rft[num3];
				num7++;
				num3++;
			}
			DrawLines(array);
		}
	}

	public override void DrawNormals(Point3D[] vertices, IndexTriangle[] triangles, Vector3D[] normals, double length)
	{
		for (int i = 0; i < triangles.Length; i++)
		{
			IndexTriangle indexTriangle = triangles[i];
			Point3D[] vertices2 = new Point3D[3]
			{
				vertices[indexTriangle.V1],
				vertices[indexTriangle.V2],
				vertices[indexTriangle.V3]
			};
			Vector3D diffVector = normals[i] * length;
			DrawNormals(vertices2, diffVector);
		}
	}

	public override void DrawSurfaceNormals(Point3D[] vertices, double length)
	{
		for (int i = 0; i < vertices.Length; i++)
		{
			PointNormalUv pointNormalUv = (PointNormalUv)vertices[i];
			DrawLine(pointNormalUv, pointNormalUv + pointNormalUv.Normal * length);
		}
	}

	public override void DrawNormalsPerVertex(Point3D[] vertices, IndexTriangle[] triangles, Vector3D[] normals, double length)
	{
		Point3D[] array = new Point3D[3];
		Vector3D[] array2 = new Vector3D[3];
		for (int i = 0; i < triangles.Length; i++)
		{
			SmoothTriangle smoothTriangle = (SmoothTriangle)triangles[i];
			array[0] = vertices[smoothTriangle.V1];
			array[1] = vertices[smoothTriangle.V2];
			array[2] = vertices[smoothTriangle.V3];
			array2[0] = normals[smoothTriangle.N1] * length;
			array2[1] = normals[smoothTriangle.N2] * length;
			array2[2] = normals[smoothTriangle.N3] * length;
			_0023_003DzI0krhr3o0LGChFWi9Q_003D_003D(array, array2);
		}
	}

	public override void DrawTriangles2D(Point2D[] vertices)
	{
		_0023_003Dz_0024ZebKH8Z4i0x1lh_0024RSMM0BDxj74i(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(vertices));
	}

	public override void DrawTriangles2D(float[] vertices)
	{
		float[] array = new float[3 * vertices.Length / 2];
		int num = 0;
		int num2 = 0;
		while (num2 < vertices.Length)
		{
			array[num++] = vertices[num2++];
			array[num++] = vertices[num2++];
			array[num++] = 0f;
		}
		_0023_003Dz_0024ZebKH8Z4i0x1lh_0024RSMM0BDxj74i(array);
	}

	private void _0023_003Dz_0024ZebKH8Z4i0x1lh_0024RSMM0BDxj74i(float[] _0023_003DzdtK6iedptbUWR7yytg_003D_003D)
	{
		int _0023_003DzRbrcOgQ_003D = _0023_003DzdtK6iedptbUWR7yytg_003D_003D.Length / 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003DzdtK6iedptbUWR7yytg_003D_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTrianglesFan2D(float[] vertices)
	{
		int num = 3 * (vertices.Length / 2 - 2);
		float[] array = new float[3 * num];
		int num2 = 0;
		int num3 = 2;
		while (num3 < vertices.Length - 2)
		{
			array[num2++] = vertices[0];
			array[num2++] = vertices[1];
			array[num2++] = 0f;
			array[num2++] = vertices[num3++];
			array[num2++] = vertices[num3++];
			array[num2++] = 0f;
			array[num2++] = vertices[num3];
			array[num2++] = vertices[num3 + 1];
			array[num2++] = 0f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTrianglesFan(Point3D[] vertices, Vector3D normal)
	{
		int num = 3 * (vertices.Length - 2);
		float[] array = new float[3 * num];
		int num2 = 0;
		int num3 = 1;
		while (num3 < vertices.Length - 1)
		{
			array[num2++] = (float)vertices[0].X;
			array[num2++] = (float)vertices[0].Y;
			array[num2++] = (float)vertices[0].Z;
			array[num2++] = (float)vertices[num3].X;
			array[num2++] = (float)vertices[num3].Y;
			array[num2++] = (float)vertices[num3].Z;
			array[num2++] = (float)vertices[++num3].X;
			array[num2++] = (float)vertices[num3].Y;
			array[num2++] = (float)vertices[num3].Z;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTriangles(Point3D[] vertices)
	{
		int num = vertices.Length;
		float[] _0023_003Dzt5jpbHs_003D = new float[3 * num];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < vertices.Length; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D normal)
	{
		int num = vertices.Length;
		float[] _0023_003Dzt5jpbHs_003D = new float[6 * num];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < vertices.Length; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, normal, ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D[] normals, float[] texCoords, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		float[] _0023_003Dzt5jpbHs_003D = new float[num * 7];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < vertices.Length; i += 3)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], texCoords[i], texCoords[i + 1], texCoords[i + 2], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D[] normals, System.Drawing.Color[] colors, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		float[] _0023_003Dzt5jpbHs_003D = new float[num * 10];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < vertices.Length; i += 3)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], colors[i], colors[i + 1], colors[i + 2], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords = null, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] _0023_003Dzt5jpbHs_003D;
		if (texCoords == null)
		{
			_0023_003Dzt5jpbHs_003D = new float[6 * num];
			for (int i = 0; i < vertices.Length; i += 3)
			{
				_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], ref _0023_003DzPH_0024hvqk_003D);
			}
		}
		else
		{
			_0023_003Dzt5jpbHs_003D = new float[10 * num];
			for (int j = 0; j < vertices.Length; j += 3)
			{
				_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[j], vertices[j + 1], vertices[j + 2], normals[j], normals[j + 1], normals[j + 2], texCoords[j], texCoords[j + 1], texCoords[j + 2], ref _0023_003DzPH_0024hvqk_003D);
			}
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart);
	}

	public override void DrawTrianglesPartialWithMaterialColor(Point3D[] vertices, Vector3D[] normals, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] _0023_003Dzt5jpbHs_003D = new float[10 * num];
		for (int i = 0; i < vertices.Length; i += 3)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], base.CurrentMaterial.Diffuse, base.CurrentMaterial.Diffuse, base.CurrentMaterial.Diffuse, ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz8UwOt6tpkImF(_0023_003DzxbCbL_0024mWtybX, _0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart, _0023_003Dz9Yc_0024ROw_003D: false, shaderType.None);
	}

	public override void DrawTrianglesPartialWithTexture(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] _0023_003Dzt5jpbHs_003D = new float[8 * num];
		for (int i = 0; i < vertices.Length; i += 3)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], texCoords[i], texCoords[i + 1], texCoords[i + 2], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz8UwOt6tpkImF(_0023_003DzxbCbL_0024mWtybX, _0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart, _0023_003Dz9Yc_0024ROw_003D: false, shaderType.None);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D[] normals, IndexTriangle[] triangles, PointF[] texCoords)
	{
		int num = triangles.Length * 3;
		float[] _0023_003Dzt5jpbHs_003D;
		if (texCoords != null)
		{
			_0023_003Dzt5jpbHs_003D = new float[num * 8];
			int _0023_003DzPH_0024hvqk_003D = 0;
			for (int i = 0; i < triangles.Length; i++)
			{
				SmoothTriangle smoothTriangle = (SmoothTriangle)triangles[i];
				_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[smoothTriangle.V1], vertices[smoothTriangle.V2], vertices[smoothTriangle.V3], normals[smoothTriangle.N1], normals[smoothTriangle.N2], normals[smoothTriangle.N3], texCoords[smoothTriangle.V1], texCoords[smoothTriangle.V2], texCoords[smoothTriangle.V3], ref _0023_003DzPH_0024hvqk_003D);
			}
		}
		else
		{
			_0023_003Dzt5jpbHs_003D = new float[triangles.Length * 18];
			int _0023_003DzPH_0024hvqk_003D2 = 0;
			for (int j = 0; j < triangles.Length; j++)
			{
				SmoothTriangle smoothTriangle2 = (SmoothTriangle)triangles[j];
				_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[smoothTriangle2.V1], vertices[smoothTriangle2.V2], vertices[smoothTriangle2.V3], normals[smoothTriangle2.N1], normals[smoothTriangle2.N2], normals[smoothTriangle2.N3], ref _0023_003DzPH_0024hvqk_003D2);
			}
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTrianglesPlanar(Point3D[] vertices, IndexTriangle[] triangles, Vector3D normal)
	{
		DrawTrianglesPlanar(vertices, RenderContextBase.GetIndicesFromTriangles(triangles), normal);
	}

	public override void DrawTrianglesPlanar(Point3D[] vertices, int[] trianglesIndices, Vector3D normal)
	{
		float[] array = new float[vertices.Length * 2 * 3];
		int _0023_003DzPH_0024hvqk_003D = 0;
		int num = 0;
		while (num < vertices.Length)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, vertices[num++], ref _0023_003DzPH_0024hvqk_003D);
			array[_0023_003DzPH_0024hvqk_003D++] = (float)normal.X;
			array[_0023_003DzPH_0024hvqk_003D++] = (float)normal.Y;
			array[_0023_003DzPH_0024hvqk_003D++] = (float)normal.Z;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, trianglesIndices, primitiveType.TriangleList, vertices.Length, (trianglesIndices != null) ? trianglesIndices.Length : 0);
	}

	public override void DrawQuads2D(float[] vertices)
	{
		int num = vertices.Length / 2;
		float[] array = new float[3 * num];
		int[] array2 = new int[num / 4 * 6];
		int num2 = 0;
		int num3 = 0;
		while (num2 < vertices.Length)
		{
			array[num3++] = vertices[num2++];
			array[num3++] = vertices[num2++];
			array[num3++] = 0f;
		}
		int i = 0;
		int num4 = 0;
		for (; i < num; i += 4)
		{
			array2[num4++] = i;
			array2[num4++] = i + 1;
			array2[num4++] = i + 3;
			array2[num4++] = i + 1;
			array2[num4++] = i + 2;
			array2[num4++] = i + 3;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, array2, primitiveType.TriangleList, num, array2.Length);
	}

	public override void DrawLines2D(float[] vertices)
	{
		int num = vertices.Length / 2;
		float[] array = new float[3 * num];
		int num2 = 0;
		int num3 = 0;
		while (num3 < vertices.Length)
		{
			array[num2++] = vertices[num3++];
			array[num2++] = vertices[num3++];
			array[num2++] = 0f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.LineList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineLoop(Point2D[] vertices, int first, int count)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(vertices, first, count, _0023_003DzN_MOKU7jsa0t: true);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineStrip, count + 1, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineLoop(Point3D[] vertices, int first, int count)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(vertices, first, count, _0023_003DzN_MOKU7jsa0t: true);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineStrip, count + 1, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawIndexLines(IList<IndexLine> lines, Point3D[] vertices)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzxt_0024C4mfsru6P(lines, vertices, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, _0023_003DzVKEHOoE_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawIndexLines(IList<IndexLine> lines, float[] vertices)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzxt_0024C4mfsru6P(lines, vertices, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, _0023_003DzVKEHOoE_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawIndexLinesWithDisplacement(IList<IndexLine> lines, Point3D[] vertices, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzJDIVJsRbg20OVXIybQ_003D_003D(lines, vertices, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawLinesWithDisplacement(Point3D[] vertices, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz9AhjvKeUMMns(vertices, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawBufferedLine(Point3D v0, Point3D v1)
	{
		Vector4 vector = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(base.CurrentWireColor);
		if (base.CurrentLineWidth > 1f)
		{
			float[] _0023_003Dzt5jpbHs_003D = new float[16]
			{
				(float)v0.X,
				(float)v0.Y,
				(float)v0.Z,
				vector.X,
				vector.Y,
				vector.Z,
				vector.W,
				base.CurrentLineWidth,
				(float)v1.X,
				(float)v1.Y,
				(float)v1.Z,
				vector.X,
				vector.Y,
				vector.Z,
				vector.W,
				base.CurrentLineWidth
			};
			_0023_003Dz8UwOt6tpkImF(_0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D, _0023_003Dzt5jpbHs_003D, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: true, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLightsThickLinesPerVertex);
		}
		else
		{
			float[] _0023_003Dzt5jpbHs_003D2 = new float[14]
			{
				(float)v0.X,
				(float)v0.Y,
				(float)v0.Z,
				vector.X,
				vector.Y,
				vector.Z,
				vector.W,
				(float)v1.X,
				(float)v1.Y,
				(float)v1.Z,
				vector.X,
				vector.Y,
				vector.Z,
				vector.W
			};
			_0023_003Dz8UwOt6tpkImF(_0023_003DzYpDxbNl_WsmZ, _0023_003Dzt5jpbHs_003D2, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: true, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLights);
		}
	}

	public override void DrawBufferedPoint(Point3D v0)
	{
		if (base.CurrentPointSize > 1f)
		{
			Vector4 vector = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(base.CurrentWireColor);
			float[] _0023_003Dzt5jpbHs_003D = new float[8]
			{
				(float)v0.X,
				(float)v0.Y,
				(float)v0.Z,
				vector.X,
				vector.Y,
				vector.Z,
				vector.W,
				base.CurrentPointSize
			};
			_0023_003Dz8UwOt6tpkImF(_0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D, _0023_003Dzt5jpbHs_003D, primitiveType.PointList, 1, _0023_003DzKs6hunzjen4G: true, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLightsThickPointsPerVertex);
		}
		else
		{
			Vector4 vector2 = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(base.CurrentWireColor);
			float[] _0023_003Dzt5jpbHs_003D2 = new float[7]
			{
				(float)v0.X,
				(float)v0.Y,
				(float)v0.Z,
				vector2.X,
				vector2.Y,
				vector2.Z,
				vector2.W
			};
			_0023_003Dz8UwOt6tpkImF(_0023_003DzhNCOIdKjRgee, _0023_003Dzt5jpbHs_003D2, primitiveType.PointList, 1, _0023_003DzKs6hunzjen4G: true, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLights);
		}
	}

	public override void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, System.Drawing.Color singleColor, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(vertices, normals, singleColor, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, System.Drawing.Color[] colors, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(vertices, normals, colors, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(vertices, normals, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, float[] tex1DCoords, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(vertices, normals, tex1DCoords, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void Draw(EntityGraphicsData data, primitiveType primitiveType = primitiveType.Undefined, uint? indexOffset = null, uint? indexCount = null)
	{
		_0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU _0023_003DzyO_593HDldkn = ((D3DEntityGraphicsData)data)._0023_003DzyO_593HDldkn;
		if (_0023_003DzyO_593HDldkn == null)
		{
			ThrowEntityNotCompiledError(data);
		}
		for (int i = 0; i < _0023_003DzyO_593HDldkn._0023_003Dzz8j8G7g_003D.Count; i++)
		{
			vertexBufferData vertexBufferData2 = _0023_003DzyO_593HDldkn._0023_003Dzz8j8G7g_003D[i];
			switch (primitiveType)
			{
			case primitiveType.PointList:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(PrimitiveTopology.PointList._0023_003DzOC8oSVZPCqOX());
				break;
			case primitiveType.LineStrip:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(PrimitiveTopology.LineStrip._0023_003DzOC8oSVZPCqOX());
				break;
			case primitiveType.LineList:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(PrimitiveTopology.LineList._0023_003DzOC8oSVZPCqOX());
				break;
			case primitiveType.TriangleList:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(PrimitiveTopology.TriangleList._0023_003DzOC8oSVZPCqOX());
				break;
			case primitiveType.TriangleStrip:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(PrimitiveTopology.TriangleStrip._0023_003DzOC8oSVZPCqOX());
				break;
			default:
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599011));
			case primitiveType.Undefined:
				break;
			}
			switch (vertexBufferData2._0023_003DzDX_IlROkgDgt())
			{
			case primitiveType.LineList:
				SetLinesShader((double)_0023_003Dz_BT7SDwEbLrP._0023_003DzUTdFkSI_003D > 1.0, base.CurrentShader);
				break;
			case primitiveType.PointList:
				SetPointsShader((double)_0023_003Dz_BT7SDwEbLrP._0023_003DzIt9jKuJG8ncE > 1.0, base.CurrentShader);
				break;
			}
			_0023_003DzyO_593HDldkn._0023_003Dz99kJFjE_003D(this, i, indexOffset, indexCount);
		}
	}

	protected override bool SetPointsShader(bool thick, shaderType shader, ShaderParameters shaderParams = null)
	{
		bool result;
		if (thick)
		{
			switch (shader)
			{
			case shaderType.StandardThickPoints:
			case shaderType.Standard:
			case shaderType.StandardShadow:
				result = SetShader(shaderType.StandardThickPoints);
				break;
			case shaderType.MultiColorNoLights:
				result = SetShader(shaderType.MultiColorNoLightsThickPoints, shaderParams);
				break;
			case shaderType.MultiColorNoLightsThickPoints:
				result = SetShader(shader, shaderParams);
				break;
			case shaderType.MultiColorNoLightsThickPointsPerVertex:
				result = true;
				break;
			case shaderType.SingleColorModulatedByIntensity:
			case shaderType.SingleColorModulatedByIntensityThickPoints:
				result = SetShader(shaderType.SingleColorModulatedByIntensityThickPoints, shaderParams);
				break;
			default:
				result = SetShader(shaderType.NoLightsThickPoints, shaderParams);
				break;
			}
			RemovePolygonOffset(ref prevPolygonOffset);
			SetPolygonDrawingMode(rasterizerPolygonDrawingType.Fill);
		}
		else
		{
			switch (shader)
			{
			case shaderType.MultiColorNoLightsThickPoints:
				result = SetShader(shaderType.MultiColorNoLights, shaderParams);
				break;
			case shaderType.MultiColorNoLightsThickPointsPerVertex:
				result = true;
				break;
			case shaderType.MultiColorNoLights:
				result = SetShader(shader, shaderParams);
				break;
			case shaderType.SingleColorModulatedByIntensity:
			case shaderType.SingleColorModulatedByIntensityThickPoints:
				result = SetShader(shaderType.SingleColorModulatedByIntensity, shaderParams);
				break;
			default:
				result = SetShader(shaderType.NoLights, shaderParams);
				break;
			}
			RestorePolygonOffset(ref prevPolygonOffset);
		}
		return result;
	}

	protected internal override bool SetLinesShader(bool thick, shaderType shader, ShaderParameters shaderParams = null)
	{
		bool result;
		if (thick)
		{
			if (lineStipple)
			{
				result = SetShader(shaderType.NoLightsThickLinesStipple, shaderParams);
			}
			else
			{
				switch (shader)
				{
				case shaderType.Standard:
					result = SetShader(shaderType.StandardThickLines);
					break;
				case shaderType.MultiColorNoLights:
				case shaderType.MultiColor:
					result = SetShader(shaderType.MultiColorNoLightsThickLines, shaderParams);
					break;
				case shaderType.MultiColorNoLightsThickLines:
					result = SetShader(shader, shaderParams);
					break;
				case shaderType.MultiColorNoLightsThickLinesPerVertex:
					result = true;
					break;
				case shaderType.Texture1DNoLights:
					result = SetShader(shaderType.Texture1DNoLightsThickLines, shaderParams);
					break;
				case shaderType.SingleColorModulatedByIntensity:
				case shaderType.SingleColorModulatedByIntensityThickLines:
					result = SetShader(shaderType.SingleColorModulatedByIntensityThickLines, shaderParams);
					break;
				default:
					result = SetShader(shaderType.NoLightsThickLines, shaderParams);
					break;
				}
			}
			RemovePolygonOffset(ref prevPolygonOffset);
			SetPolygonDrawingMode(rasterizerPolygonDrawingType.Fill);
		}
		else
		{
			if (lineStipple)
			{
				result = SetShader(shaderType.NoLightsLinesStipple);
			}
			else
			{
				switch (shader)
				{
				case shaderType.MultiColorNoLightsThickLinesPerVertex:
					result = true;
					break;
				case shaderType.MultiColorNoLightsThickLines:
					result = SetShader(shaderType.MultiColorNoLights, shaderParams);
					break;
				case shaderType.MultiColorNoLights:
					result = SetShader(shader, shaderParams);
					break;
				case shaderType.Texture1DNoLightsThickLines:
					result = SetShader(shaderType.Texture1DNoLights, shaderParams);
					break;
				case shaderType.MultiColorNoLightsThickPoints:
					result = SetShader(shaderType.MultiColorNoLights, shaderParams);
					break;
				case shaderType.SingleColorModulatedByIntensity:
				case shaderType.SingleColorModulatedByIntensityThickLines:
					result = SetShader(shaderType.SingleColorModulatedByIntensity, shaderParams);
					break;
				default:
					result = SetShader(shaderType.NoLights, shaderParams);
					break;
				}
			}
			RestorePolygonOffset(ref prevPolygonOffset);
		}
		return result;
	}

	public override void DrawRichPlainQuads(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords)
	{
		int num = vertices.Length / 4;
		IndexTriangle[] array = new IndexTriangle[num * 2];
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		while (num3 < num)
		{
			array[num2++] = new RichTriangle(num4, num4 + 1, num4 + 2, num4 + 3, num4 + 2, num4 + 1);
			array[num2++] = new RichTriangle(num4, num4 + 2, num4 + 3, num4 + 3, num4 + 1, num4);
			num3++;
			num4 += 4;
		}
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzMmiNe4P_GRNtsNvliw_003D_003D(vertices, normals, texCoords, array);
		int _0023_003DzRbrcOgQ_003D = array.Length * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawQuadStrip(Point3D[] vertices, Vector3D[] normals, int first, int count)
	{
		int num = count - 2;
		float[] _0023_003Dzt5jpbHs_003D = new float[count * 6];
		int _0023_003DzPH_0024hvqk_003D = first;
		int num2 = first;
		int num3 = 0;
		while (num3 < count)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, vertices[num2], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, normals[num2], ref _0023_003DzPH_0024hvqk_003D);
			num3++;
			num2++;
		}
		int[] array = new int[num * 3];
		int num4 = count - 4;
		_0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i <= num4; i += 2)
		{
			array[_0023_003DzPH_0024hvqk_003D++] = i;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 1;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 2;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 2;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 1;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 3;
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, array, primitiveType.TriangleList, count, num * 3);
	}

	protected override void SetPointSizeInternal(float thickness)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzIt9jKuJG8ncE = thickness;
	}

	protected override void SetLineSizeInternal(float thickness)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzUTdFkSI_003D = Math.Max(1f, thickness);
	}

	public override void EnableThickLines()
	{
		SetLinesShader(_0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3 && base.CurrentLineWidth > 1f, base.CurrentShader);
	}

	public override void EnableThickLinesInPolygonLineMode()
	{
		bool flag = _0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3 && base.CurrentLineWidth > 1f;
		SetLinesShader(flag, base.CurrentShader);
		SetState(flag ? rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset : rasterizerStateType.CCW_PolygonLine_NoCullFace);
	}

	public override void EnableThickPoints()
	{
		SetPointsShader(_0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3 && base.CurrentPointSize > 1f, base.CurrentShader);
	}

	public override void EnableThickPointsInPolygonLineMode()
	{
		bool flag = _0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3 && base.CurrentPointSize > 1f;
		SetPointsShader(flag, base.CurrentShader);
		SetState(flag ? rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset : rasterizerStateType.CCW_PolygonLine_NoCullFace);
	}

	public override void DrawPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz00s0VfKm4rbq(vertices, normals, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz00s0VfKm4rbq(vertices, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz0Q4yEpOowz76zjKgBA_003D_003D(vertices, normals, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawColorPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzVjE0QEIosCCL(vertices, normals, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawColorSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzjSykECD_00240nxKdnrJoQ_003D_003D(vertices, normals, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawMulticolorPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, byte alpha = byte.MaxValue)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzLPWIe7IHYgq5yd2CyOGX7R_JZmFj(vertices, normals, triangles, alpha);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawMulticolorSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, byte alpha = byte.MaxValue)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzQIPF1_0024r2FrrXS2Tvdhmj52YPkFxsfLU1Gg_003D_003D(vertices, normals, triangles, alpha);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawCurvatureMapTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, System.Drawing.Color[] colorMap)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz7CBoPWOPOsyP1uhgsxVj5tM_003D(vertices, triangles, colorMap);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawCurvatureMapInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, System.Drawing.Color[] colorMap)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzgibj4Xwc8qvk5GE2hjSt_FsO14Yk(vertices, triangles, colorMap);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, IList<PointF> texCoords)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzMmiNe4P_GRNtsNvliw_003D_003D(vertices, normals, texCoords, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, IList<PointF> texCoords)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzyOwKSPX1g5Ayz8V7rYO_0024Q7o_003D(vertices, normals, texCoords, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, float scaleU, float scaleV, float offsetU, float offsetV, float rotateUV)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzyOwKSPX1g5Ayz8V7rYO_0024Q7o_003D(vertices, triangles, scaleU, scaleV, offsetU, offsetV, rotateUV);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichSmoothInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, float scaleU, float scaleV, float offsetU, float offsetV, float rotateUV)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzdWsA7GhCz2yheIwTcdcf_ik_003D(vertices, triangles, scaleU, scaleV, offsetU, offsetV, rotateUV);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawSurfaceTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzenPR8YpYXpXc(vertices, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawSurfaceInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz8rsrSuGTOynFruGGAA_003D_003D(vertices, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawIndexedTriangles(VBOParamsBase myParams)
	{
		bool flag = myParams is VBOParamsTexture;
		int num = (flag ? 8 : 6);
		int num2 = 0;
		float[] array;
		int _0023_003DzRbrcOgQ_003D;
		if (myParams.indices != null)
		{
			array = new float[myParams.indices.Length * num];
			if (flag)
			{
				for (int i = 0; i < myParams.indices.Length; i++)
				{
					int num3 = myParams.indices[i] * 3;
					int num4 = myParams.indices[i] * 2;
					array[num2++] = myParams.vertices[num3];
					array[num2++] = myParams.vertices[num3 + 1];
					array[num2++] = myParams.vertices[num3 + 2];
					array[num2++] = myParams.normals[num3];
					array[num2++] = myParams.normals[num3 + 1];
					array[num2++] = myParams.normals[num3 + 2];
					VBOParamsTexture vBOParamsTexture = (VBOParamsTexture)myParams;
					array[num2++] = vBOParamsTexture.TextureCoordinates[num4];
					array[num2++] = vBOParamsTexture.TextureCoordinates[num4 + 1];
				}
			}
			else
			{
				for (int j = 0; j < myParams.indices.Length; j++)
				{
					int num5 = myParams.indices[j] * 3;
					array[num2++] = myParams.vertices[num5];
					array[num2++] = myParams.vertices[num5 + 1];
					array[num2++] = myParams.vertices[num5 + 2];
					array[num2++] = myParams.normals[num5];
					array[num2++] = myParams.normals[num5 + 1];
					array[num2++] = myParams.normals[num5 + 2];
				}
			}
			_0023_003DzRbrcOgQ_003D = myParams.indices.Length;
		}
		else
		{
			array = new float[myParams.vertices.Length * num];
			for (int k = 0; k < myParams.vertices.Length; k += 3)
			{
				array[num2++] = myParams.vertices[k];
				array[num2++] = myParams.vertices[k + 1];
				array[num2++] = myParams.vertices[k + 2];
				array[num2++] = myParams.normals[k];
				array[num2++] = myParams.normals[k + 1];
				array[num2++] = myParams.normals[k + 2];
			}
			_0023_003DzRbrcOgQ_003D = myParams.vertices.Length / 3;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override byte[] ReadRgbValues(System.Drawing.Point leftBottomCameraScreen, Size size, BitmapData data)
	{
		throw new NotImplementedException();
	}

	public override void DrawPixels(TextureBase texture, Bitmap bmp, Point2D rasterPos, Size destSize, bool flipY)
	{
		DrawQuad(texture, byte.MaxValue, new System.Drawing.RectangleF((float)rasterPos.X, (float)rasterPos.Y, destSize.Width, destSize.Height), 0f, !flipY);
	}

	public override void DrawBorder(Dictionary<shaderType, IShaderTechnique> shaders, System.Drawing.Color borderColor, Size size, int radius, bool visible, object borderBitmap, object lowerLeftCorner, object lowerRightCorner, object topLeftCorner, object topRightCorner)
	{
		if (_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D == null)
		{
			if (radius > 0)
			{
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D = new D3DTexture2D[4];
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[0] = new D3DTexture2D(this, (Bitmap)lowerLeftCorner, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[1] = new D3DTexture2D(this, (Bitmap)lowerRightCorner, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[2] = new D3DTexture2D(this, (Bitmap)topRightCorner, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[3] = new D3DTexture2D(this, (Bitmap)topLeftCorner, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
			}
			else if (IsMultisample())
			{
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D = new D3DTexture2D[1];
				Bitmap bitmap = new Bitmap(1, 1);
				bitmap.SetPixel(0, 0, borderColor);
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[0] = new D3DTexture2D(this, bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
				bitmap.Dispose();
			}
		}
		SetState(depthStencilStateType.DepthTestOff);
		float x = size.Width - 1;
		float num = 0f;
		float y = size.Height - 1;
		float num2 = size.Width - 1;
		float num3 = size.Height - 1;
		if (visible)
		{
			float width = num2 + 1f - (float)(2 * radius);
			float height = num3 + 1f - (float)(2 * radius);
			System.Drawing.RectangleF rect = new System.Drawing.RectangleF(radius, num, width, 1f);
			System.Drawing.RectangleF rect2 = new System.Drawing.RectangleF(radius, y, width, 1f);
			System.Drawing.RectangleF rect3 = new System.Drawing.RectangleF(0f, num + (float)radius, 1f, height);
			System.Drawing.RectangleF rect4 = new System.Drawing.RectangleF(x, num + (float)radius, 1f, height);
			PushRasterizerState();
			SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			if (IsMultisample())
			{
				SetShader(shaderType.Texture2DNoLights);
				TextureBase texture = _0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[(radius > 0) ? 3 : 0];
				SetMatrices();
				DrawQuadWithTextures(texture, new float[8], byte.MaxValue, rect, 0f, buffered: false);
				DrawQuadWithTextures(texture, new float[8], byte.MaxValue, rect2, 0f, buffered: false);
				DrawQuadWithTextures(texture, new float[8], byte.MaxValue, rect3, 0f, buffered: false);
				DrawQuadWithTextures(texture, new float[8], byte.MaxValue, rect4, 0f, buffered: false);
			}
			else
			{
				SetShader(shaderType.NoLights);
				SetColorWireframe(borderColor);
				DrawQuad(rect);
				DrawQuad(rect2);
				DrawQuad(rect3);
				DrawQuad(rect4);
			}
			PopRasterizerState();
		}
		if (radius > 0)
		{
			SetShader(shaderType.Texture2DNoLights);
			SetMatrices();
			SetState(blendStateType.Blend_Mask_RGB);
			DrawQuad(_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[3], byte.MaxValue, new System.Drawing.RectangleF(0f, 0f, radius, radius), 0f, flipY: false);
			DrawQuad(_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[2], byte.MaxValue, new System.Drawing.RectangleF(size.Width - radius, 0f, radius, radius), 0f, flipY: false);
			DrawQuad(_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[1], byte.MaxValue, new System.Drawing.RectangleF(size.Width - radius, size.Height - radius, radius, radius), 0f, flipY: false);
			DrawQuad(_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[0], byte.MaxValue, new System.Drawing.RectangleF(0f, size.Height - radius, radius, radius), 0f, flipY: false);
			SetState(blendStateType.NoBlend);
		}
		SetState(depthStencilStateType.DepthTestLess);
	}

	internal int _0023_003DzwuJKWL_0024qRlUevQgx6w_003D_003D()
	{
		if (_0023_003DzGIPo6pY0ShMi != FeatureLevel.Level_9_3)
		{
			return 2000000;
		}
		return 1000000;
	}

	protected internal override IEnvironment CreateEnvironment(byte[] image)
	{
		return new _0023_003Dz2CVvuxuWS8G37TeC_OrIULo_003D(image);
	}

	protected internal override IEnvironment CreateEnvironment(Image image)
	{
		return new _0023_003Dz2CVvuxuWS8G37TeC_OrIULo_003D(image);
	}

	protected internal override bool CreateHilbertLut(Bitmap noiseBmp)
	{
		int width = noiseBmp.Width;
		int height = noiseBmp.Height;
		Texture2DDescription description = new Texture2DDescription
		{
			Width = width,
			Height = height,
			ArraySize = 1,
			BindFlags = BindFlags.ShaderResource,
			CpuAccessFlags = CpuAccessFlags.None,
			Format = Format.R16_UInt,
			MipLevels = 1,
			OptionFlags = ResourceOptionFlags.None,
			SampleDescription = new SampleDescription(1, 0),
			Usage = ResourceUsage.Default
		};
		BitmapData bitmapData = noiseBmp.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format16bppGrayScale);
		DataBox[] data = new DataBox[1]
		{
			new DataBox(bitmapData.Scan0, width * 2, 0)
		};
		aoNoiseTexture?.Dispose();
		aoNoiseTexture = new D3DTexture2D();
		((D3DTexture2D)aoNoiseTexture)._0023_003Dz_IfKSJY_003D = new Texture2D(_0023_003DzTzFVZ_00240_003D, description, data);
		noiseBmp.UnlockBits(bitmapData);
		aoNoiseTexture.Size = new Size(width, height);
		((D3DTexture2D)aoNoiseTexture)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(_0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)aoNoiseTexture)._0023_003Dz_IfKSJY_003D);
		return true;
	}

	public override bool IsValid()
	{
		if (_0023_003DzP7fhLh8_003D != null)
		{
			return _0023_003DzTzFVZ_00240_003D != null;
		}
		return false;
	}

	public override void Dispose()
	{
		base.Dispose();
		_0023_003DzhaDtCOY_003D();
	}

	protected internal override void DisposeBorderTextures()
	{
		if (_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D != null)
		{
			for (int i = 0; i < _0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D.Length; i++)
			{
				_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[i]);
			}
		}
	}

	internal void _0023_003DzhaDtCOY_003D()
	{
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzP7fhLh8_003D);
		ClearBuffers();
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003Dz3DjOiC4_003D);
		_0023_003Dz8QkHu3mTTpWM();
		DisposeBorderTextures();
		for (int i = 0; i < _0023_003DzCs9juxBz5x1N.Count; i++)
		{
			SamplerState _0023_003Dzb2InYPc_003D = _0023_003DzCs9juxBz5x1N[i];
			_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003Dzb2InYPc_003D);
		}
		_0023_003DzCs9juxBz5x1N.Clear();
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzxbCbL_0024mWtybX);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzYpDxbNl_WsmZ);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzhNCOIdKjRgee);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D);
		ClearDynamicBuffers();
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzTzFVZ_00240_003D);
	}

	public override void ClearDynamicBuffers()
	{
		if (_0023_003DzTx0khkogHMfe != null)
		{
			_0023_003DzTx0khkogHMfe.Dispose();
		}
		_0023_003DzTx0khkogHMfe = null;
		if (_0023_003DzcsNzRnBprL0v != null)
		{
			_0023_003DzcsNzRnBprL0v.Dispose();
		}
		_0023_003DzcsNzRnBprL0v = null;
	}

	public override void MakeCurrent()
	{
	}

	public override void SwapBuffers()
	{
		EndDraw(swapBuffer: true);
	}

	private protected string _0023_003DzkXcljqUGbfkt(Result _0023_003DzTyqzlW0_003D)
	{
		return (uint)_0023_003DzTyqzlW0_003D.Code switch
		{
			2289696774u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598815), 
			2289696773u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598818), 
			2289696775u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598850), 
			2289696800u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598884), 
			2289696779u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599197), 
			2289696780u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599218), 
			2289696769u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599268), 
			2289696771u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599046), 
			2289696801u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599083), 
			2289696802u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599117), 
			2289696770u => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599140), 
			_ => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598409), 
		};
	}

	internal virtual Texture2D _0023_003DzxPP8x2119RobVE2x5A_003D_003D()
	{
		return _0023_003DzsGYT27WsV_Oyoej_0024GHn1kPc_003D;
	}

	protected override void InitDepthForPostProcessingInternal(Size size)
	{
		DepthTextureForPostProcessing?.Dispose();
		DepthTextureForPostProcessing = new D3DTextureDepth();
		((Texture)DepthTextureForPostProcessing).AllocateMemory(this, renderTarget: true, size.Width, size.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, repeatS: false, repeatT: false, IntPtr.Zero, multisample: false);
		MaskTextureForPostProcessing?.Dispose();
		MaskTextureForPostProcessing = new D3DTexture2D();
		((D3DTexture2D)MaskTextureForPostProcessing)._0023_003Dzcp4fLOSZApya(this, size, CpuAccessFlags.None, ResourceUsage.Default, Format.R8_UNorm, BindFlags.ShaderResource | BindFlags.RenderTarget, new SampleDescription(1, 0));
		((D3DTexture2D)MaskTextureForPostProcessing)._0023_003Dz59osH17qGO0V = new RenderTargetView(_0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)MaskTextureForPostProcessing)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)MaskTextureForPostProcessing)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(_0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)MaskTextureForPostProcessing)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)MaskTextureForPostProcessing)._0023_003Dzxc5GrhYq3y_0024E = _0023_003DzKjAPrkH_0024OGSs(Filter.MinMagMipPoint, _0023_003DzDXSkCVA_003D: false, _0023_003DzLYY7OMQ_003D: false, _0023_003DzTzFVZ_00240_003D, 0f);
	}

	protected internal override void SetDepthForPostProcessingAsCurrentTarget()
	{
		base.SetDepthForPostProcessingAsCurrentTarget();
		_0023_003DzElzSDDQsrPlQ();
		_0023_003Dzi6v0V6E_003D(new _0023_003DzB_00241i16ya3eUx(((D3DTexture2D)MaskTextureForPostProcessing)._0023_003Dz59osH17qGO0V, ((D3DTextureDepth)DepthTextureForPostProcessing)._0023_003Dz52pY7YIbaCdt));
	}

	protected override void SetVendorName()
	{
		SetVendorName(_0023_003Dz2Rda4kX181D8_0UgXg_003D_003D);
	}

	protected override void FreeCaptureTextures()
	{
		base.FreeCaptureTextures();
	}

	public override bool Create()
	{
		base.IsDirect3D = true;
		base.Create();
		_0023_003Dz3DjOiC4_003D = new Factory1();
		int num = _0023_003DzW7ISe_G66FSE(_0023_003Dz3DjOiC4_003D);
		string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598419);
		if (num < 0)
		{
			Logger.Instance.Error(base.ControlData.InstanceId, message, null);
			throw new GraphicsException(message);
		}
		List<int> list = new List<int>();
		list.Add(num);
		for (int i = 0; i < _0023_003Dz3DjOiC4_003D.Adapters.Length; i++)
		{
			if (i != num)
			{
				list.Add(i);
			}
		}
		bool flag = false;
		for (int j = 0; j < list.Count; j++)
		{
			Adapter adapter = _0023_003Dz3DjOiC4_003D.Adapters[list[j]];
			try
			{
				_0023_003DzGIPo6pY0ShMi = SharpDX.Direct3D11.Device.GetSupportedFeatureLevel(adapter);
				Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598523), _0023_003Dz5DKHUPMsYSLk(adapter), _0023_003DzGIPo6pY0ShMi));
				_0023_003DzIaas7wk_003D(adapter);
				flag = true;
				Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598305) + _0023_003Dz5DKHUPMsYSLk(adapter));
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598366) + _0023_003Dz5DKHUPMsYSLk(adapter), exception);
				if (j == 0)
				{
					SetIsBestAdapterAvailable(value: false);
				}
				_0023_003DzhaDtCOY_003D();
				_0023_003Dz3DjOiC4_003D = new Factory1();
				if (_0023_003DznzTxkQM_003D == null)
				{
					_0023_003DznzTxkQM_003D = new Bitmap(_0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzmsLRsIpQV5sG());
				}
				continue;
			}
			break;
		}
		if (!flag)
		{
			Logger.Instance.Error(base.ControlData.InstanceId, message, null);
			throw new GraphicsException(message);
		}
		return true;
	}

	private protected virtual void _0023_003DzIaas7wk_003D(Adapter _0023_003Dz7pcaMvE_003D)
	{
		if (base.ControlData.askForLevel9_3)
		{
			_0023_003DzTzFVZ_00240_003D = new SharpDX.Direct3D11.Device(_0023_003Dz7pcaMvE_003D, DeviceCreationFlags.BgraSupport, FeatureLevel.Level_9_3);
		}
		else
		{
			_0023_003DzTzFVZ_00240_003D = new SharpDX.Direct3D11.Device(_0023_003Dz7pcaMvE_003D, DeviceCreationFlags.BgraSupport);
		}
		if (base.ControlData.askForLevel9_3)
		{
			_0023_003DzGIPo6pY0ShMi = FeatureLevel.Level_9_3;
		}
		Logger.Instance.Info(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598388), _0023_003DzGIPo6pY0ShMi);
		_0023_003Dz2Rda4kX181D8_0UgXg_003D_003D = _0023_003Dz5DKHUPMsYSLk(_0023_003Dz7pcaMvE_003D);
		Logger.Instance.Info(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598684), _0023_003Dz2Rda4kX181D8_0UgXg_003D_003D);
		if (_0023_003DzGIPo6pY0ShMi < FeatureLevel.Level_9_3)
		{
			string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598692);
			Logger.Instance.Error(message, null, Array.Empty<object>());
			throw new GraphicsException(message);
		}
		_0023_003DzP7fhLh8_003D = _0023_003DzTzFVZ_00240_003D.ImmediateContext;
		_0023_003DzTzFVZ_00240_003D.ImmediateContext.OutputMerger.SetTargets();
		InitResourceBuffers(base.ControlData.ControlSize);
		_0023_003DzxbCbL_0024mWtybX = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, 100000, 50000);
		_0023_003DzYpDxbNl_WsmZ = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, 100000, 0);
		_0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, 100000, 0);
		_0023_003DzhNCOIdKjRgee = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, 100000, 0);
		_0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D = new _0023_003DzI4BRvY6ZZl1UU3SNUrxE9cMvzL2zQGw4lA_003D_003D(_0023_003DzTzFVZ_00240_003D, 100000, 0);
		base.ControlData.isHardwareAccelerated = true;
		SetVendorName();
		_0023_003Dzi3UeiPo_003D();
		_0023_003DzP7fhLh8_003D.OutputMerger.DepthStencilReference = 1;
		globalShadowMapData = new _0023_003DzooeimQU3HoFxQdN5vqMATC9DoCTZ();
	}

	private string _0023_003Dz5DKHUPMsYSLk(Adapter _0023_003Dz1EpCtMQ_003D)
	{
		return _0023_003DzOiLcyu8jDYMi(_0023_003Dz1EpCtMQ_003D.Description.Description);
	}

	private string _0023_003Dz2gPdYUkJ_0024mj4(Output _0023_003Dz3jjpOR0_003D)
	{
		return _0023_003DzOiLcyu8jDYMi(_0023_003Dz3jjpOR0_003D.Description.DeviceName).Replace(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598764), string.Empty).Replace(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810), string.Empty);
	}

	private static string _0023_003DzOiLcyu8jDYMi(string _0023_003Dz_0024MMzLZH6NtUL)
	{
		int num = _0023_003Dz_0024MMzLZH6NtUL.IndexOf('\0');
		if (num > 0)
		{
			_0023_003Dz_0024MMzLZH6NtUL = _0023_003Dz_0024MMzLZH6NtUL.Substring(0, num);
		}
		return _0023_003Dz_0024MMzLZH6NtUL;
	}

	private static string _0023_003Dz9TOcyoSBjA4y(string _0023_003Dz_0024MMzLZH6NtUL)
	{
		int num = _0023_003Dz_0024MMzLZH6NtUL.IndexOf('\\');
		if (num > 0)
		{
			_0023_003Dz_0024MMzLZH6NtUL = _0023_003Dz_0024MMzLZH6NtUL.Substring(0, num);
		}
		return _0023_003Dz_0024MMzLZH6NtUL;
	}

	private int _0023_003DzW7ISe_G66FSE(Factory _0023_003Dz3DjOiC4_003D)
	{
		Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598756));
		int num = -1;
		bool flag = true;
		FeatureLevel featureLevel = FeatureLevel.Level_9_1;
		Logger.Instance.Info(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598533), _0023_003Dz3DjOiC4_003D.Adapters.Length));
		Adapter adapter = null;
		Adapter adapter2 = null;
		int num2 = -1;
		for (int i = 0; i < _0023_003Dz3DjOiC4_003D.Adapters.Length; i++)
		{
			try
			{
				Adapter adapter3 = _0023_003Dz3DjOiC4_003D.Adapters[i];
				FeatureLevel supportedFeatureLevel = SharpDX.Direct3D11.Device.GetSupportedFeatureLevel(adapter3);
				ulong num3 = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzkVysqIoceUqzcj07uw_003D_003D(adapter3.Description.DedicatedVideoMemory);
				Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598564), _0023_003Dz5DKHUPMsYSLk(adapter3), supportedFeatureLevel, (double)num3 / 1048576.0, adapter3.Outputs.Length));
				if (adapter3.Outputs.Length != 0)
				{
					string text = string.Empty;
					for (int j = 0; j < adapter3.Outputs.Length; j++)
					{
						Output _0023_003Dz3jjpOR0_003D = adapter3.Outputs[j];
						if (j > 0)
						{
							text += _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621248);
						}
						text += _0023_003Dz2gPdYUkJ_0024mj4(_0023_003Dz3jjpOR0_003D);
					}
					Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599943) + text);
				}
				if (adapter3.Description.VendorId == 5140 && adapter3.Description.DeviceId == 140)
				{
					if (adapter2 == null)
					{
						adapter2 = adapter3;
						num2 = i;
					}
					else if (adapter3.Outputs.Length != 0)
					{
						adapter2 = adapter3;
						num2 = i;
					}
					Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599959) + _0023_003Dz5DKHUPMsYSLk(adapter3) + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599972));
					continue;
				}
				if (!flag)
				{
					Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599985));
				}
				if (flag || supportedFeatureLevel > featureLevel || (supportedFeatureLevel == featureLevel && num3 > _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzkVysqIoceUqzcj07uw_003D_003D(adapter.Description.DedicatedVideoMemory)))
				{
					flag = false;
					num = i;
					featureLevel = supportedFeatureLevel;
					adapter = _0023_003Dz3DjOiC4_003D.Adapters[num];
					Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599959) + _0023_003Dz5DKHUPMsYSLk(adapter) + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600050));
				}
			}
			catch (Exception exception)
			{
				Logger.Instance.Error(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599828) + _0023_003Dz5DKHUPMsYSLk(_0023_003Dz3DjOiC4_003D.Adapters[i]), exception);
			}
		}
		if (adapter != null)
		{
			Logger.Instance.Info(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599877) + _0023_003Dz5DKHUPMsYSLk(adapter) + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810));
		}
		else if (num2 != -1)
		{
			num = num2;
			adapter = _0023_003Dz3DjOiC4_003D.Adapters[num];
			Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599914), _0023_003Dz5DKHUPMsYSLk(adapter), adapter.Outputs.Length));
		}
		else
		{
			Logger.Instance.Info(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600229));
		}
		return num;
	}

	public override bool IsMultisample()
	{
		return _0023_003DzoZFDtSI_003D.Count > 1;
	}

	public override bool NeedsToCaptureDepth()
	{
		if (_0023_003DzGIPo6pY0ShMi != FeatureLevel.Level_9_3)
		{
			return base.ControlData.isFsaaAvailable;
		}
		return true;
	}

	public override void ReadDepth()
	{
	}

	private protected SampleDescription _0023_003DzENoa3feOVaqa(Format _0023_003DzNSHbX7A_003D)
	{
		SampleDescription _0023_003DzCEGI0ngjOjCn = new SampleDescription(1, 0);
		if (base.ControlData.askForAntiAliasing && base.ControlData.AntiAliasing)
		{
			Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600257));
			if (_0023_003DzENoa3feOVaqa(_0023_003DzNSHbX7A_003D, base.ControlData.antialiasingSamples, ref _0023_003DzCEGI0ngjOjCn))
			{
				base.ControlData.isFsaaAvailable = true;
				return _0023_003DzCEGI0ngjOjCn;
			}
		}
		base.ControlData.isFsaaAvailable = false;
		return _0023_003DzCEGI0ngjOjCn;
	}

	internal bool _0023_003DzENoa3feOVaqa(Format _0023_003DzNSHbX7A_003D, antialiasingSamplesNumberType _0023_003Dz4F7CpANmJ_sg, ref SampleDescription _0023_003DzCEGI0ngjOjCn)
	{
		Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600089), _0023_003DzNSHbX7A_003D));
		int num;
		while (true)
		{
			num = _0023_003DzTzFVZ_00240_003D.CheckMultisampleQualityLevels(_0023_003DzNSHbX7A_003D, (int)_0023_003Dz4F7CpANmJ_sg);
			if (num == 0)
			{
				Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600131), _0023_003Dz4F7CpANmJ_sg));
				switch (_0023_003Dz4F7CpANmJ_sg)
				{
				case antialiasingSamplesNumberType.x2:
					return false;
				case antialiasingSamplesNumberType.x4:
					_0023_003Dz4F7CpANmJ_sg = antialiasingSamplesNumberType.x2;
					break;
				case antialiasingSamplesNumberType.x8:
					_0023_003Dz4F7CpANmJ_sg = antialiasingSamplesNumberType.x4;
					break;
				case antialiasingSamplesNumberType.x16:
					_0023_003Dz4F7CpANmJ_sg = antialiasingSamplesNumberType.x8;
					break;
				default:
					throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600165));
				}
			}
			else if (num > 0)
			{
				break;
			}
		}
		Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599434), _0023_003Dz4F7CpANmJ_sg));
		_0023_003DzCEGI0ngjOjCn = new SampleDescription((int)_0023_003Dz4F7CpANmJ_sg, num - 1);
		return true;
	}

	private void _0023_003Dzi3UeiPo_003D()
	{
		Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599440));
		_0023_003DzpAUmLLSex7XHcVPCjDHQiy0_003D();
		Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599503));
		_0023_003DzZTLDe32IxXIt();
		Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599531));
		_0023_003DzBbrY5TELg7Ya();
	}

	private void _0023_003Dz8QkHu3mTTpWM()
	{
		Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599311));
		_0023_003DzH_00242T1503OfAqo9mCDBacbPU_003D();
		Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599342));
		_0023_003Dz4Q104OIzNles();
		Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599370));
		_0023_003DzS_0024BTMAVZrHrL();
	}

	private void _0023_003Dzwip6aGA_003D(rasterizerStateType _0023_003Dz_H763Oc_003D)
	{
		_0023_003Dzwip6aGA_003D(_0023_003Dz_H763Oc_003D, _0023_003DzioVUVbUUjXikAY3FaO9C77g_003D, _0023_003DzMuIGnlzWJz4F: false);
		_0023_003Dzwip6aGA_003D(_0023_003Dz_H763Oc_003D, _0023_003DzCq2MbKjLVwa2eLteTm8qc8CfbMK85AuhZQ_003D_003D, _0023_003DzMuIGnlzWJz4F: true);
	}

	private void _0023_003Dzwip6aGA_003D(rasterizerStateType _0023_003Dz_H763Oc_003D, Dictionary<rasterizerStateType, RasterizerState> _0023_003DzLBZv8Zg_003D, bool _0023_003DzMuIGnlzWJz4F)
	{
		bool flag = IsCw(_0023_003Dz_H763Oc_003D);
		GetPolygonOffsetValues(_0023_003Dz_H763Oc_003D, out var factor, out var units);
		_0023_003DzLBZv8Zg_003D.Add(_0023_003Dz_H763Oc_003D, new RasterizerState(_0023_003DzTzFVZ_00240_003D, new RasterizerStateDescription
		{
			CullMode = _0023_003DzLrLdRhg0w3Mi(GetCullFace(_0023_003Dz_H763Oc_003D)),
			FillMode = _0023_003Dz_Ie5exdei56o(GetPolygonDrawingType(_0023_003Dz_H763Oc_003D)),
			SlopeScaledDepthBias = factor,
			DepthBias = (int)units,
			IsDepthClipEnabled = true,
			IsFrontCounterClockwise = !flag,
			IsMultisampleEnabled = (_0023_003DzMuIGnlzWJz4F && (_0023_003DzGIPo6pY0ShMi <= FeatureLevel.Level_9_3 || base.Vendor == vendorName.Nvidia || base.Vendor == vendorName.Intel)),
			IsAntialiasedLineEnabled = (_0023_003DzMuIGnlzWJz4F && (base.Vendor == vendorName.Nvidia || base.Vendor == vendorName.Intel)),
			IsScissorEnabled = false
		}));
	}

	private void _0023_003DzVrx9L5Q_003D(rasterizerStateType _0023_003Dz_H763Oc_003D)
	{
		_0023_003DzVrx9L5Q_003D(_0023_003Dz_H763Oc_003D, _0023_003DzioVUVbUUjXikAY3FaO9C77g_003D);
		_0023_003DzVrx9L5Q_003D(_0023_003Dz_H763Oc_003D, _0023_003DzCq2MbKjLVwa2eLteTm8qc8CfbMK85AuhZQ_003D_003D);
	}

	private void _0023_003DzVrx9L5Q_003D(rasterizerStateType _0023_003Dz_H763Oc_003D, Dictionary<rasterizerStateType, RasterizerState> _0023_003DzLBZv8Zg_003D)
	{
		if (_0023_003DzLBZv8Zg_003D.ContainsKey(_0023_003Dz_H763Oc_003D))
		{
			_0023_003DzLBZv8Zg_003D[_0023_003Dz_H763Oc_003D].Dispose();
			_0023_003DzLBZv8Zg_003D.Remove(_0023_003Dz_H763Oc_003D);
		}
	}

	private FillMode _0023_003Dz_Ie5exdei56o(rasterizerPolygonDrawingType _0023_003Dzd4lNpu69IFz_)
	{
		return _0023_003Dzd4lNpu69IFz_ switch
		{
			rasterizerPolygonDrawingType.Fill => FillMode.Solid, 
			rasterizerPolygonDrawingType.Line => FillMode.Wireframe, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599406)), 
		};
	}

	private CullMode _0023_003DzLrLdRhg0w3Mi(rasterizerCullFaceType _0023_003Dz4IAlOoxoacZt)
	{
		return _0023_003Dz4IAlOoxoacZt switch
		{
			rasterizerCullFaceType.Back => CullMode.Back, 
			rasterizerCullFaceType.Front => CullMode.Front, 
			rasterizerCullFaceType.None => CullMode.None, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599686)), 
		};
	}

	private void _0023_003DzpAUmLLSex7XHcVPCjDHQiy0_003D()
	{
		foreach (object value in Enum.GetValues(typeof(rasterizerStateType)))
		{
			_0023_003Dzwip6aGA_003D((rasterizerStateType)value);
		}
	}

	private void _0023_003DzH_00242T1503OfAqo9mCDBacbPU_003D()
	{
		foreach (object value in Enum.GetValues(typeof(rasterizerStateType)))
		{
			_0023_003DzVrx9L5Q_003D((rasterizerStateType)value);
		}
	}

	private void _0023_003Dzwip6aGA_003D(depthStencilStateType _0023_003Dz_H763Oc_003D)
	{
		bool flag = IsStencilEnabled(_0023_003Dz_H763Oc_003D);
		DepthStencilOperationDescription depthStencilOperationDescription = default(DepthStencilOperationDescription);
		if (flag)
		{
			depthStencilOperationDescription.Comparison = _0023_003DzXYzgz1a0zpBQe7zDOg_003D_003D(GetStencilFunc(_0023_003Dz_H763Oc_003D));
			depthStencilOperationDescription.FailOperation = _0023_003DzFp5MmIoxfzHpSWGqLg_003D_003D(GetStencilOpStencilFailAction(_0023_003Dz_H763Oc_003D));
			depthStencilOperationDescription.DepthFailOperation = _0023_003DzFp5MmIoxfzHpSWGqLg_003D_003D(GetStencilOpDepthFailAction(_0023_003Dz_H763Oc_003D));
			depthStencilOperationDescription.PassOperation = _0023_003DzFp5MmIoxfzHpSWGqLg_003D_003D(GetStencilOpStencilDepthPassAction(_0023_003Dz_H763Oc_003D));
		}
		_0023_003DzOcMxhmqWn4cmb0mNJA_003D_003D.Add(_0023_003Dz_H763Oc_003D, new DepthStencilState(_0023_003DzTzFVZ_00240_003D, new DepthStencilStateDescription
		{
			DepthComparison = _0023_003Dzh_0024WobcizsP6s(GetDepthFunc(_0023_003Dz_H763Oc_003D)),
			DepthWriteMask = (GetDepthMask(_0023_003Dz_H763Oc_003D) ? DepthWriteMask.All : DepthWriteMask.Zero),
			IsDepthEnabled = IsDepthTestEnabled(_0023_003Dz_H763Oc_003D),
			FrontFace = depthStencilOperationDescription,
			BackFace = depthStencilOperationDescription,
			IsStencilEnabled = flag,
			StencilReadMask = (byte)GetStencilFuncMask(_0023_003Dz_H763Oc_003D),
			StencilWriteMask = byte.MaxValue
		}));
	}

	private void _0023_003DzVrx9L5Q_003D(depthStencilStateType _0023_003Dz_H763Oc_003D)
	{
		if (_0023_003DzOcMxhmqWn4cmb0mNJA_003D_003D.ContainsKey(_0023_003Dz_H763Oc_003D))
		{
			_0023_003DzOcMxhmqWn4cmb0mNJA_003D_003D[_0023_003Dz_H763Oc_003D].Dispose();
			_0023_003DzOcMxhmqWn4cmb0mNJA_003D_003D.Remove(_0023_003Dz_H763Oc_003D);
		}
	}

	private StencilOperation _0023_003DzFp5MmIoxfzHpSWGqLg_003D_003D(stencilOpActionType _0023_003DzqLzqtoM_003D)
	{
		return _0023_003DzqLzqtoM_003D switch
		{
			stencilOpActionType.Invert => StencilOperation.Invert, 
			stencilOpActionType.Keep => StencilOperation.Keep, 
			stencilOpActionType.Replace => StencilOperation.Replace, 
			stencilOpActionType.Zero => StencilOperation.Zero, 
			stencilOpActionType.Increment => StencilOperation.Increment, 
			stencilOpActionType.Decrement => StencilOperation.Decrement, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599716)), 
		};
	}

	private Comparison _0023_003DzXYzgz1a0zpBQe7zDOg_003D_003D(stencilFuncType _0023_003DzIooYK_0024E_003D)
	{
		return _0023_003DzIooYK_0024E_003D switch
		{
			stencilFuncType.Always => Comparison.Always, 
			stencilFuncType.Equal => Comparison.Equal, 
			stencilFuncType.Never => Comparison.Never, 
			stencilFuncType.NotEqual => Comparison.NotEqual, 
			stencilFuncType.Greater => Comparison.Greater, 
			stencilFuncType.GreaterEqual => Comparison.GreaterEqual, 
			stencilFuncType.Less => Comparison.Less, 
			stencilFuncType.LessEqual => Comparison.LessEqual, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599775)), 
		};
	}

	private Comparison _0023_003Dzh_0024WobcizsP6s(depthFuncType _0023_003DzIooYK_0024E_003D)
	{
		return _0023_003DzIooYK_0024E_003D switch
		{
			depthFuncType.Always => Comparison.Always, 
			depthFuncType.Equal => Comparison.Equal, 
			depthFuncType.Greater => Comparison.Greater, 
			depthFuncType.Less => Comparison.Less, 
			depthFuncType.LessEqual => Comparison.LessEqual, 
			depthFuncType.Never => Comparison.Never, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599792)), 
		};
	}

	private void _0023_003DzZTLDe32IxXIt()
	{
		foreach (object value in Enum.GetValues(typeof(depthStencilStateType)))
		{
			_0023_003Dzwip6aGA_003D((depthStencilStateType)value);
		}
	}

	private void _0023_003Dz4Q104OIzNles()
	{
		foreach (object value in Enum.GetValues(typeof(depthStencilStateType)))
		{
			_0023_003DzVrx9L5Q_003D((depthStencilStateType)value);
		}
	}

	private void _0023_003Dzwip6aGA_003D(blendStateType _0023_003Dz_H763Oc_003D)
	{
		bool flag = IsBlendEnabled(_0023_003Dz_H763Oc_003D);
		ColorWriteMaskFlags blendStateColorMask = (ColorWriteMaskFlags)GetBlendStateColorMask(_0023_003Dz_H763Oc_003D);
		blendStateBlendFactorType blendStateSrcFactor = GetBlendStateSrcFactor(_0023_003Dz_H763Oc_003D);
		blendStateBlendFactorType blendStateDstFactor = GetBlendStateDstFactor(_0023_003Dz_H763Oc_003D);
		blendStateBlendFactorType blendStateSrcAlphaFactor = GetBlendStateSrcAlphaFactor(_0023_003Dz_H763Oc_003D);
		blendStateBlendFactorType blendStateDstAlphaFactor = GetBlendStateDstAlphaFactor(_0023_003Dz_H763Oc_003D);
		BlendStateDescription description = new BlendStateDescription
		{
			AlphaToCoverageEnable = false,
			IndependentBlendEnable = false
		};
		description.RenderTarget[0] = new RenderTargetBlendDescription
		{
			IsBlendEnabled = flag,
			SourceBlend = _0023_003Dz_wBnztyGZ8lx(blendStateSrcFactor),
			DestinationBlend = _0023_003Dz_wBnztyGZ8lx(blendStateDstFactor),
			BlendOperation = BlendOperation.Add,
			AlphaBlendOperation = BlendOperation.Add,
			SourceAlphaBlend = _0023_003Dz_wBnztyGZ8lx(blendStateSrcAlphaFactor),
			DestinationAlphaBlend = _0023_003Dz_wBnztyGZ8lx(blendStateDstAlphaFactor),
			RenderTargetWriteMask = blendStateColorMask
		};
		_0023_003DzaYnyroaiPk1g.Add(_0023_003Dz_H763Oc_003D, new BlendState(_0023_003DzTzFVZ_00240_003D, description));
	}

	private void _0023_003DzVrx9L5Q_003D(blendStateType _0023_003Dz_H763Oc_003D)
	{
		if (_0023_003DzaYnyroaiPk1g.ContainsKey(_0023_003Dz_H763Oc_003D))
		{
			_0023_003DzaYnyroaiPk1g[_0023_003Dz_H763Oc_003D].Dispose();
			_0023_003DzaYnyroaiPk1g.Remove(_0023_003Dz_H763Oc_003D);
		}
	}

	private BlendOption _0023_003Dz_wBnztyGZ8lx(blendStateBlendFactorType _0023_003Dz1CEjt3w_003D)
	{
		return _0023_003Dz1CEjt3w_003D switch
		{
			blendStateBlendFactorType.DstColor => BlendOption.DestinationColor, 
			blendStateBlendFactorType.One => BlendOption.One, 
			blendStateBlendFactorType.OneMinusSrcAlpha => BlendOption.InverseSourceAlpha, 
			blendStateBlendFactorType.SrcAlpha => BlendOption.SourceAlpha, 
			blendStateBlendFactorType.Zero => BlendOption.Zero, 
			blendStateBlendFactorType.InverseDestinationColor => BlendOption.InverseDestinationColor, 
			blendStateBlendFactorType.InverseSourceColor => BlendOption.InverseSourceColor, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599598)), 
		};
	}

	private void _0023_003DzBbrY5TELg7Ya()
	{
		foreach (object value in Enum.GetValues(typeof(blendStateType)))
		{
			_0023_003Dzwip6aGA_003D((blendStateType)value);
		}
	}

	private void _0023_003DzS_0024BTMAVZrHrL()
	{
		foreach (object value in Enum.GetValues(typeof(blendStateType)))
		{
			_0023_003DzVrx9L5Q_003D((blendStateType)value);
		}
	}

	public override void UpdateAntialiasing()
	{
		ClearBuffers();
		InitResourceBuffers(base.ControlData.ControlSize);
		base.UpdateAntialiasing();
	}

	protected virtual void InitResourceBuffers(Size size)
	{
		if (size.Width != 0 && size.Height != 0)
		{
			int num = Math.Max(2, size.Width);
			int num2 = Math.Max(2, size.Height);
			InitSwapChainAndBackBufferTexture();
			Texture2DDescription _0023_003DzPsUSx4D2yz6n = (_0023_003Dz9BXbES9OsYCS = _0023_003Dz44KfZ5g_003D(num, num2));
			Texture2DDescription description = new Texture2DDescription
			{
				Width = num,
				Height = num2,
				ArraySize = 1,
				BindFlags = BindFlags.DepthStencil,
				CpuAccessFlags = CpuAccessFlags.None,
				Format = Format.D24_UNorm_S8_UInt,
				MipLevels = 1,
				OptionFlags = ResourceOptionFlags.None,
				SampleDescription = _0023_003DzoZFDtSI_003D,
				Usage = ResourceUsage.Default
			};
			_0023_003DzGgYOIY9UjYous_0024b3mQ_003D_003D = new Texture2D(_0023_003DzTzFVZ_00240_003D, description);
			_0023_003Dz52pY7YIbaCdt = new DepthStencilView(_0023_003DzTzFVZ_00240_003D, _0023_003DzGgYOIY9UjYous_0024b3mQ_003D_003D);
			if (!_0023_003DzlzeQWTRlPk6m())
			{
				_0023_003DzPsUSx4D2yz6n = _0023_003DzxPP8x2119RobVE2x5A_003D_003D().Description;
			}
			_0023_003DzPsUSx4D2yz6n.BindFlags |= BindFlags.ShaderResource;
			_0023_003DzPsUSx4D2yz6n.SampleDescription = new SampleDescription(1, 0);
			_0023_003DzeIRNKbDi61Y_0024(_0023_003DzPsUSx4D2yz6n);
			if (base.ControlData.isFsaaAvailable)
			{
				description.SampleDescription = new SampleDescription(1, 0);
				_0023_003DzG4rPuZTbi_V4gPxQJg_003D_003D = new Texture2D(_0023_003DzTzFVZ_00240_003D, description);
				_0023_003DzL1RoIs5YJ6eF = new DepthStencilView(_0023_003DzTzFVZ_00240_003D, _0023_003DzG4rPuZTbi_V4gPxQJg_003D_003D);
			}
			if (_0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3)
			{
				_0023_003DzfX3UC9sZfg8E = new D3DTexture2D();
				_0023_003DzfX3UC9sZfg8E._0023_003Dzcp4fLOSZApya(this, size, CpuAccessFlags.Read, ResourceUsage.Staging, Format.D24_UNorm_S8_UInt, BindFlags.None, new SampleDescription(1, 0));
			}
			else
			{
				_0023_003DzPsUSx4D2yz6n = new Texture2DDescription
				{
					BindFlags = BindFlags.RenderTarget,
					Format = Format.R32_Float,
					Width = num,
					Height = num2,
					MipLevels = 1,
					SampleDescription = new SampleDescription(1, 0),
					Usage = ResourceUsage.Default,
					OptionFlags = ResourceOptionFlags.None,
					CpuAccessFlags = CpuAccessFlags.None,
					ArraySize = 1
				};
				_0023_003DzQWdRhF_o_CD4 = new Texture2D(_0023_003DzTzFVZ_00240_003D, _0023_003DzPsUSx4D2yz6n);
				_0023_003Dz0Q1ekG6zDfXL = new RenderTargetView(_0023_003DzTzFVZ_00240_003D, _0023_003DzQWdRhF_o_CD4);
				_0023_003DzfX3UC9sZfg8E = new D3DTexture2D();
				_0023_003DzfX3UC9sZfg8E._0023_003Dzcp4fLOSZApya(this, size, CpuAccessFlags.Read, ResourceUsage.Staging, Format.R32_Float, BindFlags.None, new SampleDescription(1, 0));
			}
			ResetRenderTarget();
		}
	}

	protected virtual void InitSwapChainAndBackBufferTexture()
	{
	}

	internal abstract Texture2DDescription _0023_003Dz44KfZ5g_003D(int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D);

	private protected abstract void _0023_003DzeIRNKbDi61Y_0024(Texture2DDescription _0023_003DzPsUSx4D2yz6n);

	public override void BeginDrawForDepth()
	{
		base.BeginDrawForDepth();
		_0023_003Dzi6v0V6E_003D(new _0023_003DzB_00241i16ya3eUx(_0023_003Dz0Q1ekG6zDfXL ?? _0023_003DzipqsQZ_p852_0024, _0023_003DzL1RoIs5YJ6eF ?? _0023_003Dz52pY7YIbaCdt));
		ClearColor(System.Drawing.Color.White);
		ClearDepthStencil(depthBuffer: true, stencilBuffer: true, 0);
	}

	public override void EndDrawForDepth()
	{
		base.EndDrawForDepth();
		ResetRenderTarget();
	}

	protected internal override void SetRenderTarget(TextureBase texture)
	{
		D3DTexture2D d3DTexture2D = (D3DTexture2D)texture;
		if (((Texture2D)d3DTexture2D._0023_003Dz_IfKSJY_003D).Description.SampleDescription.Count == 1 && _0023_003DzGgYOIY9UjYous_0024b3mQ_003D_003D.Description.SampleDescription.Count > 1)
		{
			_0023_003Dzi6v0V6E_003D(new _0023_003DzB_00241i16ya3eUx(d3DTexture2D._0023_003Dz59osH17qGO0V, _0023_003DzL1RoIs5YJ6eF));
		}
		else
		{
			_0023_003Dzi6v0V6E_003D(new _0023_003DzB_00241i16ya3eUx(d3DTexture2D._0023_003Dz59osH17qGO0V, _0023_003Dz52pY7YIbaCdt));
		}
	}

	internal void _0023_003DzaQ3b8dxHyWP6(TextureBase _0023_003Dz_IfKSJY_003D, TextureBase _0023_003DzIgi4d_002476Dtqu)
	{
		SetRenderTarget(_0023_003Dz_IfKSJY_003D, _0023_003DzIgi4d_002476Dtqu);
	}

	protected override void SetRenderTarget(TextureBase texture, TextureBase depthTexture)
	{
		if (depthTexture == null)
		{
			SetRenderTarget(texture);
		}
		else
		{
			_0023_003Dzi6v0V6E_003D(new _0023_003DzB_00241i16ya3eUx((texture == null) ? null : ((D3DTexture2D)texture)._0023_003Dz59osH17qGO0V, ((D3DTextureDepth)depthTexture)._0023_003Dz52pY7YIbaCdt));
		}
	}

	public override void BeginDrawForSelection()
	{
		if (base.ControlData.isFsaaAvailable)
		{
			EnableMultisample(enable: false);
			_0023_003Dzi6v0V6E_003D(new _0023_003DzB_00241i16ya3eUx(_0023_003DzipqsQZ_p852_0024, _0023_003DzL1RoIs5YJ6eF ?? _0023_003Dz52pY7YIbaCdt));
		}
	}

	public override void EndDrawForSelection()
	{
		if (base.ControlData.isFsaaAvailable)
		{
			EnableMultisample(enable: true);
			ResetRenderTarget();
			_0023_003DzP7fhLh8_003D.Flush();
		}
	}

	internal virtual void _0023_003Dzi6v0V6E_003D(_0023_003DzB_00241i16ya3eUx _0023_003DzMYTzTqg_003D)
	{
		_0023_003Dz7XlCveSvJ5fF = _0023_003DzMYTzTqg_003D;
		_0023_003DzP7fhLh8_003D.OutputMerger.SetTargets(_0023_003DzMYTzTqg_003D._0023_003Dz52pY7YIbaCdt, _0023_003DzMYTzTqg_003D._0023_003DzfIJXGx0_003D);
	}

	protected virtual void ClearBuffers()
	{
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzGgYOIY9UjYous_0024b3mQ_003D_003D);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003Dz52pY7YIbaCdt);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzfX3UC9sZfg8E);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzJhCjKSkYMq6V);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzipqsQZ_p852_0024);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzG4rPuZTbi_V4gPxQJg_003D_003D);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzL1RoIs5YJ6eF);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003DzQWdRhF_o_CD4);
		_0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D._0023_003Dz0mdCzng_003D(ref _0023_003Dz0Q1ekG6zDfXL);
	}

	public override void ClearDepthStencil(bool depthBuffer, bool stencilBuffer, byte stencilClearValue = 0)
	{
		if (depthBuffer)
		{
			DepthStencilClearFlags depthStencilClearFlags = DepthStencilClearFlags.Depth;
			if (stencilBuffer)
			{
				depthStencilClearFlags |= DepthStencilClearFlags.Stencil;
			}
			_0023_003DzP7fhLh8_003D.ClearDepthStencilView(_0023_003Dz7XlCveSvJ5fF._0023_003Dz52pY7YIbaCdt, depthStencilClearFlags, 1f, 0);
		}
		else if (stencilBuffer)
		{
			_0023_003DzP7fhLh8_003D.ClearDepthStencilView(_0023_003Dz7XlCveSvJ5fF._0023_003Dz52pY7YIbaCdt, DepthStencilClearFlags.Stencil, 1f, stencilClearValue);
		}
	}

	public override void ClearColor(System.Drawing.Color color)
	{
		_0023_003DzP7fhLh8_003D.ClearRenderTargetView(_0023_003Dz7XlCveSvJ5fF._0023_003DzfIJXGx0_003D, _0023_003DzlMzzj_6flRUL(color));
	}

	internal Color4 _0023_003DzlMzzj_6flRUL(System.Drawing.Color _0023_003DzKni9bTk_003D)
	{
		return new Color4((float)(int)_0023_003DzKni9bTk_003D.R / 255f, (float)(int)_0023_003DzKni9bTk_003D.G / 255f, (float)(int)_0023_003DzKni9bTk_003D.B / 255f, (float)(int)_0023_003DzKni9bTk_003D.A / 255f);
	}

	public override void UpdateConstantBufferPerObject()
	{
		base.UpdateConstantBufferPerObject();
		((_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D)base.CurrentShaderTechnique)._0023_003DzBA5OJQegAhUvIN1YjA_003D_003D(_0023_003DzP7fhLh8_003D, _0023_003Dz_BT7SDwEbLrP);
	}

	public override void UpdateConstantBufferPerFrame(ShaderParameters data = null)
	{
		if (data != null)
		{
			base.UpdateConstantBufferPerFrame(data);
			if (data.Backface != null)
			{
				_0023_003DzNT32oUkqGeGp._0023_003DzZ3fch5dza_0024CRK2uxSg_003D_003D = data.Backface.ColorMethod == backfaceColorMethodType.SingleColor;
			}
			if (data is ReflectionShaderParameters)
			{
				_0023_003DzdzTABUSj5VqF((ReflectionShaderParameters)data, _0023_003DzNT32oUkqGeGp);
			}
		}
		for (int i = base.ActiveLights.Length; i < _0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1.Length; i++)
		{
			_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[i]._0023_003DzbiPzcTk_003D = 0f;
		}
		((_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D)base.CurrentShaderTechnique)._0023_003DzudrHn6AUig2kpFOdgw_003D_003D(_0023_003DzP7fhLh8_003D, _0023_003DzNT32oUkqGeGp);
	}

	private void _0023_003DzdzTABUSj5VqF(ReflectionShaderParameters _0023_003DzCBM7XJK4_5H_0024, _0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg _0023_003Dzt5jpbHs_003D)
	{
		int[] array = new int[4]
		{
			_0023_003DzCBM7XJK4_5H_0024.ViewFrame[0],
			base.ControlData.ControlSize.Height - _0023_003DzCBM7XJK4_5H_0024.ViewFrame[1] - _0023_003DzCBM7XJK4_5H_0024.ViewFrame[3],
			_0023_003DzCBM7XJK4_5H_0024.ViewFrame[2],
			_0023_003DzCBM7XJK4_5H_0024.ViewFrame[3]
		};
		float num = ((_0023_003DzCBM7XJK4_5H_0024.ZoomRect.Height == 0f) ? 0f : (1f - (_0023_003DzCBM7XJK4_5H_0024.ZoomRect.Height + _0023_003DzCBM7XJK4_5H_0024.ZoomRect.Y) / (float)array[3]));
		switch (_0023_003DzCBM7XJK4_5H_0024.Background.StyleMode)
		{
		case backgroundStyleType.None:
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzgO48Onw_003D = 0f;
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzHMURIcY_003D = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(_0023_003DzCBM7XJK4_5H_0024.ParentBackColor);
			break;
		case backgroundStyleType.Solid:
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzgO48Onw_003D = 0f;
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzHMURIcY_003D = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(((BackgroundSettings)_0023_003DzCBM7XJK4_5H_0024.Background).TopColor);
			break;
		case backgroundStyleType.LinearGradient:
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzgO48Onw_003D = 1f;
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzZvQhtZQ_003D = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(((BackgroundSettings)_0023_003DzCBM7XJK4_5H_0024.Background).BottomColor);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzHMURIcY_003D = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(((BackgroundSettings)_0023_003DzCBM7XJK4_5H_0024.Background).TopColor);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003Dz0_0024_0024VbFw_003D = new Vector2(0f, (float)array[3] * _0023_003DzCBM7XJK4_5H_0024.DrawScale);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzMwMN4hU_003D = new Vector2(0f, array[1]);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzaLDEyAb9blTZ = new Vector2(0f, num);
			break;
		case backgroundStyleType.CubicGradient:
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzgO48Onw_003D = 2f;
			_0023_003DzCBM7XJK4_5H_0024.Background.SetTexture(this, TextureBase.textureUnitType.Background);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003Dz0_0024_0024VbFw_003D = new Vector2(0f, (float)array[3] * _0023_003DzCBM7XJK4_5H_0024.DrawScale);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzMwMN4hU_003D = new Vector2(0f, array[1]);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzaLDEyAb9blTZ = new Vector2(0f, num);
			break;
		case backgroundStyleType.Image:
		{
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzgO48Onw_003D = 3f;
			_0023_003DzCBM7XJK4_5H_0024.Background.SetTexture(this, TextureBase.textureUnitType.Background);
			float bmpWidth;
			float bmpHeight;
			float imageScale = _0023_003DzCBM7XJK4_5H_0024.Background.GetImageScale(array[2], array[3], out bmpWidth, out bmpHeight);
			float x = (float)array[2] / (bmpWidth * imageScale);
			float y = (float)array[3] / (bmpHeight * imageScale);
			float x2 = _0023_003DzCBM7XJK4_5H_0024.ZoomRect.X / (float)array[2];
			float y2 = num;
			float x3 = array[0];
			float y3 = array[1];
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzmdDBb0vUt7TE = new Vector2(x, y);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003Dz0_0024_0024VbFw_003D = new Vector2(array[2], array[3]);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzMwMN4hU_003D = new Vector2(x3, y3);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzaLDEyAb9blTZ = new Vector2(x2, y2);
			_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzW_Mwciw_003D = _0023_003DzCBM7XJK4_5H_0024.DrawScale;
			break;
		}
		}
		_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzyE_Z4guKNRizEOM1IA_003D_003D = _0023_003DzCBM7XJK4_5H_0024.ReflectionIntensity;
		float _0023_003Dz125fUx6FyWXe = (float)(0.0 - _0023_003DzCBM7XJK4_5H_0024.ReflectionPlane.Equation.D);
		_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzpG46pXYAClH_0024 = _0023_003DzCBM7XJK4_5H_0024.ReflectionMaxHeight * 0.8f;
		_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003Dz125fUx6FyWXe = _0023_003Dz125fUx6FyWXe;
		_0023_003Dzt5jpbHs_003D._0023_003Dzh7lnYlk_003D._0023_003DzqzYwSbJ8o6lzCeNFBQ_003D_003D = new Vector4((float)_0023_003DzCBM7XJK4_5H_0024.ReflectionPlaneNormal.X, (float)_0023_003DzCBM7XJK4_5H_0024.ReflectionPlaneNormal.Y, (float)_0023_003DzCBM7XJK4_5H_0024.ReflectionPlaneNormal.Z, 0f);
	}

	public override void DisableClipPlanes()
	{
		bool num = _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C != ClipPlanesFlags.Zero;
		base.DisableClipPlanes();
		((_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D)base.CurrentShaderTechnique)._0023_003DzudrHn6AUig2kpFOdgw_003D_003D(_0023_003DzP7fhLh8_003D, _0023_003DzNT32oUkqGeGp);
		if (num)
		{
			SetShader(base.CurrentShader, null, force: true);
		}
	}

	public override double[] ComputePickMatrix(System.Drawing.RectangleF rectangle, Size viewportSize, int[] viewFrame)
	{
		double[] array = base.ComputePickMatrix(rectangle, viewportSize, viewFrame);
		double num = base.ControlData.ControlSize.Height - viewFrame[1] - viewFrame[3];
		if (num < 0.0)
		{
			Transformation transformation = new Translation(0.0, -2.0 * num / (double)viewFrame[3]);
			return Utility.MultMatrixd(array, transformation.MatrixAsVectorByColumn);
		}
		return array;
	}

	public override void SetViewport(int[] viewFrame, float depthMin, float depthMax)
	{
		base.SetViewport(viewFrame, depthMin, depthMax);
		_0023_003DzNT32oUkqGeGp._0023_003Dzqi43Drs_003D = new Size(viewFrame[2], viewFrame[3]);
		int _0023_003Dz8GBMuoM_003D = viewFrame[0];
		int num = base.ControlData.ControlSize.Height - viewFrame[1] - viewFrame[3];
		if (num < 0)
		{
			num = 0;
		}
		int _0023_003DzkQAiKLA_003D = viewFrame[3];
		int _0023_003Dz7PIPnGI_003D = viewFrame[2];
		if (_0023_003DzP7fhLh8_003D != null)
		{
			_0023_003DzLADmvpnYILj0(_0023_003Dz8GBMuoM_003D, num, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, depthMin, depthMax);
		}
	}

	internal override void _0023_003DzLADmvpnYILj0(int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, float _0023_003DzNsXhzVoM2zWs, float _0023_003DztKWOcOeEKDUk)
	{
		_0023_003DzP7fhLh8_003D.Rasterizer.SetViewports(new RawViewportF[1]
		{
			new SharpDX.Viewport(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003DzNsXhzVoM2zWs, _0023_003DztKWOcOeEKDUk)
		});
	}

	protected override void SetMaterial(float[] diffuseFront, float[] diffuseBack, float[] ambient, float[] specular, float shininess)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzSuWnN8cReU69x11R3A_003D_003D = new Color4(diffuseBack);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzSwMpccLliBEx = new Color4(ambient);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003Dz0rG_3k0_003D = new Color4(ambient);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003DzXN4q_0024zeq8iDq = new Color4(diffuseFront);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D = new Color4(specular[0], specular[1], specular[2], shininess);
	}

	public override void ResetColorDiffuse(float[] diffuse, float[] wireColor)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003DzXN4q_0024zeq8iDq = new Color4(diffuse);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzodM54I0_003D(new Color4(wireColor));
	}

	public override void SetLightPosition(int lightIndex, lightType lightType, float[] dir, float[] position)
	{
		double[] matrix = Utility.MultMatrixd(modelMatrices.Peek(), viewMatrices.Peek());
		double[] array = Utility.MultMatrixVecd(matrix, new double[4]
		{
			dir[0],
			dir[1],
			dir[2],
			0.0
		});
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzJuJanCE_003D = new Vector3((float)array[0], (float)array[1], (float)array[2]);
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzJuJanCE_003D.Normalize();
		if (lightType != lightType.Directional)
		{
			array = Utility.MultMatrixVecd(matrix, new double[4]
			{
				position[0],
				position[1],
				position[2],
				1.0
			});
			_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzEsu9Jcc_003D = new Vector3((float)array[0], (float)array[1], (float)array[2]);
		}
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003Dz4r_0024mn64_003D = (float)lightType;
	}

	protected override void SetMatrices(double[] d3dProj, double[] d3dView, double[] d3dModel)
	{
		base.SetMatrices(d3dProj, d3dView, d3dModel);
		double[] array = Utility.MultMatrixd(d3dModel, d3dView);
		double[] _0023_003DzbEASM6g_003D = Utility.MultMatrixd(array, d3dProj);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzcU0HDYHnAnzt(new SharpDX.Matrix(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzReuCkESVJg_0024q(_0023_003DzbEASM6g_003D)));
		_0023_003Dz_BT7SDwEbLrP._0023_003DzhgwyyOSliKf6(new SharpDX.Matrix(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzReuCkESVJg_0024q(array)));
		_0023_003Dz_BT7SDwEbLrP._0023_003DzUXELlntdw96H(new SharpDX.Matrix(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzReuCkESVJg_0024q(d3dModel)));
	}

	public override void EnableMultisample(bool enable)
	{
		bool num = _0023_003DzfSTec3RRfG0OTIPHxA_003D_003D != enable;
		_0023_003DzfSTec3RRfG0OTIPHxA_003D_003D = enable;
		if (num)
		{
			SetState(base.CurrentRasterizerState, force: true);
		}
	}

	protected override void SetStateInternal(rasterizerStateType state)
	{
		_0023_003DzP7fhLh8_003D.Rasterizer.State = (_0023_003DzfSTec3RRfG0OTIPHxA_003D_003D ? _0023_003DzCq2MbKjLVwa2eLteTm8qc8CfbMK85AuhZQ_003D_003D[state] : _0023_003DzioVUVbUUjXikAY3FaO9C77g_003D[state]);
	}

	protected override void SetStateInternal(depthStencilStateType state)
	{
		_0023_003DzP7fhLh8_003D.OutputMerger.DepthStencilState = _0023_003DzOcMxhmqWn4cmb0mNJA_003D_003D[state];
		_0023_003DzP7fhLh8_003D.OutputMerger.DepthStencilReference = GetStencilFuncRef(state);
	}

	protected override void SetStateInternal(blendStateType state, bool red, bool green, bool blue, bool alpha)
	{
		if (_0023_003DzaYnyroaiPk1g.ContainsKey(state))
		{
			_0023_003DzP7fhLh8_003D.OutputMerger.BlendState = _0023_003DzaYnyroaiPk1g[state];
		}
	}

	public override void CompileVBO(EntityGraphicsData data, DrawEntityCallBack drawEntityCallBack, object vboParams, bool dynamic = false)
	{
		D3DEntityGraphicsData d3DEntityGraphicsData = (D3DEntityGraphicsData)data;
		if (d3DEntityGraphicsData._0023_003DzyO_593HDldkn != null)
		{
			d3DEntityGraphicsData._0023_003DzyO_593HDldkn.Dispose();
		}
		VBOParamsBase vBOParamsBase = (VBOParamsBase)vboParams;
		int nVertices;
		primitiveType topology;
		float[] data2 = vBOParamsBase.GetData(out nVertices, out topology);
		if (dynamic)
		{
			d3DEntityGraphicsData._0023_003DzyO_593HDldkn = new _0023_003Dzs1_1VPmRkeowoF853hihJLs_003D(_0023_003DzTzFVZ_00240_003D, data2, vBOParamsBase.indices, topology, nVertices);
		}
		else
		{
			d3DEntityGraphicsData._0023_003DzyO_593HDldkn = new _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU(_0023_003DzwuJKWL_0024qRlUevQgx6w_003D_003D(), _0023_003DzTzFVZ_00240_003D, data2, vBOParamsBase.indices, topology, nVertices);
		}
	}

	public override void UpdateVBO(EntityGraphicsData data, DrawEntityCallBack drawEntityCallBack, object vboParams)
	{
		VBOParamsBase vBOParamsBase = (VBOParamsBase)vboParams;
		int nVertices;
		primitiveType topology;
		float[] data2 = vBOParamsBase.GetData(out nVertices, out topology);
		((_0023_003Dzs1_1VPmRkeowoF853hihJLs_003D)((D3DEntityGraphicsData)data)._0023_003DzyO_593HDldkn)._0023_003DzhzizObU_003D(data2, 0, data2.Length, nVertices, vBOParamsBase.indices, 0, (vBOParamsBase.indices != null) ? vBOParamsBase.indices.Length : 0, topology);
	}

	protected override void CompileInternal(DrawEntityCallBack drawEntityCallBack, object myParams)
	{
		D3DEntityGraphicsData d3DEntityGraphicsData = (D3DEntityGraphicsData)CompilingEntity;
		if (d3DEntityGraphicsData._0023_003DzyO_593HDldkn != null)
		{
			d3DEntityGraphicsData._0023_003DzyO_593HDldkn.Dispose();
		}
		d3DEntityGraphicsData._0023_003DzyO_593HDldkn = _0023_003DzW925NvY8XjsF();
		drawEntityCallBack(this, myParams);
		d3DEntityGraphicsData._0023_003DzyO_593HDldkn._0023_003DzrloDkpQ_003D(_0023_003DzTzFVZ_00240_003D);
	}

	private _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU _0023_003DzW925NvY8XjsF()
	{
		_0023_003Dzze_0024GKgWNSzacnVEOXA_003D_003D = new _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU();
		_0023_003Dzze_0024GKgWNSzacnVEOXA_003D_003D._0023_003Dz6ym_OKwKktrt = new List<List<float>>();
		_0023_003Dzze_0024GKgWNSzacnVEOXA_003D_003D._0023_003DzVQdby4Uk73jo52ylew_003D_003D = null;
		return _0023_003Dzze_0024GKgWNSzacnVEOXA_003D_003D;
	}

	private void _0023_003Dzped9ZPq4ahes(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, bool _0023_003DzKs6hunzjen4G)
	{
		_0023_003Dzped9ZPq4ahes(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, null, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, 0, _0023_003DzKs6hunzjen4G);
	}

	private void _0023_003Dzped9ZPq4ahes(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, int _0023_003Dz4Im51Qk_003D, bool _0023_003DzKs6hunzjen4G)
	{
		_0023_003Dzze_0024GKgWNSzacnVEOXA_003D_003D._0023_003DzgWaA5Nc_003D(_0023_003DzwuJKWL_0024qRlUevQgx6w_003D_003D(), _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, _0023_003Dz4Im51Qk_003D, !_0023_003DzKs6hunzjen4G);
	}

	private void _0023_003DzDY65k27LcWzt(Bitmap _0023_003Dza0pUM94_003D)
	{
	}

	private void _0023_003DzDY65k27LcWzt(string _0023_003Dz83HaHYE_003D)
	{
		Bitmap bitmap = new Bitmap(_0023_003Dz83HaHYE_003D);
		try
		{
			_0023_003DzDY65k27LcWzt(bitmap);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	public override TextureBase CreateTexture2D(Image image, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool enlargeIfSizeNotSupported = false, bool repeatX = true, bool repeatY = true)
	{
		D3DTexture result;
		if (image is Bitmap)
		{
			result = new D3DTexture2D(this, (Bitmap)image, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY);
		}
		else
		{
			Bitmap bitmap = new Bitmap(image);
			result = new D3DTexture2D(this, bitmap, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY);
			bitmap.Dispose();
		}
		return result;
	}

	public override TextureBase CreateTexture2D(Size size, bool depthTexture, textureFilteringFunctionType minFilterFunc = textureFilteringFunctionType.Nearest, textureFilteringFunctionType magFilterFunc = textureFilteringFunctionType.Nearest)
	{
		Texture texture = ((!depthTexture) ? ((D3DTextureBase)new D3DTexture2D()) : ((D3DTextureBase)new D3DTextureDepth()));
		texture.AllocateMemory(this, renderTarget: true, size.Width, size.Height, minFilterFunc, magFilterFunc, repeatS: false, repeatT: false, IntPtr.Zero, IsMultisample());
		return texture;
	}

	public override TextureBase CreateTexture2DNoMultisample(Size size, bool depthTexture)
	{
		D3DTexture2D d3DTexture2D = new D3DTexture2D();
		if (depthTexture)
		{
			throw new NotImplementedException();
		}
		d3DTexture2D.AllocateMemory(this, renderTarget: true, size.Width, size.Height, textureFilteringFunctionType.LinearMipmapLinear, textureFilteringFunctionType.LinearMipmapLinear, repeatS: false, repeatT: false, IntPtr.Zero, multisample: false);
		return d3DTexture2D;
	}

	public override TextureBase CreateTexture1D(System.Drawing.Color[] colorTable, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true)
	{
		TextureBase textureBase = ((_0023_003DzGIPo6pY0ShMi != FeatureLevel.Level_9_3) ? ((D3DTexture)new _0023_003Dz0F0alDAPpvjxD7vGCF6uwpvHPCis(colorTable)) : ((D3DTexture)new D3DTexture2D(this, colorTable)));
		textureBase.Load(this, minFunc, magFunc, anisotropicFiltering, repeatX);
		return textureBase;
	}

	public override int MaxTextureSize()
	{
		return 16384;
	}

	private protected override AOCompositingBase GetAoCompositingObj(bool _0023_003DzUOFKio2ucC4D)
	{
		return new _0023_003DzkrKg_i8aTwYrNyG1idttTI0ogqanZtrgyEXlzOc_003D(_0023_003DzUOFKio2ucC4D);
	}

	private protected override SilhoCompositingBase GetSilhoCompositingObj()
	{
		return new _0023_003DzJaZ7iKKSq5W6u3_vFTYFGkj4hJYLXPedJvIOflby7W64();
	}

	private protected override SmoothUICompositingBase GetSmoothUICompositingObj()
	{
		return new _0023_003DzGN6L4iqA40fnK_jNmDrzBhNVvUE3NT1lJFshoGLOjlNngLRVZQ_003D_003D();
	}

	private protected override HaloSelectionCompositingBase GetDynamicSelectionCompositingObj()
	{
		return new _0023_003DzMS7jTyevb1TJ75swRGke4rxLgN7jxySy_IDWV7zbYiRr();
	}

	public override void InitTexturesForCapture()
	{
		if (base.ControlData.isFsaaAvailable)
		{
			texSize = base.ControlData.ControlSize;
			InitTexturesForCaptureInternal(1);
		}
		else
		{
			base.InitTexturesForCapture();
		}
	}

	public override void ResizeSurfacesForCapture(Size size, bool antialiasing)
	{
		if (base.ControlData.isFsaaAvailable)
		{
			if (size.Width != texSize.Width || size.Height != texSize.Height || texturesForCapture == null)
			{
				texSize = size;
				InitTexturesForCapture();
			}
		}
		else
		{
			base.ResizeSurfacesForCapture(size, false);
		}
	}

	public override void ReadSurface(Size controlSize, bool backBuffer, bool antialiasing)
	{
		base.ReadSurface(controlSize, backBuffer, antialiasing);
		int num = 0;
		if (base.ControlData.isFsaaAvailable)
		{
			_0023_003DzP7fhLh8_003D.ResolveSubresource(_0023_003DzxPP8x2119RobVE2x5A_003D_003D(), 0, ((D3DTexture2D)texturesForCapture[0])._0023_003Dz_IfKSJY_003D, 0, _0023_003DzxPP8x2119RobVE2x5A_003D_003D().Description.Format);
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				((D3DTexture2D)texturesForCapture[num++]).FillTextureFromScreen(controlSize, texSize.Width * j, texSize.Height * i, texSize.Width, texSize.Height, this);
			}
		}
	}

	internal Bitmap _0023_003DzZOAhTmU_003D(System.Drawing.Rectangle _0023_003Dzols9v2M_003D)
	{
		byte[] _0023_003DzpZy6QX0_003D = _0023_003Dz1K9wf5pSDf4i(_0023_003Dzols9v2M_003D, _0023_003DzxPP8x2119RobVE2x5A_003D_003D(), _0023_003DzaNkZ4Os_003D: false);
		return RenderContext._0023_003Dzn6L6n02G6rY2(_0023_003Dzols9v2M_003D.Size, _0023_003DzpZy6QX0_003D);
	}

	public override Bitmap GetBitmapFromTexture(TextureBase texture)
	{
		D3DTexture2D d3DTexture2D = (D3DTexture2D)texture;
		byte[] colorValues = _0023_003Dz1K9wf5pSDf4i(new System.Drawing.Rectangle(0, 0, d3DTexture2D.Size.Width, d3DTexture2D.Size.Height), (Texture2D)d3DTexture2D._0023_003Dz_IfKSJY_003D, _0023_003DzaNkZ4Os_003D: false);
		return GetBitmapFromData(new System.Drawing.Rectangle(0, 0, d3DTexture2D.Size.Width, d3DTexture2D.Size.Height), colorValues, d3DTexture2D.Size.Width * 4, 4);
	}

	public override byte[] ReadDepthBuffer(System.Drawing.Rectangle rect, out int stride, out int bpp)
	{
		Texture2D _0023_003DzyQmY6T8_003D = _0023_003DzGgYOIY9UjYous_0024b3mQ_003D_003D;
		if (base.ControlData.isFsaaAvailable)
		{
			_0023_003DzyQmY6T8_003D = _0023_003DzG4rPuZTbi_V4gPxQJg_003D_003D;
		}
		byte[] result = D3DTextureDepth._0023_003DzNqVBjksx5BGm9KUZ8g_003D_003D(this, _0023_003DzyQmY6T8_003D, rect);
		bpp = 4;
		stride = rect.Width * bpp;
		return result;
	}

	public override byte[] ReadColorBuffer(IViewport viewport, System.Drawing.Rectangle rect, out int stride, out int bpp)
	{
		Texture2D _0023_003DzKypN2EjGsmUg = _0023_003DzxPP8x2119RobVE2x5A_003D_003D();
		if (base.ControlData.isFsaaAvailable)
		{
			_0023_003DzKypN2EjGsmUg = _0023_003DzJhCjKSkYMq6V;
		}
		byte[] result = _0023_003Dz1K9wf5pSDf4i(rect, _0023_003DzKypN2EjGsmUg, _0023_003DzaNkZ4Os_003D: false);
		bpp = 4;
		stride = rect.Width * bpp;
		return result;
	}

	private byte[] _0023_003Dz1K9wf5pSDf4i(System.Drawing.Rectangle _0023_003Dzols9v2M_003D, Texture2D _0023_003DzKypN2EjGsmUg, bool _0023_003DzaNkZ4Os_003D)
	{
		if (_0023_003Dzols9v2M_003D.IsEmpty)
		{
			_0023_003Dzols9v2M_003D = new System.Drawing.Rectangle(0, 0, _0023_003DzKypN2EjGsmUg.Description.Width, _0023_003DzKypN2EjGsmUg.Description.Height);
		}
		D3DTexture2D d3DTexture2D = new D3DTexture2D();
		Size _0023_003Dz0ERMHbg_003D = _0023_003Dzols9v2M_003D.Size;
		if (_0023_003DzKypN2EjGsmUg.Description.SampleDescription.Count > 1)
		{
			_0023_003Dz0ERMHbg_003D = new Size(_0023_003DzKypN2EjGsmUg.Description.Width, _0023_003DzKypN2EjGsmUg.Description.Height);
		}
		d3DTexture2D._0023_003Dzcp4fLOSZApya(this, _0023_003Dz0ERMHbg_003D, CpuAccessFlags.Read, ResourceUsage.Staging, _0023_003DzaNkZ4Os_003D ? Format.D24_UNorm_S8_UInt : Format.R8G8B8A8_UNorm, BindFlags.None, new SampleDescription(1, 0));
		byte[] result = d3DTexture2D._0023_003DzV9WuMm8_003D(_0023_003Dzols9v2M_003D, this, _0023_003DzKypN2EjGsmUg);
		d3DTexture2D.Dispose();
		return result;
	}

	protected override short[] ReadDepthValuesInternal(int[] layoutViewport)
	{
		return ReadDepthValues(layoutViewport[0], layoutViewport[1], new Size(layoutViewport[2], layoutViewport[3]));
	}

	internal override void _0023_003DzYDHFZIvmSA1e(Size _0023_003Dz0ERMHbg_003D, ref Bitmap _0023_003Dza0pUM94_003D, out int _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D)
	{
		base._0023_003DzYDHFZIvmSA1e(_0023_003Dz0ERMHbg_003D, ref _0023_003Dza0pUM94_003D, out _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D);
		ClearDepthStencil(depthBuffer: false, stencilBuffer: true, 0);
		_0023_003DzmskL2p3u6LWW();
	}

	public override void BeginCaptureZBufferOnce()
	{
		base.BeginCaptureZBufferOnce();
		if (!_0023_003DzraM_0024_00240ZTZX6Z)
		{
			_0023_003DzraM_0024_00240ZTZX6Z = true;
			_0023_003DzOc6QOxFoErNQ = false;
		}
	}

	public override void EndCaptureZBufferOnce()
	{
		base.EndCaptureZBufferOnce();
		_0023_003DzraM_0024_00240ZTZX6Z = false;
	}

	private void _0023_003DzmskL2p3u6LWW()
	{
		if (!_0023_003DzraM_0024_00240ZTZX6Z || !_0023_003DzOc6QOxFoErNQ)
		{
			_0023_003DzOc6QOxFoErNQ = true;
			if (_0023_003DzGIPo6pY0ShMi == FeatureLevel.Level_9_3)
			{
				_0023_003DzP7fhLh8_003D.CopyResource(_0023_003DzQWdRhF_o_CD4, _0023_003DzfX3UC9sZfg8E._0023_003Dz_IfKSJY_003D);
			}
			else if (base.ControlData.isFsaaAvailable)
			{
				_0023_003DzP7fhLh8_003D.CopyResource(_0023_003DzG4rPuZTbi_V4gPxQJg_003D_003D, _0023_003DzfX3UC9sZfg8E._0023_003Dz_IfKSJY_003D);
			}
			else
			{
				_0023_003DzP7fhLh8_003D.CopyResource(_0023_003DzGgYOIY9UjYous_0024b3mQ_003D_003D, _0023_003DzfX3UC9sZfg8E._0023_003Dz_IfKSJY_003D);
			}
		}
	}

	public override short[] ReadDepthValues(int left, int bottom, Size size)
	{
		System.Drawing.Rectangle rect = new System.Drawing.Rectangle(left, bottom, size.Width, size.Height);
		int num = base.ControlData.ControlSize.Height - rect.Y - size.Height;
		if (num < 0)
		{
			rect.Y = 0;
			rect.Height += num;
		}
		else
		{
			rect.Y = num;
		}
		if (rect.X < 0)
		{
			rect.Width += rect.X;
			rect.X = 0;
		}
		if (rect.Height <= 0)
		{
			rect.Height = 0;
		}
		Size size2 = new Size(((Texture2D)_0023_003DzfX3UC9sZfg8E._0023_003Dz_IfKSJY_003D).Description.Width, ((Texture2D)_0023_003DzfX3UC9sZfg8E._0023_003Dz_IfKSJY_003D).Description.Height);
		if (rect.Right > size2.Width)
		{
			rect.Width -= rect.Right - size2.Width;
		}
		if (rect.Bottom > size2.Height)
		{
			rect.Height -= rect.Bottom - size2.Height;
		}
		if (rect.Width <= 0 || rect.Height <= 0)
		{
			return null;
		}
		return _0023_003DzfX3UC9sZfg8E.ReadDepths(rect);
	}

	internal void _0023_003DzOwzXkEuEZQsG()
	{
		if (_0023_003DzgliipBi37pmb.Count > 0)
		{
			_0023_003Dzi6v0V6E_003D(_0023_003DzgliipBi37pmb.Pop());
		}
	}

	internal void _0023_003DzElzSDDQsrPlQ()
	{
		_0023_003DzgliipBi37pmb.Push(_0023_003Dz7XlCveSvJ5fF);
	}

	public override void PushCurrentFBO()
	{
		_0023_003DzElzSDDQsrPlQ();
	}

	public override void RestoreFBO()
	{
		_0023_003DzOwzXkEuEZQsG();
	}

	public override void ProcessClippingPlanes(ClippingPlaneBase[] clippingPlanes, bool updateGraphics = false)
	{
		double[] m = Utility.MultMatrixd(modelMatrices.Peek(), viewMatrices.Peek());
		Transformation transformation = new Transformation(m, byRow: false);
		transformation.Invert();
		transformation.Transpose();
		m = transformation.MatrixAsVectorByColumn;
		bool flag = _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C != ClipPlanesFlags.Zero;
		for (int i = 0; i < clippingPlanes.Length; i++)
		{
			FlagsHelper.SetUnset(ref _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C, (ClipPlanesFlags)(1 << i), clippingPlanes[i].Active);
			if (clippingPlanes[i].Active)
			{
				double[] array = Utility.MultMatrixVecd(m, clippingPlanes[i].Coefficients());
				_0023_003DzNT32oUkqGeGp._0023_003Dz1fK2GcGGTTUi[i] = new Vector4((float)array[0], (float)array[1], (float)array[2], (float)array[3]);
			}
		}
		if (updateGraphics)
		{
			((_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D)base.CurrentShaderTechnique)._0023_003DzudrHn6AUig2kpFOdgw_003D_003D(_0023_003DzP7fhLh8_003D, _0023_003DzNT32oUkqGeGp);
		}
		if (flag != (_0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C != ClipPlanesFlags.Zero))
		{
			SetShader(base.CurrentShader, null, force: true);
		}
	}

	public override void ProcessClippingPlanesVisibility(ClippingPlaneBase[] clippingPlanes, bool updateGraphics = false)
	{
		ClipPlanesFlags _0023_003DzUqa5ZahBwV4C = _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C;
		base.ProcessClippingPlanesVisibility(clippingPlanes, updateGraphics);
		if (_0023_003DzUqa5ZahBwV4C == ClipPlanesFlags.Zero && _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C != ClipPlanesFlags.Zero)
		{
			((_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)((_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D)base.CurrentShaderTechnique).Shader)._0023_003DzY5NLG7xn1HVsQF5W_0024w_003D_003D(_0023_003DzP7fhLh8_003D, _0023_003DzWtFDQr8_003D: true);
		}
		else if (_0023_003DzUqa5ZahBwV4C != ClipPlanesFlags.Zero && _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C == ClipPlanesFlags.Zero)
		{
			((_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)((_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D)base.CurrentShaderTechnique).Shader)._0023_003DzY5NLG7xn1HVsQF5W_0024w_003D_003D(_0023_003DzP7fhLh8_003D, _0023_003DzWtFDQr8_003D: false);
		}
		if (updateGraphics)
		{
			((_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D)base.CurrentShaderTechnique)._0023_003DzudrHn6AUig2kpFOdgw_003D_003D(_0023_003DzP7fhLh8_003D, _0023_003DzNT32oUkqGeGp);
		}
	}

	public override TextureBase CreateTexture2D()
	{
		return new D3DTexture2D();
	}

	internal int _0023_003DzKjAPrkH_0024OGSs(Filter _0023_003DzyEJxcb2yCP94, bool _0023_003DzDXSkCVA_003D, bool _0023_003DzLYY7OMQ_003D, SharpDX.Direct3D11.Device _0023_003DzJ_0024CASPE_003D, float _0023_003DzAdN79e4_zWpY)
	{
		if (_0023_003DzGIPo6pY0ShMi <= FeatureLevel.Level_9_3)
		{
			_0023_003DzAdN79e4_zWpY = float.MaxValue;
		}
		for (int i = 0; i < _0023_003DzCs9juxBz5x1N.Count; i++)
		{
			SamplerStateDescription description = _0023_003DzCs9juxBz5x1N[i].Description;
			if (description.Filter == _0023_003DzyEJxcb2yCP94 && description.AddressU == (TextureAddressMode)(_0023_003DzDXSkCVA_003D ? 1 : 3) && description.AddressV == (TextureAddressMode)(_0023_003DzLYY7OMQ_003D ? 1 : 3) && description.MaximumLod == _0023_003DzAdN79e4_zWpY)
			{
				return i;
			}
		}
		SamplerState item = new SamplerState(_0023_003DzJ_0024CASPE_003D, new SamplerStateDescription
		{
			Filter = _0023_003DzyEJxcb2yCP94,
			AddressU = (_0023_003DzDXSkCVA_003D ? TextureAddressMode.Wrap : TextureAddressMode.Clamp),
			AddressV = (_0023_003DzLYY7OMQ_003D ? TextureAddressMode.Wrap : TextureAddressMode.Clamp),
			AddressW = TextureAddressMode.Wrap,
			BorderColor = SharpDX.Color.Black,
			ComparisonFunction = Comparison.Never,
			MaximumAnisotropy = 16,
			MipLodBias = 0f,
			MinimumLod = 0f,
			MaximumLod = _0023_003DzAdN79e4_zWpY
		});
		_0023_003DzCs9juxBz5x1N.Add(item);
		return _0023_003DzCs9juxBz5x1N.Count - 1;
	}

	public override void PaintBackBuffer(int controlHeight)
	{
		int num = 0;
		if (base.ControlData.isFsaaAvailable)
		{
			TextureBase textureBase = texturesForCapture[num];
			SetTexture(textureBase);
			DrawQuad(texturesForCapture[num], byte.MaxValue, new System.Drawing.RectangleF(0f, 0f, textureBase.Size.Width, textureBase.Size.Height), 0f, flipY: false);
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			int num2 = 0;
			while (num2 < 3)
			{
				SetTexture(texturesForCapture[num]);
				DrawQuad(texturesForCapture[num], byte.MaxValue, new System.Drawing.RectangleF(num2 * texSize.Width, controlHeight - (i + 1) * texSize.Height, texSize.Width, texSize.Height), 0f, flipY: false);
				num2++;
				num++;
			}
		}
	}

	public override Dictionary<shaderType, IShaderTechnique> CreateShaders(realisticShadowQualityType shadowQuality, LightSettings[] lights)
	{
		if (_0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3)
		{
			return _0023_003Dzfp7j4xKfP6kqmtbCfA_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>(shadowQuality, lights);
		}
		return _0023_003Dzfp7j4xKfP6kqmtbCfA_003D_003D<_0023_003DzfPAV5eZ7RPdOYqUpenUvU32e2y1GdVHMQtLpwR4_003D>(shadowQuality, lights);
	}

	private Dictionary<shaderType, IShaderTechnique> _0023_003Dzfp7j4xKfP6kqmtbCfA_003D_003D<T>(realisticShadowQualityType _0023_003DzM7ye9srZVEJJ, LightSettings[] _0023_003DzMuApP021PUyU) where T : struct, _0023_003DzxlkUGOHLNznjaogT7e4XpG7_0024jwSH
	{
		Dictionary<shaderType, IShaderTechnique> dictionary = new Dictionary<shaderType, IShaderTechnique>();
		dictionary = new Dictionary<shaderType, IShaderTechnique>();
		bool _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D = true;
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.BlendFrozenOverOpaque, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599630), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MinDepth, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599618), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.DrawActiveOpaque, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz_00241S53PDm6YuOODV5iYuAam_JzfM2l3WFEzgr2oE_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599635), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.NoLights, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599650), new InputElement[1]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColor, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY, global::_0023_003Dz77olUiW63j1Slq6NZtoa_0024EPlaIny33HDHg_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599667), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColorShadow, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dz77olUiW63j1Slq6NZtoa_0024EPlaIny33HDHg_003D_003D<T>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605078), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColorNoLights, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605119), new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColorNoLightsWithNormals, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605126), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.SingleColorModulatedByIntensity, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605154), new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColorSelected, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604956), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLights, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003Dz_00241S53PDm6YuOODV5iYuAam_JzfM2l3WFEzgr2oE_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604963), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLightsWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003Dz_00241S53PDm6YuOODV5iYuAam_JzfM2l3WFEzgr2oE_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604963), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605003), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLightsDepth, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604963), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605031), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLightsModulate, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605322), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLightsModulateWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605354), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605389), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLightsDecal, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605354), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLightsDecalWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605354), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605409), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture1DNoLights, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605208), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, -1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Standard, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605216), new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.StandardShadow, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605233), new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Environment, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003Dzxcx1oSUKloXps52LzVkuT360Xu6n, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592138), new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentShadow, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dzxcx1oSUKloXps52LzVkuT360Xu6n>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605276), new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentMulticolor, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003Dzxcx1oSUKloXps52LzVkuT360Xu6n, global::_0023_003Dz77olUiW63j1Slq6NZtoa_0024EPlaIny33HDHg_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605284), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentMulticolorShadow, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dzxcx1oSUKloXps52LzVkuT360Xu6n>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dz77olUiW63j1Slq6NZtoa_0024EPlaIny33HDHg_003D_003D<T>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604552), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture2D, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604582), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture2DWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604582), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604619), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture2DShadow, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604644), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture2DShadowWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604644), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604419), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture1D, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604470), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture1DShadow, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604507), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2D, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604538), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604538), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604810), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DShadow, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604846), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DShadowWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604846), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604856), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture1D, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604886), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture1DShadow, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<T>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604902), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DDecal, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604912), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DDecalWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604912), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604699), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.WriteDepth, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604730), new InputElement[1]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, -1)));
		if (_0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3)
		{
			IShader shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604745), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605216), new InputElement[2]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			IShader shader2 = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604783), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599650), new InputElement[1]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1));
			IShader shader3 = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604789), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605208), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, -1));
			IShader shader4 = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606098), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605154), new InputElement[2]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1));
			IShader shader5 = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606145), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605119), new InputElement[2]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1));
			IShader shader6 = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606205), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605990), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606042), 0, Format.R32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1));
			IShader geometryShader = new global::_0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606062), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			IShader geometryShader2 = new global::_0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606078), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			IShader geometryShader3 = new global::_0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DzJi4JXjWEf7n6Phjq8LRhhj23STB1yi7A4Yn_vi0_003D, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606349), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			IShader geometryShader4 = new global::_0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DzJi4JXjWEf7n6Phjq8LRhhj23STB1yi7A4Yn_vi0_003D, T>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606355), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			IShader geometryShader5 = new global::_0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606392), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			IShader geometryShader6 = new global::_0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606431), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			dictionary.Add(shaderType.NoLightsThickLines, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader2,
				GeometryShader = geometryShader
			});
			dictionary.Add(shaderType.NoLightsThickPoints, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader2,
				GeometryShader = geometryShader2
			});
			dictionary.Add(shaderType.Texture1DNoLightsThickLines, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader3,
				GeometryShader = geometryShader
			});
			dictionary.Add(shaderType.SingleColorModulatedByIntensityThickLines, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader4,
				GeometryShader = geometryShader
			});
			dictionary.Add(shaderType.SingleColorModulatedByIntensityThickPoints, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader4,
				GeometryShader = geometryShader2
			});
			dictionary.Add(shaderType.MultiColorNoLightsThickLines, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader5,
				GeometryShader = geometryShader
			});
			dictionary.Add(shaderType.MultiColorNoLightsThickPoints, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader5,
				GeometryShader = geometryShader2
			});
			dictionary.Add(shaderType.MultiColorNoLightsThickLinesPerVertex, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader6,
				GeometryShader = geometryShader5
			});
			dictionary.Add(shaderType.MultiColorNoLightsThickPointsPerVertex, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader6,
				GeometryShader = geometryShader6
			});
			dictionary.Add(shaderType.StandardThickLines, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader,
				GeometryShader = geometryShader3
			});
			dictionary.Add(shaderType.StandardThickPoints, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader,
				GeometryShader = geometryShader4
			});
			IShader shader7 = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003Dziblu20F4WrJTtKvwMfnfw1g4bI5rFI0soiBFuJk_003D, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606437), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606212), new InputElement[1]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			IShader geometryShader7 = new global::_0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606254), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			dictionary.Add(shaderType.NoLightsLinesStipple, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader7,
				GeometryShader = geometryShader7
			});
			IShader geometryShader8 = new global::_0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ, _0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606267), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1));
			dictionary.Add(shaderType.NoLightsThickLinesStipple, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
			{
				Shader = shader7,
				GeometryShader = geometryShader8
			});
		}
		SetShader(shaderType.MultiColor);
		return dictionary;
	}

	public override Dictionary<shaderType, IShaderTechnique> CreateReflectionShaders(realisticShadowQualityType shadowQuality, orientationType orientationMode, IBackgroundSettings background, LightSettings[] lights)
	{
		if (ReflectionShaders != null || _0023_003DzGIPo6pY0ShMi == FeatureLevel.Level_9_3)
		{
			return ReflectionShaders;
		}
		Dictionary<shaderType, IShaderTechnique> dictionary = new Dictionary<shaderType, IShaderTechnique>();
		string text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606275);
		string text2 = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606290);
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.BlendFrozenOverOpaque, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599630), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MinDepth, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599618), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.DrawActiveOpaque, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz_00241S53PDm6YuOODV5iYuAam_JzfM2l3WFEzgr2oE_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599635), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.NoLights, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzGHWRBLH0lr1VN0HsjauNDisQHPPQ>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599650) + text, new InputElement[1]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColor, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<global::_0023_003Dz77olUiW63j1Slq6NZtoa_0024EPlaIny33HDHg_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599667) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColorShadow, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<global::_0023_003Dz77olUiW63j1Slq6NZtoa_0024EPlaIny33HDHg_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599667) + text2, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColorNoLights, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605119) + text, new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.MultiColorSelected, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604956) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLights, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604963) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DNoLightsWithAlphaMap, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604963) + text, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605003) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture1DNoLights, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DznGFW_qeyUXaLrneCPDHGxXKf1pKb>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzSBv4WigPkvukUZni9Bv24iP3WucU_0024YQWnA_003D_003D>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605208) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Standard, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605216) + text, new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.StandardShadow, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605216) + text2, new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2D, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604538) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604538) + text, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604810) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DShadow, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604538) + text2, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DShadowWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604538) + text2, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604538) + text2 + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606331), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture1D, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604886) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture1DShadow, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzMG949KP_xux_ynG9A0E20TkrlY_0024y>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604886) + text2, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DDecal, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604912) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Texture2DDecalWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dz0U4xwNqz0dC6_0024pdwPOhxPRVViaDY>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604912) + text, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604699) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.Environment, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dzxcx1oSUKloXps52LzVkuT360Xu6n>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592138) + text, new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentShadow, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dzxcx1oSUKloXps52LzVkuT360Xu6n>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592138) + text2, new InputElement[2]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentMulticolor, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dzxcx1oSUKloXps52LzVkuT360Xu6n>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<global::_0023_003Dz77olUiW63j1Slq6NZtoa_0024EPlaIny33HDHg_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605284) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentMulticolorShadow, dictionary, new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003Dzxcx1oSUKloXps52LzVkuT360Xu6n>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<global::_0023_003Dz77olUiW63j1Slq6NZtoa_0024EPlaIny33HDHg_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605284) + text2, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605058), 0, Format.R32G32B32A32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture2D, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604582) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture2DWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604582) + text, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604619) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture2DShadow, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604582) + text2, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture2DShadowWithAlphaMap, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604582) + text2, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604582) + text2 + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606331), new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture1D, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604470) + text, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		_0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType.EnvironmentTexture1DShadow, dictionary, new global::_0023_003DzeZPT_0024NXiaVtaThvmAglw_0024786BbBx<global::_0023_003Dztoqu7NOl_0024YHkI_00248oo82AD68XIXInGWQ9vg_003D_003D<_0023_003DzRA8owMYmRrBahkIE18YL4jyMdLUt>, global::_0023_003Dzpwk3AMZ_00242bGnKH5xMDz32Bqs389Zuac3Ow_003D_003D<global::_0023_003Dzk47xz1b82nuZBsSNNKXvCRs3qzNcDmk_zw_003D_003D<_0023_003DzsmCUcHuqGwyLQNdp0skU_MTHe2Yi>>>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348604470) + text2, new InputElement[3]
		{
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
			new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32_Float, InputElement.AppendAligned, 0)
		}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1)));
		return dictionary;
	}

	private void _0023_003DzLSa33vJeiCQ3hQ2yIF2eQg0_003D(shaderType _0023_003DzhklmJFQ_003D, Dictionary<shaderType, IShaderTechnique> _0023_003Dz19GQb0b_ZY_A, IShader _0023_003DzqP_0024Pj_0_003D)
	{
		_0023_003Dz19GQb0b_ZY_A.Add(_0023_003DzhklmJFQ_003D, new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = _0023_003DzqP_0024Pj_0_003D
		});
	}

	protected override void SetRGB(byte r, byte g, byte b)
	{
		SetRGBA(r, g, b, byte.MaxValue);
	}

	protected override void SetRGBA(byte r, byte g, byte b, byte a)
	{
		_0023_003DzSvrGcqgkv9ju(new Color4((float)((double)(int)r / 255.0), (float)((double)(int)g / 255.0), (float)((double)(int)b / 255.0), (float)((double)(int)a / 255.0)));
	}

	protected override void SetRGBA(float[] rgba)
	{
		_0023_003DzSvrGcqgkv9ju(new Color4(rgba));
	}

	private void _0023_003DzSvrGcqgkv9ju(Color4 _0023_003Dzhpb8QNg_003D)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzodM54I0_003D(_0023_003Dzhpb8QNg_003D);
	}

	public override void SetColorMaterial(System.Drawing.Color color, bool force = false)
	{
		switch (ColorMaterialMode)
		{
		case colorMaterialType.FrontAndBackFaceDiffuse:
			SetMaterialFrontAndBackDiffuse(color, force);
			break;
		case colorMaterialType.Disabled:
		case colorMaterialType.FrontFaceDiffuse:
			if (force || color != base.CurrentMaterial.Diffuse)
			{
				base.CurrentMaterial.Diffuse = color;
				SetMaterialFrontDiffuse(Utility.ColorToFloatArray(color));
			}
			break;
		}
	}

	protected override void SetMaterialFrontDiffuse(float[] color)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003DzXN4q_0024zeq8iDq = new Color4(color);
	}

	protected override void SetMaterialBackDiffuse(float[] color)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzSuWnN8cReU69x11R3A_003D_003D = new Color4(color);
	}

	protected override void SetMaterialFrontAmbient(float[] color)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003Dz0rG_3k0_003D = new Color4(color);
	}

	protected override void SetMaterialBackAmbient(float[] color)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzSwMpccLliBEx = new Color4(color);
	}

	public override void SetSceneAmbient(float[] color)
	{
		_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON = new Vector4(color);
	}

	public override void InitializePreviousColors()
	{
		base.InitializePreviousColors();
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003DzXN4q_0024zeq8iDq = _0023_003DzlMzzj_6flRUL(base.CurrentMaterial.Diffuse);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003Dz0rG_3k0_003D = _0023_003DzlMzzj_6flRUL(base.CurrentMaterial.Ambient);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D = _0023_003DzlMzzj_6flRUL(base.CurrentMaterial.Specular);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzbYnfewY_003D._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D.Alpha = base.CurrentMaterial.Shininess * 128f;
		base.CurrentBackMaterial.Ambient = base.CurrentMaterial.Ambient;
		base.CurrentBackMaterial.Diffuse = base.CurrentMaterial.Diffuse;
		_0023_003Dz_BT7SDwEbLrP._0023_003DzSwMpccLliBEx = _0023_003DzlMzzj_6flRUL(base.CurrentBackMaterial.Ambient);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzSuWnN8cReU69x11R3A_003D_003D = _0023_003DzlMzzj_6flRUL(base.CurrentBackMaterial.Diffuse);
	}

	public override void InitializeCurrentWireColor()
	{
		base.InitializeCurrentWireColor();
		_0023_003Dz_BT7SDwEbLrP._0023_003DzodM54I0_003D(_0023_003DzlMzzj_6flRUL(base.CurrentWireColor));
	}

	protected override bool EnableShader(shaderType shader, Dictionary<shaderType, IShaderTechnique> shaders)
	{
		if (!base.EnableShader(shader, shaders))
		{
			return false;
		}
		return _0023_003DzNZq5_002458O88Y2((_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D)shaders[shader]);
	}

	private bool _0023_003DzNZq5_002458O88Y2(_0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D _0023_003DzPdfq2XlpNUNTlWlfjGuwEgA_003D)
	{
		_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D _0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D2 = (_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)_0023_003DzPdfq2XlpNUNTlWlfjGuwEgA_003D.Shader;
		if (!_0023_003DzPdfq2XlpNUNTlWlfjGuwEgA_003D.UpdatedInFrame)
		{
			_0023_003DzPdfq2XlpNUNTlWlfjGuwEgA_003D._0023_003DzudrHn6AUig2kpFOdgw_003D_003D(_0023_003DzP7fhLh8_003D, _0023_003DzNT32oUkqGeGp);
		}
		_0023_003DzP7fhLh8_003D.InputAssembler.InputLayout = _0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D2._0023_003Dzqa6FU0IQlA38();
		_0023_003DzPdfq2XlpNUNTlWlfjGuwEgA_003D._0023_003DzCCBca0k_003D(_0023_003DzP7fhLh8_003D, _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C != ClipPlanesFlags.Zero);
		return true;
	}

	protected internal override void CloseTextureInternal(TextureBase.textureUnitType textureUnit, bool force = false)
	{
		base.CloseTextureInternal(textureUnit, force);
		_0023_003DzP7fhLh8_003D.PixelShader.SetShaderResource((int)textureUnit, null);
		_0023_003DzP7fhLh8_003D.PixelShader.SetSampler((int)textureUnit, null);
	}

	internal void _0023_003DzKY6s2YVYp9gUzvUVVw_003D_003D(_0023_003Dzh1pLMX6wbsARaRfWQQ_003D_003D _0023_003DzVphhjzI_0024J3_0024AxPOI0w_003D_003D)
	{
		this._0023_003DzVphhjzI_0024J3_0024AxPOI0w_003D_003D = _0023_003DzVphhjzI_0024J3_0024AxPOI0w_003D_003D;
	}

	public override void SetBlockRefTransform(float[] blockRefrenceMatrix)
	{
	}

	protected override void ResolveShaderType(ref shaderType type)
	{
		if (_0023_003DzGIPo6pY0ShMi <= FeatureLevel.Level_9_3)
		{
			switch (type)
			{
			case shaderType.NoLightsThickLines:
			case shaderType.NoLightsThickPoints:
				type = shaderType.NoLights;
				return;
			case shaderType.SingleColorModulatedByIntensityThickLines:
			case shaderType.SingleColorModulatedByIntensityThickPoints:
				type = shaderType.SingleColorModulatedByIntensity;
				return;
			case shaderType.MultiColorNoLightsThickLines:
			case shaderType.MultiColorNoLightsThickPoints:
			case shaderType.MultiColorNoLightsThickLinesPerVertex:
			case shaderType.MultiColorNoLightsThickPointsPerVertex:
				type = shaderType.MultiColorNoLights;
				return;
			}
		}
		base.ResolveShaderType(ref type);
	}

	internal void _0023_003DzzwTgUnl0cwiB()
	{
		ResetRenderTarget();
	}

	protected internal override void BlurTexture(ref TextureBase sharpTexture, ref TextureBase blurredTexture)
	{
		PushMatrices();
		PushShader();
		Size controlSize = base.ControlData.ControlSize;
		Size size = sharpTexture.Size;
		base.ControlData.ControlSize = size;
		SetRenderTarget(blurredTexture);
		SetState(blendStateType.NoBlend);
		SetShader(shaderType.BlurHor);
		SetMatrices(Camera.myOrtho(this, 0.0, size.Width, 0.0, size.Height, -1.0, 1.0), null);
		SetViewport(new int[4] { 0, 0, size.Width, size.Height });
		float[] texCoords = new float[8] { 0f, 1f, 1f, 1f, 1f, 0f, 0f, 0f };
		DrawQuadWithTextures(sharpTexture, texCoords, 0, new System.Drawing.RectangleF(0f, 0f, size.Width, size.Height), 0f, buffered: false);
		CloseTexture(force: true);
		SetRenderTarget(sharpTexture);
		SetShader(shaderType.BlurVert);
		SetViewport(new int[4] { 0, 0, size.Width, size.Height });
		DrawQuadWithTextures(blurredTexture, texCoords, 0, new System.Drawing.RectangleF(0f, 0f, size.Width, size.Height), 0f, buffered: false);
		base.ControlData.ControlSize = controlSize;
		ResetRenderTarget();
		CloseTexture(force: true);
		PopMatrices();
		PopShader();
		TextureBase textureBase = sharpTexture;
		sharpTexture = blurredTexture;
		blurredTexture = textureBase;
	}

	protected override void InitBlurShader(float[] offset, float[] kernelValues, out IShaderTechnique blurHor, out IShaderTechnique blurVert)
	{
		_0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D _0023_003Dz7gYTKaY_003D = default(_0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D);
		_0023_003Dz7gYTKaY_003D._0023_003DzqruzrGTURUqK = new Vector4(kernelValues[0], kernelValues[1], kernelValues[2], kernelValues[3]);
		_0023_003Dz7gYTKaY_003D._0023_003DzkRoKTTHv_MiP = new Vector4(kernelValues[4], kernelValues[5], kernelValues[6], kernelValues[7]);
		_0023_003Dz7gYTKaY_003D._0023_003DzPnCHRkKwXV8a = new Vector4(kernelValues[8], kernelValues[9], kernelValues[10], kernelValues[11]);
		_0023_003Dz7gYTKaY_003D._0023_003DzJ9EaCWjk7ADm = new Vector4(kernelValues[12], kernelValues[13], kernelValues[14], kernelValues[15]);
		_0023_003Dz7gYTKaY_003D._0023_003Dzs2_RMl6fDuzx = new Vector4(kernelValues[16], kernelValues[17], kernelValues[18], 0f);
		_0023_003Dz7gYTKaY_003D._0023_003Dz_cdRbl2uVOP4 = new Vector4(offset[0], offset[1], offset[2], offset[3]);
		_0023_003Dz7gYTKaY_003D._0023_003DzyQZKaPoKBrNX = new Vector4(offset[4], offset[5], offset[6], offset[7]);
		_0023_003Dz7gYTKaY_003D._0023_003Dz7vZ5hyPd2Df1 = new Vector4(offset[8], offset[9], offset[10], offset[11]);
		_0023_003Dz7gYTKaY_003D._0023_003DzQkh3PjpSJOuB = new Vector4(offset[12], offset[13], offset[14], offset[15]);
		_0023_003Dz7gYTKaY_003D._0023_003DzGR21YREYAAiL = new Vector4(offset[16], offset[17], offset[18], 0f);
		_0023_003DzNT32oUkqGeGp._0023_003Dz7gYTKaY_003D = _0023_003Dz7gYTKaY_003D;
		blurHor = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605576), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		blurVert = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz14T0OTLSYRuhDE5IuIo60b4e212UTimw6A_003D_003D>(_0023_003DzTzFVZ_00240_003D, _0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605594), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
	}

	private void _0023_003DzUqI37rbYcrfo2retbk_EwpQ_003D(Size _0023_003DzM_Gy4Ls_003D)
	{
		ProgDrawCompositingBase?.ResizeTargets();
		ResizeCompositingObjects(_0023_003DzM_Gy4Ls_003D);
	}

	public override void DrawOnTextureOrBitmap(TextureBase texture, TextureBase depthTexture, BitmapData bitmapData, int strideInPixels, bool antialiasingAvailable, bool antiAliasing, int antialiasingSamples, int tileWidth, int tileHeight, drawSceneFuncDelegate drawSceneFunc, object drawSceneParams, bool hdwAcceleration, int bpp, bool buildMipmaps = false)
	{
		bool flag = false;
		if (texture == null)
		{
			texture = CreateTexture2D();
			SetTexture(texture);
			((Texture)texture).AllocateMemory(this, renderTarget: true, tileWidth, tileHeight, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, repeatS: false, repeatT: false, IntPtr.Zero, base.ControlData.isFsaaAvailable);
			flag = true;
		}
		_0023_003DzB_00241i16ya3eUx _0023_003DzMYTzTqg_003D = _0023_003Dz7XlCveSvJ5fF;
		SetRenderTarget(texture, depthTexture);
		bool flag2 = drawForBitmap;
		drawForBitmap = true;
		Size controlSize = base.ControlData.ControlSize;
		base.ControlData.ControlSize = new Size(tileWidth, tileHeight);
		_0023_003DzUqI37rbYcrfo2retbk_EwpQ_003D(base.ControlData.ControlSize);
		DrawScene(drawSceneFunc, drawSceneParams);
		drawForBitmap = flag2;
		_0023_003Dzi6v0V6E_003D(_0023_003DzMYTzTqg_003D);
		base.ControlData.ControlSize = controlSize;
		_0023_003DzUqI37rbYcrfo2retbk_EwpQ_003D(base.ControlData.ControlSize);
		if (buildMipmaps)
		{
			_0023_003DzP7fhLh8_003D.GenerateMips(((D3DTexture2D)texture)._0023_003DzV_0024hxxsU_0024ZCJW);
		}
		int[] array = (_0023_003DzlzeQWTRlPk6m() ? new int[3] { 0, 1, 2 } : new int[3] { 2, 1, 0 });
		if (bitmapData != null)
		{
			byte[] array2 = _0023_003Dz1K9wf5pSDf4i(new System.Drawing.Rectangle(0, 0, tileWidth, tileHeight), (Texture2D)((D3DTexture2D)texture)._0023_003Dz_IfKSJY_003D, _0023_003DzaNkZ4Os_003D: false);
			int num = tileWidth * bpp;
			int num2 = tileHeight - 1;
			byte[] array3 = new byte[num];
			int num3 = tileWidth * 4;
			if (bpp == 3)
			{
				for (int i = 0; i < tileHeight; i++)
				{
					int num4 = i * num3;
					int num5 = 0;
					while (num5 < num)
					{
						array3[num5++] = array2[num4 + array[0]];
						array3[num5++] = array2[num4 + array[1]];
						array3[num5++] = array2[num4 + array[2]];
						num4 += 4;
					}
					Marshal.Copy(array3, 0, bitmapData.Scan0 + bitmapData.Stride * (num2 - i), num);
				}
			}
			else
			{
				for (int j = 0; j < tileHeight; j++)
				{
					int num6 = j * num3;
					int num7 = 0;
					while (num7 < num)
					{
						array3[num7++] = array2[num6 + array[0]];
						array3[num7++] = array2[num6 + array[1]];
						array3[num7++] = array2[num6 + array[2]];
						array3[num7++] = array2[num6 + 3];
						num6 += 4;
					}
					Marshal.Copy(array3, 0, bitmapData.Scan0 + bitmapData.Stride * (num2 - j), num);
				}
			}
		}
		if (flag)
		{
			texture.Dispose();
		}
	}

	protected virtual void DrawScene(drawSceneFuncDelegate drawSceneFunc, object drawSceneParams)
	{
		drawSceneFunc(drawSceneParams);
	}

	public override void ResolveMultisampleTexture(TextureBase multiSampleTexture, TextureBase singleSampleTexture)
	{
		D3DTexture2D d3DTexture2D = (D3DTexture2D)multiSampleTexture;
		D3DTexture2D d3DTexture2D2 = (D3DTexture2D)singleSampleTexture;
		_0023_003DzP7fhLh8_003D.ResolveSubresource(d3DTexture2D._0023_003Dz_IfKSJY_003D, 0, d3DTexture2D2._0023_003Dz_IfKSJY_003D, 0, ((Texture2D)d3DTexture2D._0023_003Dz_IfKSJY_003D).Description.Format);
	}

	[CLSCompliant(false)]
	public override void SetLineStipple(int factor, ushort pattern, Camera camera)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzRVNtcj0ilKIsW3W5qA_003D_003D = factor;
		_0023_003Dz_BT7SDwEbLrP._0023_003DzdM7iTrCiMP954JENCg_003D_003D = pattern;
	}

	public override void EnableLineStipple(bool enable)
	{
		if (!enable)
		{
			EndDrawBufferedLines();
		}
		base.EnableLineStipple(enable);
		SetLinesShader(base.CurrentLineWidth > 1f, base.CurrentShader);
	}

	public override void SetEnvironment(IEnvironment environment, float intensity)
	{
		base.SetEnvironment(environment, intensity);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dzyz_0024bfF2zwT8WPfon7g_003D_003D = intensity;
	}

	public override void SetTextureOverExposure(bool textureOverExposure)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHtNbVaLv1tw6oApvlY6grW0_003D = (textureOverExposure ? 1 : 0);
	}

	public override void SetTextureLength(float textureLength)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzOnHva6wpqpFv = textureLength;
	}

	public override void SetTextureGrayscale(bool grayscale, float grayscaleAlpha)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzcLeF_4uietaA = (grayscale ? grayscaleAlpha : 1f);
	}

	public override void SetClippable(bool clippable)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzYRbzTAwIoBjDBgji_0024g_003D_003D = (clippable ? 1f : 0f);
	}

	protected override void UpdateShadersForShadow(Dictionary<shaderType, IShaderTechnique> shaders, ShaderParameters shaderParams)
	{
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzZNyBcAB5yV7hpeJ_8w_003D_003D = shaderParams.NumberOfSplits;
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzDlelRQHE9I5t = shaderParams.ShadowAmbientFactor;
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzqctDI1e5SJ_00246QRevoQ_003D_003D = new Vector4(0f, 0.5f, 0.5f, 0f);
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003Dzy3SXbagWg_F4Vm8sgQ_003D_003D = ((shaderParams.NumberOfSplits == 4) ? new Vector4(0.5f, 0.5f, 0f, 0f) : new Vector4(0f, 0f, 0f, 0f));
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzRg5NBWQCHAcK = new Vector2(shaderParams.ShadowTextureScale[0], shaderParams.ShadowTextureScale[1]);
		double[] splitPositions = shaderParams.RenderContext.frustumData.SplitPositions;
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzCKF3eIui6qW8llweCQ_003D_003D = new Vector4((float)(0.0 - splitPositions[0]), (float)(0.0 - splitPositions[1]), (float)(0.0 - splitPositions[2]), (float)(0.0 - splitPositions[3]));
		if (shaderParams.NumberOfSplits > 3)
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzgDYNVpo_0024_00240O0 = new SharpDX.Matrix(shaderParams.ShadowMapData.textureMatrix[3]);
		}
		if (shaderParams.NumberOfSplits > 2)
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzKdDMLY8BiGku = new SharpDX.Matrix(shaderParams.ShadowMapData.textureMatrix[2]);
		}
		if (shaderParams.NumberOfSplits > 1)
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzB0ZfnHgXH6ki = new SharpDX.Matrix(shaderParams.ShadowMapData.textureMatrix[1]);
		}
		if (shaderParams.NumberOfSplits > 0)
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzmPPAR95Y297N = new SharpDX.Matrix(shaderParams.ShadowMapData.textureMatrix[0]);
		}
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[shaderParams.LightWithShadow]._0023_003DzBjT3PLCBXnbL = 1f;
	}

	public override int GetNumberOfShadowMapSplits(realisticShadowQualityType shadowQuality, LightSettings[] lights)
	{
		if (_0023_003DzGIPo6pY0ShMi <= FeatureLevel.Level_9_3)
		{
			return 1;
		}
		return base.GetNumberOfShadowMapSplits(shadowQuality, lights);
	}

	public override System.Drawing.Color GetPixel(int x, int y)
	{
		int stride;
		int bpp;
		byte[] array = ReadColorBuffer(null, new System.Drawing.Rectangle(x, base.ControlData.ControlSize.Height - y, 1, 1), out stride, out bpp);
		return bpp switch
		{
			3 => System.Drawing.Color.FromArgb(array[0], array[1], array[2]), 
			4 => System.Drawing.Color.FromArgb(array[3], array[0], array[1], array[2]), 
			_ => System.Drawing.Color.Empty, 
		};
	}

	protected internal override EntityGraphicsData CreateEntityGraphicsData()
	{
		return new D3DEntityGraphicsData();
	}

	public override EntityGraphicsData CreateEntityGraphicsData(object parent)
	{
		return new D3DEntityGraphicsData(parent);
	}

	internal override EntityGraphicsData InitCompositingData()
	{
		EntityGraphicsData entityGraphicsData = CreateEntityGraphicsData();
		CompileVBO(entityGraphicsData, delegate(RenderContextBase _0023_003DzD6Th82s_003D, object _0023_003DzCBM7XJK4_5H_0024)
		{
			_0023_003DzD6Th82s_003D.DrawIndexedTriangles((VBOParams)_0023_003DzCBM7XJK4_5H_0024);
		}, new VBOParamsTexture
		{
			vertices = new float[12]
			{
				0f, 0f, 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f,
				0f, 0f
			},
			TextureCoordinates = new float[8] { 0f, 1f, 0f, 0f, 1f, 0f, 1f, 1f },
			indices = new int[6] { 0, 1, 2, 0, 2, 3 },
			primitiveMode = primitiveType.TriangleList
		});
		return entityGraphicsData;
	}

	public override int RegisterCustomShader(IShader customShader)
	{
		if (_0023_003Dzj88PH_0024h_Osj8().IsDesignMode())
		{
			return -1;
		}
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605611));
	}

	public override bool SetCustomShader(IShader customShader, ShaderParameters shaderParameters = null)
	{
		if (_0023_003Dzj88PH_0024h_Osj8().IsDesignMode())
		{
			return false;
		}
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605611));
	}

	public override bool RemoveCustomShader(IShader customShader)
	{
		if (_0023_003Dzj88PH_0024h_Osj8().IsDesignMode())
		{
			return false;
		}
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605611));
	}

	public override bool RemoveAllCustomShaders()
	{
		if (_0023_003Dzj88PH_0024h_Osj8().IsDesignMode())
		{
			return false;
		}
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605611));
	}
}
