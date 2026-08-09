using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadDWG : ReadFileAsyncWithDrawing
{
	private enum _0023_003Dz_0024H7BdIKtlSwH
	{
		Simple = 0,
		Quadratic = 5,
		Cubic = 6,
		Bezier = 8
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, bool> _0023_003DzgnqB99KPcDFbDLYSxg_003D_003D;

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, bool> _0023_003DzfF6Yh1PavCPu9TIiOg_003D_003D;

		public static Func<_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D, Point2D> _0023_003DzlchAAE9bpIz9b48U_0024w_003D_003D;

		public static Func<double, bool> _0023_003DzcgZi5FcHJweNpD4ISQ_003D_003D;

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, bool> _0023_003DzWOVWzLz1hX66dkf_0024tA_003D_003D;

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, bool> _0023_003DzW2eD_iPB_00241bdd_bSOA_003D_003D;

		public static Func<double, bool> _0023_003Dz4mi0_kUSkRvLELmqTA_003D_003D;

		public static Func<_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D, bool> _0023_003Dzalnv0COf_I9Zi869Kg_003D_003D;

		public static Func<_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D, Point3D> _0023_003Dz8hXhnEXFcP5YvDcl9w_003D_003D;

		public static Func<_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D, Point3D> _0023_003Dz741qW04X4fIbBg3ufQ_003D_003D;

		public static Func<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D, bool> _0023_003DzeOAEagBlKF_0024xqvbU_0024A_003D_003D;

		public static Func<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D, _0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D> _0023_003DzglWR6MC45Z4gevdGPw_003D_003D;

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, int> _0023_003DzbMFvdl9WycLM6zQ_gA_003D_003D;

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, int> _0023_003Dz3Z0iPty6buiVKASApg_003D_003D;

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, int> _0023_003DzuCnxmib3iEIQeUPAnA_003D_003D;

		public static Predicate<double> _0023_003DzqfJsr5XIJPuwwfeL0w_003D_003D;

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, int> _0023_003Dzjv_oRg4OxsLgTclO4g_003D_003D;

		public static Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, int> _0023_003DzlIqztdbrwP9XE9xs_0024w_003D_003D;

		public static Func<double, bool> _0023_003DzU2lxieQmXQSoJaUVgQ_003D_003D;

		internal bool _0023_003Dzvxmh89BnsZphAAUWbG3lS5ZEr97DZ6PuJfnB9SQ_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D._0023_003DzELu0Pss_003D._0023_003DzzsSfH74_003D == '\0';
		}

		internal bool _0023_003DzzUx0ocdbsfCtb71_E5JNWLhE2BGJWg6ygpcupmI_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D._0023_003DzELu0Pss_003D._0023_003DzzsSfH74_003D == 'G';
		}

		internal Point2D _0023_003DzDO19nNXeZHoQ_0024rgQdcfWzYw_003D(_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003Dz77g161c_003D)
		{
			return _0023_003DzUnxHUznPiV7g(_0023_003Dz77g161c_003D);
		}

		internal bool _0023_003Dz24PRTcNFUckosZ72QjRoGuM_003D(double _0023_003Dz1v6oPQk_003D)
		{
			return _0023_003Dz1v6oPQk_003D != 0.0;
		}

		internal bool _0023_003Dz8gRmDqK6o5C3TThQpT_F57s_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D._0023_003DzELu0Pss_003D._0023_003DzzsSfH74_003D == '\n';
		}

		internal bool _0023_003Dzn0qxT4dFOrOWF3XOdOiq9dg_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D._0023_003DzELu0Pss_003D._0023_003DzzsSfH74_003D == '\n';
		}

		internal bool _0023_003Dz23eMBT3XF3gpneO8VLUHR19sHqiRTsVb0w_003D_003D(double _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D == 0.0;
		}

		internal bool _0023_003DzPo2BwEGnKGh7ObWd8p7iB60pC0fUrOCAhw_003D_003D(_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D _0023_003Dz77g161c_003D)
		{
			return _0023_003Dz77g161c_003D._0023_003Dzo9ajQUuoihC2 > 0.0;
		}

		internal Point3D _0023_003DzygXLsiqbmbpcJDWx_0024qrZiviWYhMl1z1mLA_003D_003D(_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003DzMlCq3wk_003D)
		{
			return _0023_003Dzmq2_arBswhAA(_0023_003DzMlCq3wk_003D);
		}

		internal Point3D _0023_003DzpXDjp4zPJV5AvjfKV1XemzmyTrnBFoMDxg_003D_003D(_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D _0023_003Dz77g161c_003D)
		{
			return _0023_003Dzmq2_arBswhAA(_0023_003Dz77g161c_003D._0023_003DzlY77YgY_003D);
		}

		internal bool _0023_003Dz_yk_pS9VVPOF_Q4k_Dspe0iMePuOLdDbAw_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dzs_0024uS8LA_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D != null;
		}

		internal _0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D _0023_003Dz3HN_0024TyEZffwUVQhPK42SxZuFGliTdcL0qQ_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dzs_0024uS8LA_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzznCFU5x_002428gt6aaU_g_003D_003D;
		}

		internal int _0023_003DzMgzbHGtqc7Nt7tCRmLDh2GI_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D;
		}

		internal int _0023_003DzD3XNhRvQrIemsk0lWow_GIP5c7jw_UVRYg_003D_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D;
		}

		internal int _0023_003DzczLL8o7RGN8H9_00241m9BgE5mU_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D;
		}

		internal bool _0023_003Dz3inJVbDkZF2HrRTQL_0024gvls0_003D(double _0023_003DzXrexKjY_003D)
		{
			return _0023_003DzXrexKjY_003D == 0.0;
		}

		internal int _0023_003Dz_0024MeNj3n0sLOaR40rc_Jp0ew_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D;
		}

		internal int _0023_003Dz_0024fVQMv_0024Cc9tpClGVbSBD7PzynhVWGLrq2A_003D_003D(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003Dz437_00244ak_003D)
		{
			return _0023_003Dz437_00244ak_003D._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D;
		}

		internal bool _0023_003Dz0v6Rjh1WRtALzZ5DlsKygzbmNY6H(double _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D == 0.0;
		}
	}

	private sealed class _0023_003Dz2OiDJbg_003D
	{
		private autodeskSourceType _0023_003DzIrmOpIQKicqeHpAOIg_003D_003D;

		private autodeskExportType _0023_003DzrCmz0L42Az4OhA71EXzXxOA_003D;

		public autodeskSourceType _0023_003DzYaszvDjd2aLL()
		{
			return _0023_003DzIrmOpIQKicqeHpAOIg_003D_003D;
		}

		public void _0023_003DzRkkYAZvv7ZOa(autodeskSourceType _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzIrmOpIQKicqeHpAOIg_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public autodeskExportType _0023_003DzPox_zz0iJaq7()
		{
			return _0023_003DzrCmz0L42Az4OhA71EXzXxOA_003D;
		}

		public void _0023_003Dzwesjygcl_YuA(autodeskExportType _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzrCmz0L42Az4OhA71EXzXxOA_003D = _0023_003DzPzO_0024GUk_003D;
		}
	}

	private enum _0023_003Dz3dyK9gE0_0024Dqp
	{
		kInvalid,
		kRect,
		kPoly
	}

	private struct _0023_003Dz62alrNM_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003DziWEQWvc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003Dzzo8RvXc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Quaternion _0023_003DzVvkLpZU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003DzCBEAoWM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public projectionType _0023_003Dzbl24fQDH5pP9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzG5DcWQMkTDXTkYfv5A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzYUMqwZQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SizeF _0023_003DzeYC4yc0gvh69;

		public bool _0023_003Dzvk_j02M_003D(Camera _0023_003Dz10qtbIGWAWjL, Size _0023_003Dz4BrWeV0_003D)
		{
			if (_0023_003DziWEQWvc_003D == null)
			{
				return false;
			}
			Vector3D viewNormal = _0023_003Dz10qtbIGWAWjL.ViewNormal;
			Transformation.AutocadOCS(_0023_003DziWEQWvc_003D, out var _, out var _);
			Utility.GetRotationAxisAndAngle(viewNormal, _0023_003DziWEQWvc_003D, out var rotAxis, out var angleInDegrees);
			if (rotAxis != null)
			{
				_0023_003Dz10qtbIGWAWjL.Rotation = new Quaternion(rotAxis, angleInDegrees) * _0023_003Dz10qtbIGWAWjL.Rotation;
			}
			_0023_003Dz10qtbIGWAWjL.Tilt(_0023_003DzCBEAoWM_003D);
			_0023_003Dz10qtbIGWAWjL.ProjectionMode = _0023_003Dzbl24fQDH5pP9;
			if (_0023_003Dz10qtbIGWAWjL.ProjectionMode == projectionType.Orthographic)
			{
				double val = (float)_0023_003Dz4BrWeV0_003D.Width / _0023_003DzeYC4yc0gvh69.Width;
				double val2 = (float)_0023_003Dz4BrWeV0_003D.Height / _0023_003DzeYC4yc0gvh69.Height;
				_0023_003Dz10qtbIGWAWjL.ZoomFactor = Math.Max(val, val2);
			}
			else
			{
				_0023_003Dz10qtbIGWAWjL.FocalLength = _0023_003DzG5DcWQMkTDXTkYfv5A_003D_003D;
				_0023_003Dz10qtbIGWAWjL.Distance = _0023_003DzYUMqwZQ_003D;
			}
			_0023_003Dz10qtbIGWAWjL.Target = _0023_003Dzzo8RvXc_003D;
			return true;
		}
	}

	internal sealed class _0023_003Dz9Cw5d0_0024xEL31U87kjI_0024bcjs_003D
	{
	}

	private enum _0023_003DzBXBxitM_003D
	{
		Text,
		Tol,
		Insert,
		None
	}

	private enum _0023_003DzC7KaYLVzq_0024HZ
	{
		kTopLeft = 1,
		kTopCenter,
		kTopRight,
		kMiddleLeft,
		kMiddleCenter,
		kMiddleRight,
		kBottomLeft,
		kBottomCenter,
		kBottomRight
	}

	private enum _0023_003DzI7_00246CpuM2pwv
	{
		PatternOrigin = 10
	}

	private delegate object _0023_003DzLRa1FCrMhpeH3ir8MQ_003D_003D(object _0023_003DzcrILBXg_003D);

	private enum _0023_003DzTfJR39huE1aP
	{
		DIMPOST = 3,
		DIMAPOST = 4,
		DIMSCALE = 40,
		DIMASZ = 41,
		DIMEXO = 42,
		DIMDLI = 43,
		DIMEXE = 44,
		DIMRND = 45,
		DIMDLE = 46,
		DIMTP = 47,
		DIMTM = 48,
		DIMTOL = 71,
		DIMLIM = 72,
		DIMTIH = 73,
		DIMTOH = 74,
		DIMSE1 = 75,
		DIMSE2 = 76,
		DIMTAD = 77,
		DIMZIN = 78,
		DIMAZIN = 79,
		DIMTXT = 140,
		DIMCEN = 141,
		DIMTSZ = 142,
		DIMALTF = 143,
		DIMLFAC = 144,
		DIMTVP = 145,
		DIMTFAC = 146,
		DIMGAP = 147,
		DIMALTRND = 148,
		DIMALT = 170,
		DIMALTD = 171,
		DIMTOFL = 172,
		DIMSAH = 173,
		DIMTIX = 174,
		DIMSOXD = 175,
		DIMCLRD = 176,
		DIMCLRE = 177,
		DIMCLRT = 178,
		DIMADEC = 179,
		DIMUNIT = 270,
		DIMDEC = 271,
		DIMTDEC = 272,
		DIMALTU = 273,
		DIMALTTD = 274,
		DIMAUNIT = 275,
		DIMFRAC = 276,
		DIMLUNIT = 277,
		DIMDSEP = 278,
		DIMTMOVE = 279,
		DIMJUST = 280,
		DIMSD1 = 281,
		DIMSD2 = 282,
		DIMTOLJ = 283,
		DIMTZIN = 284,
		DIMALTZ = 285,
		DIMALTTZ = 286,
		DIMFIT = 287,
		DIMUPT = 288,
		DIMATFIT = 289,
		DIMTXSTY = 340,
		DIMLDRBLK = 341,
		DIMBLK = 342,
		DIMBLK1 = 343,
		DIMBLK2 = 344,
		DIMLWD = 371,
		DIMLWE = 372
	}

	private sealed class _0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D
	{
		public _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D;

		internal _0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D _0023_003DzQK9rraso3ItIRrOfF54lwhVhA8lj(_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D _0023_003Dz77g161c_003D)
		{
			return _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz77g161c_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzznCFU5x_002428gt6aaU_g_003D_003D;
		}
	}

	private sealed class _0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D : IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>, IEnumerable, IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003Dza18auqkIO4ikE_0024Fgfk4YkL_Ckr7lanBMhVyfnwU_003D _0023_003Dzi4cdUYM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dza18auqkIO4ikE_0024Fgfk4YkL_Ckr7lanBMhVyfnwU_003D _0023_003DzHMcqF6mnkvZt;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dzbd_Hsyijovok _0023_003Dzja9gywQIhYG_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D;

		[DebuggerHidden]
		public _0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2;
			switch (_0023_003DzU7pGb3X7Zp4G)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D = _0023_003Dzi4cdUYM_003D._0023_003DzB43_00244h5YT0JV_0024ydwuw_003D_003D._0023_003Dzsfb7U1TFH2wE;
				goto IL_0038;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				goto IL_00cf;
			case 2:
				{
					_0023_003DzU7pGb3X7Zp4G = -1;
					goto IL_00cf;
				}
				IL_00cf:
				if (_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D == 0L)
				{
					return false;
				}
				goto IL_0038;
				IL_0038:
				_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D);
				if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 == null || _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D == null)
				{
					_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D = 0L;
					_0023_003DzezVIuujSK1H9 = null;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
				_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D = ((_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003Dz9MOnS4_0024n_gqH != null) ? _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003Dz9MOnS4_0024n_gqH._0023_003Dzsfb7U1TFH2wE : (_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D + 1));
				_0023_003DzezVIuujSK1H9 = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzcKZRbjbBBhU2z2_0024c7ODdLCJrVh0m6w4UtyIAkHah2GjR()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zcKZRbjbBBhU2z2$c7ODdLCJrVh0m6w4UtyIAkHah2GjR
			return this._0023_003DzcKZRbjbBBhU2z2_0024c7ODdLCJrVh0m6w4UtyIAkHah2GjR();
		}

		[DebuggerHidden]
		private void _0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrmSvUIWk93$2zIiUzQ==
			this._0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
			return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
		}

		[DebuggerHidden]
		private IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> _0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024()
		{
			_0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D _0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D2 = this;
			}
			else
			{
				_0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D2 = new _0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D(0);
			}
			_0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D2._0023_003DzELu0Pss_003D = _0023_003Dzja9gywQIhYG_;
			_0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D2._0023_003Dzi4cdUYM_003D = _0023_003DzHMcqF6mnkvZt;
			return _0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D2;
		}

		IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj$
			return this._0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	internal sealed class _0023_003Dzbd_Hsyijovok
	{
		public string _0023_003Dzi_i_00249LM56LFZ;

		public Dictionary<string, string> _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB;

		public Layer _0023_003DzkH67_MBHE4Ud;

		public BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu;

		public bool _0023_003DztO5D_0024_AzPWZu;

		public bool _0023_003DzkGwmJBIVHL2e;

		public Block _0023_003DzSXqTc_00245giMaP;

		public TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG4;

		public LineTypeKeyedCollection _0023_003Dzt1RSIVUh_0024mJh5IXfuw_003D_003D;

		internal _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D;

		public Sheet _0023_003Dzow3wazApPFf_0024;

		public double _0023_003DzejwXvvKS0nx7OIb9lg_003D_003D;

		public object _0023_003DzkabH3a5uOAQQ8hRWIg_003D_003D;

		[Obsolete("Use the constructor that accepts the hatchImportMode instead.")]
		public _0023_003Dzbd_Hsyijovok(string _0023_003Dzi_i_00249LM56LFZ, Dictionary<string, string> _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, Layer _0023_003DzkH67_MBHE4Ud, BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu, bool _0023_003DztO5D_0024_AzPWZu, bool _0023_003DzkGwmJBIVHL2e, Block _0023_003DzSXqTc_00245giMaP, TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG4, LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk)
		{
			this._0023_003Dzi_i_00249LM56LFZ = _0023_003Dzi_i_00249LM56LFZ;
			this._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB = _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB;
			_0023_003Dzt1RSIVUh_0024mJh5IXfuw_003D_003D = _0023_003Dzr0vuHde1OVHk;
			this._0023_003DzkH67_MBHE4Ud = _0023_003DzkH67_MBHE4Ud;
			this._0023_003Dza0EiICLV_0024jmu = _0023_003Dza0EiICLV_0024jmu;
			this._0023_003DztO5D_0024_AzPWZu = _0023_003DztO5D_0024_AzPWZu;
			this._0023_003DzkGwmJBIVHL2e = _0023_003DzkGwmJBIVHL2e;
			this._0023_003DzSXqTc_00245giMaP = _0023_003DzSXqTc_00245giMaP;
			this._0023_003DzUkGYUZOWpxG4 = _0023_003DzUkGYUZOWpxG4;
		}

		public _0023_003Dzbd_Hsyijovok(string _0023_003Dzi_i_00249LM56LFZ, Dictionary<string, string> _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, Layer _0023_003DzkH67_MBHE4Ud, BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu, bool _0023_003DztO5D_0024_AzPWZu, bool _0023_003DzkGwmJBIVHL2e, Block _0023_003DzSXqTc_00245giMaP, TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG4, LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk, _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D)
		{
			this._0023_003Dzi_i_00249LM56LFZ = _0023_003Dzi_i_00249LM56LFZ;
			this._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB = _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB;
			_0023_003Dzt1RSIVUh_0024mJh5IXfuw_003D_003D = _0023_003Dzr0vuHde1OVHk;
			this._0023_003DzkH67_MBHE4Ud = _0023_003DzkH67_MBHE4Ud;
			this._0023_003Dza0EiICLV_0024jmu = _0023_003Dza0EiICLV_0024jmu;
			this._0023_003DztO5D_0024_AzPWZu = _0023_003DztO5D_0024_AzPWZu;
			this._0023_003DzkGwmJBIVHL2e = _0023_003DzkGwmJBIVHL2e;
			this._0023_003DzSXqTc_00245giMaP = _0023_003DzSXqTc_00245giMaP;
			this._0023_003DzUkGYUZOWpxG4 = _0023_003DzUkGYUZOWpxG4;
			this._0023_003Dz8N608Vg_003D = _0023_003Dz8N608Vg_003D;
		}
	}

	private sealed class _0023_003Dzbu7jQqGqfSM9hacfKAfwPuY_003D
	{
		public _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D;

		internal _0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D _0023_003DzZyFHqKCX3h_00248kG9ULpGKMXyvVuQJ(_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D _0023_003Dz77g161c_003D)
		{
			return _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz77g161c_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DznDtqSlJPqUdzwKhgkA_003D_003D;
		}
	}

	private sealed class _0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D : IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>, IEnumerable, IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzcnLDdsVpLi_ZqzFOTdAwIcY_003D _0023_003Dzcoe2_tewkWc6;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzcnLDdsVpLi_ZqzFOTdAwIcY_003D _0023_003Dz8nuxCHDrYlpJq1_0024Mig_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dzbd_Hsyijovok _0023_003Dzja9gywQIhYG_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D;

		[DebuggerHidden]
		public _0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D == 0L)
				{
					return false;
				}
			}
			else
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D = _0023_003Dzcoe2_tewkWc6._0023_003DzRyaopEboJCiP._0023_003Dzsfb7U1TFH2wE;
			}
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D);
			_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D = ((_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003Dz9MOnS4_0024n_gqH != null) ? _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003Dz9MOnS4_0024n_gqH._0023_003Dzsfb7U1TFH2wE : (_0023_003DzkHrYY_00246op2JSKsfZ0w_003D_003D + 1));
			_0023_003DzezVIuujSK1H9 = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2;
			_0023_003DzU7pGb3X7Zp4G = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzcKZRbjbBBhU2z2_0024c7ODdLCJrVh0m6w4UtyIAkHah2GjR()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zcKZRbjbBBhU2z2$c7ODdLCJrVh0m6w4UtyIAkHah2GjR
			return this._0023_003DzcKZRbjbBBhU2z2_0024c7ODdLCJrVh0m6w4UtyIAkHah2GjR();
		}

		[DebuggerHidden]
		private void _0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrmSvUIWk93$2zIiUzQ==
			this._0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
			return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
		}

		[DebuggerHidden]
		private IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> _0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024()
		{
			_0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D _0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D2 = this;
			}
			else
			{
				_0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D2 = new _0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D(0);
			}
			_0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D2._0023_003DzELu0Pss_003D = _0023_003Dzja9gywQIhYG_;
			_0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D2._0023_003Dzcoe2_tewkWc6 = _0023_003Dz8nuxCHDrYlpJq1_0024Mig_003D_003D;
			return _0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D2;
		}

		IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj$
			return this._0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private enum _0023_003DzjNr_0024_0024QU_003D
	{
		kLnWtByLwDefault = -3,
		kLnWtByBlock = -2,
		kLnWtByLayer = -1,
		kLnWt000 = 0,
		kLnWt005 = 5,
		kLnWt009 = 9,
		kLnWt013 = 13,
		kLnWt015 = 15,
		kLnWt018 = 18,
		kLnWt020 = 20,
		kLnWt025 = 25,
		kLnWt030 = 30,
		kLnWt035 = 35,
		kLnWt040 = 40,
		kLnWt050 = 50,
		kLnWt053 = 53,
		kLnWt060 = 60,
		kLnWt070 = 70,
		kLnWt080 = 80,
		kLnWt090 = 90,
		kLnWt100 = 100,
		kLnWt106 = 106,
		kLnWt120 = 120,
		kLnWt140 = 140,
		kLnWt158 = 158,
		kLnWt200 = 200,
		kLnWt211 = 211
	}

	private enum _0023_003Dzl02rx_0024_aeUDU
	{

	}

	private enum _0023_003DzoAg_0024juaWrAWC
	{
		kFlat,
		kFlatWithEdges,
		kGouraud,
		kGouraudWithEdges,
		k2DWireframe,
		k3DWireframe,
		kHidden,
		kBasic,
		kRealistic,
		kConceptual,
		kCustom,
		kDim,
		kBrighten,
		kThicken,
		kLinePattern,
		kFacePattern,
		kColorChange,
		kFaceOnly,
		kEdgeOnly,
		kDisplayOnly,
		kJitterOff,
		kOverhangOff,
		kEdgeColorOff,
		kShadesOfGray,
		kSketchy,
		kXRay,
		kShadedWithEdges,
		kShaded,
		kByViewport,
		kByLayer,
		kByBlock,
		kEmptyStyle
	}

	private enum _0023_003Dzoq3_0024OjQA1tQF
	{
		kTtoB,
		kBtoT
	}

	private sealed class _0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D : IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>, IEnumerable, IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzLeyHB00_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzGHtdVmb9aoff;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dzbd_Hsyijovok _0023_003Dzja9gywQIhYG_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dz1ZiszTEGAxp_00246jTELQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long _0023_003DzTTtkdHJQVHa4SV3VnA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dz9xraizeN7vwK;

		[DebuggerHidden]
		public _0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3;
			switch (_0023_003DzU7pGb3X7Zp4G)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D[] _0023_003Dzv7xH9gk_003D = _0023_003DzLeyHB00_003D._0023_003Dzv7xH9gk_003D;
				_0023_003Dz1ZiszTEGAxp_00246jTELQ_003D_003D = ((_0023_003Dzv7xH9gk_003D != null) ? _0023_003Dzv7xH9gk_003D.Length : 0);
				if (_0023_003Dz1ZiszTEGAxp_00246jTELQ_003D_003D == 0 && (_0023_003DzLeyHB00_003D._0023_003DzGeBEw9J1idf9 == null || _0023_003DzLeyHB00_003D._0023_003DzGeBEw9J1idf9._0023_003Dzsfb7U1TFH2wE == 0L))
				{
					return false;
				}
				if (_0023_003Dz1ZiszTEGAxp_00246jTELQ_003D_003D == 0)
				{
					_0023_003DzTTtkdHJQVHa4SV3VnA_003D_003D = _0023_003DzLeyHB00_003D._0023_003DzGeBEw9J1idf9._0023_003Dzsfb7U1TFH2wE;
					goto IL_008a;
				}
				_0023_003Dz9xraizeN7vwK = 0;
				goto IL_018a;
			}
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				goto IL_0121;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				goto IL_0121;
			case 3:
				{
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003Dz9xraizeN7vwK++;
					goto IL_018a;
				}
				IL_0121:
				if (_0023_003DzTTtkdHJQVHa4SV3VnA_003D_003D == 0L)
				{
					break;
				}
				goto IL_008a;
				IL_018a:
				if (_0023_003Dz9xraizeN7vwK < _0023_003Dz1ZiszTEGAxp_00246jTELQ_003D_003D)
				{
					_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzLeyHB00_003D._0023_003Dzv7xH9gk_003D[_0023_003Dz9xraizeN7vwK]._0023_003Dzsfb7U1TFH2wE);
					_0023_003DzezVIuujSK1H9 = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2;
					_0023_003DzU7pGb3X7Zp4G = 3;
					return true;
				}
				break;
				IL_008a:
				_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzTTtkdHJQVHa4SV3VnA_003D_003D);
				if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3 == null || _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D == null)
				{
					_0023_003DzTTtkdHJQVHa4SV3VnA_003D_003D = 0L;
					_0023_003DzezVIuujSK1H9 = null;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
				_0023_003DzTTtkdHJQVHa4SV3VnA_003D_003D = ((_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003Dz9MOnS4_0024n_gqH != null) ? _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003Dz9MOnS4_0024n_gqH._0023_003Dzsfb7U1TFH2wE : (_0023_003DzTTtkdHJQVHa4SV3VnA_003D_003D + 1));
				_0023_003DzezVIuujSK1H9 = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzcKZRbjbBBhU2z2_0024c7ODdLCJrVh0m6w4UtyIAkHah2GjR()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zcKZRbjbBBhU2z2$c7ODdLCJrVh0m6w4UtyIAkHah2GjR
			return this._0023_003DzcKZRbjbBBhU2z2_0024c7ODdLCJrVh0m6w4UtyIAkHah2GjR();
		}

		[DebuggerHidden]
		private void _0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrmSvUIWk93$2zIiUzQ==
			this._0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
			return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
		}

		[DebuggerHidden]
		private IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> _0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024()
		{
			_0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D _0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D2 = this;
			}
			else
			{
				_0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D2 = new _0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D(0);
			}
			_0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D2._0023_003DzELu0Pss_003D = _0023_003Dzja9gywQIhYG_;
			_0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D2._0023_003DzLeyHB00_003D = _0023_003DzGHtdVmb9aoff;
			return _0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D2;
		}

		IEnumerator<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj$
			return this._0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzETHNGlUsw42qsr9M5ez1wYydm6L_kQz4uMreRXtloWj_0024();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003Dzpy08Ab9uEMb_0024J202y_PjouM_003D
	{
		public int _0023_003DzR9iNTRzD_0024_QJ;

		public Func<Brep.OrientedEdge, bool> _0023_003DzkqbsCVPMJ_0024g6;

		internal bool _0023_003DzYUt6iN9_eCIy5NHrTgzYVv4_003D(Brep.OrientedEdge _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.CurveIndex != _0023_003DzR9iNTRzD_0024_QJ;
		}
	}

	private enum _0023_003DzqFXknrKVx_0024Xn
	{
		LtoR = 1,
		RtoL,
		TtoB,
		BtoT,
		ByStyle
	}

	private enum _0023_003DzrGZ3whQcd9GD
	{
		kUserDefined,
		kPreDefined,
		kCustomDefined
	}

	private enum _0023_003DzuQUjVMCEogRq
	{

	}

	public enum AttachmentPoint
	{
		kTopLeft = 1,
		kTopCenter,
		kTopRight,
		kMiddleLeft,
		kMiddleCenter,
		kMiddleRight,
		kBottomLeft,
		kBottomCenter,
		kBottomRight,
		kBaseLeft,
		kBaseCenter,
		kBaseRight,
		kBaseAlign,
		kBottomAlign,
		kMiddleAlign,
		kTopAlign,
		kBaseFit,
		kBottomFit,
		kMiddleFit,
		kTopFit,
		kBaseMid,
		kBottomMid,
		kMiddleMid,
		kTopMid
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockReference[] _0023_003DzbLUVSN3vZzd_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzF7v9r2A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003Dz8dK2uhU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzVAFbYEoSaZBi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzNS4zHmODUFRu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_0024zpG__0024iX4elX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzMLT9unuFCQa2775en7mFkfw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzCyyiD7aM9LW3tHdOag_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzhEy9mmWqR3IsxTmAuz4mk2E_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzUL_00244DtX6CbActaebVQ4LAJI_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz5indGmK8tGyPjosjB9p3oqVUYSf6 = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzRUUOP7TRkAtISE1C2fJ8ors_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz7mqt6Rnaq0IVOB_1gaQKMbA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzVmVjYCagw3G1Tepb3A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzHP6drmy_00244Ugs = Color.White;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0TGiFFPvnr_hM6xKTx_PXAM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<KeyValuePair<short, object>> _0023_003DzJTv9lwiDNSb_0024LK7fCQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal autodeskVersionType _0023_003DzKeI3OEP6t3nX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<string, Transformation> _0023_003DzITXpfHxrZadmFvP45uqDMLZnKO0F3aPhN8xP52E_003D = new Dictionary<string, Transformation>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static object _0023_003DzI8_0024_PfA5TCVh = new object();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _0023_003DzEU_0024eHag_dB1L = false;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private attributeReferenceVisibilityType _0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzUPu3OwzBQC_0024U;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly AttachmentPoint[,] _0023_003Dzxxwp9scVUTld = new AttachmentPoint[4, 6]
	{
		{
			AttachmentPoint.kBaseLeft,
			AttachmentPoint.kBaseCenter,
			AttachmentPoint.kBaseRight,
			AttachmentPoint.kBaseAlign,
			AttachmentPoint.kBaseMid,
			AttachmentPoint.kBaseFit
		},
		{
			AttachmentPoint.kBottomLeft,
			AttachmentPoint.kBottomCenter,
			AttachmentPoint.kBottomRight,
			AttachmentPoint.kBottomAlign,
			AttachmentPoint.kBottomMid,
			AttachmentPoint.kBottomFit
		},
		{
			AttachmentPoint.kMiddleLeft,
			AttachmentPoint.kMiddleCenter,
			AttachmentPoint.kMiddleRight,
			AttachmentPoint.kMiddleAlign,
			AttachmentPoint.kMiddleMid,
			AttachmentPoint.kMiddleFit
		},
		{
			AttachmentPoint.kTopLeft,
			AttachmentPoint.kTopCenter,
			AttachmentPoint.kTopRight,
			AttachmentPoint.kTopAlign,
			AttachmentPoint.kTopMid,
			AttachmentPoint.kTopFit
		}
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private StreamWriter _0023_003Dzg5qpCUZJuw5N;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzMUz8vbaWBbHG = Point3D.Origin;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz62alrNM_003D _0023_003Dz3YTzYwTLBU_0024R;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_0024Fk5VPw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzpNTDgxIpPHS2 = new List<string>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003Dz8iuBhlRld1e9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEOCbnTbp11XugOEoecv8QbaozcO1;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public List<string> LayersToLoad
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMLT9unuFCQa2775en7mFkfw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzMLT9unuFCQa2775en7mFkfw_003D = value;
		}
	}

	public bool Simplify
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCyyiD7aM9LW3tHdOag_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzCyyiD7aM9LW3tHdOag_003D_003D = value;
		}
	}

	public bool SkipLayouts
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhEy9mmWqR3IsxTmAuz4mk2E_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzhEy9mmWqR3IsxTmAuz4mk2E_003D = value;
		}
	}

	public bool SkipOleObjects
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzUL_00244DtX6CbActaebVQ4LAJI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzUL_00244DtX6CbActaebVQ4LAJI_003D = value;
		}
	}

	public bool ExtrudeByThickness
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5indGmK8tGyPjosjB9p3oqVUYSf6;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz5indGmK8tGyPjosjB9p3oqVUYSf6 = value;
		}
	}

	public bool SkipProxies
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRUUOP7TRkAtISE1C2fJ8ors_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzRUUOP7TRkAtISE1C2fJ8ors_003D = value;
		}
	}

	public bool FixErrors
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz7mqt6Rnaq0IVOB_1gaQKMbA_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz7mqt6Rnaq0IVOB_1gaQKMbA_003D = value;
		}
	}

	public string Password
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVmVjYCagw3G1Tepb3A_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzVmVjYCagw3G1Tepb3A_003D_003D = value;
		}
	}

	public Color ForegroundColor
	{
		get
		{
			return _0023_003DzHP6drmy_00244Ugs;
		}
		set
		{
			if (value.ToArgb() != Color.White.ToArgb() && value.ToArgb() != Color.Black.ToArgb())
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999151));
			}
			_0023_003DzHP6drmy_00244Ugs = value;
		}
	}

	public bool SkipExternalReferences
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0TGiFFPvnr_hM6xKTx_PXAM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0TGiFFPvnr_hM6xKTx_PXAM_003D = value;
		}
	}

	public List<KeyValuePair<short, object>> ModelXData
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJTv9lwiDNSb_0024LK7fCQ_003D_003D;
		}
	}

	public autodeskVersionType OriginalFileVersion => _0023_003DzKeI3OEP6t3nX;

	public BlockReference[] FailedToLoad => _0023_003DzbLUVSN3vZzd_0024;

	public Point3D Min => _0023_003DzF7v9r2A_003D;

	public Point3D Max => _0023_003Dz8dK2uhU_003D;

	public Point2D MinLimit => _0023_003DzVAFbYEoSaZBi;

	public Point2D MaxLimit => _0023_003DzNS4zHmODUFRu;

	public bool CheckLimit => _0023_003Dz_0024zpG__0024iX4elX;

	public Dictionary<string, Transformation> PlotTransformations
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzITXpfHxrZadmFvP45uqDMLZnKO0F3aPhN8xP52E_003D;
		}
	}

	protected virtual bool buildDefaultDrawing => false;

	protected virtual bool noDocument => false;

	public attributeReferenceVisibilityType AttributeReferenceVisibilityMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D = value;
		}
	}

	public Point3D BasePoint => _0023_003DzMUz8vbaWBbHG;

	public List<string> SearchFolders => _0023_003DzpNTDgxIpPHS2;

	public bool ExplodeDimensions
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEOCbnTbp11XugOEoecv8QbaozcO1;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzEOCbnTbp11XugOEoecv8QbaozcO1 = value;
		}
	}

	public ReadDWG(string filePath, string password = null, bool fixErrors = false, bool skipProxies = true)
		: base(filePath)
	{
		SkipProxies = skipProxies;
		_0023_003DztGdcVOA_003D(password, fixErrors);
		_0023_003Dz8iuBhlRld1e9.Add(System.IO.Path.GetFileName(filePath));
	}

	public ReadDWG(Stream stream, string password = null, bool fixErrors = false, bool skipProxies = true)
		: base(stream)
	{
		SkipProxies = skipProxies;
		_0023_003DztGdcVOA_003D(password, fixErrors);
	}

	private void _0023_003Dzg_gOAs0z3hYG(List<KeyValuePair<short, object>> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzJTv9lwiDNSb_0024LK7fCQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DztGdcVOA_003D(string _0023_003Dz1TpVsjqgCMFL, bool _0023_003DzoAL7MllO_0024XW7)
	{
		Password = _0023_003Dz1TpVsjqgCMFL;
		FixErrors = _0023_003DzoAL7MllO_0024XW7;
		_0023_003Dz8iuBhlRld1e9 = new List<string>();
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003Dz_0024Fk5VPw_003D = false;
		_0023_003DzoJlqvtM_003D(base.Stream, out var _0023_003DzrxLRsss3tg, out var _0023_003Dz4ic8Qw6f1Sz, out _0023_003DzbLUVSN3vZzd_0024, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D, out _0023_003DzVAFbYEoSaZBi, out _0023_003DzNS4zHmODUFRu, out _0023_003Dz_0024zpG__0024iX4elX, progress, ct);
		base.Units = _0023_003Dz4ic8Qw6f1Sz;
		if (_0023_003DzrxLRsss3tg != null)
		{
			base.Entities.AddRange(_0023_003DzrxLRsss3tg);
		}
	}

	public override void ImportSettings(Document document)
	{
		document.AttributeReferenceVisibilityMode = AttributeReferenceVisibilityMode;
		if (base.HatchPatterns != null)
		{
			document.HatchPatterns.Measurement = base.HatchPatterns.Measurement;
		}
		base.ImportSettings(document);
	}

	internal static void _0023_003DzD_b88_0024aSBUyV<T>(EyeshotKeyedCollection<T> _0023_003DzqjMrmuo_003D, EyeshotKeyedCollection<T> _0023_003DzaoQTclc_003D) where T : IKeyedCollectionItem<T>
	{
		if (_0023_003DzqjMrmuo_003D == null)
		{
			return;
		}
		foreach (T item in _0023_003DzqjMrmuo_003D)
		{
			if (!_0023_003DzaoQTclc_003D.Contains(item.GetKey()))
			{
				_0023_003DzaoQTclc_003D.Add(item);
			}
		}
	}

	private void _0023_003DzoJlqvtM_003D(Stream _0023_003Dz98C1PIe_70FL, out Entity[] _0023_003DzrxLRsss3tg14, out linearUnitsType _0023_003Dz4ic8Qw6f1Sz9, out BlockReference[] _0023_003DzFP1zNm5aIpvo, out Point3D _0023_003DzqWHpvmQvMwHz, out Point3D _0023_003Dz6ess2JBT2mRt, out Point2D _0023_003DzR5VQfyZ_0024ynIe, out Point2D _0023_003DzDg4PnRgsENxJ, out bool _0023_003DzDQBgVUlXFc12, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzrxLRsss3tg14 = null;
		_0023_003DzqWHpvmQvMwHz = Point3D.MaxValue;
		_0023_003Dz6ess2JBT2mRt = Point3D.MinValue;
		base.Result = false;
		_0023_003DzR5VQfyZ_0024ynIe = null;
		_0023_003DzDg4PnRgsENxJ = null;
		_0023_003DzDQBgVUlXFc12 = false;
		try
		{
			_0023_003Dz_oyfH8Ts4td6ebASag_003D_003D._0023_003DzJIhJ7ug5C8Cm = StreamWriter.Null;
			_0023_003Dz_oyfH8Ts4td6ebASag_003D_003D._0023_003DzFRIKdla1uRy0 = StreamWriter.Null;
			_0023_003Dz_oyfH8Ts4td6ebASag_003D_003D._0023_003DzKepjmE8mOQRs = StreamWriter.Null;
			_0023_003Dz_oyfH8Ts4td6ebASag_003D_003D._0023_003DzE5npNEu2zl2cPxKu4g_003D_003D = StreamWriter.Null;
			_0023_003Dz_oyfH8Ts4td6ebASag_003D_003D._0023_003DzBsXhzFFkxvdJ = StreamWriter.Null;
			_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
			try
			{
				_ = SkipOleObjects;
				if (string.IsNullOrEmpty(Password))
				{
					Password = string.Empty;
				}
				if (_0023_003Dzn7DO_0024jkyzZre(_0023_003Dz98C1PIe_70FL, out _0023_003Dz4ic8Qw6f1Sz9, out _0023_003DzrxLRsss3tg14, out _0023_003DzFP1zNm5aIpvo, ref _0023_003DzqWHpvmQvMwHz, ref _0023_003Dz6ess2JBT2mRt, ref _0023_003DzR5VQfyZ_0024ynIe, ref _0023_003DzDg4PnRgsENxJ, ref _0023_003DzDQBgVUlXFc12, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					base.Result = true;
				}
			}
			finally
			{
				((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
			}
		}
		catch (Exception ex)
		{
			_0023_003DzFP1zNm5aIpvo = new BlockReference[0];
			_0023_003Dz4ic8Qw6f1Sz9 = linearUnitsType.Unitless;
			base.Result = false;
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			CloseStream();
		}
	}

	internal static autodeskVersionType _0023_003Dz24fA1XCaZOdHaan2WJn_TuI_003D(_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D _0023_003DzQ3hPewo_003D)
	{
		return _0023_003DzQ3hPewo_003D switch
		{
			_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_12 => autodeskVersionType.Release12, 
			_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_14 => autodeskVersionType.Release14, 
			_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2000 => autodeskVersionType.Acad2000, 
			_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2004 => autodeskVersionType.Acad2004, 
			_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2007 => autodeskVersionType.Acad2007, 
			_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2010 => autodeskVersionType.Acad2010, 
			_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2013 => autodeskVersionType.Acad2013, 
			_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_2018 => autodeskVersionType.Acad2018, 
			_ => autodeskVersionType.Acad2018, 
		};
	}

	internal static linearUnitsType _0023_003Dz8xTAk74d3tW9uU39Bg_003D_003D(ushort _0023_003Dzk5tMGRZ53Ii_Tafrlw_003D_003D)
	{
		if (_0023_003Dzk5tMGRZ53Ii_Tafrlw_003D_003D == 0)
		{
			return linearUnitsType.Unitless;
		}
		if (Enum.TryParse<linearUnitsType>(_0023_003Dzk5tMGRZ53Ii_Tafrlw_003D_003D.ToString(), out var result))
		{
			return result;
		}
		return linearUnitsType.NotSupported;
	}

	internal static Text.alignmentType _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(AttachmentPoint _0023_003Dz1pzzCsQ_003D)
	{
		Text.alignmentType result = Text.alignmentType.BaselineLeft;
		switch (_0023_003Dz1pzzCsQ_003D)
		{
		case AttachmentPoint.kBottomLeft:
			result = Text.alignmentType.BottomLeft;
			break;
		case AttachmentPoint.kBottomCenter:
			result = Text.alignmentType.BottomCenter;
			break;
		case AttachmentPoint.kBottomRight:
			result = Text.alignmentType.BottomRight;
			break;
		case AttachmentPoint.kBaseLeft:
		case AttachmentPoint.kBaseAlign:
		case AttachmentPoint.kBaseFit:
			result = Text.alignmentType.BaselineLeft;
			break;
		case AttachmentPoint.kBaseCenter:
			result = Text.alignmentType.BaselineCenter;
			break;
		case AttachmentPoint.kBaseRight:
			result = Text.alignmentType.BaselineRight;
			break;
		case AttachmentPoint.kMiddleLeft:
			result = Text.alignmentType.MiddleLeft;
			break;
		case AttachmentPoint.kMiddleCenter:
		case AttachmentPoint.kBaseMid:
			result = Text.alignmentType.MiddleCenter;
			break;
		case AttachmentPoint.kMiddleRight:
			result = Text.alignmentType.MiddleRight;
			break;
		case AttachmentPoint.kTopLeft:
			result = Text.alignmentType.TopLeft;
			break;
		case AttachmentPoint.kTopCenter:
			result = Text.alignmentType.TopCenter;
			break;
		case AttachmentPoint.kTopRight:
			result = Text.alignmentType.TopRight;
			break;
		}
		return result;
	}

	private static _0023_003DzC7KaYLVzq_0024HZ _0023_003DzmvyCCsJgnK7q(Text.alignmentType _0023_003Dz1pzzCsQ_003D)
	{
		return _0023_003Dz1pzzCsQ_003D switch
		{
			Text.alignmentType.BottomLeft => _0023_003DzC7KaYLVzq_0024HZ.kBottomLeft, 
			Text.alignmentType.BottomCenter => _0023_003DzC7KaYLVzq_0024HZ.kBottomCenter, 
			Text.alignmentType.BottomRight => _0023_003DzC7KaYLVzq_0024HZ.kBottomRight, 
			Text.alignmentType.MiddleLeft => _0023_003DzC7KaYLVzq_0024HZ.kMiddleLeft, 
			Text.alignmentType.MiddleCenter => _0023_003DzC7KaYLVzq_0024HZ.kMiddleCenter, 
			Text.alignmentType.MiddleRight => _0023_003DzC7KaYLVzq_0024HZ.kMiddleRight, 
			Text.alignmentType.TopLeft => _0023_003DzC7KaYLVzq_0024HZ.kTopLeft, 
			Text.alignmentType.TopCenter => _0023_003DzC7KaYLVzq_0024HZ.kTopCenter, 
			Text.alignmentType.TopRight => _0023_003DzC7KaYLVzq_0024HZ.kTopRight, 
			_ => _0023_003DzC7KaYLVzq_0024HZ.kMiddleCenter, 
		};
	}

	private static Text.alignmentType _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(_0023_003DzC7KaYLVzq_0024HZ _0023_003Dz1pzzCsQ_003D)
	{
		return _0023_003Dz1pzzCsQ_003D switch
		{
			_0023_003DzC7KaYLVzq_0024HZ.kBottomLeft => Text.alignmentType.BottomLeft, 
			_0023_003DzC7KaYLVzq_0024HZ.kBottomCenter => Text.alignmentType.BottomCenter, 
			_0023_003DzC7KaYLVzq_0024HZ.kBottomRight => Text.alignmentType.BottomRight, 
			_0023_003DzC7KaYLVzq_0024HZ.kMiddleLeft => Text.alignmentType.MiddleLeft, 
			_0023_003DzC7KaYLVzq_0024HZ.kMiddleCenter => Text.alignmentType.MiddleCenter, 
			_0023_003DzC7KaYLVzq_0024HZ.kMiddleRight => Text.alignmentType.MiddleRight, 
			_0023_003DzC7KaYLVzq_0024HZ.kTopLeft => Text.alignmentType.TopLeft, 
			_0023_003DzC7KaYLVzq_0024HZ.kTopCenter => Text.alignmentType.TopCenter, 
			_0023_003DzC7KaYLVzq_0024HZ.kTopRight => Text.alignmentType.TopRight, 
			_ => Text.alignmentType.MiddleCenter, 
		};
	}

	private static Dimension.horizontalAlignmentType _0023_003DzF8RvkF_0024sf1_0024zpxq4G_00242gJvo_003D(ushort _0023_003DzIRIiVIciQw31)
	{
		return _0023_003DzIRIiVIciQw31 switch
		{
			0 => Dimension.horizontalAlignmentType.Centered, 
			1 => Dimension.horizontalAlignmentType.FirstExtensionLine, 
			2 => Dimension.horizontalAlignmentType.SecondExtensionLine, 
			_ => Dimension.horizontalAlignmentType.Centered, 
		};
	}

	private static Dimension.verticalAlignmentType _0023_003Dz0yOsiWvhZV7rteWmhwgDe9k_003D(ushort _0023_003DzoJsj7nMaatE2)
	{
		return _0023_003DzoJsj7nMaatE2 switch
		{
			0 => Dimension.verticalAlignmentType.Centered, 
			1 => Dimension.verticalAlignmentType.Above, 
			4 => Dimension.verticalAlignmentType.Below, 
			_ => Dimension.verticalAlignmentType.Above, 
		};
	}

	internal virtual bool _0023_003Dzn7DO_0024jkyzZre(Stream _0023_003Dz98C1PIe_70FL, out linearUnitsType _0023_003Dz4ic8Qw6f1Sz9, out Entity[] _0023_003DzrxLRsss3tg14, out BlockReference[] _0023_003DzFP1zNm5aIpvo, ref Point3D _0023_003DzqWHpvmQvMwHz, ref Point3D _0023_003Dz6ess2JBT2mRt, ref Point2D _0023_003DzR5VQfyZ_0024ynIe, ref Point2D _0023_003DzDg4PnRgsENxJ, ref bool _0023_003DzDQBgVUlXFc12, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999104));
		_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2 = new _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D();
		StartContinuousAnimation(base.ReadingText, _0023_003DzmHS7frs_003D);
		int num = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzSIdxVMWGq6zH7lZVbg_003D_003D(_0023_003Dz98C1PIe_70FL, _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2);
		if (num >= _0023_003DzUj_EGvUkNHeM90w5zQ_003D_003D._0023_003DzbYcShSsXROSaFPQthw_003D_003D())
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999068));
			_0023_003Dz4ic8Qw6f1Sz9 = linearUnitsType.Unitless;
			_0023_003DzrxLRsss3tg14 = null;
			_0023_003DzFP1zNm5aIpvo = null;
			return false;
		}
		if (num > 0)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999270));
		}
		_0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D _0023_003DzQ3hPewo_003D = _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2._0023_003Dz8Vwa6Pc_003D._0023_003DzQ3hPewo_003D;
		if (_0023_003DzQ3hPewo_003D < _0023_003DzBeSlAy3pscSyZl7fo9yy4z8_003D.R_14)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999194) + _0023_003DzQ3hPewo_003D.GetDisplayName() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999182));
		}
		StopContinuousAnimation(_0023_003DzmHS7frs_003D);
		if (!_0023_003DziovQPjxLLGlj(out _0023_003DzrxLRsss3tg14, out _0023_003DzFP1zNm5aIpvo, ref _0023_003DzqWHpvmQvMwHz, ref _0023_003Dz6ess2JBT2mRt, ref _0023_003DzR5VQfyZ_0024ynIe, ref _0023_003DzDg4PnRgsENxJ, ref _0023_003DzDQBgVUlXFc12, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2))
		{
			_0023_003Dz4ic8Qw6f1Sz9 = linearUnitsType.Unitless;
			return false;
		}
		_0023_003DzKeI3OEP6t3nX = _0023_003Dz24fA1XCaZOdHaan2WJn_TuI_003D(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2._0023_003Dz8Vwa6Pc_003D._0023_003DzQ3hPewo_003D);
		if (_0023_003DzKeI3OEP6t3nX == autodeskVersionType.Release12 || _0023_003DzKeI3OEP6t3nX == autodeskVersionType.Release13 || _0023_003DzKeI3OEP6t3nX == autodeskVersionType.Release14)
		{
			_0023_003Dz4ic8Qw6f1Sz9 = linearUnitsType.Unitless;
		}
		else
		{
			ushort _0023_003Dz0ayzOq_0024Yy10ZmsJMbg_003D_003D = _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2._0023_003DzqGEUYVYcqGlx._0023_003Dz0ayzOq_0024Yy10ZmsJMbg_003D_003D;
			_0023_003Dz4ic8Qw6f1Sz9 = _0023_003Dz8xTAk74d3tW9uU39Bg_003D_003D(_0023_003Dz0ayzOq_0024Yy10ZmsJMbg_003D_003D);
		}
		return true;
	}

	internal bool _0023_003DziovQPjxLLGlj(out Entity[] _0023_003DzrxLRsss3tg14, out BlockReference[] _0023_003DzFP1zNm5aIpvo, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D, ref Point2D _0023_003DzR5VQfyZ_0024ynIe, ref Point2D _0023_003DzDg4PnRgsENxJ, ref bool _0023_003DzDQBgVUlXFc12, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003DzgoEmXtNJA4td)
	{
		_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003DzC_N_0024MuXGG31j = _0023_003DzgoEmXtNJA4td._0023_003DzqGEUYVYcqGlx._0023_003DzC_N_0024MuXGG31j;
		_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003DzNJ2fYGAKJfqn = _0023_003DzgoEmXtNJA4td._0023_003DzqGEUYVYcqGlx._0023_003DzNJ2fYGAKJfqn;
		_0023_003DzR5VQfyZ_0024ynIe = new Point2D(_0023_003DzC_N_0024MuXGG31j._0023_003DzBJFJHwk_003D, _0023_003DzC_N_0024MuXGG31j._0023_003Dz40R7bAU_003D);
		_0023_003DzDg4PnRgsENxJ = new Point2D(_0023_003DzNJ2fYGAKJfqn._0023_003DzBJFJHwk_003D, _0023_003DzNJ2fYGAKJfqn._0023_003Dz40R7bAU_003D);
		_0023_003DzDQBgVUlXFc12 = _0023_003DzgoEmXtNJA4td._0023_003DzqGEUYVYcqGlx._0023_003DzQF9lAHmTTIeMgaWyyQ_003D_003D != '\0';
		_0023_003DzrxLRsss3tg14 = null;
		if (FixErrors)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999898));
		}
		base.HatchPatterns = new HatchPatternKeyedCollection();
		Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
		Dictionary<string, string> _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB = new Dictionary<string, string>();
		BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu;
		TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG;
		LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk;
		float _0023_003Dz8oMsDcyNkuDg;
		List<Entity> list = _0023_003DzbezkkWk_003D(null, _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, _0023_003DzgoEmXtNJA4td, _0023_003Dz47HBQmYeh1Ai, out _0023_003Dza0EiICLV_0024jmu, out _0023_003DzUkGYUZOWpxG, out _0023_003Dzr0vuHde1OVHk, out _0023_003Dz8oMsDcyNkuDg, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		base.TextStyles = _0023_003DzUkGYUZOWpxG;
		base.LineTypes = _0023_003Dzr0vuHde1OVHk;
		base.LineTypeScale = _0023_003Dz8oMsDcyNkuDg;
		if (_0023_003Dz_0024Fk5VPw_003D)
		{
			_0023_003DzFP1zNm5aIpvo = null;
			return false;
		}
		AttributeReferenceVisibilityMode = attributeReferenceVisibilityType.Normal;
		base.HatchPatterns.Measurement = HatchPatternKeyedCollection.measurementType.Metric;
		if (base.DrawingHatchPatterns != null)
		{
			base.DrawingHatchPatterns.Measurement = base.HatchPatterns.Measurement;
		}
		_0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(_0023_003Dz47HBQmYeh1Ai, _0023_003Dza0EiICLV_0024jmu, base.DrawingSheets, list, out var _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, out var _0023_003Dz25nZSuNUZn5v);
		_0023_003DzrBeU_f_Ge5Om(list, _0023_003Dza0EiICLV_0024jmu);
		if (!SkipLayouts)
		{
			foreach (Sheet drawingSheet in base.DrawingSheets)
			{
				_0023_003DzrBeU_f_Ge5Om(drawingSheet.Entities, _0023_003Dza0EiICLV_0024jmu);
			}
		}
		foreach (Block item in _0023_003Dza0EiICLV_0024jmu)
		{
			_0023_003DzrBeU_f_Ge5Om(item.Entities, _0023_003Dza0EiICLV_0024jmu);
		}
		_0023_003DzrxLRsss3tg14 = list.ToArray();
		_0023_003DzFP1zNm5aIpvo = _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D.ToArray();
		foreach (Block item2 in _0023_003Dza0EiICLV_0024jmu)
		{
			bool flag = ((_0023_003Dz2OiDJbg_003D)item2.CustomData)._0023_003DzYaszvDjd2aLL() != autodeskSourceType.Anonymous;
			if (!base.Blocks.Contains(item2.Name) && (flag || _0023_003Dz25nZSuNUZn5v.Contains(item2.Name)))
			{
				base.Blocks.Add(item2);
			}
			item2.CustomData = null;
		}
		return true;
	}

	private void _0023_003DzrBeU_f_Ge5Om(IList<Entity> _0023_003Dzv7xH9gk_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
	{
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (!(item is BlockReference))
			{
				continue;
			}
			BlockReference blockReference = (BlockReference)item;
			if (blockReference.Attributes.Count <= 0)
			{
				continue;
			}
			Transformation transformation = (Transformation)blockReference.GetFullTransformation(_0023_003DzJO1FWlQ_003D).Clone();
			transformation.Invert();
			foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
			{
				Plane plane = attribute.Value.Plane;
				attribute.Value.Plane = new Plane(transformation * plane.Origin, transformation * plane.AxisX, transformation * plane.AxisY);
			}
		}
	}

	internal static string _0023_003DzagryWWni2TF6FN1OaQ_003D_003D(object _0023_003Dz6RrwO9Q_003D, int _0023_003DztA_0024AxdXTrBDa)
	{
		StackTrace stackTrace = new StackTrace();
		return _0023_003Dz6RrwO9Q_003D.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + stackTrace.GetFrame(_0023_003DztA_0024AxdXTrBDa).GetMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999866);
	}

	internal static string _0023_003Dz8AIYQUVZBwfup4nSglMjf_s_003D(object _0023_003Dz6RrwO9Q_003D)
	{
		return _0023_003Dz6RrwO9Q_003D.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999959);
	}

	private void _0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, SheetKeyedCollection _0023_003DzqGLs6NnUvrRQ, IList<Entity> _0023_003DzWc9WmS8VMsuA, out List<BlockReference> _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, out HashSet<string> _0023_003Dz25nZSuNUZn5v)
	{
		_0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D = new List<BlockReference>();
		_0023_003Dz25nZSuNUZn5v = new HashSet<string>();
		foreach (Block item in _0023_003DzJO1FWlQ_003D)
		{
			_0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(_0023_003Dz47HBQmYeh1Ai, _0023_003DzJO1FWlQ_003D, item.Entities, _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, _0023_003Dz25nZSuNUZn5v);
		}
		if (!SkipLayouts)
		{
			foreach (Sheet item2 in _0023_003DzqGLs6NnUvrRQ)
			{
				_0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(_0023_003Dz47HBQmYeh1Ai, _0023_003DzJO1FWlQ_003D, item2.Entities, _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, _0023_003Dz25nZSuNUZn5v);
			}
		}
		_0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(_0023_003Dz47HBQmYeh1Ai, _0023_003DzJO1FWlQ_003D, _0023_003DzWc9WmS8VMsuA, _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, _0023_003Dz25nZSuNUZn5v);
	}

	private void _0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, IList<Entity> _0023_003DzWc9WmS8VMsuA, List<BlockReference> _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, HashSet<string> _0023_003Dz25nZSuNUZn5v)
	{
		for (int i = 0; i < _0023_003DzWc9WmS8VMsuA.Count; i++)
		{
			if (_0023_003DzWc9WmS8VMsuA[i] is View || !(_0023_003DzWc9WmS8VMsuA[i] is BlockReference blockReference))
			{
				continue;
			}
			bool flag = _0023_003Dz47HBQmYeh1Ai.ContainsKey(blockReference.BlockName);
			if (flag || !_0023_003DzJO1FWlQ_003D.Contains(blockReference.BlockName))
			{
				if (flag)
				{
					blockReference.EntityData = _0023_003Dz47HBQmYeh1Ai[blockReference.BlockName];
				}
				_0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D.Add(blockReference);
				_0023_003DzWc9WmS8VMsuA.RemoveAt(i);
				i--;
			}
			else
			{
				_0023_003Dz25nZSuNUZn5v.Add(blockReference.BlockName);
			}
		}
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003Dz3j2MWyc_003D(string _0023_003DzkKfJheA_003D)
	{
		_0023_003Dzg5qpCUZJuw5N.WriteLine(_0023_003DzkKfJheA_003D);
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003DzXtPp1L_C8leT()
	{
		_0023_003Dzg5qpCUZJuw5N = new StreamWriter(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999798));
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003Dz6edkzof72BT6()
	{
		_0023_003Dzg5qpCUZJuw5N.Close();
	}

	internal void _0023_003DzzDW8Nhhc76Dg(Point3D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMUz8vbaWBbHG = _0023_003DzPzO_0024GUk_003D;
	}

	private List<Entity> _0023_003DzbezkkWk_003D(string _0023_003Dzi_i_00249LM56LFZ, Dictionary<string, string> _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003DzgoEmXtNJA4td, Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, out BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu, out TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG4, out LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk, out float _0023_003Dz8oMsDcyNkuDg, out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzUkGYUZOWpxG4 = new TextStyleKeyedCollection();
		_0023_003Dza0EiICLV_0024jmu = new BlockKeyedCollection();
		if (string.IsNullOrEmpty(_0023_003Dzi_i_00249LM56LFZ))
		{
			_0023_003Dzi_i_00249LM56LFZ = string.Empty;
			_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D _0023_003DzLqNPpVPScQaw = _0023_003DzgoEmXtNJA4td._0023_003DzqGEUYVYcqGlx._0023_003DzLqNPpVPScQaw;
			_0023_003DzzDW8Nhhc76Dg(new Point3D(_0023_003DzLqNPpVPScQaw._0023_003DzBJFJHwk_003D, _0023_003DzLqNPpVPScQaw._0023_003Dz40R7bAU_003D, _0023_003DzLqNPpVPScQaw._0023_003DzId5C3LA_003D));
		}
		_0023_003DzF7v9r2A_003D = Point3D.MaxValue;
		_0023_003Dz8dK2uhU_003D = Point3D.MinValue;
		_0023_003Dz8oMsDcyNkuDg = (float)_0023_003DzgoEmXtNJA4td._0023_003DzqGEUYVYcqGlx._0023_003DzjTx5B6GbeIHn;
		bool flag = !string.IsNullOrEmpty(_0023_003Dzi_i_00249LM56LFZ);
		string _0023_003DzUPTg1DPlXSwL = string.Empty;
		if (flag)
		{
			_0023_003DzUPTg1DPlXSwL = _0023_003Dzi_i_00249LM56LFZ.Substring(0, _0023_003Dzi_i_00249LM56LFZ.Length - 1);
		}
		_0023_003DzzgJ0_0024bS_0024T6DyaeQm_0024A_003D_003D(_0023_003DzgoEmXtNJA4td);
		_0023_003Dzi605dMOp2r3T(_0023_003DzgoEmXtNJA4td, _0023_003DzUPTg1DPlXSwL, out _0023_003Dzr0vuHde1OVHk);
		_0023_003DzdEWsLrg_003D(_0023_003DzgoEmXtNJA4td, flag, _0023_003Dzi_i_00249LM56LFZ, _0023_003DzUPTg1DPlXSwL, _0023_003Dzr0vuHde1OVHk);
		_0023_003DzorzoAewfz7D_(_0023_003DzgoEmXtNJA4td, out _0023_003DzUkGYUZOWpxG4, _0023_003DzUPTg1DPlXSwL);
		List<Entity> list = new List<Entity>();
		_0023_003Dza0EiICLV_0024jmu = new BlockKeyedCollection(StringComparer.CurrentCultureIgnoreCase);
		_0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D = new _0023_003Dzbd_Hsyijovok(_0023_003Dzi_i_00249LM56LFZ, _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, new Layer(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999784)), _0023_003Dza0EiICLV_0024jmu, SkipProxies, SkipOleObjects, null, _0023_003DzUkGYUZOWpxG4, _0023_003Dzr0vuHde1OVHk, _0023_003DzgoEmXtNJA4td);
		_0023_003Dz_WPSEfrCWp3R(_0023_003DzgoEmXtNJA4td, _0023_003DzELu0Pss_003D, _0023_003Dz47HBQmYeh1Ai, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		if (!flag)
		{
			_0023_003DzwXaUSxTMziQA(_0023_003DzgoEmXtNJA4td);
		}
		if ((_0023_003DzgoEmXtNJA4td._0023_003DzJgLPtwW2aRu5YTAUng_003D_003D?._0023_003DztbByVAY_003D._0023_003DzcyjgzzFwJ_C_ ?? 0) > 1)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999761));
		}
		if (_0023_003Dz_0024Fk5VPw_003D)
		{
			list = null;
		}
		else
		{
			if (_0023_003DzgoEmXtNJA4td._0023_003DzfQBvT1uETSVi == null)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999707));
				return list;
			}
			_0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzAU5e7ML4pj6L = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzgoEmXtNJA4td, _0023_003DzgoEmXtNJA4td._0023_003DzfQBvT1uETSVi._0023_003DzembzSKEaxTCc._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzAU5e7ML4pj6L;
			if (!flag)
			{
				string name = _0023_003DzAU5e7ML4pj6L._0023_003DzPyofyVbkaTED._0023_003DzCX9Hbao_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzGTziT4A_003D._0023_003DzS_00246o7tc_003D.TrimStart('*');
				base.Blocks.RootBlock.Name = name;
			}
			_0023_003DzfOBDTtTFrTm5(_0023_003DzAU5e7ML4pj6L, list, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzELu0Pss_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			if (!SkipLayouts && !flag)
			{
				_0023_003DzVXwZYbg_003D(_0023_003DzELu0Pss_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			}
		}
		return list;
	}

	private void _0023_003DzzgJ0_0024bS_0024T6DyaeQm_0024A_003D_003D(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D)
	{
		if (_0023_003Dz8N608Vg_003D._0023_003DzqGEUYVYcqGlx._0023_003DzB7mOj7Gm6o0Gy5P6fzI5eQc_003D == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000427));
			return;
		}
		base.Materials = new MaterialKeyedCollection();
		_0023_003DzkCGkik_0024HuDFkeH_dw79j1LWXTOkiUAN6nQ_003D_003D _0023_003Dz0_QhICOOCFvT53E61w_003D_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003Dz8N608Vg_003D._0023_003DzqGEUYVYcqGlx._0023_003DzB7mOj7Gm6o0Gy5P6fzI5eQc_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz0_QhICOOCFvT53E61w_003D_003D;
		int _0023_003Dz5qQ2gcqSWdIeg4ZG_0024g_003D_003D = (int)_0023_003Dz0_QhICOOCFvT53E61w_003D_003D._0023_003Dz5qQ2gcqSWdIeg4ZG_0024g_003D_003D;
		for (int i = 0; i < _0023_003Dz5qQ2gcqSWdIeg4ZG_0024g_003D_003D; i++)
		{
			long _0023_003Dzsfb7U1TFH2wE = _0023_003Dz0_QhICOOCFvT53E61w_003D_003D._0023_003DzHd77rvksAZocL3PdbQ_003D_003D[i]._0023_003Dzsfb7U1TFH2wE;
			if (_0023_003Dzsfb7U1TFH2wE == 0L)
			{
				continue;
			}
			_0023_003DzO4b3j8FuEaXq6taVECRcM4c_003D _0023_003Dz9FuDnLY_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz9FuDnLY_003D;
			if (_0023_003Dz9FuDnLY_003D == null)
			{
				continue;
			}
			string _0023_003DzS_00246o7tc_003D = _0023_003Dz9FuDnLY_003D._0023_003DzS_00246o7tc_003D;
			if (_0023_003DzS_00246o7tc_003D.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000377)) || _0023_003DzS_00246o7tc_003D.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000359)) || _0023_003DzS_00246o7tc_003D.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000341)))
			{
				continue;
			}
			Material material = new Material(_0023_003DzS_00246o7tc_003D);
			material.Description = _0023_003Dz9FuDnLY_003D._0023_003DzmAgXdRQ_003D;
			uint num = _0023_003Dz9FuDnLY_003D._0023_003DzICQ8H3KdxVw34DXKBQ_003D_003D._0023_003DzFd5hios_003D & 0xFFFFFF;
			byte red = (byte)(num & 0xFF0000);
			byte green = (byte)(num & 0xFF00);
			byte blue = (byte)num;
			material.Ambient = Color.FromArgb(red, green, blue);
			_0023_003DzdjBUiOoz41RawWxJEsownwmCF1px _0023_003DzMtL8FF23ofkzGsNq1w_003D_003D = _0023_003Dz9FuDnLY_003D._0023_003DzMtL8FF23ofkzGsNq1w_003D_003D;
			uint num2 = _0023_003DzMtL8FF23ofkzGsNq1w_003D_003D._0023_003DzmSs_h5w_003D._0023_003DzFd5hios_003D & 0xFFFFFF;
			uint num3 = _0023_003DzMtL8FF23ofkzGsNq1w_003D_003D._0023_003Dzm4QpQkw_003D._0023_003DzFd5hios_003D & 0xFFFFFF;
			byte b = (byte)(num2 & 0xFF0000);
			byte b2 = (byte)(num2 & 0xFF00);
			byte b3 = (byte)num2;
			byte b4 = (byte)(num3 & 0xFF0000);
			byte b5 = (byte)(num3 & 0xFF00);
			byte b6 = (byte)num3;
			red = (byte)((b + b4) / 2);
			green = (byte)((b2 + b5) / 2);
			blue = (byte)((b3 + b6) / 2);
			double _0023_003Dz9ywbiM7HJBU55mtC3g_003D_003D = _0023_003Dz9FuDnLY_003D._0023_003Dz9ywbiM7HJBU55mtC3g_003D_003D;
			material.Diffuse = Color.FromArgb((int)(_0023_003Dz9ywbiM7HJBU55mtC3g_003D_003D * 255.0), red, green, blue);
			string text = _0023_003DzMtL8FF23ofkzGsNq1w_003D_003D._0023_003Dzg_0024RwPyE_003D;
			if (!string.IsNullOrEmpty(text))
			{
				try
				{
					if (File.Exists(text))
					{
						material.TextureImage = Utility._0023_003DzIpZE2cw6usPZ(text);
					}
					else
					{
						text = ((!string.IsNullOrEmpty(base.Path)) ? System.IO.Path.Combine(base.Path, System.IO.Path.GetFileName(text)) : System.IO.Path.GetFileName(text));
						if (File.Exists(text))
						{
							material.TextureImage = Utility._0023_003DzIpZE2cw6usPZ(text);
						}
					}
				}
				catch (Exception arg)
				{
					log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000324), arg, text, _0023_003DzS_00246o7tc_003D));
				}
			}
			uint num4 = _0023_003Dz9FuDnLY_003D._0023_003DzmYVwI62_0024a0r9bpGXiw_003D_003D._0023_003DzFd5hios_003D & 0xFFFFFF;
			red = (byte)(num4 & 0xFF0000);
			green = (byte)(num4 & 0xFF00);
			blue = (byte)num4;
			material.Specular = Color.FromArgb(red, green, blue);
			if (!base.Materials.Contains(material.Name))
			{
				base.Materials.Add(material);
			}
		}
	}

	private void _0023_003DzorzoAewfz7D_(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D, out TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG4, string _0023_003DzUPTg1DPlXSwL)
	{
		_0023_003DzUkGYUZOWpxG4 = new TextStyleKeyedCollection();
		if (_0023_003Dz8N608Vg_003D._0023_003Dz70mFbDRRnNp3 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000529));
		}
		else
		{
			if (_0023_003Dz8N608Vg_003D._0023_003Dz70mFbDRRnNp3._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D == null)
			{
				return;
			}
			for (int i = 0; i < _0023_003Dz8N608Vg_003D._0023_003Dz70mFbDRRnNp3._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D.Length; i++)
			{
				long _0023_003Dzsfb7U1TFH2wE = _0023_003Dz8N608Vg_003D._0023_003Dz70mFbDRRnNp3._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D[i]._0023_003Dzsfb7U1TFH2wE;
				if (_0023_003Dzsfb7U1TFH2wE != 0L)
				{
					_0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D _0023_003Dz4vDywqc_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz4vDywqc_003D;
					if ((_0023_003Dz4vDywqc_003D._0023_003DztbByVAY_003D._0023_003Dzu0fdGj8uwG1b_0024Zs0cQ_003D_003D != '1' || (!string.IsNullOrEmpty(_0023_003DzUPTg1DPlXSwL) && _0023_003Dz4vDywqc_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D.StartsWith(_0023_003DzUPTg1DPlXSwL))) && !string.IsNullOrEmpty(_0023_003Dz4vDywqc_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D) && !_0023_003DzUkGYUZOWpxG4.Contains(_0023_003Dz4vDywqc_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D))
					{
						_0023_003DzUkGYUZOWpxG4.Add(_0023_003Dz6ZIsoVdTO_jk90za3Vza19TgahMi(_0023_003Dz4vDywqc_003D, _0023_003DzUPTg1DPlXSwL));
					}
				}
			}
		}
	}

	private void _0023_003Dzi605dMOp2r3T(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D, string _0023_003DzUPTg1DPlXSwL, out LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk)
	{
		_0023_003Dzr0vuHde1OVHk = new LineTypeKeyedCollection();
		if (_0023_003Dz8N608Vg_003D._0023_003Dz5mE9wyRTIi2Q37zMLA_003D_003D == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000483));
			return;
		}
		for (int i = 0; i < _0023_003Dz8N608Vg_003D._0023_003Dz5mE9wyRTIi2Q37zMLA_003D_003D._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D.Length; i++)
		{
			long _0023_003Dzsfb7U1TFH2wE = _0023_003Dz8N608Vg_003D._0023_003Dz5mE9wyRTIi2Q37zMLA_003D_003D._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D[i]._0023_003Dzsfb7U1TFH2wE;
			if (_0023_003Dzsfb7U1TFH2wE == 0L)
			{
				continue;
			}
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003Dzsfb7U1TFH2wE);
			if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzEKSHIVc_003D != 57)
			{
				continue;
			}
			_0023_003DzTR5z6N_0024xLvYrGBfXqZSIK5hkX_00241Q _0023_003DzvVLGvrAoh3WE = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzvVLGvrAoh3WE;
			string _0023_003DzS_00246o7tc_003D = _0023_003DzvVLGvrAoh3WE._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D;
			if ((_0023_003DzvVLGvrAoh3WE._0023_003DztbByVAY_003D._0023_003Dzu0fdGj8uwG1b_0024Zs0cQ_003D_003D != '1' || (!string.IsNullOrEmpty(_0023_003DzUPTg1DPlXSwL) && _0023_003DzS_00246o7tc_003D.StartsWith(_0023_003DzUPTg1DPlXSwL))) && !LineTypeKeyedCollection.IsReservedName(_0023_003DzS_00246o7tc_003D))
			{
				float[] array = new float[_0023_003DzvVLGvrAoh3WE._0023_003Dzt5qQHCWPJf_A.Length];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = (float)_0023_003DzvVLGvrAoh3WE._0023_003Dzt5qQHCWPJf_A[j]._0023_003Dz736ekIs_003D;
				}
				if (LineType.CheckPattern(array, throwEx: false, out var _) && !_0023_003Dzr0vuHde1OVHk.Contains(_0023_003DzS_00246o7tc_003D))
				{
					_0023_003Dzr0vuHde1OVHk.Add(new LineType(_0023_003DzS_00246o7tc_003D, array, _0023_003DzvVLGvrAoh3WE._0023_003DzmAgXdRQ_003D));
				}
			}
		}
	}

	private static float _0023_003DznZ_0024c4UJBVHLK3svo29coD_0024wi12Ua(_0023_003DzjNr_0024_0024QU_003D _0023_003DzLs5VuQY_003D)
	{
		float result = 0.5f;
		switch (_0023_003DzLs5VuQY_003D)
		{
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt000:
			result = 0.01f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt005:
			result = 0.05f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt009:
			result = 0.09f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt013:
			result = 0.13f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt015:
			result = 0.15f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt018:
			result = 0.18f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt020:
			result = 0.2f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt025:
			result = 0.25f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt030:
			result = 0.3f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt035:
			result = 0.35f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt040:
			result = 0.4f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt050:
			result = 0.5f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt053:
			result = 0.53f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt060:
			result = 0.6f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt070:
			result = 0.7f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt080:
			result = 0.8f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt100:
			result = 1f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt106:
			result = 1.06f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt120:
			result = 1.2f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt140:
			result = 1.4f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt158:
			result = 1.58f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt200:
			result = 2f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWt211:
			result = 2.11f;
			break;
		case _0023_003DzjNr_0024_0024QU_003D.kLnWtByLwDefault:
			result = 0.25f;
			break;
		}
		return result;
	}

	private void _0023_003DzdEWsLrg_003D(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D, bool _0023_003DzBSmc6k0_003D, string _0023_003Dzi_i_00249LM56LFZ, string _0023_003DzUPTg1DPlXSwL, LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk)
	{
		if (_0023_003Dz8N608Vg_003D._0023_003Dz3ula2bcrtZB2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000181));
			return;
		}
		for (int i = 0; i < _0023_003Dz8N608Vg_003D._0023_003Dz3ula2bcrtZB2._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D.Length; i++)
		{
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003Dz8N608Vg_003D._0023_003Dz3ula2bcrtZB2._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D[i]._0023_003Dzsfb7U1TFH2wE);
			if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 == null || _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzEKSHIVc_003D != 51)
			{
				continue;
			}
			_0023_003DzKe2lNEm_MgUwP4PyvHMVEU9SmYpt _0023_003DzHdSqIFkmZYg = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzHdSqIFkmZYg2;
			if ((LayersToLoad != null && !LayersToLoad.Contains(_0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D)) || (_0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003Dzu0fdGj8uwG1b_0024Zs0cQ_003D_003D == '\u0001' && (string.IsNullOrEmpty(_0023_003Dzi_i_00249LM56LFZ) || !_0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D.StartsWith(_0023_003Dzi_i_00249LM56LFZ))))
			{
				continue;
			}
			Color color = _0023_003DzHzDodfEv0nnc(_0023_003DzHdSqIFkmZYg._0023_003Dz1MMYB1g_003D);
			bool visible = false;
			if (_0023_003DzHdSqIFkmZYg._0023_003Dzx8HrkQY_003D == '\0' && _0023_003DzHdSqIFkmZYg._0023_003DzBquWwrs_003D == '\0')
			{
				visible = true;
			}
			string lineTypeName = null;
			if (_0023_003DzHdSqIFkmZYg._0023_003Dz2ro_VwTtYYm9 != null && _0023_003Dzr0vuHde1OVHk.Contains(_0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003DzHdSqIFkmZYg._0023_003Dz2ro_VwTtYYm9._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzvVLGvrAoh3WE._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D))
			{
				lineTypeName = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003DzHdSqIFkmZYg._0023_003Dz2ro_VwTtYYm9._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzvVLGvrAoh3WE._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D;
			}
			float lineWeight = _0023_003DznZ_0024c4UJBVHLK3svo29coD_0024wi12Ua(_0023_003DzjNr_0024_0024QU_003D.kLnWtByLwDefault);
			if (Enum.TryParse<_0023_003DzjNr_0024_0024QU_003D>(_0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzpEyxzFEjatGqKIEdmNFbxQA_003D(_0023_003DzHdSqIFkmZYg._0023_003DzeThyx1uJ0LOH).ToString(), out var result))
			{
				lineWeight = _0023_003DznZ_0024c4UJBVHLK3svo29coD_0024wi12Ua(result);
			}
			if (_0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D != null && _0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D.Length != 0)
			{
				_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D[] _0023_003DzrHY7reY_003D = _0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D;
				foreach (_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2 in _0023_003DzrHY7reY_003D)
				{
					if (_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003Dzy0p1LSY_003D != null && _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D > 0)
					{
						_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D);
						if (((_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3._0023_003DzEKSHIVc_003D > 500) ? ((int)_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3._0023_003DzSoqwt5BxOhwWTmZWWA_003D_003D) : _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3._0023_003DzEKSHIVc_003D) == 67 && (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzKK3g9LjdIh8d)._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000135) && _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dz0QpYXqOmiv7H._0023_003DzVHJsUbk_003D != 0)
						{
							color = Color.FromArgb((int)(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dz0QpYXqOmiv7H._0023_003DzVHJsUbk_003D & 0xFFFFFF), color.R, color.G, color.B);
						}
					}
				}
			}
			Layer item = new Layer(_0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D, color, lineTypeName, lineWeight, visible, _0023_003DzHdSqIFkmZYg._0023_003DzfuwWUlY_003D == '\u0001');
			if (base.Layers.IndexOf(item) == -1)
			{
				base.Layers.Add(item);
			}
		}
	}

	private void _0023_003DzVXwZYbg_003D(_0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D._0023_003DzqGEUYVYcqGlx._0023_003DzwirtKpkYO_7ILOJtR7wi_0024Fk_003D == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000128));
			return;
		}
		_0023_003DzkCGkik_0024HuDFkeH_dw79j1LWXTOkiUAN6nQ_003D_003D _0023_003Dz0_QhICOOCFvT53E61w_003D_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D._0023_003DzqGEUYVYcqGlx._0023_003DzwirtKpkYO_7ILOJtR7wi_0024Fk_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz0_QhICOOCFvT53E61w_003D_003D;
		int _0023_003Dz5qQ2gcqSWdIeg4ZG_0024g_003D_003D = (int)_0023_003Dz0_QhICOOCFvT53E61w_003D_003D._0023_003Dz5qQ2gcqSWdIeg4ZG_0024g_003D_003D;
		for (int i = 0; i < _0023_003Dz5qQ2gcqSWdIeg4ZG_0024g_003D_003D; i++)
		{
			long _0023_003Dzsfb7U1TFH2wE = _0023_003Dz0_QhICOOCFvT53E61w_003D_003D._0023_003DzHd77rvksAZocL3PdbQ_003D_003D[i]._0023_003Dzsfb7U1TFH2wE;
			if (_0023_003Dzsfb7U1TFH2wE == 0L)
			{
				continue;
			}
			_0023_003DzYtH41PWn3yFoQ6oCri177uA_003D _0023_003DzuGC8k8Y_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzuGC8k8Y_003D;
			if (_0023_003DzuGC8k8Y_003D == null)
			{
				continue;
			}
			_0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzAU5e7ML4pj6L = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzuGC8k8Y_003D._0023_003DzxziTOkrXFzFi._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzAU5e7ML4pj6L;
			if (_0023_003DzAU5e7ML4pj6L._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D.TrimStart('*').ToUpper() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000073))
			{
				continue;
			}
			string _0023_003DzZy0UiHhu4lGX = _0023_003DzuGC8k8Y_003D._0023_003DzZy0UiHhu4lGX;
			_ = _0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DzYYb_0024S7vqPyjBwoTvYQ_003D_003D;
			double num = _0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DznkKFOVy_0024ulGDo8KVhw_003D_003D;
			double num2 = _0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DzNFmlvN1rthUz6gmY9w_003D_003D;
			double num3 = _0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DzbcQAxemSzoV4;
			double num4 = _0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DzSFzqnMsmq3EE;
			Point2D point2D = _0023_003DzUnxHUznPiV7g(_0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DzWp45xwswKefJ);
			double num5 = point2D.X;
			double num6 = point2D.Y;
			Point2D point2D2 = _0023_003DzUnxHUznPiV7g(_0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DzV5_0BddtfUFA1D7xkA_003D_003D);
			double num7 = (int)_0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DzidAfj7xB9tGpXMJaZQ_003D_003D;
			if (num7 == 1.0 || num7 == 3.0)
			{
				double num8 = num;
				num = num2;
				num2 = num8;
				double num9 = num3;
				num3 = num4;
				num4 = num9;
				double num10 = num5;
				num5 = num6;
				num6 = num10;
			}
			linearUnitsType linearUnitsType2 = _0023_003Dz8xTAk74d3tW9uU39Bg_003D_003D(_0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003Dz8tZJqsnTalu3BcnkO_PyS8Q_003D);
			if (linearUnitsType2 == linearUnitsType.Inches)
			{
				double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, linearUnitsType2);
				num *= linearUnitsConversionFactor;
				num2 *= linearUnitsConversionFactor;
				num3 *= linearUnitsConversionFactor;
				num4 *= linearUnitsConversionFactor;
				num5 *= linearUnitsConversionFactor;
				num6 *= linearUnitsConversionFactor;
				point2D2 *= linearUnitsConversionFactor;
			}
			double num11 = (_0023_003DzELu0Pss_003D._0023_003DzejwXvvKS0nx7OIb9lg_003D_003D = _0023_003DzuGC8k8Y_003D._0023_003DzQDjevqlrvKn_adVpktIlrS0_003D._0023_003DzTpGeuQIzwdCBeBzzFQ_003D_003D);
			Vector3D vector3D = new Vector3D(num3 + num5, num4 + num6, 0.0);
			Vector3D vector3D2 = new Vector3D(point2D2.X * num11, point2D2.Y * num11);
			Vector3D vector3D3 = vector3D + vector3D2;
			Transformation transformation = new Translation(vector3D3) * new Scaling(num11);
			PlotTransformations.Add(_0023_003DzZy0UiHhu4lGX, transformation);
			Sheet sheet = (_0023_003DzELu0Pss_003D._0023_003Dzow3wazApPFf_0024 = new Sheet(linearUnitsType2, num, num2, _0023_003DzZy0UiHhu4lGX, angleProjectionType.FirstAngle));
			if (_0023_003DzuGC8k8Y_003D._0023_003DzD5kyl_aymjMPjYevVFDVnGI_003D != 0)
			{
				_0023_003DzELu0Pss_003D._0023_003DzkabH3a5uOAQQ8hRWIg_003D_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzuGC8k8Y_003D._0023_003DzpMQfDQdMKpct._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D;
			}
			List<Entity> list = new List<Entity>();
			_0023_003DzfOBDTtTFrTm5(_0023_003DzAU5e7ML4pj6L, list, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzELu0Pss_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			foreach (Entity item in list)
			{
				_0023_003Dzu_0024TNsbNoY0XE(item, _0023_003DzELu0Pss_003D);
				if (item is View view)
				{
					view.X += vector3D3.X;
					view.Y += vector3D3.Y;
					continue;
				}
				item.TransformBy(transformation);
				if (item is Dimension dimension)
				{
					dimension.LinearScale /= num11;
				}
				if (!(item is BlockReference blockReference))
				{
					continue;
				}
				foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
				{
					Plane plane = attribute.Value.Plane;
					attribute.Value.Plane = new Plane(transformation * plane.Origin, transformation * plane.AxisX, transformation * plane.AxisY);
				}
			}
			sheet.Entities.AddRange(list);
			base.DrawingSheets.Add(sheet);
		}
	}

	private void _0023_003Dzu_0024TNsbNoY0XE(Entity _0023_003Dzs_0024uS8LA_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		if (_0023_003Dzs_0024uS8LA_003D.LineTypeName != null && !base.DrawingLineTypes.Contains(_0023_003Dzs_0024uS8LA_003D.LineTypeName))
		{
			base.DrawingLineTypes.Add((LineType)_0023_003DzELu0Pss_003D._0023_003Dzt1RSIVUh_0024mJh5IXfuw_003D_003D[_0023_003Dzs_0024uS8LA_003D.LineTypeName].Clone());
		}
		if (_0023_003Dzs_0024uS8LA_003D is Hatch { IsUserDefinedPattern: false } hatch && !hatch.PatternName.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485)) && !base.DrawingHatchPatterns.Contains(hatch.PatternName))
		{
			base.DrawingHatchPatterns.Add((HatchPattern)base.HatchPatterns[hatch.PatternName].Clone());
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Text text && !string.IsNullOrEmpty(text.StyleName) && !base.DrawingTextStyles.Contains(text.StyleName))
		{
			base.DrawingTextStyles.Add((TextStyle)_0023_003DzELu0Pss_003D._0023_003DzUkGYUZOWpxG4[text.StyleName].Clone());
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Table table)
		{
			for (int i = 0; i < table.RowsNum; i++)
			{
				for (int j = 0; j < table.ColumnsNum; j++)
				{
					string styleName = table.GetStyleName(i, j);
					if (!string.IsNullOrEmpty(styleName) && !base.DrawingTextStyles.Contains(styleName))
					{
						base.DrawingTextStyles.Add((TextStyle)_0023_003DzELu0Pss_003D._0023_003DzUkGYUZOWpxG4[styleName].Clone());
					}
				}
			}
		}
		if (!base.DrawingLayers.Contains(_0023_003Dzs_0024uS8LA_003D.LayerName))
		{
			Layer layer = base.Layers[_0023_003Dzs_0024uS8LA_003D.LayerName];
			base.DrawingLayers.Add((Layer)layer.Clone());
			if (layer.LineTypeName != null && !base.DrawingLineTypes.Contains(layer.LineTypeName))
			{
				base.DrawingLineTypes.Add((LineType)_0023_003DzELu0Pss_003D._0023_003Dzt1RSIVUh_0024mJh5IXfuw_003D_003D[layer.LineTypeName].Clone());
			}
		}
		if (!(_0023_003Dzs_0024uS8LA_003D is BlockReference blockReference))
		{
			return;
		}
		foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
		{
			AttributeReference value = attribute.Value;
			if (value.LineTypeName != null && !base.DrawingLineTypes.Contains(value.LineTypeName))
			{
				base.DrawingLineTypes.Add((LineType)_0023_003DzELu0Pss_003D._0023_003Dzt1RSIVUh_0024mJh5IXfuw_003D_003D[value.LineTypeName].Clone());
			}
			if (!string.IsNullOrEmpty(value.StyleName) && !base.DrawingTextStyles.Contains(value.StyleName))
			{
				base.DrawingTextStyles.Add((TextStyle)_0023_003DzELu0Pss_003D._0023_003DzUkGYUZOWpxG4[value.StyleName].Clone());
			}
			if (!base.DrawingLayers.Contains(value.LayerName))
			{
				base.DrawingLayers.Add((Layer)base.Layers[value.LayerName].Clone());
			}
		}
		_0023_003DzlT8V84X_AO1t(blockReference, _0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzlT8V84X_AO1t(BlockReference _0023_003Dz5I3b_GM_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		if (!_0023_003DzELu0Pss_003D._0023_003Dza0EiICLV_0024jmu.TryGetValue(_0023_003Dz5I3b_GM_003D.BlockName, out var value))
		{
			return;
		}
		if (!base.DrawingBlocks.Contains(value.Name))
		{
			base.DrawingBlocks.Add((Block)value.Clone());
		}
		foreach (Entity entity in value.Entities)
		{
			_0023_003Dzu_0024TNsbNoY0XE(entity, _0023_003DzELu0Pss_003D);
		}
	}

	private void _0023_003DzwXaUSxTMziQA(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D)
	{
		if (_0023_003Dz8N608Vg_003D._0023_003DzJgLPtwW2aRu5YTAUng_003D_003D == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000315));
		}
		else if (_0023_003Dz8N608Vg_003D._0023_003DzJgLPtwW2aRu5YTAUng_003D_003D._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D.Length == 0)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000242));
		}
		else
		{
			_0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003Dz8N608Vg_003D._0023_003DzJgLPtwW2aRu5YTAUng_003D_003D._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D[0]._0023_003Dzsfb7U1TFH2wE);
		}
	}

	private TextStyle _0023_003Dz6ZIsoVdTO_jk90za3Vza19TgahMi(_0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D _0023_003Dz6l9dids_003D, string _0023_003DzUPTg1DPlXSwL)
	{
		fontStyle fontStyle2 = fontStyle.Regular;
		string empty = string.Empty;
		_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2 = _0023_003Dz6l9dids_003D._0023_003DztbByVAY_003D._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D?.FirstOrDefault(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzvxmh89BnsZphAAUWbG3lS5ZEr97DZ6PuJfnB9SQ_003D);
		empty = ((_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2 != null && _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzmUmfvNoj7TIG._0023_003DzsKlTvtQ_003D.Length != 0 && _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzmUmfvNoj7TIG._0023_003DzsKlTvtQ_003D[0] != 0) ? new string(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzmUmfvNoj7TIG._0023_003DzsKlTvtQ_003D) : ((_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2 == null || _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzkCmn7_0024Q7J0kWxtGBMg_003D_003D._0023_003DzsKlTvtQ_003D.Length == 0 || _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzkCmn7_0024Q7J0kWxtGBMg_003D_003D._0023_003DzsKlTvtQ_003D[0] == '\0') ? _0023_003Dz6l9dids_003D._0023_003DzwLyFWnSeGDCe : new string(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D2._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzkCmn7_0024Q7J0kWxtGBMg_003D_003D._0023_003DzsKlTvtQ_003D)));
		bool flag = _0023_003Dz6l9dids_003D._0023_003DzMkQ8pC2FvwgggLExlQ_003D_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000194);
		bool flag2 = _0023_003Dz6l9dids_003D._0023_003DzMkQ8pC2FvwgggLExlQ_003D_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000203);
		_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D3 = _0023_003Dz6l9dids_003D._0023_003DztbByVAY_003D._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D?.FirstOrDefault(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzzUx0ocdbsfCtb71_E5JNWLhE2BGJWg6ygpcupmI_003D);
		if (_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D3 != null)
		{
			uint _0023_003DzVHJsUbk_003D = _0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D3._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dz0QpYXqOmiv7H._0023_003DzVHJsUbk_003D;
			flag = (_0023_003DzVHJsUbk_003D & 0x2000000) != 0;
			flag2 = (_0023_003DzVHJsUbk_003D & 0x1000000) != 0;
		}
		if (flag)
		{
			fontStyle2 |= fontStyle.Bold;
		}
		if (flag2)
		{
			fontStyle2 |= fontStyle.Italic;
		}
		return new TextStyle(_0023_003Dz6l9dids_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D, empty, fontStyle2, _0023_003Dz6l9dids_003D._0023_003Dzdl_0024F0ljq1J6w)
		{
			FileName = (string.IsNullOrEmpty(empty) ? _0023_003Dz6l9dids_003D._0023_003DzwLyFWnSeGDCe : null),
			XRefName = _0023_003DzUPTg1DPlXSwL
		};
	}

	private void _0023_003Dz_WPSEfrCWp3R(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (_0023_003Dz8N608Vg_003D._0023_003DzfQBvT1uETSVi == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000954));
			return;
		}
		if (_0023_003Dz8N608Vg_003D._0023_003DzfQBvT1uETSVi._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000908));
			return;
		}
		int num = _0023_003Dz8N608Vg_003D._0023_003DzfQBvT1uETSVi._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D.Length;
		for (int i = 0; i < num; i++)
		{
			long _0023_003Dzsfb7U1TFH2wE = _0023_003Dz8N608Vg_003D._0023_003DzfQBvT1uETSVi._0023_003DztbByVAY_003D._0023_003Dz2uhdYYE_003D[i]._0023_003Dzsfb7U1TFH2wE;
			if (_0023_003Dzsfb7U1TFH2wE == 0L)
			{
				continue;
			}
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003Dz8N608Vg_003D, _0023_003Dzsfb7U1TFH2wE);
			if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 == null)
			{
				continue;
			}
			_0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzAU5e7ML4pj6L = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzAU5e7ML4pj6L;
			string text = _0023_003DzAU5e7ML4pj6L._0023_003DzPyofyVbkaTED._0023_003DzCX9Hbao_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzGTziT4A_003D._0023_003DzS_00246o7tc_003D.TrimStart('*');
			if (text.ToUpper() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000073) || text.ToUpper().StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000840)))
			{
				continue;
			}
			string text2 = _0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ + text;
			string text3 = text;
			if (_0023_003DzELu0Pss_003D._0023_003Dza0EiICLV_0024jmu.Contains(text2))
			{
				if (_0023_003DzELu0Pss_003D._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB.ContainsKey(text2))
				{
					continue;
				}
				text3 = Utility.GetUnusedBlockName(text2, _0023_003DzELu0Pss_003D._0023_003Dza0EiICLV_0024jmu).Substring(_0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ.Length);
				_0023_003DzELu0Pss_003D._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB.Add(text2, text3);
			}
			_0023_003DzKu_0024hv_0024Sj4CMJ(_0023_003Dz8N608Vg_003D, _0023_003DzAU5e7ML4pj6L, text3, _0023_003DzELu0Pss_003D, _0023_003Dz47HBQmYeh1Ai, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			if (_0023_003Dz_0024Fk5VPw_003D)
			{
				break;
			}
			if (!UpdateProgressAndCheckCancelled(i, num, base.ParsingBlocksText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003Dz_0024Fk5VPw_003D = true;
				break;
			}
			if (i == num)
			{
				break;
			}
		}
		UpdateProgressTo100(base.ParsingBlocksText, _0023_003DzmHS7frs_003D);
	}

	[IteratorStateMachine(typeof(_0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D))]
	private IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> _0023_003DzCz0OQ_Yp_jht(_0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, _0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzLeyHB00_003D)
	{
		return new _0023_003Dzpuhy7L1tMnbFbwwVBg_003D_003D(-2)
		{
			_0023_003Dzja9gywQIhYG_ = _0023_003DzELu0Pss_003D,
			_0023_003DzGHtdVmb9aoff = _0023_003DzLeyHB00_003D
		};
	}

	private void _0023_003DzfOBDTtTFrTm5(_0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzRsVXxv6LgF5j, List<Entity> _0023_003DzuAKPwfU_003D, Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		ushort _0023_003Dzq4FsZ0nPyAxs = _0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D._0023_003DzqGEUYVYcqGlx._0023_003Dzq4FsZ0nPyAxs;
		_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D._0023_003DzqGEUYVYcqGlx._0023_003Dzq4FsZ0nPyAxs = 0;
		int num = 0;
		if (string.IsNullOrEmpty(_0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ))
		{
			_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D[] _0023_003Dzv7xH9gk_003D = _0023_003DzRsVXxv6LgF5j._0023_003Dzv7xH9gk_003D;
			num = ((_0023_003Dzv7xH9gk_003D != null) ? _0023_003Dzv7xH9gk_003D.Length : 0);
		}
		int num2 = num;
		num = 0;
		foreach (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D item in _0023_003DzCz0OQ_Yp_jht(_0023_003DzELu0Pss_003D, _0023_003DzRsVXxv6LgF5j))
		{
			if (item == null)
			{
				continue;
			}
			if (item._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D == null)
			{
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001082), _0023_003DzYylTTgozgnF29k_90g_003D_003D(item)));
				continue;
			}
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = item;
			_0023_003DzKe2lNEm_MgUwP4PyvHMVEU9SmYpt _0023_003DzHdSqIFkmZYg = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DztIaJjPw_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzHdSqIFkmZYg2;
			if (LayersToLoad == null || LayersToLoad.Contains(_0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D))
			{
				IEnumerable<Entity> enumerable = _0023_003Dz3u_0Ozo_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2, _0023_003DzELu0Pss_003D);
				if (enumerable != null)
				{
					_0023_003DzuAKPwfU_003D.AddRange(enumerable);
				}
				if (!UpdateProgressAndCheckCancelled(++num, num2, base.ParsingEntitiesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					_0023_003Dz_0024Fk5VPw_003D = true;
					break;
				}
			}
		}
		_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D._0023_003DzqGEUYVYcqGlx._0023_003Dzq4FsZ0nPyAxs = _0023_003Dzq4FsZ0nPyAxs;
		UpdateProgressTo100(base.ParsingEntitiesText, _0023_003DzmHS7frs_003D);
	}

	private void _0023_003DzKu_0024hv_0024Sj4CMJ(_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003Dz8N608Vg_003D, _0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzLeyHB00_003D, string _0023_003DznkMU43c_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		Point3D basePoint = _0023_003Dzmq2_arBswhAA(_0023_003DzLeyHB00_003D._0023_003DzxzzGfe9_Gs38);
		string text = _0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ + _0023_003DznkMU43c_003D;
		Block block = new Block(text, basePoint);
		block.Description = _0023_003DzLeyHB00_003D._0023_003DzmAgXdRQ_003D;
		block.Units = _0023_003Dz8xTAk74d3tW9uU39Bg_003D_003D(_0023_003DzLeyHB00_003D._0023_003DzvofhnS2eyDaU);
		_0023_003Dz2OiDJbg_003D _0023_003Dz2OiDJbg_003D2 = (_0023_003Dz2OiDJbg_003D)(block.CustomData = new _0023_003Dz2OiDJbg_003D());
		if (_0023_003DzLeyHB00_003D._0023_003Dz6yESPag_003D == '\u0001')
		{
			_0023_003Dz2OiDJbg_003D2._0023_003DzRkkYAZvv7ZOa(autodeskSourceType.Anonymous);
		}
		_0023_003Dz2OiDJbg_003D2._0023_003Dzwesjygcl_YuA((_0023_003DzLeyHB00_003D._0023_003DzEJnJBECqY7YhhO8hbA_003D_003D == '\u0001') ? autodeskExportType.ExternalReference : autodeskExportType.Embedded);
		if (_0023_003Dz2OiDJbg_003D2._0023_003DzPox_zz0iJaq7() == autodeskExportType.ExternalReference)
		{
			string _0023_003DzlMvDoAofvAHIDHoxKg_003D_003D = _0023_003DzLeyHB00_003D._0023_003DzlMvDoAofvAHIDHoxKg_003D_003D;
			string fileName = System.IO.Path.GetFileName(_0023_003DzlMvDoAofvAHIDHoxKg_003D_003D);
			if (_0023_003Dz8iuBhlRld1e9.Contains(fileName) || SkipExternalReferences)
			{
				return;
			}
			_0023_003Dz8iuBhlRld1e9.Add(fileName);
			string path = fileName;
			if (!File.Exists(path))
			{
				if (!string.IsNullOrEmpty(base.Path))
				{
					path = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(base.Path, new string[1] { _0023_003DzlMvDoAofvAHIDHoxKg_003D_003D });
				}
				if (!File.Exists(path) && SearchFolders != null)
				{
					for (int i = 0; i < SearchFolders.Count; i++)
					{
						path = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(SearchFolders[i], new string[1] { fileName });
						if (!File.Exists(path))
						{
							break;
						}
					}
				}
			}
			if (File.Exists(path))
			{
				_0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2 = new _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D();
				_0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzSIdxVMWGq6zH7lZVbg_003D_003D(new MemoryStream(File.ReadAllBytes(path)), _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2);
				string _0023_003Dzi_i_00249LM56LFZ = _0023_003DznkMU43c_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu;
				TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG;
				LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk;
				float _0023_003Dz8oMsDcyNkuDg;
				Point3D point3D;
				Point3D point3D2;
				IEnumerable<Entity> collection = _0023_003DzbezkkWk_003D(_0023_003Dzi_i_00249LM56LFZ, _0023_003DzELu0Pss_003D._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, _0023_003DzaIPnSuliJ0kc5I7LvQ_003D_003D2, _0023_003Dz47HBQmYeh1Ai, out _0023_003Dza0EiICLV_0024jmu, out _0023_003DzUkGYUZOWpxG, out _0023_003Dzr0vuHde1OVHk, out _0023_003Dz8oMsDcyNkuDg, out point3D, out point3D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
				if (_0023_003Dz_0024Fk5VPw_003D)
				{
					return;
				}
				block.Entities.AddRange(collection);
				foreach (Block item in _0023_003Dza0EiICLV_0024jmu)
				{
					if (!_0023_003DzELu0Pss_003D._0023_003Dza0EiICLV_0024jmu.Contains(item.Name))
					{
						_0023_003DzELu0Pss_003D._0023_003Dza0EiICLV_0024jmu.Add(item);
					}
				}
				_0023_003DzD_b88_0024aSBUyV(_0023_003DzUkGYUZOWpxG, _0023_003DzELu0Pss_003D._0023_003DzUkGYUZOWpxG4);
				_0023_003DzD_b88_0024aSBUyV(_0023_003Dzr0vuHde1OVHk, _0023_003DzELu0Pss_003D._0023_003Dzt1RSIVUh_0024mJh5IXfuw_003D_003D);
			}
			else if (!_0023_003Dz47HBQmYeh1Ai.ContainsKey(text))
			{
				_0023_003Dz47HBQmYeh1Ai.Add(text, _0023_003DzlMvDoAofvAHIDHoxKg_003D_003D);
			}
		}
		else
		{
			Block _0023_003DzSXqTc_00245giMaP = _0023_003DzELu0Pss_003D._0023_003DzSXqTc_00245giMaP;
			_0023_003DzELu0Pss_003D._0023_003DzSXqTc_00245giMaP = block;
			_0023_003DzOI_VfczqNrG7(_0023_003DzLeyHB00_003D, _0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D._0023_003DzSXqTc_00245giMaP = _0023_003DzSXqTc_00245giMaP;
		}
		block.IsResolved = _0023_003DzLeyHB00_003D._0023_003DztbByVAY_003D._0023_003DzKxxZH4WxjeLqPUopVw_003D_003D == 1;
		if ((_0023_003Dz2OiDJbg_003D2._0023_003DzPox_zz0iJaq7() == autodeskExportType.Embedded || block.IsResolved) && !string.IsNullOrEmpty(text) && !_0023_003DzELu0Pss_003D._0023_003Dza0EiICLV_0024jmu.Contains(text))
		{
			_0023_003DzELu0Pss_003D._0023_003Dza0EiICLV_0024jmu.Add(block);
		}
	}

	private void _0023_003DzOI_VfczqNrG7(_0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzLeyHB00_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		foreach (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D item in _0023_003DzCz0OQ_Yp_jht(_0023_003DzELu0Pss_003D, _0023_003DzLeyHB00_003D))
		{
			if (item == null)
			{
				continue;
			}
			if (item._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D == null)
			{
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001082), _0023_003DzYylTTgozgnF29k_90g_003D_003D(item)));
				continue;
			}
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = item;
			_0023_003DzKe2lNEm_MgUwP4PyvHMVEU9SmYpt _0023_003DzHdSqIFkmZYg = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DztIaJjPw_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzHdSqIFkmZYg2;
			if (LayersToLoad == null || LayersToLoad.Contains(_0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D))
			{
				IEnumerable<Entity> enumerable = _0023_003Dz3u_0Ozo_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2, _0023_003DzELu0Pss_003D);
				if (enumerable != null)
				{
					_0023_003DzELu0Pss_003D._0023_003DzSXqTc_00245giMaP.Entities.AddRange(enumerable);
				}
			}
		}
	}

	private protected virtual IEnumerable<Entity> _0023_003Dz3u_0Ozo_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		List<Entity> list = new List<Entity>();
		Entity entity = null;
		try
		{
			switch ((_0023_003DzfpN7pnryJplL._0023_003DzEKSHIVc_003D > 500) ? ((int)_0023_003DzfpN7pnryJplL._0023_003DzSoqwt5BxOhwWTmZWWA_003D_003D) : _0023_003DzfpN7pnryJplL._0023_003DzEKSHIVc_003D)
			{
			case 27:
				entity = _0023_003DzYW8_fbk_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 19:
				entity = _0023_003DzcvG8EU4_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 41:
				entity = _0023_003Dz_00249dhb4DTUG2p(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 17:
				entity = _0023_003DzNc2BB00_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 18:
				entity = _0023_003Dzbp0VrpRnjEGL(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 35:
				entity = _0023_003DzHBlwxd8_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 3:
				entity = _0023_003DzCGAW_0024kk_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 1:
				entity = _0023_003Dzfpt8uoA_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 44:
				entity = _0023_003DzDYm8KNE_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 45:
				entity = _0023_003DzkLREJtM_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 77:
				entity = _0023_003DzgU_7uU5MaplX7ygU9A_003D_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D, null);
				break;
			case 15:
				entity = _0023_003DzTwlzqt9JW4xI1su8WA_003D_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 16:
				entity = _0023_003DzT7JvkYG2_e5DlNpugQ_003D_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 36:
				entity = _0023_003Dzl6LkJd4_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 28:
				entity = _0023_003Dzg4ddAVY_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 8:
				return _0023_003DzxHijCgY_003D(_0023_003DzfpN7pnryJplL, list, _0023_003DzLpWyOE7im5SP(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D));
			case 716:
				entity = _0023_003DzFtZzkWs_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 7:
				entity = _0023_003DzTV0E4RQU4BKB(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 21:
				entity = _0023_003DzENcxqI_0024BKH1PCQp0tQ_003D_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 22:
				entity = _0023_003DzB8B0nHKDPlI6(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 20:
				entity = _0023_003DzoOHtxsENBiu8bEHdgg_003D_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 25:
				entity = _0023_003DznW93rAUBvf38(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 26:
				entity = _0023_003DzuRzGetAm14NIaaQeYNyCkHE_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 23:
				entity = _0023_003DzyXtdDh_3bSdUtCBHlX3aq10_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 24:
				entity = _0023_003DzOLOdi926iMAO4DSdUNx4mF0_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 526:
				entity = _0023_003Dzxu0pTpS29tic(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 31:
				entity = _0023_003Dz1vzybyo_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D, log);
				break;
			case 47:
				return _0023_003Dz047xcxuVWS6B(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			case 78:
				entity = _0023_003DzDRBMPy0_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			case 646:
				entity = _0023_003DzlnkplwW5eb4jKSLHlA_003D_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D, log);
				break;
			case 34:
				entity = _0023_003DzrhdupuI_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				break;
			default:
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001030), _0023_003DzfpN7pnryJplL.GetType(), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
				break;
			}
			if (entity != null)
			{
				if (entity.TranslationID == null)
				{
					entity.TranslationID = new TranslationIdentifier(_0023_003DzfpN7pnryJplL._0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D);
				}
				list.Add(entity);
			}
		}
		catch (Exception ex)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000991), _0023_003DzfpN7pnryJplL.GetType(), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
			log.AppendLine(ex.Message);
		}
		return list;
	}

	private Entity _0023_003DzxTalGOSuD6rc(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private bool _0023_003Dzs4u_SgWZHzKJya5Z0w_003D_003D(out Image _0023_003DzqwYd0N8_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzFtZzkWs_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzhH20_vyshI_0024v_0024t89s2sv27s_003D _0023_003DzHILNZdw_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzHILNZdw_003D;
		Vector3D vector3D = _0023_003DzlvGiL_QdgBbL(_0023_003DzHILNZdw_003D._0023_003DzksPLhezltPnwwLym0g_003D_003D);
		Vector3D a = _0023_003DzlvGiL_QdgBbL(_0023_003DzHILNZdw_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		Plane plane = new Plane(Point3D.Origin, vector3D, Vector3D.Cross(a, vector3D));
		Point3D origin = _0023_003Dzmq2_arBswhAA(_0023_003DzHILNZdw_003D._0023_003Dz0R7qasJeCI_s);
		plane.Origin = origin;
		Enum.TryParse<_0023_003Dzoq3_0024OjQA1tQF>(_0023_003DzHILNZdw_003D._0023_003Dzra_0024tAkvM_kD_0024.ToString(), out var result);
		Table.flowDirection direction = ((result == _0023_003Dzoq3_0024OjQA1tQF.kBtoT) ? Table.flowDirection.Up : Table.flowDirection.Down);
		int _0023_003Dz85J_0024UBMWN_wm = (int)_0023_003DzHILNZdw_003D._0023_003Dz85J_0024UBMWN_wm;
		int _0023_003DzsN771aAf_00241S = (int)_0023_003DzHILNZdw_003D._0023_003DzsN771aAf_00241S7;
		double[] rowsHeights = (double[])_0023_003DzHILNZdw_003D._0023_003Dz_l9q0l0G6eKVAKv7oQ_003D_003D.Clone();
		double[] columnsWidths = (double[])_0023_003DzHILNZdw_003D._0023_003DzjDn2CAROetPc_0024PSTig_003D_003D.Clone();
		_0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D _0023_003Dz4vDywqc_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzHILNZdw_003D._0023_003Dz8gBVPtGvezsOAq796w_003D_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz4vDywqc_003D;
		_ = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzHILNZdw_003D._0023_003DzPPGiEmZnNFLvHV3XJg_003D_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D;
		_ = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzHILNZdw_003D._0023_003Dz6GDUEVL9TACI7qJhKg_003D_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D;
		Table table = new Table(plane, _0023_003Dz85J_0024UBMWN_wm, _0023_003DzsN771aAf_00241S, rowsHeights, columnsWidths, _0023_003Dz4vDywqc_003D._0023_003Dzw_0024baBGpTBKVJ, direction);
		table.HorCellMargin = _0023_003DzHILNZdw_003D._0023_003Dz1gY2dKv5sCHA6XUcxA_003D_003D;
		table.VerCellMargin = _0023_003DzHILNZdw_003D._0023_003Dzv4KuWx0DVBxYYj3dBQ_003D_003D;
		for (int i = 0; i < _0023_003Dz85J_0024UBMWN_wm * _0023_003DzsN771aAf_00241S; i++)
		{
			int row = i / _0023_003DzsN771aAf_00241S;
			int col = i % _0023_003DzsN771aAf_00241S;
			_0023_003DzsK4PxEXDNuyj5qVjaZfY8cs_003D _0023_003DzsK4PxEXDNuyj5qVjaZfY8cs_003D2 = _0023_003DzHILNZdw_003D._0023_003DznKwOAQk_003D[i];
			_0023_003DzzLIUnNo_003D(_0023_003DzsK4PxEXDNuyj5qVjaZfY8cs_003D2._0023_003DzTx0oa42d7YEq, out var _, out var _, out var _);
			double _0023_003DzXjYzxWXnTO = _0023_003DzsK4PxEXDNuyj5qVjaZfY8cs_003D2._0023_003DzXjYzxWXnTO27;
			table.SetTextHeight(row, col, _0023_003DzXjYzxWXnTO);
			table.SetLineSpaceDistance(row, col, _0023_003DzXjYzxWXnTO * 5.0 / 3.0);
			string styleName = ((_0023_003DzsK4PxEXDNuyj5qVjaZfY8cs_003D2._0023_003DzIitOdbf_rrcE != null) ? _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzsK4PxEXDNuyj5qVjaZfY8cs_003D2._0023_003DzIitOdbf_rrcE._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz4vDywqc_003D : null)?._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000688);
			table.SetStyleName(row, col, styleName);
			Enum.TryParse<_0023_003DzC7KaYLVzq_0024HZ>(_0023_003DzsK4PxEXDNuyj5qVjaZfY8cs_003D2._0023_003DzKtKmMCrwaO6s.ToString(), out var result2);
			table.SetAlignment(row, col, _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(result2));
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(table, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return table;
	}

	private static string _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL)
	{
		return _0023_003DzfpN7pnryJplL._0023_003Dzy0p1LSY_003D._0023_003DzPzO_0024GUk_003D.ToString();
	}

	private void _0023_003DzuXPANacdFY07H_0024Q22w_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, ref List<Entity> _0023_003DzeC_DDe_0024a09Ii, ref Entity _0023_003Dzs_0024uS8LA_003D)
	{
		throw new NotImplementedException();
	}

	private static AutodeskProperties.visualStyleType _0023_003DzT6F8mm4K2az9(_0023_003DzoAg_0024juaWrAWC _0023_003DzzqWaf_0024HmEqo2)
	{
		return _0023_003DzzqWaf_0024HmEqo2 switch
		{
			_0023_003DzoAg_0024juaWrAWC.k2DWireframe => AutodeskProperties.visualStyleType.Wireframe2D, 
			_0023_003DzoAg_0024juaWrAWC.k3DWireframe => AutodeskProperties.visualStyleType.Wireframe, 
			_0023_003DzoAg_0024juaWrAWC.kHidden => AutodeskProperties.visualStyleType.Hidden, 
			_0023_003DzoAg_0024juaWrAWC.kRealistic => AutodeskProperties.visualStyleType.Realistic, 
			_0023_003DzoAg_0024juaWrAWC.kConceptual => AutodeskProperties.visualStyleType.Conceptual, 
			_0023_003DzoAg_0024juaWrAWC.kShaded => AutodeskProperties.visualStyleType.Shaded, 
			_0023_003DzoAg_0024juaWrAWC.kShadedWithEdges => AutodeskProperties.visualStyleType.ShadedWithEdges, 
			_0023_003DzoAg_0024juaWrAWC.kShadesOfGray => AutodeskProperties.visualStyleType.ShadesOfGray, 
			_0023_003DzoAg_0024juaWrAWC.kSketchy => AutodeskProperties.visualStyleType.Sketchy, 
			_0023_003DzoAg_0024juaWrAWC.kXRay => AutodeskProperties.visualStyleType.XRay, 
			_ => AutodeskProperties.visualStyleType.Realistic, 
		};
	}

	private Entity _0023_003DzrhdupuI_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D._0023_003DzkabH3a5uOAQQ8hRWIg_003D_003D == null || _0023_003DzELu0Pss_003D._0023_003DzkabH3a5uOAQQ8hRWIg_003D_003D.Equals(_0023_003DzfpN7pnryJplL))
		{
			return null;
		}
		_0023_003Dzo4cNEF3sJd_0024GYei_0024aPcYgowRgYNuid1bcQ_003D_003D _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D;
		_0023_003Dz62alrNM_003D _0023_003Dz62alrNM_003D2 = default(_0023_003Dz62alrNM_003D);
		_0023_003Dz62alrNM_003D2._0023_003DziWEQWvc_003D = _0023_003DzlvGiL_QdgBbL(_0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003DzKSMUNb92tuMd);
		_0023_003Dz62alrNM_003D2._0023_003DziWEQWvc_003D.Normalize();
		Transformation.AutocadOCS(_0023_003Dz62alrNM_003D2._0023_003DziWEQWvc_003D, out var xAxis, out var yAxis);
		yAxis.TransformBy(new Rotation(0.0 - _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003DzytuB6bQmIK7liuvHAw_003D_003D, _0023_003Dz62alrNM_003D2._0023_003DziWEQWvc_003D));
		_0023_003Dz62alrNM_003D2._0023_003DzG5DcWQMkTDXTkYfv5A_003D_003D = _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003DzxLDOtKxP8Ill;
		_0023_003Dz62alrNM_003D2._0023_003DzYUMqwZQ_003D = _0023_003DzlvGiL_QdgBbL(_0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003DzKSMUNb92tuMd).Length;
		_0023_003Dz62alrNM_003D2._0023_003Dzzo8RvXc_003D = _0023_003Dzmq2_arBswhAA(_0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz2L6xVKs3ik6_0024) + _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz6jn0Rb6OL3QG._0023_003DzBJFJHwk_003D * xAxis + _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz6jn0Rb6OL3QG._0023_003Dz40R7bAU_003D * yAxis;
		_0023_003Dz62alrNM_003D2._0023_003DzCBEAoWM_003D = new Vector3D(yAxis.ToArray());
		_0023_003Dz62alrNM_003D2._0023_003Dzbl24fQDH5pP9 = projectionType.Orthographic;
		double num = _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz6tVBpdk_003D;
		double num2 = _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003DzvAxV_0024Ic_003D;
		_0023_003Dz62alrNM_003D2._0023_003DzeYC4yc0gvh69 = new SizeF(100f, 100f);
		Size _0023_003Dz4BrWeV0_003D = new Size(100, 100);
		Camera camera = new Camera();
		_0023_003Dz62alrNM_003D2._0023_003Dzvk_j02M_003D(camera, _0023_003Dz4BrWeV0_003D);
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003DzbUvT9Pc_003D);
		linearUnitsType toUnits = _0023_003Dz8xTAk74d3tW9uU39Bg_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D._0023_003DzqGEUYVYcqGlx._0023_003Dz0ayzOq_0024Yy10ZmsJMbg_003D_003D);
		Utility.GetLinearUnitsConversionFactor(_0023_003DzELu0Pss_003D._0023_003Dzow3wazApPFf_0024.Units, toUnits);
		double num3 = 1.0;
		if (_0023_003DzELu0Pss_003D._0023_003DzejwXvvKS0nx7OIb9lg_003D_003D != 1.0)
		{
			num3 *= _0023_003DzELu0Pss_003D._0023_003DzejwXvvKS0nx7OIb9lg_003D_003D;
			point3D *= _0023_003DzELu0Pss_003D._0023_003DzejwXvvKS0nx7OIb9lg_003D_003D;
			num *= _0023_003DzELu0Pss_003D._0023_003DzejwXvvKS0nx7OIb9lg_003D_003D;
			num2 *= _0023_003DzELu0Pss_003D._0023_003DzejwXvvKS0nx7OIb9lg_003D_003D;
		}
		_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003DzB90jspOe_fPXYjAmMQ_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0);
		_0023_003DzoAg_0024juaWrAWC result;
		if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 != null)
		{
			Enum.TryParse<_0023_003DzoAg_0024juaWrAWC>(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz6SQ8MziUz_0024PGkmm83A_003D_003D._0023_003DzGogIJGLudYQu.ToString(), out result);
		}
		else
		{
			result = _0023_003DzoAg_0024juaWrAWC.kFlatWithEdges;
		}
		View view;
		switch (result)
		{
		case _0023_003DzoAg_0024juaWrAWC.k2DWireframe:
		case _0023_003DzoAg_0024juaWrAWC.k3DWireframe:
		case _0023_003DzoAg_0024juaWrAWC.kHidden:
			view = new VectorView(point3D.X, point3D.Y, camera, num3, _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz2QVVx8s_003D.ToString(), num, num2);
			break;
		case _0023_003DzoAg_0024juaWrAWC.kFlat:
		case _0023_003DzoAg_0024juaWrAWC.kFlatWithEdges:
			view = new RasterView(point3D.X, point3D.Y, camera, num3, _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz2QVVx8s_003D.ToString(), num, num2)
			{
				DisplayMode = displayType.Flat
			};
			break;
		case _0023_003DzoAg_0024juaWrAWC.kRealistic:
		case _0023_003DzoAg_0024juaWrAWC.kConceptual:
			view = new RasterView(point3D.X, point3D.Y, camera, num3, _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz2QVVx8s_003D.ToString(), num, num2)
			{
				DisplayMode = displayType.Rendered
			};
			break;
		case _0023_003DzoAg_0024juaWrAWC.kShadedWithEdges:
		case _0023_003DzoAg_0024juaWrAWC.kShaded:
			view = new RasterView(point3D.X, point3D.Y, camera, num3, _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz2QVVx8s_003D.ToString(), num, num2)
			{
				DisplayMode = displayType.Shaded
			};
			break;
		default:
			view = new RasterView(point3D.X, point3D.Y, camera, num3, _0023_003DzN8JGqZtRpRx31MO8Ig_003D_003D._0023_003Dz2QVVx8s_003D.ToString(), num, num2);
			break;
		}
		view.visualStyleMode = _0023_003DzT6F8mm4K2az9(result);
		if (view is VectorView vectorView)
		{
			vectorView.CenterlinesExtensionAmount = Math.Min(_0023_003DzELu0Pss_003D._0023_003Dzow3wazApPFf_0024.Width, _0023_003DzELu0Pss_003D._0023_003Dzow3wazApPFf_0024.Height) / 200.0;
			vectorView.HiddenSegments = true;
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(view, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return view;
	}

	private Entity _0023_003DzDYm8KNE_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzLS1KBXjm5ZDuK6u3sC023_0024j4C7Y4 _0023_003Dzp5SIhaysv4So = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dzp5SIhaysv4So;
		string _0023_003DzwyYng5o_003D = _0023_003Dzp5SIhaysv4So._0023_003DzwyYng5o_003D;
		double _0023_003DzXjYzxWXnTO = _0023_003Dzp5SIhaysv4So._0023_003DzXjYzxWXnTO27;
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dzp5SIhaysv4So._0023_003Dz0R7qasJeCI_s);
		_0023_003DzzLIUnNo_003D(_0023_003DzwyYng5o_003D, out var _0023_003DzyIUKu5w_003D, out var _0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D, out var _0023_003DzQdxCPUCTIzyF);
		_0023_003DzyIUKu5w_003D[0] = _0023_003DzmD2fQ5da9CZSb36vG_0024I5QCI_003D(_0023_003DzyIUKu5w_003D[0]);
		double lineSpaceDistance = _0023_003Dzp5SIhaysv4So._0023_003DzW08zH8jW3S4TvmW8mFISKKE_003D * _0023_003DzXjYzxWXnTO * 5.0 / 3.0;
		Enum.TryParse<AttachmentPoint>(_0023_003Dzp5SIhaysv4So._0023_003DzuqM0Lbg_003D.ToString(), out var result);
		Text.alignmentType alignment = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(result);
		double num = Utility.DegToRad(Utility.VectorsAngle(_0023_003DzlvGiL_QdgBbL(_0023_003Dzp5SIhaysv4So._0023_003DzPhR2e3io416T), Vector3D.AxisX, Plane.XY));
		Point3D insPoint = (Point3D)point3D.Clone();
		Enum.TryParse<_0023_003DzqFXknrKVx_0024Xn>(_0023_003Dzp5SIhaysv4So._0023_003Dzq0HvFyYZLZeP.ToString(), out var result2);
		if (result2 == _0023_003DzqFXknrKVx_0024Xn.BtoT)
		{
			num += Math.PI / 2.0;
		}
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dzp5SIhaysv4So._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), 0.0);
		plane.Rotate(num, plane.AxisZ, plane.Origin);
		string styleName = ((_0023_003Dzp5SIhaysv4So._0023_003Dz_0024wQZnFQ_003D != null) ? _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dzp5SIhaysv4So._0023_003Dz_0024wQZnFQ_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz4vDywqc_003D : null)?._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000688);
		if (!string.IsNullOrEmpty(_0023_003DzQdxCPUCTIzyF))
		{
			string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(_0023_003DzQdxCPUCTIzyF);
			if (!_0023_003DzELu0Pss_003D._0023_003DzUkGYUZOWpxG4.Contains(fileNameWithoutExtension))
			{
				if (!string.IsNullOrEmpty(_0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ))
				{
					_0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ.Substring(0, _0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ.Length - 1);
				}
				_0023_003DzELu0Pss_003D._0023_003DzUkGYUZOWpxG4.Add(new TextStyle(fileNameWithoutExtension, string.Empty, fontStyle.Regular)
				{
					FileName = _0023_003DzQdxCPUCTIzyF
				});
			}
			styleName = fileNameWithoutExtension;
		}
		MultilineText multilineText = new MultilineText(plane, insPoint, _0023_003Dz3lOHLrA_003D(_0023_003DzyIUKu5w_003D[0]), _0023_003Dzp5SIhaysv4So._0023_003DzguNAWXyud6Ch, _0023_003DzXjYzxWXnTO, lineSpaceDistance, alignment, styleName);
		multilineText.RectHeight = _0023_003Dzp5SIhaysv4So._0023_003Dzm8Vlsh7Kmtgg;
		multilineText.Contents = _0023_003Dzp5SIhaysv4So._0023_003DzwyYng5o_003D;
		if (_0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D != null)
		{
			multilineText.WidthFactors = _0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D;
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(multilineText, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		if (multilineText.TextString.Trim().Length > 0)
		{
			return multilineText;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000669), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
		return null;
	}

	private Entity _0023_003DzlnkplwW5eb4jKSLHlA_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, StringBuilder _0023_003DzFdTKfve582KK)
	{
		_0023_003Dz4HnBG68tzuSABb1UpX_lJiU_003D _0023_003DzTfEFvW0_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzTfEFvW0_003D;
		byte[] array = null;
		if (_0023_003DzTfEFvW0_003D == null)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000590), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
			return null;
		}
		if (_0023_003DzTfEFvW0_003D._0023_003DzikSaw_fT6lTAqbEjHA_003D_003D == null)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000590), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
			return null;
		}
		_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzTfEFvW0_003D._0023_003DzikSaw_fT6lTAqbEjHA_003D_003D._0023_003Dzsfb7U1TFH2wE);
		if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 == null)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000590), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
			return null;
		}
		_0023_003DzvJWxEENEFueiBsvEhizSgEFe0y0zhW6jVw_003D_003D _0023_003DzhiORTMf55heg8nIz3g_003D_003D = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzhiORTMf55heg8nIz3g_003D_003D;
		string text = null;
		if (!SkipExternalReferences)
		{
			text = _0023_003Dznd_0024R454_003D(_0023_003DzhiORTMf55heg8nIz3g_003D_003D._0023_003DzRqV_0024_nY41SJN);
		}
		if (text != null)
		{
			array = Utility._0023_003DzIpZE2cw6usPZ(text);
			Point3D p = _0023_003Dzmq2_arBswhAA(_0023_003DzTfEFvW0_003D._0023_003DzKjF_hSw_003D);
			Vector3D vector3D = _0023_003DzlvGiL_QdgBbL(_0023_003DzTfEFvW0_003D._0023_003Dz_0024P4mCGgOApqn) * _0023_003DzTfEFvW0_003D._0023_003Dz14lzA48_003D._0023_003DzBJFJHwk_003D;
			Vector3D vector3D2 = _0023_003DzlvGiL_QdgBbL(_0023_003DzTfEFvW0_003D._0023_003DzHjKdTBRurwA5) * _0023_003DzTfEFvW0_003D._0023_003Dz14lzA48_003D._0023_003Dz40R7bAU_003D;
			Plane plane = new Plane(p, vector3D, vector3D2);
			Picture picture = new Picture(plane, vector3D.Length, vector3D2.Length, array)
			{
				FilePath = text
			};
			picture.Lighted = false;
			if (_0023_003DzTfEFvW0_003D._0023_003Dz7bJvMRdHks7F_vGxOw_003D_003D == '\u0001')
			{
				Enum.TryParse<_0023_003Dz3dyK9gE0_0024Dqp>(_0023_003DzTfEFvW0_003D._0023_003DzvuWt2Hdx8j8e.ToString(), out var result);
				if (result != _0023_003Dz3dyK9gE0_0024Dqp.kInvalid)
				{
					_0023_003DzPK3LRelsWSan(_0023_003DzTfEFvW0_003D, plane, out var _0023_003Dz0ClAFJogap1KGtoTFxVkIyhbNVs_0024);
					picture.ClippingBoundary = new Polygon2D(_0023_003Dz0ClAFJogap1KGtoTFxVkIyhbNVs_0024);
					picture.ShowClipped = true;
				}
			}
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(picture, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			if (Utility._0023_003DzEZap865nk78Y(array))
			{
				picture.Color = Color.FromArgb(254, picture.Color);
			}
			return picture;
		}
		throw new NotImplementedException();
	}

	private string _0023_003Dznd_0024R454_003D(string _0023_003Dzsuiz4uo_003D)
	{
		if (string.IsNullOrEmpty(_0023_003Dzsuiz4uo_003D))
		{
			return null;
		}
		if (File.Exists(_0023_003Dzsuiz4uo_003D))
		{
			return _0023_003Dzsuiz4uo_003D;
		}
		string fileName = System.IO.Path.GetFileName(_0023_003Dzsuiz4uo_003D);
		if (File.Exists(fileName))
		{
			return fileName;
		}
		if (!string.IsNullOrEmpty(base.Path))
		{
			string text = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(base.Path, new string[1] { _0023_003Dzsuiz4uo_003D });
			if (File.Exists(text))
			{
				return text;
			}
			text = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(base.Path, new string[1] { fileName });
			if (File.Exists(text))
			{
				return text;
			}
		}
		if (SearchFolders != null)
		{
			foreach (string searchFolder in SearchFolders)
			{
				if (!string.IsNullOrEmpty(searchFolder))
				{
					string text2 = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(searchFolder, new string[1] { _0023_003Dzsuiz4uo_003D });
					if (File.Exists(text2))
					{
						return text2;
					}
					text2 = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(searchFolder, new string[1] { fileName });
					if (File.Exists(text2))
					{
						return text2;
					}
				}
			}
		}
		return null;
	}

	private void _0023_003DzPK3LRelsWSan(_0023_003Dz4HnBG68tzuSABb1UpX_lJiU_003D _0023_003DzcZP07lC8mnyB, Plane _0023_003DzfouwaYc0JbnN, out List<Point2D> _0023_003Dz0ClAFJogap1KGtoTFxVkIyhbNVs_0024)
	{
		List<Point2D> list = _0023_003DzcZP07lC8mnyB._0023_003DzbYidw16Bsd68D1Q0tQ_003D_003D.Select((_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003Dz77g161c_003D) => _0023_003DzUnxHUznPiV7g(_0023_003Dz77g161c_003D)).ToList();
		if (list.Count == 2)
		{
			list.Insert(1, new Point2D(list[0].X, list[1].Y));
			list.Add(new Point2D(list[2].X, list[0].Y));
			list.Add(list[0]);
		}
		List<Point3D> list2 = new List<Point3D>();
		_0023_003Dz0ClAFJogap1KGtoTFxVkIyhbNVs_0024 = new List<Point2D>();
		foreach (Point3D item in list2)
		{
			_0023_003Dz0ClAFJogap1KGtoTFxVkIyhbNVs_0024.Add(_0023_003DzfouwaYc0JbnN.Project(item));
		}
	}

	private static IEnumerable<Entity> _0023_003DzxHijCgY_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, List<Entity> _0023_003DzuAKPwfU_003D, IList<Entity> _0023_003DzyIjeB1Bf2138)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzMjyFtqiji3qL(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private IList<Entity> _0023_003DzLpWyOE7im5SP(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzAhCqvHRc4IZMWlScClLB1HSoV3gLMy2RBg_003D_003D _0023_003DzmWq5yVexUgkD = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzmWq5yVexUgkD;
		List<Entity> list = new List<Entity>(_0023_003DzmWq5yVexUgkD._0023_003DzO_0024xvpvo_003D * _0023_003DzmWq5yVexUgkD._0023_003DzmVsXTy4_003D);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003DzmWq5yVexUgkD._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), 0.0);
		Entity entity = _0023_003Dz8JpE3wJqYhqC(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		Vector3D vector3D = new Vector3D((plane.AxisX * _0023_003DzmWq5yVexUgkD._0023_003Dzxn1Q_0024jl94USQ0HXoNA_003D_003D).ToArray());
		Vector3D vector3D2 = new Vector3D((plane.AxisY * _0023_003DzmWq5yVexUgkD._0023_003DzKCKKPjxghRIM7GRKDQ_003D_003D).ToArray());
		for (int i = 0; i < _0023_003DzmWq5yVexUgkD._0023_003DzO_0024xvpvo_003D; i++)
		{
			for (int j = 0; j < _0023_003DzmWq5yVexUgkD._0023_003DzmVsXTy4_003D; j++)
			{
				Entity entity2 = (Entity)entity.Clone();
				Vector3D v = new Vector3D((vector3D2 * i + vector3D * j).ToArray());
				entity2.Translate(v);
				list.Add(entity2);
			}
		}
		return list;
	}

	private Entity _0023_003DzlmftVwI_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private List<Entity> _0023_003Dz047xcxuVWS6B(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzIO2ZloP00WGeXUDT3_RZHb4IOr3a _0023_003DzSNPRotMI31y = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzSNPRotMI31y0;
		Plane pln = _0023_003DztIc79mb2zQ0f(new double[3]
		{
			_0023_003DzSNPRotMI31y._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D._0023_003DzBJFJHwk_003D,
			_0023_003DzSNPRotMI31y._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D._0023_003Dz40R7bAU_003D,
			_0023_003DzSNPRotMI31y._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D._0023_003DzId5C3LA_003D
		}, 0.0);
		Point3D[] array = new Point3D[_0023_003DzSNPRotMI31y._0023_003DzZ86NWzV6mlAE.Length];
		for (int i = 0; i < _0023_003DzSNPRotMI31y._0023_003DzZ86NWzV6mlAE.Length; i++)
		{
			array[i] = new Point3D(_0023_003DzSNPRotMI31y._0023_003DzZ86NWzV6mlAE[i]._0023_003DzkEYxO1SuR1Kw._0023_003DzBJFJHwk_003D, _0023_003DzSNPRotMI31y._0023_003DzZ86NWzV6mlAE[i]._0023_003DzkEYxO1SuR1Kw._0023_003Dz40R7bAU_003D, _0023_003DzSNPRotMI31y._0023_003DzZ86NWzV6mlAE[i]._0023_003DzkEYxO1SuR1Kw._0023_003DzId5C3LA_003D);
		}
		List<Entity> list = new List<Entity>();
		LinearPath linearPath = new LinearPath(array);
		list.Add(linearPath);
		ICurve[] source = linearPath.QuickOffset(_0023_003DzSNPRotMI31y._0023_003DzoMBKEgY_003D, pln, cornerType.Miter);
		list.AddRange(source.Cast<Entity>());
		foreach (Entity item in list)
		{
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(item, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		}
		return list;
	}

	private BlockReference _0023_003Dz3saWoyFCPYaSjy2t1w_003D_003D(_0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, string _0023_003DznkMU43c_003D, _0023_003DzLRa1FCrMhpeH3ir8MQ_003D_003D _0023_003DzZ6L63kOJ5f2jN2Dr0Q_003D_003D, bool _0023_003DzNa9Dmjg_003D)
	{
		throw new NotImplementedException();
	}

	private List<Entity> _0023_003DzhXTnpsYq40AA6J7nJg_003D_003D(object[] _0023_003DzcrILBXg_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private List<Entity> _0023_003DzTarfA4M_003D(object[] _0023_003DzcrILBXg_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzNKwglGI_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private void _0023_003DzMgxbxPjGiu9O(Hatch _0023_003Dz1L3TZOcNA99t, _0023_003DzI7_00246CpuM2pwv _0023_003DzKvMQ6zg_003D, object _0023_003DzPzO_0024GUk_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzKvMQ6zg_003D == _0023_003DzI7_00246CpuM2pwv.PatternOrigin)
		{
			_0023_003Dz1L3TZOcNA99t.PatternOrigin = _0023_003Dzmq2_arBswhAA((_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D)_0023_003DzPzO_0024GUk_003D);
		}
	}

	private void _0023_003Dza3IECYHPW6Uu(Hatch _0023_003Dz1L3TZOcNA99t, _0023_003DzC8_AFnebcwUyTZxkDjjmIIXgzH_00241 _0023_003DzARMr0XOa9k_00249, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D[] _0023_003DzrHY7reY_003D = _0023_003DzARMr0XOa9k_00249._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D;
		if (_0023_003DzrHY7reY_003D == null)
		{
			return;
		}
		for (int i = 0; i < _0023_003DzrHY7reY_003D.Length; i++)
		{
			char _0023_003DzzsSfH74_003D = _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003DzzsSfH74_003D;
			if (_0023_003DzzsSfH74_003D == '\n')
			{
				Enum.TryParse<_0023_003DzI7_00246CpuM2pwv>(_0023_003DzzsSfH74_003D.ToString(), out var result);
				if (_0023_003DzzsSfH74_003D != 0 && _0023_003DzzsSfH74_003D == '\n')
				{
					_0023_003DzMgxbxPjGiu9O(_0023_003Dz1L3TZOcNA99t, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzorx6XD93y6m4._0023_003DzlY77YgY_003D, _0023_003DzELu0Pss_003D);
				}
			}
		}
	}

	private Entity _0023_003DzDRBMPy0_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzC8_AFnebcwUyTZxkDjjmIIXgzH_00241 _0023_003DzbxW9bVgwUFzG = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzbxW9bVgwUFzG;
		string text;
		if (_0023_003DzbxW9bVgwUFzG._0023_003DzC7_0024lP3ibl0U4ahF9yGFRWe4_003D == 1)
		{
			text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485);
		}
		else
		{
			text = _0023_003DzbxW9bVgwUFzG._0023_003DzS_00246o7tc_003D;
			Enum.TryParse<_0023_003DzrGZ3whQcd9GD>(_0023_003DzbxW9bVgwUFzG._0023_003DzQX3sb0GmLbT6.ToString(), out var result);
			if (result != _0023_003DzrGZ3whQcd9GD.kUserDefined && !base.HatchPatterns.Contains(text))
			{
				base.HatchPatterns.Add(_0023_003DzHSqIboHDImSB(text, _0023_003DzbxW9bVgwUFzG));
			}
		}
		List<ICurve> list = new List<ICurve>();
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzlvGiL_QdgBbL(_0023_003DzbxW9bVgwUFzG._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D).ToArray(), _0023_003DzbxW9bVgwUFzG._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		for (int i = 0; i < _0023_003DzbxW9bVgwUFzG._0023_003DzFichXsSONLlX; i++)
		{
			_0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q _0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q2 = _0023_003DzbxW9bVgwUFzG._0023_003DzCULckQQ_003D[i];
			if (_0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q2._0023_003DzMS5GHWfCAF58VFBtfA_003D_003D != null)
			{
				int num = _0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q2._0023_003DzMS5GHWfCAF58VFBtfA_003D_003D.Length;
				_0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D _0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D2 = new _0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D
				{
					_0023_003DzrdSL0CI_003D = new _0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D[num],
					_0023_003Dzl854Q0bMjSxQ = (uint)num,
					_0023_003DzSDLnxKBqGfZ7 = new double[num],
					_0023_003Dz474kkOleOJyc = new _0023_003Dzk_00247DjARjCBnWeRU7kqI5lJ_0024wsaBws1yGkA_003D_003D[num],
					_0023_003Dzjcx0hV4_003D = (ushort)((_0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q2._0023_003DzbErHvVw_003D == '\u0001') ? 512 : 0)
				};
				for (int j = 0; j < _0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q2._0023_003DzMS5GHWfCAF58VFBtfA_003D_003D.Length; j++)
				{
					_0023_003DzisGtdpEc86Q3Jsi6rrYCmtjr8JtBnnlTH9R6smo_003D _0023_003DzisGtdpEc86Q3Jsi6rrYCmtjr8JtBnnlTH9R6smo_003D2 = _0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q2._0023_003DzMS5GHWfCAF58VFBtfA_003D_003D[j];
					_0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D2._0023_003DzrdSL0CI_003D[j] = _0023_003DzisGtdpEc86Q3Jsi6rrYCmtjr8JtBnnlTH9R6smo_003D2._0023_003DzlY77YgY_003D;
					_0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D2._0023_003DzSDLnxKBqGfZ7[j] = _0023_003DzisGtdpEc86Q3Jsi6rrYCmtjr8JtBnnlTH9R6smo_003D2._0023_003Dzo9ajQUuoihC2;
				}
				_0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D2._0023_003DzCL1XEBfKPNlTfjRcOg_003D_003D = (uint)_0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D2._0023_003DzSDLnxKBqGfZ7.Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz24PRTcNFUckosZ72QjRoGuM_003D);
				_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL2 = new _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D
				{
					_0023_003DzRLZJ5Uk_003D = new _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D._0023_003Dz1aH9cSAjVUbu
					{
						_0023_003Dz9j7EUB0_003D = new _0023_003DzEg6_Cd8VKxjdkr0v1E_0024vWxQ_003D
						{
							_0023_003DzRLZJ5Uk_003D = new _0023_003DzEg6_Cd8VKxjdkr0v1E_0024vWxQ_003D._0023_003Dz1aH9cSAjVUbu
							{
								_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D = _0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D2
							},
							_0023_003DzeThyx1uJ0LOH = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzeThyx1uJ0LOH
						}
					}
				};
				ICurve item = _0023_003DzgU_7uU5MaplX7ygU9A_003D_003D(_0023_003DzfpN7pnryJplL2, _0023_003DzELu0Pss_003D, null) as ICurve;
				list.Add(item);
				continue;
			}
			List<ICurve> list2 = new List<ICurve>();
			for (int k = 0; k < _0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q2._0023_003DzwzkUcc_0024WYwGprQEAuTKFG4I_003D; k++)
			{
				_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC5 _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6 = _0023_003DzGnN8g3pVzss0YAt2fehPTDsXB32Q2._0023_003Dz6DFTd2VbHmYd[k];
				if (_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzX_bjfACpRara == '\u0001')
				{
					Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzYrKWGPFLq_78);
					Point3D point3D2 = _0023_003Dzmq2_arBswhAA(_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzJKKT8w2JlZOn);
					if (!(Point3D.DistanceSquared(point3D, point3D2) < 1E-12))
					{
						Line item2 = new Line(plane.PointAt(point3D), plane.PointAt(point3D2));
						list2.Add(item2);
					}
					continue;
				}
				if (_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzX_bjfACpRara == '\u0002')
				{
					Point2D point2D = new Point2D(_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzbUvT9Pc_003D._0023_003DzBJFJHwk_003D, _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzbUvT9Pc_003D._0023_003Dz40R7bAU_003D);
					Plane plane2 = (Plane)plane.Clone();
					double _0023_003Dz_gbL4wz7_0024Ge = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003Dz_gbL4wz7_0024Ge1;
					double _0023_003DzTruHvE_0024PuoOB = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzTruHvE_0024PuoOB;
					if (_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003Dzo9SepbWOgtcG == '\0')
					{
						plane2 = new Plane(plane2.Origin, plane2.AxisX, -1.0 * plane2.AxisY);
						point2D = plane2.Project(plane.PointAt(point2D));
					}
					list2.Add(Utility.AreEqual(_0023_003DzTruHvE_0024PuoOB - _0023_003Dz_gbL4wz7_0024Ge, Math.PI * 2.0, Math.PI * 2.0) ? new Circle(plane2, point2D, _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzEGKj_0024SNUUihi) : new Arc(plane2, point2D, _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzEGKj_0024SNUUihi, _0023_003Dz_gbL4wz7_0024Ge, _0023_003DzTruHvE_0024PuoOB));
					continue;
				}
				if (_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzX_bjfACpRara == '\u0003')
				{
					Point3D pt = _0023_003Dzmq2_arBswhAA(_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzbUvT9Pc_003D);
					Vector3D vector3D = new Vector3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzXq1BPpQ_003D));
					Vector3D b = ((_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003Dzo9SepbWOgtcG == '\u0001') ? (-1.0 * plane.AxisZ) : plane.AxisZ);
					Vector3D vector3D2 = Vector3D.Cross(vector3D, b);
					vector3D2.Normalize();
					Vector3D vector3D3 = new Vector3D(_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzvHQqcBrLCD8Zivs0dg_003D_003D * vector3D.Length * vector3D2.X, _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzvHQqcBrLCD8Zivs0dg_003D_003D * vector3D.Length * vector3D2.Y, _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzvHQqcBrLCD8Zivs0dg_003D_003D * vector3D.Length * vector3D2.Z);
					Plane plane3 = new Plane(plane.Origin, vector3D, vector3D3);
					Point2D center = plane3.Project(plane.PointAt(pt));
					list2.Add(Utility.AreEqual(_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzTruHvE_0024PuoOB - _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003Dz_gbL4wz7_0024Ge1, Math.PI * 2.0, Math.PI * 2.0) ? new Ellipse(plane3, center, vector3D.Length, vector3D3.Length) : new EllipticalArc(plane3, center, vector3D.Length, vector3D3.Length, _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003Dz_gbL4wz7_0024Ge1, _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzTruHvE_0024PuoOB));
					continue;
				}
				if (_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzX_bjfACpRara == '\u0004')
				{
					_0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP _0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP2 = new _0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP
					{
						_0023_003Dz2rdX29E_003D = 1,
						_0023_003DzU7eDCS_XZhhv = (ushort)_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzU7eDCS_XZhhv,
						_0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzI9RHnR4XCCgj3TUoJQ_003D_003D,
						_0023_003DzzBglnhwdR3VArgpYbQ_003D_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzyffpZdA2oPxJXpF3LQ_003D_003D,
						_0023_003DzqLg2YxLQcCSiAYLQHw_003D_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzqLg2YxLQcCSiAYLQHw_003D_003D,
						_0023_003DzWnkJjDtu2bda38hXSw_003D_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzqNp7yXAvGxZe2KjGIg_003D_003D,
						_0023_003Dzr7tgnwG7XK6N = new double[_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzqLg2YxLQcCSiAYLQHw_003D_003D],
						_0023_003Dz2yaeB8fJ9fBB = new _0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D[_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzqNp7yXAvGxZe2KjGIg_003D_003D],
						_0023_003DzJ_dbzFrlaoXxUEjiLw_003D_003D = (ushort)_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzGzdQjd28ilTxQBSLyw_003D_003D,
						_0023_003Dz_STl1YXQKrP3 = new _0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D[_0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzGzdQjd28ilTxQBSLyw_003D_003D],
						_0023_003DzUt7m5dcZ9582Avz_Gg_003D_003D = new _0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D
						{
							_0023_003DzBJFJHwk_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzmHuN_HszKd_NssbiUA_003D_003D._0023_003DzBJFJHwk_003D,
							_0023_003Dz40R7bAU_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzmHuN_HszKd_NssbiUA_003D_003D._0023_003Dz40R7bAU_003D,
							_0023_003DzId5C3LA_003D = 0.0
						},
						_0023_003DzpiXCdUL_0024nFXC5N_0024iBw_003D_003D = new _0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D
						{
							_0023_003DzBJFJHwk_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzGWtllAWh2CMQ17vZYA_003D_003D._0023_003DzBJFJHwk_003D,
							_0023_003Dz40R7bAU_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzGWtllAWh2CMQ17vZYA_003D_003D._0023_003Dz40R7bAU_003D,
							_0023_003DzId5C3LA_003D = 0.0
						}
					};
					for (int l = 0; l < _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzqLg2YxLQcCSiAYLQHw_003D_003D; l++)
					{
						_0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP2._0023_003Dzr7tgnwG7XK6N[l] = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003Dzr7tgnwG7XK6N[l];
					}
					for (int m = 0; m < _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzqNp7yXAvGxZe2KjGIg_003D_003D; m++)
					{
						_0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP2._0023_003Dz2yaeB8fJ9fBB[m] = new _0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D
						{
							_0023_003DzBJFJHwk_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzIyTwAk4zYM2h[m]._0023_003DzlY77YgY_003D._0023_003DzBJFJHwk_003D,
							_0023_003Dz40R7bAU_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzIyTwAk4zYM2h[m]._0023_003DzlY77YgY_003D._0023_003Dz40R7bAU_003D,
							_0023_003DzId5C3LA_003D = 0.0,
							_0023_003DzAvn2b38_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzIyTwAk4zYM2h[m]._0023_003Dz_wp2sAU_003D
						};
					}
					for (int n = 0; n < _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzGzdQjd28ilTxQBSLyw_003D_003D; n++)
					{
						_0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP2._0023_003Dz_STl1YXQKrP3[n] = new _0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D
						{
							_0023_003DzBJFJHwk_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzoCHBJGxE9KUk[n]._0023_003DzBJFJHwk_003D,
							_0023_003Dz40R7bAU_003D = _0023_003DzRj0oSIvy0ugjIiIM6NlSLa1FzoC6._0023_003DzoCHBJGxE9KUk[n]._0023_003Dz40R7bAU_003D
						};
					}
					_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL3 = new _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D
					{
						_0023_003DzRLZJ5Uk_003D = new _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D._0023_003Dz1aH9cSAjVUbu
						{
							_0023_003Dz9j7EUB0_003D = new _0023_003DzEg6_Cd8VKxjdkr0v1E_0024vWxQ_003D
							{
								_0023_003DzRLZJ5Uk_003D = new _0023_003DzEg6_Cd8VKxjdkr0v1E_0024vWxQ_003D._0023_003Dz1aH9cSAjVUbu
								{
									_0023_003DzP9yM7Jgz_mJc = _0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP2
								},
								_0023_003DzeThyx1uJ0LOH = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzeThyx1uJ0LOH
							}
						}
					};
					ICurve item3 = _0023_003Dzl6LkJd4_003D(_0023_003DzfpN7pnryJplL3, _0023_003DzELu0Pss_003D) as ICurve;
					list2.Add(item3);
					continue;
				}
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000798), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
				return null;
			}
			if (list2.Count > 1)
			{
				list.Add(new CompositeCurve(list2));
			}
			else if (list2.Count == 1)
			{
				list.Add(list2[0]);
			}
		}
		if (list.Count > 0)
		{
			_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D valueOrDefault = (_0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzrHY7reY_003D?.FirstOrDefault(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz8gRmDqK6o5C3TThQpT_F57s_003D)?._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzorx6XD93y6m4._0023_003DzlY77YgY_003D).GetValueOrDefault();
			Hatch hatch = new Hatch(text, list, plane)
			{
				PatternScale = (float)_0023_003DzbxW9bVgwUFzG._0023_003DzPhDSgjTLbbd8t7BRbQ_003D_003D,
				PatternAngle = _0023_003DzbxW9bVgwUFzG._0023_003Dz6pajdGM_003D,
				PatternOrigin = new Point3D(valueOrDefault._0023_003DzBJFJHwk_003D, valueOrDefault._0023_003Dz40R7bAU_003D),
				PatternSpacing = _0023_003DzbxW9bVgwUFzG._0023_003DzPhDSgjTLbbd8t7BRbQ_003D_003D,
				PatternDouble = (_0023_003DzbxW9bVgwUFzG._0023_003DzwT8Ifiidc_00246F == '\u0001'),
				IsUserDefinedPattern = (_0023_003DzbxW9bVgwUFzG._0023_003DzQX3sb0GmLbT6 == 0)
			};
			_0023_003Dza3IECYHPW6Uu(hatch, _0023_003DzbxW9bVgwUFzG, _0023_003DzELu0Pss_003D);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(hatch, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			return hatch;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000720), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
		return null;
	}

	private HatchPattern _0023_003DzHSqIboHDImSB(string _0023_003DzS5V6fD8_003D, _0023_003DzC8_AFnebcwUyTZxkDjjmIIXgzH_00241 _0023_003DzQpPe45a1ZHXq)
	{
		HatchPatternLine[] array = new HatchPatternLine[_0023_003DzQpPe45a1ZHXq._0023_003DzHmkvg22LCcuOdGn_IQ_003D_003D];
		double num = _0023_003DzgRf1Kl0_003D(_0023_003DzQpPe45a1ZHXq._0023_003DzPhDSgjTLbbd8t7BRbQ_003D_003D);
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP _0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2 = _0023_003DzQpPe45a1ZHXq._0023_003Dz3JS0zqyMwuZVLY_0024nYw_003D_003D[i];
			float[] array2 = new float[_0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003Dz9AdWyDpcQrDA_0024nMZuw_003D_003D];
			for (int j = 0; j < _0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003Dz9AdWyDpcQrDA_0024nMZuw_003D_003D; j++)
			{
				array2[j] = (float)(_0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003Dzt5qQHCWPJf_A[j] / num);
			}
			if (!LineType.CheckPattern(array2, throwEx: false, out var _))
			{
				array2 = new float[0];
			}
			_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D _0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D2 = _0023_003DzQpPe45a1ZHXq._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D?.First(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzn0qxT4dFOrOWF3XOdOiq9dg_003D)._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzorx6XD93y6m4._0023_003DzlY77YgY_003D ?? default(_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D);
			Point3D point3D = new Point3D(_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D2._0023_003DzBJFJHwk_003D, _0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D2._0023_003Dz40R7bAU_003D);
			Point3D point3D2 = new Point3D(_0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003DzKjF_hSw_003D._0023_003DzBJFJHwk_003D, _0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003DzKjF_hSw_003D._0023_003Dz40R7bAU_003D);
			Point3D point3D3 = new Point3D(_0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003DzfBEBL_o_003D._0023_003DzBJFJHwk_003D, _0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003DzfBEBL_o_003D._0023_003Dz40R7bAU_003D);
			Scaling scaling = new Scaling(1.0 / num);
			Rotation rotation = new Rotation(_0023_003DzQpPe45a1ZHXq._0023_003Dz6pajdGM_003D, Vector3D.AxisMinusZ);
			point3D2.TransformBy(scaling * rotation * new Translation(-1.0 * point3D.AsVector));
			point3D3.TransformBy(new Rotation(_0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003Dz6pajdGM_003D - _0023_003DzQpPe45a1ZHXq._0023_003Dz6pajdGM_003D, Vector3D.AxisMinusZ) * scaling * rotation);
			double num2 = _0023_003DzbBAZi46W1zumbX_R5ThcNJ_0024y3TnP2._0023_003Dz6pajdGM_003D - _0023_003DzQpPe45a1ZHXq._0023_003Dz6pajdGM_003D;
			if (num2 < 0.0)
			{
				num2 += Math.PI * 2.0;
			}
			array[i] = new HatchPatternLine(num2, new Point2D(point3D2.X, point3D2.Y), point3D3.X, point3D3.Y, array2);
		}
		return new HatchPattern(_0023_003DzS5V6fD8_003D, array);
	}

	private Entity _0023_003Dzoxqi4p0vqgDY(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzYW8_fbk_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003Dz3O9trta_0024Jv6ZVdqoB0EBNMY_003D _0023_003DzqBYbG5Y_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzqBYbG5Y_003D;
		devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D(_0023_003DzgRf1Kl0_003D(_0023_003DzqBYbG5Y_003D._0023_003DzBJFJHwk_003D), _0023_003DzgRf1Kl0_003D(_0023_003DzqBYbG5Y_003D._0023_003Dz40R7bAU_003D), _0023_003DzgRf1Kl0_003D(_0023_003DzqBYbG5Y_003D._0023_003DzId5C3LA_003D)));
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(point, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return point;
	}

	private Entity _0023_003DzcvG8EU4_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzV_00240n1_1uATTWCE9i_hZgj_0024o_003D _0023_003Dz51iYAwc_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz51iYAwc_003D;
		Point3D start = _0023_003Dzmq2_arBswhAA(_0023_003Dz51iYAwc_003D._0023_003DzAqOpw0w_003D);
		Point3D end = _0023_003Dzmq2_arBswhAA(_0023_003Dz51iYAwc_003D._0023_003Dzk64JNOo_003D);
		Line line = new Line(start, end);
		Vector3D vector3D = _0023_003DzlvGiL_QdgBbL(_0023_003Dz51iYAwc_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		if (line.Length() < Utility._0023_003DzheSR8QM7q9ya)
		{
			devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(line.StartPoint);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(point, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			point.AutodeskProperties.Thickness = _0023_003Dz51iYAwc_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D;
			point.AutodeskProperties.ExtrusionDir = vector3D;
			return point;
		}
		if (_0023_003Dz51iYAwc_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D == 0.0 || !ExtrudeByThickness)
		{
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(line, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			line.AutodeskProperties.Thickness = _0023_003Dz51iYAwc_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D;
			line.AutodeskProperties.ExtrusionDir = vector3D;
			return line;
		}
		Entity entity = line.ExtrudeAsBrep(vector3D * _0023_003Dz51iYAwc_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return entity;
	}

	private Entity _0023_003Dz_00249dhb4DTUG2p(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DznawwDHFLXbB6f9xKqr7PAULnJyH9 _0023_003DzZ1XKaaex6Dos = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzZ1XKaaex6Dos;
		Point3D position = _0023_003Dzmq2_arBswhAA(_0023_003DzZ1XKaaex6Dos._0023_003DzlY77YgY_003D);
		Vector3D vector3D = _0023_003DzlvGiL_QdgBbL(_0023_003DzZ1XKaaex6Dos._0023_003DzY5pSLwI_003D);
		LinearEntity linearEntity = new LinearEntity(position, vector3D, vector3D.Length);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearEntity, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return linearEntity;
	}

	private Entity _0023_003DzNc2BB00_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003Dzb5sxvL6oXq2Ju1EX7EVolqzP_ECX _0023_003Dz_0024ojHEdo_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz_0024ojHEdo_003D;
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dz_0024ojHEdo_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), 0.0);
		double _0023_003DzSeznUY9fyh7N = _0023_003Dz_0024ojHEdo_003D._0023_003DzTruHvE_0024PuoOB;
		double _0023_003DzXWCF4rA_003D = (_0023_003Dz_0024ojHEdo_003D._0023_003Dz_gbL4wz7_0024Ge1 - _0023_003Dz_0024ojHEdo_003D._0023_003DzTruHvE_0024PuoOB) / 2.0 * Math.Pow(_0023_003Dz_0024ojHEdo_003D._0023_003DzEGKj_0024SNUUihi, 2.0);
		_0023_003Dzh0LtzHPRUFkd(_0023_003Dz_0024ojHEdo_003D._0023_003Dz_gbL4wz7_0024Ge1, ref _0023_003DzSeznUY9fyh7N, _0023_003DzXWCF4rA_003D);
		if (_0023_003Dz_0024ojHEdo_003D._0023_003DzEGKj_0024SNUUihi > 1E-12)
		{
			Point3D center = _0023_003Dz_0024ojHEdo_003D._0023_003DzbUvT9Pc_003D._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane);
			Arc arc = new Arc(plane, center, _0023_003Dz_0024ojHEdo_003D._0023_003DzEGKj_0024SNUUihi, _0023_003Dz_0024ojHEdo_003D._0023_003Dz_gbL4wz7_0024Ge1, _0023_003DzSeznUY9fyh7N);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(arc, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			Vector3D vector3D = _0023_003DzlvGiL_QdgBbL(_0023_003Dz_0024ojHEdo_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
			if (_0023_003Dz_0024ojHEdo_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D == 0.0 || !ExtrudeByThickness)
			{
				_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(arc, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				arc.AutodeskProperties.Thickness = _0023_003Dz_0024ojHEdo_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D;
				arc.AutodeskProperties.ExtrusionDir = vector3D;
				return arc;
			}
			Entity entity = arc.ExtrudeAsBrep(vector3D * _0023_003Dz_0024ojHEdo_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			return entity;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001393), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
		return null;
	}

	private static void _0023_003Dzh0LtzHPRUFkd(double _0023_003Dz3veEI49c6b6Q, ref double _0023_003DzSeznUY9fyh7N, double _0023_003DzXWCF4rA_003D)
	{
		if (_0023_003DzSeznUY9fyh7N < _0023_003Dz3veEI49c6b6Q)
		{
			_0023_003DzSeznUY9fyh7N += Math.PI * 2.0;
		}
		else if (Math.Abs(_0023_003DzSeznUY9fyh7N - _0023_003Dz3veEI49c6b6Q) < 1E-12)
		{
			if (!(_0023_003DzXWCF4rA_003D > 0.0))
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955100));
			}
			_0023_003DzSeznUY9fyh7N += Math.PI * 2.0;
		}
	}

	private Entity _0023_003Dzbp0VrpRnjEGL(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzLW2H7FYC8Twmc8nmzf4o21Abj6v9 _0023_003Dzkf0rqaL5G6i_0024 = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dzkf0rqaL5G6i_0024;
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dzkf0rqaL5G6i_0024._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), 0.0);
		if (_0023_003Dzkf0rqaL5G6i_0024._0023_003DzEGKj_0024SNUUihi > 1E-12)
		{
			Point3D center = _0023_003Dzkf0rqaL5G6i_0024._0023_003DzbUvT9Pc_003D._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane);
			Circle circle = new Circle(plane, center, _0023_003Dzkf0rqaL5G6i_0024._0023_003DzEGKj_0024SNUUihi);
			Vector3D vector3D = _0023_003DzlvGiL_QdgBbL(_0023_003Dzkf0rqaL5G6i_0024._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(circle, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			if (_0023_003Dzkf0rqaL5G6i_0024._0023_003Dzetc0sjwdrddceszzig_003D_003D == 0.0 || !ExtrudeByThickness)
			{
				_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(circle, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				circle.AutodeskProperties.Thickness = _0023_003Dzkf0rqaL5G6i_0024._0023_003Dzetc0sjwdrddceszzig_003D_003D;
				circle.AutodeskProperties.ExtrusionDir = vector3D;
				return circle;
			}
			Entity entity = circle.ExtrudeAsBrep(vector3D * _0023_003Dzkf0rqaL5G6i_0024._0023_003Dzetc0sjwdrddceszzig_003D_003D);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			return entity;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001589), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
		return null;
	}

	private Entity _0023_003DzHBlwxd8_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzhtZCf9VqUt5d_0024G_0024OSOpppPwUoGdwUU2n_0024Q_003D_003D _0023_003DzB1KfqX_0024SCu2_0024 = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzB1KfqX_0024SCu2_0024;
		Vector3D xAxis = new Vector3D();
		Vector3D yAxis = new Vector3D();
		Vector3D vector3D = _0023_003DzlvGiL_QdgBbL(_0023_003DzB1KfqX_0024SCu2_0024._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		Transformation.AutocadOCS(vector3D, out xAxis, out yAxis);
		Vector3D vector3D2 = _0023_003DzlvGiL_QdgBbL(_0023_003DzB1KfqX_0024SCu2_0024._0023_003DzkdtJIoFP5X7g);
		Vector3D vector3D3 = Vector3D.Cross(vector3D2, -1.0 * vector3D);
		vector3D3.Normalize();
		Vector3D vector3D4 = vector3D3 * (_0023_003DzB1KfqX_0024SCu2_0024._0023_003DzvGfon0CnFS9ANgEQFQ_003D_003D * vector3D2.Length);
		Plane arcPlane = new Plane(Point3D.Origin, vector3D2, vector3D4);
		double _0023_003Dz_gbL4wz7_0024Ge = _0023_003DzB1KfqX_0024SCu2_0024._0023_003Dz_gbL4wz7_0024Ge1;
		double endAngle = _0023_003DzB1KfqX_0024SCu2_0024._0023_003DzTruHvE_0024PuoOB;
		Utility.FixEndAngle(_0023_003Dz_gbL4wz7_0024Ge, ref endAngle);
		double length = vector3D2.Length;
		double length2 = vector3D4.Length;
		if (length > 1E-12 && length2 > 1E-12)
		{
			Point3D center = _0023_003Dzmq2_arBswhAA(_0023_003DzB1KfqX_0024SCu2_0024._0023_003DzbUvT9Pc_003D);
			EllipticalArc ellipticalArc = new EllipticalArc(arcPlane, center, length, length2, _0023_003Dz_gbL4wz7_0024Ge, endAngle);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(ellipticalArc, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			return ellipticalArc;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001534), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
		return null;
	}

	private Entity _0023_003Dzfpt8uoA_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzMExtuWihOrIcAg0bBVUlNmU_003D _0023_003Dz24XD0tE_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz24XD0tE_003D;
		string _0023_003DzTx0oa42d7YEq = _0023_003Dz24XD0tE_003D._0023_003DzTx0oa42d7YEq;
		double _0023_003DzvAxV_0024Ic_003D = _0023_003Dz24XD0tE_003D._0023_003DzvAxV_0024Ic_003D;
		AttachmentPoint attachmentPoint = _0023_003Dzxxwp9scVUTld[_0023_003Dz24XD0tE_003D._0023_003DzL1_0024LClwExf2o, _0023_003Dz24XD0tE_003D._0023_003Dzac3o_0024iimGW4nUg4aXQ_003D_003D];
		Text.alignmentType alignment = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(attachmentPoint);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dz24XD0tE_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), 0.0);
		plane.Rotate(_0023_003Dz24XD0tE_003D._0023_003DzVvkLpZU_003D, plane.AxisZ, Point3D.Origin);
		Plane _0023_003Dzpyw2kZk_003D = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dz24XD0tE_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), _0023_003Dz24XD0tE_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		Point3D insPoint = _0023_003Dz24XD0tE_003D._0023_003Dz0R7qasJeCI_s._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(_0023_003Dzpyw2kZk_003D, _0023_003Dz24XD0tE_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		if (attachmentPoint != AttachmentPoint.kBaseLeft && attachmentPoint != AttachmentPoint.kBaseAlign && attachmentPoint != AttachmentPoint.kBaseFit)
		{
			insPoint = _0023_003Dz24XD0tE_003D._0023_003Dzl_00248SX2MAYp_Q._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(_0023_003Dzpyw2kZk_003D, _0023_003Dz24XD0tE_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		}
		_0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D _0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D2 = ((_0023_003Dz24XD0tE_003D._0023_003Dz_0024wQZnFQ_003D != null) ? _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz24XD0tE_003D._0023_003Dz_0024wQZnFQ_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz4vDywqc_003D : null);
		string styleName = ((_0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D2 == null) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000688) : _0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D2._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D);
		Text text = new Text(plane, insPoint, _0023_003Dz3lOHLrA_003D(_0023_003DzTx0oa42d7YEq), _0023_003DzvAxV_0024Ic_003D, alignment, styleName);
		text.Backward = (_0023_003Dz24XD0tE_003D._0023_003DzGM3SAv8_003D & 2) == 2;
		text.UpsideDown = (_0023_003Dz24XD0tE_003D._0023_003DzGM3SAv8_003D & 4) == 4;
		text.WidthFactor = ((_0023_003Dz24XD0tE_003D._0023_003Dzdl_0024F0ljq1J6w == 0.0) ? 1.0 : _0023_003Dz24XD0tE_003D._0023_003Dzdl_0024F0ljq1J6w);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(text, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		if (text.TextString.Trim().Length > 0)
		{
			return text;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001190), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
		return null;
	}

	internal static string _0023_003DzmD2fQ5da9CZSb36vG_0024I5QCI_003D(string _0023_003DzlUfsUzo_003D)
	{
		while (true)
		{
			int num = _0023_003DzlUfsUzo_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966609));
			if (num < 0)
			{
				break;
			}
			_0023_003DzlUfsUzo_003D = string.Concat(_0023_003DzlUfsUzo_003D.Substring(0, num), str2: _0023_003DzlUfsUzo_003D.Substring(num + 2, _0023_003DzlUfsUzo_003D.Length - num - 2), str1: Environment.NewLine);
		}
		return _0023_003DzlUfsUzo_003D;
	}

	private AttributeReference _0023_003DzFdchMug_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzDpYNuA87njLP189ewQLdlq4_003D _0023_003Dz3nNqLJ4_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz3nNqLJ4_003D;
		double _0023_003DzvAxV_0024Ic_003D = _0023_003Dz3nNqLJ4_003D._0023_003DzvAxV_0024Ic_003D;
		AttachmentPoint attachmentPoint = _0023_003Dzxxwp9scVUTld[_0023_003Dz3nNqLJ4_003D._0023_003DzL1_0024LClwExf2o, _0023_003Dz3nNqLJ4_003D._0023_003Dzac3o_0024iimGW4nUg4aXQ_003D_003D];
		Text.alignmentType alignment = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(attachmentPoint);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dz3nNqLJ4_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), _0023_003Dz3nNqLJ4_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		Point3D insPoint = _0023_003Dz3nNqLJ4_003D._0023_003Dz0R7qasJeCI_s._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane, _0023_003Dz3nNqLJ4_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		if (attachmentPoint != AttachmentPoint.kBaseLeft && attachmentPoint != AttachmentPoint.kBaseAlign && attachmentPoint != AttachmentPoint.kBaseFit)
		{
			insPoint = _0023_003Dz3nNqLJ4_003D._0023_003Dzl_00248SX2MAYp_Q._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane, _0023_003Dz3nNqLJ4_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		}
		plane.Rotate(_0023_003Dz3nNqLJ4_003D._0023_003DzVvkLpZU_003D, plane.AxisZ, Point3D.Origin);
		AttributeReference attributeReference = new AttributeReference(plane, insPoint, _0023_003Dz3lOHLrA_003D(_0023_003Dz3nNqLJ4_003D._0023_003DzTx0oa42d7YEq), _0023_003DzvAxV_0024Ic_003D);
		attributeReference.Alignment = alignment;
		attributeReference.Backward = (_0023_003Dz3nNqLJ4_003D._0023_003DzGM3SAv8_003D & 2) == 2;
		attributeReference.UpsideDown = (_0023_003Dz3nNqLJ4_003D._0023_003DzGM3SAv8_003D & 4) == 4;
		attributeReference.WidthFactor = ((_0023_003Dz3nNqLJ4_003D._0023_003Dzdl_0024F0ljq1J6w == 0.0) ? 1.0 : _0023_003Dz3nNqLJ4_003D._0023_003Dzdl_0024F0ljq1J6w);
		attributeReference.Constant = _0023_003Dz3nNqLJ4_003D._0023_003Dz_00244zNrgI_003D == '\u0002';
		attributeReference.Verify = _0023_003Dz3nNqLJ4_003D._0023_003Dz_00244zNrgI_003D == '\u0004';
		attributeReference.Preset = _0023_003Dz3nNqLJ4_003D._0023_003Dz_00244zNrgI_003D == '\b';
		_0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D _0023_003Dz4vDywqc_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz3nNqLJ4_003D._0023_003Dz_0024wQZnFQ_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz4vDywqc_003D;
		attributeReference.StyleName = _0023_003Dz4vDywqc_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D;
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(attributeReference, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		attributeReference.Invisible = _0023_003Dz3nNqLJ4_003D._0023_003Dz_00244zNrgI_003D == '\u0001';
		return attributeReference;
	}

	private Entity _0023_003DzCGAW_0024kk_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzJ2jDsLU9f6zwfsOOwcrdfYF1KZPG _0023_003DzxqaHoKARAQgy = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzxqaHoKARAQgy;
		double _0023_003DzvAxV_0024Ic_003D = _0023_003DzxqaHoKARAQgy._0023_003DzvAxV_0024Ic_003D;
		AttachmentPoint attachmentPoint = _0023_003Dzxxwp9scVUTld[_0023_003DzxqaHoKARAQgy._0023_003DzL1_0024LClwExf2o, _0023_003DzxqaHoKARAQgy._0023_003Dzac3o_0024iimGW4nUg4aXQ_003D_003D];
		Text.alignmentType alignment = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(attachmentPoint);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003DzxqaHoKARAQgy._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), _0023_003DzxqaHoKARAQgy._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		Point3D insPoint = _0023_003DzxqaHoKARAQgy._0023_003Dz0R7qasJeCI_s._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane, _0023_003DzxqaHoKARAQgy._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		if (attachmentPoint != AttachmentPoint.kBaseLeft && attachmentPoint != AttachmentPoint.kBaseAlign && attachmentPoint != AttachmentPoint.kBaseFit)
		{
			insPoint = _0023_003DzxqaHoKARAQgy._0023_003Dzl_00248SX2MAYp_Q._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane, _0023_003DzxqaHoKARAQgy._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		}
		plane.Rotate(_0023_003DzxqaHoKARAQgy._0023_003DzVvkLpZU_003D, plane.AxisZ, plane.Origin);
		devDept.Eyeshot.Entities.Attribute attribute = new devDept.Eyeshot.Entities.Attribute(plane, insPoint, _0023_003DzxqaHoKARAQgy._0023_003Dzo4ntpKk_003D, _0023_003Dz3lOHLrA_003D(_0023_003DzxqaHoKARAQgy._0023_003DzSuxKDcTKSrsk), _0023_003DzvAxV_0024Ic_003D);
		attribute.Alignment = alignment;
		attribute.Backward = (_0023_003DzxqaHoKARAQgy._0023_003DzGM3SAv8_003D & 2) == 2;
		attribute.UpsideDown = (_0023_003DzxqaHoKARAQgy._0023_003DzGM3SAv8_003D & 4) == 4;
		attribute.WidthFactor = ((_0023_003DzxqaHoKARAQgy._0023_003Dzdl_0024F0ljq1J6w == 0.0) ? 1.0 : _0023_003DzxqaHoKARAQgy._0023_003Dzdl_0024F0ljq1J6w);
		attribute.Prompt = _0023_003DzxqaHoKARAQgy._0023_003DzixR8230_003D;
		attribute.Constant = _0023_003DzxqaHoKARAQgy._0023_003Dz_00244zNrgI_003D == '\u0002';
		attribute.Verify = _0023_003DzxqaHoKARAQgy._0023_003Dz_00244zNrgI_003D == '\u0004';
		attribute.Preset = _0023_003DzxqaHoKARAQgy._0023_003Dz_00244zNrgI_003D == '\b';
		_0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D _0023_003Dz4vDywqc_003D = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzxqaHoKARAQgy._0023_003Dz_0024wQZnFQ_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz4vDywqc_003D;
		attribute.StyleName = _0023_003Dz4vDywqc_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D;
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(attribute, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		attribute.Invisible = _0023_003DzxqaHoKARAQgy._0023_003Dz_00244zNrgI_003D == '\u0001';
		return attribute;
	}

	private Entity _0023_003DzgU_7uU5MaplX7ygU9A_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, Plane _0023_003Dz7BYIGZMHUBv_0024qJaOYQ_003D_003D)
	{
		_0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D _0023_003DzoFgsK8GdHriOzoDLqA_003D_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzoFgsK8GdHriOzoDLqA_003D_003D;
		double[] array = _0023_003DzdZJdWj61QN4u(_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		Vector3D vector3D = (array.All(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz23eMBT3XF3gpneO8VLUHR19sHqiRTsVb0w_003D_003D) ? Vector3D.AxisZ : new Vector3D(array));
		Plane _0023_003Dzpyw2kZk_003D = _0023_003Dz7BYIGZMHUBv_0024qJaOYQ_003D_003D ?? _0023_003DztIc79mb2zQ0f(vector3D.ToArray(), 0.0);
		bool _0023_003Dz_0024INsivcUOnm = _0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003DzCL1XEBfKPNlTfjRcOg_003D_003D != 0;
		bool flag = _0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D != 0.0 && ExtrudeByThickness;
		ICurve curve = _0023_003DzkHJqKtSjQNmd19v2BLC9VR0_003D(_0023_003DzfpN7pnryJplL, (int)_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003Dzl854Q0bMjSxQ, _0023_003Dzpyw2kZk_003D, _0023_003Dz_0024INsivcUOnm, _0023_003DzELu0Pss_003D, flag);
		if (!flag)
		{
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(curve as Entity, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			((Entity)curve).AutodeskProperties.Thickness = _0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D;
			((Entity)curve).AutodeskProperties.ExtrusionDir = vector3D;
			return curve as Entity;
		}
		Entity entity = curve.ExtrudeAsBrep(vector3D * _0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return entity;
	}

	private Entity _0023_003DzMzJHeIDGb91Csfia3n8XpKseARLi(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D, int _0023_003DzfBEBL_o_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private static bool _0023_003DzPXJymPlOuaUh(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dz9j7EUB0_003D, ref int _0023_003Dz_0024DaxafaOesSsyDpEUiMoG1gVdKy_)
	{
		throw new NotImplementedException();
	}

	[IteratorStateMachine(typeof(_0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D))]
	private IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> _0023_003DzwVOMFo93q2aB(_0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, _0023_003Dza18auqkIO4ikE_0024Fgfk4YkL_Ckr7lanBMhVyfnwU_003D _0023_003Dzi4cdUYM_003D)
	{
		return new _0023_003DzVEs2cBr99J9ohSOzwP4rv30_003D(-2)
		{
			_0023_003Dzja9gywQIhYG_ = _0023_003DzELu0Pss_003D,
			_0023_003DzHMcqF6mnkvZt = _0023_003Dzi4cdUYM_003D
		};
	}

	private Entity _0023_003DzTwlzqt9JW4xI1su8WA_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003Dzbu7jQqGqfSM9hacfKAfwPuY_003D CS_0024_003C_003E8__locals6 = new _0023_003Dzbu7jQqGqfSM9hacfKAfwPuY_003D();
		CS_0024_003C_003E8__locals6._0023_003DzELu0Pss_003D = _0023_003DzELu0Pss_003D;
		_0023_003Dzkf1q6_ttU58LErsobqzzmLtO9c9uz7A0Q07txEk_003D _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D;
		double[] array = _0023_003DzdZJdWj61QN4u(_0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		Plane _0023_003Dzpyw2kZk_003D = ((array.Sum() > 0.0) ? _0023_003DztIc79mb2zQ0f(array, 0.0) : Plane.XY);
		_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D[] array2;
		if (_0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003DzB43_00244h5YT0JV_0024ydwuw_003D_003D != null)
		{
			long num = _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003DzNIyqoD0e_vzSOapJKQ_003D_003D._0023_003Dzsfb7U1TFH2wE - _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003DzB43_00244h5YT0JV_0024ydwuw_003D_003D._0023_003Dzsfb7U1TFH2wE + 1;
			int num2 = 0;
			array2 = new _0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D[num];
			foreach (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D item in _0023_003DzwVOMFo93q2aB(CS_0024_003C_003E8__locals6._0023_003DzELu0Pss_003D, _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D))
			{
				if (item != null)
				{
					array2[num2++] = item._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DznDtqSlJPqUdzwKhgkA_003D_003D;
				}
			}
		}
		else
		{
			array2 = _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003DzkEYxO1SuR1Kw.Select((_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D _0023_003Dz77g161c_003D) => _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(CS_0024_003C_003E8__locals6._0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz77g161c_003D._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DznDtqSlJPqUdzwKhgkA_003D_003D).ToArray();
		}
		bool _0023_003Dz_0024INsivcUOnm = array2.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzPo2BwEGnKGh7ObWd8p7iB60pC0fUrOCAhw_003D_003D);
		bool flag = _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D != 0.0 && ExtrudeByThickness;
		ICurve curve = _0023_003DzEkpgqzV9z_0024l9dRbztEghRLs_003D(_0023_003DzfpN7pnryJplL, array2, _0023_003Dz_0024INsivcUOnm, _0023_003Dzpyw2kZk_003D, CS_0024_003C_003E8__locals6._0023_003DzELu0Pss_003D, flag);
		Vector3D vector3D = ((array.Sum() > 0.0) ? new Vector3D(array) : Vector3D.AxisZ);
		if (!flag)
		{
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(curve as Entity, _0023_003DzfpN7pnryJplL, CS_0024_003C_003E8__locals6._0023_003DzELu0Pss_003D);
			((Entity)curve).AutodeskProperties.Thickness = _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D;
			((Entity)curve).AutodeskProperties.ExtrusionDir = vector3D;
			return curve as Entity;
		}
		Entity entity = curve.ExtrudeAsBrep(vector3D * _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003Dzetc0sjwdrddceszzig_003D_003D);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, _0023_003DzfpN7pnryJplL, CS_0024_003C_003E8__locals6._0023_003DzELu0Pss_003D);
		return entity;
	}

	private ICurve _0023_003DzkHJqKtSjQNmd19v2BLC9VR0_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, int _0023_003DzIjWUrIsQsQLYSNdMYg_003D_003D, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003Dz_0024INsivcUOnm1, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, bool _0023_003DzlQ_1bygDZUc_0024BU6OAw_003D_003D)
	{
		_0023_003DzqIKY6V_OHm6218GYKDFn3N4LHKNI3EFk2g_003D_003D _0023_003DzoFgsK8GdHriOzoDLqA_003D_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzoFgsK8GdHriOzoDLqA_003D_003D;
		Utility.BoundingBox(_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003DzrdSL0CI_003D.Select((_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003DzMlCq3wk_003D) => _0023_003Dzmq2_arBswhAA(_0023_003DzMlCq3wk_003D)).ToArray(), out var min, out var max);
		double domainSize = Point3D.Distance(min, max);
		bool flag = (_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003Dzjcx0hV4_003D & 0x200) != 0;
		if (!_0023_003Dz_0024INsivcUOnm1)
		{
			List<Point3D> list = new List<Point3D>();
			double _0023_003DznBt0TkcDK54J = _0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003DznBt0TkcDK54J;
			for (int num = 0; num < _0023_003DzIjWUrIsQsQLYSNdMYg_003D_003D; num++)
			{
				Point2D point2D = _0023_003DzUnxHUznPiV7g(_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003DzrdSL0CI_003D[num]);
				double c = _0023_003DzgRf1Kl0_003D(_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
				list.Add(_0023_003Dzpyw2kZk_003D.PointAt(point2D.X, point2D.Y, c));
			}
			if (_0023_003DzlQ_1bygDZUc_0024BU6OAw_003D_003D)
			{
				list = Utility.RemoveDuplicates(list).ToList();
			}
			LinearPath linearPath = new LinearPath(list);
			if (flag && !linearPath.IsClosed)
			{
				list.Add((Point3D)list[0].Clone());
				linearPath.Vertices = list.ToArray();
			}
			linearPath.GlobalWidth = _0023_003DznBt0TkcDK54J;
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearPath, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			return linearPath;
		}
		List<ICurve> list2 = new List<ICurve>();
		int num2 = (flag ? (_0023_003DzIjWUrIsQsQLYSNdMYg_003D_003D + 1) : _0023_003DzIjWUrIsQsQLYSNdMYg_003D_003D);
		for (int num3 = 0; num3 < num2 - 1; num3++)
		{
			Point2D point2D2 = _0023_003DzUnxHUznPiV7g(_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003DzrdSL0CI_003D[num3]);
			Point2D point2D3 = _0023_003DzUnxHUznPiV7g(_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003DzrdSL0CI_003D[(num3 + 1) % _0023_003DzIjWUrIsQsQLYSNdMYg_003D_003D]);
			double _0023_003DzPzO_0024GUk_003D = _0023_003DzgRf1Kl0_003D(_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
			if (Point2D.AreEqual(point2D2, point2D3, domainSize))
			{
				continue;
			}
			double num4 = _0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003DzSDLnxKBqGfZ7[num3];
			if (num4 == 0.0)
			{
				Line item = new Line(_0023_003Dzpyw2kZk_003D.PointAt(_0023_003DzgRf1Kl0_003D(point2D2.X), _0023_003DzgRf1Kl0_003D(point2D2.Y), _0023_003DzgRf1Kl0_003D(_0023_003DzPzO_0024GUk_003D)), _0023_003Dzpyw2kZk_003D.PointAt(_0023_003DzgRf1Kl0_003D(point2D3.X), _0023_003DzgRf1Kl0_003D(point2D3.Y), _0023_003DzgRf1Kl0_003D(_0023_003DzPzO_0024GUk_003D)));
				list2.Add(item);
				continue;
			}
			double length = Vector2D.Subtract(point2D3, point2D2).Length;
			if (length > 0.0)
			{
				double num5 = length / 2.0 * num4;
				double num6 = (length / 2.0 * (length / 2.0) + num5 * num5) / (2.0 * num5);
				double num7 = num6 - num5;
				double num8 = Math.Atan(num4) * 4.0;
				Point2D point2D4 = point2D2 + 0.5 * (point2D3 - point2D2);
				Vector2D vector2D = new Vector2D(0.0 - (point2D3.Y - point2D2.Y), point2D3.X - point2D2.X);
				vector2D.Normalize();
				Vector2D vector2D2 = num7 * vector2D;
				Point2D point2D5 = new Point2D(point2D4.X + vector2D2.X, point2D4.Y + vector2D2.Y);
				double num9 = Utility.ArcTanProblem(point2D2.X - point2D5.X, point2D2.Y - point2D5.Y);
				if (Math.Abs(num6) > 1E-12 && Math.Abs(num8) > 1E-12)
				{
					Arc item2 = new Arc(_0023_003Dzpyw2kZk_003D, _0023_003Dzpyw2kZk_003D.PointAt(_0023_003DzgRf1Kl0_003D(point2D5.X), _0023_003DzgRf1Kl0_003D(point2D5.Y), _0023_003DzgRf1Kl0_003D(_0023_003DzoFgsK8GdHriOzoDLqA_003D_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D)), Math.Abs(num6), num9, num9 + num8);
					list2.Add(item2);
				}
			}
		}
		if (list2.Count == 0)
		{
			return null;
		}
		CompositeCurve compositeCurve = new CompositeCurve(list2, sortAndOrient: false);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(compositeCurve, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return compositeCurve;
	}

	private ICurve _0023_003DzEkpgqzV9z_0024l9dRbztEghRLs_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D[] _0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D, bool _0023_003Dz_0024INsivcUOnm1, Plane _0023_003Dzpyw2kZk_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, bool _0023_003DzlQ_1bygDZUc_0024BU6OAw_003D_003D)
	{
		_0023_003Dzkf1q6_ttU58LErsobqzzmLtO9c9uz7A0Q07txEk_003D _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D;
		Utility.BoundingBox(_0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzpXDjp4zPJV5AvjfKV1XemzmyTrnBFoMDxg_003D_003D).ToArray(), out var min, out var max);
		double domainSize = Point3D.Distance(min, max);
		bool flag = (_0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003Dzjcx0hV4_003D & 1) != 0;
		double _0023_003Dz1Rls5bMv91nm31u74A_003D_003D = _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003Dz1Rls5bMv91nm31u74A_003D_003D;
		if (!_0023_003Dz_0024INsivcUOnm1)
		{
			List<Point3D> list = new List<Point3D>();
			double _0023_003DzgHtrud_0024Yx1Rt = _0023_003Dzei2JkTp7oA24k7Vj2A_003D_003D._0023_003DzgHtrud_0024Yx1Rt;
			foreach (_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D _0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D2 in _0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D)
			{
				if ((_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D2._0023_003Dzjcx0hV4_003D & 4) != 4 && (_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D2._0023_003Dzjcx0hV4_003D & 0x10) != 16)
				{
					_0023_003DzgHtrud_0024Yx1Rt = _0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D2._0023_003DzgHtrud_0024Yx1Rt;
					Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dzppg2CE6FT53WKuhhwtuxmjqYHi_0024_0024LRPD5A_003D_003D2._0023_003DzlY77YgY_003D);
					list.Add(_0023_003Dzpyw2kZk_003D.PointAt(_0023_003DzgRf1Kl0_003D(point3D.X), _0023_003DzgRf1Kl0_003D(point3D.Y), _0023_003DzgRf1Kl0_003D(_0023_003Dz1Rls5bMv91nm31u74A_003D_003D)));
				}
			}
			if (_0023_003DzlQ_1bygDZUc_0024BU6OAw_003D_003D)
			{
				list = Utility.RemoveDuplicates(list).ToList();
			}
			LinearPath linearPath = new LinearPath(list);
			if (flag && !linearPath.IsClosed)
			{
				list.Add((Point3D)list[0].Clone());
				linearPath.Vertices = list.ToArray();
			}
			linearPath.GlobalWidth = _0023_003DzgHtrud_0024Yx1Rt;
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearPath, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			return linearPath;
		}
		List<ICurve> list2 = new List<ICurve>();
		int num = (flag ? (_0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D.Length + 1) : _0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D.Length);
		for (int j = 0; j < num - 1; j++)
		{
			Point2D point2D = _0023_003Dzmq2_arBswhAA(_0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D[j]._0023_003DzlY77YgY_003D);
			Point2D point2D2 = _0023_003Dzmq2_arBswhAA(_0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D[(j + 1) % _0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D.Length]._0023_003DzlY77YgY_003D);
			if (Point2D.AreEqual(point2D, point2D2, domainSize))
			{
				continue;
			}
			double _0023_003Dzo9ajQUuoihC = _0023_003DzNnaQFAbH_0024YJjkPfMgA_003D_003D[j]._0023_003Dzo9ajQUuoihC2;
			if (_0023_003Dzo9ajQUuoihC == 0.0)
			{
				Line item = new Line(_0023_003Dzpyw2kZk_003D.PointAt(_0023_003DzgRf1Kl0_003D(point2D.X), _0023_003DzgRf1Kl0_003D(point2D.Y), _0023_003DzgRf1Kl0_003D(_0023_003Dz1Rls5bMv91nm31u74A_003D_003D)), _0023_003Dzpyw2kZk_003D.PointAt(_0023_003DzgRf1Kl0_003D(point2D2.X), _0023_003DzgRf1Kl0_003D(point2D2.Y), _0023_003DzgRf1Kl0_003D(_0023_003Dz1Rls5bMv91nm31u74A_003D_003D)));
				list2.Add(item);
				continue;
			}
			double length = Vector2D.Subtract(point2D2, point2D).Length;
			if (length > 0.0)
			{
				double num2 = length / 2.0 * _0023_003Dzo9ajQUuoihC;
				double num3 = (length / 2.0 * (length / 2.0) + num2 * num2) / (2.0 * num2);
				double num4 = num3 - num2;
				double num5 = Math.Atan(_0023_003Dzo9ajQUuoihC) * 4.0;
				Point2D point2D3 = point2D + 0.5 * (point2D2 - point2D);
				Vector2D vector2D = new Vector2D(0.0 - (point2D2.Y - point2D.Y), point2D2.X - point2D.X);
				vector2D.Normalize();
				Vector2D vector2D2 = num4 * vector2D;
				Point2D point2D4 = new Point2D(point2D3.X + vector2D2.X, point2D3.Y + vector2D2.Y);
				double num6 = Utility.ArcTanProblem(point2D.X - point2D4.X, point2D.Y - point2D4.Y);
				if (Math.Abs(num3) > 1E-12 && Math.Abs(num5) > 1E-12)
				{
					Arc item2 = new Arc(_0023_003Dzpyw2kZk_003D, _0023_003Dzpyw2kZk_003D.PointAt(_0023_003DzgRf1Kl0_003D(point2D4.X), _0023_003DzgRf1Kl0_003D(point2D4.Y), _0023_003DzgRf1Kl0_003D(_0023_003Dz1Rls5bMv91nm31u74A_003D_003D)), Math.Abs(num3), num6, num6 + num5);
					list2.Add(item2);
				}
			}
		}
		if (list2.Count == 0)
		{
			return null;
		}
		CompositeCurve compositeCurve = new CompositeCurve(list2, sortAndOrient: false);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(compositeCurve, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return compositeCurve;
	}

	private ICurve _0023_003DzDIfQPmvb7H4x7wBlCQ_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzRStSB1rsoNKYaya4kg_003D_003D, int _0023_003DzfBEBL_o_003D, int _0023_003DzIjWUrIsQsQLYSNdMYg_003D_003D, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003Dz_0024INsivcUOnm1, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzT7JvkYG2_e5DlNpugQ_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D _0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D2 = new _0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D();
		_0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D2._0023_003DzELu0Pss_003D = _0023_003DzELu0Pss_003D;
		_0023_003DzngdStw3YwA05PBp_rj0x_0024vcV2T_bnaos29qgOeo_003D _0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D;
		_0023_003Dz_0024H7BdIKtlSwH result = _0023_003Dz_0024H7BdIKtlSwH.Simple;
		if (_0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D._0023_003DzX_bjfACpRara != 0 && !Enum.TryParse<_0023_003Dz_0024H7BdIKtlSwH>(_0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D._0023_003DzX_bjfACpRara.ToString(), out result))
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001132), _0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D._0023_003DzX_bjfACpRara, _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
		}
		List<Point3D> list = new List<Point3D>();
		List<Point3D> list2 = new List<Point3D>();
		_0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D[] array = ((_0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D._0023_003DzB43_00244h5YT0JV_0024ydwuw_003D_003D == null) ? _0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D._0023_003DzkEYxO1SuR1Kw.Select(_0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D2._0023_003DzQK9rraso3ItIRrOfF54lwhVhA8lj).ToArray() : (from _0023_003Dzs_0024uS8LA_003D in _0023_003DzwVOMFo93q2aB(_0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D2._0023_003DzELu0Pss_003D, _0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D).Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz_yk_pS9VVPOF_Q4k_Dspe0iMePuOLdDbAw_003D_003D)
			select _0023_003Dzs_0024uS8LA_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzznCFU5x_002428gt6aaU_g_003D_003D).ToArray());
		_0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D[] array2 = array;
		foreach (_0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D _0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D2 in array2)
		{
			if ((_0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D2._0023_003Dzjcx0hV4_003D & 0x10) == 16)
			{
				list.Add(_0023_003Dzmq2_arBswhAA(_0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D2._0023_003DzlY77YgY_003D));
			}
			else
			{
				list2.Add(_0023_003Dzmq2_arBswhAA(_0023_003DzrAzxoo57NuR8iOWTmbMj9hX_nRz2Urr0mw_003D_003D2._0023_003DzlY77YgY_003D));
			}
		}
		if ((_0023_003DzItvFK_0024khrYPmg3oHdg_003D_003D._0023_003Dzjcx0hV4_003D & 1) != 0)
		{
			result = _0023_003Dz_0024H7BdIKtlSwH.Simple;
			if (list2.Count > 0 && !list2[0].Equals(list2.Last()))
			{
				list2.Add((Point3D)list2[0].Clone());
			}
		}
		int num2 = 0;
		int count = list.Count;
		if (count == 0)
		{
			result = _0023_003Dz_0024H7BdIKtlSwH.Simple;
			if (list2.Count < 2)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001282));
			}
		}
		switch (result)
		{
		case _0023_003Dz_0024H7BdIKtlSwH.Quadratic:
		{
			num2 = ((count == 2) ? 1 : 2);
			double[] knotVector = NurbsBase.UniformKnotVector(num2, count);
			Point4D[] array3 = new Point4D[count];
			for (int num4 = 0; num4 < count; num4++)
			{
				array3[num4] = new Point4D(list[num4].X, list[num4].Y, list[num4].Z);
			}
			Curve curve = new Curve(num2, knotVector, array3);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(curve, _0023_003DzfpN7pnryJplL, _0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D2._0023_003DzELu0Pss_003D);
			return curve;
		}
		case _0023_003Dz_0024H7BdIKtlSwH.Cubic:
		{
			num2 = count switch
			{
				2 => 1, 
				3 => 2, 
				_ => 3, 
			};
			double[] knotVector = NurbsBase.UniformKnotVector(num2, count);
			Point4D[] array3 = new Point4D[count];
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				array3[num3] = new Point4D(list[num3].X, list[num3].Y, list[num3].Z);
			}
			Curve curve = new Curve(num2, knotVector, array3);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(curve, _0023_003DzfpN7pnryJplL, _0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D2._0023_003DzELu0Pss_003D);
			return curve;
		}
		default:
		{
			LinearPathEx linearPathEx = new LinearPathEx(list2);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearPathEx, _0023_003DzfpN7pnryJplL, _0023_003DzTpIWF58ofg9xjoSzqCcs1dk_003D2._0023_003DzELu0Pss_003D);
			return linearPathEx;
		}
		}
	}

	private Entity _0023_003Dzl6LkJd4_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP _0023_003DzP9yM7Jgz_mJc = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzP9yM7Jgz_mJc;
		try
		{
			Entity entity = _0023_003DzT54SwPVVUhscZ3AyXg_003D_003D(_0023_003DzP9yM7Jgz_mJc);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			return entity;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private Curve _0023_003DzT54SwPVVUhscZ3AyXg_003D_003D(_0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP _0023_003DzBllXlC9tCWsv)
	{
		Curve _0023_003Dz0sHZv5DCE_0024_H = null;
		bool _0023_003DzjuYKWBBXI34x4GCzLw_003D_003D = _0023_003DzBllXlC9tCWsv._0023_003DzjuYKWBBXI34x4GCzLw_003D_003D == '\u0001';
		int _0023_003DzU7eDCS_XZhhv = _0023_003DzBllXlC9tCWsv._0023_003DzU7eDCS_XZhhv;
		if (_0023_003DzBllXlC9tCWsv._0023_003Dz2rdX29E_003D == 1)
		{
			return _0023_003Dzp9I2BfKR1p0H(_0023_003DzBllXlC9tCWsv, _0023_003DzjuYKWBBXI34x4GCzLw_003D_003D, _0023_003Dz0sHZv5DCE_0024_H, _0023_003DzU7eDCS_XZhhv);
		}
		return _0023_003Dz3s3mUmR0Hgkl(_0023_003DzBllXlC9tCWsv);
	}

	private Vector3D _0023_003DzZ2FGq78_003D(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D _0023_003DzlllF2to_003D)
	{
		double num = _0023_003DzgRf1Kl0_003D(_0023_003DzlllF2to_003D._0023_003DzBJFJHwk_003D);
		double num2 = _0023_003DzgRf1Kl0_003D(_0023_003DzlllF2to_003D._0023_003Dz40R7bAU_003D);
		double num3 = _0023_003DzgRf1Kl0_003D(_0023_003DzlllF2to_003D._0023_003DzId5C3LA_003D);
		if (num == 0.0 && num2 == 0.0 && num3 == 0.0)
		{
			return null;
		}
		return new Vector3D(num, num2, num3);
	}

	private Curve _0023_003Dz3s3mUmR0Hgkl(_0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP _0023_003DzBllXlC9tCWsv)
	{
		Point3D[] array = new Point3D[_0023_003DzBllXlC9tCWsv._0023_003DzJ_dbzFrlaoXxUEjiLw_003D_003D];
		if (array.Length != 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D _0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D2 = _0023_003DzBllXlC9tCWsv._0023_003Dz_STl1YXQKrP3[i];
				array[i] = new Point3D(_0023_003DzgRf1Kl0_003D(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D2._0023_003DzBJFJHwk_003D), _0023_003DzgRf1Kl0_003D(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D2._0023_003Dz40R7bAU_003D), _0023_003DzgRf1Kl0_003D(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D2._0023_003DzId5C3LA_003D));
			}
		}
		Curve.fitPointMethod fitPointMethod = Curve.fitPointMethod.chordLength;
		Vector3D startTang = _0023_003DzZ2FGq78_003D(_0023_003DzBllXlC9tCWsv._0023_003DzUt7m5dcZ9582Avz_Gg_003D_003D);
		Vector3D endTang = _0023_003DzZ2FGq78_003D(_0023_003DzBllXlC9tCWsv._0023_003DzpiXCdUL_0024nFXC5N_0024iBw_003D_003D);
		if (_0023_003DzBllXlC9tCWsv._0023_003DzP_hp52StqUPpR4_0024RBQ_003D_003D == 1)
		{
			fitPointMethod = Curve.fitPointMethod.squareRoot;
		}
		else if (_0023_003DzBllXlC9tCWsv._0023_003DzP_hp52StqUPpR4_0024RBQ_003D_003D == 2)
		{
			fitPointMethod = Curve.fitPointMethod.uniform;
		}
		Curve curve = ((!(_0023_003DzBllXlC9tCWsv._0023_003Dzfe7xj_z77Urc <= 1E-10)) ? null : Curve.NaturalCubicSplineInterpolation(array, fitPointMethod, startTang, endTang));
		_0023_003Dzn3YnR26DHLcdqjgY_0024w_003D_003D(curve, array, fitPointMethod);
		return curve;
	}

	private static Curve _0023_003Dzp9I2BfKR1p0H(_0023_003DzNCPY_0024aDoUG8gVsvjQ8TaFfHWyHzP _0023_003DzBllXlC9tCWsv, bool _0023_003DzjuYKWBBXI34x4GCzLw_003D_003D, Curve _0023_003Dz0sHZv5DCE_0024_H, int _0023_003DzU7eDCS_XZhhv)
	{
		Point4D[] array = new Point4D[_0023_003DzBllXlC9tCWsv._0023_003DzWnkJjDtu2bda38hXSw_003D_003D];
		if (array.Length != 0)
		{
			if (_0023_003DzjuYKWBBXI34x4GCzLw_003D_003D)
			{
				for (int i = 0; i < array.Length; i++)
				{
					_0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D _0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D2 = _0023_003DzBllXlC9tCWsv._0023_003Dz2yaeB8fJ9fBB[i];
					double _0023_003DzAvn2b38_003D = _0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D2._0023_003DzAvn2b38_003D;
					array[i] = new Point4D(_0023_003DzgRf1Kl0_003D(_0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D2._0023_003DzBJFJHwk_003D) * _0023_003DzAvn2b38_003D, _0023_003DzgRf1Kl0_003D(_0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D2._0023_003Dz40R7bAU_003D) * _0023_003DzAvn2b38_003D, _0023_003DzgRf1Kl0_003D(_0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D2._0023_003DzId5C3LA_003D) * _0023_003DzAvn2b38_003D, _0023_003DzAvn2b38_003D);
				}
			}
			else
			{
				for (int j = 0; j < array.Length; j++)
				{
					_0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D _0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D3 = _0023_003DzBllXlC9tCWsv._0023_003Dz2yaeB8fJ9fBB[j];
					array[j] = new Point4D(_0023_003DzgRf1Kl0_003D(_0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D3._0023_003DzBJFJHwk_003D), _0023_003DzgRf1Kl0_003D(_0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D3._0023_003Dz40R7bAU_003D), _0023_003DzgRf1Kl0_003D(_0023_003DzaQw_UuD_MdjZV3aLlyXe9G62A5fbJXSgyw_003D_003D3._0023_003DzId5C3LA_003D));
				}
			}
			_0023_003Dz0sHZv5DCE_0024_H = new Curve(_0023_003DzU7eDCS_XZhhv, _0023_003DzBllXlC9tCWsv._0023_003Dzr7tgnwG7XK6N, array);
		}
		return _0023_003Dz0sHZv5DCE_0024_H;
	}

	private void _0023_003Dzn3YnR26DHLcdqjgY_0024w_003D_003D(Curve _0023_003Dz0sHZv5DCE_0024_H, Point3D[] _0023_003DzOVcOkAK7kJKN, Curve.fitPointMethod _0023_003DzJTQziP0_003D)
	{
		if (_0023_003DzJTQziP0_003D == Curve.fitPointMethod.uniform)
		{
			_0023_003Dz0sHZv5DCE_0024_H.KnotVector.Scale(_0023_003DzOVcOkAK7kJKN.Length - 1);
			return;
		}
		double num = 0.0;
		for (int i = 1; i < _0023_003DzOVcOkAK7kJKN.Length; i++)
		{
			num += ((_0023_003DzJTQziP0_003D == Curve.fitPointMethod.squareRoot) ? Math.Sqrt(_0023_003DzOVcOkAK7kJKN[i].DistanceTo(_0023_003DzOVcOkAK7kJKN[i - 1])) : _0023_003DzOVcOkAK7kJKN[i].DistanceTo(_0023_003DzOVcOkAK7kJKN[i - 1]));
		}
		_0023_003Dz0sHZv5DCE_0024_H.KnotVector.Scale(num);
	}

	internal static void _0023_003DzlsAvovRYD7jjgMUyL9PP3KRrV9Mi(int _0023_003DzB68dg9Q_003D, double[] _0023_003DztnKSw31yt72w, Point4D[] _0023_003DzsshtarbDj7bf, double _0023_003DzE3bcH0RM3xCE, out List<double> _0023_003DzXptaNUPHdku5, out List<Point4D> _0023_003DzHZhKOsqm4tXS)
	{
		int num = _0023_003DztnKSw31yt72w.Length - _0023_003DzB68dg9Q_003D;
		_0023_003DzXptaNUPHdku5 = new List<double>();
		_0023_003DzHZhKOsqm4tXS = new List<Point4D>();
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i <= _0023_003DzB68dg9Q_003D; i++)
		{
			_0023_003DzXptaNUPHdku5.Add(_0023_003DztnKSw31yt72w[0]);
		}
		for (int j = _0023_003DzB68dg9Q_003D + 1; j < num - 1; j++)
		{
			double num4 = _0023_003DztnKSw31yt72w[j];
			if (num4 == _0023_003DztnKSw31yt72w[j + _0023_003DzB68dg9Q_003D] || num4 == _0023_003DztnKSw31yt72w[j + _0023_003DzB68dg9Q_003D] - _0023_003DzE3bcH0RM3xCE)
			{
				for (int k = 0; k < _0023_003DzB68dg9Q_003D; k++)
				{
					_0023_003DzXptaNUPHdku5.Add(num4);
				}
				for (int l = num3; l < num3 + j - num2 - 1; l++)
				{
					_0023_003DzHZhKOsqm4tXS.Add(_0023_003DzsshtarbDj7bf[l]);
				}
				num3 += j - num2;
				num2 = j;
				j += _0023_003DzB68dg9Q_003D;
			}
			else
			{
				_0023_003DzXptaNUPHdku5.Add(num4);
			}
		}
		for (int m = 0; m <= _0023_003DzB68dg9Q_003D; m++)
		{
			_0023_003DzXptaNUPHdku5.Add(_0023_003DztnKSw31yt72w[num]);
		}
		for (int n = num3; n < _0023_003DzsshtarbDj7bf.Length; n++)
		{
			_0023_003DzHZhKOsqm4tXS.Add(_0023_003DzsshtarbDj7bf[n]);
		}
	}

	private Entity _0023_003Dzg4ddAVY_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzzqJI3rVkA85vd1VlEo39GAeO0rwd44b9SQ_003D_003D _0023_003DzETeDI6Pugpjz = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzETeDI6Pugpjz;
		Point3D[] array = new Point3D[4]
		{
			_0023_003Dzmq2_arBswhAA(_0023_003DzETeDI6Pugpjz._0023_003DzzxCX0YE_003D),
			_0023_003Dzmq2_arBswhAA(_0023_003DzETeDI6Pugpjz._0023_003DzfILMMw4_003D),
			_0023_003Dzmq2_arBswhAA(_0023_003DzETeDI6Pugpjz._0023_003DzVX1L6fc_003D),
			_0023_003Dzmq2_arBswhAA(_0023_003DzETeDI6Pugpjz._0023_003DzG_HFZvc_003D)
		};
		if (array[2] == array[3])
		{
			Triangle triangle = new Triangle(array[0], array[1], array[2]);
			triangle.VisibleEdgeFlag = 0;
			if ((_0023_003DzETeDI6Pugpjz._0023_003Dz_0024QBfiC_00241iV_0024Nfg7G6g_003D_003D & 1) == 1)
			{
				triangle.VisibleEdgeFlag |= 1;
			}
			if ((_0023_003DzETeDI6Pugpjz._0023_003Dz_0024QBfiC_00241iV_0024Nfg7G6g_003D_003D & 2) == 2)
			{
				triangle.VisibleEdgeFlag |= 2;
			}
			if ((_0023_003DzETeDI6Pugpjz._0023_003Dz_0024QBfiC_00241iV_0024Nfg7G6g_003D_003D & 4) == 4)
			{
				triangle.VisibleEdgeFlag |= 4;
			}
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(triangle, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			return triangle;
		}
		Quad quad = new Quad(array[0], array[1], array[2], array[3]);
		quad.VisibleEdgeFlag = 0;
		if ((_0023_003DzETeDI6Pugpjz._0023_003Dz_0024QBfiC_00241iV_0024Nfg7G6g_003D_003D & 1) == 1)
		{
			quad.VisibleEdgeFlag |= 1;
		}
		if ((_0023_003DzETeDI6Pugpjz._0023_003Dz_0024QBfiC_00241iV_0024Nfg7G6g_003D_003D & 2) == 2)
		{
			quad.VisibleEdgeFlag |= 2;
		}
		if ((_0023_003DzETeDI6Pugpjz._0023_003Dz_0024QBfiC_00241iV_0024Nfg7G6g_003D_003D & 4) == 4)
		{
			quad.VisibleEdgeFlag |= 4;
		}
		if ((_0023_003DzETeDI6Pugpjz._0023_003Dz_0024QBfiC_00241iV_0024Nfg7G6g_003D_003D & 8) == 8)
		{
			quad.VisibleEdgeFlag |= 8;
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(quad, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return quad;
	}

	private Entity _0023_003DzfLPBio4Tv0xc(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private Mesh _0023_003DzqyEDItIHfCqH74lqXwKNTQc_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzhENEtLLHryGA)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003Dzzfv5ud5Q7Vjx(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003Dz8JpE3wJqYhqC(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzAhCqvHRc4IZMWlScClLB1HSoV3gLMy2RBg_003D_003D _0023_003DzmWq5yVexUgkD = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzmWq5yVexUgkD;
		_0023_003DzJIBslYQaoXnzK1MAq4mqDtjLgRzg _0023_003DzAU5e7ML4pj6L = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzmWq5yVexUgkD._0023_003DzxziTOkrXFzFi._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzAU5e7ML4pj6L;
		string text;
		try
		{
			string _0023_003DzS_00246o7tc_003D = _0023_003DzAU5e7ML4pj6L._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D;
			text = _0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ + _0023_003DzS_00246o7tc_003D.TrimStart('*');
			if (_0023_003DzELu0Pss_003D._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB.ContainsKey(text))
			{
				text = _0023_003DzELu0Pss_003D._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB[text];
			}
		}
		catch (Exception)
		{
			return null;
		}
		double[] array = _0023_003Dzh4Wf7tlUUlDt(_0023_003DzmWq5yVexUgkD._0023_003Dz0R7qasJeCI_s);
		BlockReference blockReference = new BlockReference(array[0], array[1], array[2], text, _0023_003DzmWq5yVexUgkD._0023_003DzoMBKEgY_003D._0023_003DzBJFJHwk_003D, _0023_003DzmWq5yVexUgkD._0023_003DzoMBKEgY_003D._0023_003Dz40R7bAU_003D, _0023_003DzmWq5yVexUgkD._0023_003DzoMBKEgY_003D._0023_003DzId5C3LA_003D, _0023_003DzmWq5yVexUgkD._0023_003DzVvkLpZU_003D);
		double[] array2 = _0023_003DzdZJdWj61QN4u(_0023_003DzmWq5yVexUgkD._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		if (array2[2] != 1.0)
		{
			Plane xY = Plane.XY;
			Plane plane = _0023_003DztIc79mb2zQ0f(array2, 0.0);
			Transformation transformation = new Transformation();
			transformation.Translation(0.0 - array[0], 0.0 - array[1], 0.0 - array[2]);
			Transformation transformation2 = new Transformation();
			transformation2.Rotation(xY.AxisX, xY.AxisY, xY.AxisZ, plane.AxisX, plane.AxisY, plane.AxisZ);
			Transformation transformation3 = new Transformation();
			transformation3.Translation(array[0], array[1], array[2]);
			blockReference.TransformBy(transformation3 * transformation2 * transformation);
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(blockReference, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		if (_0023_003DzmWq5yVexUgkD._0023_003Dz71No6HVrAku6 == '\u0001')
		{
			_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D[] _0023_003Dzj48KiIQ_003D = _0023_003DzmWq5yVexUgkD._0023_003Dzj48KiIQ_003D;
			foreach (_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D2 in _0023_003Dzj48KiIQ_003D)
			{
				_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D2._0023_003Dzsfb7U1TFH2wE);
				if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 == null)
				{
					log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001234), _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D2));
					continue;
				}
				_0023_003DzDpYNuA87njLP189ewQLdlq4_003D _0023_003Dz3nNqLJ4_003D = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz3nNqLJ4_003D;
				AttributeReference attributeReference = _0023_003DzFdchMug_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2, _0023_003DzELu0Pss_003D);
				attributeReference.WidthFactor *= Math.Abs(_0023_003DzmWq5yVexUgkD._0023_003DzoMBKEgY_003D._0023_003Dz40R7bAU_003D / _0023_003DzmWq5yVexUgkD._0023_003DzoMBKEgY_003D._0023_003DzBJFJHwk_003D);
				attributeReference.Height /= Math.Abs(_0023_003DzmWq5yVexUgkD._0023_003DzoMBKEgY_003D._0023_003Dz40R7bAU_003D);
				string text2 = _0023_003Dz3nNqLJ4_003D._0023_003Dzo4ntpKk_003D;
				if (blockReference.Attributes.ContainsKey(text2))
				{
					text2 = _0023_003DzRCP_0024_DgLkyfr(blockReference.Attributes, text2);
				}
				blockReference.Attributes.Add(text2, attributeReference);
			}
		}
		return blockReference;
	}

	[IteratorStateMachine(typeof(_0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D))]
	private IEnumerable<_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D> _0023_003DzW3utHH0ehIhj(_0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, _0023_003DzcnLDdsVpLi_ZqzFOTdAwIcY_003D _0023_003Dzcoe2_tewkWc6)
	{
		return new _0023_003DzgvT694_0024Rq6xbfuuz96k1rf8_003D(-2)
		{
			_0023_003Dzja9gywQIhYG_ = _0023_003DzELu0Pss_003D,
			_0023_003Dz8nuxCHDrYlpJq1_0024Mig_003D_003D = _0023_003Dzcoe2_tewkWc6
		};
	}

	private Entity _0023_003DzTV0E4RQU4BKB(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzcnLDdsVpLi_ZqzFOTdAwIcY_003D _0023_003Dz9rm_0024LlA_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz9rm_0024LlA_003D;
		_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz9rm_0024LlA_003D._0023_003DzxziTOkrXFzFi._0023_003Dzsfb7U1TFH2wE);
		if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001973) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		string _0023_003DzS_00246o7tc_003D = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzAU5e7ML4pj6L._0023_003DzPyofyVbkaTED._0023_003DzCX9Hbao_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzGTziT4A_003D._0023_003DzS_00246o7tc_003D;
		string text = _0023_003DzELu0Pss_003D._0023_003Dzi_i_00249LM56LFZ + _0023_003DzS_00246o7tc_003D.TrimStart('*');
		if (_0023_003DzELu0Pss_003D._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB.ContainsKey(text))
		{
			text = _0023_003DzELu0Pss_003D._0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB[text];
		}
		Transformation.AutocadOCS(_0023_003DzlvGiL_QdgBbL(_0023_003Dz9rm_0024LlA_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), out var xAxis, out var yAxis);
		double[] array = _0023_003Dz9rm_0024LlA_003D._0023_003Dz0R7qasJeCI_s._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(new Plane(Point3D.Origin, xAxis, yAxis)).ToArray();
		BlockReference blockReference = new BlockReference(array[0], array[1], array[2], text, _0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003DzBJFJHwk_003D, _0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003Dz40R7bAU_003D, _0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003DzId5C3LA_003D, _0023_003Dz9rm_0024LlA_003D._0023_003DzVvkLpZU_003D);
		double[] array2 = _0023_003DzdZJdWj61QN4u(_0023_003Dz9rm_0024LlA_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		if (array2[2] != 1.0)
		{
			Plane xY = Plane.XY;
			Plane plane = _0023_003DztIc79mb2zQ0f(array2, 0.0);
			Transformation transformation = new Transformation();
			transformation.Translation(0.0 - array[0], 0.0 - array[1], 0.0 - array[2]);
			Transformation transformation2 = new Transformation();
			transformation2.Rotation(xY.AxisX, xY.AxisY, xY.AxisZ, plane.AxisX, plane.AxisY, plane.AxisZ);
			Transformation transformation3 = new Transformation();
			transformation3.Translation(array[0], array[1], array[2]);
			blockReference.TransformBy(transformation3 * transformation2 * transformation);
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(blockReference, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		if (_0023_003Dz9rm_0024LlA_003D._0023_003Dz71No6HVrAku6 == '\u0001')
		{
			if (_0023_003Dz9rm_0024LlA_003D._0023_003Dzj48KiIQ_003D == null)
			{
				foreach (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D item in _0023_003DzW3utHH0ehIhj(_0023_003DzELu0Pss_003D, _0023_003Dz9rm_0024LlA_003D))
				{
					if (item == null)
					{
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001905));
						continue;
					}
					_0023_003DzDpYNuA87njLP189ewQLdlq4_003D _0023_003Dz3nNqLJ4_003D = item._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz3nNqLJ4_003D;
					AttributeReference attributeReference = _0023_003DzFdchMug_003D(item, _0023_003DzELu0Pss_003D);
					attributeReference.WidthFactor *= Math.Abs(_0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003Dz40R7bAU_003D / _0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003DzBJFJHwk_003D);
					attributeReference.Height /= Math.Abs(_0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003Dz40R7bAU_003D);
					string text2 = _0023_003Dz3nNqLJ4_003D._0023_003Dzo4ntpKk_003D;
					if (blockReference.Attributes.ContainsKey(text2))
					{
						text2 = _0023_003DzRCP_0024_DgLkyfr(blockReference.Attributes, text2);
					}
					blockReference.Attributes.Add(text2, attributeReference);
				}
			}
			else
			{
				_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D[] _0023_003Dzj48KiIQ_003D = _0023_003Dz9rm_0024LlA_003D._0023_003Dzj48KiIQ_003D;
				foreach (_0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D2 in _0023_003Dzj48KiIQ_003D)
				{
					_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D2._0023_003Dzsfb7U1TFH2wE);
					if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3 == null)
					{
						log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001234), _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D2));
						continue;
					}
					_0023_003DzDpYNuA87njLP189ewQLdlq4_003D _0023_003Dz3nNqLJ4_003D2 = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz3nNqLJ4_003D;
					AttributeReference attributeReference2 = _0023_003DzFdchMug_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D3, _0023_003DzELu0Pss_003D);
					attributeReference2.WidthFactor *= Math.Abs(_0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003Dz40R7bAU_003D / _0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003DzBJFJHwk_003D);
					attributeReference2.Height /= Math.Abs(_0023_003Dz9rm_0024LlA_003D._0023_003DzoMBKEgY_003D._0023_003Dz40R7bAU_003D);
					string text3 = _0023_003Dz3nNqLJ4_003D2._0023_003Dzo4ntpKk_003D;
					if (blockReference.Attributes.ContainsKey(text3))
					{
						text3 = _0023_003DzRCP_0024_DgLkyfr(blockReference.Attributes, text3);
					}
					blockReference.Attributes.Add(text3, attributeReference2);
				}
			}
		}
		return blockReference;
	}

	internal static string _0023_003DzRCP_0024_DgLkyfr(AttributeReferenceDictionary _0023_003DzqP5lTto_003D, string _0023_003Dzo4ntpKk_003D)
	{
		int num = 1;
		string text = _0023_003Dzo4ntpKk_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027);
		while (_0023_003DzqP5lTto_003D.ContainsKey(text + num))
		{
			num++;
		}
		return text + num;
	}

	private _0023_003Dzw7QT09EaLKBdtibL6A_003D_003D _0023_003DzPwhvCyymWADc(int _0023_003DzyzK8swU_003D)
	{
		if (_0023_003DzyzK8swU_003D < 0 || _0023_003DzyzK8swU_003D > 256)
		{
			return null;
		}
		uint _0023_003DzFd5hios_003D;
		int _0023_003DzJTQziP0_003D;
		switch (_0023_003DzyzK8swU_003D)
		{
		case 0:
			_0023_003DzFd5hios_003D = 3238002688u;
			_0023_003DzJTQziP0_003D = 193;
			break;
		case 256:
			_0023_003DzFd5hios_003D = 3221225472u;
			_0023_003DzJTQziP0_003D = 192;
			break;
		default:
			_0023_003DzFd5hios_003D = (uint)(-1023410176 + _0023_003DzyzK8swU_003D);
			_0023_003DzJTQziP0_003D = 195;
			break;
		}
		return new _0023_003Dzw7QT09EaLKBdtibL6A_003D_003D
		{
			_0023_003DzyzK8swU_003D = (short)_0023_003DzyzK8swU_003D,
			_0023_003DzFd5hios_003D = _0023_003DzFd5hios_003D,
			_0023_003DzJTQziP0_003D = _0023_003DzJTQziP0_003D
		};
	}

	private void _0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003DzhEn8_iQ_003D, _0023_003DzTfJR39huE1aP _0023_003DzBGxbbB5kRlyz2o7VPw_003D_003D, object _0023_003DzPzO_0024GUk_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		switch (_0023_003DzBGxbbB5kRlyz2o7VPw_003D_003D)
		{
		case _0023_003DzTfJR39huE1aP.DIMPOST:
			_0023_003DzhEn8_iQ_003D._0023_003DzKvvCDB_0024beEn6 = Convert.ToString(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMAPOST:
			_0023_003DzhEn8_iQ_003D._0023_003DzRHcYYFX7WH1JIJ6XuA_003D_003D = Convert.ToString(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMSCALE:
			_0023_003DzhEn8_iQ_003D._0023_003DzBWO43tSG1emxw15YjA_003D_003D = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMASZ:
			_0023_003DzhEn8_iQ_003D._0023_003DzfMKMuEdcm0tt = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMEXO:
			_0023_003DzhEn8_iQ_003D._0023_003DzPlMtCT4JTzEJ = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMDLI:
			_0023_003DzhEn8_iQ_003D._0023_003DzQfWu2gcam9bk = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMEXE:
			_0023_003DzhEn8_iQ_003D._0023_003Dz_vbwjK7jzwnE = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMRND:
			_0023_003DzhEn8_iQ_003D._0023_003Dzeh8fF2cZocfu = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMDLE:
			_0023_003DzhEn8_iQ_003D._0023_003DzxKs1hnSSQEKH = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTP:
			_0023_003DzhEn8_iQ_003D._0023_003DzoINu11nVehLi = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTM:
			_0023_003DzhEn8_iQ_003D._0023_003DztYRx2KSazGKZ = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTOL:
			_0023_003DzhEn8_iQ_003D._0023_003DztVCz_0024_VYTacl = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMLIM:
			_0023_003DzhEn8_iQ_003D._0023_003DzEwxH0aaG1Gqa = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTIH:
			_0023_003DzhEn8_iQ_003D._0023_003Dz_u_0024e5LltrUjR = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTOH:
			_0023_003DzhEn8_iQ_003D._0023_003DzQ5wkCw_6tGIi = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMSE1:
			_0023_003DzhEn8_iQ_003D._0023_003DzATVjIS9Putvg = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMSE2:
			_0023_003DzhEn8_iQ_003D._0023_003DzTUjXw2vv7Zbg = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTAD:
			_0023_003DzhEn8_iQ_003D._0023_003DzKjSnWlHmEQ25 = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMZIN:
			_0023_003DzhEn8_iQ_003D._0023_003Dz_0024ExUXJnivF0y = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMAZIN:
			_0023_003DzhEn8_iQ_003D._0023_003Dz6xMnU7PAZF2_ = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTXT:
			_0023_003DzhEn8_iQ_003D._0023_003DzXMDGX0mLcrRu = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMCEN:
			_0023_003DzhEn8_iQ_003D._0023_003Dz_00240jd7P8HCcs5 = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTSZ:
			_0023_003DzhEn8_iQ_003D._0023_003DzxSmGGJSVFJba = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMALTF:
			_0023_003DzhEn8_iQ_003D._0023_003DzJi3JI8YYr7r9 = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMLFAC:
			_0023_003DzhEn8_iQ_003D._0023_003DzTiHZU0aam2ka = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTVP:
			_0023_003DzhEn8_iQ_003D._0023_003DzQuzb5G0be07R = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTFAC:
			_0023_003DzhEn8_iQ_003D._0023_003DzF6svcv33bDic = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMGAP:
			_0023_003DzhEn8_iQ_003D._0023_003DzJ84uIcrYGHGB = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMALTRND:
			_0023_003DzhEn8_iQ_003D._0023_003Dzjwjp7Ug4yKT7tWxFnQ_003D_003D = Convert.ToDouble(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMALT:
			_0023_003DzhEn8_iQ_003D._0023_003DzkhrfBdDXNXe5 = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMALTD:
			_0023_003DzhEn8_iQ_003D._0023_003Dza5uvzJSYf0gq = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTOFL:
			_0023_003DzhEn8_iQ_003D._0023_003DzyVO9r5t9b6WE = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMSAH:
			_0023_003DzhEn8_iQ_003D._0023_003DzPYKe8CTaCCaC = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTIX:
			_0023_003DzhEn8_iQ_003D._0023_003DzaHEFL3nLRPnS = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMSOXD:
			_0023_003DzhEn8_iQ_003D._0023_003DzIh_0024Amhe0BGnL = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMCLRD:
			_0023_003DzhEn8_iQ_003D._0023_003DzMkKx5qjSc9TZ = _0023_003DzPwhvCyymWADc((ushort)_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMCLRE:
			_0023_003DzhEn8_iQ_003D._0023_003DzrICsPvwb6Gsy = _0023_003DzPwhvCyymWADc((ushort)_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMCLRT:
			_0023_003DzhEn8_iQ_003D._0023_003Dzke1tr3vraA2B = _0023_003DzPwhvCyymWADc((ushort)_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMADEC:
			_0023_003DzhEn8_iQ_003D._0023_003DzGM62zn1x1zy4 = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMUNIT:
			_0023_003DzhEn8_iQ_003D._0023_003DzmGoBOjCG4ypX = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMDEC:
			_0023_003DzhEn8_iQ_003D._0023_003DzFkgfQX_WkAzF = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTDEC:
			_0023_003DzhEn8_iQ_003D._0023_003DzftaLHGinj94l = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMALTU:
			_0023_003DzhEn8_iQ_003D._0023_003DzRHcfxxLTyYmo = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMALTTD:
			_0023_003DzhEn8_iQ_003D._0023_003DzV4OKYAxaoxAqy756Ig_003D_003D = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMAUNIT:
			_0023_003DzhEn8_iQ_003D._0023_003Dzgkc7YY2tCxjIK_0024OuLg_003D_003D = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMFRAC:
			_0023_003DzhEn8_iQ_003D._0023_003DzMMfUqbWg0Tpj = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMLUNIT:
			_0023_003DzhEn8_iQ_003D._0023_003Dz5dBSaneq8iYxhVhLdg_003D_003D = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMDSEP:
			_0023_003DzhEn8_iQ_003D._0023_003DzjECQmTNjm0Xq = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTMOVE:
			_0023_003DzhEn8_iQ_003D._0023_003DzklxVIsbi02Z8r4Oq_0024w_003D_003D = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMJUST:
			_0023_003DzhEn8_iQ_003D._0023_003Dzvz4zY8gBjIpX = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMSD1:
			_0023_003DzhEn8_iQ_003D._0023_003DzGBp1D_c5P9WB = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMSD2:
			_0023_003DzhEn8_iQ_003D._0023_003DzGWd9vQii3_Ge = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTOLJ:
			_0023_003DzhEn8_iQ_003D._0023_003DzS7JOXLgKAgfy = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTZIN:
			_0023_003DzhEn8_iQ_003D._0023_003Dzh_00249BH3go2E54 = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMALTZ:
			_0023_003DzhEn8_iQ_003D._0023_003Dzp12oorb50O_0024S = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMALTTZ:
			_0023_003DzhEn8_iQ_003D._0023_003DzHNzbGArCsPEQQFHt1w_003D_003D = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMFIT:
			_0023_003DzhEn8_iQ_003D._0023_003DzTpFV77q7QhCA = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMUPT:
			_0023_003DzhEn8_iQ_003D._0023_003Dzb7DyCnV6SP3S = Convert.ToChar(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMATFIT:
			_0023_003DzhEn8_iQ_003D._0023_003DzvqCTTNTgHAM_gl_0024auw_003D_003D = Convert.ToUInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMTXSTY:
			_0023_003DzhEn8_iQ_003D._0023_003DzC_i6VzYMEbn45bucKg_003D_003D = new _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D
			{
				_0023_003DzCX9Hbao_003D = null,
				_0023_003Dzsfb7U1TFH2wE = Convert.ToInt64(_0023_003DzPzO_0024GUk_003D)
			};
			break;
		case _0023_003DzTfJR39huE1aP.DIMLDRBLK:
			_0023_003DzhEn8_iQ_003D._0023_003DzxPAQxP2yyqvRZ6e36g_003D_003D = new _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D
			{
				_0023_003DzCX9Hbao_003D = null,
				_0023_003Dzsfb7U1TFH2wE = Convert.ToInt64(_0023_003DzPzO_0024GUk_003D)
			};
			break;
		case _0023_003DzTfJR39huE1aP.DIMBLK:
			_0023_003DzhEn8_iQ_003D._0023_003DzyyM4EEEEtS_n = new _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D
			{
				_0023_003DzCX9Hbao_003D = null,
				_0023_003Dzsfb7U1TFH2wE = Convert.ToInt64(_0023_003DzPzO_0024GUk_003D)
			};
			break;
		case _0023_003DzTfJR39huE1aP.DIMBLK1:
			_0023_003DzhEn8_iQ_003D._0023_003DzyzCTgAfUrypj = new _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D
			{
				_0023_003DzCX9Hbao_003D = null,
				_0023_003Dzsfb7U1TFH2wE = Convert.ToInt64(_0023_003DzPzO_0024GUk_003D)
			};
			break;
		case _0023_003DzTfJR39huE1aP.DIMBLK2:
			_0023_003DzhEn8_iQ_003D._0023_003DzT_00246134ITGItu = new _0023_003DzEFVzpegW2EKTuQGfGvZoSnY_003D
			{
				_0023_003DzCX9Hbao_003D = null,
				_0023_003Dzsfb7U1TFH2wE = Convert.ToInt64(_0023_003DzPzO_0024GUk_003D)
			};
			break;
		case _0023_003DzTfJR39huE1aP.DIMLWD:
			_0023_003DzhEn8_iQ_003D._0023_003DzJhGCbuzk1eGn = Convert.ToInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		case _0023_003DzTfJR39huE1aP.DIMLWE:
			_0023_003DzhEn8_iQ_003D._0023_003DzO1sbZ_zZv8_C = Convert.ToInt16(_0023_003DzPzO_0024GUk_003D);
			break;
		}
	}

	private void _0023_003DzCPyqAJNEgRCm(_0023_003DzN5CxkjI2cEwNGCNgatXgmM1axxPe _0023_003Dzr_3OnS8_003D, out Point3D _0023_003DzeoY7iyo_003D, out Vector3D _0023_003DzZbOaTIM_003D, out Point3D _0023_003Dz2AZWQ2NrfVgE, out Point3D _0023_003Dzrp9kE6WEdfd8)
	{
		_0023_003DzeoY7iyo_003D = _0023_003Dzmq2_arBswhAA(_0023_003Dzr_3OnS8_003D._0023_003Dz_00242mKGNULbJnX);
		_0023_003DzZbOaTIM_003D = _0023_003DzlvGiL_QdgBbL(_0023_003Dzr_3OnS8_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		_0023_003Dz2AZWQ2NrfVgE = _0023_003Dzmq2_arBswhAA(_0023_003Dzr_3OnS8_003D._0023_003Dz_00242mKGNULbJnX);
		_0023_003Dzrp9kE6WEdfd8 = _0023_003Dzmq2_arBswhAA(_0023_003Dzr_3OnS8_003D._0023_003Dz6aqVJ6LfYNaRAyWJTg_003D_003D);
	}

	internal static toleranceType _0023_003DzFEqYFvyI9Oqw(char _0023_003Dzqwd3fRbYru_H, char _0023_003DzC1zxcMgKu0_00240, double _0023_003Dzjwq5f1UHVzoa, double _0023_003DzIG7ocTWv7dlB, double _0023_003DzZyknGJyLMPyb)
	{
		if (_0023_003Dzqwd3fRbYru_H == '\0' && _0023_003DzC1zxcMgKu0_00240 == '\0')
		{
			if (_0023_003DzZyknGJyLMPyb < 0.0)
			{
				return toleranceType.Basic;
			}
			return toleranceType.None;
		}
		if (_0023_003Dzqwd3fRbYru_H == '\u0001')
		{
			if (Utility.Compare(_0023_003Dzjwq5f1UHVzoa, _0023_003DzIG7ocTWv7dlB) == 0)
			{
				return toleranceType.Symmetrical;
			}
			return toleranceType.Deviation;
		}
		return toleranceType.Limits;
	}

	private _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003DzpQxOoUM7WgGE(_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D[] _0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003DzOFG_u8Nb5mN2, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzrHY7reY_003D == null)
		{
			return _0023_003DzOFG_u8Nb5mN2;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzOFG_u8Nb5mN2._0023_003Dzx9P_oXY_003D();
		bool flag = false;
		for (int i = 0; i < _0023_003DzrHY7reY_003D.Length; i++)
		{
			switch (_0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003DzzsSfH74_003D)
			{
			case '\u0002':
				flag = _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzQvuDavyq8RZL._0023_003DzQZRatpY_003D == '\0';
				continue;
			default:
				if (!flag)
				{
					continue;
				}
				break;
			case 'F':
				break;
			}
			string value = _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D.ToString();
			i++;
			char _0023_003DzzsSfH74_003D = _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003DzzsSfH74_003D;
			Enum.TryParse<_0023_003DzTfJR39huE1aP>(value, out var result);
			switch (_0023_003DzzsSfH74_003D)
			{
			case '\0':
				if (_0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzmUmfvNoj7TIG._0023_003DzsKlTvtQ_003D.Length != 0 && _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzmUmfvNoj7TIG._0023_003DzsKlTvtQ_003D[0] != 0)
				{
					_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, new string(_0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzmUmfvNoj7TIG._0023_003DzsKlTvtQ_003D), _0023_003DzELu0Pss_003D);
				}
				else if (_0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzkCmn7_0024Q7J0kWxtGBMg_003D_003D._0023_003DzsKlTvtQ_003D.Length != 0 && _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzkCmn7_0024Q7J0kWxtGBMg_003D_003D._0023_003DzsKlTvtQ_003D[0] != 0)
				{
					_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, new string(_0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzkCmn7_0024Q7J0kWxtGBMg_003D_003D._0023_003DzsKlTvtQ_003D), _0023_003DzELu0Pss_003D);
				}
				break;
			case '\u0001':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzmUPPAAUfK9kG._0023_003DzGk93_rs_003D, _0023_003DzELu0Pss_003D);
				break;
			case '\n':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzorx6XD93y6m4._0023_003DzlY77YgY_003D, _0023_003DzELu0Pss_003D);
				break;
			case '\v':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzorx6XD93y6m4._0023_003DzlY77YgY_003D, _0023_003DzELu0Pss_003D);
				break;
			case '\f':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzorx6XD93y6m4._0023_003DzlY77YgY_003D, _0023_003DzELu0Pss_003D);
				break;
			case '\r':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzorx6XD93y6m4._0023_003DzlY77YgY_003D, _0023_003DzELu0Pss_003D);
				break;
			case '\u0002':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzQvuDavyq8RZL._0023_003DzQZRatpY_003D, _0023_003DzELu0Pss_003D);
				break;
			case '\u0003':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003DzVfiR7Ss9npLc._0023_003DztIaJjPw_003D, _0023_003DzELu0Pss_003D);
				break;
			case '\u0004':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dz4jxD5gwsQ5F4._0023_003DzELu0Pss_003D, _0023_003DzELu0Pss_003D);
				break;
			case '(':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzj9qUCN8RXnHc._0023_003DzcoZdc94_003D, _0023_003DzELu0Pss_003D);
				break;
			case ')':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzj9qUCN8RXnHc._0023_003DzcoZdc94_003D, _0023_003DzELu0Pss_003D);
				break;
			case '*':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzj9qUCN8RXnHc._0023_003DzcoZdc94_003D, _0023_003DzELu0Pss_003D);
				break;
			case '\u0005':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dze_D_o0nlsB6H._0023_003Dz9j7EUB0_003D, _0023_003DzELu0Pss_003D);
				break;
			case 'F':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D, _0023_003DzELu0Pss_003D);
				break;
			case 'G':
				_0023_003DzTOfZwgSl6ERL(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, result, _0023_003DzrHY7reY_003D[i]._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dz0QpYXqOmiv7H._0023_003DzVHJsUbk_003D, _0023_003DzELu0Pss_003D);
				break;
			}
		}
		return _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2;
	}

	private void _0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(Dimension _0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003DzhEn8_iQ_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, _0023_003DzN5CxkjI2cEwNGCNgatXgmM1axxPe _0023_003DzHZ9seh2ABjYt)
	{
		int _0023_003Dz5dBSaneq8iYxhVhLdg_003D_003D = _0023_003DzhEn8_iQ_003D._0023_003Dz5dBSaneq8iYxhVhLdg_003D_003D;
		if (_0023_003Dz5dBSaneq8iYxhVhLdg_003D_003D < 7)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.LinearDimensionUnits = (linearDimensionUnitsType)_0023_003Dz5dBSaneq8iYxhVhLdg_003D_003D;
		}
		else
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.LinearDimensionUnits = linearDimensionUnitsType.Decimal;
		}
		_0023_003Dzfyln692eNua6(_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D, _0023_003DzhEn8_iQ_003D);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ArrowheadSize = _0023_003DzhEn8_iQ_003D._0023_003DzfMKMuEdcm0tt;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextGap = _0023_003DzhEn8_iQ_003D._0023_003DzJ84uIcrYGHGB;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextHorizontalPosition = _0023_003DzF8RvkF_0024sf1_0024zpxq4G_00242gJvo_003D(_0023_003DzhEn8_iQ_003D._0023_003Dzvz4zY8gBjIpX);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextVerticalPosition = _0023_003Dz0yOsiWvhZV7rteWmhwgDe9k_003D(_0023_003DzhEn8_iQ_003D._0023_003DzKjSnWlHmEQ25);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.UseDefaultTextPosition = (_0023_003DzHZ9seh2ABjYt._0023_003Dzjcx0hV4_003D & 0x80) == 0;
		if (_0023_003DzhEn8_iQ_003D._0023_003Dzke1tr3vraA2B != null && (_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextColorMethod = _0023_003DzarHeGWMdmft8(_0023_003DzhEn8_iQ_003D._0023_003Dzke1tr3vraA2B)) == colorMethodType.byEntity)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextColor = _0023_003DzHzDodfEv0nnc(_0023_003DzhEn8_iQ_003D._0023_003Dzke1tr3vraA2B);
		}
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ToleranceMode = _0023_003DzFEqYFvyI9Oqw(_0023_003DzhEn8_iQ_003D._0023_003DztVCz_0024_VYTacl, _0023_003DzhEn8_iQ_003D._0023_003DzEwxH0aaG1Gqa, _0023_003DzhEn8_iQ_003D._0023_003DzoINu11nVehLi, _0023_003DzhEn8_iQ_003D._0023_003DztYRx2KSazGKZ, _0023_003DzhEn8_iQ_003D._0023_003DzJ84uIcrYGHGB);
		if (_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ToleranceMode == toleranceType.Basic)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextGap = 0.0 - _0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextGap;
		}
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.UpperValue = _0023_003DzhEn8_iQ_003D._0023_003DzoINu11nVehLi;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.LowerValue = _0023_003DzhEn8_iQ_003D._0023_003DztYRx2KSazGKZ;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ScalingForHeight = _0023_003DzhEn8_iQ_003D._0023_003DzF6svcv33bDic;
		ushort _0023_003Dzh_00249BH3go2E = _0023_003DzhEn8_iQ_003D._0023_003Dzh_00249BH3go2E54;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ToleranceSuppressLeadingZeros = ((_0023_003Dzh_00249BH3go2E >> 2) & 1) != 0;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ToleranceSuppressTralingZeros = ((_0023_003Dzh_00249BH3go2E >> 3) & 1) != 0;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TolerancePrecision = _0023_003DzhEn8_iQ_003D._0023_003DzftaLHGinj94l;
		if (_0023_003DzhEn8_iQ_003D._0023_003DzBWO43tSG1emxw15YjA_003D_003D != 0.0)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ScaleOverall = _0023_003DzhEn8_iQ_003D._0023_003DzBWO43tSG1emxw15YjA_003D_003D;
		}
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.DimStyle = ((_0023_003DzhEn8_iQ_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000688)) ? string.Empty : _0023_003DzhEn8_iQ_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D);
		_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzhEn8_iQ_003D._0023_003DzC_i6VzYMEbn45bucKg_003D_003D._0023_003Dzsfb7U1TFH2wE);
		if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 != null)
		{
			_0023_003DzCJx_0024G2p_0024_QAHm48kA6tZa3E_003D _0023_003Dz4vDywqc_003D = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz4vDywqc_003D;
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.StyleName = _0023_003Dz4vDywqc_003D._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D;
			if (_0023_003Dz4vDywqc_003D._0023_003Dzw_0024baBGpTBKVJ != 0.0 && _0023_003DzhEn8_iQ_003D._0023_003DzBWO43tSG1emxw15YjA_003D_003D != 0.0)
			{
				_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.Height = _0023_003Dz4vDywqc_003D._0023_003Dzw_0024baBGpTBKVJ / _0023_003DzhEn8_iQ_003D._0023_003DzBWO43tSG1emxw15YjA_003D_003D;
			}
		}
	}

	private static void _0023_003Dzfyln692eNua6(Dimension _0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003DzhEn8_iQ_003D)
	{
		if (_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D is AngularDim)
		{
			char _0023_003Dz6xMnU7PAZF2_ = _0023_003DzhEn8_iQ_003D._0023_003Dz6xMnU7PAZF2_;
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.SuppressLeadingZeros = (_0023_003Dz6xMnU7PAZF2_ & 1) != 0;
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.SuppressTrailingZeros = (((int)_0023_003Dz6xMnU7PAZF2_ >> 1) & 1) != 0;
		}
		else
		{
			ushort _0023_003Dz_0024ExUXJnivF0y = _0023_003DzhEn8_iQ_003D._0023_003Dz_0024ExUXJnivF0y;
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.SuppressLeadingZeros = ((_0023_003Dz_0024ExUXJnivF0y >> 2) & 1) != 0;
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.SuppressTrailingZeros = ((_0023_003Dz_0024ExUXJnivF0y >> 3) & 1) != 0;
		}
	}

	private string _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(long _0023_003DzjzfU7sc_003D, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzjzfU7sc_003D);
		return _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzAU5e7ML4pj6L._0023_003DzPyofyVbkaTED._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzGTziT4A_003D._0023_003DzS_00246o7tc_003D ?? string.Empty;
	}

	private Entity _0023_003DzB8B0nHKDPlI6(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003Dz8WMAehYRpH0pFSnjdfegdOtqDwIeWeA27Tp0L_GSTx9l _0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY;
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _, _0023_003DzfpN7pnryJplL))
		{
			throw new NotImplementedException();
		}
		_0023_003DzCPyqAJNEgRCm(_0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003DzHZ9seh2ABjYt, out var _, out var _0023_003DzZbOaTIM_003D, out var _0023_003Dz2AZWQ2NrfVgE, out var _0023_003Dzrp9kE6WEdfd);
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003DzFi59_C5L4ZLl0LnZnQ_003D_003D);
		Point3D point3D2 = _0023_003Dzmq2_arBswhAA(_0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003Dz8SsZ_x5ZOkk4jRw1ew_003D_003D);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzZbOaTIM_003D.ToArray(), 0.0);
		_0023_003DzLqECXomsH96v5omFVw_003D_003D(plane, point3D, point3D2, _0023_003Dz2AZWQ2NrfVgE);
		Point3D dimLinePos = _0023_003Dz42rkBhNtmyOU(plane, point3D2, _0023_003Dz2AZWQ2NrfVgE, _0023_003Dzrp9kE6WEdfd);
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003DzHZ9seh2ABjYt._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001876) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		LinearDim linearDim = new LinearDim(plane, point3D, point3D2, dimLinePos, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzXMDGX0mLcrRu);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(linearDim, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3, _0023_003DzELu0Pss_003D, _0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003DzHZ9seh2ABjYt);
		linearDim.Precision = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzFkgfQX_WkAzF;
		linearDim.ExtLineOffset = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzPlMtCT4JTzEJ;
		linearDim.ExtLineExt = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003Dz_vbwjK7jzwnE;
		linearDim.ShowExtLine1 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzATVjIS9Putvg == '\0';
		linearDim.ShowExtLine2 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTUjXw2vv7Zbg == '\0';
		if (_0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D != null && _0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzMgzbHGtqc7Nt7tCRmLDh2GI_003D).Intersect(new List<int> { 342, 343, 344 }).Count() > 0)
		{
			if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzPYKe8CTaCCaC == '\u0001')
			{
				string text = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzyzCTgAfUrypj._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
				string text2 = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzT_00246134ITGItu._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
				if (text == string.Empty)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002076) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
				}
				if (text2 == string.Empty)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001703) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
				}
				linearDim.LeftArrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text);
				linearDim.RightArrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text2);
			}
			else
			{
				string text3 = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzyyM4EEEEtS_n._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
				if (text3 == string.Empty)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001631) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
				}
				arrowheadType leftArrowhead = (linearDim.RightArrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text3));
				linearDim.LeftArrowhead = leftArrowhead;
			}
		}
		linearDim.LinearScale = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTiHZU0aam2ka;
		_0023_003Dz65vloBQS4N5h(linearDim, _0023_003Dz_mrUCCgkTP4o6D42_0024o1d_0024d9D_1JY._0023_003DzHZ9seh2ABjYt._0023_003Dz9X4o8w6GAp5N, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzKvvCDB_0024beEn6);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearDim, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return linearDim;
	}

	private Entity _0023_003DzENcxqI_0024BKH1PCQp0tQ_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003Dzw6Ek9DXqbwnla9p3e8PlM5P_3IP9nga5VLZjxeJt7acF _0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w;
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _, _0023_003DzfpN7pnryJplL))
		{
			throw new NotImplementedException();
		}
		_0023_003DzCPyqAJNEgRCm(_0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt, out var _, out var _0023_003DzZbOaTIM_003D, out var _0023_003Dz2AZWQ2NrfVgE, out var _0023_003Dzrp9kE6WEdfd);
		Point3D extLine = _0023_003Dzmq2_arBswhAA(_0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzFi59_C5L4ZLl0LnZnQ_003D_003D);
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003Dz8SsZ_x5ZOkk4jRw1ew_003D_003D);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzZbOaTIM_003D.ToArray(), 0.0);
		double _0023_003Dz_UsRAoY4MFys = _0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003Dz_UsRAoY4MFys;
		if (!Utility.AreEqual(_0023_003Dz_UsRAoY4MFys, Math.PI, Math.PI * 2.0))
		{
			plane.Rotate(_0023_003Dz_UsRAoY4MFys, plane.AxisZ, Point3D.Origin);
		}
		_0023_003DztCFdmp_0024mpA4_0024(_0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt);
		Point3D dimLinePos = _0023_003Dz42rkBhNtmyOU(plane, point3D, _0023_003Dz2AZWQ2NrfVgE, _0023_003Dzrp9kE6WEdfd);
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001808) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		LinearDim linearDim = new LinearDim(plane, extLine, point3D, dimLinePos, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzXMDGX0mLcrRu);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(linearDim, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3, _0023_003DzELu0Pss_003D, _0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt);
		linearDim.Precision = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzFkgfQX_WkAzF;
		linearDim.ExtLineOffset = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzPlMtCT4JTzEJ;
		linearDim.ExtLineExt = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003Dz_vbwjK7jzwnE;
		linearDim.ShowExtLine1 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzATVjIS9Putvg == '\0';
		linearDim.ShowExtLine2 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTUjXw2vv7Zbg == '\0';
		if (_0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D != null && _0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzD3XNhRvQrIemsk0lWow_GIP5c7jw_UVRYg_003D_003D).Intersect(new List<int> { 342, 343, 344 }).Count() > 0)
		{
			if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzPYKe8CTaCCaC == '\u0001')
			{
				string text = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzyzCTgAfUrypj._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
				string text2 = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzT_00246134ITGItu._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
				if (text == string.Empty)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002488) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
				}
				if (text2 == string.Empty)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002413) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
				}
				linearDim.LeftArrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text);
				linearDim.RightArrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text2);
			}
			else
			{
				string text3 = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzyyM4EEEEtS_n._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
				if (text3 == string.Empty)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002565) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
				}
				arrowheadType leftArrowhead = (linearDim.RightArrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text3));
				linearDim.LeftArrowhead = leftArrowhead;
			}
		}
		linearDim.LinearScale = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTiHZU0aam2ka;
		_0023_003Dz65vloBQS4N5h(linearDim, _0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt._0023_003Dz9X4o8w6GAp5N, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzKvvCDB_0024beEn6);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearDim, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		linearDim.AutodeskProperties.UnparsedDimensionText = _0023_003Dzp23OxGcJx8bUKZ54KuJeF35asw2w._0023_003DzHZ9seh2ABjYt._0023_003Dz9X4o8w6GAp5N;
		return linearDim;
	}

	private bool _0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, out Entity _0023_003Dzs_0024uS8LA_003D, _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL)
	{
		_0023_003Dzs_0024uS8LA_003D = null;
		return false;
	}

	private Entity _0023_003Dz02YZjgyIS01t(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzFyTplFcHWcRc, Plane _0023_003Dzpyw2kZk_003D, Point3D _0023_003DzO97ip_0024TQ_0024juS, Point3D _0023_003DzM7o0gT3hjI42, Point3D _0023_003Dz2AZWQ2NrfVgE, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, bool _0023_003DzL7uQ2E_DVkh2)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzoOHtxsENBiu8bEHdgg_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzLGyHNq6AiWNjNMgyG50oxNpnLxGSvVonxI8bV1Alisvx _0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf;
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _, _0023_003DzfpN7pnryJplL))
		{
			throw new NotImplementedException();
		}
		_0023_003DzCPyqAJNEgRCm(_0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt, out var _0023_003DzeoY7iyo_003D, out var _0023_003DzZbOaTIM_003D, out var _0023_003Dz2AZWQ2NrfVgE, out var _0023_003Dzrp9kE6WEdfd);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzZbOaTIM_003D.ToArray(), _0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		Point3D definingPoint = _0023_003Dzmq2_arBswhAA(_0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzmCQzdFfO3zgQRToupw_003D_003D);
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzGk90xDvVJUFVYk_0024Gaz_2_Ck_003D);
		plane.Origin = _0023_003DzeoY7iyo_003D;
		_0023_003Dzrp9kE6WEdfd.Z = _0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt._0023_003Dz1Rls5bMv91nm31u74A_003D_003D;
		_0023_003Dzrp9kE6WEdfd = _0023_003Dzrp9kE6WEdfd._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane);
		if (_0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt._0023_003DzocU6Az4em4pyPiFlMg_003D_003D != 0.0)
		{
			plane.Rotate(0.0 - _0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt._0023_003DzocU6Az4em4pyPiFlMg_003D_003D, plane.AxisZ, plane.Origin);
		}
		bool flag = _0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzbHi6dec_003D == '\u0001';
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002230) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		Vector3D vector3D = (flag ? plane.AxisY : plane.AxisX);
		Segment3D seg = new Segment3D(point3D, point3D + vector3D);
		_0023_003Dz2AZWQ2NrfVgE = _0023_003Dzrp9kE6WEdfd.ProjectTo(seg);
		OrdinateDim ordinateDim = new OrdinateDim(plane, definingPoint, _0023_003Dz2AZWQ2NrfVgE, flag, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzXMDGX0mLcrRu);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(ordinateDim, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3, _0023_003DzELu0Pss_003D, _0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt);
		ordinateDim.Precision = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzFkgfQX_WkAzF;
		ordinateDim.ExtLineOffset = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzPlMtCT4JTzEJ;
		ordinateDim.LinearScale = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTiHZU0aam2ka;
		_0023_003Dz65vloBQS4N5h(ordinateDim, _0023_003Dz0c1slIcyzPfvKkenCghcQPJWWpvf._0023_003DzHZ9seh2ABjYt._0023_003Dz9X4o8w6GAp5N, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzKvvCDB_0024beEn6);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(ordinateDim, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return ordinateDim;
	}

	private Entity _0023_003Dzboe_0024sThAOtUt(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzBqlxqq4WlwS_(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzkLREJtM_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzFiu4erjv_0024gVqTQRyp4KzOyoWVJM_0024 _0023_003Dz3OY3BrX69qIe = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz3OY3BrX69qIe;
		if (ExplodeDimensions && _0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, _0023_003DzfpN7pnryJplL))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		Plane pln = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dz3OY3BrX69qIe._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), 0.0);
		Enum.TryParse<_0023_003DzBXBxitM_003D>(_0023_003Dz3OY3BrX69qIe._0023_003Dz3AmFrD8QYBnJ.ToString(), out var result);
		if (result != _0023_003DzBXBxitM_003D.None)
		{
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz3OY3BrX69qIe._0023_003Dze2Shg5RCcwAF._0023_003Dzsfb7U1TFH2wE);
			if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 == null)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002173) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002346));
			}
			else
			{
				switch (result)
				{
				case _0023_003DzBXBxitM_003D.Text:
					pln = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dzp5SIhaysv4So._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), 0.0);
					break;
				case _0023_003DzBXBxitM_003D.Insert:
					pln = _0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz9rm_0024LlA_003D._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D), 0.0);
					break;
				}
			}
		}
		List<Point3D> list = new List<Point3D>();
		int _0023_003Dzl854Q0bMjSxQ = (int)_0023_003Dz3OY3BrX69qIe._0023_003Dzl854Q0bMjSxQ;
		if (_0023_003Dzl854Q0bMjSxQ < 2)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002331));
		}
		for (int i = 0; i < _0023_003Dzl854Q0bMjSxQ; i++)
		{
			list.Add(_0023_003Dzmq2_arBswhAA(_0023_003Dz3OY3BrX69qIe._0023_003DzrdSL0CI_003D[i]));
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz3OY3BrX69qIe._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002286) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003Dz3OY3BrX69qIe._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		arrowheadType arrowhead = arrowheadType.Arrow;
		if (_0023_003Dz3OY3BrX69qIe._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D != null && ((IEnumerable<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D>)_0023_003Dz3OY3BrX69qIe._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D).Select((Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, int>)((_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003Dz437_00244ak_003D) => _0023_003Dz437_00244ak_003D._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D)).Intersect(new List<int> { 342, 343, 344 }).Count() > 0)
		{
			string text = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzyyM4EEEEtS_n._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
			if (text == string.Empty)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002985) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002926));
			}
			arrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text);
		}
		_ = _0023_003Dz3OY3BrX69qIe._0023_003DzzswhXJNu8n__0024;
		Leader leader = new Leader(pln, list.ToArray(), _0023_003Dz3OY3BrX69qIe._0023_003DzXkK_9JWb2sI9217lCw_003D_003D == '\u0001', _0023_003Dz3OY3BrX69qIe._0023_003Dz9CfoOcemMrqvo_0024nX9w_003D_003D == '\u0001', arrowhead, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzfMKMuEdcm0tt, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzBWO43tSG1emxw15YjA_003D_003D);
		leader.ShowArrowHead = _0023_003Dz3OY3BrX69qIe._0023_003Dz99b9fZTgkOEHZIpe9cGXdHs_003D == '\u0001';
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(leader, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return leader;
	}

	private static string _0023_003Dz7dWp4YQ_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzXULhp_00248_003D)
	{
		throw new NotImplementedException();
	}

	internal static double[] _0023_003Dzh4Wf7tlUUlDt(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new double[3]
		{
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003DzBJFJHwk_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003Dz40R7bAU_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003DzId5C3LA_003D)
		};
	}

	internal static double[] _0023_003Dzh4Wf7tlUUlDt(_0023_003Dz25XJrJIetZ23qUhcBtaV9aOv_sJhH9e8gw_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new double[3]
		{
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003DzBJFJHwk_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003Dz40R7bAU_003D),
			0.0
		};
	}

	internal static double[] _0023_003Dzh4Wf7tlUUlDt(_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new double[3]
		{
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003DzBJFJHwk_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003Dz40R7bAU_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003DzId5C3LA_003D)
		};
	}

	internal static double[] _0023_003Dzh4Wf7tlUUlDt(_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new double[3]
		{
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003DzBJFJHwk_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D._0023_003Dz40R7bAU_003D),
			0.0
		};
	}

	internal static Point3D _0023_003Dzmq2_arBswhAA(_0023_003Dz25XJrJIetZ23qUhcBtaV9aOv_sJhH9e8gw_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
	}

	internal static Point3D _0023_003Dzmq2_arBswhAA(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
	}

	internal static Point3D _0023_003Dzmq2_arBswhAA(_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
	}

	internal static Point3D _0023_003Dzmq2_arBswhAA(_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
	}

	internal static Point2D _0023_003DzUnxHUznPiV7g(_0023_003Dz25XJrJIetZ23qUhcBtaV9aOv_sJhH9e8gw_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new Point2D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
	}

	internal static Point2D _0023_003DzUnxHUznPiV7g(_0023_003Dzt0vc_0024bWMDcGrN3_3oeRxiUi5sn1I4wXd4A_003D_003D _0023_003DzlY77YgY_003D)
	{
		return new Point2D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
	}

	private static double[] _0023_003DzdZJdWj61QN4u(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D _0023_003DzhLyxqqrgjQmH)
	{
		return new double[3]
		{
			_0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH._0023_003DzBJFJHwk_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH._0023_003Dz40R7bAU_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH._0023_003DzId5C3LA_003D)
		};
	}

	private static double[] _0023_003DzdZJdWj61QN4u(_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D _0023_003DzhLyxqqrgjQmH)
	{
		return new double[3]
		{
			_0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH._0023_003DzBJFJHwk_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH._0023_003Dz40R7bAU_003D),
			_0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH._0023_003DzId5C3LA_003D)
		};
	}

	internal static Vector3D _0023_003DzlvGiL_QdgBbL(_0023_003Dzv1xYz4vP1uodvImerKneh9da6jYijm1lcQ_003D_003D _0023_003DzhLyxqqrgjQmH)
	{
		return new Vector3D(_0023_003DzdZJdWj61QN4u(_0023_003DzhLyxqqrgjQmH));
	}

	internal static Vector3D _0023_003DzlvGiL_QdgBbL(_0023_003DzzywK7yAQdHCtmcasiGFQueO8qwoEHssLjw_003D_003D _0023_003DzhLyxqqrgjQmH)
	{
		return new Vector3D(_0023_003DzdZJdWj61QN4u(_0023_003DzhLyxqqrgjQmH));
	}

	internal static Plane _0023_003DzNY5YUv279_SW(object _0023_003Dz12eJSlBUy_00249q2lCIWA_003D_003D)
	{
		throw new NotImplementedException();
	}

	internal static double _0023_003DzgRf1Kl0_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		if (Math.Abs(_0023_003DzPzO_0024GUk_003D) > 100000000000000.0)
		{
			return 0.0;
		}
		return _0023_003DzPzO_0024GUk_003D;
	}

	internal static double[] _0023_003DzR6INDB9Oz9uo(double[] _0023_003DzHSO_00246A0_003D)
	{
		double[] array = new double[_0023_003DzHSO_00246A0_003D.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzgRf1Kl0_003D(_0023_003DzHSO_00246A0_003D[i]);
		}
		return array;
	}

	private static void _0023_003DztqqiFz7oOWGZ(Vector3D _0023_003DzY5pSLwI_003D)
	{
		_0023_003DzY5pSLwI_003D.X = _0023_003DzgRf1Kl0_003D(_0023_003DzY5pSLwI_003D.X);
		_0023_003DzY5pSLwI_003D.Y = _0023_003DzgRf1Kl0_003D(_0023_003DzY5pSLwI_003D.Y);
		_0023_003DzY5pSLwI_003D.Z = _0023_003DzgRf1Kl0_003D(_0023_003DzY5pSLwI_003D.Z);
	}

	internal static arrowheadType _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(string _0023_003DzuwH5j5s_003D)
	{
		string text = _0023_003DzuwH5j5s_003D.ToUpper();
		if (!(text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002890)))
		{
			if (!(text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003130)))
			{
				if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003107))
				{
					return arrowheadType.Oblique;
				}
				return arrowheadType.Arrow;
			}
			return arrowheadType.Dot;
		}
		return arrowheadType.Tick;
	}

	internal static string _0023_003DznfXa3AI3NPN91l01HXlvcH_NP92e(arrowheadType _0023_003Dzud0AEEw_003D)
	{
		return _0023_003Dzud0AEEw_003D switch
		{
			arrowheadType.Tick => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002890), 
			arrowheadType.Dot => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003130), 
			arrowheadType.Oblique => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003107), 
			_ => string.Empty, 
		};
	}

	internal static Point3D _0023_003Dz42rkBhNtmyOU(Plane _0023_003Dzpyw2kZk_003D, Point3D _0023_003DzbApOAdcGQJZQ, Point3D _0023_003Dz2AZWQ2NrfVgE, Point3D _0023_003Dzrp9kE6WEdfd8)
	{
		Segment3D seg = new Segment3D(_0023_003DzbApOAdcGQJZQ, _0023_003DzbApOAdcGQJZQ + _0023_003Dzpyw2kZk_003D.AxisY);
		Point3D b = _0023_003Dzrp9kE6WEdfd8.ProjectTo(seg);
		return _0023_003Dzrp9kE6WEdfd8 + Vector3D.Dot(Vector3D.Subtract(_0023_003Dz2AZWQ2NrfVgE, b), _0023_003Dzpyw2kZk_003D.AxisY) * _0023_003Dzpyw2kZk_003D.AxisY;
	}

	private void _0023_003DztCFdmp_0024mpA4_0024(_0023_003DzN5CxkjI2cEwNGCNgatXgmM1axxPe _0023_003Dzr_3OnS8_003D)
	{
		double[] array = _0023_003Dzh4Wf7tlUUlDt(_0023_003Dzr_3OnS8_003D._0023_003Dz6aqVJ6LfYNaRAyWJTg_003D_003D);
		if ((_0023_003Dzr_3OnS8_003D._0023_003DzYv_7Eo8_003D & 0x80) != 128)
		{
			Array.TrueForAll(array, (double _0023_003DzXrexKjY_003D) => _0023_003DzXrexKjY_003D == 0.0);
		}
	}

	private Entity _0023_003DznW93rAUBvf38(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003Dz3PadSvVWfwNfL42xSDVnPDjZQu7BpTDzA7VB__stVkv_0024 _0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo;
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _, _0023_003DzfpN7pnryJplL))
		{
			throw new NotImplementedException();
		}
		_0023_003DzCPyqAJNEgRCm(_0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003DzHZ9seh2ABjYt, out var _0023_003DzeoY7iyo_003D, out var _0023_003DzZbOaTIM_003D, out var _, out var _0023_003Dzrp9kE6WEdfd);
		Point3D point3D = _0023_003DzeoY7iyo_003D;
		Point3D b = _0023_003Dzmq2_arBswhAA(_0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003Dz28meUmKNh363lGdElA_003D_003D);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzZbOaTIM_003D.ToArray(), _0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003DzHZ9seh2ABjYt._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		double num = Point3D.Distance(point3D, b);
		if (num < 1E-12)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003092), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
			return null;
		}
		Circle circle = new Circle(plane, point3D, num);
		_0023_003Dzrp9kE6WEdfd = _0023_003Dzrp9kE6WEdfd._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane);
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003DzHZ9seh2ABjYt._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003047) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		RadialDim radialDim = new RadialDim(circle, _0023_003Dzrp9kE6WEdfd, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzXMDGX0mLcrRu);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(radialDim, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3, _0023_003DzELu0Pss_003D, _0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003DzHZ9seh2ABjYt);
		radialDim.Precision = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzFkgfQX_WkAzF;
		if (_0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D != null && ((IEnumerable<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D>)_0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D).Select((Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, int>)((_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003Dz437_00244ak_003D) => _0023_003Dz437_00244ak_003D._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D)).Intersect(new List<int> { 342, 343, 344 }).Count() > 0)
		{
			string text = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzT_00246134ITGItu._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
			if (text == string.Empty)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002734) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
			}
			radialDim.Arrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text);
		}
		radialDim.LinearScale = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTiHZU0aam2ka;
		radialDim.CenterMarkSize = Math.Abs(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003Dz_00240jd7P8HCcs5);
		radialDim.TrimLeader = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzklxVIsbi02Z8r4Oq_0024w_003D_003D != 2;
		_0023_003Dz65vloBQS4N5h(radialDim, _0023_003DzDq4X6HxeLgosR6GHoSyZTUdo9gPo._0023_003DzHZ9seh2ABjYt._0023_003Dz9X4o8w6GAp5N, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzKvvCDB_0024beEn6);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(radialDim, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return radialDim;
	}

	private Entity _0023_003DzuRzGetAm14NIaaQeYNyCkHE_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzibnaMU7SM2TnXFXftv9XxJX_0024KIO6EaJRUKwzdoE8fV3c _0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr;
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _, _0023_003DzfpN7pnryJplL))
		{
			throw new NotImplementedException();
		}
		_0023_003DzCPyqAJNEgRCm(_0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003DzHZ9seh2ABjYt, out var _0023_003DzeoY7iyo_003D, out var _0023_003DzZbOaTIM_003D, out var _, out var _0023_003Dzrp9kE6WEdfd);
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003Dz28meUmKNh363lGdElA_003D_003D);
		Point3D b = _0023_003DzeoY7iyo_003D;
		Point3D point3D2 = Point3D.MidPoint(point3D, b);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzZbOaTIM_003D.ToArray(), _0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003DzHZ9seh2ABjYt._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		double num = Point3D.Distance(point3D2, point3D);
		if (num < 1E-12)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003092), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
			return null;
		}
		Circle circle = new Circle(plane, point3D2, num);
		_0023_003Dzrp9kE6WEdfd = _0023_003Dzrp9kE6WEdfd._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane);
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003DzHZ9seh2ABjYt._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003047) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		DiametricDim diametricDim = new DiametricDim(circle, _0023_003Dzrp9kE6WEdfd, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzXMDGX0mLcrRu);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(diametricDim, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3, _0023_003DzELu0Pss_003D, _0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003DzHZ9seh2ABjYt);
		diametricDim.Precision = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzFkgfQX_WkAzF;
		if (_0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D != null && ((IEnumerable<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D>)_0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D).Select((Func<_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D, int>)((_0023_003DzvrnbRXV_0024nOp_KfLLEgPF9AU_003D _0023_003Dz437_00244ak_003D) => _0023_003Dz437_00244ak_003D._0023_003DzELu0Pss_003D._0023_003Dz_eY3Y4c_003D._0023_003Dzln3qnYN3mZh8._0023_003Dzwpg6eD8_003D)).Intersect(new List<int> { 342, 343, 344 }).Count() > 0)
		{
			string text = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzT_00246134ITGItu._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
			string text2 = _0023_003DzjnFZ6jnkuIVyN0klPSfwp6E_003D(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzyzCTgAfUrypj._0023_003Dzsfb7U1TFH2wE, _0023_003DzELu0Pss_003D);
			if (text == string.Empty)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002649) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
			}
			if (text2 == string.Empty)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002804) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001713));
			}
			diametricDim.LeftArrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text);
			diametricDim.RightArrowhead = _0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(text2);
		}
		diametricDim.LinearScale = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTiHZU0aam2ka;
		diametricDim.CenterMarkSize = Math.Abs(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003Dz_00240jd7P8HCcs5);
		_0023_003Dz65vloBQS4N5h(diametricDim, _0023_003DzrZB_TSYyYAh_4pCvl4KXm920t5jr._0023_003DzHZ9seh2ABjYt._0023_003Dz9X4o8w6GAp5N, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzKvvCDB_0024beEn6);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(diametricDim, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return diametricDim;
	}

	private void _0023_003Dz6LGpzi9Ck1X_0024(int _0023_003DzXD9Cqyhrz4iU, ref AngularDim _0023_003DzaVdSMzhr5rnc)
	{
		switch (_0023_003DzXD9Cqyhrz4iU)
		{
		case 0:
			_0023_003DzaVdSMzhr5rnc.AngleFormat = angleFormatType.DecimalDegrees;
			break;
		case 1:
			_0023_003DzaVdSMzhr5rnc.AngleFormat = angleFormatType.DegMinSec;
			break;
		case 2:
			_0023_003DzaVdSMzhr5rnc.AngleFormat = angleFormatType.Gradians;
			break;
		case 3:
			_0023_003DzaVdSMzhr5rnc.AngleFormat = angleFormatType.Radians;
			break;
		}
	}

	private Entity _0023_003DzyXtdDh_3bSdUtCBHlX3aq10_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003Dz8VrQz3GarLbPRP9aVWjl7nZooYbF3hFbM74FAq3zP5Cw _0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG;
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _, _0023_003DzfpN7pnryJplL))
		{
			throw new NotImplementedException();
		}
		_0023_003DzCPyqAJNEgRCm(_0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG._0023_003DzHZ9seh2ABjYt, out var _, out var _0023_003DzZbOaTIM_003D, out var _, out var _0023_003Dzrp9kE6WEdfd);
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG._0023_003DzDmF4ICT2K4gU);
		Point3D point3D2 = _0023_003Dzmq2_arBswhAA(_0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG._0023_003DzFi59_C5L4ZLl0LnZnQ_003D_003D);
		Point3D point3D3 = _0023_003Dzmq2_arBswhAA(_0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG._0023_003Dz8SsZ_x5ZOkk4jRw1ew_003D_003D);
		double num = point3D.DistanceTo(point3D2);
		if (num == 0.0 || Point3D.AreEqual(point3D2, point3D3, num))
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003502) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzZbOaTIM_003D.ToArray(), 0.0);
		plane.Origin = point3D;
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG._0023_003DzHZ9seh2ABjYt._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003427) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		AngularDim _0023_003DzaVdSMzhr5rnc = new AngularDim(plane, point3D2, point3D3, _0023_003Dzrp9kE6WEdfd, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzXMDGX0mLcrRu);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(_0023_003DzaVdSMzhr5rnc, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3, _0023_003DzELu0Pss_003D, _0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG._0023_003DzHZ9seh2ABjYt);
		_0023_003DzaVdSMzhr5rnc.ShowExtLine1 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzATVjIS9Putvg == '\0';
		_0023_003DzaVdSMzhr5rnc.ShowExtLine2 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTUjXw2vv7Zbg == '\0';
		_0023_003Dz6LGpzi9Ck1X_0024(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003Dzgkc7YY2tCxjIK_0024OuLg_003D_003D, ref _0023_003DzaVdSMzhr5rnc);
		_0023_003DzaVdSMzhr5rnc.Precision = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzGM62zn1x1zy4;
		_0023_003DzaVdSMzhr5rnc.LinearScale = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTiHZU0aam2ka;
		_0023_003Dz65vloBQS4N5h(_0023_003DzaVdSMzhr5rnc, _0023_003Dz23fv9ZeWWTmaa0rR4SchuKQqIZgG._0023_003DzHZ9seh2ABjYt._0023_003Dz9X4o8w6GAp5N, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzKvvCDB_0024beEn6);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(_0023_003DzaVdSMzhr5rnc, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return _0023_003DzaVdSMzhr5rnc;
	}

	private Entity _0023_003DzOLOdi926iMAO4DSdUNx4mF0_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzS9geValMnJ9i73TVKsLNKRirCnz5wobeYSdRVnLUH60k _0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG;
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _, _0023_003DzfpN7pnryJplL))
		{
			throw new NotImplementedException();
		}
		_0023_003DzCPyqAJNEgRCm(_0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt, out var _0023_003DzeoY7iyo_003D, out var _0023_003DzZbOaTIM_003D, out var _0023_003Dz2AZWQ2NrfVgE, out var _0023_003Dzrp9kE6WEdfd);
		Point3D point3D = _0023_003DzeoY7iyo_003D;
		Point3D start = _0023_003Dzmq2_arBswhAA(_0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzGpn1zrZmpG_6O6Z0LQ_003D_003D);
		Point3D end = _0023_003Dzmq2_arBswhAA(_0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzBWt4HT5ki222tSXhSQ_003D_003D);
		Point3D start2 = _0023_003Dzmq2_arBswhAA(_0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzCozvN4DVH4i2SAMvGg_003D_003D);
		Point3D end2 = _0023_003Dzmq2_arBswhAA(_0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003Dz6q41d_0024j489Zlwuoelw_003D_003D);
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzZbOaTIM_003D.ToArray(), _0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt._0023_003Dz1Rls5bMv91nm31u74A_003D_003D);
		point3D.Z = _0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt._0023_003Dz1Rls5bMv91nm31u74A_003D_003D;
		_0023_003Dz2AZWQ2NrfVgE.Z = _0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt._0023_003Dz1Rls5bMv91nm31u74A_003D_003D;
		_0023_003Dzrp9kE6WEdfd.Z = _0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt._0023_003Dz1Rls5bMv91nm31u74A_003D_003D;
		point3D = point3D._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane);
		_0023_003Dz2AZWQ2NrfVgE = _0023_003Dz2AZWQ2NrfVgE._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane);
		_0023_003Dzrp9kE6WEdfd = _0023_003Dzrp9kE6WEdfd._0023_003DzyOOFX_0024nEkSZ9czU5gQ_003D_003D(plane);
		Line line = new Line(start, end);
		Line line2 = new Line(start2, end2);
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003427) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		AngularDim _0023_003DzaVdSMzhr5rnc = new AngularDim(plane, line, line2, point3D, _0023_003Dzrp9kE6WEdfd, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzXMDGX0mLcrRu);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(_0023_003DzaVdSMzhr5rnc, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3, _0023_003DzELu0Pss_003D, _0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt);
		_0023_003DzaVdSMzhr5rnc.ShowExtLine1 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzATVjIS9Putvg == '\0';
		_0023_003DzaVdSMzhr5rnc.ShowExtLine2 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTUjXw2vv7Zbg == '\0';
		_0023_003Dz6LGpzi9Ck1X_0024(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003Dzgkc7YY2tCxjIK_0024OuLg_003D_003D, ref _0023_003DzaVdSMzhr5rnc);
		_0023_003DzaVdSMzhr5rnc.Precision = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzGM62zn1x1zy4;
		_0023_003DzaVdSMzhr5rnc.LinearScale = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTiHZU0aam2ka;
		_0023_003Dz65vloBQS4N5h(_0023_003DzaVdSMzhr5rnc, _0023_003DzQAIMmTFjSKM7lEtS7ANJhwCQvqkG._0023_003DzHZ9seh2ABjYt._0023_003Dz9X4o8w6GAp5N, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzKvvCDB_0024beEn6);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(_0023_003DzaVdSMzhr5rnc, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return _0023_003DzaVdSMzhr5rnc;
	}

	private Entity _0023_003Dzxu0pTpS29tic(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		_0023_003DzT7lYtp04ntfP1kLgsrpK2_y28WTXLHwEBE9Kttw_003D _0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D;
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _, _0023_003DzfpN7pnryJplL))
		{
			throw new NotImplementedException();
		}
		_0023_003DzCPyqAJNEgRCm(_0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D._0023_003DzHZ9seh2ABjYt, out var _, out var _0023_003DzZbOaTIM_003D, out var _, out var _0023_003Dzrp9kE6WEdfd);
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D._0023_003DzDmF4ICT2K4gU);
		Point3D point3D2 = _0023_003Dzmq2_arBswhAA(_0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D._0023_003DzFi59_C5L4ZLl0LnZnQ_003D_003D);
		Point3D point3D3 = _0023_003Dzmq2_arBswhAA(_0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D._0023_003Dz8SsZ_x5ZOkk4jRw1ew_003D_003D);
		double num = point3D.DistanceTo(point3D2);
		if (num == 0.0 || Point3D.AreEqual(point3D2, point3D3, num))
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003502) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		Plane plane = _0023_003DztIc79mb2zQ0f(_0023_003DzZbOaTIM_003D.ToArray(), 0.0);
		plane.Origin = point3D;
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D._0023_003DzHZ9seh2ABjYt._0023_003DzZvhUALwgfp5aVQBFBA_003D_003D?._0023_003Dzsfb7U1TFH2wE ?? 0)?._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzLKZ880ONlfQlAIY6fQ_003D_003D;
		if (_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2 == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003427) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL));
			return null;
		}
		_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3 = _0023_003DzpQxOoUM7WgGE(_0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D._0023_003DzHZ9seh2ABjYt._0023_003DzdB76IQ9w1LWb()._0023_003DzrHY7reY_003D, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D2, _0023_003DzELu0Pss_003D);
		AngularDim _0023_003DzaVdSMzhr5rnc = new AngularDim(plane, point3D2, point3D3, _0023_003Dzrp9kE6WEdfd, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzXMDGX0mLcrRu);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(_0023_003DzaVdSMzhr5rnc, _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3, _0023_003DzELu0Pss_003D, _0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D._0023_003DzHZ9seh2ABjYt);
		_0023_003DzaVdSMzhr5rnc.ShowExtLine1 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzATVjIS9Putvg == '\0';
		_0023_003DzaVdSMzhr5rnc.ShowExtLine2 = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTUjXw2vv7Zbg == '\0';
		_0023_003Dz6LGpzi9Ck1X_0024(_0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003Dzgkc7YY2tCxjIK_0024OuLg_003D_003D, ref _0023_003DzaVdSMzhr5rnc);
		_0023_003DzaVdSMzhr5rnc.Precision = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzGM62zn1x1zy4;
		_0023_003DzaVdSMzhr5rnc.LinearScale = _0023_003Dz0k_tzkZaKTH_0024xfAUTLpAMXokAFBwVuC3cQ_003D_003D3._0023_003DzTiHZU0aam2ka;
		_0023_003DzzLIUnNo_003D(_0023_003Dz1nQImjVC26zzxqx0OzJwa4c_003D._0023_003DzHZ9seh2ABjYt._0023_003DzWCiVb25U6HBe.ToString(), out var _0023_003DzyIUKu5w_003D, out var _, out var _);
		_0023_003DzaVdSMzhr5rnc.TextOverride = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003627) + _0023_003DzyIUKu5w_003D[0];
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(_0023_003DzaVdSMzhr5rnc, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return _0023_003DzaVdSMzhr5rnc;
	}

	private colorMethodType _0023_003DzRKkHXgUCbxClA2HaCg_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL)
	{
		return _0023_003DzarHeGWMdmft8(_0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003Dz1MMYB1g_003D);
	}

	private colorMethodType _0023_003DzarHeGWMdmft8(_0023_003Dzw7QT09EaLKBdtibL6A_003D_003D _0023_003DzyjhGhCI_003D)
	{
		string text = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzKHrbYLtrxq1maBZqIg_003D_003D(_0023_003DzyjhGhCI_003D._0023_003DzJTQziP0_003D);
		if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000377) || _0023_003DzyjhGhCI_003D._0023_003DzyzK8swU_003D == 0)
		{
			return colorMethodType.byParent;
		}
		if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000359) || _0023_003DzyjhGhCI_003D._0023_003DzyzK8swU_003D == 256)
		{
			return colorMethodType.byLayer;
		}
		return colorMethodType.byEntity;
	}

	private Color _0023_003DzF0AIs_0024tEWhNkVnMfYA_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL)
	{
		return _0023_003DzHzDodfEv0nnc(_0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003Dz1MMYB1g_003D);
	}

	private Color _0023_003DzHzDodfEv0nnc(_0023_003Dzw7QT09EaLKBdtibL6A_003D_003D _0023_003DzyjhGhCI_003D)
	{
		bool flag = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzKHrbYLtrxq1maBZqIg_003D_003D(_0023_003DzyjhGhCI_003D._0023_003DzJTQziP0_003D) == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003606);
		bool num = _0023_003DzyjhGhCI_003D._0023_003DzyzK8swU_003D > 0 && _0023_003DzyjhGhCI_003D._0023_003DzyzK8swU_003D < 256;
		bool flag2 = (_0023_003DzyjhGhCI_003D._0023_003Dzjcx0hV4_003D & 0x80) != 0;
		bool flag3 = (_0023_003DzyjhGhCI_003D._0023_003Dzjcx0hV4_003D & 0x20) != 0;
		int alpha = ((_0023_003DzyjhGhCI_003D._0023_003DzpvRMZ2Bo3TEl == '\u0003' && flag3) ? _0023_003DzyjhGhCI_003D._0023_003DzbvIFYko_003D : 'ÿ');
		if (num || flag)
		{
			int num2 = (int)(_0023_003DzyjhGhCI_003D._0023_003DzFd5hios_003D & 0xFFFFFF);
			int num3 = ((!flag2 && num2 > 0 && num2 < 256) ? num2 : _0023_003DzyjhGhCI_003D._0023_003DzyzK8swU_003D);
			if (num3 == 7)
			{
				return Color.FromArgb(alpha, ForegroundColor);
			}
			_0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D _0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzAN9e1_0024CqSaV8Z5bYhw_003D_003D[num3];
			return Color.FromArgb(alpha, _0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2._0023_003DzRpXgovo_003D, _0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2._0023_003Dz5rQzobg_003D, _0023_003DzFzKcweJdGQqgbxzZ1XnxIUk_003D2._0023_003Dz1v6oPQk_003D);
		}
		uint num4 = _0023_003DzyjhGhCI_003D._0023_003DzFd5hios_003D & 0xFFFFFF;
		byte red = (byte)((num4 & 0xFF0000) >> 16);
		byte green = (byte)((num4 & 0xFF00) >> 8);
		byte blue = (byte)num4;
		return Color.FromArgb(alpha, red, green, blue);
	}

	internal void _0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(IEntity _0023_003DzTb8sVfuysOroSa7Xag_003D_003D, _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.AutodeskProperties == null)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.AutodeskProperties = new AutodeskProperties();
		}
		_0023_003DzEg6_Cd8VKxjdkr0v1E_0024vWxQ_003D _0023_003Dz9j7EUB0_003D = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D;
		if (_0023_003Dz9j7EUB0_003D == null)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001030), _0023_003DzfpN7pnryJplL.GetType(), _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL)));
			return;
		}
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Visible = _0023_003Dz9j7EUB0_003D._0023_003DzIVihMJc_003D == 0;
		if (_0023_003Dz9j7EUB0_003D._0023_003DztIaJjPw_003D != null)
		{
			_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz9j7EUB0_003D._0023_003DztIaJjPw_003D._0023_003Dzsfb7U1TFH2wE);
			if (_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2 != null)
			{
				_0023_003DzKe2lNEm_MgUwP4PyvHMVEU9SmYpt _0023_003DzHdSqIFkmZYg = _0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D2._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzHdSqIFkmZYg2;
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = _0023_003DzHdSqIFkmZYg._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D;
				if (!base.Layers.Contains(_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName))
				{
					_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = base.Layers[0].Name;
				}
			}
			else
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974825) + _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003590));
			}
		}
		if (_0023_003Dz9j7EUB0_003D._0023_003DzeThyx1uJ0LOH == -1)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byParent;
		}
		else if (_0023_003Dz9j7EUB0_003D._0023_003DzeThyx1uJ0LOH == -2)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byEntity;
			Enum.TryParse<_0023_003DzjNr_0024_0024QU_003D>(_0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzpEyxzFEjatGqKIEdmNFbxQA_003D(_0023_003Dz9j7EUB0_003D._0023_003DzeThyx1uJ0LOH % 32).ToString(), out var result);
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeight = _0023_003DznZ_0024c4UJBVHLK3svo29coD_0024wi12Ua(result);
		}
		colorMethodType colorMethod = _0023_003DzRKkHXgUCbxClA2HaCg_003D_003D(_0023_003DzfpN7pnryJplL);
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethod;
		if (_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod == colorMethodType.byEntity)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Color = _0023_003DzF0AIs_0024tEWhNkVnMfYA_003D_003D(_0023_003DzfpN7pnryJplL);
		}
		if (_0023_003Dz9j7EUB0_003D._0023_003Dztf4fenR5GudUdJHj2A_003D_003D == '\0')
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byLayer;
		}
		else if (_0023_003Dz9j7EUB0_003D._0023_003Dztf4fenR5GudUdJHj2A_003D_003D == '\u0001')
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byParent;
		}
		else if (_0023_003Dz9j7EUB0_003D._0023_003Dztf4fenR5GudUdJHj2A_003D_003D == '\u0002')
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byEntity;
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeName = null;
		}
		else if (_0023_003Dz9j7EUB0_003D._0023_003Dz2ro_VwTtYYm9 != null)
		{
			_0023_003DzTR5z6N_0024xLvYrGBfXqZSIK5hkX_00241Q _0023_003DzvVLGvrAoh3WE = _0023_003DzusI0CdDJe3sdibbI3w_003D_003D._0023_003DzPh3rI9ECDu443e_0024Rhw_003D_003D(_0023_003DzELu0Pss_003D._0023_003Dz8N608Vg_003D, _0023_003Dz9j7EUB0_003D._0023_003Dz2ro_VwTtYYm9._0023_003Dzsfb7U1TFH2wE)._0023_003DzRLZJ5Uk_003D._0023_003DzHYF9BSI_003D._0023_003DzRLZJ5Uk_003D._0023_003DzvVLGvrAoh3WE;
			if (_0023_003DzELu0Pss_003D._0023_003Dzt1RSIVUh_0024mJh5IXfuw_003D_003D.Contains(_0023_003DzvVLGvrAoh3WE._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D))
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byEntity;
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeName = _0023_003DzvVLGvrAoh3WE._0023_003DztbByVAY_003D._0023_003DzS_00246o7tc_003D;
			}
		}
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeScale = (float)_0023_003Dz9j7EUB0_003D._0023_003Dzun_0024Fc0orzst2E__XCQ_003D_003D;
		_ = _0023_003Dz9j7EUB0_003D._0023_003DzxGqDVdDdyawl;
	}

	internal void _0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(IEntity _0023_003DzTb8sVfuysOroSa7Xag_003D_003D, _0023_003Dz9Cw5d0_0024xEL31U87kjI_0024bcjs_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private bool _0023_003Dz_s59BFycTcLUOE0fVw_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Point3D[] _0023_003DzqiqldgRGLZLgH668WopyQAY_003D)
	{
		_0023_003DzqiqldgRGLZLgH668WopyQAY_003D = null;
		List<Point3D> list = new List<Point3D>(2) { _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] };
		for (int i = 1; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
		{
			int num = 0;
			for (int j = 0; j < list.Count; j++)
			{
				if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] == list[j])
				{
					num++;
				}
			}
			if (num == 0)
			{
				list.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]);
			}
		}
		if (list.Count == _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length)
		{
			return false;
		}
		_0023_003DzqiqldgRGLZLgH668WopyQAY_003D = list.ToArray();
		return true;
	}

	private Entity _0023_003Dz1vzybyo_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D, StringBuilder _0023_003DzFdTKfve582KK)
	{
		_0023_003DzXn5mohel_ZFuDV2t6TMkzmAO_1sv _0023_003Dzn_BpkG_YhU_0024J = _0023_003DzfpN7pnryJplL._0023_003DzRLZJ5Uk_003D._0023_003Dz9j7EUB0_003D._0023_003DzRLZJ5Uk_003D._0023_003Dzn_BpkG_YhU_0024J;
		Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point3D[4]
		{
			_0023_003Dzmq2_arBswhAA(_0023_003Dzn_BpkG_YhU_0024J._0023_003DzzxCX0YE_003D),
			_0023_003Dzmq2_arBswhAA(_0023_003Dzn_BpkG_YhU_0024J._0023_003DzfILMMw4_003D),
			_0023_003Dzmq2_arBswhAA(_0023_003Dzn_BpkG_YhU_0024J._0023_003DzVX1L6fc_003D),
			_0023_003Dzmq2_arBswhAA(_0023_003Dzn_BpkG_YhU_0024J._0023_003DzG_HFZvc_003D)
		};
		Vector3D _0023_003DzZbOaTIM_003D = _0023_003DzlvGiL_QdgBbL(_0023_003Dzn_BpkG_YhU_0024J._0023_003DzvEjqUlZSmP3rL_WVIg_003D_003D);
		Entity entity = AutodeskUtility.ReadSolid(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzZbOaTIM_003D, _0023_003Dzn_BpkG_YhU_0024J._0023_003Dzetc0sjwdrddceszzig_003D_003D, _0023_003DzYylTTgozgnF29k_90g_003D_003D(_0023_003DzfpN7pnryJplL), log);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return entity;
	}

	internal static void _0023_003Dz65vloBQS4N5h(Dimension _0023_003Dzr_3OnS8_003D, string _0023_003DzX7KQQ_0024S_AUky, string _0023_003Dz1GybGwPiSoBt)
	{
		string _0023_003DzQdxCPUCTIzyF;
		if (!string.IsNullOrEmpty(_0023_003Dz1GybGwPiSoBt))
		{
			_0023_003DzzLIUnNo_003D(_0023_003Dz1GybGwPiSoBt, out var _0023_003DzyIUKu5w_003D, out var _, out _0023_003DzQdxCPUCTIzyF);
			if (_0023_003DzyIUKu5w_003D != null && _0023_003DzyIUKu5w_003D.Count > 0)
			{
				_0023_003Dz1GybGwPiSoBt = _0023_003DzyIUKu5w_003D[0];
			}
			if (_0023_003Dz1GybGwPiSoBt.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966001)))
			{
				string[] array = _0023_003Dz1GybGwPiSoBt.Split(new string[1] { _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966001) }, 2, StringSplitOptions.None);
				_0023_003Dzr_3OnS8_003D.TextPrefix = _0023_003Dz3lOHLrA_003D(array[0]);
				_0023_003Dzr_3OnS8_003D.TextSuffix = _0023_003Dz3lOHLrA_003D(array[1]);
			}
			else
			{
				_0023_003Dzr_3OnS8_003D.TextSuffix = _0023_003Dz3lOHLrA_003D(_0023_003Dz1GybGwPiSoBt);
			}
		}
		if (_0023_003DzX7KQQ_0024S_AUky != null && _0023_003DzX7KQQ_0024S_AUky.Length > 0)
		{
			_0023_003DzzLIUnNo_003D(_0023_003DzX7KQQ_0024S_AUky, out var _0023_003DzyIUKu5w_003D2, out var _0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D2, out _0023_003DzQdxCPUCTIzyF);
			if (_0023_003DzyIUKu5w_003D2 != null && _0023_003DzyIUKu5w_003D2.Count > 0)
			{
				_0023_003DzX7KQQ_0024S_AUky = _0023_003DzyIUKu5w_003D2[0];
			}
			if (_0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D2 != null && _0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D2.Length != 0)
			{
				_0023_003Dzr_3OnS8_003D.WidthFactor = _0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D2[0];
			}
			_0023_003Dzr_3OnS8_003D.TextOverride = _0023_003Dz3lOHLrA_003D(_0023_003DzX7KQQ_0024S_AUky);
		}
	}

	internal static string _0023_003Dz3lOHLrA_003D(string _0023_003DzwyYng5o_003D)
	{
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003545)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003545), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954660));
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003523)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003523), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954660));
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003533)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003533), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966742));
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003255)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003255), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966742));
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003233)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003233), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965359));
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003243)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003243), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965359));
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003221)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003221), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953488));
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003231)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003231), string.Empty);
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003209)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003209), string.Empty);
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003187)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003187), string.Empty);
		}
		if (_0023_003DzwyYng5o_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003197)))
		{
			_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003197), string.Empty);
		}
		int num = _0023_003DzwyYng5o_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003175));
		if (num != -1 && _0023_003DzwyYng5o_003D.Length > num + 4)
		{
			string text = _0023_003DzwyYng5o_003D.Substring(num + 2, 3);
			if (int.TryParse(text, out var result))
			{
				switch (result)
				{
				case 131:
					_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003175) + text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003154));
					break;
				case 223:
					_0023_003DzwyYng5o_003D = _0023_003DzwyYng5o_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003175) + text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003162));
					break;
				}
			}
		}
		return _0023_003DzwyYng5o_003D;
	}

	internal static void _0023_003DzzLIUnNo_003D(string _0023_003DzlUfsUzo_003D, out List<string> _0023_003DzyIUKu5w_003D, out double[] _0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D, out string _0023_003DzQdxCPUCTIzyF)
	{
		_0023_003DzyIUKu5w_003D = new List<string>();
		bool flag = false;
		string text = string.Empty;
		List<double> list = new List<double>();
		_0023_003DzQdxCPUCTIzyF = string.Empty;
		bool flag2 = true;
		int num = 1;
		for (int i = 0; i < _0023_003DzlUfsUzo_003D.Length; i++)
		{
			char c = _0023_003DzlUfsUzo_003D[i];
			if ((uint)c <= 92u)
			{
				switch (c)
				{
				case '\\':
					if (i >= _0023_003DzlUfsUzo_003D.Length - 1)
					{
						break;
					}
					switch (_0023_003DzlUfsUzo_003D[i + 1])
					{
					case 'F':
					case 'f':
					{
						flag = true;
						int num3 = i + 2;
						int num4 = _0023_003DzlUfsUzo_003D.IndexOf(';', num3);
						if (num4 >= 0)
						{
							string text2 = _0023_003DzlUfsUzo_003D.Substring(num3, num4 - num3);
							if (text2.EndsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003137)))
							{
								_0023_003DzQdxCPUCTIzyF = text2;
								i = num4 - 1;
							}
						}
						break;
					}
					case 'H':
						flag = true;
						break;
					case 'W':
					{
						flag = true;
						int num5 = i + 2;
						if (num5 < _0023_003DzlUfsUzo_003D.Length)
						{
							string text3 = _0023_003DzlUfsUzo_003D.Substring(num5, _0023_003DzlUfsUzo_003D.IndexOf(';', num5) - num5);
							if (!flag2)
							{
								num--;
								_0023_003DzHnkwK531ghU8gcXpgA_003D_003D(list, num);
							}
							num = 0;
							flag2 = false;
							if (text3[text3.Length - 1] == 'x')
							{
								text3 = text3.Substring(0, text3.Length - 1);
							}
							double num6 = Utility.DoubleParse(text3);
							list.Add((num6 > 10.0) ? 10.0 : num6);
						}
						break;
					}
					case 'T':
						flag = true;
						break;
					case 'C':
					case 'c':
						flag = true;
						break;
					case 'S':
						flag = true;
						break;
					case 'Q':
						flag = true;
						break;
					case 'A':
						flag = true;
						break;
					case 'L':
					case 'l':
						i++;
						continue;
					case 'O':
					case 'o':
						i++;
						continue;
					case 'P':
						flag2 = false;
						num++;
						break;
					case 'p':
						if (i == 0 || _0023_003DzlUfsUzo_003D[i - 1] != '\\')
						{
							int num2 = _0023_003DzlUfsUzo_003D.IndexOf(';', i) - (i + 1);
							i += num2;
							flag = true;
						}
						continue;
					case '~':
						text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003150);
						i++;
						continue;
					}
					break;
				case ';':
					if (flag)
					{
						flag = false;
						continue;
					}
					break;
				}
			}
			else if (c == '{' || c == '}')
			{
				continue;
			}
			if (!flag)
			{
				text += _0023_003DzlUfsUzo_003D[i];
			}
		}
		_0023_003DzHnkwK531ghU8gcXpgA_003D_003D(list, num);
		_0023_003DzyIUKu5w_003D.Add(text);
		if (list.Count > 0)
		{
			_0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D = list.ToArray();
		}
		else
		{
			_0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D = null;
		}
	}

	private static bool _0023_003DzNvwnALs_003D(int _0023_003DzAddCv_o_003D, string _0023_003DzwyYng5o_003D, string _0023_003Dz1kXcGZQ_003D)
	{
		if (_0023_003DzwyYng5o_003D.Length - _0023_003DzAddCv_o_003D <= _0023_003Dz1kXcGZQ_003D.Length)
		{
			return false;
		}
		for (int i = 0; i < _0023_003Dz1kXcGZQ_003D.Length; i++)
		{
			if (_0023_003DzwyYng5o_003D[_0023_003DzAddCv_o_003D + i] != _0023_003Dz1kXcGZQ_003D[i])
			{
				return false;
			}
		}
		return true;
	}

	private static void _0023_003DzHnkwK531ghU8gcXpgA_003D_003D(List<double> _0023_003DzT5HEoT0HHzki, int _0023_003Dzqz2gcwn_0024Jx8mOmlDfA_003D_003D)
	{
		if (_0023_003Dzqz2gcwn_0024Jx8mOmlDfA_003D_003D > 0)
		{
			double item = -1.0;
			if (_0023_003DzT5HEoT0HHzki.Count > 0)
			{
				item = _0023_003DzT5HEoT0HHzki.Last();
			}
			for (int i = 0; i < _0023_003Dzqz2gcwn_0024Jx8mOmlDfA_003D_003D; i++)
			{
				_0023_003DzT5HEoT0HHzki.Add(item);
			}
		}
	}

	internal static void _0023_003DzLqECXomsH96v5omFVw_003D_003D(Plane _0023_003Dzpyw2kZk_003D, Point3D _0023_003DzO97ip_0024TQ_0024juS, Point3D _0023_003DzM7o0gT3hjI42, Point3D _0023_003Dz2AZWQ2NrfVgE)
	{
		double num = Vector3D.Subtract(_0023_003DzM7o0gT3hjI42, _0023_003DzO97ip_0024TQ_0024juS).AngleInXY;
		if (num < 0.0)
		{
			num += Math.Ceiling((0.0 - num) / (Math.PI * 2.0)) * (Math.PI * 2.0);
		}
		if (num > Math.PI * 2.0)
		{
			num -= Math.Floor(num / (Math.PI * 2.0)) * (Math.PI * 2.0);
		}
		if (num > Math.PI * 3.0 / 4.0 && num < 5.497787143782138)
		{
			_0023_003Dzpyw2kZk_003D.Rotate(num + Math.PI, _0023_003Dzpyw2kZk_003D.AxisZ, _0023_003Dzpyw2kZk_003D.Origin);
		}
		else if (num != 0.0)
		{
			_0023_003Dzpyw2kZk_003D.Rotate(num, _0023_003Dzpyw2kZk_003D.AxisZ, _0023_003Dzpyw2kZk_003D.Origin);
		}
	}

	internal static Plane _0023_003DztIc79mb2zQ0f(double[] _0023_003DzZbOaTIM_003D, double _0023_003Dz1Rls5bMv91nm31u74A_003D_003D)
	{
		if (_0023_003DzZbOaTIM_003D.All(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz0v6Rjh1WRtALzZ5DlsKygzbmNY6H))
		{
			return Plane.XY;
		}
		Transformation.AutocadOCS(new Vector3D(_0023_003DzZbOaTIM_003D), out var xAxis, out var yAxis);
		Plane plane = new Plane(Point3D.Origin, xAxis, yAxis);
		plane.Translate(_0023_003Dz1Rls5bMv91nm31u74A_003D_003D * plane.AxisZ);
		return plane;
	}

	private Entity _0023_003DzTzB3m0HOA3XiW_00242goQ_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private static object _0023_003DzzpPf_t9QK6Tq(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, out bool _0023_003DzyXY3EnL_LgAE, out Transformation _0023_003Dz63vmKM0_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzHCbFScK4iejT(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private static ICurve _0023_003DzzVSgBJDZ84_5(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dzbi3UlCmUa8jH, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		throw new NotImplementedException();
	}

	private Entity _0023_003DzzAKlySEeZ2dLOr0jug_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzfpN7pnryJplL, _0023_003Dzbd_Hsyijovok _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private Brep _0023_003DzTKtnT5N7AEqw(object _0023_003Dz_0024deRlKY_003D)
	{
		throw new NotImplementedException();
	}

	private void _0023_003DzXrer4voypQXrsqxXrgGlHFc_003D(Brep _0023_003DzGb8kdyZ1x5nj)
	{
		Brep.Edge[] edges = _0023_003DzGb8kdyZ1x5nj.Edges;
		Point3D[] vertices = _0023_003DzGb8kdyZ1x5nj.Vertices;
		bool flag = false;
		bool[] array = new bool[edges.Length];
		bool[] array2 = new bool[vertices.Length];
		for (int i = 0; i < edges.Length; i++)
		{
			Brep.Edge edge = edges[i];
			if (edge.Parents != null && edge.Parents.Length == 2 && edge.Parents[0] == edge.Parents[1] && !_0023_003DzAlQLBGPZsHb3(_0023_003DzGb8kdyZ1x5nj.Faces[edge.Parents[0]], i) && edge.StartPointIndex != edge.EndPointIndex && ((Brep.Vertex)vertices[edge.StartPointIndex]).Parents.Length < 2 && ((Brep.Vertex)vertices[edge.EndPointIndex]).Parents.Length < 2)
			{
				_0023_003DzbCCBtYpMOnFBQ_0024mVLg_003D_003D(_0023_003DzGb8kdyZ1x5nj.Faces[edge.Parents[0]], i);
				array[i] = true;
				array2[edge.StartPointIndex] = true;
				array2[edge.EndPointIndex] = true;
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		int[] array3 = new int[vertices.Length];
		int[] array4 = new int[edges.Length];
		List<Brep.Edge> list = new List<Brep.Edge>(edges.Length);
		List<Point3D> list2 = new List<Point3D>(vertices.Length);
		int j = 0;
		int num = 0;
		for (; j < vertices.Length; j++)
		{
			if (!array2[j])
			{
				list2.Add(vertices[j]);
				array3[j] = num;
				num++;
			}
			else
			{
				array3[j] = -1;
			}
		}
		int k = 0;
		int num2 = 0;
		for (; k < edges.Length; k++)
		{
			if (!array[k])
			{
				Brep.Edge edge2 = edges[k];
				edge2.StartPointIndex = array3[edge2.StartPointIndex];
				edge2.EndPointIndex = array3[edge2.EndPointIndex];
				list.Add(edge2);
				array4[k] = num2;
				num2++;
			}
			else
			{
				array4[k] = -1;
			}
		}
		_0023_003Dzh2uqhe7njeTo(_0023_003DzGb8kdyZ1x5nj.Faces, array4);
		Brep.Face[][] inners = _0023_003DzGb8kdyZ1x5nj.Inners;
		for (int l = 0; l < inners.Length; l++)
		{
			_0023_003Dzh2uqhe7njeTo(inners[l], array4);
		}
		_0023_003DzGb8kdyZ1x5nj.Edges = list.ToArray();
		_0023_003DzGb8kdyZ1x5nj.Vertices = list2.ToArray();
	}

	private bool _0023_003DzAlQLBGPZsHb3(Brep.Face _0023_003DzHEpjcdg2hk9U, int _0023_003DzR9iNTRzD_0024_QJ)
	{
		Brep.Loop[] loops = _0023_003DzHEpjcdg2hk9U.Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			Brep.OrientedEdge[] segments = loops[i].Segments;
			if (segments[0].CurveIndex == _0023_003DzR9iNTRzD_0024_QJ && segments[^1].CurveIndex == _0023_003DzR9iNTRzD_0024_QJ)
			{
				return true;
			}
			for (int j = 0; j < segments.Length - 1; j++)
			{
				if (segments[j].CurveIndex == _0023_003DzR9iNTRzD_0024_QJ && segments[j + 1].CurveIndex == _0023_003DzR9iNTRzD_0024_QJ)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void _0023_003DzbCCBtYpMOnFBQ_0024mVLg_003D_003D(Brep.Face _0023_003DzHEpjcdg2hk9U, int _0023_003DzR9iNTRzD_0024_QJ)
	{
		_0023_003Dzpy08Ab9uEMb_0024J202y_PjouM_003D _0023_003Dzpy08Ab9uEMb_0024J202y_PjouM_003D2 = new _0023_003Dzpy08Ab9uEMb_0024J202y_PjouM_003D();
		_0023_003Dzpy08Ab9uEMb_0024J202y_PjouM_003D2._0023_003DzR9iNTRzD_0024_QJ = _0023_003DzR9iNTRzD_0024_QJ;
		Brep.Loop[] array = new Brep.Loop[_0023_003DzHEpjcdg2hk9U.Loops.Length + 1];
		int num = 0;
		for (int i = 0; i < _0023_003DzHEpjcdg2hk9U.Loops.Length; i++)
		{
			Brep.Loop loop = _0023_003DzHEpjcdg2hk9U.Loops[i];
			if (loop.Segments.All(_0023_003Dzpy08Ab9uEMb_0024J202y_PjouM_003D2._0023_003DzYUt6iN9_eCIy5NHrTgzYVv4_003D))
			{
				array[num++] = loop;
				continue;
			}
			List<Brep.OrientedEdge> list = new List<Brep.OrientedEdge>();
			List<Brep.OrientedEdge> list2 = new List<Brep.OrientedEdge>();
			Brep.OrientedEdge[] segments = loop.Segments;
			bool flag = true;
			for (int j = 0; j < segments.Length; j++)
			{
				if (segments[j].CurveIndex == _0023_003Dzpy08Ab9uEMb_0024J202y_PjouM_003D2._0023_003DzR9iNTRzD_0024_QJ)
				{
					flag = !flag;
				}
				else if (flag)
				{
					list.Add(segments[j]);
				}
				else
				{
					list2.Add(segments[j]);
				}
			}
			array[num++] = new Brep.Loop(list.ToArray(), loop.Sense);
			array[num++] = new Brep.Loop(list2.ToArray(), loop.Sense);
		}
		_0023_003DzHEpjcdg2hk9U.Loops = array;
	}

	private static void _0023_003Dzh2uqhe7njeTo(IList<Brep.Face> _0023_003DzEtn4dIEPKCsi, int[] _0023_003DzCS02Bu0_003D)
	{
		foreach (Brep.Face item in _0023_003DzEtn4dIEPKCsi)
		{
			Brep.Loop[] loops = item.Loops;
			foreach (Brep.Loop loop in loops)
			{
				for (int j = 0; j < loop.Segments.Length; j++)
				{
					loop.Segments[j].CurveIndex = _0023_003DzCS02Bu0_003D[loop.Segments[j].CurveIndex];
				}
			}
		}
	}

	private AnalyticSurf _0023_003DzEWDnsqb1JazfGvDd7JAhZJs_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzVg2JOkrvi_0024WWTvaq_0024g_003D_003D, int _0023_003DzyzK8swU_003D, out bool _0023_003DzRJCkAs7KXaib)
	{
		throw new NotImplementedException();
	}

	private Surface[] _0023_003DzFkEN6dUHgk58jWgxqg_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dzkc_CPgXyxLUH, List<ICurve> _0023_003Dzf5ywTHlO2gM5)
	{
		throw new NotImplementedException();
	}

	private NurbsSurf _0023_003DzFkEN6dUHgk58jWgxqg_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dzkc_CPgXyxLUH)
	{
		throw new NotImplementedException();
	}

	private Surface[] _0023_003DzGEANTo2LpsV8(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003DzHEpjcdg2hk9U, List<ICurve> _0023_003Dzf5ywTHlO2gM5)
	{
		throw new NotImplementedException();
	}

	private ToroidalSurface[] _0023_003Dz_YKYrhvOk07iAHIIBg_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dz_0024KKopL9T7nzT, List<ICurve> _0023_003Dzf5ywTHlO2gM5, bool _0023_003Dzwc7poJCrlnrg)
	{
		throw new NotImplementedException();
	}

	private ConicalSurface[] _0023_003DzaE9qw8f6WlDc(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dz_0024KKopL9T7nzT, List<ICurve> _0023_003Dzf5ywTHlO2gM5, bool _0023_003Dzwc7poJCrlnrg)
	{
		throw new NotImplementedException();
	}

	private SphericalSurface[] _0023_003DzbEQwqJoZ1kxijZ9iiQ_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dz_0024KKopL9T7nzT, List<ICurve> _0023_003Dzf5ywTHlO2gM5, bool _0023_003Dzwc7poJCrlnrg)
	{
		throw new NotImplementedException();
	}

	private PlanarSurface[] _0023_003DzyvLjslOteUX7sdfyLw_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dz_0024KKopL9T7nzT, List<ICurve> _0023_003Dzf5ywTHlO2gM5, bool _0023_003Dzwc7poJCrlnrg)
	{
		throw new NotImplementedException();
	}

	private CylindricalSurface[] _0023_003DzB3cT__0024WWlY2bgM5cFA_003D_003D(_0023_003DzV_0024blJvMHZq7xhSx5tQ_003D_003D _0023_003Dz_0024KKopL9T7nzT, List<ICurve> _0023_003Dzf5ywTHlO2gM5, bool _0023_003Dzwc7poJCrlnrg)
	{
		throw new NotImplementedException();
	}

	[DebuggerStepThrough]
	private static bool _0023_003DzsaDs2uY_003D(object _0023_003DzHEpjcdg2hk9U, IList<ICurve> _0023_003Dzf5ywTHlO2gM5, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D, string _0023_003Dzy0p1LSY_003D)
	{
		throw new NotImplementedException();
	}

	public BlockReference CreateXRef(string blockName, Point3D basePoint, Document workspace, string exportFileName = null)
	{
		if (workspace.Blocks.Contains(blockName))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003382));
		}
		Block block = new Block(blockName);
		string text = blockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
		Dictionary<string, string> _0023_003Dz2pZ9OScWhJ8f = new Dictionary<string, string>();
		for (int i = 0; i < base.Layers.Count; i++)
		{
			Layer layer = base.Layers[i];
			if (layer.Name != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746))
			{
				string text2 = text + layer.Name;
				_0023_003Dz2pZ9OScWhJ8f.Add(layer.Name, text2);
				layer.Name = text2;
			}
		}
		_0023_003DzsFcdFdtxtw0i(_0023_003Dz2pZ9OScWhJ8f);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Block block2 in base.Blocks)
		{
			string value = text + block2.Name;
			dictionary.Add(block2.Name, value);
		}
		string rootBlockName = base.Blocks.RootBlockName;
		BlockKeyedCollection blocks = base.Blocks;
		EntityList.ReplaceBlockNames<Block>(dictionary, base.Entities, ref blocks);
		base.Blocks = blocks;
		rootBlockName = dictionary[rootBlockName];
		base.Blocks.SetRootBlock(rootBlockName);
		foreach (Block block3 in base.Blocks)
		{
			if (block3 == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003335));
			}
		}
		base.TextStyles = _0023_003DzD8Tb1f9EPSct<TextStyleKeyedCollection, TextStyle>(base.TextStyles, blockName, text, out _0023_003Dz2pZ9OScWhJ8f);
		_0023_003DzuHulo_0024fPObkV(_0023_003Dz2pZ9OScWhJ8f);
		base.LineTypes = _0023_003DzD8Tb1f9EPSct<LineTypeKeyedCollection, LineType>(base.LineTypes, blockName, text, out _0023_003Dz2pZ9OScWhJ8f);
		_0023_003DzOZ4tzTpeNGf9(_0023_003Dz2pZ9OScWhJ8f);
		foreach (Layer layer2 in base.Layers)
		{
			if (!string.IsNullOrEmpty(layer2.LineTypeName))
			{
				layer2.LineTypeName = _0023_003Dz2pZ9OScWhJ8f[layer2.LineTypeName];
			}
		}
		ImportSettings(workspace);
		FillAllCollectionsData(workspace);
		block.Entities.AddRange(base.Entities);
		block.BasePoint = BasePoint;
		workspace.Blocks.Add(block);
		base.Layers.Clear(addDefaultLayer: false);
		base.TextStyles.Clear(addDefaultTextStyle: false);
		base.Blocks.Clear();
		return new BlockReference(new Translation(0.0 - basePoint.X, 0.0 - basePoint.Y, 0.0 - basePoint.Z), blockName);
	}

	private void _0023_003DzuHulo_0024fPObkV(Dictionary<string, string> _0023_003DzD1qZfQPfVu5L)
	{
		foreach (Block block in base.Blocks)
		{
			_0023_003DzuHulo_0024fPObkV(_0023_003DzD1qZfQPfVu5L, block.Entities);
		}
	}

	private void _0023_003DzOZ4tzTpeNGf9(Dictionary<string, string> _0023_003DzD1qZfQPfVu5L)
	{
		foreach (Block block in base.Blocks)
		{
			_0023_003DzOZ4tzTpeNGf9(_0023_003DzD1qZfQPfVu5L, block.Entities);
		}
	}

	private void _0023_003DzsFcdFdtxtw0i(Dictionary<string, string> _0023_003DzD1qZfQPfVu5L)
	{
		foreach (Block block in base.Blocks)
		{
			_0023_003DzsFcdFdtxtw0i(_0023_003DzD1qZfQPfVu5L, block.Entities);
		}
	}

	private T _0023_003DzD8Tb1f9EPSct<T, Q>(T _0023_003DzELu0Pss_003D, string _0023_003DznkMU43c_003D, string _0023_003Dz73bcubQ_003D, out Dictionary<string, string> _0023_003Dz2pZ9OScWhJ8f) where T : EyeshotKeyedCollection<Q>, new() where Q : IKeyedCollectionItem<Q>
	{
		T val = new T();
		_0023_003Dz2pZ9OScWhJ8f = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		foreach (Q item in _0023_003DzELu0Pss_003D)
		{
			string text = _0023_003Dz73bcubQ_003D + item.GetKey();
			_0023_003Dz2pZ9OScWhJ8f.Add(item.GetKey(), text);
			item.SetKey(text);
			val.Add(item);
			if (!(item is IReadWriteDataEx))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004014));
			}
			IReadWriteDataEx readWriteDataEx = (IReadWriteDataEx)(object)item;
			if (string.IsNullOrEmpty(((IDataEx)readWriteDataEx).XRefName))
			{
				((IWriteDataEx)readWriteDataEx).XRefName = _0023_003DznkMU43c_003D;
			}
			else
			{
				((IWriteDataEx)readWriteDataEx).XRefName = _0023_003Dz73bcubQ_003D + ((IDataEx)readWriteDataEx).XRefName;
			}
		}
		return val;
	}

	internal static void _0023_003DzuHulo_0024fPObkV(Dictionary<string, string> _0023_003DzD1qZfQPfVu5L, IList<Entity> _0023_003Dzv7xH9gk_003D)
	{
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is Text text)
			{
				if (!string.IsNullOrEmpty(text.StyleName) && _0023_003DzD1qZfQPfVu5L.ContainsKey(text.StyleName))
				{
					text.StyleName = _0023_003DzD1qZfQPfVu5L[text.StyleName];
				}
			}
			else if (item is BlockReference blockReference)
			{
				foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
				{
					string styleName = attribute.Value.StyleName;
					if (!string.IsNullOrEmpty(styleName) && _0023_003DzD1qZfQPfVu5L.ContainsKey(styleName))
					{
						attribute.Value.StyleName = _0023_003DzD1qZfQPfVu5L[styleName];
					}
				}
			}
			else
			{
				if (!(item is Table table))
				{
					continue;
				}
				double num = table.RowsNum;
				double num2 = table.ColumnsNum;
				for (int i = 0; (double)i < num; i++)
				{
					for (int j = 0; (double)j < num2; j++)
					{
						string styleName2 = table.GetStyleName(i, j);
						if (!string.IsNullOrEmpty(styleName2) && _0023_003DzD1qZfQPfVu5L.ContainsKey(styleName2))
						{
							table.SetStyleName(i, j, _0023_003DzD1qZfQPfVu5L[styleName2]);
						}
					}
				}
			}
		}
	}

	internal static void _0023_003DzOZ4tzTpeNGf9(Dictionary<string, string> _0023_003DzD1qZfQPfVu5L, IList<Entity> _0023_003Dzv7xH9gk_003D)
	{
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (!string.IsNullOrEmpty(item.LineTypeName))
			{
				item.LineTypeName = _0023_003DzD1qZfQPfVu5L[item.LineTypeName];
			}
		}
	}

	internal static void _0023_003DzsFcdFdtxtw0i(Dictionary<string, string> _0023_003DzD1qZfQPfVu5L, IList<Entity> _0023_003Dzv7xH9gk_003D)
	{
		if (_0023_003Dzv7xH9gk_003D == null)
		{
			return;
		}
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (_0023_003DzD1qZfQPfVu5L.ContainsKey(item.LayerName))
			{
				item.LayerName = _0023_003DzD1qZfQPfVu5L[item.LayerName];
			}
			if (!(item is BlockReference blockReference))
			{
				continue;
			}
			foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
			{
				if (_0023_003DzD1qZfQPfVu5L.ContainsKey(attribute.Value.LayerName))
				{
					attribute.Value.LayerName = _0023_003DzD1qZfQPfVu5L[attribute.Value.LayerName];
				}
			}
		}
	}

	public bool SetView(IViewport viewport)
	{
		return _0023_003Dz3YTzYwTLBU_0024R._0023_003Dzvk_j02M_003D(viewport.Camera, viewport.Size);
	}

	public Image GetThumbnail()
	{
		throw new NotImplementedException();
	}
}
