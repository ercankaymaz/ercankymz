using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Control;

public abstract class MovementSettingsBase : ICloneable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MouseButton _0023_003DzkGobcLg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzz6Id5ZF7ST6_0024za5V8rG1U00_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Mouse button and modifier key.")]
	public MouseButton MouseButton
	{
		get
		{
			return _0023_003DzkGobcLg_003D;
		}
		set
		{
			Workspace._0023_003DzbksQw_5VXML8(value);
			_0023_003DzkGobcLg_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Movement by keys step (in pixels).")]
	public int KeysStep
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzz6Id5ZF7ST6_0024za5V8rG1U00_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzz6Id5ZF7ST6_0024za5V8rG1U00_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Indicates whether the command is enabled. For rotate command it can be used to avoid accidental rotations in 2D views.")]
	public bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D = value;
		}
	}

	static MovementSettingsBase()
	{
		_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D _0023_003DzL07WkTo_003D = (_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D)0;
		object[] array = null;
		array = new object[1] { _0023_003DzL07WkTo_003D };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "M#I>Qq\"ad(", array);
	}

	protected MovementSettingsBase(MouseButton mouseButton, int keysStep, bool enabled)
	{
		MouseButton = mouseButton;
		Enabled = enabled;
		KeysStep = keysStep;
	}

	internal abstract bool _0023_003DzTuElmQdRnJAJ();

	internal abstract void _0023_003Dzyz4tqOWweGck();

	internal abstract bool _0023_003DzsW3nXFIc0Ymq974B_0024A_003D_003D();

	internal abstract void _0023_003DzMctCFm0sc4YA();

	internal static bool _0023_003DzlAUaJg4N2d6h()
	{
		return true;
	}

	internal bool _0023_003DzcY1SwfFv_M8s()
	{
		return Enabled != _0023_003DzlAUaJg4N2d6h();
	}

	internal void _0023_003DzNSayyTKTSOmA()
	{
		Enabled = _0023_003DzlAUaJg4N2d6h();
	}

	internal void _0023_003DzO2EJpO4Eh_JL(Type[] _0023_003Dzy2y_0024Edk_003D, object[] _0023_003DzdZ6CayI_003D)
	{
		_0023_003Dzy2y_0024Edk_003D[0] = typeof(MouseButton);
		_0023_003DzdZ6CayI_003D[0] = MouseButton;
		_0023_003Dzy2y_0024Edk_003D[1] = typeof(int);
		_0023_003DzdZ6CayI_003D[1] = KeysStep;
		_0023_003Dzy2y_0024Edk_003D[2] = typeof(bool);
		_0023_003DzdZ6CayI_003D[2] = Enabled;
	}

	public abstract object Clone();
}
