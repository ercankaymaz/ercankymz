using System;
using System.Drawing;
using System.Runtime.Serialization;
using OpenGL;
using devDept.Geometry;

namespace devDept.Graphics;

public class OGLTexture1D : OGLTextureBase
{
	public OGLTexture1D()
	{
		targetMode = TargetType.Texture1D;
	}

	protected OGLTexture1D(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		targetMode = TargetType.Texture1D;
	}

	public OGLTexture1D(Color[] colorTable)
		: this()
	{
		base.Bitmap = Texture.BitmapFromColors(colorTable);
	}

	public OGLTexture1D(RenderContext renderContext, Color[] colorTable)
		: this(colorTable)
	{
		_0023_003DzSpXm1l_Bq4NB(renderContext, UtilityEx.ConvertBytesToImage(base.Bitmap), textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, _0023_003DzDXSkCVA_003D: false);
	}

	public override void Load(RenderContextBase renderContext, byte[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		if (bitmap == null)
		{
			return;
		}
		using Bitmap _0023_003DzmPRo6QY_003D = UtilityEx.ConvertBytesToImage(bitmap);
		_0023_003DzSpXm1l_Bq4NB(renderContext, _0023_003DzmPRo6QY_003D, minFunc, magFunc, repeatX);
	}

	public override void Load(RenderContextBase renderContext, IDisposable[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608655));
	}

	public override void Load(RenderContextBase renderContext, Bitmap bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		if (bitmap != null)
		{
			_0023_003DzSpXm1l_Bq4NB(renderContext, bitmap, minFunc, magFunc, repeatX);
		}
	}

	private void _0023_003DzSpXm1l_Bq4NB(RenderContextBase _0023_003DzmNZD0Zs_003D, Bitmap _0023_003DzmPRo6QY_003D, textureFilteringFunctionType _0023_003Dzjf2lB30tMq_Q, textureFilteringFunctionType _0023_003DzMkJ4lhG0mqmw, bool _0023_003DzDXSkCVA_003D)
	{
		base.FirstPixelColor = Color.FromArgb(255, _0023_003DzmPRo6QY_003D.GetPixel(0, 0));
		OglRenderContext.GenTextureName(ref Name, 3552);
		gl.BindTexture(3552, Name);
		LoadBitmap(_0023_003DzmNZD0Zs_003D, _0023_003DzmPRo6QY_003D, checkPowerOfTwo: true);
		gl.TexParameterf(3552, 10242, _0023_003DzDXSkCVA_003D ? 10497 : gl.CLAMP_TO_EDGE);
		gl.TexParameteri(3552, 10241, OGLTextureBase._0023_003DzBum_5fBFid7F(_0023_003Dzjf2lB30tMq_Q));
		gl.TexParameteri(3552, 10240, OGLTextureBase._0023_003DzBum_5fBFid7F(_0023_003DzMkJ4lhG0mqmw));
		gl.BindTexture(3552, 0u);
	}

	public override void Unbind()
	{
		gl.BindTexture(3552, 0u);
	}

	public override void AllocateMemory(RenderContextBase context, bool renderTarget, int width, int height, textureFilteringFunctionType minFilter, textureFilteringFunctionType magFilter, bool repeatS, bool repeatT, IntPtr pixels, bool multisample)
	{
		throw new NotImplementedException();
	}

	protected override void EnableTexture(RenderContextBase renderContext, textureUnitType textureUnit)
	{
		base.EnableTexture(renderContext, textureUnit);
		renderContext.SetActiveTexture(textureUnit);
		gl.BindTexture(3552, Name);
		renderContext.SetActiveTexture(textureUnitType.Base);
	}
}
