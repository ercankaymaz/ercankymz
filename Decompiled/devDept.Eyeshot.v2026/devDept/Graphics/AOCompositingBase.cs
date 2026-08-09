using System;
using System.Drawing;
using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Graphics;

internal abstract class AOCompositingBase : CompositingBase
{
	public enum aoTargetType
	{
		viewPos,
		viewNrm,
		rawAo,
		filteredAo
	}

	protected IShaderTechnique PreProcess_ViewZ;

	protected IShaderTechnique PreProcess_Normal;

	protected IShaderTechnique BilateralFilterHor;

	protected IShaderTechnique BilateralFilterVert;

	protected IShaderTechnique ComputeAO;

	protected TextureBase _viewZTexture;

	protected TextureBase _normalTexture;

	protected TextureBase _aoRawTexture;

	protected TextureBase _aoFilteredTexture;

	protected AoShaderParameters _aoParams;

	protected readonly bool _halfRes;

	protected static Color ClearColor => Color.Empty;

	protected override _0023_003DzYxAFqflazMmC AvailabilityMask => (_0023_003DzYxAFqflazMmC)4;

	public AOCompositingBase(bool halfRes)
	{
		_halfRes = halfRes;
	}

	protected override void FreeTargets()
	{
		_viewZTexture?.Dispose();
		_viewZTexture = null;
		_normalTexture?.Dispose();
		_normalTexture = null;
		_aoRawTexture?.Dispose();
		_aoRawTexture = null;
		_aoFilteredTexture?.Dispose();
		_aoFilteredTexture = null;
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
		RemoveShaderFromContext(shaderType.ViewZFromDepth);
		RemoveShaderFromContext(shaderType.ComputeSsao);
		RemoveShaderFromContext(shaderType.BilateralHor);
		RemoveShaderFromContext(shaderType.BilateralVert);
		RemoveShaderFromContext(shaderType.NormalFromZ);
		PreProcess_ViewZ?.Dispose();
		PreProcess_Normal?.Dispose();
		ComputeAO?.Dispose();
		BilateralFilterHor?.Dispose();
		BilateralFilterVert?.Dispose();
	}

	internal override void DrawOnTopOfCurrentTarget(Rectangle viewportRect, ClippingPlaneBase[] clippingPlanes)
	{
		RectangleF value = viewportRect;
		float num = 1f / (float)ParentRenderContext.ControlData.ControlSize.Width;
		float num2 = 1f / (float)ParentRenderContext.ControlData.ControlSize.Height;
		value.X *= num;
		value.Y *= num2;
		value.Width *= num;
		value.Height *= num2;
		Rectangle rectangle = viewportRect;
		rectangle.X /= 2;
		rectangle.Y /= 2;
		rectangle.Width /= 2;
		rectangle.Height /= 2;
		rectangle.Width += ((rectangle.X != 0) ? 1 : 0);
		rectangle.Height += ((rectangle.Y != 0) ? 1 : 0);
		if (ParentRenderContext.IsDirect3D)
		{
			rectangle.Y += (int)Math.Ceiling((double)ParentRenderContext.ControlData.ControlSize.Height / 2.0);
		}
		if (!ParentRenderContext.IsDirect3D)
		{
			_aoParams.ViewFrame = new int[4]
			{
				0,
				0,
				ParentRenderContext.DepthTextureForPostProcessing.Size.Width,
				ParentRenderContext.DepthTextureForPostProcessing.Size.Height
			};
		}
		ParentRenderContext.PushBlendState();
		ParentRenderContext.SetState(blendStateType.NoBlend);
		SetTarget(aoTargetType.viewPos);
		DrawQuadForPostProcessing(viewportRect, value, clippingPlanes, shaderType.ViewZFromDepth, _aoParams, ParentRenderContext.DepthTextureForPostProcessing, ParentRenderContext.MaskTextureForPostProcessing);
		ResetTarget();
		GenMipMapsForPositions();
		SetTarget(aoTargetType.viewNrm);
		DrawQuadForPostProcessing(viewportRect, value, clippingPlanes, shaderType.NormalFromZ, _aoParams, _viewZTexture);
		ResetTarget();
		if (_halfRes && !ParentRenderContext.IsDirect3D)
		{
			_aoParams.ViewFrame = new int[4]
			{
				0,
				0,
				ParentRenderContext.DepthTextureForPostProcessing.Size.Width / 2,
				ParentRenderContext.DepthTextureForPostProcessing.Size.Height / 2
			};
		}
		SetTarget(aoTargetType.rawAo);
		DrawQuadForPostProcessing(_halfRes ? rectangle : viewportRect, value, clippingPlanes, shaderType.ComputeSsao, _aoParams, _viewZTexture, ParentRenderContext.aoNoiseTexture);
		ResetTarget();
		SetTarget(aoTargetType.filteredAo);
		DrawQuadForPostProcessing(_halfRes ? rectangle : viewportRect, value, clippingPlanes, shaderType.BilateralHor, _aoParams, _normalTexture, _aoRawTexture);
		ResetTarget();
		SetTarget(aoTargetType.rawAo);
		DrawQuadForPostProcessing(_halfRes ? rectangle : viewportRect, value, clippingPlanes, shaderType.BilateralVert, _aoParams, _normalTexture, _aoFilteredTexture);
		ResetTarget();
		ParentRenderContext.SetState(blendStateType.Blend_SrcZero_DstSrcAlpha_Mask_RGB);
		DrawQuadForPostProcessing(viewportRect, value, clippingPlanes, shaderType.Texture2DNoLightsWithAlphaMap, null, _aoRawTexture, null, null, null, _aoRawTexture);
		ParentRenderContext.PopBlendState();
	}

