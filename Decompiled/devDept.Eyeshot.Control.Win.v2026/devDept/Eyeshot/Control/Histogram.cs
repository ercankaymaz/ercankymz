using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(HistogramConverter))]
public class Histogram : BarBase, ICloneable
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<Tuple<double, double, int>, int> _0023_003Dz_68Kr7hT8MvIl7ap8w_003D_003D;

		public static Func<ToolBar, bool> _0023_003Dz1oOcm5IUi1HJLfCX_g_003D_003D;

		internal int _0023_003DzkAIsym6d_0024Wdvz_0024IAIX5FMIw_003D(Tuple<double, double, int> _0023_003DzQIrNPUk_003D)
		{
			return _0023_003DzQIrNPUk_003D.Item3;
		}

		internal bool _0023_003Dzfx8cmLkC8R6mnXB7sWMUHiU_003D(ToolBar _0023_003Dz7mKSiLg_003D)
		{
			return _0023_003Dz7mKSiLg_003D.Visible;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HistogramData _0023_003DzvLO6oc_0024kuBQ_0024 = DefaultHistogram;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzoJKgKMoEivAc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzIL1y9fIhQuNt = _0023_003DzmQl1CA0wezPR();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzyv6RsY1iJUic = _0023_003DzD7yn9PWJm8jt();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz9X_00246qCY_003D = _0023_003DzTggvRpdisiKK();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzYpM2sTFG3lCd = _0023_003DzwBusyTBDWRBW();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzJhnylsHlav_0024n = _0023_003DztG7oqeEsiGCP();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DznqehKVub4JTS = _0023_003Dzm_EVjOMwjRYd();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzZ32GldEXPHbg = _0023_003DzHBZVHFEyBeHc();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzDUVBhsOhu44_0024 = _0023_003DzSKb0W00Eht0_0024();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzkXu4BscOMhO9 = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase _0023_003DzwzpgATa_0024z8Yi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase _0023_003DzUUH_jOQpGxTg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase _0023_003Dz1JBw7ul42g0G;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase _0023_003DzrmI3Ej7EFjib;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzPkzw1z5rqyYA = _0023_003DzWUgmeE8YqcXs();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzJE7ZC6zcJ14_0024O4rZlA_003D_003D = string.Empty;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz4Zz2hDkrZ7lL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D = _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz9oRn9SIN9NeQ = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzWmIpzVzj3tUi = _0023_003DzF_0024Y1Y3uxLaIf();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzGIpKXu0_003D = _0023_003DzndG2TcxO_tb_0024();

	public static HistogramData DefaultHistogram => new HistogramData(23, 0, 0, 5.0, -3.0, 1.0, new Tuple<double, double, int>[8]
	{
		new Tuple<double, double, int>(-3.0, -2.0, 0),
		new Tuple<double, double, int>(-2.0, -1.0, 1),
		new Tuple<double, double, int>(-1.0, 0.0, 2),
		new Tuple<double, double, int>(0.0, 1.0, 3),
		new Tuple<double, double, int>(1.0, 2.0, 3),
		new Tuple<double, double, int>(2.0, 3.0, 2),
		new Tuple<double, double, int>(3.0, 4.0, 1),
		new Tuple<double, double, int>(4.0, 5.0, 0)
	});

	[Description("Gets or sets the color of the background columns.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BackgroundColor
	{
		get
		{
			return _0023_003DzYpM2sTFG3lCd;
		}
		set
		{
			_0023_003DzYpM2sTFG3lCd = value;
		}
	}

	[Description("Gets or sets the color of the foreground columns.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color ColumnColor
	{
		get
		{
			return _0023_003DznqehKVub4JTS;
		}
		set
		{
			_0023_003DznqehKVub4JTS = value;
		}
	}

	[Description("Gets or sets the highlighted color of the diagram. A column becomes highlighted when hovering over it.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color HighlightColor
	{
		get
		{
			return _0023_003DzJhnylsHlav_0024n;
		}
		set
		{
			_0023_003DzJhnylsHlav_0024n = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Gets or sets lighting status. Affects the look of the diagram.")]
	public bool Lighting
	{
		get
		{
			return _0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D;
		}
		set
		{
			_0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D = value;
			_0023_003Dz9oRn9SIN9NeQ = true;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Gets or sets the visibility status.")]
	public bool Visible
	{
		get
		{
			return _0023_003DzGIpKXu0_003D;
		}
		set
		{
			_0023_003DzGIpKXu0_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Gets or sets the average mark visibility status.")]
	public bool ShowAverage
	{
		get
		{
			return _0023_003DzWmIpzVzj3tUi;
		}
		set
		{
			_0023_003DzWmIpzVzj3tUi = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Value's numeric format. Useful to change number format and decimal places.")]
	public string FormatString
	{
		get
		{
			return _0023_003DzPkzw1z5rqyYA;
		}
		set
		{
			if (_0023_003DzPkzw1z5rqyYA != value)
			{
				_0023_003DzPkzw1z5rqyYA = value;
				_0023_003Dz9oRn9SIN9NeQ = true;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Gets or sets the column's width in pixels.")]
	public int ColumnWidth
	{
		get
		{
			return _0023_003DzIL1y9fIhQuNt;
		}
		set
		{
			_0023_003DzIL1y9fIhQuNt = Math.Max(4, value);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Gets or sets the column's height in pixels.")]
	public int ColumnHeight
	{
		get
		{
			return _0023_003Dzyv6RsY1iJUic;
		}
		set
		{
			_0023_003Dzyv6RsY1iJUic = Math.Max(4, value);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description(" Gets or sets the title's string. The title is shown on the top-left corner of the diagram.")]
	public string Title
	{
		get
		{
			return _0023_003Dz9X_00246qCY_003D;
		}
		set
		{
			_0023_003Dz9X_00246qCY_003D = value;
			_0023_003Dz9oRn9SIN9NeQ = true;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Gets or sets the color used to draw texts for this diagram. Ignored when Lighting is set to false.")]
	public Color TextColor
	{
		get
		{
			return _0023_003DzDUVBhsOhu44_0024;
		}
		set
		{
			_0023_003DzDUVBhsOhu44_0024 = value;
			_0023_003Dz9oRn9SIN9NeQ = true;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Gets or sets the color of the average mark.")]
	public Color AverageLineColor
	{
		get
		{
			return _0023_003DzZ32GldEXPHbg;
		}
		set
		{
			_0023_003DzZ32GldEXPHbg = value;
			_0023_003Dz9oRn9SIN9NeQ = true;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public HistogramData HistogramData
	{
		get
		{
			return _0023_003DzvLO6oc_0024kuBQ_0024;
		}
		set
		{
			_0023_003DzvLO6oc_0024kuBQ_0024 = value;
			_0023_003DzoJKgKMoEivAc = _0023_003DzvLO6oc_0024kuBQ_0024.Bins.OrderByDescending((Tuple<double, double, int> _0023_003DzQIrNPUk_003D) => _0023_003DzQIrNPUk_003D.Item3).First().Item3;
			_0023_003Dz9oRn9SIN9NeQ = true;
		}
	}

	public Histogram()
		: this(DefaultHistogram, _0023_003DzmQl1CA0wezPR(), _0023_003DzD7yn9PWJm8jt(), _0023_003DzTggvRpdisiKK(), _0023_003Dzm_EVjOMwjRYd(), _0023_003DzwBusyTBDWRBW(), _0023_003DzSKb0W00Eht0_0024(), _0023_003DzHBZVHFEyBeHc(), _0023_003DztG7oqeEsiGCP(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DzF_0024Y1Y3uxLaIf(), _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D(), _0023_003DzWUgmeE8YqcXs())
	{
	}

	public Histogram(int columnWidth, int columnHeight, string title, Color columnColor, Color backgroundColor, Color textColor, Color averageColor, Color highlightColor, bool isVisible, bool showAverage, bool lighting, string formatString)
	{
		_0023_003DzshPEPAc_003D(DefaultHistogram, columnWidth, columnHeight, title, columnColor, backgroundColor, textColor, averageColor, highlightColor, isVisible, showAverage, lighting, formatString);
	}

	public Histogram(HistogramData histogramData, int columnWidth, int columnHeight, string title, Color columnColor, Color backgroundColor, Color textColor, Color averageColor, Color highlightColor, bool isVisible, bool showAverage, bool lighting, string formatString)
	{
		_0023_003DzshPEPAc_003D(histogramData, columnWidth, columnHeight, title, columnColor, backgroundColor, textColor, averageColor, highlightColor, isVisible, showAverage, lighting, formatString);
	}

	public Histogram(Histogram another)
	{
		_0023_003DzshPEPAc_003D(another.HistogramData, another.ColumnWidth, another.ColumnHeight, another.Title, RenderContextUtility.ConvertColor(another.ColumnColor), RenderContextUtility.ConvertColor(another.BackgroundColor), RenderContextUtility.ConvertColor(another.TextColor), RenderContextUtility.ConvertColor(another.AverageLineColor), RenderContextUtility.ConvertColor(another.HighlightColor), another.Visible, another.ShowAverage, another.Lighting, another.FormatString);
	}

	private void _0023_003DzshPEPAc_003D(HistogramData _0023_003Dz_myoC2I_003D, int _0023_003DzGw6jkJAWOP57, int _0023_003DzZjX_jVJfkWwJ, string _0023_003DzPw_8sZI_003D, Color _0023_003DzZS_Z8wo_003D, Color _0023_003DzNLGcq5k_003D, Color _0023_003Dzlxpb_Og_003D, Color _0023_003DzQcIBPX0_003D, Color _0023_003DzxJGJhjg_003D, bool _0023_003DzpBF5_0024KI_003D, bool _0023_003DzvYcWirjanwFO, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, string _0023_003Dzls52r2I_003D)
	{
		Visible = _0023_003DzpBF5_0024KI_003D;
		FormatString = _0023_003Dzls52r2I_003D;
		ColumnWidth = Math.Max(_0023_003DzGw6jkJAWOP57, 4);
		ColumnHeight = Math.Max(_0023_003DzZjX_jVJfkWwJ, 4);
		AverageLineColor = RenderContextUtility.ConvertColor(_0023_003DzQcIBPX0_003D);
		BackgroundColor = RenderContextUtility.ConvertColor(_0023_003DzNLGcq5k_003D);
		HighlightColor = RenderContextUtility.ConvertColor(_0023_003DzxJGJhjg_003D);
		TextColor = RenderContextUtility.ConvertColor(_0023_003Dzlxpb_Og_003D);
		Title = _0023_003DzPw_8sZI_003D;
		ShowAverage = _0023_003DzvYcWirjanwFO;
		Lighting = _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D;
		ColumnColor = RenderContextUtility.ConvertColor(_0023_003DzZS_Z8wo_003D);
		HistogramData = _0023_003Dz_myoC2I_003D;
	}

	private static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return false;
	}

	private static int _0023_003DzmQl1CA0wezPR()
	{
		return 30;
	}

	private static int _0023_003DzD7yn9PWJm8jt()
	{
		return 80;
	}

	private static Color _0023_003Dzm_EVjOMwjRYd()
	{
		return Color.Blue;
	}

	private static Color _0023_003DzwBusyTBDWRBW()
	{
		return Color.Gray;
	}

	private static Color _0023_003DztG7oqeEsiGCP()
	{
		return Color.LightYellow;
	}

	private static Color _0023_003DzHBZVHFEyBeHc()
	{
		return Color.Red;
	}

	private static Color _0023_003DzSKb0W00Eht0_0024()
	{
		return Color.Black;
	}

	private static string _0023_003DzTggvRpdisiKK()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647769);
	}

	private static bool _0023_003DzF_0024Y1Y3uxLaIf()
	{
		return true;
	}

	private static bool _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D()
	{
		return false;
	}

	private static string _0023_003DzWUgmeE8YqcXs()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589512);
	}

	private int _0023_003DzAc_0024nyiVUpYPn()
	{
		return (int)((double)_0023_003DzwzpgATa_0024z8Yi.Size.Height * 0.5);
	}

	private int _0023_003DzFWIDiRcbRagE()
	{
		return (int)((double)_0023_003DzwzpgATa_0024z8Yi.Size.Height * 0.2);
	}

	private int _0023_003Dz7DsE4vvXL7E7vpylug_003D_003D()
	{
		return (int)((double)_0023_003DzwzpgATa_0024z8Yi.Size.Height * 0.5);
	}

	private int _0023_003DzNBr6ybhyjZxRESmyPw_003D_003D()
	{
		return (int)((double)_0023_003DzwzpgATa_0024z8Yi.Size.Height * 0.2);
	}

	private int _0023_003DzhjsRCvYm7L_dp1gfDg_003D_003D()
	{
		_ = _0023_003DzwzpgATa_0024z8Yi.Size.Height;
		return 0;
	}

	private int _0023_003DzOldcAXfYUHwc()
	{
		return (int)((double)_0023_003DzwzpgATa_0024z8Yi.Size.Height * 0.2);
	}

	private bool _0023_003DzeO7bcoEYNoO5()
	{
		return !RenderContextUtility.AreEqual(BackgroundColor, _0023_003DzwBusyTBDWRBW());
	}

	private void _0023_003DzPc_Y3Ko9gyHq()
	{
		BackgroundColor = RenderContextUtility.ConvertColor(_0023_003DzwBusyTBDWRBW());
	}

	private bool _0023_003DzB7ugi1U1Whi4()
	{
		return !RenderContextUtility.AreEqual(ColumnColor, _0023_003Dzm_EVjOMwjRYd());
	}

	private void _0023_003Dz8KJs1i9_0024FO1X()
	{
		ColumnColor = RenderContextUtility.ConvertColor(_0023_003Dzm_EVjOMwjRYd());
	}

	private bool _0023_003DztwUFLIoIz_0024k_0024()
	{
		return !RenderContextUtility.AreEqual(HighlightColor, _0023_003DztG7oqeEsiGCP());
	}

	private void _0023_003Dz9ioQqruPEIL8()
	{
		HighlightColor = RenderContextUtility.ConvertColor(_0023_003DztG7oqeEsiGCP());
	}

	private bool _0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D()
	{
		return Lighting != _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();
	}

	private void _0023_003DzUi_NH3uU71f_AaJ5Gg_003D_003D()
	{
		Lighting = _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();
	}

	private bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return Visible != _0023_003DzndG2TcxO_tb_0024();
	}

	private void _0023_003DzGUdRoqIEEze_()
	{
		Visible = _0023_003DzndG2TcxO_tb_0024();
	}

	private bool _0023_003DzH9QBTV0wJUbyNqDwJQ_003D_003D()
	{
		return ShowAverage != _0023_003DzF_0024Y1Y3uxLaIf();
	}

	private void _0023_003DzGKWfW1yI6Q64()
	{
		ShowAverage = _0023_003DzF_0024Y1Y3uxLaIf();
	}

	private bool _0023_003Dze1UPisCj1fP_()
	{
		return FormatString != _0023_003DzWUgmeE8YqcXs();
	}

	private void _0023_003Dzszxv4cIWEC2P()
	{
		FormatString = _0023_003DzWUgmeE8YqcXs();
	}

	private bool _0023_003DzBhbEn0_pADw0()
	{
		return ColumnWidth != _0023_003DzmQl1CA0wezPR();
	}

	private void _0023_003DzlhbIkr1Dij1p()
	{
		ColumnWidth = _0023_003DzmQl1CA0wezPR();
	}

	private bool _0023_003DzT_0024Qv6o2fnjWc()
	{
		return ColumnHeight != _0023_003DzD7yn9PWJm8jt();
	}

	private void _0023_003DzCUAzKwKSU4rO()
	{
		ColumnHeight = _0023_003DzD7yn9PWJm8jt();
	}

	private bool _0023_003DzyhWwmgq8mZ64()
	{
		return Title != _0023_003DzTggvRpdisiKK();
	}

	private void _0023_003Dz8UTa_YRK7i0_0024()
	{
		Title = _0023_003DzTggvRpdisiKK();
	}

	private bool _0023_003DzR7lfdPM5Ly7X()
	{
		return !RenderContextUtility.AreEqual(TextColor, _0023_003DzSKb0W00Eht0_0024());
	}

	private void _0023_003DzXYtd_0024aXemTQ_0024()
	{
		TextColor = RenderContextUtility.ConvertColor(_0023_003DzSKb0W00Eht0_0024());
	}

	private bool _0023_003DzMYgFo38NP5QaRi8pyQ_003D_003D()
	{
		return !RenderContextUtility.AreEqual(AverageLineColor, _0023_003DzHBZVHFEyBeHc());
	}

	private void _0023_003DzSNhxuPP3RZf9()
	{
		AverageLineColor = RenderContextUtility.ConvertColor(_0023_003DzHBZVHFEyBeHc());
	}

	public static Histogram GetDefaultHistogram()
	{
		return new Histogram();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (!_0023_003DzMYgFo38NP5QaRi8pyQ_003D_003D() && !_0023_003DzeO7bcoEYNoO5() && !_0023_003DzB7ugi1U1Whi4() && !_0023_003DzT_0024Qv6o2fnjWc() && !_0023_003DzyhWwmgq8mZ64() && !_0023_003DzBhbEn0_pADw0() && !_0023_003DztwUFLIoIz_0024k_0024() && !_0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D() && !_0023_003DzH9QBTV0wJUbyNqDwJQ_003D_003D() && !_0023_003DzR7lfdPM5Ly7X())
		{
			return _0023_003Dz3SV_00249FPfwz1J();
		}
		return true;
	}

	private void _0023_003Dz0SvimYtbuT3m()
	{
		Color _0023_003Dzlxpb_Og_003D = (Lighting ? _0023_003DzZ32GldEXPHbg : _0023_003DzZ32GldEXPHbg);
		Color _0023_003Dz_MTHyUzel9SB = (Lighting ? Color.Transparent : ParentViewport.Background.GetContrastColorInverted());
		Workspace _0023_003Dz0TvaYNo_003D = ParentViewport._0023_003Dz0TvaYNo_003D;
		Bitmap bitmap = Workspace._0023_003DzRFGA2zTmmjXj(string.Format(FormatString, _0023_003DzvLO6oc_0024kuBQ_0024.Mean), _0023_003Dz0TvaYNo_003D.Font, _0023_003Dzlxpb_Og_003D, Color.Transparent, _0023_003Dz0TvaYNo_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: true, _0023_003Dz_MTHyUzel9SB, 0);
		_0023_003DzwzpgATa_0024z8Yi = _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: true, enlargeIfSizeNotSupported: true);
		bitmap.Dispose();
	}

	private void _0023_003DzA7xuuWlcsmTc()
	{
		Color _0023_003Dzlxpb_Og_003D = (Lighting ? _0023_003DzDUVBhsOhu44_0024 : ParentViewport.Background.GetContrastColor());
		Color _0023_003Dz_MTHyUzel9SB = (Lighting ? Color.Transparent : ParentViewport.Background.GetContrastColorInverted());
		Workspace _0023_003Dz0TvaYNo_003D = ParentViewport._0023_003Dz0TvaYNo_003D;
		Bitmap bitmap = Workspace._0023_003DzRFGA2zTmmjXj(string.Format(FormatString, _0023_003DzvLO6oc_0024kuBQ_0024.Bins[0].Item1), _0023_003Dz0TvaYNo_003D.Font, _0023_003Dzlxpb_Og_003D, Color.Transparent, _0023_003Dz0TvaYNo_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: true, _0023_003Dz_MTHyUzel9SB, 0);
		_0023_003DzUUH_jOQpGxTg = _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: true, enlargeIfSizeNotSupported: true);
		bitmap.Dispose();
		bitmap = Workspace._0023_003DzRFGA2zTmmjXj(string.Format(FormatString, _0023_003DzvLO6oc_0024kuBQ_0024.Bins.Last().Item2), _0023_003Dz0TvaYNo_003D.Font, _0023_003Dzlxpb_Og_003D, Color.Transparent, _0023_003Dz0TvaYNo_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: true, _0023_003Dz_MTHyUzel9SB, 0);
		_0023_003Dz1JBw7ul42g0G = _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: true, enlargeIfSizeNotSupported: true);
		bitmap.Dispose();
	}

	private void _0023_003DzMY92jyrLQIKb()
	{
		Color _0023_003Dzlxpb_Og_003D = (Lighting ? _0023_003DzDUVBhsOhu44_0024 : ParentViewport.Background.GetContrastColor());
		Color _0023_003Dz_MTHyUzel9SB = (Lighting ? Color.Transparent : ParentViewport.Background.GetContrastColorInverted());
		Workspace _0023_003Dz0TvaYNo_003D = ParentViewport._0023_003Dz0TvaYNo_003D;
		Bitmap bitmap = Workspace._0023_003DzRFGA2zTmmjXj(Title, _0023_003Dz0TvaYNo_003D.Font, _0023_003Dzlxpb_Og_003D, Color.Transparent, _0023_003Dz0TvaYNo_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: true, _0023_003Dz_MTHyUzel9SB, 0);
		_0023_003DzrmI3Ej7EFjib = _0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: true, enlargeIfSizeNotSupported: true);
		bitmap.Dispose();
	}

	private Rectangle _0023_003DztRcaydVbm_0024zU(Rectangle _0023_003Dz3R_0024cukrIKXVx)
	{
		int num = _0023_003DzvLO6oc_0024kuBQ_0024.Bins.Length * _0023_003DzIL1y9fIhQuNt + (_0023_003DzvLO6oc_0024kuBQ_0024.Bins.Length - 1) * _0023_003DzFWIDiRcbRagE();
		int num2 = _0023_003DzKzysyxWInqLc();
		int num3 = _0023_003Dz5lMtUJ2nSxWh();
		int x = (int)((double)(ParentViewport.Size.Width - num) / 2.0);
		int num4 = _0023_003DzAc_0024nyiVUpYPn() + num3 + num2;
		int y = num4;
		foreach (ToolBar item in ParentViewport.ToolBars.Where(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dzfx8cmLkC8R6mnXB7sWMUHiU_003D))
		{
			if (item.Position == ToolBar.positionType.HorizontalBottomCenter)
			{
				Rectangle bounds = item.GetBounds(ParentViewport);
				int num5 = ParentViewport.Size.Height - bounds.Y;
				if (ColumnHeight > num5)
				{
					y = num4 + num5;
				}
			}
		}
		return new Rectangle(x, y, num, _0023_003Dzyv6RsY1iJUic);
	}

	private int _0023_003DzKzysyxWInqLc()
	{
		return _0023_003DzUUH_jOQpGxTg.Size.Height + _0023_003DzNBr6ybhyjZxRESmyPw_003D_003D();
	}

	private int _0023_003Dz_0024CgHjPTX_EwU()
	{
		return _0023_003DzUUH_jOQpGxTg.Size.Width;
	}

	private int _0023_003Dz5lMtUJ2nSxWh()
	{
		if (!ShowAverage)
		{
			return 0;
		}
		return _0023_003DzwzpgATa_0024z8Yi.Size.Height + _0023_003DzhjsRCvYm7L_dp1gfDg_003D_003D();
	}

	private int _0023_003DzOufAxqtOkSMi()
	{
		return _0023_003DzrmI3Ej7EFjib.Size.Height + _0023_003Dz7DsE4vvXL7E7vpylug_003D_003D();
	}

	private int _0023_003DzgkDQHQ21zylg()
	{
		return _0023_003DzrmI3Ej7EFjib.Size.Width;
	}

	private static double _0023_003DzDb8oVUs_003D(double _0023_003DzsLHxXyo_003D, Interval _0023_003Dz76w7Z4giagRJ, int _0023_003DzoDzmrQs_003D)
	{
		double val = (_0023_003DzsLHxXyo_003D - _0023_003Dz76w7Z4giagRJ.Low) / _0023_003Dz76w7Z4giagRJ.Length;
		val = Math.Min(1.0, Math.Max(0.0, val));
		double num = (int)(val * (double)_0023_003DzoDzmrQs_003D);
		if (!(num <= (double)(_0023_003DzoDzmrQs_003D - 1)))
		{
			return _0023_003DzoDzmrQs_003D - 1;
		}
		return num;
	}

	private void _0023_003DzZ_0024w5UrgzDe6zIQN9xA_003D_003D()
	{
		if (_0023_003DzwzpgATa_0024z8Yi != null)
		{
			_0023_003DzwzpgATa_0024z8Yi.Dispose();
			_0023_003DzwzpgATa_0024z8Yi = null;
		}
		if (_0023_003DzUUH_jOQpGxTg != null)
		{
			_0023_003DzUUH_jOQpGxTg.Dispose();
			_0023_003DzUUH_jOQpGxTg = null;
		}
		if (_0023_003Dz1JBw7ul42g0G != null)
		{
			_0023_003Dz1JBw7ul42g0G.Dispose();
			_0023_003Dz1JBw7ul42g0G = null;
		}
		if (_0023_003DzrmI3Ej7EFjib != null)
		{
			_0023_003DzrmI3Ej7EFjib.Dispose();
			_0023_003DzrmI3Ej7EFjib = null;
		}
	}

	internal override void _0023_003Dz8WTvZ9I_003D(Workspace _0023_003DzUcDEGhkv_6eLJN4D_0024A_003D_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		ParentViewport = _0023_003DzYzWi5Yw_003D;
		_0023_003DzCY_uiCy4JvXn0VAkZWp06kk_003D();
	}

	private void _0023_003DzCY_uiCy4JvXn0VAkZWp06kk_003D()
	{
		_0023_003DzZ_0024w5UrgzDe6zIQN9xA_003D_003D();
		_0023_003Dz0SvimYtbuT3m();
		_0023_003DzA7xuuWlcsmTc();
		_0023_003DzMY92jyrLQIKb();
	}

	protected internal override void Draw(DrawSceneParams myParams)
	{
		if (!Visible)
		{
			return;
		}
		Viewport viewport = (Viewport)myParams.Viewport;
		if (viewport._0023_003Dz0TvaYNo_003D._0023_003DzipBYly6zFKAp() == viewport)
		{
			if (_0023_003Dz9oRn9SIN9NeQ)
			{
				_0023_003DzCY_uiCy4JvXn0VAkZWp06kk_003D();
				_0023_003Dz9oRn9SIN9NeQ = false;
			}
			myParams.RenderContext.PushDepthStencilState();
			myParams.RenderContext.PushBlendState();
			myParams.RenderContext.PushShader();
			myParams.RenderContext.SetState(depthStencilStateType.DepthTestOff);
			myParams.RenderContext.SetState(blendStateType.Blend);
			myParams.RenderContext.SetShader(shaderType.NoLights);
			Rectangle _0023_003Dz3R_0024cukrIKXVx = (myParams.ZoomRect.IsEmpty ? Rectangle.Empty : new Rectangle(0, 0, (int)((float)myParams.Viewport.Size.Width * myParams.Rectangle.Size.Width / myParams.ZoomRect.Size.Width), (int)((float)myParams.Viewport.Size.Height * myParams.Rectangle.Size.Height / myParams.ZoomRect.Size.Height)));
			Rectangle _0023_003Dzols9v2M_003D = _0023_003DztRcaydVbm_0024zU(_0023_003Dz3R_0024cukrIKXVx);
			_0023_003DzNbwAFLd9B6eqFd0rw_BQtcc_003D(_0023_003Dzols9v2M_003D);
			_0023_003DzmJFyDzFldUF7(_0023_003Dzols9v2M_003D);
			if (!Lighting)
			{
				_0023_003Dzn3LwLBRlDNQgbaYfpw_003D_003D(_0023_003Dzols9v2M_003D);
			}
			_0023_003DzGq93kPYpX8Bg(_0023_003Dzols9v2M_003D);
			if (ShowAverage)
			{
				int x = _0023_003Dzols9v2M_003D.Left + (int)Math.Max(Math.Min((_0023_003DzvLO6oc_0024kuBQ_0024.Mean - _0023_003DzvLO6oc_0024kuBQ_0024.Bins[0].Item1) / (_0023_003DzvLO6oc_0024kuBQ_0024.Bins.Last().Item2 - _0023_003DzvLO6oc_0024kuBQ_0024.Bins[0].Item1) * (double)_0023_003Dzols9v2M_003D.Width, _0023_003Dzols9v2M_003D.Width), 0.0);
				_0023_003DzlI9xRMdRso0h(new Point(x, _0023_003Dzols9v2M_003D.Top - _0023_003DzKzysyxWInqLc() - _0023_003DzhjsRCvYm7L_dp1gfDg_003D_003D()));
			}
			if (_0023_003DzkXu4BscOMhO9 != -1)
			{
				_0023_003DzrMXC341fYYep(_0023_003Dzols9v2M_003D);
			}
			_0023_003Dz5tCqrnS6dC6J(_0023_003Dzols9v2M_003D);
			myParams.RenderContext.PopDepthStencilState();
			myParams.RenderContext.PopShader();
			myParams.RenderContext.PopBlendState();
		}
	}

	private void _0023_003Dzn3LwLBRlDNQgbaYfpw_003D_003D(Rectangle _0023_003Dzols9v2M_003D)
	{
		Color contrastColor = ParentViewport.Background.GetContrastColor();
		int num = Math.Max(1, (int)(0.04 * (double)_0023_003DzIL1y9fIhQuNt));
		ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetColorWireframe(contrastColor);
		for (int i = 0; i < _0023_003DzvLO6oc_0024kuBQ_0024.Bins.Length; i++)
		{
			ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003Dzols9v2M_003D.Left + i * (_0023_003DzIL1y9fIhQuNt + _0023_003DzFWIDiRcbRagE()), _0023_003Dzols9v2M_003D.Top, num, _0023_003Dzyv6RsY1iJUic));
			ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003Dzols9v2M_003D.Left + i * (_0023_003DzIL1y9fIhQuNt + _0023_003DzFWIDiRcbRagE()) + _0023_003DzIL1y9fIhQuNt - num, _0023_003Dzols9v2M_003D.Top, num, _0023_003Dzyv6RsY1iJUic));
			ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003Dzols9v2M_003D.Left + i * (_0023_003DzIL1y9fIhQuNt + _0023_003DzFWIDiRcbRagE()), _0023_003Dzols9v2M_003D.Top, _0023_003DzIL1y9fIhQuNt, num));
			ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003Dzols9v2M_003D.Left + i * (_0023_003DzIL1y9fIhQuNt + _0023_003DzFWIDiRcbRagE()), _0023_003Dzols9v2M_003D.Bottom - num, _0023_003DzIL1y9fIhQuNt, num));
		}
	}

	private void _0023_003DzNbwAFLd9B6eqFd0rw_BQtcc_003D(Rectangle _0023_003Dzols9v2M_003D)
	{
		Color color = Color.FromArgb((int)(ParentViewport.Background.ColorThemeTransparency * 255.0 / 4.0), _0023_003DzYpM2sTFG3lCd);
		ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetColorWireframe(color);
		for (int i = 0; i < _0023_003DzvLO6oc_0024kuBQ_0024.Bins.Length; i++)
		{
			ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003Dzols9v2M_003D.Left + i * (_0023_003DzIL1y9fIhQuNt + _0023_003DzFWIDiRcbRagE()), _0023_003Dzols9v2M_003D.Top, _0023_003DzIL1y9fIhQuNt, _0023_003Dzyv6RsY1iJUic));
		}
	}

	protected new static void Repaint(Workspace workspace)
	{
		if (workspace._0023_003DzMBy_0024512q0kfX())
		{
			workspace.Invalidate();
			return;
		}
		workspace.PaintBackBuffer();
		workspace.SwapBuffers();
	}

	private void _0023_003DzrMXC341fYYep(Rectangle _0023_003Dzols9v2M_003D)
	{
		Color color = Color.FromArgb((int)(ParentViewport.Background.ColorThemeTransparency * 255.0 / 3.0), _0023_003DzYpM2sTFG3lCd);
		ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetColorWireframe(color);
		ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003Dzols9v2M_003D.Left + _0023_003DzkXu4BscOMhO9 * (_0023_003DzIL1y9fIhQuNt + _0023_003DzFWIDiRcbRagE()), _0023_003Dzols9v2M_003D.Top, _0023_003DzIL1y9fIhQuNt, _0023_003Dzyv6RsY1iJUic));
	}

	private void _0023_003DzmJFyDzFldUF7(Rectangle _0023_003Dzols9v2M_003D)
	{
		Color color = Color.FromArgb((int)(ParentViewport.Background.ColorThemeTransparency * 255.0), _0023_003DznqehKVub4JTS);
		for (int i = 0; i < _0023_003DzvLO6oc_0024kuBQ_0024.Bins.Length; i++)
		{
			if (_0023_003DzvLO6oc_0024kuBQ_0024.Bins[i].Item3 > 0)
			{
				ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetColorWireframe(color);
				ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003Dzols9v2M_003D.Left + i * (_0023_003DzIL1y9fIhQuNt + _0023_003DzFWIDiRcbRagE()), _0023_003Dzols9v2M_003D.Top, _0023_003DzIL1y9fIhQuNt, (int)((double)_0023_003DzvLO6oc_0024kuBQ_0024.Bins[i].Item3 / (double)_0023_003DzoJKgKMoEivAc * (double)_0023_003Dzyv6RsY1iJUic)));
			}
		}
	}

	private void _0023_003Dz5tCqrnS6dC6J(Rectangle _0023_003Dzols9v2M_003D)
	{
		Workspace._0023_003DzwCL3lEhabo_0024g(ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzrmI3Ej7EFjib, _0023_003Dz4Zz2hDkrZ7lL, _0023_003Dzols9v2M_003D.Bottom + _0023_003Dz7DsE4vvXL7E7vpylug_003D_003D(), ContentAlignment.BottomLeft, _0023_003DzPuIG8z4Ok7Hn: false, _0023_003DzJQ_0024zQtc_003D: false, out var _);
	}

	private void _0023_003DzGq93kPYpX8Bg(Rectangle _0023_003Dzols9v2M_003D)
	{
		Workspace._0023_003DzwCL3lEhabo_0024g(ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzUUH_jOQpGxTg, _0023_003Dzols9v2M_003D.Left, _0023_003Dzols9v2M_003D.Top - _0023_003DzNBr6ybhyjZxRESmyPw_003D_003D(), ContentAlignment.TopCenter, _0023_003DzPuIG8z4Ok7Hn: false, _0023_003DzJQ_0024zQtc_003D: false, out var _0023_003Dz6g4Y6AMwu8y);
		_0023_003Dz4Zz2hDkrZ7lL = _0023_003Dz6g4Y6AMwu8y.Left;
		Workspace._0023_003DzwCL3lEhabo_0024g(ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003Dz1JBw7ul42g0G, _0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Top - _0023_003DzNBr6ybhyjZxRESmyPw_003D_003D(), ContentAlignment.TopCenter, _0023_003DzPuIG8z4Ok7Hn: false, _0023_003DzJQ_0024zQtc_003D: false, out var _);
	}

	private void _0023_003DzlI9xRMdRso0h(Point _0023_003DzmE4SAfnesHPQ)
	{
		Workspace._0023_003DzwCL3lEhabo_0024g(ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzwzpgATa_0024z8Yi, _0023_003DzmE4SAfnesHPQ.X, _0023_003DzmE4SAfnesHPQ.Y, ContentAlignment.TopCenter, _0023_003DzPuIG8z4Ok7Hn: false, _0023_003DzJQ_0024zQtc_003D: false, out var _);
		ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetColorWireframe(_0023_003DzZ32GldEXPHbg);
		ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		ParentViewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003DzmE4SAfnesHPQ.X, _0023_003DzmE4SAfnesHPQ.Y, _0023_003DzOldcAXfYUHwc(), _0023_003DztRcaydVbm_0024zU(Rectangle.Empty).Height + _0023_003DzKzysyxWInqLc() + _0023_003DzhjsRCvYm7L_dp1gfDg_003D_003D()));
	}

	internal override bool _0023_003DzMhJnK2KPd8YE(Workspace _0023_003DzcUI95r0_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003DzwzpgATa_0024z8Yi == null || _0023_003Dz1JBw7ul42g0G == null || _0023_003DzUUH_jOQpGxTg == null || _0023_003DzrmI3Ej7EFjib == null)
		{
			return false;
		}
		if (_0023_003DzpJl96TJmtcSP(_0023_003Dz1SmHC4c_003D.Location) && _0023_003Dz1SmHC4c_003D.Button == MouseButtons.None)
		{
			_0023_003Dze4bCZA_S7dsL(_0023_003DzcUI95r0_003D, _0023_003Dz1SmHC4c_003D);
			Repaint(_0023_003DzcUI95r0_003D);
			return true;
		}
		if (_0023_003DzkXu4BscOMhO9 != -1)
		{
			_0023_003DzkXu4BscOMhO9 = -1;
			_0023_003DzcUI95r0_003D._0023_003DzhuBlAi9v6TXq(_0023_003DzWtFDQr8_003D: false);
			Repaint(_0023_003DzcUI95r0_003D);
			return false;
		}
		return false;
	}

	private void _0023_003Dze4bCZA_S7dsL(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		string text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589550);
		if (_0023_003DzJE7ZC6zcJ14_0024O4rZlA_003D_003D != text)
		{
			_0023_003DzJE7ZC6zcJ14_0024O4rZlA_003D_003D = text;
			_0023_003DzU0f5_qE_003D._0023_003DzPpGh50u0FkyM(_0023_003DzJE7ZC6zcJ14_0024O4rZlA_003D_003D);
			_0023_003DzU0f5_qE_003D._0023_003DzhuBlAi9v6TXq(_0023_003DzWtFDQr8_003D: true);
		}
	}

	private bool _0023_003DzpJl96TJmtcSP(Point _0023_003DzxGL6Kng_003D)
	{
		Rectangle rectangle = _0023_003DztRcaydVbm_0024zU(Rectangle.Empty);
		Point pt = new Point(_0023_003DzxGL6Kng_003D.X, ParentViewport.Size.Height - _0023_003DzxGL6Kng_003D.Y);
		if (!rectangle.Contains(pt))
		{
			return false;
		}
		_0023_003DzkXu4BscOMhO9 = (int)_0023_003DzDb8oVUs_003D(pt.X, new Interval(rectangle.Left, rectangle.Right), _0023_003DzvLO6oc_0024kuBQ_0024.Bins.Length);
		return true;
	}

	public override void Dispose()
	{
		base.Dispose();
		_0023_003DzZ_0024w5UrgzDe6zIQN9xA_003D_003D();
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		Rectangle rectangle = _0023_003DztRcaydVbm_0024zU(Rectangle.Empty);
		int num = (int)((double)_0023_003Dz_0024CgHjPTX_EwU() / 2.0);
		return new Rectangle(viewport.Location.X + rectangle.Location.X - num, viewport.Location.Y + viewport.Size.Height - rectangle.Location.Y - rectangle.Height - _0023_003DzOufAxqtOkSMi(), rectangle.Width + num * 2, rectangle.Height + _0023_003Dz5lMtUJ2nSxWh() + _0023_003DzKzysyxWInqLc() + _0023_003DzOufAxqtOkSMi());
	}

	public override void Update(IUserInterfaceElement another)
	{
		Histogram histogram = (Histogram)another;
		Color _0023_003DzZS_Z8wo_003D = RenderContextUtility.ConvertColor(histogram.ColumnColor);
		Color _0023_003DzNLGcq5k_003D = RenderContextUtility.ConvertColor(histogram.BackgroundColor);
		Color _0023_003DzxJGJhjg_003D = RenderContextUtility.ConvertColor(histogram.HighlightColor);
		Color _0023_003Dzlxpb_Og_003D = RenderContextUtility.ConvertColor(histogram.TextColor);
		Color _0023_003DzQcIBPX0_003D = RenderContextUtility.ConvertColor(histogram.AverageLineColor);
		_0023_003DzshPEPAc_003D(histogram.HistogramData, histogram.ColumnWidth, histogram.ColumnHeight, histogram.Title, _0023_003DzZS_Z8wo_003D, _0023_003DzNLGcq5k_003D, _0023_003Dzlxpb_Og_003D, _0023_003DzQcIBPX0_003D, _0023_003DzxJGJhjg_003D, histogram.Visible, histogram.ShowAverage, histogram.Lighting, histogram.FormatString);
	}

	public virtual object Clone()
	{
		return new Histogram(this);
	}
}
