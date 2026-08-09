using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(ScaleBarConverter))]
public class ScaleBar : UserInterfaceBase, IUserInterfaceElement, IUserInterfaceElementBase, IDisposable, ICloneable
{
	private enum _0023_003DzKBt3fDM7lnVt
	{

	}

	public enum positionType
	{
		TopLeft,
		TopCenter,
		TopRight,
		BottomRight,
		BottomCenter,
		BottomLeft
	}

	public enum styleType
	{
		Single,
		Double,
		Alternate
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzBAY5JG2_0024Zo0Qlui4hQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzwG1FbuYfDz3E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzwEL0w574i3jO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzDUVBhsOhu44_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzMHjY2xGZclmD63jh1A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private styleType _0023_003DzU_hIjulDg9rByIZc54yIies_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzZWAzMRChU55jVyKT0g_003D_003D = _0023_003DzHvTCvn7jeJiSZ_0024UPkw_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzptGjWkyxmAY5 = _0023_003DzyQV_0024fIP7z02T();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzuh1jpGhPTULH = _0023_003DzgrHo2ifZFpKW();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private positionType _0023_003DzABDpBS0_003D = _0023_003DzPkO7IBwkBx9t();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Font _0023_003DzaAQLLBXfRolO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Font _0023_003DzXIQvTdJYGC4Y;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private linearUnitsType? _0023_003Dz6LzJF8f8LQsGygpuQsz2wAM_003D = _0023_003DzWVEZxqzZb2Go();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Rectangle _0023_003Dzti0S0oE_003D = Rectangle.Empty;

	[Description("ScaleBar visibility status. Visibility is automatically turned off during a perspective projection")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Visible
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzBAY5JG2_0024Zo0Qlui4hQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzBAY5JG2_0024Zo0Qlui4hQ_003D_003D = value;
		}
	}

