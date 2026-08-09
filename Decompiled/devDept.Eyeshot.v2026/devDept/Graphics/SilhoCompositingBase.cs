using System;
using System.Drawing;
using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Graphics;

internal abstract class SilhoCompositingBase : CompositingBase
{
	public enum silhoTargetType
	{
		cleanDepth,
		silhoColor0,
		silhoColor1
	}

	protected IShaderTechnique CleanDepth;

	protected IShaderTechnique ComputeSilho;

	protected IShaderTechnique InflateSilho;

	protected IShaderTechnique FXAA;

	protected TextureBase _cleanDepthTexture;

	protected TextureBase _silhoColorTexture0;

	protected TextureBase _silhoColorTexture1;

	protected TextureBase _solidWhiteTexture;

	protected SilhoShaderParameters _silhoShaderParams;

	internal int SilhoWidth;

	internal Color SilhoColor;

	protected override _0023_003DzYxAFqflazMmC AvailabilityMask => (_0023_003DzYxAFqflazMmC)8;

	protected override void FreeTargets()
	{
		_cleanDepthTexture?.Dispose();
		_cleanDepthTexture = null;
		_silhoColorTexture0?.Dispose();
		_silhoColorTexture0 = null;
		_silhoColorTexture1?.Dispose();
		_silhoColorTexture1 = null;
		_solidWhiteTexture?.Dispose();
		_solidWhiteTexture = null;
	}

	private void RemoveShaderFromContext(shaderType type)
	{
		if (ParentRenderContext.Shaders != null && ParentRenderContext.Shaders.ContainsKey(type))
		{
			ParentRenderContext.Shaders.Remove(type);
		}
	}

	protected override void FreeShaders()
	{
		RemoveShaderFromContext(shaderType.CleanDepth);
		RemoveShaderFromContext(shaderType.ComputeSilho);
		RemoveShaderFromContext(shaderType.InflateSilho);
		RemoveShaderFromContext(shaderType.FXAA);
		CleanDepth?.Dispose();
		CleanDepth = null;
		ComputeSilho?.Dispose();
		ComputeSilho = null;
		InflateSilho?.Dispose();
		InflateSilho = null;
		FXAA?.Dispose();
		FXAA = null;
	}

	private void InvertSilhoTarget(ref TextureBase silhoTex, ref silhoTargetType silhoTexTarget)
	{
		switch (silhoTexTarget)
		{
		case silhoTargetType.silhoColor0:
			silhoTex = _silhoColorTexture0;
			silhoTexTarget = silhoTargetType.silhoColor1;
			break;
		case silhoTargetType.silhoColor1:
			silhoTex = _silhoColorTexture1;
			silhoTexTarget = silhoTargetType.silhoColor0;
			break;
		default:
			throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663742));
		}
	}

	internal override void DrawOnTopOfCurrentTarget(Rectangle viewportRect, ClippingPlaneBase[] clippingPlanes)
	{
		bool flag = ParentRenderContext.ControlData.IsAntiAliasingEnabled();
		ShaderParameters shaderParams = new ShaderParameters(ParentRenderContext)
		{
			AlphaClip = false,
			AlphaMap = true
		};
		if (!ParentRenderContext.IsDirect3D)
		{
			_silhoShaderParams.ViewFrame = new int[4]
			{
				0,
				0,
				ParentRenderContext.DepthTextureForPostProcessing.Size.Width,
				ParentRenderContext.DepthTextureForPostProcessing.Size.Height
			};
		}
		ParentRenderContext.PushBlendState();
		ParentRenderContext.SetState(blendStateType.NoBlend);
		SetTarget(silhoTargetType.cleanDepth);
		DrawQuadForPostProcessing(viewportRect, null, clippingPlanes, shaderType.CleanDepth, _silhoShaderParams, ParentRenderContext.DepthTextureForPostProcessing);
		ResetTarget();
		TextureBase silhoTex = _silhoColorTexture0;
		silhoTargetType silhoTexTarget = silhoTargetType.silhoColor1;
		SetTarget(silhoTexTarget);
		DrawQuadForPostProcessing(viewportRect, null, clippingPlanes, shaderType.ComputeSilho, _silhoShaderParams, _cleanDepthTexture, ParentRenderContext.MaskTextureForPostProcessing);
		ResetTarget();
		InvertSilhoTarget(ref silhoTex, ref silhoTexTarget);
		for (int i = 0; i < Math.Max(2, SilhoWidth) - 1; i++)
		{
			SetTarget(silhoTexTarget);
			DrawQuadForPostProcessing(viewportRect, null, clippingPlanes, shaderType.InflateSilho, _silhoShaderParams, silhoTex);
			ResetTarget();
			InvertSilhoTarget(ref silhoTex, ref silhoTexTarget);
		}
		if (flag)
		{
			SetTarget(silhoTexTarget);
			DrawQuadForPostProcessing(viewportRect, null, clippingPlanes, shaderType.FXAA, _silhoShaderParams, silhoTex);
			ResetTarget();
			InvertSilhoTarget(ref silhoTex, ref silhoTexTarget);
		}
		ParentRenderContext.SetState(blendStateType.Blend);
		ParentRenderContext.SetColorWireframe(SilhoColor);
		DrawQuadForPostProcessing(viewportRect, null, clippingPlanes, shaderType.Texture2DNoLightsModulateWithAlphaMap, shaderParams, _solidWhiteTexture, null, null, null, silhoTex);
		ParentRenderContext.PopBlendState();
	}

	protected internal virtual void UpdateSilhoData(int silhoWidth, Color silhoColor, double[] projection, float depthMin, float depthMax, float zNear, float zFar)
	{
		Transformation transformation = new Transformation(projection, byRow: false);
		new Transformation(projection, byRow: false).Invert();
		float[] matrixAsVectorFloatByColumn = transformation.MatrixAsVectorFloatByColumn;
		_silhoShaderParams = new SilhoShaderParameters(ParentRenderContext, ParentRenderContext.currViewFrame, matrixAsVectorFloatByColumn, new Vector2D(zNear, zFar), new Vector2D(depthMin, depthMax));
		IShaderTechnique cleanDepth = CleanDepth;
		IShaderTechnique computeSilho = ComputeSilho;
		bool flag = (FXAA.UpdatedInFrame = false);
		bool updatedInFrame = (computeSilho.UpdatedInFrame = flag);
		cleanDepth.UpdatedInFrame = updatedInFrame;
		SilhoColor = silhoColor;
		SilhoWidth = silhoWidth;
	}

	protected internal abstract void SetTarget(silhoTargetType target);
}
