using System;

namespace SharpGLTF.Schema2;

internal readonly struct _MaterialTexture
{
	private readonly Func<TextureInfo> _Getter;

	private readonly Func<TextureInfo> _Using;

	public bool IsEmpty => _Getter == null;

	public TextureInfo Info => _Getter?.Invoke();

	public int TextureCoordinate => (_Getter?.Invoke()?.TextureCoordinate).GetValueOrDefault();

	public TextureTransform TextureTransform => _Getter?.Invoke()?.Transform;

	public static implicit operator _MaterialTexture(Func<bool, TextureInfo> getOrUse)
	{
		return new _MaterialTexture(getOrUse);
	}

	public _MaterialTexture(Func<TextureInfo> getter, Action initialize)
	{
		_Getter = getter;
		_Using = delegate
		{
			if (getter == null)
			{
				return (TextureInfo)null;
			}
			TextureInfo textureInfo = getter();
			if (textureInfo != null)
			{
				return textureInfo;
			}
			initialize?.Invoke();
			return getter();
		};
	}

	public _MaterialTexture(Func<bool, TextureInfo> getOrUse)
	{
		_Getter = () => getOrUse(arg: false);
		_Using = () => getOrUse(arg: true);
	}

	public TextureInfo Use()
	{
		return _Using?.Invoke();
	}
}
