using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D : _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D
{
	private object _0023_003Dzq80RbjQ_003D;

	public _0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D(object _0023_003Dzq80RbjQ_003D)
		: base(25)
	{
		if (_0023_003Dzq80RbjQ_003D != null && !(_0023_003Dzq80RbjQ_003D is ValueType))
		{
			throw new ArgumentException();
		}
		this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
	}

	public object _0023_003Dz0JnUB3O4xCsib39IP97QRlnfMWXo()
	{
		return _0023_003Dzq80RbjQ_003D;
	}

	public void _0023_003DzoSeWBn4VgamQ_0024hZPDt1I4ZA_003D(object _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D != null && !(_0023_003Dzq80RbjQ_003D is ValueType))
		{
			throw new ArgumentException();
		}
		this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
	}

	[SpecialName]
	public override object _0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()
	{
		return _0023_003Dz0JnUB3O4xCsib39IP97QRlnfMWXo();
	}

	[SpecialName]
	public override void _0023_003Dzo33kGQXV675C6hNoF81XsSEYKksd3nOR_0024BTIt3_9Mzop3nbwVDhRzms9WcekcpYSeX_0024SmhxcEhkErzVIHbObpCA_003D(object _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzoSeWBn4VgamQ_0024hZPDt1I4ZA_003D(_0023_003Dzq80RbjQ_003D);
	}

	private static bool _0023_003DzAJL_0024q7gHnNtBYjq1is_rJDYoGOYK(Type _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D.IsGenericType && _0023_003Dzq80RbjQ_003D.Namespace == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527858))
		{
			string name = _0023_003Dzq80RbjQ_003D.Name;
			if (name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527815) || name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527832))
			{
				return false;
			}
		}
		return true;
	}

	public override _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
		switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 25:
		{
			object obj = ((_0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz0JnUB3O4xCsib39IP97QRlnfMWXo();
			object obj2 = _0023_003Dz0JnUB3O4xCsib39IP97QRlnfMWXo();
			if (obj2 != null && obj != null)
			{
				Type type = obj2.GetType();
				if (!type.IsPrimitive && !type.IsEnum && type == obj.GetType() && _0023_003DzAJL_0024q7gHnNtBYjq1is_rJDYoGOYK(type))
				{
					FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						fieldInfo.SetValue(obj2, fieldInfo.GetValue(obj));
					}
					break;
				}
			}
			_0023_003DzoSeWBn4VgamQ_0024hZPDt1I4ZA_003D(obj);
			break;
		}
		case 7:
			_0023_003DzoSeWBn4VgamQ_0024hZPDt1I4ZA_003D(((_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzvPsFwllF9YUejQF68VzjbUs4hENNmXLLhEVR500jpyde());
			break;
		default:
			_0023_003DzoSeWBn4VgamQ_0024hZPDt1I4ZA_003D(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
			break;
		}
		return this;
	}

	public override _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dz048eNPCCLNNmZFIiW7pSmsLry714y0ieZoaY0obA2vjaWKhL_0024Ft9HlWoFrDEcPmBFkeHbqme9OIi()
	{
		_0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D obj = new _0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D(_0023_003Dzq80RbjQ_003D);
		obj._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
		return obj;
	}
}
