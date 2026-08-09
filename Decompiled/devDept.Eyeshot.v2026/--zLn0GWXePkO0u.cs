using System;
using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003DzLn0GWXePkO0u
{
	public sealed class _0023_003DzSFDLg0ySU5LF : IEqualityComparer<Tuple<uint, uint>>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dze0Fv7ZA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzKltRkW4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DztXhReqsokgjP;

		public _0023_003DzSFDLg0ySU5LF(int _0023_003DzUyUjWvo_003D = 8)
		{
			_0023_003Dze0Fv7ZA_003D = _0023_003DznQmwsb4uCzj5._0023_003DzJ5Y6QGlKLoMh(_0023_003DzUyUjWvo_003D);
			_0023_003DztXhReqsokgjP = _0023_003Dze0Fv7ZA_003D + 1;
			_0023_003DzKltRkW4_003D = 0;
		}

		public void _0023_003DzxoMYJ81eOYFN(int _0023_003DzUyUjWvo_003D)
		{
			_0023_003Dze0Fv7ZA_003D = _0023_003DznQmwsb4uCzj5._0023_003DzJ5Y6QGlKLoMh(_0023_003DzUyUjWvo_003D);
			_0023_003DztXhReqsokgjP = _0023_003Dze0Fv7ZA_003D + 1;
			_0023_003DzKltRkW4_003D = 0;
		}

		public bool Equals(Tuple<uint, uint> _0023_003DzBJFJHwk_003D, Tuple<uint, uint> _0023_003Dz40R7bAU_003D)
		{
			if (_0023_003DzBJFJHwk_003D.Item1 == _0023_003Dz40R7bAU_003D.Item1 && _0023_003DzBJFJHwk_003D.Item2 == _0023_003Dz40R7bAU_003D.Item2)
			{
				return true;
			}
			return false;
		}

		public int GetHashCode(Tuple<uint, uint> _0023_003DzCX9Hbao_003D)
		{
			uint num = 0u;
			num ^= (uint)((int)_0023_003DzCX9Hbao_003D.Item1 + -1640531527 + (int)(num << 6) + (int)(num >> 2));
			num ^= (uint)((int)_0023_003DzCX9Hbao_003D.Item2 + -1640531527 + (int)(num << 6) + (int)(num >> 2));
			return (int)num & _0023_003Dze0Fv7ZA_003D;
		}

		public bool _0023_003Dz7_tGU8jVJwFd()
		{
			if (1.0 < Convert.ToDouble(_0023_003DzKltRkW4_003D) / Convert.ToDouble(_0023_003DztXhReqsokgjP))
			{
				int num = _0023_003DztXhReqsokgjP;
				num = ((num >= 512) ? (num * 2) : (num * 8));
				_0023_003Dze0Fv7ZA_003D = num - 1;
				_0023_003DztXhReqsokgjP = num;
				return true;
			}
			return false;
		}
	}

	public static class _0023_003DznQmwsb4uCzj5
	{
		public static int _0023_003DzJ5Y6QGlKLoMh(int _0023_003Dz0L2_dUk_003D)
		{
			int num = int.MaxValue;
			int num2 = 8;
			while (num2 < _0023_003Dz0L2_dUk_003D && num2 < num)
			{
				num2 *= 2;
			}
			return num2 - 1;
		}
	}

	public static void _0023_003DzNQ9Nv80_003D(List<_0023_003DzS2iP22kRK_wR290tTpXL_0024UpEygCs._0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D> _0023_003DzD4_6UnewoOi_8vgCZQ_003D_003D, _0023_003DzS2iP22kRK_wR290tTpXL_0024UpEygCs._0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D _0023_003DzXULhp_00248_003D)
	{
		int i = 0;
		for (int count = _0023_003DzD4_6UnewoOi_8vgCZQ_003D_003D.Count; i != count; i++)
		{
			_0023_003DzD4_6UnewoOi_8vgCZQ_003D_003D[i] = _0023_003DzXULhp_00248_003D;
		}
	}

	public static void _0023_003DzNQ9Nv80_003D(int _0023_003DzRVoDPs0_003D, int _0023_003DzDr1MUxo_003D, List<double> _0023_003DzD4_6UnewoOi_8vgCZQ_003D_003D, uint _0023_003DzXULhp_00248_003D)
	{
		while (_0023_003DzRVoDPs0_003D != _0023_003DzDr1MUxo_003D)
		{
			_0023_003DzD4_6UnewoOi_8vgCZQ_003D_003D[_0023_003DzRVoDPs0_003D] = _0023_003DzXULhp_00248_003D;
			_0023_003DzRVoDPs0_003D++;
		}
	}

	public static void _0023_003DzEXLcE10_003D(int _0023_003DzRVoDPs0_003D, int _0023_003DzDr1MUxo_003D, List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> _0023_003DzW9FQ15bjNq8I5LASIA_003D_003D)
	{
		while (_0023_003DzRVoDPs0_003D != _0023_003DzDr1MUxo_003D && _0023_003DzRVoDPs0_003D != --_0023_003DzDr1MUxo_003D)
		{
			_0023_003DznKtQBJ2EDmhK(_0023_003DzRVoDPs0_003D, _0023_003DzDr1MUxo_003D, _0023_003DzW9FQ15bjNq8I5LASIA_003D_003D);
			_0023_003DzRVoDPs0_003D++;
		}
	}

	public static void _0023_003DznKtQBJ2EDmhK(int _0023_003DzjbqS1qE_003D, int _0023_003Dz1v6oPQk_003D, List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> _0023_003DzW9FQ15bjNq8I5LASIA_003D_003D)
	{
		_0023_003Dzxd6BoZ4_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D, _0023_003DzW9FQ15bjNq8I5LASIA_003D_003D);
	}

	public static void _0023_003Dzxd6BoZ4_003D(int _0023_003DzjbqS1qE_003D, int _0023_003Dz1v6oPQk_003D, List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> _0023_003DzW9FQ15bjNq8I5LASIA_003D_003D)
	{
		_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D value = _0023_003DzW9FQ15bjNq8I5LASIA_003D_003D[_0023_003DzjbqS1qE_003D];
		_0023_003DzW9FQ15bjNq8I5LASIA_003D_003D[_0023_003DzjbqS1qE_003D] = _0023_003DzW9FQ15bjNq8I5LASIA_003D_003D[_0023_003Dz1v6oPQk_003D];
		_0023_003DzW9FQ15bjNq8I5LASIA_003D_003D[_0023_003Dz1v6oPQk_003D] = value;
	}

	public static int _0023_003Dzl_0024kBRC0_003D(int _0023_003DzAqOpw0w_003D, int _0023_003Dzk64JNOo_003D, List<double> _0023_003Dzb7SPTpc_003D, int _0023_003DzJBh158s_003D, List<double> _0023_003Dzzo8RvXc_003D)
	{
		for (int i = _0023_003DzAqOpw0w_003D; i < _0023_003Dzk64JNOo_003D; i++)
		{
			_0023_003Dzzo8RvXc_003D.Insert(_0023_003DzJBh158s_003D, _0023_003Dzb7SPTpc_003D[i]);
			_0023_003DzJBh158s_003D++;
		}
		return _0023_003DzJBh158s_003D;
	}

	public static void _0023_003DzhF_UisQ_003D(ref long _0023_003DzWBTH6Pc_003D, ref long _0023_003DzkSkwveA_003D)
	{
		long num = _0023_003DzWBTH6Pc_003D;
		_0023_003DzWBTH6Pc_003D = _0023_003DzkSkwveA_003D;
		_0023_003DzkSkwveA_003D = num;
	}

	public static uint _0023_003DzD8KG3IzIZQ4q(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, List<uint> _0023_003DzBh0pl5Q_003D, uint _0023_003Dz6GWD7Qn_0024HnfQrDXn8K9rYu_0024ZnYDI4hTs4w_003D_003D)
	{
		while (_0023_003DzRVoDPs0_003D != _0023_003DzDr1MUxo_003D && !_0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(_0023_003Dz6GWD7Qn_0024HnfQrDXn8K9rYu_0024ZnYDI4hTs4w_003D_003D, _0023_003DzBh0pl5Q_003D[(int)_0023_003DzRVoDPs0_003D]))
		{
			_0023_003DzRVoDPs0_003D++;
		}
		if (_0023_003DzRVoDPs0_003D < _0023_003DzBh0pl5Q_003D.Count)
		{
			return _0023_003DzRVoDPs0_003D;
		}
		return uint.MaxValue;
	}

	public static bool _0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(uint _0023_003Dz6GWD7Qn_0024HnfQrDXn8K9rYu_0024ZnYDI4hTs4w_003D_003D, uint _0023_003DzPzO_0024GUk_003D)
	{
		return _0023_003DzPzO_0024GUk_003D < _0023_003Dz6GWD7Qn_0024HnfQrDXn8K9rYu_0024ZnYDI4hTs4w_003D_003D;
	}

	public static uint _0023_003DzD8KG3IzIZQ4q(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, List<uint> _0023_003DzBh0pl5Q_003D, uint _0023_003Dz25ReCaCSsPJv4Y99NXWhApiLcILn, uint _0023_003Dz6Y4BoUWFYxyjlVQAldvwL7VX3gCHa4AWcvvNiWw_003D)
	{
		uint num;
		for (num = _0023_003DzRVoDPs0_003D; num != _0023_003DzDr1MUxo_003D && !_0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(_0023_003Dz25ReCaCSsPJv4Y99NXWhApiLcILn, _0023_003Dz6Y4BoUWFYxyjlVQAldvwL7VX3gCHa4AWcvvNiWw_003D, _0023_003DzBh0pl5Q_003D[(int)num]); num++)
		{
		}
		_0023_003DzRVoDPs0_003D = num;
		if (_0023_003DzRVoDPs0_003D >= _0023_003DzBh0pl5Q_003D.Count)
		{
			return uint.MaxValue;
		}
		return _0023_003DzRVoDPs0_003D;
	}

	public static bool _0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(uint _0023_003Dz25ReCaCSsPJv4Y99NXWhApiLcILn, uint _0023_003Dz6Y4BoUWFYxyjlVQAldvwL7VX3gCHa4AWcvvNiWw_003D, uint _0023_003Dz437_00244ak_003D)
	{
		if (_0023_003Dz437_00244ak_003D >= _0023_003Dz25ReCaCSsPJv4Y99NXWhApiLcILn)
		{
			return _0023_003Dz437_00244ak_003D < _0023_003Dz6Y4BoUWFYxyjlVQAldvwL7VX3gCHa4AWcvvNiWw_003D;
		}
		return false;
	}

	public static uint _0023_003DzsK5ayzqFZ5qP(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, List<uint> _0023_003DzWlztEOZcMOof, uint _0023_003DzVEGAjeZoIH_0024_00241oEggr3YBLk_003D, List<bool> _0023_003DzILpY9QqE29OD)
	{
		_0023_003DzRVoDPs0_003D = _0023_003DzD8KG3IzIZQ4q(_0023_003DzRVoDPs0_003D, _0023_003DzDr1MUxo_003D, _0023_003DzWlztEOZcMOof, _0023_003DzVEGAjeZoIH_0024_00241oEggr3YBLk_003D, _0023_003DzILpY9QqE29OD);
		uint num = _0023_003DzRVoDPs0_003D;
		uint num2 = _0023_003DzRVoDPs0_003D;
		if (num != _0023_003DzDr1MUxo_003D)
		{
			while (++num != _0023_003DzDr1MUxo_003D)
			{
				if (!_0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(_0023_003DzWlztEOZcMOof[(int)num], _0023_003DzVEGAjeZoIH_0024_00241oEggr3YBLk_003D, _0023_003DzILpY9QqE29OD))
				{
					_0023_003DzWlztEOZcMOof[(int)num2] = _0023_003DzWlztEOZcMOof[(int)num];
					num2++;
				}
			}
		}
		_0023_003DzRVoDPs0_003D = num2;
		return _0023_003DzRVoDPs0_003D;
	}

	public static uint _0023_003DzD8KG3IzIZQ4q(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, List<uint> _0023_003DzWlztEOZcMOof, uint _0023_003DzVEGAjeZoIH_0024_00241oEggr3YBLk_003D, List<bool> _0023_003DzILpY9QqE29OD)
	{
		uint num;
		for (num = _0023_003DzRVoDPs0_003D; num != _0023_003DzDr1MUxo_003D && !_0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(_0023_003DzWlztEOZcMOof[(int)num], _0023_003DzVEGAjeZoIH_0024_00241oEggr3YBLk_003D, _0023_003DzILpY9QqE29OD); num++)
		{
		}
		_0023_003DzRVoDPs0_003D = num;
		return _0023_003DzRVoDPs0_003D;
	}

	public static bool _0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(uint _0023_003DzyzK8swU_003D, uint _0023_003DzVEGAjeZoIH_0024_00241oEggr3YBLk_003D, List<bool> _0023_003DzILpY9QqE29OD)
	{
		if (_0023_003DzyzK8swU_003D != _0023_003DzVEGAjeZoIH_0024_00241oEggr3YBLk_003D)
		{
			return _0023_003DzILpY9QqE29OD[(int)_0023_003DzyzK8swU_003D];
		}
		return false;
	}

	public static uint _0023_003DzsK5ayzqFZ5qP(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D> _0023_003DzBh0pl5Q_003D, HashSet<Tuple<uint, uint>> _0023_003DzT_H6KyVYBHee, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzQc8VQekavOEG, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DziXYpXl_0024HD9gD)
	{
		_0023_003DzRVoDPs0_003D = _0023_003DzD8KG3IzIZQ4q(_0023_003DzRVoDPs0_003D, _0023_003DzDr1MUxo_003D, _0023_003DzT_H6KyVYBHee, _0023_003DzBh0pl5Q_003D, _0023_003DzQc8VQekavOEG, _0023_003DziXYpXl_0024HD9gD);
		uint num = _0023_003DzRVoDPs0_003D;
		uint num2 = _0023_003DzRVoDPs0_003D;
		if (num != _0023_003DzDr1MUxo_003D)
		{
			for (; num < _0023_003DzDr1MUxo_003D; num++)
			{
				if (!_0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(_0023_003DzT_H6KyVYBHee, _0023_003DzBh0pl5Q_003D, num, _0023_003DzQc8VQekavOEG, _0023_003DziXYpXl_0024HD9gD))
				{
					_0023_003DzBh0pl5Q_003D[(int)num2] = _0023_003DzBh0pl5Q_003D[(int)num];
					num2++;
				}
			}
		}
		_0023_003DzRVoDPs0_003D = num2;
		return _0023_003DzRVoDPs0_003D;
	}

	public static uint _0023_003DzD8KG3IzIZQ4q(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, HashSet<Tuple<uint, uint>> _0023_003DzT_H6KyVYBHee, List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D> _0023_003DzXbk97xF5bva7, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzQc8VQekavOEG, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DziXYpXl_0024HD9gD)
	{
		uint num;
		for (num = _0023_003DzRVoDPs0_003D; num != _0023_003DzDr1MUxo_003D && !_0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(_0023_003DzT_H6KyVYBHee, _0023_003DzXbk97xF5bva7, num, _0023_003DzQc8VQekavOEG, _0023_003DziXYpXl_0024HD9gD); num++)
		{
		}
		_0023_003DzRVoDPs0_003D = num;
		return _0023_003DzRVoDPs0_003D;
	}

	public static bool _0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(HashSet<Tuple<uint, uint>> _0023_003DzT_H6KyVYBHee, List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D> _0023_003DzXbk97xF5bva7, uint _0023_003DzyzK8swU_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzQc8VQekavOEG, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DziXYpXl_0024HD9gD)
	{
		if (!_0023_003DzT_H6KyVYBHee.Contains(new Tuple<uint, uint>(_0023_003DzXbk97xF5bva7[(int)_0023_003DzyzK8swU_003D]._0023_003DzzBupebA_003D, _0023_003DzXbk97xF5bva7[(int)_0023_003DzyzK8swU_003D]._0023_003Dz7e1fPC8_003D)))
		{
			return false;
		}
		_0023_003DzcQiRB3Mv_00246WF _0023_003Dz5Azd7L8_003D = _0023_003DzQc8VQekavOEG[_0023_003Dz4bQB7f9e8mCtX_ivosmY4ynvt_I_0024VHY6ew_003D_003D._0023_003DzduXNaEJiW25_0024(_0023_003DzXbk97xF5bva7[(int)_0023_003DzyzK8swU_003D]._0023_003DzzBupebA_003D, _0023_003DzQc8VQekavOEG)]._0023_003DzIIL2q6XkW9OP();
		if (_0023_003DzcQiRB3Mv_00246WF._0023_003Dzgr6OWgJnCIU5(_0023_003DzXbk97xF5bva7[(int)_0023_003DzyzK8swU_003D]._0023_003DzpdeSbFA_003D, _0023_003Dz5Azd7L8_003D))
		{
			return true;
		}
		_0023_003DzcQiRB3Mv_00246WF _0023_003Dz5Azd7L8_003D2 = _0023_003DziXYpXl_0024HD9gD[_0023_003Dz4bQB7f9e8mCtX_ivosmY4ynvt_I_0024VHY6ew_003D_003D._0023_003DzduXNaEJiW25_0024(_0023_003DzXbk97xF5bva7[(int)_0023_003DzyzK8swU_003D]._0023_003Dz7e1fPC8_003D, _0023_003DziXYpXl_0024HD9gD)]._0023_003DzIIL2q6XkW9OP();
		return _0023_003DzcQiRB3Mv_00246WF._0023_003Dzgr6OWgJnCIU5(_0023_003DzXbk97xF5bva7[(int)_0023_003DzyzK8swU_003D]._0023_003DzpdeSbFA_003D, _0023_003Dz5Azd7L8_003D2);
	}

	public static uint _0023_003DzsK5ayzqFZ5qP(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, List<uint> _0023_003DzWlztEOZcMOof, List<bool> _0023_003DzILpY9QqE29OD)
	{
		_0023_003DzRVoDPs0_003D = _0023_003DzD8KG3IzIZQ4q(_0023_003DzRVoDPs0_003D, _0023_003DzDr1MUxo_003D, _0023_003DzWlztEOZcMOof, _0023_003DzILpY9QqE29OD);
		uint num = _0023_003DzRVoDPs0_003D;
		uint num2 = _0023_003DzRVoDPs0_003D;
		if (num != _0023_003DzDr1MUxo_003D)
		{
			while (++num != _0023_003DzDr1MUxo_003D)
			{
				if (!_0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(_0023_003DzWlztEOZcMOof[(int)num], _0023_003DzILpY9QqE29OD))
				{
					_0023_003DzWlztEOZcMOof[(int)num2] = _0023_003DzWlztEOZcMOof[(int)num];
					num2++;
				}
			}
		}
		_0023_003DzRVoDPs0_003D = num2;
		return _0023_003DzRVoDPs0_003D;
	}

	public static uint _0023_003DzD8KG3IzIZQ4q(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, List<uint> _0023_003DzWlztEOZcMOof, List<bool> _0023_003DzILpY9QqE29OD)
	{
		uint num;
		for (num = _0023_003DzRVoDPs0_003D; num != _0023_003DzDr1MUxo_003D && !_0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(_0023_003DzWlztEOZcMOof[(int)num], _0023_003DzILpY9QqE29OD); num++)
		{
		}
		_0023_003DzRVoDPs0_003D = num;
		return _0023_003DzRVoDPs0_003D;
	}

	public static bool _0023_003DzzGR14_0024rSQNrig5BDSw_003D_003D(uint _0023_003DzyzK8swU_003D, List<bool> _0023_003DzILpY9QqE29OD)
	{
		return _0023_003DzILpY9QqE29OD[(int)_0023_003DzyzK8swU_003D];
	}

	public static void _0023_003DzwVFSvec_003D(int _0023_003DzMg6UGAU_003D, List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> _0023_003DzmmOE2ec_003D, int _0023_003Dzkfp2bdc_003D, int _0023_003DzRDzl4_00248_003D, List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> _0023_003DzsP8EGLoRmZgC)
	{
		for (int i = _0023_003Dzkfp2bdc_003D; i < _0023_003DzRDzl4_00248_003D; i++)
		{
			_0023_003DzmmOE2ec_003D.Add(_0023_003DzsP8EGLoRmZgC[i]);
		}
	}

	public static void _0023_003DzhF_UisQ_003D(List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D> _0023_003DzXpSQPCI_003D, List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D> _0023_003DzMH3yuIE_003D)
	{
		List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D> collection = new List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D>(_0023_003DzXpSQPCI_003D);
		_0023_003DzXpSQPCI_003D.Clear();
		_0023_003DzXpSQPCI_003D.AddRange(_0023_003DzMH3yuIE_003D);
		_0023_003DzMH3yuIE_003D.Clear();
		_0023_003DzMH3yuIE_003D.AddRange(collection);
	}

	public static void _0023_003DzhF_UisQ_003D(List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzXpSQPCI_003D, List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzMH3yuIE_003D)
	{
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> collection = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(_0023_003DzXpSQPCI_003D);
		_0023_003DzXpSQPCI_003D.Clear();
		_0023_003DzXpSQPCI_003D.AddRange(_0023_003DzMH3yuIE_003D);
		_0023_003DzMH3yuIE_003D.Clear();
		_0023_003DzMH3yuIE_003D.AddRange(collection);
	}

	public static void _0023_003DzhF_UisQ_003D(List<bool> _0023_003DzXpSQPCI_003D, List<bool> _0023_003DzMH3yuIE_003D)
	{
		List<bool> collection = new List<bool>(_0023_003DzXpSQPCI_003D);
		_0023_003DzXpSQPCI_003D.Clear();
		_0023_003DzXpSQPCI_003D.AddRange(_0023_003DzMH3yuIE_003D);
		_0023_003DzMH3yuIE_003D.Clear();
		_0023_003DzMH3yuIE_003D.AddRange(collection);
	}

	public static void _0023_003Dzl2vWevE_003D(List<bool> _0023_003DzcDEsV8s_003D, int _0023_003DzsSJGgWE_003D, bool _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzcDEsV8s_003D.Count > _0023_003DzsSJGgWE_003D)
		{
			_0023_003DzcDEsV8s_003D.RemoveRange(_0023_003DzsSJGgWE_003D, _0023_003DzcDEsV8s_003D.Count - _0023_003DzsSJGgWE_003D);
		}
		else if (_0023_003DzcDEsV8s_003D.Count < _0023_003DzsSJGgWE_003D)
		{
			for (int i = _0023_003DzcDEsV8s_003D.Count; i < _0023_003DzsSJGgWE_003D; i++)
			{
				_0023_003DzcDEsV8s_003D.Add(_0023_003DzPzO_0024GUk_003D);
			}
		}
	}

	public static void _0023_003Dzl2vWevE_003D(List<double> _0023_003DzcDEsV8s_003D, int _0023_003DzsSJGgWE_003D, double _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzcDEsV8s_003D.Count > _0023_003DzsSJGgWE_003D)
		{
			_0023_003DzcDEsV8s_003D.RemoveRange(_0023_003DzsSJGgWE_003D, _0023_003DzcDEsV8s_003D.Count - _0023_003DzsSJGgWE_003D);
		}
		else if (_0023_003DzcDEsV8s_003D.Count < _0023_003DzsSJGgWE_003D)
		{
			for (int i = _0023_003DzcDEsV8s_003D.Count; i < _0023_003DzsSJGgWE_003D; i++)
			{
				_0023_003DzcDEsV8s_003D.Add(_0023_003DzPzO_0024GUk_003D);
			}
		}
	}

	public static void _0023_003Dzl2vWevE_003D(List<List<uint>> _0023_003DzcDEsV8s_003D, int _0023_003DzsSJGgWE_003D, List<uint> _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzcDEsV8s_003D.Count > _0023_003DzsSJGgWE_003D)
		{
			_0023_003DzcDEsV8s_003D.RemoveRange(_0023_003DzsSJGgWE_003D, _0023_003DzcDEsV8s_003D.Count - _0023_003DzsSJGgWE_003D);
		}
		else if (_0023_003DzcDEsV8s_003D.Count < _0023_003DzsSJGgWE_003D)
		{
			for (int i = _0023_003DzcDEsV8s_003D.Count; i < _0023_003DzsSJGgWE_003D; i++)
			{
				_0023_003DzcDEsV8s_003D.Add(_0023_003DzPzO_0024GUk_003D);
			}
		}
	}

	public static void _0023_003Dzl2vWevE_003D(List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> _0023_003DzcDEsV8s_003D, int _0023_003DzsSJGgWE_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzcDEsV8s_003D.Count > _0023_003DzsSJGgWE_003D)
		{
			_0023_003DzcDEsV8s_003D.RemoveRange(_0023_003DzsSJGgWE_003D, _0023_003DzcDEsV8s_003D.Count - _0023_003DzsSJGgWE_003D);
		}
		else if (_0023_003DzcDEsV8s_003D.Count < _0023_003DzsSJGgWE_003D)
		{
			for (int i = _0023_003DzcDEsV8s_003D.Count; i < _0023_003DzsSJGgWE_003D; i++)
			{
				_0023_003DzcDEsV8s_003D.Add(_0023_003DzPzO_0024GUk_003D);
			}
		}
	}

	public static void _0023_003Dzl2vWevE_003D(List<_0023_003DzS2iP22kRK_wR290tTpXL_0024UpEygCs._0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D> _0023_003DzcDEsV8s_003D, int _0023_003DzsSJGgWE_003D, _0023_003DzS2iP22kRK_wR290tTpXL_0024UpEygCs._0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzcDEsV8s_003D.Count > _0023_003DzsSJGgWE_003D)
		{
			_0023_003DzcDEsV8s_003D.RemoveRange(_0023_003DzsSJGgWE_003D, _0023_003DzcDEsV8s_003D.Count - _0023_003DzsSJGgWE_003D);
		}
		else if (_0023_003DzcDEsV8s_003D.Count < _0023_003DzsSJGgWE_003D)
		{
			for (int i = _0023_003DzcDEsV8s_003D.Count; i < _0023_003DzsSJGgWE_003D; i++)
			{
				_0023_003DzcDEsV8s_003D.Add(_0023_003DzPzO_0024GUk_003D);
			}
		}
	}

	public static void _0023_003Dzl2vWevE_003D(List<_0023_003DzS2iP22kRK_wR290tTpXL_0024UpEygCs._0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D> _0023_003DzcDEsV8s_003D, int _0023_003DzsSJGgWE_003D, _0023_003DzS2iP22kRK_wR290tTpXL_0024UpEygCs._0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzcDEsV8s_003D.Count > _0023_003DzsSJGgWE_003D)
		{
			_0023_003DzcDEsV8s_003D.RemoveRange(_0023_003DzsSJGgWE_003D, _0023_003DzcDEsV8s_003D.Count - _0023_003DzsSJGgWE_003D);
		}
		else if (_0023_003DzcDEsV8s_003D.Count < _0023_003DzsSJGgWE_003D)
		{
			for (int i = _0023_003DzcDEsV8s_003D.Count; i < _0023_003DzsSJGgWE_003D; i++)
			{
				_0023_003DzcDEsV8s_003D.Add(_0023_003DzPzO_0024GUk_003D);
			}
		}
	}
}
