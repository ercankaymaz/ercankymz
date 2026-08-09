using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Diagnostic;
using devDept.Eyeshot;

namespace devDept.Graphics;

public class ControlData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DztaHBbA3e4xq7TpYry4Lt0bk_003D = true;

	public bool isHardwareAccelerated;

	public bool isFsaaAvailable;

	public antialiasingSamplesNumberType antialiasingSamples = antialiasingSamplesNumberType.x4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzH99PaNU9xwUXQTmCzq6pIPeAwIJSDvCS7ga55bA_003D;

	public bool askForAntiAliasing;

	public bool AntiAliasing;

	public IntPtr controlHandle;

	[Obsolete("With the adoption of OpenGL 3.3, a HW accelerated context is always requested. A non accelerated one is tried as a fallback. This field will be actively ignored.")]
	public bool ForceHardwareAcceleration;

	[Obsolete("With the adoption of OpenGL 3.3, a HW accelerated context is always requested. A non accelerated one is tried as a fallback. This field will be actively ignored.")]
	public bool askForHwAcc;

	public bool askForLevel9_3;

	public bool errorInPaint;

	public bool useFrameBufferObject = true;

	public Size ControlSize;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzKkaBDh5vK_0024wQaLb5iOTxME0_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzHN7_00241KHdosH7P_0024SXzw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003DzjL3UXrMg_DJx = 0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly object _0023_003DzBOqDR2I_003D = new object();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Material _0023_003Dzn2KuWQxTcJbtcL7boQ_003D_003D = DefaultMaterialShaded;

	public bool ShadersHqrMainSwitch
	{
		get
		{
			return _0023_003DztaHBbA3e4xq7TpYry4Lt0bk_003D;
		}
		set
		{
			_0023_003DztaHBbA3e4xq7TpYry4Lt0bk_003D = value;
		}
	}

	public int RealAntialiasingSamples
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzH99PaNU9xwUXQTmCzq6pIPeAwIJSDvCS7ga55bA_003D;
		}
	}

	public bool IsBestAdapterAvailable
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzKkaBDh5vK_0024wQaLb5iOTxME0_003D;
		}
	}

	public string InstanceId
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzHN7_00241KHdosH7P_0024SXzw_003D_003D;
		}
	}

	public static Material DefaultMaterialShaded => new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662894), Color.Black, Color.White, Color.White, 1f, 0.02f);

	public Material DefaultMaterial
	{
		get
		{
			return _0023_003Dzn2KuWQxTcJbtcL7boQ_003D_003D;
		}
		set
		{
			_0023_003Dzn2KuWQxTcJbtcL7boQ_003D_003D = value;
		}
	}

	public ControlData()
	{
		antialiasingSamples = antialiasingSamplesNumberType.x4;
		lock (_0023_003DzBOqDR2I_003D)
		{
			_0023_003DzBLtKinZ5MNvP(_0023_003DzjL3UXrMg_DJx++.ToString());
		}
	}

	internal void _0023_003DzS3jyMU6piOKbt8f8zFkfA_0024c8ylI5(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzH99PaNU9xwUXQTmCzq6pIPeAwIJSDvCS7ga55bA_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003Dz5LAqOjoTo3cQ_0024nm6vg_003D_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzKkaBDh5vK_0024wQaLb5iOTxME0_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzBLtKinZ5MNvP(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzHN7_00241KHdosH7P_0024SXzw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public static bool IsVirtualMachine()
	{
		return Logger.IsVirtualMachine;
	}

	public void ResetDefaultMaterial()
	{
		DefaultMaterial = DefaultMaterialShaded;
	}

	public bool IsAntiAliasingEnabled()
	{
		if (isFsaaAvailable)
		{
			return AntiAliasing;
		}
		return false;
	}
}
