using System;
using devDept.Eyeshot;
using devDept.Graphics;

internal sealed class _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF : _0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK
{
	public _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF()
	{
	}

	public _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF(bool _0023_003DzDu2ys90ONDZJ)
		: base(_0023_003DzDu2ys90ONDZJ)
	{
	}

	public _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF(int _0023_003DzbmfjdH77NKNt)
		: base(_0023_003DzbmfjdH77NKNt)
	{
	}

	public _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF(OglRenderContext _0023_003DzmNZD0Zs_003D, LightSettings[] _0023_003DzMuApP021PUyU, realisticShadowQualityType? _0023_003DzM7ye9srZVEJJ, IBackgroundSettings _0023_003Dz2bwAPoQwFwzX)
		: base(_0023_003DzmNZD0Zs_003D, _0023_003Dzd59lTZgxTYre: false, _0023_003DzMuApP021PUyU, _0023_003DzM7ye9srZVEJJ, _0023_003Dz2bwAPoQwFwzX)
	{
	}

	internal override GLShader _0023_003DzG_7_HCo_003D(shaderType _0023_003DzhklmJFQ_003D)
	{
		switch (_0023_003DzhklmJFQ_003D)
		{
		case shaderType.NoLights:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzi9qQ9rP8X2a_0024<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003DzUj2DRcZE2UZZ: false);
		case shaderType.NoLightsThickLinesStipple:
		case shaderType.NoLightsLinesStipple:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzi9qQ9rP8X2a_0024<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003DzUj2DRcZE2UZZ: true);
		case shaderType.BlendFrozenOverOpaque:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003DzD9Wtc3Prjr1O2JpWAw_003D_003D();
		case shaderType.MinDepth:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003DzsLfpDpHskF3T();
		case shaderType.DrawActiveOpaque:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzy3OMsjAMEUVj();
		case shaderType.Texture2DNoLights:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture2DNoLightsWithAlphaMap:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: true, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture2DNoLightsModulate:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: true, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture2DNoLightsModulateWithAlphaMap:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: true, _0023_003DzxAshdwOYgM5J: true, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture2DNoLightsDecal:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: true, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture2DNoLightsDecalWithAlphaMap:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: true, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: true, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture1DNoLights:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: false, _0023_003Dzqhk6QTxx5f6U: true, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.SingleColorModulatedByIntensity:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dz11aY9UlmGCiynsLEgiqAhk_wE6v6WCmUuw_003D_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>();
		case shaderType.Standard:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dz6792C0s_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003Dzy4tqFiI_003D: false);
		case shaderType.Environment:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003Dz3Sov7XZFjL_4ArNnVF7vee1sMh4_0024>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: false, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003DzsNK9TysFzMoq: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.EnvironmentTexture2D:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003DzKa3jAfB_0024f16XqvofruEUn6rj6UsH>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: false, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003DzsNK9TysFzMoq: true, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.EnvironmentTexture2DWithAlphaMap:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003DzKa3jAfB_0024f16XqvofruEUn6rj6UsH>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: false, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003DzsNK9TysFzMoq: true, _0023_003DzxAshdwOYgM5J: true, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.Texture2D:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: true, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.Texture2DWithAlphaMap:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: true, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.Texture2DDecal:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: true, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture2DDecalWithAlphaMap:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: true, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: true, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.MultiColor:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzr_XQpKE_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: true, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzhpb8QNg_003D: true, _0023_003Dzv_0024Gzcjk_003D: false, _0023_003DzgbXz0H9Bw_O4: false, _0023_003DzxGL6Kng_003D: false);
		case shaderType.MultiColorNoLights:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzr_XQpKE_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: false, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzhpb8QNg_003D: true, _0023_003Dzv_0024Gzcjk_003D: false, _0023_003DzgbXz0H9Bw_O4: false, _0023_003DzxGL6Kng_003D: false);
		case shaderType.MultiColorNoLightsThickPointsPerVertex:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzr_XQpKE_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: false, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzhpb8QNg_003D: true, _0023_003Dzv_0024Gzcjk_003D: false, _0023_003DzgbXz0H9Bw_O4: true, _0023_003DzxGL6Kng_003D: true);
		case shaderType.MultiColorNoLightsThickLinesPerVertex:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzr_XQpKE_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: false, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzhpb8QNg_003D: true, _0023_003Dzv_0024Gzcjk_003D: false, _0023_003DzgbXz0H9Bw_O4: true, _0023_003DzxGL6Kng_003D: false);
		case shaderType.MultiColorNoLightsWithNormals:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzr_XQpKE_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: false, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzhpb8QNg_003D: true, _0023_003Dzv_0024Gzcjk_003D: true, _0023_003DzgbXz0H9Bw_O4: false, _0023_003DzxGL6Kng_003D: false);
		case shaderType.EnvironmentMulticolor:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003Dz3Sov7XZFjL_4ArNnVF7vee1sMh4_0024>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: true, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzqhk6QTxx5f6U: false, _0023_003DzsNK9TysFzMoq: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture1D:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: true, _0023_003Dzqhk6QTxx5f6U: true, _0023_003Dzy4tqFiI_003D: false, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: true, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.EnvironmentTexture1D:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003DzKa3jAfB_0024f16XqvofruEUn6rj6UsH>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: false, _0023_003Dzy4tqFiI_003D: false, _0023_003Dzqhk6QTxx5f6U: true, _0023_003DzsNK9TysFzMoq: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.StandardShadow:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dz6792C0s_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003Dzy4tqFiI_003D: true);
		case shaderType.EnvironmentShadow:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003Dz3Sov7XZFjL_4ArNnVF7vee1sMh4_0024>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: false, _0023_003Dzy4tqFiI_003D: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003DzsNK9TysFzMoq: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.EnvironmentTexture2DShadow:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003DzKa3jAfB_0024f16XqvofruEUn6rj6UsH>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: false, _0023_003Dzy4tqFiI_003D: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003DzsNK9TysFzMoq: true, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.EnvironmentTexture2DShadowWithAlphaMap:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003DzKa3jAfB_0024f16XqvofruEUn6rj6UsH>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: false, _0023_003Dzy4tqFiI_003D: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003DzsNK9TysFzMoq: true, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.Texture2DShadow:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: true, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.Texture2DShadowWithAlphaMap:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003Dzy4tqFiI_003D: true, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: true, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.MultiColorShadow:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzr_XQpKE_003D<_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d>(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: true, _0023_003Dzy4tqFiI_003D: true, _0023_003Dzhpb8QNg_003D: true, _0023_003Dzv_0024Gzcjk_003D: false, _0023_003DzgbXz0H9Bw_O4: false, _0023_003DzxGL6Kng_003D: false);
		case shaderType.EnvironmentMulticolorShadow:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003Dz3Sov7XZFjL_4ArNnVF7vee1sMh4_0024>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: true, _0023_003Dzy4tqFiI_003D: true, _0023_003Dzqhk6QTxx5f6U: false, _0023_003DzsNK9TysFzMoq: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: false);
		case shaderType.Texture1DShadow:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzjgn1DPI_003D<_0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5>(_0023_003DzMuApP021PUyU: true, _0023_003Dzqhk6QTxx5f6U: true, _0023_003Dzy4tqFiI_003D: true, _0023_003DzGPyK0Ac4hsIH: false, _0023_003DzCdP1XXBi3X9uzej37A_003D_003D: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.EnvironmentTexture1DShadow:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzd_y17lk_003D<_0023_003DzKa3jAfB_0024f16XqvofruEUn6rj6UsH>(_0023_003DzFqdVpMrNzRyJycAO2Q_003D_003D: false, _0023_003Dzy4tqFiI_003D: true, _0023_003Dzqhk6QTxx5f6U: true, _0023_003DzsNK9TysFzMoq: false, _0023_003DzxAshdwOYgM5J: false, _0023_003DzeJf7TAfDwFvBPicTUOqwXYs_003D: true);
		case shaderType.BilateralHor:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dz1hSi8_EbUySA92km_0024Q_003D_003D(_0023_003Dzu0NvygI_003D: true);
		case shaderType.BilateralVert:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dz1hSi8_EbUySA92km_0024Q_003D_003D(_0023_003Dzu0NvygI_003D: false);
		case shaderType.CleanDepth:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003DzZmq9EhFzkcPE();
		case shaderType.ComputeSilho:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003DzzeMv97kgIuwd();
		case shaderType.InflateSilho:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003DzQ6cwP6Zj8hatjIDVzqrzGAk_003D();
		case shaderType.ComputeSsao:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dz7BQykXxwaZf8();
		case shaderType.NormalFromZ:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzl4EJpuzmaElt();
		case shaderType.ViewZFromDepth:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dz12ZeYYFyg2eZ();
		case shaderType.FXAA:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003Dzg2hytAKhJNHc();
		case shaderType.BlurHor:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003DzGgCRtKt9aYru();
		case shaderType.BlurVert:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003DzpIOgvWqCy9lM();
		case shaderType.Outline:
			return _0023_003DzGqk1Jws5Qz9vMgHrzBCP2i8_003D._0023_003DzEP5V9Fw_003D();
		default:
			throw new NotImplementedException();
		}
	}
}
