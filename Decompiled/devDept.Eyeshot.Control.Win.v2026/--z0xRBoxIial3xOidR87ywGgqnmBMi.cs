using System;
using System.Diagnostics;
using SharpDX.D3DCompiler;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using devDept.Graphics;

internal sealed class _0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi<_0023_003DzWoS2eJk_003D, _0023_003DzjYYAPCA_003D> : global::_0023_003DzBmXz0gRPiKFIxUCQVDI95Ivdytnc<_0023_003DzWoS2eJk_003D, _0023_003DzjYYAPCA_003D> where _0023_003DzWoS2eJk_003D : struct, _0023_003DzrMGZTYmugtUvk4_0024f3rFUC49cbnhp where _0023_003DzjYYAPCA_003D : struct, _0023_003DzxlkUGOHLNznjaogT7e4XpG7_0024jwSH
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public ShaderBytecode _0023_003Dz_00247vYhoLmVq5p;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public ShaderBytecode _0023_003Dztkr6ImRvCwALaFLLVw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GeometryShader _0023_003DzOsCIt2zRI6D9T6_e9I7SCos_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GeometryShader _0023_003DzgxWYwxELQnDARv9m5E_hmDOPYnPt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_ _0023_003DzD8B1UoIRQ_00240lukd5EejZiE6EdXdd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz6Jo21io_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz0AADrNPF5g4q;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzpUXgp3DwJ8fEKajmSQ_003D_003D;

	public override bool IsCompiled => _0023_003Dzdxmzy3zcwAaU() != null;

	public _0023_003Dz0xRBoxIial3xOidR87ywGgqnmBMi(Device _0023_003DzJ_0024CASPE_003D, FeatureLevel _0023_003DzGIPo6pY0ShMi, string _0023_003DzZLWXAps_003D, _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_ _0023_003Dzkb2a_00244ZL5F39, bool _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D = true)
		: base(_0023_003DzJ_0024CASPE_003D)
	{
		_0023_003Dz0AADrNPF5g4q = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601839);
		_0023_003DzpUXgp3DwJ8fEKajmSQ_003D_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601825);
		_0023_003Dz6Jo21io_003D = _0023_003DzZLWXAps_003D;
		_0023_003Dz9HK1Trz6RwsrD4F1OZvmT7s_003D(_0023_003Dzkb2a_00244ZL5F39);
		this._0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D = _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D;
	}

	private GeometryShader _0023_003Dzdxmzy3zcwAaU()
	{
		return _0023_003DzOsCIt2zRI6D9T6_e9I7SCos_003D;
	}

	private void _0023_003DzG6dV2kcIdAX8(GeometryShader _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzOsCIt2zRI6D9T6_e9I7SCos_003D = _0023_003DzsLHxXyo_003D;
	}

	private GeometryShader _0023_003DzZ0LpqSCs1PEfD5JJ9Q_003D_003D()
	{
		return _0023_003DzgxWYwxELQnDARv9m5E_hmDOPYnPt;
	}

	private void _0023_003DzSwV6M45w2cqbgY14yQ_003D_003D(GeometryShader _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzgxWYwxELQnDARv9m5E_hmDOPYnPt = _0023_003DzsLHxXyo_003D;
	}

	public _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_ _0023_003DzY_0024ZCOhROTsSqOXkL_0024cnwMuA_003D()
	{
		return _0023_003DzD8B1UoIRQ_00240lukd5EejZiE6EdXdd;
	}

	private void _0023_003Dz9HK1Trz6RwsrD4F1OZvmT7s_003D(_0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_ _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzD8B1UoIRQ_00240lukd5EejZiE6EdXdd = _0023_003DzsLHxXyo_003D;
	}

	public override bool Compile(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003Dz_00247vYhoLmVq5p = _0023_003DzX5I0kYMZ27nVKvNSAA_003D_003D(_0023_003Dz6Jo21io_003D, _0023_003Dz0AADrNPF5g4q);
		Device _0023_003DzTzFVZ_00240_003D = ((D3DRenderContext)_0023_003DzmNZD0Zs_003D)._0023_003DzTzFVZ_00240_003D;
		_0023_003DzG6dV2kcIdAX8(new GeometryShader(_0023_003DzTzFVZ_00240_003D, _0023_003Dz_00247vYhoLmVq5p));
		try
		{
			if (_0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D)
			{
				_0023_003Dztkr6ImRvCwALaFLLVw_003D_003D = _0023_003DzX5I0kYMZ27nVKvNSAA_003D_003D(_0023_003Dz6Jo21io_003D, _0023_003DzpUXgp3DwJ8fEKajmSQ_003D_003D);
				_0023_003DzSwV6M45w2cqbgY14yQ_003D_003D(new GeometryShader(_0023_003DzTzFVZ_00240_003D, _0023_003Dztkr6ImRvCwALaFLLVw_003D_003D));
			}
		}
		catch (Exception)
		{
		}
		return true;
	}

	public override void _0023_003DzCCBca0k_003D(DeviceContext _0023_003DzoC62DbA_003D, bool _0023_003DzSSU_OrNwA8uS)
	{
		_0023_003DzoC62DbA_003D.GeometryShader.Set(_0023_003DzSSU_OrNwA8uS ? _0023_003DzZ0LpqSCs1PEfD5JJ9Q_003D_003D() : _0023_003Dzdxmzy3zcwAaU());
		if (_0023_003DzY_0024ZCOhROTsSqOXkL_0024cnwMuA_003D()._0023_003Dz8g1qSCQ_003D >= 0)
		{
			_0023_003DzoC62DbA_003D.GeometryShader.SetConstantBuffer(_0023_003DzY_0024ZCOhROTsSqOXkL_0024cnwMuA_003D()._0023_003Dz8g1qSCQ_003D, _0023_003DzLzovILT5Pg1SO1lXjw_003D_003D());
		}
		if (_0023_003DzY_0024ZCOhROTsSqOXkL_0024cnwMuA_003D()._0023_003Dzie0Ff26EAshd >= 0)
		{
			_0023_003DzoC62DbA_003D.GeometryShader.SetConstantBuffer(_0023_003DzY_0024ZCOhROTsSqOXkL_0024cnwMuA_003D()._0023_003Dzie0Ff26EAshd, _0023_003DzbnCF7h7ukra_0024pIXzuA_003D_003D());
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		if (_0023_003Dzdxmzy3zcwAaU() != null)
		{
			_0023_003Dzdxmzy3zcwAaU().Dispose();
			_0023_003DzG6dV2kcIdAX8(null);
			_0023_003Dz_00247vYhoLmVq5p.Dispose();
			_0023_003Dz_00247vYhoLmVq5p = null;
		}
		if (_0023_003DzZ0LpqSCs1PEfD5JJ9Q_003D_003D() != null)
		{
			_0023_003DzZ0LpqSCs1PEfD5JJ9Q_003D_003D().Dispose();
			_0023_003DzSwV6M45w2cqbgY14yQ_003D_003D(null);
			_0023_003Dztkr6ImRvCwALaFLLVw_003D_003D.Dispose();
			_0023_003Dztkr6ImRvCwALaFLLVw_003D_003D = null;
		}
	}
}
