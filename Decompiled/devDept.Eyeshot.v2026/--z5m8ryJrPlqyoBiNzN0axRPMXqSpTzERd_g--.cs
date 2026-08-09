using System;
using System.Collections.Generic;

internal sealed class _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D : _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D
{
	private Dictionary<uint, uint> _0023_003DzS0fEsyA_003D = new Dictionary<uint, uint>();

	public _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D()
	{
	}

	public _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D _0023_003Dzb7SPTpc_003D)
	{
		uint _0023_003DzoMNiNRw_003D = _0023_003DzRVoDPs0_003D - _0023_003DzDr1MUxo_003D;
		_0023_003Dze6U2VUyBaRq6(_0023_003DzoMNiNRw_003D, 1u);
		_0023_003DzMdkihsQJa2bf._0023_003Dzl_0024kBRC0_003D(_0023_003DzRVoDPs0_003D, _0023_003DzDr1MUxo_003D, _0023_003Dzb7SPTpc_003D, _0023_003DzIBRMQdw_003D(), this);
	}

	public override void _0023_003DzttBXI_0024c_003D()
	{
		base._0023_003DzttBXI_0024c_003D();
		_0023_003DzS0fEsyA_003D.Clear();
	}

	public bool _0023_003Dzl_0024kBRC0_003D(_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D _0023_003DzBJFJHwk_003D)
	{
		_0023_003DzttBXI_0024c_003D();
		if (!_0023_003Dzl_0024kBRC0_003D((_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D)_0023_003DzBJFJHwk_003D))
		{
			return false;
		}
		_0023_003DzS0fEsyA_003D = _0023_003DzBJFJHwk_003D._0023_003DzS0fEsyA_003D;
		return true;
	}

	public bool _0023_003DzoVvJiTZkfNA7(HashSet<uint> _0023_003DzazMdIw6iDqMJ)
	{
		uint num = Convert.ToUInt32(_0023_003DzazMdIw6iDqMJ.Count);
		_0023_003DzttBXI_0024c_003D();
		if (!_0023_003DzroU3nqY_003D(num))
		{
			return false;
		}
		uint num2 = _0023_003DzIBRMQdw_003D();
		_0023_003DzMdkihsQJa2bf._0023_003Dzl_0024kBRC0_003D(0u, (uint)_0023_003DzazMdIw6iDqMJ.Count, _0023_003DzazMdIw6iDqMJ, num2, this);
		_0023_003DzMdkihsQJa2bf._0023_003DzoQcRoMY_003D(num2, num2 + num, this);
		uint num3 = 0u;
		while (num3 < num)
		{
			uint key = _0023_003DzYBaDcXE_003D(num2);
			_0023_003DzS0fEsyA_003D.Add(key, num3);
			num3++;
			num2++;
		}
		return true;
	}

	public void _0023_003DzSZ0NwQM_003D(uint _0023_003Dzt_m8zV0_003D)
	{
		uint item = _0023_003Dz14lzA48_003D();
		Tuple<uint, uint> tuple = new Tuple<uint, uint>(_0023_003Dzt_m8zV0_003D, item);
		if (!_0023_003DzS0fEsyA_003D.ContainsKey(tuple.Item1))
		{
			_0023_003DzS0fEsyA_003D.Add(tuple.Item1, tuple.Item2);
			base._0023_003DzccHNBKidQXxY(_0023_003Dzt_m8zV0_003D);
		}
	}

	public override bool _0023_003DzccHNBKidQXxY(uint _0023_003Dzt_m8zV0_003D)
	{
		_0023_003DzSZ0NwQM_003D(_0023_003Dzt_m8zV0_003D);
		return true;
	}

	public uint _0023_003DzyzK8swU_003D(uint _0023_003Dzt_m8zV0_003D)
	{
		if (_0023_003DzS0fEsyA_003D.ContainsKey(_0023_003Dzt_m8zV0_003D))
		{
			_0023_003DzS0fEsyA_003D.TryGetValue(_0023_003Dzt_m8zV0_003D, out var value);
			return value;
		}
		return uint.MaxValue;
	}

	public bool _0023_003Dz8y9lXPc_003D(uint _0023_003Dzt_m8zV0_003D)
	{
		return _0023_003DzyzK8swU_003D(_0023_003Dzt_m8zV0_003D) != uint.MaxValue;
	}

	public uint _0023_003DzqTiQqGs_003D(uint _0023_003Dzt_m8zV0_003D)
	{
		uint num = _0023_003DzyzK8swU_003D(_0023_003Dzt_m8zV0_003D);
		if (num == uint.MaxValue)
		{
			return _0023_003Dzk64JNOo_003D();
		}
		return _0023_003DzIBRMQdw_003D() + num;
	}

	public bool _0023_003Dz7lC5yqQvCGUoiakoBRZLNSU_003D(_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D _0023_003Dz77g161c_003D)
	{
		_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D2 = this;
		_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D3 = _0023_003Dz77g161c_003D;
		if (_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D3._0023_003Dz14lzA48_003D() < _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D2._0023_003Dz14lzA48_003D())
		{
			_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D obj = _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D2;
			_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D2 = _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D3;
			_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D3 = obj;
		}
		uint num = _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D2._0023_003DzIBRMQdw_003D();
		for (uint num2 = _0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D2._0023_003Dzk64JNOo_003D(); num < num2; num++)
		{
			if (_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D3._0023_003Dz8y9lXPc_003D(_0023_003Dz5m8ryJrPlqyoBiNzN0axRPMXqSpTzERd_g_003D_003D2._0023_003DzYBaDcXE_003D(num)))
			{
				return true;
			}
		}
		return false;
	}
}
