using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using OpenGL;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept.Diagnostic;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Graphics;

public abstract class RenderContext : RenderContextBase
{
	public struct FIXED
	{
		public short fract;

		public short value;

		public double realNumber
		{
			get
			{
				double num = (double)value + (double)fract / 65536.0;
				if (fract < 0)
				{
					num += 1.0;
				}
				return num;
			}
		}
	}

	public struct GLYPHMETRICS
	{
		public int gmBlackBoxX;

		public int gmBlackBoxY;

		[MarshalAs(UnmanagedType.Struct)]
		public POINTFX gmptGlyphOrigin;

		public short gmCellIncX;

		public short gmCellIncY;
	}

	public struct MAT2
	{
		[MarshalAs(UnmanagedType.Struct)]
		public FIXED eM11;

		[MarshalAs(UnmanagedType.Struct)]
		public FIXED eM12;

		[MarshalAs(UnmanagedType.Struct)]
		public FIXED eM21;

		[MarshalAs(UnmanagedType.Struct)]
		public FIXED eM22;
	}

	public struct POINT
	{
		public int x;

		public int y;
	}

	public struct POINTFX
	{
		[MarshalAs(UnmanagedType.Struct)]
		public FIXED x;

		[MarshalAs(UnmanagedType.Struct)]
		public FIXED y;
	}

	public struct TTPOLYCURVEHEADER
	{
		public short wType;

		public short cpfx;
	}

	public struct TTPOLYGONHEADER
	{
		public int cb;

		public int dwType;

		[MarshalAs(UnmanagedType.Struct)]
		public POINTFX pfxStart;
	}

	public const int TA_NOUPDATECP = 0;

	public const int TA_UPDATECP = 1;

	public const int TA_LEFT = 0;

	public const int TA_RIGHT = 2;

	public const int TA_CENTER = 6;

	public const int TA_TOP = 0;

	public const int TA_BOTTOM = 8;

	public const int TA_BASELINE = 24;

	public const int TA_RTLREADING = 256;

	public const int TA_MASK = 287;

	public const int VTA_BASELINE = 24;

	public const int VTA_LEFT = 8;

	public const int VTA_RIGHT = 0;

	public const int VTA_CENTER = 6;

	public const int VTA_BOTTOM = 2;

	public const int VTA_TOP = 0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg _0023_003DzNT32oUkqGeGp = new _0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg(8);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Bitmap _0023_003DzQWJNsDWuroSY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Bitmap _0023_003DznzTxkQM_003D = new Bitmap(_0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzmsLRsIpQV5sG());

	public RenderContext(Size size, ControlData data, IWorkspace parentWorkspace)
		: base(size, data, parentWorkspace)
	{
	}

	protected internal override void GetTextOutlines(double chordalErr, Transformation transf, bool computeInners, bool toCurve, IWorkspace ws, Text textEntity, TextStyle textStyle, FontStyleData fsd, out ICurve[] outers, out ICurve[][] inners, Text.GetTextOutlinesDelegate getTextOutlines)
	{
		double scaleToUnitSize = fsd.ScaleToUnitSize;
		Font font = null;
		IntPtr bmp = IntPtr.Zero;
		IntPtr bmp2 = IntPtr.Zero;
		bool flag = textStyle.IsSHX();
		if (!flag)
		{
			font = new Font(textStyle.FontFamilyName, 2048f, (FontStyle)textStyle.Style, GraphicsUnit.Point);
			bmp = font.ToHfont();
			bmp2 = SelectObject(hdc, bmp);
		}
		bool isRightToLeft = ((IWorkspaceInternal)ws).IsRightToLeft();
		getTextOutlines(chordalErr, computeInners, toCurve, flag, fsd, transf, scaleToUnitSize, this, isRightToLeft, out outers, out inners);
		if (!flag)
		{
			SelectObject(hdc, bmp2);
			DeleteObject(bmp);
		}
		font?.Dispose();
	}

