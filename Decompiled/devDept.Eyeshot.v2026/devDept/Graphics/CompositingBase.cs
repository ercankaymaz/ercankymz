using System;
using System.Drawing;
using System.Linq;
using devDept.Diagnostic;
using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Graphics;

internal abstract class CompositingBase : IDisposable
{
	protected enum _0023_003DzYxAFqflazMmC
	{

	}

	protected RenderContextBase ParentRenderContext;

	protected abstract _0023_003DzYxAFqflazMmC AvailabilityMask { get; }

	protected abstract bool InitTargets(Size newSize);

	protected abstract bool InitShaders();

	protected abstract void FreeTargets();

	protected abstract void FreeShaders();

	internal bool IsAvailable()
	{
		return FlagsHelper.IsSet(ParentRenderContext.compositingAvailabilityFlags, (int)AvailabilityMask);
	}

	protected int GetDepthWriteEnableMask()
	{
		return 262144;
	}

	internal bool Init(RenderContextBase parentRenderContext, Size size)
	{
		ParentRenderContext = parentRenderContext;
		ParentRenderContext.MakeCurrent();
		if (!IsAvailable())
		{
			return false;
		}
		bool flag = InitShaders();
		bool flag2 = InitTargets(size);
		Logger.Instance.Trace(parentRenderContext.ControlData.InstanceId, GetType().ToString().Split('.').LastOrDefault() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662756) + (flag ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662708) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662726)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662690) + (flag2 ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662708) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662726)));
		bool flag3 = flag && flag2;
		FlagsHelper.SetUnset(ref ParentRenderContext.compositingAvailabilityFlags, (int)AvailabilityMask, flag3);
		return flag3;
	}

	internal abstract void DrawOnTopOfCurrentTarget(Rectangle rect, ClippingPlaneBase[] clippingPlanes);

	protected void DrawQuadForClear(Rectangle rect, ClippingPlaneBase[] clippingPlanes)
	{
		PreDrawQuad(out var prevLighting);
		ParentRenderContext.SetState(depthStencilStateType.DepthTestAlways);
		ParentRenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		Color currentWireColor = ParentRenderContext.CurrentWireColor;
		ParentRenderContext.SetColorWireframe(Color.FromArgb(0, 0, 0, 0), force: true);
		ParentRenderContext.SetShader(shaderType.NoLights);
		ParentRenderContext.DrawQuadScreenSpace(rect, clippingPlanes);
		ParentRenderContext.SetColorWireframe(currentWireColor, force: true);
		PostDrawQuad(prevLighting);
	}

	protected void DrawQuadForPostProcessing(Rectangle textureRect, RectangleF? uvRect, ClippingPlaneBase[] clippingPlanes, shaderType shader, ShaderParametersBase shaderParams, params TextureBase[] texList)
	{
		if (ParentRenderContext.IsDrawingForDepth)
		{
			return;
		}
		PreDrawQuad(out var prevLighting);
		if (!ParentRenderContext.SetShader(shader))
		{
			throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662681));
		}
		if (shaderParams != null)
		{
			ParentRenderContext.CurrentShaderTechnique.SetParameters(shaderParams);
		}
		ParentRenderContext.SetState(depthStencilStateType.DepthTestOff);
		ParentRenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		for (int i = 0; i < texList.Length; i++)
		{
			ParentRenderContext.SetTexture(texList[i], (TextureBase.textureUnitType)i);
		}
		ParentRenderContext.DrawQuadScreenSpace(textureRect, clippingPlanes, 1f, uvRect);
		for (int j = 0; j < texList.Length; j++)
		{
			if (texList[j] != null)
			{
				ParentRenderContext.CloseTexture(texList[j]);
			}
		}
		PostDrawQuad(prevLighting);
	}

	private void PreDrawQuad(out bool prevLighting)
	{
		ParentRenderContext.PushMatrices();
		ParentRenderContext.PushShader();
		ParentRenderContext.PushDepthStencilState();
		ParentRenderContext.PushRasterizerState();
		prevLighting = ParentRenderContext.SetLighting(enable: false);
	}

	private void PostDrawQuad(bool prevLighting)
	{
		ParentRenderContext.PopRasterizerState();
		ParentRenderContext.PopDepthStencilState();
		ParentRenderContext.PopMatrices();
		ParentRenderContext.PopShader();
		ParentRenderContext.SetLighting(prevLighting);
	}

	public virtual void Dispose()
	{
		FreeTargets();
		FreeShaders();
	}

	internal void ResizeTargets(Size newSize)
	{
		FreeTargets();
		InitTargets(newSize);
	}

	protected internal virtual void ResetTarget()
	{
		ParentRenderContext.RestoreFBO();
	}
}
