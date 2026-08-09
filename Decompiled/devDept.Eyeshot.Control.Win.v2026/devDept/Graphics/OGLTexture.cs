using System;
using System.Drawing;
using System.Runtime.Serialization;
using OpenGL;
using devDept.Geometry;

namespace devDept.Graphics;

[Serializable]
public class OGLTexture : OGLTextureBase
{
	public OGLTexture()
	{
		targetMode = TargetType.Texture2D;
	}

	public OGLTexture(bool createTexObj)
	{
		targetMode = TargetType.Texture2D;
		if (createTexObj)
		{
			OglRenderContext.GenTextureName(ref Name);
		}
	}

	protected OGLTexture(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		targetMode = TargetType.Texture2D;
	}

	[CLSCompliant(false)]
	public OGLTexture(RenderContextBase context, uint width, uint height, bool depthTexture, textureFilteringFunctionType minFilterFunc = textureFilteringFunctionType.Nearest, textureFilteringFunctionType magFilterFunc = textureFilteringFunctionType.Linear)
		: this()
	{
		_0023_003Dzb2QQuBqxzOi4(context, (int)width, (int)height, minFilterFunc, magFilterFunc, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, depthTexture ? 6402 : 32856, depthTexture ? 6402 : 6408, IntPtr.Zero);
	}

	[CLSCompliant(false)]
	internal OGLTexture(RenderContextBase _0023_003DzoC62DbA_003D, uint _0023_003Dz7PIPnGI_003D, uint _0023_003DzkQAiKLA_003D, bool _0023_003DzIgi4d_002476Dtqu, bool _0023_003Dz6mcnErFZlQyn, textureFilteringFunctionType _0023_003Dz03F9zIKj_qoE = textureFilteringFunctionType.Nearest, textureFilteringFunctionType _0023_003Dzo_0024D4jVFyx0uE = textureFilteringFunctionType.Linear)
		: this(_0023_003DzoC62DbA_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003Dz03F9zIKj_qoE, _0023_003Dzo_0024D4jVFyx0uE, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, (!_0023_003DzIgi4d_002476Dtqu) ? 32856 : (_0023_003Dz6mcnErFZlQyn ? 34041 : 6402), (!_0023_003DzIgi4d_002476Dtqu) ? 6408 : (_0023_003Dz6mcnErFZlQyn ? 34041 : 6402), (!_0023_003DzIgi4d_002476Dtqu) ? 5121 : (_0023_003Dz6mcnErFZlQyn ? 34042 : 5121), IntPtr.Zero)
	{
	}

	[CLSCompliant(false)]
	internal OGLTexture(RenderContextBase _0023_003DzoC62DbA_003D, uint _0023_003Dz7PIPnGI_003D, uint _0023_003DzkQAiKLA_003D, textureFilteringFunctionType _0023_003Dz03F9zIKj_qoE, textureFilteringFunctionType _0023_003Dzo_0024D4jVFyx0uE, bool _0023_003DzMOUqauw_003D, bool _0023_003Dz07HQcxg_003D, int _0023_003DzRY_0024a8v4_003D, int _0023_003DzyTdq_VY_003D, int _0023_003DzhklmJFQ_003D, IntPtr _0023_003Dzt5jpbHs_003D)
		: this()
	{
		_0023_003Dzb2QQuBqxzOi4(_0023_003DzoC62DbA_003D, (int)_0023_003Dz7PIPnGI_003D, (int)_0023_003DzkQAiKLA_003D, _0023_003Dz03F9zIKj_qoE, _0023_003Dzo_0024D4jVFyx0uE, _0023_003DzMOUqauw_003D, _0023_003Dz07HQcxg_003D, _0023_003DzRY_0024a8v4_003D, _0023_003DzyTdq_VY_003D, _0023_003DzhklmJFQ_003D, _0023_003Dzt5jpbHs_003D);
	}

	public override void Load(RenderContextBase renderContext, byte[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		if (bitmap == null)
		{
			return;
		}
		using Bitmap _0023_003DzmPRo6QY_003D = UtilityEx.ConvertBytesToImage(bitmap);
		_0023_003DzSpXm1l_Bq4NB(renderContext, _0023_003DzmPRo6QY_003D, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY, checkPowerOfTwo, enlargeIfSizeNotSupported);
	}

	public override void Load(RenderContextBase renderContext, IDisposable[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609326));
	}

	public override void Load(RenderContextBase renderContext, Bitmap bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		if (bitmap != null)
		{
			_0023_003DzSpXm1l_Bq4NB(renderContext, bitmap, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY, checkPowerOfTwo, enlargeIfSizeNotSupported);
		}
	}

