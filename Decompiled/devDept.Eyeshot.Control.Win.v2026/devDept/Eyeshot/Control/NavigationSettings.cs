using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Geometry;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(NavigationSettingsConverter))]
public class NavigationSettings : ICloneable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Camera.navigationType _0023_003Dzm2nLfZA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static double _0023_003DzsQSuyrlC56p_0024Ah_0024OKLSVQoA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static double _0023_003Dz7_XWqAU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static double _0023_003DzfEzeW4ZcQncx;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Navigation mode.")]
	public Camera.navigationType Mode { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Mouse button and modifier key")]
	public MouseButton MouseButton { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Maximum limit of the navigation volume")]
	public Point3D Max { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Minimum limit of the navigation volume")]
	public Point3D Min { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Acceleration of the camera movement")]
	public double Acceleration { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Speed of the camera movement")]
	public double Speed { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotation speed of the camera movement")]
	public double RotationSpeed { get; set; }

	static NavigationSettings()
	{
		_0023_003Dzm2nLfZA_003D = Camera.navigationType.Examine;
		_0023_003DzsQSuyrlC56p_0024Ah_0024OKLSVQoA_003D = 8.0;
		_0023_003Dz7_XWqAU_003D = 50.0;
		_0023_003DzfEzeW4ZcQncx = 50.0;
		_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D _0023_003DzL07WkTo_003D = (_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D)0;
		object[] array = null;
		array = new object[1] { _0023_003DzL07WkTo_003D };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "M#I>Qq\"ad(", array);
	}

	public NavigationSettings()
		: this(_0023_003Dzm2nLfZA_003D, _0023_003Dz_bvIk_00244hiDEH(), _0023_003DzLTSG1DMTMi6n(), _0023_003DzzXycK2aQ0pa_0024(), _0023_003DzsQSuyrlC56p_0024Ah_0024OKLSVQoA_003D, _0023_003Dz7_XWqAU_003D, _0023_003DzfEzeW4ZcQncx)
	{
	}

	public NavigationSettings(Camera.navigationType mode, MouseButton mouseButton, Point3D min, Point3D max, double acceleration, double speed, double rotationSpeed)
	{
		Mode = mode;
		MouseButton = mouseButton;
		Min = min;
		Max = max;
		Acceleration = acceleration;
		Speed = speed;
		RotationSpeed = rotationSpeed;
	}

	private static MouseButton _0023_003Dz_bvIk_00244hiDEH()
	{
		return new MouseButton(mouseButtonsZPR.Left, modifierKeys.None);
	}

	private static Point3D _0023_003DzLTSG1DMTMi6n()
	{
		return new Point3D(-1000.0, -1000.0, -1000.0);
	}

	private static Point3D _0023_003DzzXycK2aQ0pa_0024()
	{
		return new Point3D(1000.0, 1000.0, 1000.0);
	}

	private bool _0023_003DzREo2RKpAp6dg()
	{
		return Mode != _0023_003Dzm2nLfZA_003D;
	}

	internal void _0023_003DzGWJ_0024hMt5d1zT()
	{
		Mode = _0023_003Dzm2nLfZA_003D;
	}

	private bool _0023_003DzTuElmQdRnJAJ()
	{
		return MouseButton != _0023_003Dz_bvIk_00244hiDEH();
	}

	internal void _0023_003Dzyz4tqOWweGck()
	{
		MouseButton = _0023_003Dz_bvIk_00244hiDEH();
	}

	private bool _0023_003Dz4hs_7LPj2MKK()
	{
		return Max != _0023_003DzzXycK2aQ0pa_0024();
	}

	internal void _0023_003Dz_HtcTBW8S4fZ()
	{
		Max = _0023_003DzzXycK2aQ0pa_0024();
	}

	private bool _0023_003Dzf_jaeaDk9O_s()
	{
		return Min != _0023_003DzLTSG1DMTMi6n();
	}

	internal void _0023_003Dz6F5GRlXXsvuE()
	{
		Min = _0023_003DzLTSG1DMTMi6n();
	}

	private bool _0023_003DzjjTa6S3CVVMGnsakw2z_0024evIFIqZY()
	{
		return Acceleration != _0023_003DzsQSuyrlC56p_0024Ah_0024OKLSVQoA_003D;
	}

	internal void _0023_003Dz1eGO0gICKuoI5osEfGm1VUk_003D()
	{
		Acceleration = _0023_003DzsQSuyrlC56p_0024Ah_0024OKLSVQoA_003D;
	}

	private bool _0023_003DzmtLcRawG2JcE()
	{
		return Speed != _0023_003Dz7_XWqAU_003D;
	}

	internal void _0023_003DzCe_0024mWBSfbIPE()
	{
		Speed = _0023_003Dz7_XWqAU_003D;
	}

	private bool _0023_003Dz3B2GolWXD7z2UKeH0w_003D_003D()
	{
		return RotationSpeed != _0023_003DzfEzeW4ZcQncx;
	}

	internal void _0023_003Dzcg4qtBRy8wzb()
	{
		RotationSpeed = _0023_003DzfEzeW4ZcQncx;
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(NavigationSettings _0023_003DzAbAO3f4_003D)
	{
		if (Mode == _0023_003DzAbAO3f4_003D.Mode && !(MouseButton != _0023_003DzAbAO3f4_003D.MouseButton) && Acceleration == _0023_003DzAbAO3f4_003D.Acceleration && Speed == _0023_003DzAbAO3f4_003D.Speed && RotationSpeed == _0023_003DzAbAO3f4_003D.RotationSpeed && !(Min != _0023_003DzAbAO3f4_003D.Min))
		{
			return Max != _0023_003DzAbAO3f4_003D.Max;
		}
		return true;
	}

	public virtual object Clone()
	{
		return new NavigationSettings(Mode, MouseButton, Min, Max, Acceleration, Speed, RotationSpeed);
	}

	internal bool _0023_003DzAC5kXfU_003D(_0023_003Dz3yTehjY_1ZV5QPm48sNaXRgcW8e5 _0023_003DzxIgINtc_003D, _0023_003DzoFrj_j4xP7LR4PzpMFSwbLcZc_0024wi _0023_003DzY7PoD1c_003D)
	{
		if (Mode != Camera.navigationType.Examine && _0023_003DzxIgINtc_003D._0023_003DzsZJmCwY_003D((MouseButtons)MouseButton.Button))
		{
			return _0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(MouseButton.ModifierKey);
		}
		return false;
	}
}
