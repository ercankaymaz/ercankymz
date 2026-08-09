using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot;

namespace devDept.Graphics;

public abstract class ProgDrawCompositingBase
{
	protected enum compositingOperation
	{
		BlendDepthWise,
		MinDepth,
		DrawActive
	}

	public enum progDrawFrameBuffer
	{
		ActivePolygons,
		ActiveWires,
		FrozenPolygons,
		FrozenWires
	}

	protected RenderContextBase ParentRenderContext;

	protected Dictionary<compositingOperation, IShaderTechnique> Shaders;

	protected Dictionary<progDrawFrameBuffer, TextureBase[]> textures;

	protected abstract bool InitShaders();

	protected abstract bool InitTargets();

	public virtual bool Init(RenderContextBase parentRenderContext)
	{
		ParentRenderContext = parentRenderContext;
		ParentRenderContext.MakeCurrent();
		return (byte)(1u & (InitTargets() ? 1u : 0u) & (InitShaders() ? 1u : 0u)) != 0;
	}

	public virtual void DisposeTargets()
	{
		if (textures == null)
		{
			return;
		}
		foreach (KeyValuePair<progDrawFrameBuffer, TextureBase[]> texture in textures)
		{
			texture.Value[0].Dispose();
			texture.Value[1].Dispose();
		}
		textures = null;
	}

	public virtual void Dispose()
	{
		DisposeTargets();
	}

	public virtual void ResizeTargets()
	{
		DisposeTargets();
		InitTargets();
	}

	protected int GetDepthWriteEnableMask()
	{
		return 262144;
	}