	private void _0023_003DzSpXm1l_Bq4NB(RenderContextBase _0023_003DzBU4s2EOHmCFi, Bitmap _0023_003DzmPRo6QY_003D, textureFilteringFunctionType _0023_003Dzjf2lB30tMq_Q, textureFilteringFunctionType _0023_003DzMkJ4lhG0mqmw, bool _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D, bool _0023_003DzDXSkCVA_003D, bool _0023_003DzLYY7OMQ_003D, bool _0023_003DzorHz8sxwhiTJ, bool _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D)
	{
		base.FirstPixelColor = Color.FromArgb(255, _0023_003DzmPRo6QY_003D.GetPixel(0, 0));
		base.BitmapSize = _0023_003DzmPRo6QY_003D.Size;
		OglRenderContext.GenTextureName(ref Name);
		gl.BindTexture(3553, Name);
		OglRenderContext oglRenderContext = (OglRenderContext)_0023_003DzBU4s2EOHmCFi;
		if ((_0023_003Dzjf2lB30tMq_Q == textureFilteringFunctionType.Nearest || _0023_003Dzjf2lB30tMq_Q == textureFilteringFunctionType.Linear) && (_0023_003DzMkJ4lhG0mqmw == textureFilteringFunctionType.Nearest || _0023_003DzMkJ4lhG0mqmw == textureFilteringFunctionType.Linear))
		{
			MipMapping = false;
			LoadBitmap(oglRenderContext, _0023_003DzmPRo6QY_003D, _0023_003DzorHz8sxwhiTJ, _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D);
		}
		else
		{
			if (_0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D && oglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609367) }))
			{
				int integerv = gl.GetIntegerv(34047);
				gl.TexParameteri(3553, 34046, integerv);
			}
			LoadBitmap(oglRenderContext, _0023_003DzmPRo6QY_003D, _0023_003DzorHz8sxwhiTJ);
			gl.GenerateMipmapEXT(3553);
		}
		gl.TexParameteri(3553, 10241, OGLTextureBase._0023_003DzBum_5fBFid7F(_0023_003Dzjf2lB30tMq_Q));
		gl.TexParameteri(3553, 10240, OGLTextureBase._0023_003DzBum_5fBFid7F(_0023_003DzMkJ4lhG0mqmw));
		gl.TexParameterf(3553, 10242, _0023_003DzDXSkCVA_003D ? 10497 : gl.CLAMP_TO_EDGE);
		gl.TexParameterf(3553, 10243, _0023_003DzLYY7OMQ_003D ? 10497 : gl.CLAMP_TO_EDGE);
		gl.BindTexture(3553, 0u);
	}

	public override void Unbind()
	{
		gl.BindTexture(3553, 0u);
	}

	public override void AllocateMemory(RenderContextBase context, bool renderTarget, int width, int height, textureFilteringFunctionType minFilter, textureFilteringFunctionType magFilter, bool repeatS, bool repeatT, IntPtr pixels, bool multisample)
	{
		base.AllocateMemory(context, renderTarget, width, height, minFilter, magFilter, repeatS, repeatT, pixels, multisample);
		_0023_003Dzb2QQuBqxzOi4(context, width, height, minFilter, magFilter, repeatS, repeatT, 32856, 6408, pixels);
	}

	private void _0023_003Dzb2QQuBqxzOi4(RenderContextBase _0023_003DzoC62DbA_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, textureFilteringFunctionType _0023_003DzM8_0024IAmCyT0tt, textureFilteringFunctionType _0023_003DzfM8e85npVBIi, bool _0023_003DzMOUqauw_003D, bool _0023_003Dz07HQcxg_003D, int _0023_003DzRY_0024a8v4_003D, int _0023_003DzyTdq_VY_003D, IntPtr _0023_003DzTpOjvFMsZxgg)
	{
		_0023_003Dzb2QQuBqxzOi4(_0023_003DzoC62DbA_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003DzM8_0024IAmCyT0tt, _0023_003DzfM8e85npVBIi, _0023_003DzMOUqauw_003D, _0023_003Dz07HQcxg_003D, _0023_003DzRY_0024a8v4_003D, _0023_003DzyTdq_VY_003D, 5121, _0023_003DzTpOjvFMsZxgg);
	}

	private void _0023_003Dzb2QQuBqxzOi4(RenderContextBase _0023_003DzoC62DbA_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, textureFilteringFunctionType _0023_003DzM8_0024IAmCyT0tt, textureFilteringFunctionType _0023_003DzfM8e85npVBIi, bool _0023_003DzMOUqauw_003D, bool _0023_003Dz07HQcxg_003D, int _0023_003DzRY_0024a8v4_003D, int _0023_003DzyTdq_VY_003D, int _0023_003DzhklmJFQ_003D, IntPtr _0023_003DzTpOjvFMsZxgg)
	{
		base.Size = new Size(_0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D);
		OglRenderContext.GenTextureName(ref Name);
		_0023_003DzoC62DbA_003D.SetTexture(this, textureUnitType.Base);
		gl.TexImage2D(3553, 0, _0023_003DzRY_0024a8v4_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, 0, _0023_003DzyTdq_VY_003D, _0023_003DzhklmJFQ_003D, _0023_003DzTpOjvFMsZxgg);
		gl.TexParameteri(3553, 10241, OGLTextureBase._0023_003DzBum_5fBFid7F(_0023_003DzM8_0024IAmCyT0tt));
		gl.TexParameteri(3553, 10240, OGLTextureBase._0023_003DzBum_5fBFid7F(_0023_003DzfM8e85npVBIi));
		gl.TexParameterf(3553, 10242, _0023_003DzMOUqauw_003D ? 10497 : gl.CLAMP_TO_EDGE);
		gl.TexParameterf(3553, 10243, _0023_003Dz07HQcxg_003D ? 10497 : gl.CLAMP_TO_EDGE);
		_0023_003DzoC62DbA_003D.CloseTexture();
	}

	protected override void EnableTexture(RenderContextBase renderContext, textureUnitType textureUnit)
	{
		base.EnableTexture(renderContext, textureUnit);
		renderContext.SetActiveTexture(textureUnit);
		gl.BindTexture(3553, Name);
		renderContext.SetActiveTexture(textureUnitType.Base);
	}
}
