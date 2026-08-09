using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace devDept.Eyeshot.Control.MultiTouch.ManipulationInterop;

[ComImport]
[ClassInterface(0)]
[Guid("597D4FB0-47FD-4aff-89B9-C6CFAE8CF08E")]
internal sealed class ManipulationProcessor : _0023_003Dz0Efd9UJQ2M53z6ZrhLrnA5wlp8xtqVUAbq3ptv_ismkoq01w5w_003D_003D, IConnectionPointContainer
{
	public virtual extern _0023_003DzsO08yiG6iZOUzgTTylonQQWn9NsY_0024lwXsFLT3VABX0NVuPwBH9s0h2VddQS_0024MYCvZHoh0tMZyssz9yVuHA_003D_003D SupportedManipulations
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	public virtual extern float PivotPointX
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	public virtual extern float PivotPointY
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	public virtual extern float PivotRadius
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	public virtual extern float MinimumScaleRotateRadius
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void CompleteManipulation();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ProcessDown(uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ProcessMove(uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ProcessUp(uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ProcessDownWithTime(uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, int _0023_003DzasAoWFY_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ProcessMoveWithTime(uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, int _0023_003DzasAoWFY_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ProcessUpWithTime(uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, int _0023_003DzasAoWFY_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern float GetVelocityX();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern float GetVelocityY();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern float GetExpansionVelocity();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern float GetAngularVelocity();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void EnumConnectionPoints(out IEnumConnectionPoints _0023_003Dzs__0024_1RnqWwVi);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void FindConnectionPoint(ref Guid _0023_003Dzatwa6Js_003D, out IConnectionPoint _0023_003DzltJXVho9SNfn);
}
