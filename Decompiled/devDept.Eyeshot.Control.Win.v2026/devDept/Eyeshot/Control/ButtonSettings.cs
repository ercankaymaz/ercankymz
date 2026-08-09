using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(ButtonSettingsConverter))]
public class ButtonSettings
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Workspace _0023_003DzU0f5_qE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzgTjCWc4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz0RtUlkY_00244bf3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzJhnylsHlav_0024n;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz_0024NuB4Z7pYm4_0024;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Button size.")]
	public int Size
	{
		get
		{
			return _0023_003DzgTjCWc4_003D;
		}
		set
		{
			if (value <= 0)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651330));
			}
			_0023_003DzgTjCWc4_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Button corner radius.")]
	public int CornerRadius
	{
		get
		{
			return _0023_003Dz0RtUlkY_00244bf3;
		}
		set
		{
			_0023_003Dz0RtUlkY_00244bf3 = value;
		}
	}

	[Description("The button highlight color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color HighlightColor
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzJhnylsHlav_0024n);
		}
		set
		{
			_0023_003DzJhnylsHlav_0024n = RenderContextUtility.ConvertColor(value);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Distance between ToolBar Buttons.")]
	public int Gap
	{
		get
		{
			return _0023_003Dz_0024NuB4Z7pYm4_0024;
		}
		set
		{
			_0023_003Dz_0024NuB4Z7pYm4_0024 = value;
		}
	}

	public ButtonSettings()
		: this(_0023_003DzmuZmjj_0024WEUbi(), _0023_003Dz8KqL1jIFXwGQ(), _0023_003DzWPqWQ0HY83ZO(), _0023_003DztG7oqeEsiGCP())
	{
	}

	public ButtonSettings(int buttonSize, int buttonCornerRadius, int gap, Color buttonHighlightColor)
	{
		Size = buttonSize;
		CornerRadius = buttonCornerRadius;
		HighlightColor = RenderContextUtility.ConvertColor(buttonHighlightColor);
		Gap = gap;
	}

	private SizeF _0023_003DztnrgTmT5sBNd()
	{
		return _0023_003DzU0f5_qE_003D?._0023_003DztnrgTmT5sBNd() ?? UtilityEx.GetScalingLevel();
	}

	internal static int _0023_003DzmuZmjj_0024WEUbi()
	{
		return 32;
	}

	internal static int _0023_003Dz8KqL1jIFXwGQ()
	{
		return 0;
	}

	internal static Color _0023_003DztG7oqeEsiGCP()
	{
		return Color.Crimson;
	}

	internal static int _0023_003DzWPqWQ0HY83ZO()
	{
		return 5;
	}

	internal bool _0023_003DzPLlSnOGZ0u5W()
	{
		return Size != _0023_003DzmuZmjj_0024WEUbi();
	}

	internal void _0023_003Dzo_c5OjY_003D()
	{
		Size = _0023_003DzmuZmjj_0024WEUbi();
	}

	internal bool _0023_003Dzvqr_TWKYyAfSMyjG_A_003D_003D()
	{
		return CornerRadius != _0023_003Dz8KqL1jIFXwGQ();
	}

	internal void _0023_003DzudAmzr3RNMwK()
	{
		CornerRadius = _0023_003Dz8KqL1jIFXwGQ();
	}

	internal bool _0023_003DztwUFLIoIz_0024k_0024()
	{
		return _0023_003DzJhnylsHlav_0024n.ToArgb() != _0023_003DztG7oqeEsiGCP().ToArgb();
	}

	internal void _0023_003Dz9ioQqruPEIL8()
	{
		HighlightColor = RenderContextUtility.ConvertColor(_0023_003DztG7oqeEsiGCP());
	}

	internal bool _0023_003DzSGGhmSU3l1XH()
	{
		return Gap != _0023_003DzWPqWQ0HY83ZO();
	}

	internal void _0023_003DzcYpPsWHQYbZl()
	{
		Gap = _0023_003DzWPqWQ0HY83ZO();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (Size == _0023_003DzmuZmjj_0024WEUbi() && CornerRadius == _0023_003Dz8KqL1jIFXwGQ() && _0023_003DzJhnylsHlav_0024n.ToArgb() == _0023_003DztG7oqeEsiGCP().ToArgb())
		{
			return Gap != _0023_003DzWPqWQ0HY83ZO();
		}
		return true;
	}
}
