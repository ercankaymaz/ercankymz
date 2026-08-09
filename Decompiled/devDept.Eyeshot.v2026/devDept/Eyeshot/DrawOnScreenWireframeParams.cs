using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class DrawOnScreenWireframeParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureMosaicBase _0023_003DzJ_00240L5fZxKkvOnVLPlbs2BLU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RenderContextBase _0023_003DzO8cg_0024eb4HkE1yowaFA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzrG2BFnvF7MXg;

	public Camera Camera
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzGyIsDk_u4amx6yBl9w_003D_003D = value;
		}
	}

	public int[] ViewFrame
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D = value;
		}
	}

	public TextureMosaicBase DigitsTexture
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJ_00240L5fZxKkvOnVLPlbs2BLU_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJ_00240L5fZxKkvOnVLPlbs2BLU_003D = value;
		}
	}

	public RenderContextBase RenderContext
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzO8cg_0024eb4HkE1yowaFA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzO8cg_0024eb4HkE1yowaFA_003D_003D = value;
		}
	}

	public double[] ModelViewProj => _0023_003DzrG2BFnvF7MXg;

	public DrawOnScreenWireframeParams(Camera camera, int[] viewFrame, TextureMosaicBase digitsTexture, Transformation additionalModelViewTransformation = null)
	{
		Camera = camera;
		ViewFrame = viewFrame;
		DigitsTexture = digitsTexture;
		_0023_003DzrG2BFnvF7MXg = camera.GetModelViewProjectionMatrix();
		if (additionalModelViewTransformation != null)
		{
			Transformation transformation = new Transformation(_0023_003DzrG2BFnvF7MXg, byRow: false);
			_0023_003DzrG2BFnvF7MXg = (transformation * additionalModelViewTransformation).MatrixAsVectorByColumn;
		}
	}
}
