using System;
using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(ZoomConverter))]
public class ZoomSettings : MovementSettingsBase
{
	private zoomStyleType mode = zoomStyleType.AtCursorLocation;

	private bool reverseMouseWheel;

	private double speed = 1.0;

	private Camera.perspectiveFitType _perspectiveFitMode;

	private bool _fitLabels;

	private int _fitMargin;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom window box color.")]
	public Color BoxColor { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom window border drawing mode.")]
	public bool BorderXOR { get; set; } = true;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom mode, affects only zoom by mouse wheel.")]
	public zoomStyleType ZoomStyle
	{
		get
		{
			return mode;
		}
		set
		{
			mode = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Revertes the zoom by mouse wheel direction.")]
	public bool ReverseMouseWheel
	{
		get
		{
			return reverseMouseWheel;
		}
		set
		{
			reverseMouseWheel = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom camera speed.")]
	public double Speed
	{
		get
		{
			return speed;
		}
		set
		{
			speed = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom fit accuracy in perspective projection mode.")]
	public Camera.perspectiveFitType PerspectiveFitMode
	{
		get
		{
			return _perspectiveFitMode;
		}
		set
		{
			_perspectiveFitMode = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom fit mode for labels.")]
	public bool FitLabels
	{
		get
		{
			return _fitLabels;
		}
		set
		{
			_fitLabels = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom fit margin.")]
	public int FitMargin
	{
		get
		{
			return _fitMargin;
		}
		set
		{
			_fitMargin = value;
		}
	}

	public ZoomSettings(MouseButton mouseButton, int keysStep, bool enabled, zoomStyleType mode, bool reverse, double speed, Color boxColor)
		: this(mouseButton, keysStep, enabled, mode, reverse, speed, boxColor, _0023_003DzMB4TL5t5DWx1I5j0nA_003D_003D())
	{
	}

	public ZoomSettings(MouseButton mouseButton, int keysStep, bool enabled, zoomStyleType mode, bool reverse, double speed, Color boxColor, Camera.perspectiveFitType perspectiveFitMode)
		: this(mouseButton, keysStep, enabled, mode, reverse, speed, boxColor, perspectiveFitMode, _0023_003DzmGqxQ_UhNeWZ())
	{
	}

	public ZoomSettings(MouseButton mouseButton, int keysStep, bool enabled, zoomStyleType mode, bool reverse, double speed, Color boxColor, Camera.perspectiveFitType perspectiveFitMode, bool fitLabels)
		: this(mouseButton, keysStep, enabled, mode, reverse, speed, boxColor, perspectiveFitMode, fitLabels, _0023_003Dz7kOOG26julPx())
	{
	}

	public ZoomSettings(MouseButton mouseButton, int keysStep, bool enabled, zoomStyleType mode, bool reverse, double speed, Color boxColor, Camera.perspectiveFitType perspectiveFitMode, bool fitLabels, int fitMargin)
		: this(mouseButton, keysStep, enabled, mode, reverse, speed, boxColor, perspectiveFitMode, fitLabels, fitMargin, _0023_003DzosdL7FB0Vcgulr2Quw_003D_003D())
	{
	}

	public ZoomSettings(MouseButton mouseButton, int keysStep, bool enabled, zoomStyleType mode, bool reverse, double speed, Color boxColor, Camera.perspectiveFitType perspectiveFitMode, bool fitLabels, int fitMargin, bool borderXOR)
		: base(mouseButton, keysStep, enabled)
	{
		base.MouseButton = mouseButton;
		this.mode = mode;
		reverseMouseWheel = reverse;
		this.speed = speed;
		BoxColor = boxColor;
		PerspectiveFitMode = perspectiveFitMode;
		FitLabels = fitLabels;
		FitMargin = fitMargin;
		BorderXOR = borderXOR;
	}

	public ZoomSettings()
		: this(_0023_003Dz_bvIk_00244hiDEH(), _0023_003DzNpMGfoYaUexs(), MovementSettingsBase._0023_003DzlAUaJg4N2d6h(), _0023_003DzuuE1quOvo7_0024_0024(), _0023_003Dz_8I0Bt20ymBHBWH0bQ_003D_003D(), _0023_003Dzr8ccmVFZjS39(), _0023_003DzasG556A9SNqs(), _0023_003DzMB4TL5t5DWx1I5j0nA_003D_003D())
	{
	}

	private static MouseButton _0023_003Dz_bvIk_00244hiDEH()
	{
		return new MouseButton(mouseButtonsZPR.Middle, modifierKeys.Shift);
	}

	private static int _0023_003DzNpMGfoYaUexs()
	{
		return 25;
	}

	private static int _0023_003Dzr8ccmVFZjS39()
	{
		return 1;
	}

	private static zoomStyleType _0023_003DzuuE1quOvo7_0024_0024()
	{
		return zoomStyleType.AtCursorLocation;
	}

	private static bool _0023_003Dz_8I0Bt20ymBHBWH0bQ_003D_003D()
	{
		return false;
	}

	private static Color _0023_003DzasG556A9SNqs()
	{
		return Color.Empty;
	}

	private static bool _0023_003DzosdL7FB0Vcgulr2Quw_003D_003D()
	{
		return true;
	}

	private static Camera.perspectiveFitType _0023_003DzMB4TL5t5DWx1I5j0nA_003D_003D()
	{
		return Camera.perspectiveFitType.Accurate;
	}

	private static bool _0023_003DzmGqxQ_UhNeWZ()
	{
		return false;
	}

	private static int _0023_003Dz7kOOG26julPx()
	{
		return 10;
	}

	internal override bool _0023_003DzTuElmQdRnJAJ()
	{
		return base.MouseButton != _0023_003Dz_bvIk_00244hiDEH();
	}

	internal override void _0023_003Dzyz4tqOWweGck()
	{
		base.MouseButton = _0023_003Dz_bvIk_00244hiDEH();
	}

	internal override bool _0023_003DzsW3nXFIc0Ymq974B_0024A_003D_003D()
	{
		return base.KeysStep != _0023_003DzNpMGfoYaUexs();
	}

	internal override void _0023_003DzMctCFm0sc4YA()
	{
		base.KeysStep = _0023_003DzNpMGfoYaUexs();
	}

	internal bool _0023_003DzmtLcRawG2JcE()
	{
		return Speed != (double)_0023_003Dzr8ccmVFZjS39();
	}

	internal void _0023_003DzCe_0024mWBSfbIPE()
	{
		Speed = _0023_003Dzr8ccmVFZjS39();
	}

	private bool _0023_003DzwqvVG6eF9MGgCkFSCw_003D_003D()
	{
		return ZoomStyle != _0023_003DzuuE1quOvo7_0024_0024();
	}

	internal void _0023_003DzAaoH_0024jifAGaM()
	{
		ZoomStyle = _0023_003DzuuE1quOvo7_0024_0024();
	}

	private bool _0023_003Dzk04QhNPEgGJTsmi2ng_003D_003D()
	{
		return ReverseMouseWheel != _0023_003Dz_8I0Bt20ymBHBWH0bQ_003D_003D();
	}

	internal void _0023_003DzTQ8YtwgIvy3hRN16_0024A_003D_003D()
	{
		ReverseMouseWheel = _0023_003Dz_8I0Bt20ymBHBWH0bQ_003D_003D();
	}

	private bool _0023_003DzfWhpEaw7_0024Xq6()
	{
		return BoxColor.ToArgb() != _0023_003DzasG556A9SNqs().ToArgb();
	}

	internal void _0023_003DzMJ2IeeEwJpji()
	{
		BoxColor = _0023_003DzasG556A9SNqs();
	}

	private bool _0023_003DzF2jhPjHYJ8WbMIUNvg_003D_003D()
	{
		return BorderXOR != _0023_003DzosdL7FB0Vcgulr2Quw_003D_003D();
	}

	internal void _0023_003DzUc9ZHjbyKUsH()
	{
		BorderXOR = _0023_003DzosdL7FB0Vcgulr2Quw_003D_003D();
	}

	private bool _0023_003Dzcwbgy4_43hc0HPUvLw_003D_003D()
	{
		return PerspectiveFitMode != _0023_003DzMB4TL5t5DWx1I5j0nA_003D_003D();
	}

	internal void _0023_003DzUutWYFoBXLunTaWXgQ_003D_003D()
	{
		PerspectiveFitMode = _0023_003DzMB4TL5t5DWx1I5j0nA_003D_003D();
	}

	private bool _0023_003Dz0ZHP1nE8H_jS65HJOg_003D_003D()
	{
		return FitLabels != _0023_003DzmGqxQ_UhNeWZ();
	}

	internal void _0023_003DzhVAmSN746eB4()
	{
		FitLabels = _0023_003DzmGqxQ_UhNeWZ();
	}

	private bool _0023_003DzMPAN2H9gqrBLfUECyw_003D_003D()
	{
		return FitMargin != _0023_003Dz7kOOG26julPx();
	}

	internal void _0023_003DzrDlSmBgOjjoV()
	{
		FitMargin = _0023_003Dz7kOOG26julPx();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(ZoomSettings _0023_003DzAbAO3f4_003D)
	{
		if (!(base.MouseButton != _0023_003DzAbAO3f4_003D.MouseButton) && ZoomStyle == _0023_003DzAbAO3f4_003D.ZoomStyle && ReverseMouseWheel == _0023_003DzAbAO3f4_003D.ReverseMouseWheel && Speed == _0023_003DzAbAO3f4_003D.Speed && base.KeysStep == _0023_003DzAbAO3f4_003D.KeysStep && !(BoxColor != _0023_003DzAbAO3f4_003D.BoxColor) && base.Enabled == _0023_003DzAbAO3f4_003D.Enabled && PerspectiveFitMode == _0023_003DzAbAO3f4_003D.PerspectiveFitMode && FitLabels == _0023_003DzAbAO3f4_003D.FitLabels && FitMargin == _0023_003DzAbAO3f4_003D.FitMargin)
		{
			return BorderXOR != _0023_003DzAbAO3f4_003D.BorderXOR;
		}
		return true;
	}

	public override object Clone()
	{
		return new ZoomSettings(base.MouseButton, base.KeysStep, base.Enabled, mode, reverseMouseWheel, speed, BoxColor, PerspectiveFitMode, FitLabels, FitMargin, BorderXOR);
	}
}
