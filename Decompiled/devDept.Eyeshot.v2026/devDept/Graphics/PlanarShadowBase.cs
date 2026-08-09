using System;
using System.Diagnostics;
using System.Drawing;
using devDept.Geometry;

namespace devDept.Graphics;

public abstract class PlanarShadowBase : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase _0023_003Dzq4XG_o_0024fvsKb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureBase _0023_003DzvZfkU8QdNgbzaoYA9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0nCBWiS6XT1L;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzhLiJx2I_003D;

	protected double bestSize;

	protected double inflatedBestSize;

	protected Point2D center2D;

	protected bool hwAccPresent;

	protected bool fastEnough = true;

	public void Dispose()
	{
		if (_0023_003Dzq4XG_o_0024fvsKb != null)
		{
			_0023_003Dzq4XG_o_0024fvsKb.Dispose();
		}
		if (_0023_003DzvZfkU8QdNgbzaoYA9w_003D_003D != null)
		{
			_0023_003DzvZfkU8QdNgbzaoYA9w_003D_003D.Dispose();
		}
		_0023_003Dzq4XG_o_0024fvsKb = (_0023_003DzvZfkU8QdNgbzaoYA9w_003D_003D = null);
	}

	protected internal virtual void Draw(RenderContextBase context, double opacity, Plane shadowPlane, Transformation sceneTransform, Point3D globalMin, Point3D globalMax)
	{
		if (fastEnough && !(center2D == null) && !_0023_003Dz0nCBWiS6XT1L)
		{
			context.SetLighting(enable: false);
			context.PushShader();
			context.SetShader(shaderType.Texture2DNoLightsModulate);
			context.SetState(blendStateType.Blend);
			context.PushDepthStencilState();
			context.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLess);
			context.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
			context.SetColorWireframe(Color.FromArgb((byte)(opacity * 255.0), Color.White));
			context.SetTexture(_0023_003DzvZfkU8QdNgbzaoYA9w_003D_003D);
			_0023_003Dzoe5IaSNz0qLU(context, shadowPlane);
			context.PopDepthStencilState();
			context.SetState(blendStateType.NoBlend);
			context.PopShader();
			context.CloseTexture();
		}
	}

	private void _0023_003Dzoe5IaSNz0qLU(RenderContextBase _0023_003DzQdnFby4_003D, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		Point3D[] vertices = new Point3D[4]
		{
			_0023_003Dzrgqz890sj_0024X9.PointAt(center2D.X - inflatedBestSize / 2.0, center2D.Y - inflatedBestSize / 2.0),
			_0023_003Dzrgqz890sj_0024X9.PointAt(center2D.X + inflatedBestSize / 2.0, center2D.Y - inflatedBestSize / 2.0),
			_0023_003Dzrgqz890sj_0024X9.PointAt(center2D.X + inflatedBestSize / 2.0, center2D.Y + inflatedBestSize / 2.0),
			_0023_003Dzrgqz890sj_0024X9.PointAt(center2D.X - inflatedBestSize / 2.0, center2D.Y + inflatedBestSize / 2.0)
		};
		_0023_003DzQdnFby4_003D.DrawRichPlainQuads(texCoords: (!_0023_003DzQdnFby4_003D.IsDirect3D) ? new PointF[4]
		{
			new PointF(0f, 0f),
			new PointF(1f, 0f),
			new PointF(1f, 1f),
			new PointF(0f, 1f)
		} : new PointF[4]
		{
			new PointF(0f, 1f),
			new PointF(1f, 1f),
			new PointF(1f, 0f),
			new PointF(0f, 0f)
		}, vertices: vertices, normals: new Vector3D[4]
		{
			Vector3D.AxisZ,
			Vector3D.AxisZ,
			Vector3D.AxisZ,
			Vector3D.AxisZ
		});
	}

	protected void PreCreatePlanarShadows(RenderContextBase context)
	{
		_0023_003DzzL3lWLrKfLYi(context, IntPtr.Zero, ref _0023_003Dzq4XG_o_0024fvsKb);
		context.SetRenderTarget(_0023_003Dzq4XG_o_0024fvsKb);
		_0023_003DzhLiJx2I_003D = context.ControlData.ControlSize;
		context.ControlData.ControlSize = new Size(_0023_003Dzq4XG_o_0024fvsKb.Size.Width, _0023_003Dzq4XG_o_0024fvsKb.Size.Height);
		context.SetViewport(new int[4]
		{
			0,
			0,
			_0023_003Dzq4XG_o_0024fvsKb.Size.Width,
			_0023_003Dzq4XG_o_0024fvsKb.Size.Height
		});
	}

	protected void PostCreatePlanarShadows(RenderContextBase context, orientationType orientationMode)
	{
		_0023_003DzzL3lWLrKfLYi(context, IntPtr.Zero, ref _0023_003DzvZfkU8QdNgbzaoYA9w_003D_003D);
		context.PushDepthStencilState();
		context.SetState(depthStencilStateType.DepthTestAlways);
		context.BlurTexture(ref _0023_003Dzq4XG_o_0024fvsKb, ref _0023_003DzvZfkU8QdNgbzaoYA9w_003D_003D);
		context.PopDepthStencilState();
		context.ResetRenderTarget();
		context.ControlData.ControlSize = _0023_003DzhLiJx2I_003D;
	}

	protected void EndDraw(RenderContextBase renderContext)
	{
		renderContext.CloseTexture(force: true);
	}

	private void _0023_003DzzL3lWLrKfLYi(RenderContextBase _0023_003DzB8iS0QA_003D, IntPtr _0023_003Dz40jVuec_003D, ref TextureBase _0023_003DzqeyvB5U_003D)
	{
		if (_0023_003DzqeyvB5U_003D != null && (_0023_003DzqeyvB5U_003D.Size.Width != 256 || _0023_003DzqeyvB5U_003D.Size.Height != 256))
		{
			_0023_003DzqeyvB5U_003D.Dispose();
			_0023_003DzqeyvB5U_003D = null;
		}
		if (_0023_003DzqeyvB5U_003D == null)
		{
			_0023_003DzqeyvB5U_003D = _0023_003DzB8iS0QA_003D.CreateTexture2D();
			_0023_003DzqeyvB5U_003D.AllocateMemory(_0023_003DzB8iS0QA_003D, renderTarget: true, 256, 256, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, repeatS: false, repeatT: false, _0023_003Dz40jVuec_003D, multisample: false);
			_0023_003DzB8iS0QA_003D.CloseTexture();
		}
	}

	public double GetZPos(orientationType orientation, Transformation sceneTransform, Point3D globalMin, Point3D globalMax, double groundPlaneDistance)
	{
		if (globalMax == null || globalMin == null)
		{
			return 0.0;
		}
		if (sceneTransform != null)
		{
			Utility.GetBoundingBoxTransformed(sceneTransform, globalMin, globalMax, out globalMin, out globalMax);
		}
		return orientation switch
		{
			orientationType.UpAxisZ => globalMin.Z - (globalMax.Z - globalMin.Z) * groundPlaneDistance, 
			orientationType.UpAxisY => globalMin.Y - (globalMax.Y - globalMin.Y) * groundPlaneDistance, 
			_ => 0.0, 
		};
	}
}
