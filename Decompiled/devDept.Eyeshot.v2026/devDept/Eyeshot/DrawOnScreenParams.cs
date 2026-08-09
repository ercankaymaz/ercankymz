using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class DrawOnScreenParams : DrawOnScreenWireframeParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private short[] _0023_003Dzqy_0024JOPJnb1Toxrn1WnVkx6w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzAvatsN3qYqwj_0024v6u8w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzmkJa3Z679wwGYws2XvM5GeY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzpv3pdmkHAPJ68XC1qzAbWbs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz_AQaFFj1_0024cYzajbJMF00Ksc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz1SBe7OQ_0024kg2pB01CyKuGkwk_003D;

	public short[] DepthValues
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzqy_0024JOPJnb1Toxrn1WnVkx6w_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzqy_0024JOPJnb1Toxrn1WnVkx6w_003D = value;
		}
	}

	public int Stride
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAvatsN3qYqwj_0024v6u8w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzAvatsN3qYqwj_0024v6u8w_003D_003D = value;
		}
	}

	public int LeftBorder
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzmkJa3Z679wwGYws2XvM5GeY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzmkJa3Z679wwGYws2XvM5GeY_003D = value;
		}
	}

	public int RightBorder
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzpv3pdmkHAPJ68XC1qzAbWbs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzpv3pdmkHAPJ68XC1qzAbWbs_003D = value;
		}
	}

	public int BottomBorder
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_AQaFFj1_0024cYzajbJMF00Ksc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_AQaFFj1_0024cYzajbJMF00Ksc_003D = value;
		}
	}

	public int TopBorder
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz1SBe7OQ_0024kg2pB01CyKuGkwk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz1SBe7OQ_0024kg2pB01CyKuGkwk_003D = value;
		}
	}

	public DrawOnScreenParams(RenderContextBase renderContext, Camera camera, short[] depthValues, int stride, int[] viewFrame, TextureMosaicBase digitsTexture, int leftBorder, int rightBorder, int bottomBorder, int topBorder, Transformation additionalModelViewTransformation = null)
		: base(camera, viewFrame, digitsTexture, additionalModelViewTransformation)
	{
		base.RenderContext = renderContext;
		DepthValues = depthValues;
		Stride = stride;
		LeftBorder = leftBorder;
		RightBorder = rightBorder;
		BottomBorder = bottomBorder;
		TopBorder = topBorder;
	}
}