	protected internal virtual void UpdateAoData(double[] projection, float depthMin, float depthMax, float zNear, float zFar, int filterRadius, float filterSharpness, float radius, float strength)
	{
		Transformation transformation = new Transformation(projection, byRow: false);
		Transformation transformation2 = new Transformation(projection, byRow: false);
		transformation2.Invert();
		float[] matrixAsVectorFloatByColumn = transformation.MatrixAsVectorFloatByColumn;
		float[] matrixAsVectorFloatByColumn2 = transformation2.MatrixAsVectorFloatByColumn;
		bool flag = matrixAsVectorFloatByColumn[15] == 0f;
		_aoParams = new AoShaderParameters(ParentRenderContext, ParentRenderContext.currViewFrame, matrixAsVectorFloatByColumn, matrixAsVectorFloatByColumn2, new Vector2D(1.0 / (double)matrixAsVectorFloatByColumn[0], 1.0 / (double)matrixAsVectorFloatByColumn[5]), new Vector2D(matrixAsVectorFloatByColumn[flag ? 8 : 12] / matrixAsVectorFloatByColumn[0], matrixAsVectorFloatByColumn[flag ? 9 : 13] / matrixAsVectorFloatByColumn[5]), new Vector2D(zNear, zFar), new Vector2D(depthMin, depthMax), radius, filterRadius, 1f - filterSharpness, strength);
		IShaderTechnique computeAO = ComputeAO;
		IShaderTechnique preProcess_ViewZ = PreProcess_ViewZ;
		IShaderTechnique preProcess_Normal = PreProcess_Normal;
		IShaderTechnique bilateralFilterHor = BilateralFilterHor;
		bool flag2 = (BilateralFilterVert.UpdatedInFrame = false);
		bool flag4 = (bilateralFilterHor.UpdatedInFrame = flag2);
		bool flag6 = (preProcess_Normal.UpdatedInFrame = flag4);
		bool updatedInFrame = (preProcess_ViewZ.UpdatedInFrame = flag6);
		computeAO.UpdatedInFrame = updatedInFrame;
	}

	protected internal abstract void SetTarget(aoTargetType target);

	protected abstract void GenMipMapsForPositions();
}
