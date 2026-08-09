using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class OffsetOnCameraAxesParams : TraversalParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointF _0023_003Dz25jEXBfN_uldVpX3pg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointF _0023_003DzSMp3MQvDl2gpAf1MTQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointF _0023_003Dzz8LdgCFzdX0yrpurmQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointF _0023_003DzWyy35kBD_AHaHQ_0024oTg_003D_003D;

	public PointF m1
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz25jEXBfN_uldVpX3pg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz25jEXBfN_uldVpX3pg_003D_003D = value;
		}
	}

	public PointF m2
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSMp3MQvDl2gpAf1MTQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSMp3MQvDl2gpAf1MTQ_003D_003D = value;
		}
	}

	public PointF MinQ
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzz8LdgCFzdX0yrpurmQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzz8LdgCFzdX0yrpurmQ_003D_003D = value;
		}
	}

	public PointF MaxQ
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWyy35kBD_AHaHQ_0024oTg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWyy35kBD_AHaHQ_0024oTg_003D_003D = value;
		}
	}

	public OffsetOnCameraAxesParams(Transformation transform, IWorkspace workspace, PointF m1, PointF m2)
		: this(transform, (IWorkspaceInternal)workspace, m1, m2)
	{
	}

	internal OffsetOnCameraAxesParams(Transformation _0023_003Dzptomndc_003D, IWorkspaceInternal _0023_003DzImQx0os_003D, PointF _0023_003DzBlNmjoc_003D, PointF _0023_003Dz948_aeQ_003D)
		: base(_0023_003DzImQx0os_003D, _0023_003DzImQx0os_003D.GetAllBlocks(), _0023_003Dzptomndc_003D)
	{
		m1 = _0023_003DzBlNmjoc_003D;
		m2 = _0023_003Dz948_aeQ_003D;
		MinQ = new PointF(float.MinValue, float.MinValue);
		MaxQ = new PointF(float.MaxValue, float.MaxValue);
	}
}
