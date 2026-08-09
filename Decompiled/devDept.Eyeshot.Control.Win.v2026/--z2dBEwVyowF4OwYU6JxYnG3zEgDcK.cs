using devDept.Eyeshot;
using devDept.Graphics;

internal abstract class _0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK
{
	protected readonly _0023_003DzwHzEaqHhe_ahPJ_0024dpHIcDBdbVLpdhZ9RTQ_003D_003D _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D;

	protected _0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK()
	{
		_0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D = new _0023_003DzwHzEaqHhe_ahPJ_0024dpHIcDBdbVLpdhZ9RTQ_003D_003D();
	}

	protected _0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK(bool _0023_003DzDu2ys90ONDZJ)
	{
		_0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D = new _0023_003DzwHzEaqHhe_ahPJ_0024dpHIcDBdbVLpdhZ9RTQ_003D_003D(_0023_003DzDu2ys90ONDZJ);
	}

	protected _0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK(int _0023_003DzbmfjdH77NKNt)
	{
		_0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D = new _0023_003DzwHzEaqHhe_ahPJ_0024dpHIcDBdbVLpdhZ9RTQ_003D_003D(_0023_003DzbmfjdH77NKNt);
	}

	protected _0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK(OglRenderContext _0023_003DzmNZD0Zs_003D, bool _0023_003Dzd59lTZgxTYre, LightSettings[] _0023_003DzMuApP021PUyU, realisticShadowQualityType? _0023_003DzM7ye9srZVEJJ, IBackgroundSettings _0023_003Dz2bwAPoQwFwzX)
	{
		_0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D = new _0023_003DzwHzEaqHhe_ahPJ_0024dpHIcDBdbVLpdhZ9RTQ_003D_003D(_0023_003DzmNZD0Zs_003D, _0023_003Dzd59lTZgxTYre, _0023_003DzMuApP021PUyU, _0023_003DzM7ye9srZVEJJ, _0023_003Dz2bwAPoQwFwzX);
	}

	internal _0023_003DzFzcMdiXh0E2oBkC6o7lJH9t6kgLOf8_00246pw_003D_003D _0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType _0023_003DzhklmJFQ_003D)
	{
		GLShader shader = _0023_003DzG_7_HCo_003D(_0023_003DzhklmJFQ_003D);
		return new _0023_003DzFzcMdiXh0E2oBkC6o7lJH9t6kgLOf8_00246pw_003D_003D
		{
			Shader = shader
		};
	}

	internal abstract GLShader _0023_003DzG_7_HCo_003D(shaderType _0023_003DzhklmJFQ_003D);
}