	protected virtual void EnableShaderTechnique(compositingOperation compositingOperation)
	{
		shaderType shaderType2 = shaderType.None;
		shaderType2 = compositingOperation switch
		{
			compositingOperation.BlendDepthWise => shaderType.BlendFrozenOverOpaque, 
			compositingOperation.MinDepth => shaderType.MinDepth, 
			compositingOperation.DrawActive => shaderType.DrawActiveOpaque, 
			_ => throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662858) + compositingOperation.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662787)), 
		};
		ParentRenderContext.SetShader(shaderType2);
	}

	private void _0023_003DztOKVI_0024KrsD93ugo7cCyB_0024pM_003D(Size _0023_003Dz14lzA48_003D, progDrawFrameBuffer _0023_003Dzrqa8DEzQpZ1NbA_W1w_003D_003D, progDrawFrameBuffer _0023_003DzFSJpOlIzYneZZ7W8uw_003D_003D, progDrawFrameBuffer _0023_003DzD2JJMer_UQFgWLZ4Qc7Oo4Q_003D)
	{
		float[] texCoords = ((!ParentRenderContext.IsDirect3D) ? new float[8] { 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f } : new float[8] { 0f, 1f, 1f, 1f, 1f, 0f, 0f, 0f });
		ParentRenderContext.DrawQuadWithTextures(new TextureBase[5]
		{
			textures[_0023_003Dzrqa8DEzQpZ1NbA_W1w_003D_003D][1],
			textures[_0023_003DzFSJpOlIzYneZZ7W8uw_003D_003D][0],
			textures[_0023_003DzFSJpOlIzYneZZ7W8uw_003D_003D][1],
			textures[_0023_003DzD2JJMer_UQFgWLZ4Qc7Oo4Q_003D][0],
			textures[_0023_003DzD2JJMer_UQFgWLZ4Qc7Oo4Q_003D][1]
		}, texCoords, 0, new RectangleF(0f, 0f, _0023_003Dz14lzA48_003D.Width, _0023_003Dz14lzA48_003D.Height), 0f, buffered: false);
	}

	private void _0023_003Dz4UMFw0AZiZ1e(Size _0023_003Dz14lzA48_003D, progDrawFrameBuffer _0023_003DzzLvmjQQ_003D)
	{
		float[] texCoords = ((!ParentRenderContext.IsDirect3D) ? new float[8] { 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f } : new float[8] { 0f, 1f, 1f, 1f, 1f, 0f, 0f, 0f });
		ParentRenderContext.DrawQuadWithTextures(new TextureBase[2]
		{
			textures[_0023_003DzzLvmjQQ_003D][0],
			textures[_0023_003DzzLvmjQQ_003D][1]
		}, texCoords, byte.MaxValue, new RectangleF(0f, 0f, _0023_003Dz14lzA48_003D.Width, _0023_003Dz14lzA48_003D.Height), 0f, buffered: false);
	}

	private void _0023_003DzSDDvqYTzvatqPYRWuw_003D_003D(Size _0023_003Dz14lzA48_003D, progDrawFrameBuffer _0023_003DzdCqivngacb4f, progDrawFrameBuffer _0023_003Dzgdy1gQOvkjSB, progDrawFrameBuffer _0023_003Dz9dDmwyGg7pAd)
	{
		float[] texCoords = ((!ParentRenderContext.IsDirect3D) ? new float[8] { 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f } : new float[8] { 0f, 1f, 1f, 1f, 1f, 0f, 0f, 0f });
		ParentRenderContext.DrawQuadWithTextures(new TextureBase[3]
		{
			textures[_0023_003DzdCqivngacb4f][1],
			textures[_0023_003Dzgdy1gQOvkjSB][1],
			textures[_0023_003Dz9dDmwyGg7pAd][1]
		}, texCoords, 0, new RectangleF(0f, 0f, _0023_003Dz14lzA48_003D.Width, _0023_003Dz14lzA48_003D.Height), 0f, buffered: false);
	}

	public virtual void BlendDepthWise(progDrawFrameBuffer opaquePolygons, progDrawFrameBuffer opaqueWires, progDrawFrameBuffer frozenPolygons, progDrawFrameBuffer frozenWires)
	{
		ParentRenderContext.PushMatrices();
		ParentRenderContext.PushShader();
		ParentRenderContext.PushDepthStencilState();
		ParentRenderContext.PushRasterizerState();
		ParentRenderContext.PushBlendState();
		ParentRenderContext.SetState(blendStateType.Blend_SrcOne_DstOneMinusSrcAlpha);
		EnableShaderTechnique(compositingOperation.BlendDepthWise);
		Size controlSize = ParentRenderContext.ControlData.ControlSize;
		int[] currViewFrame = ParentRenderContext.currViewFrame;
		ParentRenderContext.SetMatrices(Camera.myOrtho(ParentRenderContext, 0.0, controlSize.Width, 0.0, controlSize.Height, -1.0, 1.0), null);
		ParentRenderContext.SetViewport(new int[4] { 0, 0, controlSize.Width, controlSize.Height });
		ParentRenderContext.SetState(depthStencilStateType.DepthTestOff);
		ParentRenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		_0023_003DztOKVI_0024KrsD93ugo7cCyB_0024pM_003D(controlSize, opaquePolygons, frozenPolygons, frozenWires);
		ParentRenderContext.SetViewport(currViewFrame);
		ParentRenderContext.PopBlendState();
		ParentRenderContext.PopRasterizerState();
		ParentRenderContext.PopDepthStencilState();
		ParentRenderContext.PopMatrices();
		ParentRenderContext.PopShader();
	}

	private void _0023_003Dz300Rx6cATWYF(bool _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D)
	{
		ParentRenderContext.PushMatrices();
		ParentRenderContext.PushShader();
		ParentRenderContext.PushDepthStencilState();
		ParentRenderContext.PushRasterizerState();
		ParentRenderContext.PushBlendState();
		ParentRenderContext.SetState(blendStateType.NoBlend);
		ParentRenderContext.SetState((depthStencilStateType)(_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D ? 917504 : 851968));
		ParentRenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		bool enable = false;
		if (!_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D)
		{
			enable = ParentRenderContext.EnableAlphaClip(enable: true);
		}
		EnableShaderTechnique(compositingOperation.DrawActive);
		if (!ParentRenderContext.IsDirect3D && !_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D)
		{
			ParentRenderContext.CurrentShaderTechnique.SetParameters(new ShaderParameters(ParentRenderContext)
			{
				AlphaClip = true
			});
		}
		Size controlSize = ParentRenderContext.ControlData.ControlSize;
		int[] currViewFrame = ParentRenderContext.currViewFrame;
		ParentRenderContext.SetMatrices(Camera.myOrtho(ParentRenderContext, 0.0, controlSize.Width, 0.0, controlSize.Height, -1.0, 1.0), null);
		ParentRenderContext.SetViewport(new int[4] { 0, 0, controlSize.Width, controlSize.Height });
		_0023_003Dz4UMFw0AZiZ1e(controlSize, (!_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D) ? progDrawFrameBuffer.ActiveWires : progDrawFrameBuffer.ActivePolygons);
		ParentRenderContext.SetViewport(currViewFrame);
		if (!_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D)
		{
			ParentRenderContext.EnableAlphaClip(enable);
		}
		ParentRenderContext.CurrentShaderTechnique.UpdatedInFrame = false;
		ParentRenderContext.PopBlendState();
		ParentRenderContext.PopRasterizerState();
		ParentRenderContext.PopDepthStencilState();
		ParentRenderContext.PopMatrices();
		ParentRenderContext.PopShader();
	}

	public virtual void DrawActivePolygons()
	{
		_0023_003Dz300Rx6cATWYF(_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D: true);
	}

	public virtual void DrawActiveWires()
	{
		_0023_003Dz300Rx6cATWYF(_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D: false);
	}

	public virtual void MinDepth(progDrawFrameBuffer depth1, progDrawFrameBuffer depth2, progDrawFrameBuffer depth3)
	{
		ParentRenderContext.PushMatrices();
		ParentRenderContext.PushShader();
		ParentRenderContext.PushDepthStencilState();
		EnableShaderTechnique(compositingOperation.MinDepth);
		Size controlSize = ParentRenderContext.ControlData.ControlSize;
		int[] currViewFrame = ParentRenderContext.currViewFrame;
		ParentRenderContext.SetMatrices(Camera.myOrtho(ParentRenderContext, 0.0, controlSize.Width, 0.0, controlSize.Height, -1.0, 1.0), null);
		ParentRenderContext.SetViewport(new int[4] { 0, 0, controlSize.Width, controlSize.Height });
		ParentRenderContext.SetColorMask(colorMaskFlags.None);
		ParentRenderContext.SetState(depthStencilStateType.DepthTestLess);
		_0023_003DzSDDvqYTzvatqPYRWuw_003D_003D(controlSize, depth1, depth2, depth3);
		ParentRenderContext.SetViewport(currViewFrame);
		ParentRenderContext.SetColorMask(colorMaskFlags.RGBA);
		ParentRenderContext.PopDepthStencilState();
		ParentRenderContext.PopMatrices();
		ParentRenderContext.PopShader();
	}

	protected abstract void ClearBufferColor(progDrawFrameBuffer bufferType, Color col);

	protected abstract void ClearBufferDepth(progDrawFrameBuffer bufferType);

	public virtual void ClearBuffer(progDrawFrameBuffer bufferType, Color clearColor, bool color, bool depth)
	{
		if (color)
		{
			ClearBufferColor(bufferType, clearColor);
		}
		if (depth)
		{
			ClearBufferDepth(bufferType);
		}
	}

	public virtual void ClearAllBuffers(Color clearColor, bool color = true, bool depth = true)
	{
		if (textures == null)
		{
			return;
		}
		foreach (progDrawFrameBuffer key in textures.Keys)
		{
			ClearBuffer(key, clearColor, color, depth);
		}
	}

	public virtual void RestoreBuffers()
	{
		ParentRenderContext.RestoreFBO();
	}

	public abstract void CopyBackBufferTo(progDrawFrameBuffer dest, bool color, bool depth);

	public abstract void CopyToBackBuffer(progDrawFrameBuffer source, bool color, bool depth);

	public abstract void BindTarget(progDrawFrameBuffer frameBuffer);
}
