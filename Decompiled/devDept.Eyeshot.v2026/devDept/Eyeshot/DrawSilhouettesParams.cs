using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class DrawSilhouettesParams : DrawParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private projectionType _0023_003DzIZbAC_0024zyMu_7jBCS_0024kF9Zac_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003Dzl3iF7aS_Xkoh3HUP77VEuvI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_00245r8cGYY0l9X4SubyVRgrPw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dzzy1Gc1eiAPvDB8WRsuSXKE4_003D = 1f;

	public projectionType ProjectionMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzIZbAC_0024zyMu_7jBCS_0024kF9Zac_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzIZbAC_0024zyMu_7jBCS_0024kF9Zac_003D = value;
		}
	}

	public double[] ModelViewProj
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzl3iF7aS_Xkoh3HUP77VEuvI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzl3iF7aS_Xkoh3HUP77VEuvI_003D = value;
		}
	}

	public bool SkipBorderEdges
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_00245r8cGYY0l9X4SubyVRgrPw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_00245r8cGYY0l9X4SubyVRgrPw_003D = value;
		}
	}

	public float SilhoThickness
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzzy1Gc1eiAPvDB8WRsuSXKE4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzzy1Gc1eiAPvDB8WRsuSXKE4_003D = value;
		}
	}

	public DrawSilhouettesParams(IViewport viewport, BlockKeyedCollection blocks, projectionType projectionMode, double[] modelViewProj, float screenToWorld, ShaderParameters shaderParams = null)
		: base(viewport, blocks, shaderParams)
	{
		ProjectionMode = projectionMode;
		ModelViewProj = modelViewProj;
		base.ScreenToWorld = screenToWorld;
	}
}