	protected internal override IList<Entity> GetCharMeshes(string s, string fontName, fontStyle style, double scaleToUnitSize, double chordalErr, bool isRightToLeft, out double width, out double descend, bool computeDataForFpc, out Point2D[][] fpcOuters, out Point2D[][][] fpcInners)
	{
		Font font = new Font(fontName, 2048f, (FontStyle)style, GraphicsUnit.Point);
		IntPtr bmp = font.ToHfont();
		IntPtr bmp2 = SelectObject(hdc, bmp);
		Size size;
		using (System.Drawing.Graphics dc = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
		{
			Size proposedSize = new Size(int.MaxValue, int.MaxValue);
			size = TextRenderer.MeasureText(dc, s, font, proposedSize, TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding);
		}
		GetCharOutlines(s, chordalErr, toCurve: false, isRightToLeft, out var outers, out var inners, out descend, scaleToUnitSize);
		List<Entity> list = new List<Entity>();
		for (int i = 0; i < outers.Length; i++)
		{
			if (outers[i].Length >= 4)
			{
				Utility.Triangulate(outers[i], inners[i], fixOrientation: false, checkValidity: false, out var vertices, out var triangles);
				Point3D[] array = new Point3D[vertices.Length];
				for (int j = 0; j < vertices.Length; j++)
				{
					array[j] = new Point3D(vertices[j].X, vertices[j].Y);
				}
				Mesh mesh = new Mesh(array, triangles);
				mesh.LightWeight = true;
				mesh.Regen(0.1);
				list.Add(mesh);
			}
		}
		fpcOuters = Array.Empty<Point2D[]>();
		fpcInners = Array.Empty<Point2D[][]>();
		if (computeDataForFpc)
		{
			GetCharOutlines(s, 0.0, toCurve: true, isRightToLeft, out fpcOuters, out fpcInners, out descend, scaleToUnitSize);
		}
		SelectObject(hdc, bmp2);
		DeleteObject(bmp);
		font.Dispose();
		width = (double)size.Width * scaleToUnitSize;
		return list;
	}

	[DllImport("gdi32.dll")]
	public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

	[DllImport("gdi32.dll")]
	public static extern IntPtr DeleteObject(IntPtr bmp);

	[DllImport("gdi32.dll", EntryPoint = "GetGlyphOutline")]
	internal static extern uint _0023_003DzRjRiiPUKulhQ(IntPtr _0023_003DzMUy2r_A_003D, uint _0023_003DzQ3G_0024FUs_003D, uint _0023_003DzHOIZ4SY_003D, out GLYPHMETRICS _0023_003DzhW_0024pCQbzBQbL, uint _0023_003DzL9WrRltX47G_, IntPtr _0023_003Dzc0f9jLF1F4rg, ref MAT2 _0023_003DzQEaWwNoUdoZL);

	[DllImport("gdi32.dll", EntryPoint = "GetGlyphIndicesW")]
	private static extern uint _0023_003DzSAoQKr_v9Yb_0024([In] IntPtr _0023_003DzMUy2r_A_003D, [In][MarshalAs(UnmanagedType.LPTStr)] string _0023_003Dz0M7vRJM_003D, int _0023_003Dzt2pW2yo_003D, [Out] ushort[] _0023_003DzXfoz4_w_003D, uint _0023_003DzD9KDXqY_003D);

	[DllImport("gdi32.dll", EntryPoint = "BeginPath")]
	internal static extern bool _0023_003DzObHNZIk_003D(IntPtr _0023_003DzMUy2r_A_003D);

	[DllImport("gdi32.dll", EntryPoint = "EndPath")]
	internal static extern bool _0023_003Dz9R_QbG0_003D(IntPtr _0023_003DzMUy2r_A_003D);

	[DllImport("gdi32.dll", EntryPoint = "FlattenPath")]
	internal static extern bool _0023_003DzGz5luAk_003D(IntPtr _0023_003DzMUy2r_A_003D);

	[DllImport("gdi32.dll", EntryPoint = "GetPath")]
	internal static extern int _0023_003DzFHffHcs_003D(IntPtr _0023_003DzMUy2r_A_003D, [Out] POINT[] _0023_003DzuBi7m_rdfF9x, [Out] byte[] _0023_003DzPDaYO2jTb3a1, int _0023_003DzfqzfqY0_003D);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "TextOut")]
	internal static extern bool _0023_003DzQy2dn_I_003D(IntPtr _0023_003DzMUy2r_A_003D, int _0023_003DzCTovjQQ_003D, int _0023_003DzQ5Vk5Io_003D, string _0023_003DzCih1KpQ_003D, int _0023_003DzVhA9kYQ_003D);

	[DllImport("gdi32.dll", EntryPoint = "SetTextAlign")]
	private static extern uint _0023_003Dz7aj_0024hS_XFAH8(IntPtr _0023_003DzMUy2r_A_003D, uint _0023_003DzLwfjSBo_003D);

	private static Point2D[][] _0023_003Dzj0CWBgwFyCIX4xyJAA_003D_003D(IntPtr _0023_003DzzVbSCUs_003D, string _0023_003DzgWGS4uo_003D, double _0023_003DzuzncrfRs8pp9, double _0023_003DzD14JsI2EZDbWYZ30AA_003D_003D, bool _0023_003Dz61oiirkEol0_0024, bool _0023_003DzFaPJpO8LsP_0024i, out double _0023_003DzSOBAsL8ad1Fl)
	{
		_0023_003DzObHNZIk_003D(_0023_003DzzVbSCUs_003D);
		if (_0023_003DzFaPJpO8LsP_0024i)
		{
			_0023_003Dz7aj_0024hS_XFAH8(_0023_003DzzVbSCUs_003D, 280u);
		}
		else
		{
			_0023_003Dz7aj_0024hS_XFAH8(_0023_003DzzVbSCUs_003D, 24u);
		}
		_0023_003DzQy2dn_I_003D(_0023_003DzzVbSCUs_003D, 0, 0, _0023_003DzgWGS4uo_003D, _0023_003DzgWGS4uo_003D.Length);
		_0023_003Dz9R_QbG0_003D(_0023_003DzzVbSCUs_003D);
		List<Point2D[]> list = new List<Point2D[]>();
		List<Point2D> _0023_003DztaZ_dqw_003D = null;
		POINT[] array = ((_0023_003DzD14JsI2EZDbWYZ30AA_003D_003D != 0.0 || _0023_003Dz61oiirkEol0_0024) ? _0023_003Dz4KEzmNYwXM2n(_0023_003DzzVbSCUs_003D, _0023_003DzuzncrfRs8pp9, list, _0023_003DzD14JsI2EZDbWYZ30AA_003D_003D, _0023_003DztaZ_dqw_003D, _0023_003Dz61oiirkEol0_0024) : _0023_003Dz_KITtsvI0L38(_0023_003DzzVbSCUs_003D, _0023_003DzuzncrfRs8pp9, list, ref _0023_003DztaZ_dqw_003D));
		if (_0023_003DztaZ_dqw_003D != null)
		{
			list.Add(_0023_003DztaZ_dqw_003D.ToArray());
		}
		if (array.Length > 3)
		{
			_0023_003DzSOBAsL8ad1Fl = (double)array[2].y * _0023_003DzuzncrfRs8pp9;
		}
		else
		{
			_0023_003DzSOBAsL8ad1Fl = 0.0;
		}
		return list.ToArray();
	}

	private static POINT[] _0023_003Dz4KEzmNYwXM2n(IntPtr _0023_003DzzVbSCUs_003D, double _0023_003DzuzncrfRs8pp9, List<Point2D[]> _0023_003DzacFINwJAMRZX, double _0023_003DzD14JsI2EZDbWYZ30AA_003D_003D, List<Point2D> _0023_003DztaZ_dqw_003D, bool _0023_003Dz61oiirkEol0_0024)
	{
		int num = _0023_003DzFHffHcs_003D(_0023_003DzzVbSCUs_003D, null, null, 0);
		if (num <= 0)
		{
			return new POINT[0];
		}
		POINT[] array = new POINT[num];
		byte[] array2 = new byte[num];
		_0023_003DzFHffHcs_003D(_0023_003DzzVbSCUs_003D, array, array2, num);
		if (num == 0)
		{
			return array;
		}
		if (num < 0)
		{
			string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613500);
			Exception ex = new Exception(new StackTrace().ToString());
			Logger.Instance.Error(message, ex);
			throw new EyeshotException(message, ex);
		}
		int num2 = 0;
		do
		{
			num2++;
		}
		while ((array2[num2] & 1) != 1);
		num2++;
		Point2D[] array3 = new Point2D[4];
		int num3 = 0;
		Point2D point2D = null;
		for (int i = num2; i < array.Length; i++)
		{
			byte b = array2[i];
			Point2D point2D2 = new Point2D((double)array[i].x * _0023_003DzuzncrfRs8pp9, (double)(-array[i].y) * _0023_003DzuzncrfRs8pp9);
			bool flag = false;
			if ((b & 6) == 6)
			{
				flag = true;
				if (_0023_003DztaZ_dqw_003D != null && _0023_003DztaZ_dqw_003D.Count > 0)
				{
					_0023_003DzacFINwJAMRZX.Add(_0023_003DztaZ_dqw_003D.ToArray());
				}
				point2D = point2D2;
				num3 = 0;
				_0023_003DztaZ_dqw_003D = new List<Point2D>();
			}
			if (!_0023_003Dz61oiirkEol0_0024 && !flag && (b & 4) == 4)
			{
				if (num3 == 0)
				{
					array3[num3++] = _0023_003DztaZ_dqw_003D[_0023_003DztaZ_dqw_003D.Count - 1];
				}
				array3[num3++] = point2D2;
				if (num3 == 4)
				{
					_0023_003DztaZ_dqw_003D.AddRange(_0023_003Dz__0024mAPoQoYuwO(_0023_003DzD14JsI2EZDbWYZ30AA_003D_003D, array3[0], array3[1], array3[2], array3[3]));
					num3 = 0;
				}
			}
			else if (_0023_003Dz61oiirkEol0_0024 && !flag && (b & 4) == 4)
			{
				if (num3 == 0)
				{
					array3[num3++] = _0023_003DztaZ_dqw_003D[_0023_003DztaZ_dqw_003D.Count - 1];
				}
				array3[num3++] = point2D2;
				if (num3 == 4)
				{
					Point2D[] array4 = array3;
					foreach (Point2D point2D3 in array4)
					{
						_0023_003DztaZ_dqw_003D.Add(new Point3D(point2D3.X, point2D3.Y, 1.0));
					}
					num3 = 0;
				}
			}
			else
			{
				_0023_003DztaZ_dqw_003D.Add(point2D2);
			}
			if ((b & 1) == 1)
			{
				_0023_003DztaZ_dqw_003D.Add((Point2D)point2D.Clone());
				if (Point2D.DistanceSquared(point2D2, point2D) > _0023_003DzD14JsI2EZDbWYZ30AA_003D_003D * _0023_003DzD14JsI2EZDbWYZ30AA_003D_003D)
				{
					_0023_003DztaZ_dqw_003D.Add((Point2D)point2D.Clone());
				}
			}
		}
		if (_0023_003DztaZ_dqw_003D != null && _0023_003DztaZ_dqw_003D.Count > 0)
		{
			_0023_003DzacFINwJAMRZX.Add(_0023_003DztaZ_dqw_003D.ToArray());
		}
		return array;
	}

	internal static List<Point2D> _0023_003Dz__0024mAPoQoYuwO(double _0023_003DzD14JsI2EZDbWYZ30AA_003D_003D, Point2D _0023_003DzA8LasaY_003D, Point2D _0023_003DzouXiP80_003D, Point2D _0023_003DzkIbQUQc_003D, Point2D _0023_003Dz_sf6JCo_003D)
	{
		return _0023_003DzgbPfeyPl_XSQ(_0023_003DzA8LasaY_003D, _0023_003DzouXiP80_003D, _0023_003DzkIbQUQc_003D, _0023_003Dz_sf6JCo_003D, _0023_003DzD14JsI2EZDbWYZ30AA_003D_003D);
	}

	private static List<Point2D> _0023_003DzgbPfeyPl_XSQ(Point2D _0023_003DzA8LasaY_003D, Point2D _0023_003DzouXiP80_003D, Point2D _0023_003DzkIbQUQc_003D, Point2D _0023_003Dz_sf6JCo_003D, double _0023_003DzLm6Fg6o_003D)
	{
		List<Point2D> list = new List<Point2D>();
		list.Add(_0023_003DzA8LasaY_003D);
		list.AddRange(_0023_003DzYPXSPnatRJ_0024t(_0023_003DzA8LasaY_003D, _0023_003DzouXiP80_003D, _0023_003DzkIbQUQc_003D, _0023_003Dz_sf6JCo_003D, _0023_003DzLm6Fg6o_003D, 0.0, 1.0, _0023_003DzA8LasaY_003D, _0023_003Dz_sf6JCo_003D));
		list.Add(_0023_003Dz_sf6JCo_003D);
		return list;
	}

	private static IList<Point2D> _0023_003DzYPXSPnatRJ_0024t(Point2D _0023_003DzA8LasaY_003D, Point2D _0023_003DzouXiP80_003D, Point2D _0023_003DzkIbQUQc_003D, Point2D _0023_003Dz_sf6JCo_003D, double _0023_003DzLm6Fg6o_003D, double _0023_003DzR7PHkYc_003D, double _0023_003DzyA9uYGo_003D, Point2D _0023_003DzHVFO3JYAQ7M6, Point2D _0023_003Dzmbo3zAVS8_jP)
	{
		if (_0023_003DzLm6Fg6o_003D == 0.0)
		{
			return new List<Point2D>();
		}
		IList<Point2D> list = new List<Point2D>();
		IList<Point2D> list2 = new List<Point2D>();
		double num = (_0023_003DzR7PHkYc_003D + _0023_003DzyA9uYGo_003D) / 2.0;
		Point2D point2D = _0023_003DzE30GmEKogq6eQ7oBaQ_003D_003D(_0023_003DzA8LasaY_003D, _0023_003DzouXiP80_003D, _0023_003DzkIbQUQc_003D, _0023_003Dz_sf6JCo_003D, num);
		Point2D b = Point2D.MidPoint(_0023_003DzHVFO3JYAQ7M6, _0023_003Dzmbo3zAVS8_jP);
		List<Point2D> list3 = new List<Point2D>();
		if (Point2D.Distance(point2D, b) > _0023_003DzLm6Fg6o_003D)
		{
			list = _0023_003DzYPXSPnatRJ_0024t(_0023_003DzA8LasaY_003D, _0023_003DzouXiP80_003D, _0023_003DzkIbQUQc_003D, _0023_003Dz_sf6JCo_003D, _0023_003DzLm6Fg6o_003D, _0023_003DzR7PHkYc_003D, num, _0023_003DzHVFO3JYAQ7M6, point2D);
			list2 = _0023_003DzYPXSPnatRJ_0024t(_0023_003DzA8LasaY_003D, _0023_003DzouXiP80_003D, _0023_003DzkIbQUQc_003D, _0023_003Dz_sf6JCo_003D, _0023_003DzLm6Fg6o_003D, num, _0023_003DzyA9uYGo_003D, point2D, _0023_003Dzmbo3zAVS8_jP);
			list3.AddRange(list);
			list3.Add(point2D);
			list3.AddRange(list2);
		}
		return list3;
	}

	private static Point2D _0023_003DzE30GmEKogq6eQ7oBaQ_003D_003D(Point2D _0023_003Dz6It9KyA_003D, Point2D _0023_003Dz5PxKZP0_003D, Point2D _0023_003Dzt2pW2yo_003D, Point2D _0023_003Dz0yDzO_0024c_003D, double _0023_003Dz7mKSiLg_003D)
	{
		double num = 1.0 - _0023_003Dz7mKSiLg_003D;
		double num2 = num * num;
		double num3 = num2 * num;
		double num4 = _0023_003Dz7mKSiLg_003D * _0023_003Dz7mKSiLg_003D;
		double num5 = num4 * _0023_003Dz7mKSiLg_003D;
		double x = num3 * _0023_003Dz6It9KyA_003D.X + 3.0 * num2 * _0023_003Dz7mKSiLg_003D * _0023_003Dz5PxKZP0_003D.X + 3.0 * num * num4 * _0023_003Dzt2pW2yo_003D.X + num5 * _0023_003Dz0yDzO_0024c_003D.X;
		double y = num3 * _0023_003Dz6It9KyA_003D.Y + 3.0 * num2 * _0023_003Dz7mKSiLg_003D * _0023_003Dz5PxKZP0_003D.Y + 3.0 * num * num4 * _0023_003Dzt2pW2yo_003D.Y + num5 * _0023_003Dz0yDzO_0024c_003D.Y;
		return new Point2D(x, y);
	}

	private static POINT[] _0023_003Dz_KITtsvI0L38(IntPtr _0023_003DzzVbSCUs_003D, double _0023_003DzuzncrfRs8pp9, List<Point2D[]> _0023_003DzacFINwJAMRZX, ref List<Point2D> _0023_003DztaZ_dqw_003D)
	{
		_0023_003DzGz5luAk_003D(_0023_003DzzVbSCUs_003D);
		int num = _0023_003DzFHffHcs_003D(_0023_003DzzVbSCUs_003D, null, null, 0);
		if (num == 0)
		{
			return new POINT[0];
		}
		if (num < 0)
		{
			string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613500);
			Exception ex = new Exception(new StackTrace().ToString());
			Logger.Instance.Error(message, ex);
			throw new EyeshotException(message, ex);
		}
		POINT[] array = new POINT[num];
		byte[] array2 = new byte[num];
		_0023_003DzFHffHcs_003D(_0023_003DzzVbSCUs_003D, array, array2, num);
		if (num == 0)
		{
			return array;
		}
		int num2 = 0;
		do
		{
			num2++;
		}
		while ((array2[num2] & 1) != 1);
		num2++;
		for (int i = num2; i < array.Length; i++)
		{
			byte num3 = array2[i];
			Point2D item = new Point2D((double)array[i].x * _0023_003DzuzncrfRs8pp9, (double)(-array[i].y) * _0023_003DzuzncrfRs8pp9);
			if ((num3 & 6) == 6)
			{
				if (_0023_003DztaZ_dqw_003D != null)
				{
					_0023_003DzacFINwJAMRZX.Add(_0023_003DztaZ_dqw_003D.ToArray());
				}
				_0023_003DztaZ_dqw_003D = new List<Point2D>();
			}
			_0023_003DztaZ_dqw_003D.Add(item);
			if ((num3 & 1) == 1)
			{
				_0023_003DztaZ_dqw_003D.Add((Point2D)_0023_003DztaZ_dqw_003D[0].Clone());
			}
		}
		return array;
	}

	protected internal override double GetQScaleFactor(string fontName, fontStyle style)
	{
		return _0023_003Dz_0024CP_0024fAAqctOo(hdc, fontName, style);
	}

	internal static double _0023_003Dz_0024CP_0024fAAqctOo(IntPtr _0023_003DzzVbSCUs_003D, string _0023_003Dza_hu_V0_003D, fontStyle _0023_003DzqheO7Oc_003D)
	{
		Font font = new Font(_0023_003Dza_hu_V0_003D, 2048f, (FontStyle)_0023_003DzqheO7Oc_003D, GraphicsUnit.Point);
		try
		{
			IntPtr bmp = font.ToHfont();
			IntPtr bmp2 = SelectObject(_0023_003DzzVbSCUs_003D, bmp);
			_0023_003DzObHNZIk_003D(_0023_003DzzVbSCUs_003D);
			_0023_003Dz7aj_0024hS_XFAH8(_0023_003DzzVbSCUs_003D, 24u);
			_0023_003DzQy2dn_I_003D(_0023_003DzzVbSCUs_003D, 0, 0, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612763), 1);
			_0023_003Dz9R_QbG0_003D(_0023_003DzzVbSCUs_003D);
			_0023_003DzGz5luAk_003D(_0023_003DzzVbSCUs_003D);
			int num = _0023_003DzFHffHcs_003D(_0023_003DzzVbSCUs_003D, null, null, 0);
			if (num < 0)
			{
				string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613500);
				Exception ex = new Exception(new StackTrace().ToString());
				Logger.Instance.Error(message, ex);
				throw new EyeshotException(message, ex);
			}
			POINT[] array = new POINT[num];
			byte[] array2 = new byte[num];
			_0023_003DzFHffHcs_003D(_0023_003DzzVbSCUs_003D, array, array2, num);
			if (num == 0)
			{
				return 0.0;
			}
			SelectObject(_0023_003DzzVbSCUs_003D, bmp2);
			DeleteObject(bmp);
			int num2 = 0;
			do
			{
				num2++;
			}
			while ((array2[num2] & 1) != 1);
			num2++;
			double num3 = double.MaxValue;
			for (int i = num2; i < array.Length; i++)
			{
				if ((double)array[i].y < num3)
				{
					num3 = array[i].y;
				}
			}
			return -1.0 / num3;
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
	}

	protected internal override void GetCharOutlines(string s, double chordalErr, bool toCurve, bool isRightToLeft, out Point2D[][] loops, out double Descend, double fontScale)
	{
		_0023_003DzRrN0c_hLnkUS0VJsjw_003D_003D(s, hdc, chordalErr, toCurve, isRightToLeft, out loops, out Descend, fontScale);
	}

	protected internal override void GetCharOutlines(string s, double chordalErr, bool toCurve, bool isRightToLeft, out Point2D[][] outers, out Point2D[][][] inners, out double Descend, double fontScale)
	{
		_0023_003DzRrN0c_hLnkUS0VJsjw_003D_003D(s, hdc, chordalErr, toCurve, isRightToLeft, out outers, out inners, out Descend, fontScale);
	}

	internal static void _0023_003DzRrN0c_hLnkUS0VJsjw_003D_003D(string _0023_003Dz7dLpRsk_003D, IntPtr _0023_003DzzVbSCUs_003D, double _0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D, bool _0023_003Dz61oiirkEol0_0024, bool _0023_003DzFaPJpO8LsP_0024i, out Point2D[][] _0023_003Dz9mP3GfVi8Gkv, out double _0023_003DzSOBAsL8ad1Fl, double _0023_003DzuzncrfRs8pp9)
	{
		Point2D[][] array = _0023_003Dzj0CWBgwFyCIX4xyJAA_003D_003D(_0023_003DzzVbSCUs_003D, _0023_003Dz7dLpRsk_003D, _0023_003DzuzncrfRs8pp9, _0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D, _0023_003Dz61oiirkEol0_0024, _0023_003DzFaPJpO8LsP_0024i, out _0023_003DzSOBAsL8ad1Fl);
		if (_0023_003Dz61oiirkEol0_0024)
		{
			_0023_003Dz9mP3GfVi8Gkv = array;
			return;
		}
		_0023_003Dz9mP3GfVi8Gkv = new Point2D[array.Length][];
		for (int i = 0; i < _0023_003Dz9mP3GfVi8Gkv.Length; i++)
		{
			_0023_003Dz9mP3GfVi8Gkv[i] = Utility.RemoveDuplicates(array[i]);
		}
	}

	internal static void _0023_003DzRrN0c_hLnkUS0VJsjw_003D_003D(string _0023_003Dz7dLpRsk_003D, IntPtr _0023_003DzzVbSCUs_003D, double _0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D, bool _0023_003Dz61oiirkEol0_0024, bool _0023_003DzFaPJpO8LsP_0024i, out Point2D[][] _0023_003Dzf0NImE_xvj8u, out Point2D[][][] _0023_003DzyGaR_8tOPKPu, out double _0023_003DzSOBAsL8ad1Fl, double _0023_003DzuzncrfRs8pp9)
	{
		_0023_003DzRrN0c_hLnkUS0VJsjw_003D_003D(_0023_003Dz7dLpRsk_003D, _0023_003DzzVbSCUs_003D, _0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D, _0023_003Dz61oiirkEol0_0024, _0023_003DzFaPJpO8LsP_0024i, out var _0023_003Dz9mP3GfVi8Gkv, out _0023_003DzSOBAsL8ad1Fl, _0023_003DzuzncrfRs8pp9);
		Utility.FindLoops(_0023_003Dz9mP3GfVi8Gkv, out _0023_003Dzf0NImE_xvj8u, out _0023_003DzyGaR_8tOPKPu);
		int num = _0023_003Dzf0NImE_xvj8u.Length;
		for (int i = 0; i < num; i++)
		{
			if (Utility.IsOrientedClockwise(_0023_003Dzf0NImE_xvj8u[i]))
			{
				Array.Reverse(_0023_003Dzf0NImE_xvj8u[i]);
			}
			if (_0023_003DzyGaR_8tOPKPu[i] == null)
			{
				continue;
			}
			for (int j = 0; j < _0023_003DzyGaR_8tOPKPu[i].Length; j++)
			{
				if (!Utility.IsOrientedClockwise(_0023_003DzyGaR_8tOPKPu[i][j]))
				{
					Array.Reverse(_0023_003DzyGaR_8tOPKPu[i][j]);
				}
			}
		}
	}

	protected internal override string GetDefaultFontFamilyName()
	{
		return SystemFonts.DefaultFont.FontFamily.Name;
	}

	public override void ProcessClippingPlanesVisibility(ClippingPlaneBase[] clippingPlanes, bool updateGraphics = false)
	{
		for (int i = 0; i < clippingPlanes.Length; i++)
		{
			FlagsHelper.SetUnset(ref _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C, (ClipPlanesFlags)(1 << i), clippingPlanes[i].Active);
		}
	}

	internal IWorkspace _0023_003Dzj88PH_0024h_Osj8()
	{
		return base.ParentWorkspace;
	}

	public override void Dispose()
	{
		base.Dispose();
		_0023_003DznzTxkQM_003D.Dispose();
		_0023_003DznzTxkQM_003D = null;
		DisposeBorderTextures();
	}

	protected internal abstract void DisposeBorderTextures();

	protected override void FreeCaptureTextures()
	{
		base.FreeCaptureTextures();
		if (_0023_003DzQWJNsDWuroSY != null)
		{
			_0023_003DzQWJNsDWuroSY.Dispose();
			_0023_003DzQWJNsDWuroSY = null;
		}
	}

	public override bool Create()
	{
		wnd = base.ControlData.controlHandle;
		if (hdc == IntPtr.Zero)
		{
			hdc = OpenGL.Windows.GetDC(wnd);
		}
		Logger.Instance.Info(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612755), hdc));
		return hdc != IntPtr.Zero;
	}

	internal abstract void _0023_003DzLADmvpnYILj0(int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, float _0023_003DzNsXhzVoM2zWs, float _0023_003DztKWOcOeEKDUk);

	public override TextureBase CreateTexture2D(System.Drawing.Color[] colors)
	{
		return CreateTexture2D(Texture.BitmapFromColors(colors));
	}

	public override TextureBase CreateTexture2D(byte[] image, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool enlargeIfSizeNotSupported = false, bool repeatX = true, bool repeatY = true)
	{
		using Bitmap image2 = UtilityEx.ConvertBytesToImage(image);
		return CreateTexture2D(image2, minFunc, magFunc, anisotropicFiltering, enlargeIfSizeNotSupported, repeatX, repeatY);
	}

	public override TextureBase CreateTexture2D(IDisposable image, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool enlargeIfSizeNotSupported = false, bool repeatX = true, bool repeatY = true)
	{
		return CreateTexture2D((Image)image, minFunc, magFunc, anisotropicFiltering, enlargeIfSizeNotSupported, repeatX, repeatY);
	}

	public abstract TextureBase CreateTexture2D(Image image, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool enlargeIfSizeNotSupported = false, bool repeatX = true, bool repeatY = true);

	public override void ReadSurface(Size controlSize, bool backBuffer, bool antialiasing)
	{
		SetShader(shaderType.Standard);
		if (antialiasing && !base.IsDirect3D)
		{
			if (_0023_003DzQWJNsDWuroSY == null)
			{
				return;
			}
		}
		else if (texturesForCapture == null)
		{
			return;
		}
		SetViewport(new int[4] { 0, 0, controlSize.Width, controlSize.Height });
		SetMatrices(Camera.myOrtho(this, 0.0, controlSize.Width, 0.0, controlSize.Height, -1.0, 1.0), RenderContextBase.IdentityMatrixDouble);
	}

	public abstract Bitmap GetBitmapFromTexture(TextureBase texture);

	private static uint _0023_003DzBpDwLw21eS3GlEodWQ_003D_003D(uint _0023_003DzGuW5l4E_003D, uint _0023_003DzVDBzBJQ_003D)
	{
		uint num = 64u;
		uint num2 = 0u;
		for (uint num3 = num / 2; num3 != 0; num3 /= 2)
		{
			uint num4 = (((_0023_003DzGuW5l4E_003D & num3) != 0) ? 1u : 0u);
			uint num5 = (((_0023_003DzVDBzBJQ_003D & num3) != 0) ? 1u : 0u);
			num2 += num3 * num3 * ((3 * num4) ^ num5);
			if (num5 == 0)
			{
				if (num4 == 1)
				{
					_0023_003DzGuW5l4E_003D = num - 1 - _0023_003DzGuW5l4E_003D;
					_0023_003DzVDBzBJQ_003D = num - 1 - _0023_003DzVDBzBJQ_003D;
				}
				uint num6 = _0023_003DzVDBzBJQ_003D;
				_0023_003DzVDBzBJQ_003D = _0023_003DzGuW5l4E_003D;
				_0023_003DzGuW5l4E_003D = num6;
			}
		}
		return num2;
	}

	protected override bool CreateHilbertLut()
	{
		int num = 64;
		int num2 = 64;
		ushort[] array = new ushort[num * num2];
		for (uint num3 = 0u; num3 < num; num3++)
		{
			for (uint num4 = 0u; num4 < num2; num4++)
			{
				uint num5 = _0023_003DzBpDwLw21eS3GlEodWQ_003D_003D(num3, num4);
				array[num3 + num * num4] = (ushort)num5;
			}
		}
		bool flag = true;
		Bitmap bitmap = new Bitmap(num, num2, PixelFormat.Format16bppGrayScale);
		try
		{
			BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, 64, 64), ImageLockMode.WriteOnly, PixelFormat.Format16bppGrayScale);
			byte[] array2 = new byte[num * num2 * 2];
			System.Buffer.BlockCopy(array, 0, array2, 0, num * num2 * 2);
			Marshal.Copy(array2, 0, bitmapData.Scan0, array2.Length);
			bitmap.UnlockBits(bitmapData);
			return flag & CreateHilbertLut(bitmap);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	protected internal abstract bool CreateHilbertLut(Bitmap noiseBmp);

	public abstract void DrawPixels(TextureBase texture, Bitmap bmp, Point2D rasterPos, Size destSize, bool flipY);

	public override void BeginReadDepthValues(Size size, out int strideInPixels)
	{
		Bitmap _0023_003Dza0pUM94_003D = null;
		_0023_003DzYDHFZIvmSA1e(size, ref _0023_003Dza0pUM94_003D, out strideInPixels);
	}

	internal virtual void _0023_003DzYDHFZIvmSA1e(Size _0023_003Dz0ERMHbg_003D, ref Bitmap _0023_003Dza0pUM94_003D, out int _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D)
	{
		_0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D = _0023_003Dz0ERMHbg_003D.Width;
	}

	internal static Bitmap _0023_003Dzn6L6n02G6rY2(Size _0023_003Dz0ERMHbg_003D, byte[] _0023_003DzpZy6QX0_003D)
	{
		Bitmap bitmap = new Bitmap(_0023_003Dz0ERMHbg_003D.Width, _0023_003Dz0ERMHbg_003D.Height, PixelFormat.Format24bppRgb);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		while (num3 < _0023_003DzpZy6QX0_003D.Length)
		{
			byte red = _0023_003DzpZy6QX0_003D[num3++];
			byte green = _0023_003DzpZy6QX0_003D[num3++];
			byte blue = _0023_003DzpZy6QX0_003D[num3++];
			byte alpha = _0023_003DzpZy6QX0_003D[num3++];
			bitmap.SetPixel(num2, num, System.Drawing.Color.FromArgb(alpha, red, green, blue));
			num2++;
			if (num2 == bitmap.Width)
			{
				num++;
				num2 = 0;
			}
		}
		return bitmap;
	}

	public override void SetLightStatus(int lightIndex, bool active)
	{
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzCCBca0k_003D(active, null, null, null);
	}

	private int _0023_003DzgwlIgijBU1dU(lightType _0023_003DzmuAvDts_003D)
	{
		return _0023_003DzmuAvDts_003D switch
		{
			lightType.Directional => 0, 
			lightType.Point => 1, 
			_ => 2, 
		};
	}

	public override void SetLightAttributes(int lightIndex, float[] diffuse, float[] ambient, float[] specular, LightSettings light)
	{
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003Dz4r_0024mn64_003D = _0023_003DzgwlIgijBU1dU(light.Type);
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzCCBca0k_003D(light.Active, diffuse, ambient, specular);
		if (light.Type != lightType.Directional)
		{
			_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003Dzs91I1MdqldH0pe8iOA_003D_003D = new Vector3((float)light.ConstantAttenuation, (float)light.LinearAttenuation, (float)light.QuadraticAttenuation);
			_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzObmXzlJIFTmL = (float)light.SpotExponent;
			_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzGhupw8QIiPQeTSq64g_003D_003D = (float)Math.Cos(light.SpotHalfAngle);
		}
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzBjT3PLCBXnbL = 0f;
	}

	public override void DisableClipPlanes()
	{
		foreach (KeyValuePair<shaderType, IShaderTechnique> shader in Shaders)
		{
			shader.Value.UpdatedInFrame = false;
		}
		_0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C = ClipPlanesFlags.Zero;
	}

	public override void ResizeSurfacesForCapture(Size size, bool antialiasing)
	{
		if (antialiasing)
		{
			if (_0023_003DzQWJNsDWuroSY == null || _0023_003DzQWJNsDWuroSY.Width != size.Width || _0023_003DzQWJNsDWuroSY.Height != size.Height)
			{
				if (_0023_003DzQWJNsDWuroSY == null)
				{
					_0023_003DzQWJNsDWuroSY = new Bitmap(size.Width, size.Height);
				}
				else if (size != _0023_003DzQWJNsDWuroSY.Size)
				{
					_0023_003DzQWJNsDWuroSY.Dispose();
					_0023_003DzQWJNsDWuroSY = new Bitmap(size.Width, size.Height);
				}
			}
			return;
		}
		int num = Math.Max(size.Width, size.Height);
		int num2 = (int)Math.Pow(2.0, Math.Ceiling(Math.Log((double)num / 3.0, 2.0)));
		if (num2 != texSize.Width || texturesForCapture == null)
		{
			texSize = new Size(num2, num2);
			if (texSize.Width > MaxTextureSize())
			{
				texSize = new Size(MaxTextureSize(), MaxTextureSize());
			}
			InitTexturesForCapture();
		}
	}

	public override void PaintBackBuffer(Size controlSize, Camera camera, bool antiAliasing)
	{
		SetViewport(new int[4] { 0, 0, controlSize.Width, controlSize.Height });
		SetShader(shaderType.Texture2DNoLights);
		SetMatrices(Camera.myOrtho(this, 0.0, controlSize.Width, 0.0, controlSize.Height, -1.0, 1.0), null);
		SetState(depthStencilStateType.DepthTestOff);
		if (antiAliasing && !base.IsDirect3D)
		{
			DrawPixels(null, _0023_003DzQWJNsDWuroSY, new Point2D(0.0, 0.0), _0023_003DzQWJNsDWuroSY.Size, flipY: false);
		}
		else
		{
			SetLighting(enable: false);
			SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			PaintBackBuffer(controlSize.Height);
			texturesForCapture[0].Unbind();
			CloseTexture();
		}
		SetState(depthStencilStateType.DepthTestLess);
	}

	public abstract void DrawOnTextureOrBitmap(TextureBase texture, TextureBase depthTexture, BitmapData bitmapData, int strideInPixels, bool antialiasingAvailable, bool antiAliasing, int antialiasingSamples, int tileWidth, int tileHeight, drawSceneFuncDelegate drawSceneFunc, object drawSceneParams, bool hdwAcceleration, int bpp, bool buildMipmaps = false);

	public override void CompileBackground(IBackgroundSettings iBackgroundSettings, int height)
	{
		BackgroundSettings backgroundSettings = (BackgroundSettings)iBackgroundSettings;
		switch (backgroundSettings.StyleMode)
		{
		case backgroundStyleType.Image:
			backgroundSettings._0023_003DzG7_0024fT88_0024REjz(CreateTexture2D(backgroundSettings.Image));
			break;
		case backgroundStyleType.CubicGradient:
			backgroundSettings.texture1DLength = height;
			TextureBase.MakePowerOfTwoBigger(this, ref backgroundSettings.texture1DLength);
			if (backgroundSettings.texture1DLength > 0)
			{
				System.Drawing.Color[] array = new System.Drawing.Color[backgroundSettings.texture1DLength];
				int num = (int)((double)backgroundSettings.texture1DLength * backgroundSettings.IntermediateColorPosition);
				for (int i = 0; i < num; i++)
				{
					array[i] = _0023_003DztxdOewwb5dbF(backgroundSettings.TopColor, backgroundSettings.IntermediateColor, (double)i / (double)num);
				}
				double num2 = backgroundSettings.texture1DLength - num;
				for (int j = num; j < backgroundSettings.texture1DLength; j++)
				{
					array[j] = _0023_003DztxdOewwb5dbF(backgroundSettings.IntermediateColor, backgroundSettings.BottomColor, (double)(j - num) / num2);
				}
				backgroundSettings._0023_003DzG7_0024fT88_0024REjz(CreateTexture2D(array));
			}
			break;
		}
	}

	private System.Drawing.Color _0023_003DztxdOewwb5dbF(System.Drawing.Color _0023_003DzriHDpk0_003D, System.Drawing.Color _0023_003DztMA38ag_003D, double _0023_003Dz7mKSiLg_003D)
	{
		Point2D p = new Point2D(0.0, 0.0);
		Vector2D m = new Vector2D(1.0, 0.0);
		Point2D p2 = new Point2D(1.0, 1.0);
		Vector2D m2 = new Vector2D(1.0, 0.0);
		Point2D point2D = Utility.HermiteSpline(p, m, p2, m2, _0023_003Dz7mKSiLg_003D);
		return System.Drawing.Color.FromArgb(_0023_003DzHWU3pE4_003D(_0023_003DzriHDpk0_003D.R, _0023_003DztMA38ag_003D.R, point2D.Y), _0023_003DzHWU3pE4_003D(_0023_003DzriHDpk0_003D.G, _0023_003DztMA38ag_003D.G, point2D.Y), _0023_003DzHWU3pE4_003D(_0023_003DzriHDpk0_003D.B, _0023_003DztMA38ag_003D.B, point2D.Y));
	}

	internal static int _0023_003DzHWU3pE4_003D(int _0023_003DzriHDpk0_003D, int _0023_003DztMA38ag_003D, double _0023_003DzJU0R6e0_003D)
	{
		return (int)((double)_0023_003DzriHDpk0_003D + (double)(_0023_003DztMA38ag_003D - _0023_003DzriHDpk0_003D) * _0023_003DzJU0R6e0_003D);
	}

	public override IEnvironment CompileEnvironment(object img)
	{
		Image image = (Image)img;
		if (base.CurrentEnvironmentMap != null)
		{
			base.CurrentEnvironmentMap.Dispose();
		}
		base.CurrentEnvironmentMap = CreateEnvironment(image ?? _0023_003DznzTxkQM_003D);
		((TextureBase)base.CurrentEnvironmentMap).Load(this, textureFilteringFunctionType.Linear);
		return base.CurrentEnvironmentMap;
	}

	protected internal abstract IEnvironment CreateEnvironment(Image image);

	public override int[] GetEntityIndicesFromBmp(System.Drawing.Rectangle selectionBox, bool firstOnly, byte[] rgbValues, int bpp, int stride)
	{
		List<int> list = new List<int>();
		int num = stride - selectionBox.Width * bpp;
		int num2 = ((!base.IsDirect3D) ? (rgbValues.Length - selectionBox.Bottom * stride + selectionBox.Left * bpp) : (selectionBox.Top * stride + selectionBox.Left * bpp));
		int num3 = 0;
		int num4 = 2;
		if (firstOnly && selectionBox.Width == selectionBox.Height)
		{
			int width = selectionBox.Width;
			int height = selectionBox.Height;
			int num5 = width / 2;
			int num6 = height / 2;
			int num7 = num6 + 1;
			int num8 = num5 + 1;
			int num9 = num6 - 1;
			int num10 = num5 - 1;
			int num11 = -1;
			int num12 = 0;
			if (ColorsBits16)
			{
				for (int i = 0; i < width * height; i++)
				{
					int num13 = num2 + num5 * bpp + num6 * (num + width * bpp);
					byte color = rgbValues[num13 + num3];
					byte color2 = rgbValues[num13 + 1];
					byte color3 = rgbValues[num13 + num4];
					int redBlue16BitId = GetRedBlue16BitId(color);
					int redBlue16BitId2 = GetRedBlue16BitId(color3);
					int green16BitId = GetGreen16BitId(color2);
					if (redBlue16BitId2 >= 0 && green16BitId >= 0 && redBlue16BitId >= 0)
					{
						int num14 = (redBlue16BitId2 << RedShift) + (green16BitId << GreenShift) + (redBlue16BitId << BlueShift);
						if (num14 != MaxColorVal)
						{
							return new int[1] { num14 };
						}
						bool flag;
						num9 -= ((flag = num9 >= num6) ? 1 : 0);
						bool flag2;
						num10 -= ((flag2 = num10 >= num5) ? 1 : 0);
						bool flag3;
						num7 += ((flag3 = num7 <= num6) ? 1 : 0);
						bool flag4;
						num8 += ((flag4 = num8 <= num5) ? 1 : 0);
						if (flag || flag2 || flag3 || flag4)
						{
							int num15 = num12;
							num12 = num11;
							num11 = -num15;
						}
						num5 += num12;
						num6 += num11;
					}
				}
			}
			else
			{
				for (int j = 0; j < width * height; j++)
				{
					int num16 = num2 + num5 * bpp + num6 * (num + width * bpp);
					byte num17 = rgbValues[num16 + num3];
					byte b = rgbValues[num16 + 1];
					byte b2 = rgbValues[num16 + num4];
					int num18 = (num17 << BlueShift) + (b << GreenShift) + (b2 << RedShift);
					if (num18 != MaxColorVal)
					{
						return new int[1] { num18 };
					}
					bool flag;
					num9 -= ((flag = num9 >= num6) ? 1 : 0);
					bool flag2;
					num10 -= ((flag2 = num10 >= num5) ? 1 : 0);
					bool flag3;
					num7 += ((flag3 = num7 <= num6) ? 1 : 0);
					bool flag4;
					num8 += ((flag4 = num8 <= num5) ? 1 : 0);
					if (flag || flag2 || flag3 || flag4)
					{
						int num19 = num12;
						num12 = num11;
						num11 = -num19;
					}
					num5 += num12;
					num6 += num11;
				}
			}
		}
		else if (ColorsBits16)
		{
			for (int k = 0; k < selectionBox.Height; k++)
			{
				for (int l = 0; l < selectionBox.Width; l++)
				{
					byte color4 = rgbValues[num2 + num3];
					byte color5 = rgbValues[num2 + 1];
					byte color6 = rgbValues[num2 + num4];
					int redBlue16BitId3 = GetRedBlue16BitId(color4);
					int redBlue16BitId4 = GetRedBlue16BitId(color6);
					int green16BitId2 = GetGreen16BitId(color5);
					if (redBlue16BitId4 < 0 || green16BitId2 < 0 || redBlue16BitId3 < 0)
					{
						continue;
					}
					int num20 = (redBlue16BitId4 << RedShift) + (green16BitId2 << GreenShift) + (redBlue16BitId3 << BlueShift);
					if (num20 != MaxColorVal)
					{
						list.Add(num20);
						if (firstOnly)
						{
							return list.ToArray();
						}
					}
					num2 += bpp;
				}
				num2 += num;
			}
		}
		else
		{
			for (int m = 0; m < selectionBox.Height; m++)
			{
				for (int n = 0; n < selectionBox.Width; n++)
				{
					byte num21 = rgbValues[num2 + num3];
					byte b3 = rgbValues[num2 + 1];
					byte b4 = rgbValues[num2 + num4];
					int num22 = (num21 << BlueShift) + (b3 << GreenShift) + (b4 << RedShift);
					if (num22 != MaxColorVal)
					{
						list.Add(num22);
						if (firstOnly)
						{
							return list.ToArray();
						}
					}
					num2 += bpp;
				}
				num2 += num;
			}
		}
		return _0023_003DziNP3HW_S_Szu(list);
	}

	private static int[] _0023_003DziNP3HW_S_Szu(List<int> _0023_003Dzdo7ctlc_003D)
	{
		List<int> list = new List<int>();
		if (_0023_003Dzdo7ctlc_003D.Count > 0)
		{
			_0023_003Dzdo7ctlc_003D.Sort();
			int num = _0023_003Dzdo7ctlc_003D[0];
			list.Add(num);
			for (int i = 1; i < _0023_003Dzdo7ctlc_003D.Count; i++)
			{
				if (_0023_003Dzdo7ctlc_003D[i] != num)
				{
					num = _0023_003Dzdo7ctlc_003D[i];
					list.Add(num);
				}
			}
		}
		return list.ToArray();
	}

	public override byte[] MakePowerOfTwo(byte[] bmpByteArray, out int bmpWidth, out int bmpHeight)
	{
		using Bitmap bitmap = UtilityEx.ConvertBytesToImage(bmpByteArray);
		using Bitmap bitmap2 = Texture.MakePowerOfTwo(this, bitmap);
		bmpWidth = bitmap2.Width;
		bmpHeight = bitmap2.Height;
		return UtilityEx.ConvertImageToBytes(bitmap2);
	}

	public override byte[] MakeGrayscale(byte[] imageBytes)
	{
		using Bitmap original = UtilityEx.ConvertBytesToImage(imageBytes);
		using Bitmap image = UtilityEx.MakeGrayscale(original);
		return UtilityEx.ConvertImageToBytes(image);
	}

	public override byte[] SetImageOpacity(byte[] imageBytes, float opacity)
	{
		using Bitmap image = UtilityEx.ConvertBytesToImage(imageBytes);
		using Bitmap image2 = UtilityEx.SetImageOpacity(image, opacity);
		return UtilityEx.ConvertImageToBytes(image2);
	}

	protected internal new void ThrowEntityNotCompiledError(EntityGraphicsData data)
	{
		base.ThrowEntityNotCompiledError(data);
	}

	public abstract byte[] ReadRgbValues(System.Drawing.Point leftBottomCameraScreen, Size size, BitmapData data);

	public override void BeginDrawMulticolorWithAmbientAndDiffuse(ShaderParameters shaderParams)
	{
		_0023_003DzNT32oUkqGeGp._0023_003Dz32GKgec08ez24iO1GoJN_0024Jo_003D = true;
		base.BeginDrawMulticolorWithAmbientAndDiffuse(shaderParams);
	}

	public override void EndDrawMulticolorWithAmbientAndDiffuse(ShaderParameters shaderParams)
	{
		_0023_003DzNT32oUkqGeGp._0023_003Dz32GKgec08ez24iO1GoJN_0024Jo_003D = false;
		base.EndDrawMulticolorWithAmbientAndDiffuse(shaderParams);
	}

	internal Bitmap _0023_003DzAg0R7vgxCXdu(System.Drawing.Rectangle _0023_003Dzols9v2M_003D, byte[] _0023_003DzqQPYGq3qIt9X, int _0023_003DzssihP0ihgi5u, string _0023_003Dz83HaHYE_003D, bool _0023_003Dzr5eQXr8_003D)
	{
		int bytesPerColor = (base.IsDirect3D ? 4 : 3);
		Bitmap bitmapFromData = GetBitmapFromData(_0023_003Dzols9v2M_003D, _0023_003DzqQPYGq3qIt9X, _0023_003DzssihP0ihgi5u, bytesPerColor);
		bitmapFromData.Save(_0023_003Dz83HaHYE_003D);
		if (_0023_003Dzr5eQXr8_003D)
		{
			bitmapFromData.Dispose();
		}
		return bitmapFromData;
	}

	protected Bitmap GetBitmapFromData(System.Drawing.Rectangle rect, byte[] colorValues, int stride, int bytesPerColor)
	{
		Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
		int num = 0;
		int num2 = stride - bytesPerColor * rect.Width;
		if (bytesPerColor == 3)
		{
			for (int i = 0; i < rect.Height; i++)
			{
				for (int j = 0; j < rect.Width; j++)
				{
					System.Drawing.Color color = System.Drawing.Color.FromArgb(colorValues[num + 2], colorValues[num + 1], colorValues[num]);
					bitmap.SetPixel(j, i, color);
					num += bytesPerColor;
				}
				num += num2;
			}
		}
		else
		{
			for (int k = 0; k < rect.Height; k++)
			{
				for (int l = 0; l < rect.Width; l++)
				{
					System.Drawing.Color color2 = System.Drawing.Color.FromArgb(colorValues[num + 3], colorValues[num + 2], colorValues[num + 1], colorValues[num]);
					bitmap.SetPixel(l, k, color2);
					num += bytesPerColor;
				}
				num += num2;
			}
		}
		return bitmap;
	}

	public override void DrawTextureOnScreen(System.Drawing.Rectangle rect, TextureBase textureForRendering, TextureBase textureResolved)
	{
		PushBlendState();
		SetState(blendStateType.Blend);
		PushDepthStencilState();
		SetState(depthStencilStateType.DepthTestAlways);
		CloseTexture();
		PushShader();
		PushMatrices();
		SetShader(shaderType.Texture2DNoLights);
		int[] viewport = currViewFrame;
		SetViewport(new int[4]
		{
			rect.X,
			rect.Y,
			rect.Size.Width,
			rect.Size.Height
		});
		SetMatrices(Camera.myOrtho(this, 0.0, rect.Size.Width, 0.0, rect.Size.Height, -1.0, 1.0), new double[16]
		{
			1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0,
			1.0, 0.0, 0.0, 0.0, 0.0, 1.0
		});
		TextureBase texture = textureForRendering;
		if (base.IsDirect3D && IsMultisample())
		{
			D3DRenderContext obj = (D3DRenderContext)this;
			obj.ResolveMultisampleTexture(textureForRendering, textureResolved);
			texture = textureResolved;
			obj._0023_003DzP7fhLh8_003D.GenerateMips(((D3DTexture2D)textureResolved)._0023_003DzV_0024hxxsU_0024ZCJW);
		}
		float[] texCoords = ((!base.IsDirect3D) ? new float[8] { 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f } : new float[8] { 0f, 1f, 1f, 1f, 1f, 0f, 0f, 0f });
		DrawQuadWithTextures(texture, texCoords, byte.MaxValue, new System.Drawing.RectangleF(0f, 0f, rect.Size.Width, rect.Size.Height), 0f, buffered: false);
		CloseTexture();
		SetViewport(viewport);
		PopMatrices();
		PushShader();
		PopBlendState();
		PopDepthStencilState();
	}

	public override bool EnableAlphaClip(bool enable)
	{
		bool result = _0023_003DzNT32oUkqGeGp._0023_003Dzemb5TmiWZnwc > 0f;
		_0023_003DzNT32oUkqGeGp._0023_003Dzemb5TmiWZnwc = (enable ? 1 : 0);
		return result;
	}

	internal virtual bool _0023_003DzlzeQWTRlPk6m()
	{
		return false;
	}

	public override float[,] GetHeightmapFromGeometry(double[] transformationMatrix, int[] viewFrame, DrawPlainGeometryCallBack drawCall)
	{
		if (!base.IsDirect3D && !((OglRenderContext)this).HasFBO())
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612803));
		}
		TextureBase textureBase = CreateTexture2D(new Size(viewFrame[2], viewFrame[3]), depthTexture: true);
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2 = null;
		PushCurrentFBO();
		if (!base.IsDirect3D)
		{
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2 = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(this, viewFrame[2], viewFrame[3], _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: false, 0u, ((OGLTexture)textureBase).Name, _0023_003Dz6mcnErFZlQyn: false);
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2._0023_003Dzri_Jxos_003D(this);
		}
		else
		{
			SetRenderTarget(null, textureBase);
		}
		PushMatrices();
		SetMatrices(null, transformationMatrix);
		_0023_003DzLADmvpnYILj0(viewFrame[0], viewFrame[1], viewFrame[2], viewFrame[3], 0f, 1f);
		PushBlendState();
		SetState(blendStateType.NoBlend);
		PushDepthStencilState();
		SetState(depthStencilStateType.DepthTestLess);
		ClearDepthStencil(depthBuffer: true, stencilBuffer: true, 0);
		PushRasterizerState();
		SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		PushShader();
		SetShader(shaderType.NoLights, null, force: true);
		drawCall(this);
		PopShader();
		PopDepthStencilState();
		PopBlendState();
		PopRasterizerState();
		PopMatrices();
		short[] array;
		if (!base.IsDirect3D)
		{
			Bitmap bitmap = new Bitmap(viewFrame[2], viewFrame[3], PixelFormat.Format16bppGrayScale);
			try
			{
				BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, viewFrame[2], viewFrame[3]), ImageLockMode.WriteOnly, PixelFormat.Format16bppGrayScale);
				((OglRenderContext)this).ReadDepthValues(viewFrame[0], viewFrame[1], new Size(viewFrame[2], viewFrame[3]), bitmapData.Scan0, bitmapData.Stride);
				array = new short[viewFrame[2] * viewFrame[3]];
				for (int i = 0; i < viewFrame[3]; i++)
				{
					Marshal.Copy(bitmapData.Scan0 + bitmapData.Stride * i, array, viewFrame[2] * i, viewFrame[2]);
				}
				bitmap.UnlockBits(bitmapData);
			}
			finally
			{
				((IDisposable)bitmap).Dispose();
			}
		}
		else
		{
			using D3DTexture2D d3DTexture2D = new D3DTexture2D();
			d3DTexture2D._0023_003Dzcp4fLOSZApya(this, textureBase.Size, CpuAccessFlags.Read, ResourceUsage.Staging, Format.D24_UNorm_S8_UInt, BindFlags.None, new SampleDescription(1, 0));
			((D3DRenderContext)this)._0023_003DzP7fhLh8_003D.CopyResource(((D3DTextureDepth)textureBase)._0023_003Dz_IfKSJY_003D, d3DTexture2D._0023_003Dz_IfKSJY_003D);
			array = d3DTexture2D.ReadDepths(new System.Drawing.Rectangle(viewFrame[0], viewFrame[1], viewFrame[2], viewFrame[3]));
		}
		RestoreFBO();
		textureBase.Dispose();
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2?._0023_003DzHF353qc_003D(this);
		if (array.Length != viewFrame[2] * viewFrame[3])
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612852));
		}
		float[,] array2 = new float[viewFrame[2], viewFrame[3]];
		for (int j = 0; j < viewFrame[2]; j++)
		{
			for (int k = 0; k < viewFrame[3]; k++)
			{
				array2[j, k] = (float)array[j + k * viewFrame[2]] / 32767f;
			}
		}
		return array2;
	}

	internal override ZBufferBase CreateZBuffer(ZBufferBase _0023_003DzsmgIqeCnnRrL)
	{
		return new ZBuffer
		{
			Size = _0023_003DzsmgIqeCnnRrL.Size,
			Max = _0023_003DzsmgIqeCnnRrL.Max,
			Min = _0023_003DzsmgIqeCnnRrL.Min,
			LinesReadIncrement = _0023_003DzsmgIqeCnnRrL.LinesReadIncrement,
			Location = _0023_003DzsmgIqeCnnRrL.Location,
			ModelViewMatrix = _0023_003DzsmgIqeCnnRrL.ModelViewMatrix,
			ProjectionMatrix = _0023_003DzsmgIqeCnnRrL.ProjectionMatrix,
			SelectionImage = _0023_003DzsmgIqeCnnRrL.SelectionImage,
			Dirty = _0023_003DzsmgIqeCnnRrL.Dirty
		};
	}

	internal override byte[] BitmapFromColors(System.Drawing.Color[] _0023_003DzXSIcYos_003D)
	{
		return Texture.BitmapFromColors(_0023_003DzXSIcYos_003D);
	}

	protected void PackData<T>(ref T[] data, int nFloatsPerVertex, int first, int count) where T : struct
	{
		int num = count * nFloatsPerVertex;
		if (first != 0 || (CompilingEntity != null && num < data.Length))
		{
			T[] array = new T[num];
			Array.Copy(data, first * nFloatsPerVertex, array, 0, num);
			data = array;
		}
	}
}
