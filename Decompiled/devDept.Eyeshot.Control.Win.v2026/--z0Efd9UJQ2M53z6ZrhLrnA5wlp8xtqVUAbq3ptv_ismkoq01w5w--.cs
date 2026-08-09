using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

[ComImport]
[Guid("A22AC519-8300-48a0-BEF4-F1BE8737DBA4")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface _0023_003Dz0Efd9UJQ2M53z6ZrhLrnA5wlp8xtqVUAbq3ptv_ismkoq01w5w_003D_003D : IConnectionPointContainer
{
	_0023_003DzsO08yiG6iZOUzgTTylonQQWn9NsY_0024lwXsFLT3VABX0NVuPwBH9s0h2VddQS_0024MYCvZHoh0tMZyssz9yVuHA_003D_003D SupportedManipulations
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	float PivotPointX
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	float PivotPointY
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	float PivotRadius
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CompleteManipulation();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ProcessDown([In] uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, [In] float _0023_003Dz8GBMuoM_003D, [In] float _0023_003DzJU0R6e0_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ProcessMove([In] uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, [In] float _0023_003Dz8GBMuoM_003D, [In] float _0023_003DzJU0R6e0_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ProcessUp([In] uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, [In] float _0023_003Dz8GBMuoM_003D, [In] float _0023_003DzJU0R6e0_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ProcessDownWithTime([In] uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, [In] float _0023_003Dz8GBMuoM_003D, [In] float _0023_003DzJU0R6e0_003D, [In] int _0023_003DzasAoWFY_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ProcessMoveWithTime([In] uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, [In] float _0023_003Dz8GBMuoM_003D, [In] float _0023_003DzJU0R6e0_003D, [In] int _0023_003DzasAoWFY_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ProcessUpWithTime([In] uint _0023_003Dzvs3z7wn7xymtwndJNQpuqsQ_003D, [In] float _0023_003Dz8GBMuoM_003D, [In] float _0023_003DzJU0R6e0_003D, [In] int _0023_003DzasAoWFY_003D);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	float GetVelocityX();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	float GetVelocityY();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	float GetExpansionVelocity();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	float GetAngularVelocity();

	float MinimumScaleRotateRadius
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		set;
	}
}
