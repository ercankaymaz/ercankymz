using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(GridConverter))]
public class Grid : UserInterfaceBase, ICloneable, IGrid
{
	internal enum _0023_003Dzp2xC_56LDhr6
	{

	}

	private Point2D _min = _0023_003DzLTSG1DMTMi6n();

	private Point2D _max = _0023_003DzzXycK2aQ0pa_0024();

	private double _step = _0023_003Dz1DsTOElApaec();

	private Color _lineColor = _0023_003DzQCZj0InUSIj3();

	private Color _colorAxisX = _0023_003Dz6O6WmgCZc9Kn();

	private Color _colorAxisY = _0023_003DzCff3qA6f6jPS();

	private Color _fillColor = _0023_003Dzl5GnhY3xHpW5();

	private Color _borderColor = _0023_003DziAyexVFQlS4_0024();

	private bool _autoSize;

	private bool _autoStep;

	private bool _visible = _0023_003DzndG2TcxO_tb_0024();

	private bool _lighting = _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();

	private Point2D _realMin;

	private Point2D _realMax;

	internal bool Recompute = true;

	private Plane _plane;

	private int _majorLinesEvery;

	private Color _majorLineColor;

	private int _minNumberOfLines;

	private int _maxNumberOfLines;

	private float[] minorLines;

	private float[] lineVOrig;

	private float[] lineHOrig;

	private float[] majorLines;

	private double[] minGridProjMatrix;

	private double[] maxGridProjMatrix;

	private Point2D startPt;

	private Point2D endPt;

	private double minNear;

	private double maxFar;

	private Point2D leftOverMin;

	private Point2D leftOverMax;

	private EntityGraphicsData _drawMinorLinesData;

	private EntityGraphicsData _drawMajorLinesData;

	public Point2D ActualMin => _realMin;

