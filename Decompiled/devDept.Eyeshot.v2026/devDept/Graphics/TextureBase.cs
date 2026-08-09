using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace devDept.Graphics;

[Serializable]
public abstract class TextureBase : IDisposable, ISerializable
{
	protected enum TargetType
	{
		Texture1D,
		Texture2D,
		Texture3D
	}

	public enum textureUnitType
	{
		Base,
		Environment,
		Background,
		ShadowMap,
		AlphaTexture
	}

	protected bool MipMapping;

	protected TargetType targetMode;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzjDY1erHaZM8JtLcQ1A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dzga1ujCM_0024q4oHGCSepaMjzQY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzMNHVHn8dkMbJU0SWHg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzeRe_0024tHX7Z9jDndaiWA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private textureUnitType _0023_003Dz6hQifR2cy0Ya5e0umTHiWL8_003D;

	protected internal byte[] Bitmap
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzjDY1erHaZM8JtLcQ1A_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzjDY1erHaZM8JtLcQ1A_003D_003D = value;
		}
	}

	public Color FirstPixelColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzga1ujCM_0024q4oHGCSepaMjzQY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzga1ujCM_0024q4oHGCSepaMjzQY_003D = value;
		}
	}

	public Size Size
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMNHVHn8dkMbJU0SWHg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzMNHVHn8dkMbJU0SWHg_003D_003D = value;
		}
	}

	public Size BitmapSize
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeRe_0024tHX7Z9jDndaiWA_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzeRe_0024tHX7Z9jDndaiWA_003D_003D = value;
		}
	}

	public textureUnitType TextureUnitMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz6hQifR2cy0Ya5e0umTHiWL8_003D;
		}
	}

	protected TextureBase()
	{
	}

	protected TextureBase(SerializationInfo info, StreamingContext context)
	{
		Bitmap = (byte[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663700), typeof(byte[]));
	}

	internal void _0023_003DztXK6GnE_003D()
	{
		Bitmap = null;
	}

	public virtual void Dispose()
	{
		_0023_003DztXK6GnE_003D();
		FreeResources();
	}

	public abstract void FreeResources();

	protected internal void SetImage(byte[] image)
	{
		Bitmap = image;
		if (image == null)
		{
			FirstPixelColor = Color.Black;
		}
	}

	public void Load(RenderContextBase renderContext, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true)
	{
		Load(renderContext, Bitmap, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY);
	}

	public abstract void Load(RenderContextBase renderContext, byte[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false);

	public abstract void Load(RenderContextBase renderContext, IDisposable bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false);

	public abstract void Load(RenderContextBase renderContext, IDisposable[] bitmaps, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false);

	public abstract void UpdateRegion(RenderContextBase renderContext, byte[] bitmap, int xOffset, int yOffset);

	public static bool MakePowerOfTwoSmaller(RenderContextBase renderContext, ref int dim)
	{
		bool flag = false;
		int num = (int)Math.Pow(2.0, Math.Floor(Math.Log(dim, 2.0)));
		if (num != dim)
		{
			flag = true;
		}
		int num2 = renderContext.MaxTextureSize();
		if (num > num2)
		{
			num = num2;
			flag = true;
		}
		if (flag)
		{
			dim = num;
		}
		return flag;
	}

	public static bool MakePowerOfTwoBigger(RenderContextBase renderContext, ref int dim)
	{
		bool flag = false;
		int num = (int)Math.Pow(2.0, Math.Ceiling(Math.Log(dim, 2.0)));
		if (num != dim)
		{
			flag = true;
		}
		int num2 = renderContext.MaxTextureSize();
		if (num > num2)
		{
			num = num2;
			flag = true;
		}
		if (flag)
		{
			dim = num;
		}
		return flag;
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663700), Bitmap);
	}

	protected internal bool SetTextureInternal(RenderContextBase renderContext, textureUnitType textureUnit)
	{
		if (!IsValid())
		{
			renderContext.CloseTexture(textureUnit);
			return false;
		}
		EnableTexture(renderContext, textureUnit);
		return true;
	}

	internal void _0023_003Dz8JbATT26qCT1wrphJQ_003D_003D(textureUnitType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz6hQifR2cy0Ya5e0umTHiWL8_003D = _0023_003DzPzO_0024GUk_003D;
	}

	protected virtual void EnableTexture(RenderContextBase renderContext, textureUnitType textureUnit)
	{
		renderContext._0023_003DzzW3dSjRL0oLt[(int)textureUnit] = true;
		_0023_003Dz8JbATT26qCT1wrphJQ_003D_003D(textureUnit);
	}

	public abstract bool IsValid();

	public abstract void Unbind();

	public virtual void AllocateMemory(RenderContextBase context, bool renderTarget, int width, int height, textureFilteringFunctionType minFilter, textureFilteringFunctionType magFilter, bool repeatS, bool repeatT, IntPtr pixels, bool multisample)
	{
		Dispose();
		Size = new Size(width, height);
	}

	[Conditional("DEBUG")]
	public abstract void Check();
}
