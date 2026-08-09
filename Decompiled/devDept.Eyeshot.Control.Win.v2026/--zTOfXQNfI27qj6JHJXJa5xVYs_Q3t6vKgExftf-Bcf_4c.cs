using System;
using System.Collections.Generic;
using System.Drawing;
using SharpDX.Direct3D11;
using devDept;
using devDept.Graphics;

internal sealed class _0023_003DzTOfXQNfI27qj6JHJXJa5xVYs_Q3t6vKgExftf_0024Bcf_4c : ProgDrawCompositingBase
{
	public override bool Init(RenderContextBase _0023_003DzSi_RY6HdcYCZ)
	{
		if (_0023_003DzSi_RY6HdcYCZ is D3DRenderContext)
		{
			return base.Init(_0023_003DzSi_RY6HdcYCZ);
		}
		return false;
	}

	protected override bool InitTargets()
	{
		Size controlSize = ParentRenderContext.ControlData.ControlSize;
		textures = new Dictionary<progDrawFrameBuffer, TextureBase[]>(Enum.GetValues(typeof(progDrawFrameBuffer)).Length);
		textures.Add(progDrawFrameBuffer.ActivePolygons, new TextureBase[2]
		{
			new D3DTexture2D(),
			new D3DTextureDepth()
		});
		textures.Add(progDrawFrameBuffer.ActiveWires, new TextureBase[2]
		{
			new D3DTexture2D(),
			new D3DTextureDepth()
		});
		textures.Add(progDrawFrameBuffer.FrozenPolygons, new TextureBase[2]
		{
			new D3DTexture2D(),
			new D3DTextureDepth()
		});
		textures.Add(progDrawFrameBuffer.FrozenWires, new TextureBase[2]
		{
			new D3DTexture2D(),
			new D3DTextureDepth()
		});
		for (int i = 0; i < textures.Count; i++)
		{
			textures[(progDrawFrameBuffer)i][0].AllocateMemory(ParentRenderContext, renderTarget: true, controlSize.Width, controlSize.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, repeatS: false, repeatT: false, IntPtr.Zero, multisample: false);
			textures[(progDrawFrameBuffer)i][1].AllocateMemory(ParentRenderContext, renderTarget: true, controlSize.Width, controlSize.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, repeatS: false, repeatT: false, IntPtr.Zero, multisample: false);
		}
		return true;
	}

	protected override void ClearBufferColor(progDrawFrameBuffer _0023_003Dzede4j5s_003D, Color _0023_003Dz8U9WRUs_003D)
	{
		if (textures != null)
		{
			if (!textures.TryGetValue(_0023_003Dzede4j5s_003D, out var value))
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601684));
			}
			D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
			if (!(value[0] is D3DTexture2D d3DTexture2D))
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601626));
			}
			d3DRenderContext._0023_003DzP7fhLh8_003D.ClearRenderTargetView(d3DTexture2D._0023_003Dz59osH17qGO0V, ((D3DRenderContext)ParentRenderContext)._0023_003DzlMzzj_6flRUL(_0023_003Dz8U9WRUs_003D));
		}
	}

	protected override void ClearBufferDepth(progDrawFrameBuffer _0023_003Dzede4j5s_003D)
	{
		if (textures != null)
		{
			if (!textures.TryGetValue(_0023_003Dzede4j5s_003D, out var value))
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601684));
			}
			D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
			if (!(value[1] is D3DTextureDepth d3DTextureDepth))
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598918));
			}
			d3DRenderContext._0023_003DzP7fhLh8_003D.ClearDepthStencilView(d3DTextureDepth._0023_003Dz52pY7YIbaCdt, DepthStencilClearFlags.Depth | DepthStencilClearFlags.Stencil, 1f, 0);
		}
	}

	public override void CopyBackBufferTo(progDrawFrameBuffer _0023_003Dzh2PCgGI_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D)
	{
		if (textures == null || !textures.TryGetValue(_0023_003Dzh2PCgGI_003D, out var value))
		{
			return;
		}
		D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
		if (_0023_003Dzhpb8QNg_003D && value[0] is D3DTexture2D d3DTexture2D)
		{
			using Resource source = d3DRenderContext._0023_003Dz7XlCveSvJ5fF._0023_003DzfIJXGx0_003D.Resource;
			d3DRenderContext._0023_003DzP7fhLh8_003D.CopyResource(source, d3DTexture2D._0023_003Dz_IfKSJY_003D);
		}
		if (_0023_003DzaNkZ4Os_003D && value[1] is D3DTextureDepth d3DTextureDepth)
		{
			using Resource source2 = d3DRenderContext._0023_003Dz7XlCveSvJ5fF._0023_003Dz52pY7YIbaCdt.Resource;
			d3DRenderContext._0023_003DzP7fhLh8_003D.CopyResource(source2, d3DTextureDepth._0023_003Dz_IfKSJY_003D);
		}
	}

	public override void CopyToBackBuffer(progDrawFrameBuffer _0023_003Dzy78_0024Z10_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D)
	{
		if (textures == null || !textures.TryGetValue(_0023_003Dzy78_0024Z10_003D, out var value))
		{
			return;
		}
		D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
		if (_0023_003Dzhpb8QNg_003D && value[0] is D3DTexture2D d3DTexture2D)
		{
			using Resource destination = d3DRenderContext._0023_003Dz7XlCveSvJ5fF._0023_003DzfIJXGx0_003D.Resource;
			d3DRenderContext._0023_003DzP7fhLh8_003D.CopyResource(d3DTexture2D._0023_003Dz_IfKSJY_003D, destination);
		}
		if (_0023_003DzaNkZ4Os_003D && value[1] is D3DTextureDepth d3DTextureDepth)
		{
			using Resource destination2 = d3DRenderContext._0023_003Dz7XlCveSvJ5fF._0023_003Dz52pY7YIbaCdt.Resource;
			d3DRenderContext._0023_003DzP7fhLh8_003D.CopyResource(d3DTextureDepth._0023_003Dz_IfKSJY_003D, destination2);
		}
	}

	protected override bool InitShaders()
	{
		return true;
	}

	public override void BindTarget(progDrawFrameBuffer _0023_003DzOY6IA54_003D)
	{
		if (!(textures[_0023_003DzOY6IA54_003D][0] is D3DTexture2D d3DTexture2D) || !(textures[_0023_003DzOY6IA54_003D][1] is D3DTextureDepth d3DTextureDepth) || !(d3DTexture2D.Size == d3DTextureDepth.Size))
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598976));
		}
		D3DRenderContext obj = (D3DRenderContext)ParentRenderContext;
		D3DRenderContext._0023_003DzB_00241i16ya3eUx _0023_003DzMYTzTqg_003D = new D3DRenderContext._0023_003DzB_00241i16ya3eUx(((D3DTexture2D)textures[_0023_003DzOY6IA54_003D][0])._0023_003Dz59osH17qGO0V, ((D3DTextureDepth)textures[_0023_003DzOY6IA54_003D][1])._0023_003Dz52pY7YIbaCdt);
		obj._0023_003DzElzSDDQsrPlQ();
		obj._0023_003Dzi6v0V6E_003D(_0023_003DzMYTzTqg_003D);
	}
}