	public Point2D ActualMax => _realMax;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("When false, the UI element is drawn with a flat color.")]
	public bool Lighting
	{
		get
		{
			return _lighting;
		}
		set
		{
			_lighting = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Grid minimum 2D point relative to the grid plane.")]
	public Point2D Min
	{
		get
		{
			return _min;
		}
		set
		{
			_min = value;
			Recompute = true;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Grid maximum 2D point relative to the grid plane.")]
	public Point2D Max
	{
		get
		{
			return _max;
		}
		set
		{
			_max = value;
			Recompute = true;
		}
	}

	[Description("Step between grid lines.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double Step
	{
		get
		{
			return _step;
		}
		set
		{
			if (value != _step)
			{
				Recompute = true;
			}
			_step = value;
		}
	}

	[Description("The color used to draw lines.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color LineColor
	{
		get
		{
			return _lineColor;
		}
		set
		{
			_lineColor = value;
		}
	}

	[Description("Color used to draw axis X.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color ColorAxisX
	{
		get
		{
			return _colorAxisX;
		}
		set
		{
			_colorAxisX = value;
		}
	}

	[Description("Color used to draw axis Y.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color ColorAxisY
	{
		get
		{
			return _colorAxisY;
		}
		set
		{
			_colorAxisY = value;
		}
	}

	[Description("Color used to draw the grid plane.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color FillColor
	{
		get
		{
			return _fillColor;
		}
		set
		{
			_fillColor = value;
		}
	}

	[Description("Color used to draw the grid plane border.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BorderColor
	{
		get
		{
			return _borderColor;
		}
		set
		{
			_borderColor = value;
		}
	}

	[Description("When true, the grid is resized automatically every time the design's bounding box changes.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AutoSize
	{
		get
		{
			return _autoSize;
		}
		set
		{
			if (value != _autoSize)
			{
				Recompute = true;
			}
			_autoSize = value;
		}
	}

	[Description("The visibility status.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			_visible = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The grid plane.")]
	public Plane Plane
	{
		get
		{
			return _plane;
		}
		set
		{
			_plane = value;
			Recompute = true;
		}
	}

	[Description("When true, the grids is drawn always behind the geometry.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AlwaysBehind { get; set; }

	[Description("When true, the grid real step is a multiple of the Step to keep the number of lines between MinLines and MaxLines.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AutoStep
	{
		get
		{
			return _autoStep;
		}
		set
		{
			if (value != _autoStep)
			{
				Recompute = true;
			}
			_autoStep = value;
		}
	}

	[Description("Gets or sets the number of steps between two major lines.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int MajorLinesEvery
	{
		get
		{
			return _majorLinesEvery;
		}
		set
		{
			if (value != _majorLinesEvery)
			{
				Recompute = true;
			}
			_majorLinesEvery = value;
		}
	}

	[Description("Color used to draw major lines.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color MajorLineColor
	{
		get
		{
			return _majorLineColor;
		}
		set
		{
			_majorLineColor = value;
		}
	}

	[Description("When AutoStep is true, defines the Minimum number of lines.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int MinNumberOfLines
	{
		get
		{
			return _minNumberOfLines;
		}
		set
		{
			if (_minNumberOfLines != value)
			{
				Recompute = true;
			}
			_minNumberOfLines = value;
		}
	}

	[Description("If AutoStep is true, defines the Maximum number of lines.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int MaxNumberOfLines
	{
		get
		{
			return _maxNumberOfLines;
		}
		set
		{
			if (_maxNumberOfLines != value)
			{
				Recompute = true;
			}
			_maxNumberOfLines = value;
		}
	}

	public Grid()
		: this(_0023_003DzLTSG1DMTMi6n(), _0023_003DzzXycK2aQ0pa_0024(), _0023_003Dz1DsTOElApaec(), _0023_003DzE9RSY6yTonwalL35aQ_003D_003D(), _0023_003DzQCZj0InUSIj3(), _0023_003Dz6O6WmgCZc9Kn(), _0023_003DzCff3qA6f6jPS(), _0023_003Dzab7DmS9CoaNt(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DzYtvBUriC16S7(), _0023_003DzW6XArTiCtQMi(), _0023_003DzZpr9cyF8ObrDvgDK0g_003D_003D(), _0023_003DzYAF6Cxw9l2LcCjakxQ_003D_003D(), _0023_003Dzuf9KKkod26S0WoH51w_003D_003D(), _0023_003Dz7Nu_0024XkArigfR())
	{
	}

	public Grid(Point2D min, Point2D max, double step)
		: this(min, max, step, _0023_003DzE9RSY6yTonwalL35aQ_003D_003D())
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane)
		: this(min, max, step, plane, _0023_003DzQCZj0InUSIj3(), _0023_003Dz6O6WmgCZc9Kn())
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane, Color lineColor, Color axisColor)
		: this(min, max, step, plane, lineColor, axisColor, _0023_003Dzab7DmS9CoaNt(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DzYtvBUriC16S7())
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane, Color lineColor, Color axisColor, bool autoSize, bool visible, bool alwaysBehind)
		: this(min, max, step, plane, lineColor, axisColor, autoSize, visible, alwaysBehind, _0023_003DzW6XArTiCtQMi(), _0023_003DzZpr9cyF8ObrDvgDK0g_003D_003D(), _0023_003DzYAF6Cxw9l2LcCjakxQ_003D_003D())
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane, Color lineColor, Color axisColor, bool autoSize, bool visible, bool alwaysBehind, bool autoStep, int minNumberOfLines, int maxNumberOfLines)
		: this(min, max, step, plane, lineColor, axisColor, autoSize, visible, alwaysBehind, autoStep, minNumberOfLines, maxNumberOfLines, _0023_003Dzuf9KKkod26S0WoH51w_003D_003D(), _0023_003Dz7Nu_0024XkArigfR())
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane, Color lineColor, Color axisColor, bool autoSize, bool visible, bool alwaysBehind, bool autoStep, int minNumberOfLines, int maxNumberOfLines, int majorLinesEvery, Color majorLineColor)
		: this(min, max, step, plane, lineColor, axisColor, axisColor, autoSize, visible, alwaysBehind, autoStep, minNumberOfLines, maxNumberOfLines, majorLinesEvery, majorLineColor)
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane, Color lineColor, Color colorAxisX, Color colorAxisY, bool autoSize, bool visible, bool alwaysBehind, bool autoStep, int minNumberOfLines, int maxNumberOfLines, int majorLinesEvery, Color majorLineColor)
		: this(min, max, step, plane, lineColor, colorAxisX, colorAxisY, autoSize, visible, alwaysBehind, autoStep, minNumberOfLines, maxNumberOfLines, majorLinesEvery, majorLineColor, _0023_003Dzl5GnhY3xHpW5())
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane, Color lineColor, Color colorAxisX, Color colorAxisY, bool autoSize, bool visible, bool alwaysBehind, bool autoStep, int minNumberOfLines, int maxNumberOfLines, int majorLinesEvery, Color majorLineColor, Color fillColor)
		: this(min, max, step, plane, lineColor, colorAxisX, colorAxisY, autoSize, visible, alwaysBehind, autoStep, minNumberOfLines, maxNumberOfLines, majorLinesEvery, majorLineColor, fillColor, _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D())
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane, Color lineColor, Color colorAxisX, Color colorAxisY, bool autoSize, bool visible, bool alwaysBehind, bool autoStep, int minNumberOfLines, int maxNumberOfLines, int majorLinesEvery, Color majorLineColor, Color fillColor, bool lighting)
		: this(min, max, step, plane, lineColor, colorAxisX, colorAxisY, autoSize, visible, alwaysBehind, autoStep, minNumberOfLines, maxNumberOfLines, majorLinesEvery, majorLineColor, fillColor, lighting, _0023_003DziAyexVFQlS4_0024())
	{
	}

	public Grid(Point2D min, Point2D max, double step, Plane plane, Color lineColor, Color colorAxisX, Color colorAxisY, bool autoSize, bool visible, bool alwaysBehind, bool autoStep, int minNumberOfLines, int maxNumberOfLines, int majorLinesEvery, Color majorLineColor, Color fillColor, bool lighting, Color borderColor)
	{
		_0023_003DzshPEPAc_003D(min, max, step, plane, lineColor, colorAxisX, colorAxisY, autoSize, visible, alwaysBehind, autoStep, minNumberOfLines, maxNumberOfLines, majorLinesEvery, majorLineColor, fillColor, lighting, borderColor);
	}

	public Grid(Grid other)
	{
		_0023_003DzshPEPAc_003D(other._min, other._max, other._step, other.Plane, other._lineColor, other._colorAxisX, other._colorAxisY, other._autoSize, other._visible, other.AlwaysBehind, other._autoStep, other.MinNumberOfLines, other.MaxNumberOfLines, other.MajorLinesEvery, other._majorLineColor, other._fillColor, other._lighting, other._borderColor);
	}

	private static Point3D _0023_003DzLTSG1DMTMi6n()
	{
		return new Point3D(-100.0, -100.0);
	}

	private static Point3D _0023_003DzzXycK2aQ0pa_0024()
	{
		return new Point3D(100.0, 100.0);
	}

	private static double _0023_003Dz1DsTOElApaec()
	{
		return 1.0;
	}

	private static Plane _0023_003DzE9RSY6yTonwalL35aQ_003D_003D()
	{
		return Plane.XY;
	}

	private static Color _0023_003DzQCZj0InUSIj3()
	{
		return Color.FromArgb(63, Color.Gray);
	}

	private static Color _0023_003Dz7Nu_0024XkArigfR()
	{
		return Color.FromArgb(127, 90, 90, 90);
	}

	private static Color _0023_003Dz6O6WmgCZc9Kn()
	{
		return Color.FromArgb(127, Color.Red);
	}

	private static Color _0023_003DzCff3qA6f6jPS()
	{
		return Color.FromArgb(127, Color.Green);
	}

	private static Color _0023_003Dzl5GnhY3xHpW5()
	{
		return Color.Transparent;
	}

	private static Color _0023_003DziAyexVFQlS4_0024()
	{
		return Color.FromArgb(12, Color.Blue);
	}

	private static int _0023_003Dzuf9KKkod26S0WoH51w_003D_003D()
	{
		return 10;
	}

	private static bool _0023_003Dzab7DmS9CoaNt()
	{
		return false;
	}

	private static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return true;
	}

	private static bool _0023_003DzYtvBUriC16S7()
	{
		return false;
	}

	private static bool _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D()
	{
		return false;
	}

	private static bool _0023_003DzW6XArTiCtQMi()
	{
		return false;
	}

	private static int _0023_003DzYAF6Cxw9l2LcCjakxQ_003D_003D()
	{
		return 100;
	}

	private static int _0023_003DzZpr9cyF8ObrDvgDK0g_003D_003D()
	{
		return 10;
	}

	private bool _0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D()
	{
		return Lighting;
	}

	internal void _0023_003DzUi_NH3uU71f_AaJ5Gg_003D_003D()
	{
		Lighting = false;
	}

	private bool _0023_003Dzf_jaeaDk9O_s()
	{
		return Min != _0023_003DzLTSG1DMTMi6n();
	}

	private void _0023_003Dz6F5GRlXXsvuE()
	{
		Min = _0023_003DzLTSG1DMTMi6n();
	}

	private bool _0023_003Dz4hs_7LPj2MKK()
	{
		return Max != _0023_003DzzXycK2aQ0pa_0024();
	}

	private void _0023_003Dz_HtcTBW8S4fZ()
	{
		Max = _0023_003DzzXycK2aQ0pa_0024();
	}

	private bool _0023_003DzOQ72LC53PFkv()
	{
		return Step != _0023_003Dz1DsTOElApaec();
	}

	private void _0023_003DzpzVAl_Qd_T6b()
	{
		Step = _0023_003Dz1DsTOElApaec();
	}

	private bool _0023_003Dz3HZ8av99UI6W()
	{
		return _lineColor.ToArgb() != _0023_003DzQCZj0InUSIj3().ToArgb();
	}

	private void _0023_003Dz2sanD7CTleVe()
	{
		LineColor = _0023_003DzQCZj0InUSIj3();
	}

	private bool _0023_003DzrIHqzkI1JF8_feT6Bg_003D_003D()
	{
		return _colorAxisX.ToArgb() != _0023_003Dz6O6WmgCZc9Kn().ToArgb();
	}

	private void _0023_003DzW7HRIJZf1mki()
	{
		_colorAxisX = _0023_003Dz6O6WmgCZc9Kn();
	}

	private bool _0023_003Dz7JE_0024NZmcudM9Y6ge4A_003D_003D()
	{
		return _colorAxisY.ToArgb() != _0023_003DzCff3qA6f6jPS().ToArgb();
	}

	private void _0023_003Dz_ChmZ3CRV_de()
	{
		ColorAxisY = RenderContextUtility.ConvertColor(_0023_003DzCff3qA6f6jPS());
	}

	private bool _0023_003DzaVeiDjTzOarX()
	{
		return _fillColor.ToArgb() != _0023_003Dzl5GnhY3xHpW5().ToArgb();
	}

	private void _0023_003Dzya7R1OVgvHj6()
	{
		FillColor = RenderContextUtility.ConvertColor(_0023_003Dzl5GnhY3xHpW5());
	}

	private bool _0023_003DzoOf5ho00A4e1()
	{
		return _borderColor.ToArgb() != _0023_003DziAyexVFQlS4_0024().ToArgb();
	}

	private void _0023_003Dz14E6luzsT_0024U_0024()
	{
		BorderColor = RenderContextUtility.ConvertColor(_0023_003DziAyexVFQlS4_0024());
	}

	private bool _0023_003DzNX5iZxjog_0024NQ()
	{
		return AutoSize != _0023_003Dzab7DmS9CoaNt();
	}

	private void _0023_003DzB_mP7ZUJt9O4()
	{
		AutoSize = _0023_003Dzab7DmS9CoaNt();
	}

	private bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return Visible != _0023_003DzndG2TcxO_tb_0024();
	}

	private void _0023_003DzGUdRoqIEEze_()
	{
		Visible = _0023_003DzndG2TcxO_tb_0024();
	}

	private bool _0023_003Dzbqy7tGbebtAi0BSguw_003D_003D()
	{
		return Plane != _0023_003DzE9RSY6yTonwalL35aQ_003D_003D();
	}

	private void _0023_003DzaoUulI1kAJ_0024e()
	{
		Plane = _0023_003DzE9RSY6yTonwalL35aQ_003D_003D();
	}

	private bool _0023_003Dz8WWcB_0024gdDkIqEBVEAw_003D_003D()
	{
		return AlwaysBehind != _0023_003DzYtvBUriC16S7();
	}

	private void _0023_003DzPWuSEN8X4LqP()
	{
		AlwaysBehind = _0023_003DzYtvBUriC16S7();
	}

	private bool _0023_003Dz5NwLHUC2q1fxH_0024q_9Q_003D_003D()
	{
		return AutoStep != _0023_003DzW6XArTiCtQMi();
	}

	private void _0023_003Dzsy7vY0oeiqub()
	{
		AutoStep = _0023_003DzW6XArTiCtQMi();
	}

	private bool _0023_003DzqbuBxAupoWjVbkFRtA_003D_003D()
	{
		return MajorLinesEvery != _0023_003Dzuf9KKkod26S0WoH51w_003D_003D();
	}

	private void _0023_003Dzgjea6Qqp13SX9Ya9QQ_003D_003D()
	{
		MajorLinesEvery = _0023_003Dzuf9KKkod26S0WoH51w_003D_003D();
	}

	private bool _0023_003DzFsdrORW1p_0024eNI5r_0024AA_003D_003D()
	{
		return _majorLineColor.ToArgb() != _0023_003Dz7Nu_0024XkArigfR().ToArgb();
	}

	private void _0023_003DzRVU_z7CJuy5N()
	{
		_majorLineColor = _0023_003Dz7Nu_0024XkArigfR();
	}

	private bool _0023_003DzsnU5z00j8aKwu2mf2w_003D_003D()
	{
		return MinNumberOfLines != _0023_003DzZpr9cyF8ObrDvgDK0g_003D_003D();
	}

	private void _0023_003Dzxqkhf0J641nkEv9Evg_003D_003D()
	{
		MinNumberOfLines = _0023_003DzZpr9cyF8ObrDvgDK0g_003D_003D();
	}

	private bool _0023_003Dzqwu4sYbqsTj397g2zw_003D_003D()
	{
		return MaxNumberOfLines != _0023_003DzYAF6Cxw9l2LcCjakxQ_003D_003D();
	}

	private void _0023_003DzZwQMrirGmqAyQ_4NiQ_003D_003D()
	{
		MaxNumberOfLines = _0023_003DzYAF6Cxw9l2LcCjakxQ_003D_003D();
	}

	private void _0023_003DzshPEPAc_003D(Point2D _0023_003DzoYJjnU0_003D, Point2D _0023_003DzWRFixiU_003D, double _0023_003DztMUmTgk_003D, Plane _0023_003DzOrtNSQnn48wG, Color _0023_003DzT0RewOo_003D, Color _0023_003Dz7za7GTHi6R7f, Color _0023_003DzpDfAnOxonu9B, bool _0023_003Dznf0qQBQ_003D, bool _0023_003DzbWHNjOg_003D, bool _0023_003DzQeKbQJ_BCYRv, bool _0023_003DzHc7QCDKaROhL, int _0023_003DzXNDfrkSiOxxK, int _0023_003DzPiUj46JlCJuL, int _0023_003DzNafsLq3yTqXn, Color _0023_003DzN8uJHug4T4q9, Color _0023_003DzgUg07Uk_003D, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, Color _0023_003Dz6UlC0Gw_003D)
	{
		_min = _0023_003DzoYJjnU0_003D;
		_max = _0023_003DzWRFixiU_003D;
		Step = _0023_003DztMUmTgk_003D;
		Plane = (Plane)_0023_003DzOrtNSQnn48wG.Clone();
		LineColor = RenderContextUtility.ConvertColor(_0023_003DzT0RewOo_003D);
		ColorAxisX = RenderContextUtility.ConvertColor(_0023_003Dz7za7GTHi6R7f);
		ColorAxisY = RenderContextUtility.ConvertColor(_0023_003DzpDfAnOxonu9B);
		AutoSize = _0023_003Dznf0qQBQ_003D;
		Visible = _0023_003DzbWHNjOg_003D;
		AlwaysBehind = _0023_003DzQeKbQJ_BCYRv;
		AutoStep = _0023_003DzHc7QCDKaROhL;
		MinNumberOfLines = _0023_003DzXNDfrkSiOxxK;
		MaxNumberOfLines = _0023_003DzPiUj46JlCJuL;
		MajorLinesEvery = _0023_003DzNafsLq3yTqXn;
		MajorLineColor = RenderContextUtility.ConvertColor(_0023_003DzN8uJHug4T4q9);
		FillColor = RenderContextUtility.ConvertColor(_0023_003DzgUg07Uk_003D);
		Lighting = _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D;
		BorderColor = RenderContextUtility.ConvertColor(_0023_003Dz6UlC0Gw_003D);
	}

	internal void _0023_003Dz99kJFjE_003D(Viewport _0023_003DzYzWi5Yw_003D, int _0023_003DzatgWgTMc3NTm, _0023_003Dzp2xC_56LDhr6 _0023_003Dza3HTvMWw3UP_0024)
	{
		ParentViewport = _0023_003DzYzWi5Yw_003D;
		RenderContextBase _0023_003DzmNZD0Zs_003D = _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D;
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		_0023_003DzmNZD0Zs_003D.DisableClipPlanes();
		_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		_0023_003DzmNZD0Zs_003D.SetLineSize(1f, setShader: false);
		if (!_0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			_0023_003DzmNZD0Zs_003D.CloseTexture(force: true);
		}
		_0023_003DzmNZD0Zs_003D.SetLineSize(1f, setShader: false);
		UtilityEx._0023_003Dzg91LQv_00243gSwKmCjnSw_003D_003D(_0023_003DzmNZD0Zs_003D, _0023_003Dza3HTvMWw3UP_0024, _0023_003DzYzWi5Yw_003D, minGridProjMatrix, AlwaysBehind ? minGridProjMatrix : maxGridProjMatrix, Draw);
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
		_0023_003DzmNZD0Zs_003D.ProcessClippingPlanesVisibility(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, updateGraphics: true);
	}

	internal void _0023_003DzlZ_kJuw_003D(RenderContextBase _0023_003DzoC62DbA_003D, Camera _0023_003DzZ_0024IejP0R_0024_Cw, Transformation _0023_003Dz_0024uiLa0UlXkHZ, Point3D _0023_003DzpV4_U8o4JR26, Point3D _0023_003DzkokL1qtcIMpB, int _0023_003DzaKFuXnXvuGiD, CameraEyePosType _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D)
	{
		if (Recompute)
		{
			if (AutoSize && _0023_003DzaKFuXnXvuGiD > 0)
			{
				ComputeAutomaticSize(_0023_003DzpV4_U8o4JR26, _0023_003DzkokL1qtcIMpB, 0.5);
			}
			else
			{
				_realMin = new Point2D(Math.Min(Min.X, Max.X), Math.Min(Min.Y, Max.Y));
				_realMax = new Point2D(Math.Max(Min.X, Max.X), Math.Max(Min.Y, Max.Y));
			}
			_0023_003DzshPEPAc_003D(_0023_003DzoC62DbA_003D);
			Recompute = false;
		}
		_0023_003DzV9pE6kQDjJoa(_0023_003DzZ_0024IejP0R_0024_Cw, _0023_003Dz_0024uiLa0UlXkHZ, startPt, endPt, out minNear, out maxFar);
		minNear = _0023_003DzZ_0024IejP0R_0024_Cw.LimitNearFor3DAnaglyph(minNear);
		if (minNear != maxFar && (_0023_003DzZ_0024IejP0R_0024_Cw.ProjectionMode != projectionType.Perspective || minNear != 0.0))
		{
			_0023_003DzZ_0024IejP0R_0024_Cw.GetProjMatricesOutsideRange(AlwaysBehind, minNear, maxFar, _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D, out minGridProjMatrix, out maxGridProjMatrix);
		}
	}

	protected virtual void ComputeAutomaticSize(Point3D boxMin, Point3D boxMax, double extensionFactor)
	{
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(boxMin, boxMax);
		Point2D[] array = new Point2D[boundingBoxCorners.Length];
		for (int i = 0; i < boundingBoxCorners.Length; i++)
		{
			array[i] = Plane.Project(boundingBoxCorners[i]);
		}
		_realMin = Point2D.MaxValue;
		_realMax = Point2D.MinValue;
		Utility.UpdateMinMax(null, array, boundingBoxCorners.Length, _realMin, _realMax);
		Size2D size2D = new Size2D(_realMin, _realMax);
		double num = extensionFactor * (size2D.Min + size2D.Max) / 2.0;
		_realMin.X -= num;
		_realMax.X += num;
		_realMin.Y -= num;
		_realMax.Y += num;
	}

	internal void _0023_003DzshPEPAc_003D(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		_0023_003DzP43mHMSmeQAx(_realMin, _realMax, out var _0023_003DzRXPFpGA_003D, out var _0023_003DzXNmtO5o_003D, out startPt, out endPt, out var _0023_003Dzhe_0024reOVk3EAs);
		if (!(startPt.X > endPt.X) && !(startPt.Y > endPt.Y))
		{
			_0023_003Dz_0024OS0_vfJLNb0(startPt, endPt, _0023_003Dzhe_0024reOVk3EAs, _0023_003DzRXPFpGA_003D, _0023_003DzXNmtO5o_003D, out minorLines, out majorLines, out lineVOrig, out lineHOrig);
			_0023_003Dz8WTvZ9I_003D(_0023_003DzoC62DbA_003D);
		}
	}

	internal void _0023_003Dz8WTvZ9I_003D(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		_0023_003DzSJDeNOUaWXnt(_0023_003DzoC62DbA_003D);
		if (minorLines != null)
		{
			_0023_003DzoC62DbA_003D.Compile(_drawMinorLinesData, _0023_003DzjmzRLQL1Izy4, minorLines);
		}
		if (majorLines != null)
		{
			_0023_003DzoC62DbA_003D.Compile(_drawMajorLinesData, _0023_003DzjmzRLQL1Izy4, majorLines);
		}
	}

	private void _0023_003DzjmzRLQL1Izy4(RenderContextBase _0023_003DzoC62DbA_003D, object _0023_003DzCBM7XJK4_5H_0024)
	{
		float[] array = (float[])_0023_003DzCBM7XJK4_5H_0024;
		if (array.Length != 0)
		{
			_0023_003DzoC62DbA_003D.DrawLines(array);
		}
	}

	protected internal virtual void Draw(RenderContextBase context, IViewport viewport)
	{
		context.SetShader(shaderType.NoLights, null, force: true);
		context.PushModelView();
		Transformation transformation = new Transformation();
		transformation.Rotation(Plane.XY, Plane);
		double num = _step / 2.0;
		if (_fillColor.A != 0)
		{
			context.SetColorWireframe(_fillColor);
			context.PushRasterizerState();
			context.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1);
			context.DrawQuads(new Point3D[4]
			{
				Plane.PointAt(startPt.X + num, startPt.Y + num),
				Plane.PointAt(endPt.X - num, startPt.Y + num),
				Plane.PointAt(endPt.X - num, endPt.Y - num),
				Plane.PointAt(startPt.X + num, endPt.Y - num)
			}, new Vector3D[1] { Plane.AxisZ });
			context.PopRasterizerState();
		}
		Color contrastColor = viewport.Background.GetContrastColor();
		if (_borderColor.A != 0)
		{
			Color color = _borderColor;
			if (!_lighting)
			{
				color = Color.FromArgb(_borderColor.A, contrastColor);
			}
			context.SetColorWireframe(color);
			context.PushRasterizerState();
			context.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1);
			context.DrawQuads(new Point3D[4]
			{
				Plane.PointAt(startPt),
				Plane.PointAt(endPt.X, startPt.Y),
				Plane.PointAt(endPt.X - num, startPt.Y + num),
				Plane.PointAt(startPt.X + num, startPt.Y + num)
			}, new Vector3D[1] { Plane.AxisZ });
			context.DrawQuads(new Point3D[4]
			{
				Plane.PointAt(endPt.X - num, startPt.Y + num),
				Plane.PointAt(endPt.X, startPt.Y),
				Plane.PointAt(endPt),
				Plane.PointAt(endPt.X - num, endPt.Y - num)
			}, new Vector3D[1] { Plane.AxisZ });
			context.DrawQuads(new Point3D[4]
			{
				Plane.PointAt(endPt.X - num, endPt.Y - num),
				Plane.PointAt(endPt),
				Plane.PointAt(startPt.X, endPt.Y),
				Plane.PointAt(startPt.X + num, endPt.Y - num)
			}, new Vector3D[1] { Plane.AxisZ });
			context.DrawQuads(new Point3D[4]
			{
				Plane.PointAt(startPt.X + num, endPt.Y - num),
				Plane.PointAt(startPt.X, endPt.Y),
				Plane.PointAt(startPt),
				Plane.PointAt(startPt.X + num, startPt.Y + num)
			}, new Vector3D[1] { Plane.AxisZ });
			context.PopRasterizerState();
		}
		context.MultMatrixModelView(transformation);
		if (_lighting)
		{
			_0023_003Dz99kJFjE_003D(context, _lineColor, _drawMinorLinesData);
		}
		else
		{
			Color _0023_003Dzhpb8QNg_003D = Color.FromArgb(_lineColor.A, contrastColor);
			_0023_003Dz99kJFjE_003D(context, _0023_003Dzhpb8QNg_003D, _drawMinorLinesData);
		}
		if (majorLines != null && majorLines.Length != 0)
		{
			if (_lighting)
			{
				_0023_003Dz99kJFjE_003D(context, _majorLineColor, _drawMajorLinesData);
			}
			else
			{
				Color _0023_003Dzhpb8QNg_003D2 = Color.FromArgb(_majorLineColor.A, contrastColor);
				_0023_003Dz99kJFjE_003D(context, _0023_003Dzhpb8QNg_003D2, _drawMajorLinesData);
			}
		}
		if (lineVOrig != null)
		{
			if (_lighting)
			{
				context.SetColorWireframe(_colorAxisY);
			}
			else
			{
				Color color2 = Color.FromArgb(_colorAxisY.A, contrastColor);
				context.SetColorWireframe(color2);
			}
			context.DrawLine(lineVOrig);
		}
		if (lineHOrig != null)
		{
			if (_lighting)
			{
				context.SetColorWireframe(_colorAxisX);
			}
			else
			{
				Color color3 = Color.FromArgb(_colorAxisX.A, contrastColor);
				context.SetColorWireframe(color3);
			}
			context.DrawLine(lineHOrig);
		}
		context.PopModelView();
	}

	private static void _0023_003Dz99kJFjE_003D(RenderContextBase _0023_003DzoC62DbA_003D, Color _0023_003Dzhpb8QNg_003D, EntityGraphicsData _0023_003DzqOwbKcs_003D)
	{
		_0023_003DzoC62DbA_003D.SetColorWireframe(_0023_003Dzhpb8QNg_003D);
		_0023_003DzoC62DbA_003D.Draw(_0023_003DzqOwbKcs_003D);
	}

	private void _0023_003Dz_0024OS0_vfJLNb0(Point2D _0023_003DzZ5eHl_0024x4k5h8, Point2D _0023_003DzIvYyIem2dSnJ, double _0023_003Dzhe_0024reOVk3EAs, int _0023_003DzRXPFpGA_003D, int _0023_003DzXNmtO5o_003D, out float[] _0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, out float[] _0023_003Dz93_NsTHB3xnOyN20XA_003D_003D, out float[] _0023_003DzEmArvZpVdF2W, out float[] _0023_003DzPFq8E_0tHxGZ)
	{
		Point2D point2D;
		Point2D point2D2;
		if (AutoSize)
		{
			point2D = _0023_003DzZ5eHl_0024x4k5h8;
			point2D2 = _0023_003DzIvYyIem2dSnJ;
		}
		else
		{
			point2D = _0023_003DzZ5eHl_0024x4k5h8 - leftOverMin;
			point2D2 = _0023_003DzIvYyIem2dSnJ - leftOverMax;
		}
		int num = _0023_003Dz6Zoy3iIR6Dhl(point2D.X, point2D2.X, _0023_003Dzhe_0024reOVk3EAs);
		int num2 = _0023_003Dz6Zoy3iIR6Dhl(point2D.Y, point2D2.Y, _0023_003Dzhe_0024reOVk3EAs);
		int num3 = _0023_003DzRXPFpGA_003D + _0023_003DzXNmtO5o_003D;
		if (num != -1 && num < _0023_003DzRXPFpGA_003D)
		{
			num3--;
			_0023_003DzEmArvZpVdF2W = new float[6];
			int _0023_003DzPH_0024hvqk_003D = 0;
			_0023_003Dz1g_wMI4fee2Z(_0023_003DzEmArvZpVdF2W, 0.0, _0023_003DzZ5eHl_0024x4k5h8.Y, _0023_003DzIvYyIem2dSnJ.Y, ref _0023_003DzPH_0024hvqk_003D);
		}
		else
		{
			_0023_003DzEmArvZpVdF2W = null;
		}
		if (num2 != -1 && num2 < _0023_003DzXNmtO5o_003D)
		{
			num3--;
			_0023_003DzPFq8E_0tHxGZ = new float[6];
			int _0023_003DzPH_0024hvqk_003D2 = 0;
			_0023_003DzeiVmxYmLwISs(_0023_003DzPFq8E_0tHxGZ, 0.0, _0023_003DzZ5eHl_0024x4k5h8.X, _0023_003DzIvYyIem2dSnJ.X, ref _0023_003DzPH_0024hvqk_003D2);
		}
		else
		{
			_0023_003DzPFq8E_0tHxGZ = null;
		}
		int num4 = 0;
		int _0023_003Dzlq2dawbj0MWu = -1;
		int num5 = 0;
		int _0023_003Dzlq2dawbj0MWu2 = -1;
		int num6 = 0;
		if (MajorLinesEvery > 0)
		{
			num4 = _0023_003DzLnnHBaGbP5_0024Q(point2D.X, point2D2.X, _0023_003Dzhe_0024reOVk3EAs, MajorLinesEvery, out _0023_003Dzlq2dawbj0MWu);
			if (num >= 0)
			{
				num4--;
			}
			num5 = _0023_003DzLnnHBaGbP5_0024Q(point2D.Y, point2D2.Y, _0023_003Dzhe_0024reOVk3EAs, MajorLinesEvery, out _0023_003Dzlq2dawbj0MWu2);
			if (num2 >= 0)
			{
				num5--;
			}
			num6 = num5 + num4;
		}
		if (!AutoSize)
		{
			if (leftOverMin.X != 0.0)
			{
				num3++;
			}
			if (leftOverMin.Y != 0.0)
			{
				num3++;
			}
			if (leftOverMax.X != 0.0)
			{
				num3++;
			}
			if (leftOverMax.Y != 0.0)
			{
				num3++;
			}
		}
		_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D = new float[(num3 - num6) * 6];
		_0023_003Dz93_NsTHB3xnOyN20XA_003D_003D = new float[num6 * 6];
		int _0023_003DzPH_0024hvqk_003D3 = 0;
		int _0023_003DzPH_0024hvqk_003D4 = 0;
		double num7 = _0023_003DzZ5eHl_0024x4k5h8.X;
		if (!AutoSize && leftOverMin.X != 0.0)
		{
			_0023_003Dz1g_wMI4fee2Z(_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, num7, _0023_003DzZ5eHl_0024x4k5h8.Y, _0023_003DzIvYyIem2dSnJ.Y, ref _0023_003DzPH_0024hvqk_003D3);
			num7 -= leftOverMin.X;
		}
		if (num4 > 0)
		{
			for (int i = 0; i < _0023_003DzRXPFpGA_003D; i++)
			{
				if (i != num)
				{
					if (Math.Abs(i - _0023_003Dzlq2dawbj0MWu) % MajorLinesEvery == 0)
					{
						_0023_003Dz1g_wMI4fee2Z(_0023_003Dz93_NsTHB3xnOyN20XA_003D_003D, num7, _0023_003DzZ5eHl_0024x4k5h8.Y, _0023_003DzIvYyIem2dSnJ.Y, ref _0023_003DzPH_0024hvqk_003D4);
					}
					else
					{
						_0023_003Dz1g_wMI4fee2Z(_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, num7, _0023_003DzZ5eHl_0024x4k5h8.Y, _0023_003DzIvYyIem2dSnJ.Y, ref _0023_003DzPH_0024hvqk_003D3);
					}
				}
				num7 += _0023_003Dzhe_0024reOVk3EAs;
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzRXPFpGA_003D; j++)
			{
				if (j != num)
				{
					_0023_003Dz1g_wMI4fee2Z(_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, num7, _0023_003DzZ5eHl_0024x4k5h8.Y, _0023_003DzIvYyIem2dSnJ.Y, ref _0023_003DzPH_0024hvqk_003D3);
				}
				num7 += _0023_003Dzhe_0024reOVk3EAs;
			}
		}
		if (!AutoSize && leftOverMax.X != 0.0)
		{
			_0023_003Dz1g_wMI4fee2Z(_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, _0023_003DzIvYyIem2dSnJ.X, _0023_003DzZ5eHl_0024x4k5h8.Y, _0023_003DzIvYyIem2dSnJ.Y, ref _0023_003DzPH_0024hvqk_003D3);
		}
		num7 = _0023_003DzZ5eHl_0024x4k5h8.Y;
		if (!AutoSize && leftOverMin.Y != 0.0)
		{
			_0023_003DzeiVmxYmLwISs(_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, num7, _0023_003DzZ5eHl_0024x4k5h8.X, _0023_003DzIvYyIem2dSnJ.X, ref _0023_003DzPH_0024hvqk_003D3);
			num7 -= leftOverMin.Y;
		}
		if (num5 > 0)
		{
			for (int k = 0; k < _0023_003DzXNmtO5o_003D; k++)
			{
				if (k != num2)
				{
					if (Math.Abs(k - _0023_003Dzlq2dawbj0MWu2) % MajorLinesEvery == 0)
					{
						_0023_003DzeiVmxYmLwISs(_0023_003Dz93_NsTHB3xnOyN20XA_003D_003D, num7, _0023_003DzZ5eHl_0024x4k5h8.X, _0023_003DzIvYyIem2dSnJ.X, ref _0023_003DzPH_0024hvqk_003D4);
					}
					else
					{
						_0023_003DzeiVmxYmLwISs(_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, num7, _0023_003DzZ5eHl_0024x4k5h8.X, _0023_003DzIvYyIem2dSnJ.X, ref _0023_003DzPH_0024hvqk_003D3);
					}
				}
				num7 += _0023_003Dzhe_0024reOVk3EAs;
			}
		}
		else
		{
			for (int l = 0; l < _0023_003DzXNmtO5o_003D; l++)
			{
				if (l != num2)
				{
					_0023_003DzeiVmxYmLwISs(_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, num7, _0023_003DzZ5eHl_0024x4k5h8.X, _0023_003DzIvYyIem2dSnJ.X, ref _0023_003DzPH_0024hvqk_003D3);
				}
				num7 += _0023_003Dzhe_0024reOVk3EAs;
			}
		}
		if (!AutoSize && leftOverMax.Y != 0.0)
		{
			_0023_003DzeiVmxYmLwISs(_0023_003DzD0VVQLaKNFu6Cy8YBg_003D_003D, _0023_003DzIvYyIem2dSnJ.Y, _0023_003DzZ5eHl_0024x4k5h8.X, _0023_003DzIvYyIem2dSnJ.X, ref _0023_003DzPH_0024hvqk_003D3);
		}
	}

	private static int _0023_003DzLnnHBaGbP5_0024Q(double _0023_003DzriHDpk0_003D, double _0023_003DztMA38ag_003D, double _0023_003Dzhe_0024reOVk3EAs, int _0023_003DzWz2GEhT3y5mcUHPUSAZGqIQ_003D, out int _0023_003Dzlq2dawbj0MWu)
	{
		int num = _0023_003DzH4Maq_Q_003D(_0023_003DzriHDpk0_003D / _0023_003Dzhe_0024reOVk3EAs);
		int num2 = num - _0023_003DzWz2GEhT3y5mcUHPUSAZGqIQ_003D * (num / _0023_003DzWz2GEhT3y5mcUHPUSAZGqIQ_003D);
		if (num2 == 0)
		{
			_0023_003Dzlq2dawbj0MWu = 0;
		}
		else if (num2 > 0)
		{
			_0023_003Dzlq2dawbj0MWu = _0023_003DzWz2GEhT3y5mcUHPUSAZGqIQ_003D - num2;
		}
		else
		{
			_0023_003Dzlq2dawbj0MWu = -num2;
		}
		return _0023_003DzH4Maq_Q_003D((_0023_003DztMA38ag_003D - (_0023_003DzriHDpk0_003D + (double)_0023_003Dzlq2dawbj0MWu * _0023_003Dzhe_0024reOVk3EAs)) / ((double)_0023_003DzWz2GEhT3y5mcUHPUSAZGqIQ_003D * _0023_003Dzhe_0024reOVk3EAs) + 1.0);
	}

	private static int _0023_003DzH4Maq_Q_003D(double _0023_003DzoMNiNRw_003D)
	{
		if (Math.Ceiling(_0023_003DzoMNiNRw_003D) - _0023_003DzoMNiNRw_003D < 1E-06)
		{
			return (int)Math.Ceiling(_0023_003DzoMNiNRw_003D);
		}
		return (int)Math.Floor(_0023_003DzoMNiNRw_003D);
	}

	private void _0023_003DzP43mHMSmeQAx(Point2D _0023_003DzjgNaclVKPapt, Point2D _0023_003DzFkEdLw6Gu1_0024c, out int _0023_003DzRXPFpGA_003D, out int _0023_003DzXNmtO5o_003D, out Point2D _0023_003DzZ5eHl_0024x4k5h8, out Point2D _0023_003DzIvYyIem2dSnJ, out double _0023_003Dzhe_0024reOVk3EAs)
	{
		Size2D size2D = new Size2D(_0023_003DzjgNaclVKPapt, _0023_003DzFkEdLw6Gu1_0024c);
		double diagonal = size2D.Diagonal;
		_0023_003Dzhe_0024reOVk3EAs = _step;
		if (AutoStep)
		{
			int num = MaxNumberOfLines - 2;
			for (int i = 0; i < 2; i++)
			{
				double num2 = diagonal / _0023_003Dzhe_0024reOVk3EAs;
				if (num2 > (double)num || num2 < (double)MinNumberOfLines)
				{
					if (num2 > (double)num)
					{
						double num3 = diagonal / (double)num;
						_0023_003Dzhe_0024reOVk3EAs = _step * Math.Pow(2.0, Math.Ceiling(Math.Log(num3 / _step, 2.0)));
					}
					else
					{
						double num3 = diagonal / (double)MinNumberOfLines;
						_0023_003Dzhe_0024reOVk3EAs = _step * Math.Pow(2.0, Math.Floor(Math.Log(num3 / _step, 2.0)));
					}
				}
			}
		}
		Point2D point2D = Point2D.MidPoint(_0023_003DzjgNaclVKPapt, _0023_003DzFkEdLw6Gu1_0024c);
		if (AutoSize)
		{
			int num4 = ((int)(size2D.X / _0023_003Dzhe_0024reOVk3EAs) + 1) / 2;
			int num5 = ((int)(size2D.Y / _0023_003Dzhe_0024reOVk3EAs) + 1) / 2;
			if (num4 < 1)
			{
				num4 = 1;
			}
			if (num5 < 1)
			{
				num5 = 1;
			}
			_0023_003DzZ5eHl_0024x4k5h8 = new Point2D(point2D.X - (double)num4 * _0023_003Dzhe_0024reOVk3EAs, point2D.Y - (double)num5 * _0023_003Dzhe_0024reOVk3EAs);
		}
		else
		{
			_0023_003DzZ5eHl_0024x4k5h8 = (Point2D)_0023_003DzjgNaclVKPapt.Clone();
		}
		if (_autoSize)
		{
			_0023_003DzZ5eHl_0024x4k5h8.X = Math.Round(_0023_003DzZ5eHl_0024x4k5h8.X / _0023_003Dzhe_0024reOVk3EAs) * _0023_003Dzhe_0024reOVk3EAs;
			_0023_003DzZ5eHl_0024x4k5h8.Y = Math.Round(_0023_003DzZ5eHl_0024x4k5h8.Y / _0023_003Dzhe_0024reOVk3EAs) * _0023_003Dzhe_0024reOVk3EAs;
			leftOverMin = null;
			leftOverMax = null;
			int num6 = (int)((point2D.X - _0023_003DzZ5eHl_0024x4k5h8.X) / _0023_003Dzhe_0024reOVk3EAs) + 1;
			int num7 = (int)((point2D.Y - _0023_003DzZ5eHl_0024x4k5h8.Y) / _0023_003Dzhe_0024reOVk3EAs) + 1;
			_0023_003DzRXPFpGA_003D = 2 * num6;
			_0023_003DzXNmtO5o_003D = 2 * num7;
		}
		else
		{
			leftOverMin = new Point2D(_0023_003DzjgNaclVKPapt.X - Math.Ceiling(_0023_003DzjgNaclVKPapt.X / _0023_003Dzhe_0024reOVk3EAs) * _0023_003Dzhe_0024reOVk3EAs, _0023_003DzjgNaclVKPapt.Y - Math.Ceiling(_0023_003DzjgNaclVKPapt.Y / _0023_003Dzhe_0024reOVk3EAs) * _0023_003Dzhe_0024reOVk3EAs);
			leftOverMax = new Point2D(_0023_003DzFkEdLw6Gu1_0024c.X - Math.Floor(_0023_003DzFkEdLw6Gu1_0024c.X / _0023_003Dzhe_0024reOVk3EAs) * _0023_003Dzhe_0024reOVk3EAs, _0023_003DzFkEdLw6Gu1_0024c.Y - Math.Floor(_0023_003DzFkEdLw6Gu1_0024c.Y / _0023_003Dzhe_0024reOVk3EAs) * _0023_003Dzhe_0024reOVk3EAs);
			_0023_003DzRXPFpGA_003D = (int)Math.Round((_0023_003DzFkEdLw6Gu1_0024c.X - leftOverMax.X + leftOverMin.X - _0023_003DzZ5eHl_0024x4k5h8.X) / _0023_003Dzhe_0024reOVk3EAs + 1.0);
			_0023_003DzXNmtO5o_003D = (int)Math.Round((_0023_003DzFkEdLw6Gu1_0024c.Y - leftOverMax.Y + leftOverMin.Y - _0023_003DzZ5eHl_0024x4k5h8.Y) / _0023_003Dzhe_0024reOVk3EAs + 1.0);
		}
		if (AutoSize)
		{
			_0023_003DzIvYyIem2dSnJ = new Point2D(_0023_003DzZ5eHl_0024x4k5h8.X + (double)(_0023_003DzRXPFpGA_003D - 1) * _0023_003Dzhe_0024reOVk3EAs, _0023_003DzZ5eHl_0024x4k5h8.Y + (double)(_0023_003DzXNmtO5o_003D - 1) * _0023_003Dzhe_0024reOVk3EAs);
		}
		else
		{
			_0023_003DzIvYyIem2dSnJ = (Point2D)_0023_003DzFkEdLw6Gu1_0024c.Clone();
		}
	}

	private void _0023_003Dz1g_wMI4fee2Z(float[] _0023_003Dzm_gdWbg_003D, double _0023_003DzsLHxXyo_003D, double _0023_003Dzen_0024fIS0_003D, double _0023_003DzU_Q9Xi0_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		Point3D point3D = new Point3D(_0023_003DzsLHxXyo_003D, _0023_003Dzen_0024fIS0_003D);
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.X;
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.Y;
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.Z;
		point3D = new Point3D(_0023_003DzsLHxXyo_003D, _0023_003DzU_Q9Xi0_003D);
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.X;
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.Y;
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.Z;
	}

	private void _0023_003DzeiVmxYmLwISs(float[] _0023_003Dzm_gdWbg_003D, double _0023_003DzsLHxXyo_003D, double _0023_003DzGZr6kOc_003D, double _0023_003Dzmza_0024EO0_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		Point3D point3D = new Point3D(_0023_003DzGZr6kOc_003D, _0023_003DzsLHxXyo_003D);
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.X;
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.Y;
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.Z;
		point3D = new Point3D(_0023_003Dzmza_0024EO0_003D, _0023_003DzsLHxXyo_003D);
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.X;
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.Y;
		_0023_003Dzm_gdWbg_003D[_0023_003DzPH_0024hvqk_003D++] = (float)point3D.Z;
	}

	private int _0023_003Dz6Zoy3iIR6Dhl(double _0023_003DzriHDpk0_003D, double _0023_003DztMA38ag_003D, double _0023_003DztMUmTgk_003D)
	{
		if (_0023_003DzriHDpk0_003D <= 0.0 && _0023_003DztMA38ag_003D > 0.0)
		{
			return Math.Abs((int)Math.Round(_0023_003DzriHDpk0_003D / _0023_003DztMUmTgk_003D));
		}
		return -1;
	}

	private void _0023_003DzV9pE6kQDjJoa(Camera _0023_003DzZ_0024IejP0R_0024_Cw, Transformation _0023_003Dz_0024uiLa0UlXkHZ, Point2D _0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D, Point2D _0023_003Dz2Pfty2WDSlB45RWFHw_003D_003D, out double _0023_003Dz8SiEeqqjUObS, out double _0023_003DzVbNvU5kkJhqV)
	{
		Size2D size2D = new Size2D(_0023_003Dz2Pfty2WDSlB45RWFHw_003D_003D.X - _0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.X, _0023_003Dz2Pfty2WDSlB45RWFHw_003D_003D.Y - _0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.Y);
		double num = Math.Max(size2D.X, size2D.Y);
		Point2D[] array = new Point2D[4]
		{
			new Point2D(_0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.X, _0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.Y),
			new Point2D(_0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.X + num, _0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.Y),
			new Point2D(_0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.X + num, _0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.Y + num),
			new Point2D(_0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.X, _0023_003DzPyTxNfRaY2tbHyDSrA_003D_003D.Y + num)
		};
		Plane plane = Plane;
		Point3D[] array2 = new Point3D[4];
		for (int i = 0; i < 4; i++)
		{
			array2[i] = plane.PointAt(array[i]);
		}
		UtilityEx._0023_003DzLlW7aSdsQyHy(_0023_003DzZ_0024IejP0R_0024_Cw, array2, out _0023_003Dz8SiEeqqjUObS, out _0023_003DzVbNvU5kkJhqV);
	}

	private void _0023_003DzSJDeNOUaWXnt(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (_drawMinorLinesData == null)
		{
			_drawMinorLinesData = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		}
		if (_drawMajorLinesData == null)
		{
			_drawMajorLinesData = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		_drawMinorLinesData?.Dispose();
		_drawMajorLinesData?.Dispose();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(Grid _0023_003DzAbAO3f4_003D)
	{
		if (!(Min != _0023_003DzAbAO3f4_003D.Min) && !(Max != _0023_003DzAbAO3f4_003D.Max) && Step == _0023_003DzAbAO3f4_003D.Step && !(Plane != _0023_003DzAbAO3f4_003D.Plane) && _lineColor.ToArgb() == _0023_003DzAbAO3f4_003D._lineColor.ToArgb() && _colorAxisX.ToArgb() == _0023_003DzAbAO3f4_003D._colorAxisX.ToArgb() && _colorAxisY.ToArgb() == _0023_003DzAbAO3f4_003D._colorAxisY.ToArgb() && AutoSize == _0023_003DzAbAO3f4_003D.AutoSize && Visible == _0023_003DzAbAO3f4_003D.Visible && AlwaysBehind == _0023_003DzAbAO3f4_003D.AlwaysBehind && AutoStep == _0023_003DzAbAO3f4_003D.AutoStep && MinNumberOfLines == _0023_003DzAbAO3f4_003D.MinNumberOfLines && MaxNumberOfLines == _0023_003DzAbAO3f4_003D.MaxNumberOfLines && MajorLinesEvery == _0023_003DzAbAO3f4_003D.MajorLinesEvery && _majorLineColor.ToArgb() == _0023_003DzAbAO3f4_003D._majorLineColor.ToArgb() && Lighting == _0023_003DzAbAO3f4_003D.Lighting)
		{
			return _borderColor.ToArgb() != _0023_003DzAbAO3f4_003D._borderColor.ToArgb();
		}
		return true;
	}

	public override Image GetThumbnail(Viewport viewport, Size size, Color backgroundColor)
	{
		_0023_003DzlZ_kJuw_003D(viewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, viewport.Camera, null, viewport._0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003Dze4TpmVqI26AF, viewport._0023_003Dz0TvaYNo_003D._0023_003DzK3OaHhra7VrS._0023_003DzD4HjvLi8HsVr, viewport._0023_003Dz0TvaYNo_003D.Entities.Count, CameraEyePosType.Center);
		viewport.Camera.UpdateMatrices();
		Rectangle bounds = GetBounds(viewport);
		if (bounds.Left < viewport.Location.X)
		{
			bounds.Width -= viewport.Location.X - bounds.Left;
			bounds.Location = new System.Drawing.Point(viewport.Location.X, bounds.Location.Y);
		}
		if (bounds.Right > viewport.Location.X + viewport.Size.Width)
		{
			bounds.Width -= bounds.Right - viewport.Size.Width;
		}
		if (bounds.Top < viewport.Location.Y)
		{
			bounds.Height -= viewport.Location.Y - bounds.Top;
			bounds.Location = new System.Drawing.Point(bounds.Location.X, viewport.Location.Y);
		}
		if (bounds.Bottom > viewport.Location.Y + viewport.Size.Height)
		{
			bounds.Height -= bounds.Bottom - viewport.Size.Height;
		}
		return _0023_003DzxxnnHBbC5r2U(this, viewport, default(Size), bounds, size, backgroundColor);
	}

	internal Image _0023_003DzxxnnHBbC5r2U(IUserInterfaceElement _0023_003DzDkQ3_10_003D, Viewport _0023_003DzYzWi5Yw_003D, Size _0023_003Dz0_0024_0024VbFw_003D, Rectangle _0023_003DzLCFtN0k_003D, Size _0023_003Dz9UoBAvg_003D, Color _0023_003DzNLGcq5k_003D)
	{
		_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
		bool flag = _0023_003DzNLGcq5k_003D == Color.Empty;
		RenderContextBase.drawSceneFuncDelegate _0023_003DzHdL9CKamSnvn = ((!flag) ? new RenderContextBase.drawSceneFuncDelegate(DrawForBitmap) : new RenderContextBase.drawSceneFuncDelegate(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003Dz6LfbgRAYOjvE));
		return _0023_003DzYzWi5Yw_003D._0023_003DzNZ5R7KqLKF7E(new Viewport._0023_003Dz7XrVzbNXMo8q
		{
			_0023_003DzshGHYXMIRfsi = flag,
			_0023_003DzNLGcq5k_003D = _0023_003DzNLGcq5k_003D,
			_0023_003Dzy4MPItw_003D = _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D,
			_0023_003DzxFNeIFWItLae = _0023_003Dz0_0024_0024VbFw_003D,
			_0023_003DzLCFtN0k_003D = _0023_003DzLCFtN0k_003D,
			_0023_003DzCs_ZxbN2mZ30 = 1f,
			_0023_003DzbUBvby4V64DY = flag,
			_0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D = false,
			_0023_003Dz0W4nCS2oJwWK = false,
			_0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D = false,
			_0023_003DzmAezgho6pU2i = true,
			_0023_003DzHdL9CKamSnvn = _0023_003DzHdL9CKamSnvn
		}, _0023_003Dz9UoBAvg_003D);
	}

	protected override void DrawForBitmap(object drawSceneParams)
	{
		DrawSceneParams drawSceneParams2 = (DrawSceneParams)drawSceneParams;
		Viewport viewport = (Viewport)drawSceneParams2.Viewport;
		RenderContextBase renderContext = drawSceneParams2.RenderContext;
		Workspace workspace = (Workspace)drawSceneParams2.Workspace;
		renderContext.ClearColor(workspace._0023_003DzU7yFFKcRyseX());
		renderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		drawSceneParams2.RenderContext.FrontFaceCW = false;
		renderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		viewport._0023_003Dz191ozMVp28cu(drawSceneParams2.RenderContext, workspace._0023_003DzNwtRJ3cLTrAy(), drawSceneParams2.ZoomRect, _0023_003DzPHqp5dQ_003D: false, 0f, workspace._0023_003DzU7yFFKcRyseX(), _0023_003DzIHwNrERoZxEh: false);
		renderContext.SetState(depthStencilStateType.DepthTestLess);
		_0023_003DzKCqq1iC8575l(drawSceneParams2);
	}

	internal void _0023_003DzKCqq1iC8575l(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		double near = viewport.Camera.Near;
		double far = viewport.Camera.Far;
		if (minGridProjMatrix != null)
		{
			viewport.Camera.Near = minNear;
		}
		if (maxGridProjMatrix != null)
		{
			viewport.Camera.Far = maxFar;
		}
		viewport.Camera.SetupModelViewProjection(_0023_003DzCBM7XJK4_5H_0024.ZoomRect, setGraphics: true, shadowPass: false, reflection: false, _0023_003DzCBM7XJK4_5H_0024.CameraEyePos, applySceneTransformation: true);
		_0023_003Dz99kJFjE_003D(viewport, _0023_003DzCBM7XJK4_5H_0024.workspaceInternal.MyHeight, (_0023_003Dzp2xC_56LDhr6)1);
		viewport.Camera.Near = near;
		viewport.Camera.Far = far;
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		List<Point3D> list = new List<Point3D>
		{
			new Point3D(startPt.X, startPt.Y),
			new Point3D(endPt.X, startPt.Y),
			new Point3D(endPt.X, endPt.Y),
			new Point3D(startPt.X, endPt.Y),
			new Point3D(startPt.X, startPt.Y)
		};
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = Plane.PointAt(list[i]);
		}
		Mesh mesh = Mesh.CreatePlanar(new LinearPath(list), 0.1, Mesh.natureType.Plain);
		double near = viewport.Camera.Near;
		double far = viewport.Camera.Far;
		if (minGridProjMatrix != null)
		{
			viewport.Camera.Near = minNear;
		}
		if (maxGridProjMatrix != null)
		{
			viewport.Camera.Far = maxFar;
		}
		viewport.Camera.SetupProjection(default(RectangleF), _0023_003DzbwFGvuI_003D: false, _0023_003Dz5a0lNBR9CWFl: false, _0023_003Dz_OlmZyU_003D: false, CameraEyePosType.Center);
		PlaneEquation[] frustum = viewport.Camera.GetFrustum(viewport.GetViewFrame(), _0023_003Dz_OlmZyU_003D: false);
		for (int j = 0; j < frustum.Length; j++)
		{
			Plane plane = new Plane(frustum[j].ToArray());
			plane.Flip();
			mesh.CutBy(plane);
		}
		List<Point3D> list2 = new List<Point3D>(viewport.WorldToScreen(mesh.Vertices));
		viewport.Camera.Near = near;
		viewport.Camera.Far = far;
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		Utility.UpdateMinMax(null, list2, list2.Count, maxValue, minValue);
		int y = (int)((double)viewport._0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - minValue.Y);
		return new Rectangle(new System.Drawing.Point((int)maxValue.X, y), new Size((int)(minValue.X - maxValue.X), (int)(minValue.Y - maxValue.Y)));
	}

	public override void Update(IUserInterfaceElement another)
	{
		Grid grid = (Grid)another;
		_0023_003DzshPEPAc_003D(grid._min, grid._max, grid._step, grid.Plane, grid._lineColor, grid._colorAxisX, grid._colorAxisY, grid._autoSize, grid._visible, grid.AlwaysBehind, grid._autoStep, grid.MinNumberOfLines, grid.MaxNumberOfLines, grid.MajorLinesEvery, grid._majorLineColor, grid._fillColor, grid._lighting, grid._borderColor);
	}

	public virtual object Clone()
	{
		return new Grid(this);
	}

	internal void _0023_003DzZZedz_Wv_0024WfT(Viewport _0023_003DzYzWi5Yw_003D, bool _0023_003DzPHqp5dQ_003D, Point3D _0023_003DzoYJjnU0_003D, Point3D _0023_003DzWRFixiU_003D, int _0023_003Dz9FzxYm0_003D, int _0023_003Dzcynlfz_Vshyb, CameraEyePosType _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D)
	{
		if (!(!Visible || _0023_003DzPHqp5dQ_003D))
		{
			_0023_003DzlZ_kJuw_003D(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D.Camera, null, _0023_003DzoYJjnU0_003D, _0023_003DzWRFixiU_003D, _0023_003Dz9FzxYm0_003D, _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D);
			_0023_003Dz99kJFjE_003D(_0023_003DzYzWi5Yw_003D, _0023_003Dzcynlfz_Vshyb, (_0023_003Dzp2xC_56LDhr6)2);
		}
	}

	private GridSettings _0023_003DzGD8_x0MEPu3J8aOtLIjS3_0024L60gLJRgVjmQ_003D_003D()
	{
		return new GridSettings
		{
			Plane = (Plane)Plane.Clone(),
			ColorAxisX = _colorAxisX,
			ColorAxisY = _colorAxisY,
			Lighting = Lighting
		};
	}

	GridSettings IGrid.GetSettings()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zGD8_x0MEPu3J8aOtLIjS3$L60gLJRgVjmQ==
		return this._0023_003DzGD8_x0MEPu3J8aOtLIjS3_0024L60gLJRgVjmQ_003D_003D();
	}

	private void _0023_003DzfH87z2QUnmck0GUXuynaZdm0RKpGh7hqBA_003D_003D(GridSettings _0023_003DzOUFng_M_003D)
	{
		Plane = _0023_003DzOUFng_M_003D.Plane;
		ColorAxisX = RenderContextUtility.ConvertColor(_0023_003DzOUFng_M_003D.ColorAxisX);
		ColorAxisY = RenderContextUtility.ConvertColor(_0023_003DzOUFng_M_003D.ColorAxisY);
		Lighting = _0023_003DzOUFng_M_003D.Lighting;
	}

	void IGrid.ApplySettings(GridSettings _0023_003DzOUFng_M_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zfH87z2QUnmck0GUXuynaZdm0RKpGh7hqBA==
		this._0023_003DzfH87z2QUnmck0GUXuynaZdm0RKpGh7hqBA_003D_003D(_0023_003DzOUFng_M_003D);
	}
}
