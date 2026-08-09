using System;
using System.ComponentModel;
using devDept.Eyeshot.Control.Converters;
using devDept.Geometry;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(RotateConverter))]
public class RotateSettings : MovementSettingsBase, IRotateSettings
{
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotate by arrow keys step (in degrees).")]
	public new double KeysStep { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotation speed.")]
	public double Speed { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Indicates whether rotation around model Z axis is preferred.")]
	public rotationType RotationMode { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotation center mode.")]
	public rotationCenterType RotationCenter { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotation center point.")]
	public Point3D Center { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Rotation center visibility.")]
	public bool ShowCenter { get; set; }

	public RotateSettings(MouseButton mouseButton, double step, bool enabled, double speed, rotationType rotationMode, rotationCenterType rotationCenter)
		: this(mouseButton, step, enabled, speed, rotationMode, rotationCenter, Point3D.Origin)
	{
	}

	public RotateSettings(MouseButton mouseButton, double step, bool enabled, double speed, rotationType rotationMode, rotationCenterType rotationCenter, Point3D center)
		: this(mouseButton, step, enabled, speed, rotationMode, rotationCenter, center, _0023_003DzLwr7828VLDv4())
	{
	}

	public RotateSettings(MouseButton mouseButton, double step, bool enabled, double speed, rotationType rotationMode, rotationCenterType rotationCenter, Point3D center, bool showCenter)
		: base(mouseButton, 0, enabled)
	{
		base.MouseButton = mouseButton;
		Speed = speed;
		KeysStep = step;
		RotationMode = rotationMode;
		base.Enabled = enabled;
		RotationCenter = rotationCenter;
		Center = center;
		ShowCenter = showCenter;
	}

	public RotateSettings()
		: this(_0023_003Dz_bvIk_00244hiDEH(), _0023_003DzNpMGfoYaUexs(), MovementSettingsBase._0023_003DzlAUaJg4N2d6h(), _0023_003Dzr8ccmVFZjS39(), _0023_003Dz6jaPj5tt6_j8(), _0023_003DzmIdb09_rOp1l())
	{
	}

	public override object Clone()
	{
		return new RotateSettings(base.MouseButton, KeysStep, base.Enabled, Speed, RotationMode, RotationCenter);
	}

	private static MouseButton _0023_003Dz_bvIk_00244hiDEH()
	{
		return new MouseButton(mouseButtonsZPR.Middle, modifierKeys.None);
	}

	private static double _0023_003DzNpMGfoYaUexs()
	{
		return 10.0;
	}

	private static double _0023_003Dzr8ccmVFZjS39()
	{
		return 1.0;
	}

	private static rotationType _0023_003Dz6jaPj5tt6_j8()
	{
		return rotationType.Trackball;
	}

	private static rotationCenterType _0023_003DzmIdb09_rOp1l()
	{
		return rotationCenterType.CursorLocation;
	}

	private static Point3D _0023_003DzdfKaCwjFgZ4i()
	{
		return Point3D.Origin;
	}

	private static bool _0023_003DzLwr7828VLDv4()
	{
		return false;
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
		return KeysStep != _0023_003DzNpMGfoYaUexs();
	}

	internal override void _0023_003DzMctCFm0sc4YA()
	{
		KeysStep = _0023_003DzNpMGfoYaUexs();
	}

	internal bool _0023_003DzmtLcRawG2JcE()
	{
		return Speed != _0023_003Dzr8ccmVFZjS39();
	}

	internal void _0023_003DzCe_0024mWBSfbIPE()
	{
		Speed = _0023_003Dzr8ccmVFZjS39();
	}

	private bool _0023_003DzxI_0024SVKo5RRqRbD5pkA_003D_003D()
	{
		return RotationMode != _0023_003Dz6jaPj5tt6_j8();
	}

	internal void _0023_003DzbPyZPU75tET3()
	{
		RotationMode = _0023_003Dz6jaPj5tt6_j8();
	}

	private bool _0023_003DzskSijoaOBLwWwEqPCQ_003D_003D()
	{
		return RotationCenter != _0023_003DzmIdb09_rOp1l();
	}

	internal void _0023_003DzVedBjdmDQ2Tc()
	{
		RotationCenter = _0023_003DzmIdb09_rOp1l();
	}

	private bool _0023_003DzD_0024ejD4Y4S_0024kG()
	{
		return Center != _0023_003DzdfKaCwjFgZ4i();
	}

	internal void _0023_003DzDudL3b1unUHX()
	{
		Center = _0023_003DzdfKaCwjFgZ4i();
	}

	private bool _0023_003DzzEHawGbb31kg0yabuQ_003D_003D()
	{
		return ShowCenter != _0023_003DzLwr7828VLDv4();
	}

	internal void _0023_003Dzoipa_00247rL5bUi()
	{
		ShowCenter = _0023_003DzLwr7828VLDv4();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(RotateSettings _0023_003DzAbAO3f4_003D)
	{
		if (!(base.MouseButton != _0023_003DzAbAO3f4_003D.MouseButton) && Speed == _0023_003DzAbAO3f4_003D.Speed && KeysStep == _0023_003DzAbAO3f4_003D.KeysStep && RotationMode == _0023_003DzAbAO3f4_003D.RotationMode && base.Enabled == _0023_003DzAbAO3f4_003D.Enabled && RotationCenter == _0023_003DzAbAO3f4_003D.RotationCenter && Point3D.AreEqual(Center, _0023_003DzAbAO3f4_003D.Center, 1.0))
		{
			return ShowCenter != _0023_003DzAbAO3f4_003D.ShowCenter;
		}
		return true;
	}
}
