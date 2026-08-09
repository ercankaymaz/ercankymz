using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Control.MultiTouch.Manipulation;

public class ManipulationCompletedEventArgs : ManipulationStartedEventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SizeF _0023_003DzI4_0024pJ_0024CK8vMhjA_u7izaxOfNYtTp935Qlw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dz_0024TDroxf2s4AszhXpbhN48Qc_0024hnzsChSxBg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzTgOa0orD7rIW_4c6g8r9AwHS3L_UxEe63A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzblCNbRv8udfpRMCLrg6ayPXxMBW_0024_0024WqUXQ_003D_003D;

	public SizeF CumulativeTranslation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzI4_0024pJ_0024CK8vMhjA_u7izaxOfNYtTp935Qlw_003D_003D;
		}
	}

	public float CumulativeScale
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_0024TDroxf2s4AszhXpbhN48Qc_0024hnzsChSxBg_003D_003D;
		}
	}

	public float CumulativeExpansion
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTgOa0orD7rIW_4c6g8r9AwHS3L_UxEe63A_003D_003D;
		}
	}

	public float CumulativeRotation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzblCNbRv8udfpRMCLrg6ayPXxMBW_0024_0024WqUXQ_003D_003D;
		}
	}

	public ManipulationCompletedEventArgs(float x, float y, float cumulativeTranslationX, float cumulativeTranslationY, float cumulativeScale, float cumulativeExpansion, float cumulativeRotation)
		: base(x, y)
	{
		_0023_003Dz0RXG3ZgGBx2W734L8m3Jvyc_003D(new SizeF(cumulativeTranslationX, cumulativeTranslationY));
		_0023_003DzI3Xu1KNbdUrNIQ9bxGVfxC0_003D(cumulativeScale);
		_0023_003Dz75g7qeHx_0024WCMskGade9OHYI_003D(cumulativeExpansion);
		_0023_003DzjVKT5SQPG5aNCe6qhox5uP8_003D(cumulativeRotation);
	}

	private void _0023_003Dz0RXG3ZgGBx2W734L8m3Jvyc_003D(SizeF _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzI4_0024pJ_0024CK8vMhjA_u7izaxOfNYtTp935Qlw_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzI3Xu1KNbdUrNIQ9bxGVfxC0_003D(float _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz_0024TDroxf2s4AszhXpbhN48Qc_0024hnzsChSxBg_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dz75g7qeHx_0024WCMskGade9OHYI_003D(float _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzTgOa0orD7rIW_4c6g8r9AwHS3L_UxEe63A_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzjVKT5SQPG5aNCe6qhox5uP8_003D(float _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzblCNbRv8udfpRMCLrg6ayPXxMBW_0024_0024WqUXQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}
}
