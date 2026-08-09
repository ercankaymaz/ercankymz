using System;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using OpenGL;

namespace devDept.Graphics;

public class OGLTexture3D : OGLTextureBase
{
	public OGLTexture3D()
	{
		targetMode = TargetType.Texture3D;
	}

	protected OGLTexture3D(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		targetMode = TargetType.Texture3D;
	}

	private void _0023_003DzSpXm1l_Bq4NB(RenderContextBase _0023_003DzmNZD0Zs_003D, Bitmap[] _0023_003DzmPRo6QY_003D, textureFilteringFunctionType _0023_003Dzjf2lB30tMq_Q, textureFilteringFunctionType _0023_003DzMkJ4lhG0mqmw, bool _0023_003DzDXSkCVA_003D)
	{
		base.FirstPixelColor = Color.FromArgb(255, _0023_003DzmPRo6QY_003D[0].GetPixel(0, 0));
		OglRenderContext.GenTextureName(ref Name, 32879);
		gl.BindTexture(32879, Name);
		LoadBitmap(_0023_003DzmNZD0Zs_003D, _0023_003DzmPRo6QY_003D, checkPowerOfTwo: true);
		gl.TexParameterf(32879, 10242, _0023_003DzDXSkCVA_003D ? 10497 : gl.CLAMP_TO_EDGE);
		gl.TexParameterf(32879, 10243, _0023_003DzDXSkCVA_003D ? 10497 : gl.CLAMP_TO_EDGE);
		gl.TexParameterf(32879, 32882, _0023_003DzDXSkCVA_003D ? 10497 : gl.CLAMP_TO_EDGE);
		gl.TexParameteri(32879, 10241, OGLTextureBase._0023_003DzBum_5fBFid7F(_0023_003Dzjf2lB30tMq_Q));
		gl.TexParameteri(32879, 10240, OGLTextureBase._0023_003DzBum_5fBFid7F(_0023_003DzMkJ4lhG0mqmw));
		gl.BindTexture(32879, 0u);
	}

	public override void Unbind()
	{
		gl.BindTexture(32879, 0u);
	}

	public override void AllocateMemory(RenderContextBase context, bool renderTarget, int width, int height, textureFilteringFunctionType minFilter, textureFilteringFunctionType magFilter, bool repeatS, bool repeatT, IntPtr pixels, bool multisample)
	{
		throw new NotImplementedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608696));
	}

	public override void Load(RenderContextBase renderContext, byte[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608520));
	}

	public override void Load(RenderContextBase renderContext, IDisposable[] bitmaps, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		_0023_003DzSpXm1l_Bq4NB(renderContext, bitmaps.Cast<Bitmap>().ToArray(), minFunc, magFunc, _0023_003DzDXSkCVA_003D: false);
	}

	public override void Load(RenderContextBase renderContext, Bitmap bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608520));
	}

	protected override void EnableTexture(RenderContextBase renderContext, textureUnitType textureUnit)
	{
		base.EnableTexture(renderContext, textureUnit);
		renderContext.SetActiveTexture(textureUnit);
		gl.BindTexture(32879, Name);
		renderContext.SetActiveTexture(textureUnitType.Base);
	}
}
