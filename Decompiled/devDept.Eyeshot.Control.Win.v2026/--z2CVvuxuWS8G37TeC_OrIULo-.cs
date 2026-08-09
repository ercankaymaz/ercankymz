using System.Drawing;
using devDept.Graphics;

internal sealed class _0023_003Dz2CVvuxuWS8G37TeC_OrIULo_003D : D3DTexture2D, IEnvironment
{
	public _0023_003Dz2CVvuxuWS8G37TeC_OrIULo_003D(byte[] _0023_003DzpfQIlVXNQtMt)
	{
		SetImage(_0023_003DzpfQIlVXNQtMt);
	}

	public _0023_003Dz2CVvuxuWS8G37TeC_OrIULo_003D(Image _0023_003DzpfQIlVXNQtMt)
	{
		_0023_003DzCT0ooac_003D(_0023_003DzpfQIlVXNQtMt, _0023_003DzYI_0024_E9M_003D: false);
	}

	public _0023_003Dz2CVvuxuWS8G37TeC_OrIULo_003D()
	{
	}

	public bool _0023_003DzZ0Ymk8RHp4W7()
	{
		return true;
	}

	public void Enable(RenderContextBase _0023_003DzoC62DbA_003D, float _0023_003Dz2WxCUwdbWLg9KRDBVw_003D_003D)
	{
		SetTextureInternal(_0023_003DzoC62DbA_003D, textureUnitType.Environment);
	}

	public void Disable(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		_0023_003DzoC62DbA_003D.CloseTexture(this);
	}
}