	[Description("First background color, also applied as border color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BackgroundColor1
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzwG1FbuYfDz3E);
		}
		set
		{
			if (_0023_003DzwG1FbuYfDz3E != RenderContextUtility.ConvertColor(value))
			{
				_0023_003DzwG1FbuYfDz3E = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[Description("Second background color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BackgroundColor2
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzwEL0w574i3jO);
		}
		set
		{
			if (_0023_003DzwEL0w574i3jO != RenderContextUtility.ConvertColor(value))
			{
				_0023_003DzwEL0w574i3jO = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[Description("Text color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color TextColor
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzDUVBhsOhu44_0024);
		}
		set
		{
			if (_0023_003DzDUVBhsOhu44_0024 != RenderContextUtility.ConvertColor(value))
			{
				_0023_003DzDUVBhsOhu44_0024 = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[Description("Value's numeric format. Useful to change number format and decimal places.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string FormatString
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMHjY2xGZclmD63jh1A_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzMHjY2xGZclmD63jh1A_003D_003D = value;
		}
	}

	[Description("When false, the UI element is drawn with a flat color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Lighting
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn = value;
		}
	}

	[Description("The scale bar style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public styleType StyleMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzU_hIjulDg9rByIZc54yIies_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzU_hIjulDg9rByIZc54yIies_003D = value;
		}
	}

	[Description("The maximum number of different color bars.\r\nThis number will never be exceeded, instead, the bar will change its scale.\r\nCannot be lower than 1.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int MaxNumberOfBars
	{
		get
		{
			return _0023_003DzZWAzMRChU55jVyKT0g_003D_003D;
		}
		set
		{
			_0023_003DzZWAzMRChU55jVyKT0g_003D_003D = Math.Max(1, value);
		}
	}

	[Description("Height of the bars in pixels.\r\nCannot be lower than 3.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int BarsHeight
	{
		get
		{
			return _0023_003DzptGjWkyxmAY5;
		}
		set
		{
			_0023_003DzptGjWkyxmAY5 = Math.Max(3, value);
		}
	}

	[Description("The max width as a percentage of the parent viewport width.\r\nUsed to determine the number of bars to draw.\r\nValues can range from 0.01 to 1..")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double MaxWidth
	{
		get
		{
			return _0023_003Dzuh1jpGhPTULH;
		}
		set
		{
			_0023_003Dzuh1jpGhPTULH = Math.Min(Math.Max(0.01, value), 1.0);
		}
	}

	[Description("The ScaleBar position.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public positionType Position
	{
		get
		{
			return _0023_003DzABDpBS0_003D;
		}
		set
		{
			_0023_003DzABDpBS0_003D = value;
			_0023_003Dzti0S0oE_003D = Rectangle.Empty;
		}
	}

	[Description("The ScaleBar text font.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Font Font
	{
		get
		{
			return _0023_003DzXIQvTdJYGC4Y ?? _0023_003DzaAQLLBXfRolO;
		}
		set
		{
			if (_0023_003DzXIQvTdJYGC4Y == null || !_0023_003DzXIQvTdJYGC4Y.Equals(value))
			{
				_0023_003DzXIQvTdJYGC4Y = value;
			}
		}
	}

	[Description("The ScaleBar unit system.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public linearUnitsType? UnitsOverride
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz6LzJF8f8LQsGygpuQsz2wAM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz6LzJF8f8LQsGygpuQsz2wAM_003D = value;
		}
	}

	public ScaleBar()
		: this(_0023_003DzndG2TcxO_tb_0024(), _0023_003DzGPP3Pyu2dQt9(), _0023_003DzAwXlKBcpus3R(), _0023_003DzSKb0W00Eht0_0024(), _0023_003DzWUgmeE8YqcXs(), _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D(), _0023_003DzCp6SpVT8Q9QG(), _0023_003DzHvTCvn7jeJiSZ_0024UPkw_003D_003D(), _0023_003DzyQV_0024fIP7z02T(), _0023_003DzgrHo2ifZFpKW(), _0023_003DzPkO7IBwkBx9t(), _0023_003Dz0UloR3WvSVa2(), _0023_003DzWVEZxqzZb2Go())
	{
	}

	public ScaleBar(bool visible, Color backgroundColor1, Color backgroundColor2, Color textColor)
		: this(visible, backgroundColor1, backgroundColor2, textColor, _0023_003DzWUgmeE8YqcXs(), _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D())
	{
	}

	public ScaleBar(bool visible, Color backgroundColor1, Color backgroundColor2, Color textColor, string formatString, bool lighting)
		: this(visible, backgroundColor1, backgroundColor2, textColor, formatString, lighting, _0023_003DzCp6SpVT8Q9QG(), _0023_003DzHvTCvn7jeJiSZ_0024UPkw_003D_003D(), _0023_003DzyQV_0024fIP7z02T(), _0023_003DzgrHo2ifZFpKW(), _0023_003DzPkO7IBwkBx9t(), _0023_003Dz0UloR3WvSVa2(), _0023_003DzWVEZxqzZb2Go())
	{
	}

	[Obsolete("Use the Standard constructor instead.")]
	public ScaleBar(bool visible, Color backgroundColor1, Color backgroundColor2, Color textColor, string formatString, bool lighting, styleType styleMode)
	{
		_0023_003DzshPEPAc_003D(visible, backgroundColor1, backgroundColor2, textColor, formatString, lighting, styleMode, _0023_003DzHvTCvn7jeJiSZ_0024UPkw_003D_003D(), _0023_003DzyQV_0024fIP7z02T(), _0023_003DzgrHo2ifZFpKW(), _0023_003DzPkO7IBwkBx9t(), _0023_003Dz0UloR3WvSVa2(), _0023_003DzWVEZxqzZb2Go());
	}

	public ScaleBar(bool visible, Color backgroundColor1, Color backgroundColor2, Color textColor, string formatString, bool lighting, styleType styleMode, int maxBars, int barsHeight, double maxWidth, positionType position, Font font, linearUnitsType? units)
	{
		_0023_003DzshPEPAc_003D(visible, backgroundColor1, backgroundColor2, textColor, formatString, lighting, styleMode, maxBars, barsHeight, maxWidth, position, font, units);
	}

	public ScaleBar(ScaleBar another)
	{
		_0023_003DzshPEPAc_003D(another.Visible, RenderContextUtility.ConvertColor(another.BackgroundColor1), RenderContextUtility.ConvertColor(another.BackgroundColor2), RenderContextUtility.ConvertColor(another.TextColor), another.FormatString, another.Lighting, another.StyleMode, another.MaxNumberOfBars, another.BarsHeight, another.MaxWidth, another.Position, another.Font, another.UnitsOverride);
	}

	internal static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return false;
	}

	internal static Color _0023_003DzGPP3Pyu2dQt9()
	{
		return Color.Black;
	}

	internal static Color _0023_003DzAwXlKBcpus3R()
	{
		return Color.White;
	}

	internal static Color _0023_003DzSKb0W00Eht0_0024()
	{
		return Color.Black;
	}

	internal static string _0023_003DzWUgmeE8YqcXs()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593158);
	}

	internal static bool _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D()
	{
		return false;
	}

	internal static styleType _0023_003DzCp6SpVT8Q9QG()
	{
		return styleType.Alternate;
	}

	internal static int _0023_003DzHvTCvn7jeJiSZ_0024UPkw_003D_003D()
	{
		return 4;
	}

	internal static int _0023_003DzyQV_0024fIP7z02T()
	{
		return 15;
	}

	internal static double _0023_003DzgrHo2ifZFpKW()
	{
		return 0.4;
	}

	internal static positionType _0023_003DzPkO7IBwkBx9t()
	{
		return positionType.BottomCenter;
	}

	internal static linearUnitsType? _0023_003DzWVEZxqzZb2Go()
	{
		return null;
	}

	private static Font _0023_003Dz0UloR3WvSVa2()
	{
		return null;
	}

	private bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return Visible != _0023_003DzndG2TcxO_tb_0024();
	}

	private void _0023_003DzGUdRoqIEEze_()
	{
		Visible = _0023_003DzndG2TcxO_tb_0024();
	}

	private bool _0023_003DzfFj9WQPpfkwVWmmcZQ_003D_003D()
	{
		return !RenderContextUtility.AreEqual(BackgroundColor1, _0023_003DzGPP3Pyu2dQt9());
	}

	private void _0023_003DzPc_Y3Ko9gyHq()
	{
		BackgroundColor1 = RenderContextUtility.ConvertColor(_0023_003DzGPP3Pyu2dQt9());
	}

	private bool _0023_003Dz_sPq8Vr_ajZc6z5eBQ_003D_003D()
	{
		return !RenderContextUtility.AreEqual(BackgroundColor2, _0023_003DzAwXlKBcpus3R());
	}

	private void _0023_003DzuOVJ22zz4Vvj()
	{
		BackgroundColor2 = RenderContextUtility.ConvertColor(_0023_003DzAwXlKBcpus3R());
	}

	private bool _0023_003DzR7lfdPM5Ly7X()
	{
		return !RenderContextUtility.AreEqual(TextColor, _0023_003DzSKb0W00Eht0_0024());
	}

	private void _0023_003DzXYtd_0024aXemTQ_0024()
	{
		TextColor = RenderContextUtility.ConvertColor(_0023_003DzSKb0W00Eht0_0024());
	}

	private bool _0023_003Dze1UPisCj1fP_()
	{
		return FormatString != _0023_003DzWUgmeE8YqcXs();
	}

	private void _0023_003Dzszxv4cIWEC2P()
	{
		FormatString = _0023_003DzWUgmeE8YqcXs();
	}

	private bool _0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D()
	{
		return Lighting;
	}

	internal void _0023_003DzUi_NH3uU71f_AaJ5Gg_003D_003D()
	{
		Lighting = _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();
	}

	private bool _0023_003DzuooydjCMSwlZPpsh1w_003D_003D()
	{
		return StyleMode == _0023_003DzCp6SpVT8Q9QG();
	}

	internal void _0023_003DzyUvVZflI9bLt()
	{
		StyleMode = _0023_003DzCp6SpVT8Q9QG();
	}

	private bool _0023_003Dzp4zeyTm_0024_0024XPxTZPeDQ_003D_003D()
	{
		return MaxNumberOfBars != _0023_003DzHvTCvn7jeJiSZ_0024UPkw_003D_003D();
	}

	internal void _0023_003DzIMSgrjs5szOFDmj4ng_003D_003D()
	{
		MaxNumberOfBars = _0023_003DzHvTCvn7jeJiSZ_0024UPkw_003D_003D();
	}

	private bool _0023_003DzyOS_0024WJFupR1frgS5yw_003D_003D()
	{
		return BarsHeight != _0023_003DzyQV_0024fIP7z02T();
	}

	internal void _0023_003Dzj68ppQS3nP5M()
	{
		BarsHeight = _0023_003DzyQV_0024fIP7z02T();
	}

	private bool _0023_003DzQEXAd2PO3IaD7XzPuA_003D_003D()
	{
		return MaxWidth != _0023_003DzgrHo2ifZFpKW();
	}

	internal void _0023_003DzE1LqbiHMPNp4()
	{
		MaxWidth = _0023_003DzgrHo2ifZFpKW();
	}

	private bool _0023_003DzbUxkg_0024pX8GiH()
	{
		return Position != _0023_003DzPkO7IBwkBx9t();
	}

	internal void _0023_003Dz4T4pGdvYHA7k()
	{
		Position = _0023_003DzPkO7IBwkBx9t();
	}

	internal static void _0023_003DzyEl5vhuM_0024afX(ScaleBar _0023_003DzFoyG7wMbzInnR5aKuQ_003D_003D)
	{
		if (_0023_003DzFoyG7wMbzInnR5aKuQ_003D_003D._0023_003DzXIQvTdJYGC4Y == null)
		{
			if (_0023_003DzFoyG7wMbzInnR5aKuQ_003D_003D.ParentViewport != null && _0023_003DzFoyG7wMbzInnR5aKuQ_003D_003D.ParentViewport._0023_003Dz0TvaYNo_003D != null)
			{
				_0023_003DziZZfZEAkgw4HT9h4XA_003D_003D(_0023_003DzFoyG7wMbzInnR5aKuQ_003D_003D.ParentViewport._0023_003Dz0TvaYNo_003D.Font, ref _0023_003DzFoyG7wMbzInnR5aKuQ_003D_003D._0023_003DzaAQLLBXfRolO);
			}
			else
			{
				_0023_003DziZZfZEAkgw4HT9h4XA_003D_003D(System.Windows.Forms.Control.DefaultFont, ref _0023_003DzFoyG7wMbzInnR5aKuQ_003D_003D._0023_003DzaAQLLBXfRolO);
			}
		}
	}

	private static void _0023_003DziZZfZEAkgw4HT9h4XA_003D_003D(Font _0023_003DzQMi_00244nsHFihL, ref Font _0023_003Dz7t7IPa3k6ngt)
	{
		if (_0023_003Dz7t7IPa3k6ngt == null || !_0023_003Dz7t7IPa3k6ngt.Equals(_0023_003DzQMi_00244nsHFihL))
		{
			_0023_003Dz7t7IPa3k6ngt?.Dispose();
			_0023_003Dz7t7IPa3k6ngt = (Font)_0023_003DzQMi_00244nsHFihL.Clone();
		}
	}

	private bool _0023_003Dz7tZ_0024PR01p2VZ()
	{
		return Font != null;
	}

	private void _0023_003DzsF7yMRKiuC_s()
	{
		Font = _0023_003Dz0UloR3WvSVa2();
	}

	private bool _0023_003DzP3_00244p4hi20Fd()
	{
		return UnitsOverride != _0023_003DzWVEZxqzZb2Go();
	}

	internal void _0023_003DztfrIiE30_CTR()
	{
		UnitsOverride = _0023_003DzWVEZxqzZb2Go();
	}

	public static ScaleBar GetDefaultScaleBar()
	{
		return new ScaleBar();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (!_0023_003Dz3SV_00249FPfwz1J() && !_0023_003DzfFj9WQPpfkwVWmmcZQ_003D_003D() && !_0023_003Dz_sPq8Vr_ajZc6z5eBQ_003D_003D() && !_0023_003DzR7lfdPM5Ly7X() && !_0023_003Dze1UPisCj1fP_() && !_0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D() && !_0023_003DzuooydjCMSwlZPpsh1w_003D_003D() && !_0023_003Dzp4zeyTm_0024_0024XPxTZPeDQ_003D_003D() && !_0023_003DzyOS_0024WJFupR1frgS5yw_003D_003D() && !_0023_003DzQEXAd2PO3IaD7XzPuA_003D_003D() && !_0023_003DzbUxkg_0024pX8GiH())
		{
			return _0023_003Dz7tZ_0024PR01p2VZ();
		}
		return true;
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		int num = 3;
		int x = _0023_003Dzti0S0oE_003D.X - num;
		int y = ParentViewport.Size.Height - _0023_003Dzti0S0oE_003D.Y - _0023_003Dzti0S0oE_003D.Height - ((StyleMode == styleType.Double) ? num : (2 * num));
		int width = _0023_003Dzti0S0oE_003D.Width + num;
		int height = _0023_003Dzti0S0oE_003D.Height + ((StyleMode == styleType.Double) ? num : (2 * num));
		Point location = viewport.ViewportToScreen(new Point(x, y));
		Size size = new Size(width, height);
		if (StyleMode == styleType.Double)
		{
			location.Y += 7 + num;
		}
		return new Rectangle(location, size);
	}

	private void _0023_003DzshPEPAc_003D(bool _0023_003DzbWHNjOg_003D, Color _0023_003DzIlEkoHyhsfA6, Color _0023_003DzS1K1IP2VlZf9, Color _0023_003Dzlxpb_Og_003D, string _0023_003Dzls52r2I_003D, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, styleType _0023_003Dz6yfqjDtS_0024Sze, int _0023_003DzvDfwJAPnNR_0024e, int _0023_003DzlBTW6Bn7049c, double _0023_003DzdoRBD90BMBQ7, positionType _0023_003DzhEjPeMs_003D, Font _0023_003Dz6FupbG0_003D, linearUnitsType? _0023_003DzdW8_eCI_003D)
	{
		Visible = _0023_003DzbWHNjOg_003D;
		BackgroundColor1 = RenderContextUtility.ConvertColor(_0023_003DzIlEkoHyhsfA6);
		BackgroundColor2 = RenderContextUtility.ConvertColor(_0023_003DzS1K1IP2VlZf9);
		TextColor = RenderContextUtility.ConvertColor(_0023_003Dzlxpb_Og_003D);
		FormatString = _0023_003Dzls52r2I_003D;
		Lighting = _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D;
		StyleMode = _0023_003Dz6yfqjDtS_0024Sze;
		MaxNumberOfBars = _0023_003DzvDfwJAPnNR_0024e;
		BarsHeight = _0023_003DzlBTW6Bn7049c;
		MaxWidth = _0023_003DzdoRBD90BMBQ7;
		Position = _0023_003DzhEjPeMs_003D;
		Font = _0023_003Dz6FupbG0_003D;
		UnitsOverride = _0023_003DzdW8_eCI_003D;
	}

	public override void Update(IUserInterfaceElement another)
	{
		ScaleBar scaleBar = (ScaleBar)another;
		_0023_003DzshPEPAc_003D(scaleBar.Visible, RenderContextUtility.ConvertColor(scaleBar.BackgroundColor1), RenderContextUtility.ConvertColor(scaleBar.BackgroundColor2), RenderContextUtility.ConvertColor(scaleBar.TextColor), scaleBar.FormatString, scaleBar.Lighting, scaleBar.StyleMode, scaleBar.MaxNumberOfBars, scaleBar.BarsHeight, scaleBar.MaxWidth, scaleBar.Position, scaleBar.Font, scaleBar.UnitsOverride);
	}

	private void _0023_003DzXu3JDeA_003D(int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D)
	{
		_0023_003Dzti0S0oE_003D = new Rectangle(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D);
	}

	private void _0023_003DzyB7YPoE_003D(int _0023_003DzeY3BaWv4lo0i, int _0023_003DzAjBXpjSfi2LS, out int _0023_003Dz8GBMuoM_003D, out int _0023_003DzJU0R6e0_003D)
	{
		int num = _0023_003DzAjBXpjSfi2LS * _0023_003DzeY3BaWv4lo0i + 30;
		int num2 = BarsHeight + ((StyleMode == styleType.Double) ? 7 : 15);
		positionType position = Position;
		if ((position == positionType.TopLeft || position == positionType.BottomLeft) ? true : false)
		{
			_0023_003Dz8GBMuoM_003D = 10;
		}
		else
		{
			position = Position;
			if ((position == positionType.TopCenter || position == positionType.BottomCenter) ? true : false)
			{
				_0023_003Dz8GBMuoM_003D = ParentViewport.Size.Width / 2 - num / 2;
			}
			else
			{
				_0023_003Dz8GBMuoM_003D = ParentViewport.Size.Width - num - 10;
			}
		}
		position = Position;
		if ((uint)(position - 3) <= 2u)
		{
			_0023_003DzJU0R6e0_003D = 25;
		}
		else
		{
			_0023_003DzJU0R6e0_003D = ParentViewport.Size.Height - num2 - 10;
		}
		int num3 = 0;
		int num4 = 0;
		Histogram _0023_003DznPu5SKE_003D = ParentViewport._0023_003DznPu5SKE_003D;
		if (_0023_003DznPu5SKE_003D != null && _0023_003DznPu5SKE_003D.Visible && Position == positionType.BottomCenter)
		{
			Rectangle bounds = ParentViewport._0023_003DznPu5SKE_003D.GetBounds(ParentViewport);
			int num5 = ParentViewport.Size.Height - bounds.Y;
			if (Math.Abs(num5) > Math.Abs(num4))
			{
				num4 = num5;
			}
		}
		if (ParentViewport._0023_003DzXldEn8dxMaC2 != null)
		{
			ToolBar[] _0023_003DzXldEn8dxMaC = ParentViewport._0023_003DzXldEn8dxMaC2;
			foreach (ToolBar toolBar in _0023_003DzXldEn8dxMaC)
			{
				if (toolBar.Visible)
				{
					Rectangle bounds2 = toolBar.GetBounds(ParentViewport);
					int num6 = 0;
					int num7 = 0;
					if ((Position == positionType.TopLeft && toolBar.Position == ToolBar.positionType.HorizontalTopLeft) || (Position == positionType.TopCenter && toolBar.Position == ToolBar.positionType.HorizontalTopCenter) || (Position == positionType.TopRight && toolBar.Position == ToolBar.positionType.HorizontalTopRight))
					{
						num7 = -(bounds2.Y + bounds2.Height);
					}
					else if ((Position == positionType.BottomLeft && toolBar.Position == ToolBar.positionType.HorizontalBottomLeft) || (Position == positionType.BottomCenter && toolBar.Position == ToolBar.positionType.HorizontalBottomCenter) || (Position == positionType.BottomRight && toolBar.Position == ToolBar.positionType.HorizontalBottomRight))
					{
						num7 = ParentViewport.Size.Height - bounds2.Y;
					}
					else if ((Position == positionType.TopLeft && toolBar.Position == ToolBar.positionType.VerticalTopLeft) || (Position == positionType.BottomLeft && toolBar.Position == ToolBar.positionType.VerticalBottomLeft))
					{
						num6 = bounds2.X + bounds2.Width;
					}
					else if ((Position == positionType.TopRight && toolBar.Position == ToolBar.positionType.VerticalTopRight) || (Position == positionType.BottomRight && toolBar.Position == ToolBar.positionType.VerticalBottomRight))
					{
						num6 = -(ParentViewport.Size.Width - bounds2.X);
					}
					if (Math.Abs(num6) > Math.Abs(num3))
					{
						num3 = num6;
					}
					if (Math.Abs(num7) > Math.Abs(num4))
					{
						num4 = num7;
					}
				}
			}
		}
		ViewCubeIcon viewCubeIcon = ParentViewport.ViewCubeIcon;
		if (viewCubeIcon != null && viewCubeIcon.Visible)
		{
			Rectangle bounds3 = ParentViewport.ViewCubeIcon.GetBounds(ParentViewport);
			int num8 = 0;
			if ((Position == positionType.TopLeft && ParentViewport.ViewCubeIcon.Position == coordinateSystemPositionType.TopLeft) || (Position == positionType.BottomLeft && ParentViewport.ViewCubeIcon.Position == coordinateSystemPositionType.BottomLeft))
			{
				num8 = bounds3.X + bounds3.Width;
			}
			else if ((Position == positionType.TopRight && ParentViewport.ViewCubeIcon.Position == coordinateSystemPositionType.TopRight) || (Position == positionType.BottomRight && ParentViewport.ViewCubeIcon.Position == coordinateSystemPositionType.BottomRight))
			{
				num8 = -(ParentViewport.Size.Width - bounds3.X);
			}
			if (Math.Abs(num8) > Math.Abs(num3))
			{
				num3 = num8;
			}
		}
		CoordinateSystemIcon coordinateSystemIcon = ParentViewport.CoordinateSystemIcon;
		if (coordinateSystemIcon != null && coordinateSystemIcon.Visible)
		{
			Rectangle bounds4 = ParentViewport.CoordinateSystemIcon.GetBounds(ParentViewport);
			int num9 = 0;
			if ((Position == positionType.TopLeft && ParentViewport.CoordinateSystemIcon.Position == coordinateSystemPositionType.TopLeft) || (Position == positionType.BottomLeft && ParentViewport.CoordinateSystemIcon.Position == coordinateSystemPositionType.BottomLeft))
			{
				num9 = bounds4.X + bounds4.Width;
			}
			else if ((Position == positionType.TopRight && ParentViewport.CoordinateSystemIcon.Position == coordinateSystemPositionType.TopRight) || (Position == positionType.BottomRight && ParentViewport.CoordinateSystemIcon.Position == coordinateSystemPositionType.BottomRight))
			{
				num9 = -(ParentViewport.Size.Width - bounds4.X);
			}
			if (Math.Abs(num9) > Math.Abs(num3))
			{
				num3 = num9;
			}
		}
		Legend legend = ParentViewport.Legend;
		if (legend != null && legend.Visible)
		{
			Rectangle bounds5 = ParentViewport.Legend.GetBounds(ParentViewport);
			int num10 = 0;
			if ((Position == positionType.TopLeft && ParentViewport.Legend.PositionMode == Legend.positionType.TopLeft) || (Position == positionType.BottomLeft && ParentViewport.Legend.PositionMode == Legend.positionType.BottomLeft))
			{
				num10 = bounds5.X + bounds5.Width;
			}
			else if ((Position == positionType.TopRight && ParentViewport.Legend.PositionMode == Legend.positionType.TopRight) || (Position == positionType.BottomRight && ParentViewport.Legend.PositionMode == Legend.positionType.BottomRight))
			{
				num10 = -(ParentViewport.Size.Width - bounds5.X);
			}
			if (Math.Abs(num10) > Math.Abs(num3))
			{
				num3 = num10;
			}
		}
		_0023_003Dz8GBMuoM_003D += num3;
		_0023_003DzJU0R6e0_003D += num4;
		if (StyleMode == styleType.Double)
		{
			_0023_003DzJU0R6e0_003D += 7;
		}
	}

	protected override void DrawForBitmap(object drawSceneParams)
	{
		DrawSceneParams drawSceneParams2 = (DrawSceneParams)drawSceneParams;
		RenderContextBase renderContext = drawSceneParams2.RenderContext;
		Workspace workspace = (Workspace)drawSceneParams2.Workspace;
		Viewport obj = (Viewport)drawSceneParams2.Viewport;
		renderContext.ClearColor(workspace._0023_003DzU7yFFKcRyseX());
		renderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		renderContext.FrontFaceCW = false;
		renderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		obj._0023_003Dz191ozMVp28cu(renderContext, workspace._0023_003DzNwtRJ3cLTrAy(), drawSceneParams2.ZoomRect, _0023_003DzPHqp5dQ_003D: false, 0f, workspace._0023_003DzU7yFFKcRyseX(), _0023_003DzIHwNrERoZxEh: false);
		renderContext.SetState(depthStencilStateType.DepthTestLess);
		renderContext.PushBlendState();
		renderContext.SetState(blendStateType.Blend);
		_0023_003DzCr91__0024HyQlKJ(drawSceneParams2, _0023_003DzU8oXN7UFEIoq: true);
		renderContext.PopBlendState();
	}

	internal void _0023_003DzCr91__0024HyQlKJ(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzU8oXN7UFEIoq)
	{
		_0023_003DzyEl5vhuM_0024afX(this);
		IWorkspace workspace = _0023_003DzCBM7XJK4_5H_0024.Workspace;
		if (!Visible || workspace.Entities.Count == 0 || !_0023_003DzCBM7XJK4_5H_0024.IsCurrentViewport())
		{
			return;
		}
		ParentViewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		if (ParentViewport.Camera.ProjectionMode != projectionType.Perspective)
		{
			RenderContextBase renderContext = _0023_003DzCBM7XJK4_5H_0024.RenderContext;
			renderContext.PushDepthStencilState();
			renderContext.PushBlendState();
			renderContext.PushShader();
			renderContext.SetState(depthStencilStateType.DepthTestOff);
			bool lighting = renderContext.SetLighting(enable: false);
			renderContext.SetShader(shaderType.NoLights);
			workspace.ScreenToPlane(new Point(0, 0), ParentViewport.Camera.NearPlane, out var intPoint);
			workspace.ScreenToPlane(new Point(ParentViewport.Size.Width, 0), ParentViewport.Camera.NearPlane, out var intPoint2);
			double num = Point3D.Distance(intPoint, intPoint2) * ((!UnitsOverride.HasValue) ? 1.0 : Utility.GetLinearUnitsConversionFactor(workspace.CurrentBlock.Units, UnitsOverride.Value));
			double num2 = (double)ParentViewport.Size.Width / num;
			double num3 = num * MaxWidth / (double)MaxNumberOfBars;
			double num4 = Math.Pow(10.0, Math.Floor(Math.Log10(num3)) - 1.0);
			num3 = 25.0 * Math.Max(1.0, Math.Round(num3 / (25.0 * num4))) * num4;
			int num5 = (int)Math.Ceiling(num3 * num2);
			int _0023_003DzAjBXpjSfi2LS = Math.Min(MaxNumberOfBars, Math.Max(1, (int)Math.Ceiling((double)(ParentViewport.Size.Width / num5) * MaxWidth)));
			_0023_003DzyB7YPoE_003D(num5, _0023_003DzAjBXpjSfi2LS, out var _0023_003Dz8GBMuoM_003D, out var _0023_003DzJU0R6e0_003D);
			renderContext.TranslateMatrixModelView(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, 0.0);
			switch (StyleMode)
			{
			case styleType.Single:
				_0023_003DzgiPVNZEXqpjO(renderContext, _0023_003DzAjBXpjSfi2LS, num5);
				_0023_003DzRzuCrPw_003D(workspace, _0023_003DzAjBXpjSfi2LS, num5, num3, 2, (_0023_003DzKBt3fDM7lnVt)2);
				break;
			case styleType.Double:
				_0023_003DzF0hzaQN10Fq2(renderContext, _0023_003DzAjBXpjSfi2LS, num5);
				_0023_003DzRzuCrPw_003D(workspace, _0023_003DzAjBXpjSfi2LS, num5, num3, 7, (_0023_003DzKBt3fDM7lnVt)1);
				break;
			case styleType.Alternate:
				_0023_003Dzs3YojWBXXyWL(renderContext, _0023_003DzAjBXpjSfi2LS, num5);
				_0023_003DzRzuCrPw_003D(workspace, _0023_003DzAjBXpjSfi2LS, num5, num3, 2, (_0023_003DzKBt3fDM7lnVt)0);
				break;
			}
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.PopDepthStencilState();
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.PopShader();
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.PopBlendState();
			renderContext.SetLighting(lighting);
		}
	}

	protected internal void Draw(DrawSceneParams myParams)
	{
		_0023_003DzCr91__0024HyQlKJ(myParams, _0023_003DzU8oXN7UFEIoq: false);
	}

	private void _0023_003DzgiPVNZEXqpjO(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzAjBXpjSfi2LS, int _0023_003DzeY3BaWv4lo0i)
	{
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor1));
		int num = 1;
		int num2 = 2 * num;
		int num3 = _0023_003DzAjBXpjSfi2LS * _0023_003DzeY3BaWv4lo0i + num2;
		for (int i = 0; i < _0023_003DzAjBXpjSfi2LS; i++)
		{
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor((i % 2 == 0) ? BackgroundColor2 : BackgroundColor1));
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(i * _0023_003DzeY3BaWv4lo0i, 0f, _0023_003DzeY3BaWv4lo0i, BarsHeight));
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.Disabled;
		}
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor1));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(-num, 0f, num, BarsHeight));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(-num, -num, num3, num));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(_0023_003DzAjBXpjSfi2LS * _0023_003DzeY3BaWv4lo0i, 0f, num, BarsHeight));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(-num, BarsHeight, num3, num));
	}

	private void _0023_003DzF0hzaQN10Fq2(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzAjBXpjSfi2LS, int _0023_003DzeY3BaWv4lo0i)
	{
		int num = 1;
		int num2 = 2 * num;
		int num3 = _0023_003DzAjBXpjSfi2LS * _0023_003DzeY3BaWv4lo0i + num2;
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor1));
		for (int i = 0; i < _0023_003DzAjBXpjSfi2LS; i++)
		{
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor((i % 2 == 0) ? BackgroundColor1 : BackgroundColor2));
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(i * _0023_003DzeY3BaWv4lo0i, 0f, _0023_003DzeY3BaWv4lo0i, BarsHeight / 2));
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.Disabled;
		}
		for (int j = 0; j < _0023_003DzAjBXpjSfi2LS; j++)
		{
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor((j % 2 == 0) ? BackgroundColor2 : BackgroundColor1));
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(j * _0023_003DzeY3BaWv4lo0i, BarsHeight / 2, _0023_003DzeY3BaWv4lo0i, BarsHeight / 2 + 1));
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.Disabled;
		}
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor1));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(-num, -num, num3, num));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(-num, BarsHeight / 2, num3, num));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(-num, BarsHeight, num3, num));
		for (int k = 0; k <= _0023_003DzAjBXpjSfi2LS; k++)
		{
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF((k == 0) ? (-num) : (k * _0023_003DzeY3BaWv4lo0i), -7f, num, 7 + BarsHeight));
		}
	}

	private void _0023_003Dzs3YojWBXXyWL(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzAjBXpjSfi2LS, int _0023_003DzeY3BaWv4lo0i)
	{
		int num = 1;
		int num2 = 2 * num;
		int num3 = _0023_003DzAjBXpjSfi2LS * _0023_003DzeY3BaWv4lo0i + num2;
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor1));
		for (int i = 0; i < _0023_003DzAjBXpjSfi2LS; i += 2)
		{
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(i * _0023_003DzeY3BaWv4lo0i, -num, _0023_003DzeY3BaWv4lo0i + num, num));
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(i * _0023_003DzeY3BaWv4lo0i, 0f, _0023_003DzeY3BaWv4lo0i, BarsHeight / 2));
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.Disabled;
		}
		for (int j = 1; j < _0023_003DzAjBXpjSfi2LS; j += 2)
		{
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor1));
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(j * _0023_003DzeY3BaWv4lo0i, BarsHeight, _0023_003DzeY3BaWv4lo0i + num, num));
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor2));
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(j * _0023_003DzeY3BaWv4lo0i, BarsHeight / 2, _0023_003DzeY3BaWv4lo0i, BarsHeight / 2 + num));
			_0023_003DzmNZD0Zs_003D.ColorMaterialMode = colorMaterialType.Disabled;
		}
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(RenderContextUtility.ConvertColor(BackgroundColor1));
		_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(-num, BarsHeight / 2, num3, num));
		for (int k = 0; k <= _0023_003DzAjBXpjSfi2LS; k++)
		{
			_0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF((k == 0) ? (-num) : (k * _0023_003DzeY3BaWv4lo0i), -7f, num, 7 + BarsHeight));
		}
	}

	private void _0023_003DzRzuCrPw_003D(IWorkspace _0023_003DzU0f5_qE_003D, int _0023_003DzAjBXpjSfi2LS, int _0023_003DzeY3BaWv4lo0i, double _0023_003DzImhlUnsblz_0024T, int _0023_003Dz4yhQFMBGNdhX, _0023_003DzKBt3fDM7lnVt _0023_003DzhEjPeMs_003D)
	{
		Color contrastColorInverted = ParentViewport.Background.GetContrastColorInverted();
		Color textColor = (Lighting ? RenderContextUtility.ConvertColor(TextColor) : ParentViewport.Background.GetContrastColor());
		for (int i = 0; i < _0023_003DzAjBXpjSfi2LS; i++)
		{
			_0023_003DqgfRhwjE0ZLKFetZEKyoZraYpA9h5b2c49rBAwwAHI5Q_003D(out var _0023_003DzJU0R6e0_003D, out var _0023_003DzC65xNFw_003D, i, _0023_003Dz4yhQFMBGNdhX, _0023_003DzhEjPeMs_003D);
			if (!Lighting)
			{
				((Workspace)_0023_003DzU0f5_qE_003D).DrawTextOutlined(i * _0023_003DzeY3BaWv4lo0i, _0023_003DzJU0R6e0_003D, string.Format(FormatString, (double)i * _0023_003DzImhlUnsblz_0024T), Font, textColor, contrastColorInverted, 1f, _0023_003DzC65xNFw_003D);
			}
			else
			{
				((Workspace)_0023_003DzU0f5_qE_003D).DrawText(i * _0023_003DzeY3BaWv4lo0i, _0023_003DzJU0R6e0_003D, string.Format(FormatString, (double)i * _0023_003DzImhlUnsblz_0024T), Font, textColor, _0023_003DzC65xNFw_003D);
			}
		}
		using System.Drawing.Graphics _0023_003DzVC9FBdo_003D = System.Drawing.Graphics.FromHwnd(((Workspace)_0023_003DzU0f5_qE_003D)._0023_003DzZUohT3Y_003D);
		_0023_003DqgfRhwjE0ZLKFetZEKyoZraYpA9h5b2c49rBAwwAHI5Q_003D(out var _0023_003DzJU0R6e0_003D2, out var _0023_003DzC65xNFw_003D2, _0023_003DzAjBXpjSfi2LS, _0023_003Dz4yhQFMBGNdhX, _0023_003DzhEjPeMs_003D);
		_0023_003DzC65xNFw_003D2 = ((_0023_003DzC65xNFw_003D2 != ContentAlignment.BottomCenter) ? ContentAlignment.TopLeft : ContentAlignment.BottomLeft);
		_0023_003DzcDmtj8s_003D(_0023_003DzVC9FBdo_003D, _0023_003DzU0f5_qE_003D, _0023_003DzAjBXpjSfi2LS, _0023_003DzImhlUnsblz_0024T, out var _0023_003Dzi7zrVks_003D, out var _0023_003DzCsVh6ZK44iYg, out var _0023_003DzmExX2S11iFUC, out var _0023_003DzW6sZvG0DqoG);
		if (!Lighting)
		{
			((Workspace)_0023_003DzU0f5_qE_003D).DrawTextOutlined(_0023_003DzAjBXpjSfi2LS * _0023_003DzeY3BaWv4lo0i - (int)_0023_003DzmExX2S11iFUC.Width / 2, _0023_003DzJU0R6e0_003D2, _0023_003Dzi7zrVks_003D, Font, textColor, contrastColorInverted, 1f, _0023_003DzC65xNFw_003D2);
		}
		else
		{
			((Workspace)_0023_003DzU0f5_qE_003D).DrawText(_0023_003DzAjBXpjSfi2LS * _0023_003DzeY3BaWv4lo0i - (int)_0023_003DzmExX2S11iFUC.Width / 2, _0023_003DzJU0R6e0_003D2, _0023_003Dzi7zrVks_003D, ((Workspace)_0023_003DzU0f5_qE_003D).Font, textColor, _0023_003DzC65xNFw_003D2);
		}
		_0023_003DzyB7YPoE_003D(_0023_003DzeY3BaWv4lo0i, _0023_003DzAjBXpjSfi2LS, out var _0023_003Dz8GBMuoM_003D, out var _0023_003DzJU0R6e0_003D3);
		_0023_003DzXu3JDeA_003D(_0023_003Dz8GBMuoM_003D - (int)(_0023_003DzCsVh6ZK44iYg.Width / 2f), _0023_003DzJU0R6e0_003D3 - (int)_0023_003DzCsVh6ZK44iYg.Height, _0023_003DzAjBXpjSfi2LS * _0023_003DzeY3BaWv4lo0i + (int)(_0023_003DzmExX2S11iFUC.Width / 2f + _0023_003DzW6sZvG0DqoG.Width), BarsHeight + (int)(2f * _0023_003DzCsVh6ZK44iYg.Height));
	}

	private void _0023_003DzcDmtj8s_003D(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, IWorkspace _0023_003DzU0f5_qE_003D, int _0023_003DzAjBXpjSfi2LS, double _0023_003DzImhlUnsblz_0024T, out string _0023_003Dzi7zrVks_003D, out SizeF _0023_003DzCsVh6ZK44iYg, out SizeF _0023_003DzmExX2S11iFUC, out SizeF _0023_003DzW6sZvG0DqoG5)
	{
		string text = string.Format(FormatString, 0);
		string text2 = string.Format(FormatString, (double)_0023_003DzAjBXpjSfi2LS * _0023_003DzImhlUnsblz_0024T);
		string text3 = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593177) + Utility.GetUnitsAbbreviation(UnitsOverride ?? _0023_003DzU0f5_qE_003D.CurrentBlock.Units) + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621295);
		_0023_003Dzi7zrVks_003D = text2 + text3;
		_0023_003DzCsVh6ZK44iYg = _0023_003DzVC9FBdo_003D.MeasureString(text, Font);
		_0023_003DzmExX2S11iFUC = _0023_003DzVC9FBdo_003D.MeasureString(text2, Font);
		_0023_003DzW6sZvG0DqoG5 = _0023_003DzVC9FBdo_003D.MeasureString(text3, Font);
	}

	public object Clone()
	{
		return new ScaleBar(this);
	}

	private void _0023_003DqgfRhwjE0ZLKFetZEKyoZraYpA9h5b2c49rBAwwAHI5Q_003D(out int _0023_003DzJU0R6e0_003D, out ContentAlignment _0023_003DzC65xNFw_003D, int _0023_003DznRRpGN8_003D, int _0023_003DzVEavwVbBMvl2, _0023_003DzKBt3fDM7lnVt _0023_003DzKBt3fDM7lnVt)
	{
		_0023_003DzJU0R6e0_003D = -1;
		_0023_003DzC65xNFw_003D = ContentAlignment.BottomCenter;
		switch (_0023_003DzKBt3fDM7lnVt)
		{
		case (_0023_003DzKBt3fDM7lnVt)0:
			_0023_003DzJU0R6e0_003D = BarsHeight + _0023_003DzVEavwVbBMvl2;
			_0023_003DzC65xNFw_003D = ContentAlignment.BottomCenter;
			break;
		case (_0023_003DzKBt3fDM7lnVt)1:
			_0023_003DzJU0R6e0_003D = -_0023_003DzVEavwVbBMvl2;
			_0023_003DzC65xNFw_003D = ContentAlignment.TopCenter;
			break;
		case (_0023_003DzKBt3fDM7lnVt)2:
			_0023_003DzJU0R6e0_003D = ((_0023_003DznRRpGN8_003D % 2 == 0) ? (BarsHeight + _0023_003DzVEavwVbBMvl2) : (-_0023_003DzVEavwVbBMvl2));
			_0023_003DzC65xNFw_003D = ((_0023_003DznRRpGN8_003D % 2 == 0) ? ContentAlignment.BottomCenter : ContentAlignment.TopCenter);
			break;
		}
	}
}
