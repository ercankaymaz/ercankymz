using System;
using System.Diagnostics;
using System.Threading;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;

internal sealed class _0023_003DzUcEVokiS1LwqHRRaC0mGpnaI1oOZ68PVIQ_003D_003D : WorkUnit
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Manufacture _0023_003DzcJPqfp0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzTofgyiU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzOZsg8NQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzFSEocL44sFiL;

	public _0023_003DzUcEVokiS1LwqHRRaC0mGpnaI1oOZ68PVIQ_003D_003D(Manufacture _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D, int _0023_003DzhlCpXt8_003D, int _0023_003DzlKY_0024Jbk_003D, string _0023_003Dz_00242SchWKVAEJ_0024)
	{
		_0023_003DzcJPqfp0_003D = _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D;
		_0023_003DzTofgyiU_003D = _0023_003DzhlCpXt8_003D;
		_0023_003DzOZsg8NQ_003D = _0023_003DzlKY_0024Jbk_003D;
		_0023_003DzFSEocL44sFiL = _0023_003Dz_00242SchWKVAEJ_0024;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D, CancellationToken _0023_003DzkIE5Tx8_003D)
	{
		_0023_003DzcJPqfp0_003D.SimulationStock.Cut(_0023_003DzcJPqfp0_003D.SimulationToolpath.allVertices, _0023_003DzcJPqfp0_003D.SimulationTool, this, _0023_003DzFSEocL44sFiL, _0023_003DzTofgyiU_003D, _0023_003DzOZsg8NQ_003D, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D);
	}

	public override void WorkCompleted(object _0023_003DzxwGby4M_003D)
	{
		_0023_003DzcJPqfp0_003D.SimulationStock.Optimize(new CompileParams(_0023_003DzcJPqfp0_003D));
		_0023_003DzcJPqfp0_003D.SimulationTimeLine.enabled = true;
		_0023_003DzcJPqfp0_003D.SimulationTimeLine._0023_003DzlGvHHDocBoCZ(_0023_003DzcJPqfp0_003D.SimulationToolpath.Length());
	}
}
