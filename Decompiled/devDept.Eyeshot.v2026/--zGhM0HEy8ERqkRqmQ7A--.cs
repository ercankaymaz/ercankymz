using System;
using System.Collections.Generic;

internal sealed class _0023_003DzGhM0HEy8ERqkRqmQ7A_003D_003D
{
	private double _0023_003DzS27lGHaOqn6a;

	private double _0023_003DzhktSWYCtl2H8;

	private double _0023_003DzEmT2suQceJrU;

	private double _0023_003Dz_0024K0e8DFzowFX;

	private uint _0023_003DzI_0024kcqcPjUnYF;

	private uint _0023_003Dz35dqAEgmjYB3;

	private uint[] _0023_003DzDLP_0024sgQUtP1t;

	private uint _0023_003Dzh5Ni86kh_klZ;

	private double[] _0023_003DzeCg54sNSoLDt;

	private uint[] _0023_003DzOR4AhirKDLNL;

	private uint _0023_003DzzT4P4GNblSep;

	public static uint _0023_003Dzl_0024yBDWU_003D;

	public _0023_003DzGhM0HEy8ERqkRqmQ7A_003D_003D()
	{
	}

	public _0023_003DzGhM0HEy8ERqkRqmQ7A_003D_003D(uint _0023_003DzIjbKWmB8CuC7)
	{
		_0023_003DzI_0024kcqcPjUnYF = _0023_003DzIjbKWmB8CuC7;
		uint num = _0023_003DzIjbKWmB8CuC7;
		uint num2 = _0023_003DzIjbKWmB8CuC7;
		_0023_003Dzl_0024yBDWU_003D = 16u;
		_0023_003Dz35dqAEgmjYB3 = _0023_003DzK7xF5tQPcxVt(_0023_003DzIjbKWmB8CuC7);
		_0023_003DzDLP_0024sgQUtP1t = new uint[_0023_003Dz35dqAEgmjYB3];
		_0023_003DzDLP_0024sgQUtP1t[0] = num * 4;
		uint num3 = 1u;
		do
		{
			num = (uint)Math.Ceiling((float)num / (float)_0023_003Dzl_0024yBDWU_003D);
			num2 += num;
			_0023_003DzDLP_0024sgQUtP1t[num3] = num2 * 4;
			num3++;
		}
		while (num != 1);
		_0023_003Dzh5Ni86kh_klZ = num2;
		_0023_003DzeCg54sNSoLDt = new double[num2 * 4];
		_0023_003DzOR4AhirKDLNL = new uint[num2];
		_0023_003DzzT4P4GNblSep = 0u;
		_0023_003DzS27lGHaOqn6a = double.PositiveInfinity;
		_0023_003DzhktSWYCtl2H8 = double.PositiveInfinity;
		_0023_003DzEmT2suQceJrU = double.NegativeInfinity;
		_0023_003Dz_0024K0e8DFzowFX = double.NegativeInfinity;
	}

	public double _0023_003DzjTLb8o0_003D()
	{
		return _0023_003DzS27lGHaOqn6a;
	}

	public double _0023_003DzK8V8En8_003D()
	{
		return _0023_003DzhktSWYCtl2H8;
	}

	public double _0023_003DzgMKLm6g_003D()
	{
		return _0023_003DzEmT2suQceJrU;
	}

	public double _0023_003DzKKRScFA_003D()
	{
		return _0023_003Dz_0024K0e8DFzowFX;
	}

	public void _0023_003Dz1l0EiMs_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D)
	{
		uint num = _0023_003DzzT4P4GNblSep >> 2;
		_0023_003DzOR4AhirKDLNL[num] = num;
		_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = _0023_003DzjTLb8o0_003D;
		_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = _0023_003DzK8V8En8_003D;
		_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = _0023_003DzgMKLm6g_003D;
		_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = _0023_003DzKKRScFA_003D;
		if (_0023_003DzjTLb8o0_003D < _0023_003DzS27lGHaOqn6a)
		{
			_0023_003DzS27lGHaOqn6a = _0023_003DzjTLb8o0_003D;
		}
		if (_0023_003DzK8V8En8_003D < _0023_003DzhktSWYCtl2H8)
		{
			_0023_003DzhktSWYCtl2H8 = _0023_003DzK8V8En8_003D;
		}
		if (_0023_003DzgMKLm6g_003D > _0023_003DzEmT2suQceJrU)
		{
			_0023_003DzEmT2suQceJrU = _0023_003DzgMKLm6g_003D;
		}
		if (_0023_003DzKKRScFA_003D > _0023_003Dz_0024K0e8DFzowFX)
		{
			_0023_003Dz_0024K0e8DFzowFX = _0023_003DzKKRScFA_003D;
		}
	}

	public void _0023_003DzUN0tEqo_003D()
	{
		if (_0023_003DzI_0024kcqcPjUnYF <= _0023_003Dzl_0024yBDWU_003D)
		{
			_0023_003DzOR4AhirKDLNL[_0023_003DzzT4P4GNblSep >> 2] = 0u;
			_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = _0023_003DzS27lGHaOqn6a;
			_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = _0023_003DzhktSWYCtl2H8;
			_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = _0023_003DzEmT2suQceJrU;
			_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = _0023_003Dz_0024K0e8DFzowFX;
			return;
		}
		double num = _0023_003DzEmT2suQceJrU - _0023_003DzS27lGHaOqn6a;
		double num2 = _0023_003Dz_0024K0e8DFzowFX - _0023_003DzhktSWYCtl2H8;
		uint[] array = new uint[_0023_003DzI_0024kcqcPjUnYF];
		uint num3 = 0u;
		for (uint num4 = 0u; num4 < _0023_003DzI_0024kcqcPjUnYF; num4++)
		{
			num3 = 4 * num4;
			double num5 = _0023_003DzeCg54sNSoLDt[num3++];
			double num6 = _0023_003DzeCg54sNSoLDt[num3++];
			double num7 = _0023_003DzeCg54sNSoLDt[num3++];
			double num8 = _0023_003DzeCg54sNSoLDt[num3++];
			uint _0023_003DzBJFJHwk_003D = (uint)Math.Floor(65535.0 * ((num5 + num7) / 2.0 - _0023_003DzS27lGHaOqn6a) / num);
			uint _0023_003Dz40R7bAU_003D = (uint)Math.Floor(65535.0 * ((num6 + num8) / 2.0 - _0023_003DzhktSWYCtl2H8) / num2);
			array[num4] = _0023_003DzSMQ6_0024BMzYvFAEZJtjA_003D_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		}
		_0023_003DzoQcRoMY_003D(array, _0023_003DzeCg54sNSoLDt, ref _0023_003DzOR4AhirKDLNL, 0u, _0023_003DzI_0024kcqcPjUnYF - 1);
		num3 = 0u;
		for (uint num9 = 0u; num9 < _0023_003Dz35dqAEgmjYB3 - 1; num9++)
		{
			uint num10 = _0023_003DzDLP_0024sgQUtP1t[num9];
			while (num3 < num10)
			{
				double num11 = double.PositiveInfinity;
				double num12 = double.PositiveInfinity;
				double num13 = double.NegativeInfinity;
				double num14 = double.NegativeInfinity;
				uint num15 = num3;
				for (uint num16 = 0u; num16 < _0023_003Dzl_0024yBDWU_003D; num16++)
				{
					if (num3 >= num10)
					{
						break;
					}
					double num17 = _0023_003DzeCg54sNSoLDt[num3++];
					double num18 = _0023_003DzeCg54sNSoLDt[num3++];
					double num19 = _0023_003DzeCg54sNSoLDt[num3++];
					double num20 = _0023_003DzeCg54sNSoLDt[num3++];
					if (num17 < num11)
					{
						num11 = num17;
					}
					if (num18 < num12)
					{
						num12 = num18;
					}
					if (num19 > num13)
					{
						num13 = num19;
					}
					if (num20 > num14)
					{
						num14 = num20;
					}
				}
				_0023_003DzOR4AhirKDLNL[_0023_003DzzT4P4GNblSep >> 2] = num15;
				_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = num11;
				_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = num12;
				_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = num13;
				_0023_003DzeCg54sNSoLDt[_0023_003DzzT4P4GNblSep++] = num14;
			}
		}
	}

	internal void _0023_003DzMuusKR5KrHqN(List<uint> _0023_003Dzbuq9_0024dwVCvSX, Dictionary<uint, List<_0023_003DzC2sCSJn2Q7FJ>> _0023_003DzUtcxhAY5kVjF)
	{
		uint num = 4 * _0023_003Dzh5Ni86kh_klZ - 4;
		uint num2 = _0023_003Dz35dqAEgmjYB3 - 1;
		List<uint> list = new List<uint>();
		list.Capacity = 16;
		bool flag = false;
		uint _0023_003Dzesp9usQ_003D = 0u;
		uint _0023_003Dzg_mSyzCWCG9x = uint.MaxValue;
		uint _0023_003DzFra0eQQ_003D = 0u;
		while (!flag)
		{
			uint num3 = Math.Min(num + _0023_003Dzl_0024yBDWU_003D * 4, _0023_003DzDLP_0024sgQUtP1t[num2]);
			for (uint num4 = num; num4 < num3; num4 += 4)
			{
				uint item = _0023_003DzOR4AhirKDLNL[num4 >> 2];
				if (!_0023_003Dzo7HoprY_003D(_0023_003Dzbuq9_0024dwVCvSX, _0023_003DzUtcxhAY5kVjF, num2, _0023_003DzeCg54sNSoLDt[num4], _0023_003DzeCg54sNSoLDt[num4 + 1], _0023_003DzeCg54sNSoLDt[num4 + 2], _0023_003DzeCg54sNSoLDt[num4 + 3], ref _0023_003Dzg_mSyzCWCG9x, ref _0023_003Dzesp9usQ_003D, ref _0023_003DzFra0eQQ_003D))
				{
					return;
				}
				if (num >= _0023_003DzI_0024kcqcPjUnYF * 4)
				{
					list.Add(item);
					list.Add(num2 - 1);
				}
			}
			if (list.Count > 1)
			{
				num2 = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
				num = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
			}
			else
			{
				flag = true;
			}
		}
	}

	internal void _0023_003DzyjbV_00243mYBaW7(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_Pbwmxzwl0tt, List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D> _0023_003DzOkHnHgY_003D, HashSet<Tuple<uint, uint>> _0023_003Dz2Q2ghA5JTkWB)
	{
		for (uint num = 0u; num < _0023_003DzDLP_0024sgQUtP1t[0] && _0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D._0023_003Dzo7HoprY_003D(_0023_003Dz_Pbwmxzwl0tt, this, _0023_003DzOR4AhirKDLNL[num >> 2], _0023_003DzeCg54sNSoLDt[num], _0023_003DzeCg54sNSoLDt[num + 1], _0023_003DzeCg54sNSoLDt[num + 2], _0023_003DzeCg54sNSoLDt[num + 3], _0023_003DzOkHnHgY_003D, _0023_003Dz2Q2ghA5JTkWB); num += 4)
		{
		}
	}

	public void _0023_003DzyjbV_00243mYBaW7(List<uint> _0023_003DznAsnXqw_003D)
	{
		for (uint num = 0u; num < _0023_003DzDLP_0024sgQUtP1t[0] && _0023_003Dzo7HoprY_003D(_0023_003DznAsnXqw_003D, _0023_003DzOR4AhirKDLNL[num >> 2], _0023_003DzeCg54sNSoLDt[num], _0023_003DzeCg54sNSoLDt[num + 1], _0023_003DzeCg54sNSoLDt[num + 2], _0023_003DzeCg54sNSoLDt[num + 3]); num += 4)
		{
		}
	}

	public void _0023_003Dz_rSAXlc_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzZE9fb_0024M_003D)
	{
		_0023_003DzdD8_00246dQ_003D(_0023_003DzjTLb8o0_003D, _0023_003DzK8V8En8_003D, _0023_003DzgMKLm6g_003D, _0023_003DzKKRScFA_003D, _0023_003DzZE9fb_0024M_003D);
	}

	public void _0023_003Dz_rSAXlc_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzZE9fb_0024M_003D, List<uint> _0023_003DzoIXQ5WI_003D)
	{
		_0023_003DzdD8_00246dQ_003D(_0023_003DzjTLb8o0_003D, _0023_003DzK8V8En8_003D, _0023_003DzgMKLm6g_003D, _0023_003DzKKRScFA_003D, _0023_003DzZE9fb_0024M_003D, _0023_003DzoIXQ5WI_003D);
	}

	public void _0023_003DzdD8_00246dQ_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzZE9fb_0024M_003D)
	{
		List<uint> list = new List<uint>();
		list.Capacity = 16;
		_0023_003DzdD8_00246dQ_003D(_0023_003DzjTLb8o0_003D, _0023_003DzK8V8En8_003D, _0023_003DzgMKLm6g_003D, _0023_003DzKKRScFA_003D, _0023_003DzZE9fb_0024M_003D, list);
	}

	public void _0023_003DzdD8_00246dQ_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzZE9fb_0024M_003D, bool _0023_003Dzesp9usQ_003D)
	{
		List<uint> list = new List<uint>();
		list.Capacity = 16;
		_0023_003DzdD8_00246dQ_003D(_0023_003DzjTLb8o0_003D, _0023_003DzK8V8En8_003D, _0023_003DzgMKLm6g_003D, _0023_003DzKKRScFA_003D, _0023_003DzZE9fb_0024M_003D, list, _0023_003Dzesp9usQ_003D);
	}

	public void _0023_003DzdD8_00246dQ_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzZE9fb_0024M_003D, List<uint> _0023_003DzoIXQ5WI_003D)
	{
		uint num = 4 * _0023_003Dzh5Ni86kh_klZ - 4;
		uint num2 = _0023_003Dz35dqAEgmjYB3 - 1;
		_0023_003DzoIXQ5WI_003D.Clear();
		bool flag = false;
		while (!flag)
		{
			uint num3 = Math.Min(num + _0023_003Dzl_0024yBDWU_003D * 4, _0023_003DzDLP_0024sgQUtP1t[num2]);
			for (uint num4 = num; num4 < num3; num4 += 4)
			{
				uint num5 = _0023_003DzOR4AhirKDLNL[num4 >> 2];
				if (_0023_003DzgMKLm6g_003D < _0023_003DzeCg54sNSoLDt[num4] || _0023_003DzKKRScFA_003D < _0023_003DzeCg54sNSoLDt[num4 + 1] || _0023_003DzjTLb8o0_003D > _0023_003DzeCg54sNSoLDt[num4 + 2] || _0023_003DzK8V8En8_003D > _0023_003DzeCg54sNSoLDt[num4 + 3])
				{
					continue;
				}
				if (num < _0023_003DzI_0024kcqcPjUnYF * 4)
				{
					flag = !_0023_003Dzo7HoprY_003D(_0023_003DzZE9fb_0024M_003D, num5);
					if (flag)
					{
						break;
					}
				}
				else
				{
					_0023_003DzoIXQ5WI_003D.Add(num5);
					_0023_003DzoIXQ5WI_003D.Add(num2 - 1);
				}
			}
			if (_0023_003DzoIXQ5WI_003D.Count > 1)
			{
				num2 = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
				num = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
			}
			else
			{
				flag = true;
			}
		}
	}

	internal void _0023_003DzdD8_00246dQ_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzoIXQ5WI_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_Pbwmxzwl0tt, _0023_003DzcQiRB3Mv_00246WF _0023_003DzlY77YgY_003D, ref bool _0023_003DzGfme77rcLA8_0024, double _0023_003DzsVw1i9LkTBtX)
	{
		uint num = 4 * _0023_003Dzh5Ni86kh_klZ - 4;
		uint num2 = _0023_003Dz35dqAEgmjYB3 - 1;
		_0023_003DzoIXQ5WI_003D.Clear();
		bool flag = false;
		while (!flag)
		{
			uint num3 = Math.Min(num + _0023_003Dzl_0024yBDWU_003D * 4, _0023_003DzDLP_0024sgQUtP1t[num2]);
			for (uint num4 = num; num4 < num3; num4 += 4)
			{
				uint num5 = _0023_003DzOR4AhirKDLNL[num4 >> 2];
				if (_0023_003DzgMKLm6g_003D < _0023_003DzeCg54sNSoLDt[num4] || _0023_003DzKKRScFA_003D < _0023_003DzeCg54sNSoLDt[num4 + 1] || _0023_003DzjTLb8o0_003D > _0023_003DzeCg54sNSoLDt[num4 + 2] || _0023_003DzK8V8En8_003D > _0023_003DzeCg54sNSoLDt[num4 + 3])
				{
					continue;
				}
				if (num < _0023_003DzI_0024kcqcPjUnYF * 4)
				{
					flag = !_0023_003Dzjpa4idEx_0024nUarOiwkxe35rs_003D._0023_003Dzo7HoprY_003D(_0023_003Dz_Pbwmxzwl0tt, _0023_003DzlY77YgY_003D, ref _0023_003DzGfme77rcLA8_0024, _0023_003DzsVw1i9LkTBtX, num5);
					if (flag)
					{
						break;
					}
				}
				else
				{
					_0023_003DzoIXQ5WI_003D.Add(num5);
					_0023_003DzoIXQ5WI_003D.Add(num2 - 1);
				}
			}
			if (_0023_003DzoIXQ5WI_003D.Count > 1)
			{
				num2 = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
				num = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
			}
			else
			{
				flag = true;
			}
		}
	}

	internal void _0023_003DzdD8_00246dQ_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzoIXQ5WI_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzffqPLNQ_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003Dz5Azd7L8_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz36ohu294GzAl, ref bool _0023_003Dzf_0024RkgMfvKcdU)
	{
		uint num = 4 * _0023_003Dzh5Ni86kh_klZ - 4;
		uint num2 = _0023_003Dz35dqAEgmjYB3 - 1;
		_0023_003DzoIXQ5WI_003D.Clear();
		bool flag = false;
		while (!flag)
		{
			uint num3 = Math.Min(num + _0023_003Dzl_0024yBDWU_003D * 4, _0023_003DzDLP_0024sgQUtP1t[num2]);
			for (uint num4 = num; num4 < num3; num4 += 4)
			{
				uint num5 = _0023_003DzOR4AhirKDLNL[num4 >> 2];
				if (_0023_003DzgMKLm6g_003D < _0023_003DzeCg54sNSoLDt[num4] || _0023_003DzKKRScFA_003D < _0023_003DzeCg54sNSoLDt[num4 + 1] || _0023_003DzjTLb8o0_003D > _0023_003DzeCg54sNSoLDt[num4 + 2] || _0023_003DzK8V8En8_003D > _0023_003DzeCg54sNSoLDt[num4 + 3])
				{
					continue;
				}
				if (num < _0023_003DzI_0024kcqcPjUnYF * 4)
				{
					flag = !_0023_003Dzjpa4idEx_0024nUarOiwkxe35rs_003D._0023_003Dzo7HoprY_003D(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, ref _0023_003Dzf_0024RkgMfvKcdU, _0023_003Dz36ohu294GzAl, num5);
					if (flag)
					{
						break;
					}
				}
				else
				{
					_0023_003DzoIXQ5WI_003D.Add(num5);
					_0023_003DzoIXQ5WI_003D.Add(num2 - 1);
				}
			}
			if (_0023_003DzoIXQ5WI_003D.Count > 1)
			{
				num2 = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
				num = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
			}
			else
			{
				flag = true;
			}
		}
	}

	internal void _0023_003DzdD8_00246dQ_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzoIXQ5WI_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_Pbwmxzwl0tt, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzffqPLNQ_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003Dz5Azd7L8_003D, List<_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D> _0023_003DzOkHnHgY_003D, HashSet<Tuple<uint, uint>> _0023_003Dz2Q2ghA5JTkWB, uint _0023_003Dz437_00244ak_003D, uint _0023_003DzTSeNR8Q_003D)
	{
		uint num = 4 * _0023_003Dzh5Ni86kh_klZ - 4;
		uint num2 = _0023_003Dz35dqAEgmjYB3 - 1;
		_0023_003DzoIXQ5WI_003D.Clear();
		bool flag = false;
		while (!flag)
		{
			uint num3 = Math.Min(num + _0023_003Dzl_0024yBDWU_003D * 4, _0023_003DzDLP_0024sgQUtP1t[num2]);
			for (uint num4 = num; num4 < num3; num4 += 4)
			{
				uint num5 = _0023_003DzOR4AhirKDLNL[num4 >> 2];
				if (_0023_003DzgMKLm6g_003D < _0023_003DzeCg54sNSoLDt[num4] || _0023_003DzKKRScFA_003D < _0023_003DzeCg54sNSoLDt[num4 + 1] || _0023_003DzjTLb8o0_003D > _0023_003DzeCg54sNSoLDt[num4 + 2] || _0023_003DzK8V8En8_003D > _0023_003DzeCg54sNSoLDt[num4 + 3])
				{
					continue;
				}
				if (num < _0023_003DzI_0024kcqcPjUnYF * 4)
				{
					flag = !_0023_003Dz2rcayfGT7AB7QvHbG4wsJ_0_003D._0023_003DzKNkZ2_0024w_003D(_0023_003Dz_Pbwmxzwl0tt, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzOkHnHgY_003D, _0023_003Dz2Q2ghA5JTkWB, num5, _0023_003Dz437_00244ak_003D, _0023_003DzTSeNR8Q_003D);
					if (flag)
					{
						break;
					}
				}
				else
				{
					_0023_003DzoIXQ5WI_003D.Add(num5);
					_0023_003DzoIXQ5WI_003D.Add(num2 - 1);
				}
			}
			if (_0023_003DzoIXQ5WI_003D.Count > 1)
			{
				num2 = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
				num = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
			}
			else
			{
				flag = true;
			}
		}
	}

	public void _0023_003DzdD8_00246dQ_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzWlztEOZcMOof, int _0023_003Dzesp9usQ_003D)
	{
		uint num = 4 * _0023_003Dzh5Ni86kh_klZ - 4;
		uint num2 = _0023_003Dz35dqAEgmjYB3 - 1;
		_0023_003DzWlztEOZcMOof.Clear();
		bool flag = false;
		while (!flag)
		{
			uint num3 = Math.Min(num + _0023_003Dzl_0024yBDWU_003D * 4, _0023_003DzDLP_0024sgQUtP1t[num2]);
			for (uint num4 = num; num4 < num3; num4 += 4)
			{
				uint num5 = _0023_003DzOR4AhirKDLNL[num4 >> 2];
				if (_0023_003DzgMKLm6g_003D < _0023_003DzeCg54sNSoLDt[num4] || _0023_003DzKKRScFA_003D < _0023_003DzeCg54sNSoLDt[num4 + 1] || _0023_003DzjTLb8o0_003D > _0023_003DzeCg54sNSoLDt[num4 + 2] || _0023_003DzK8V8En8_003D > _0023_003DzeCg54sNSoLDt[num4 + 3])
				{
					continue;
				}
				if (num < _0023_003DzI_0024kcqcPjUnYF * 4)
				{
					flag = !_0023_003Dzo7HoprY_003D(_0023_003DzWlztEOZcMOof, num5);
					if (flag)
					{
						break;
					}
				}
				else
				{
					_0023_003DzWlztEOZcMOof.Add(num5);
					_0023_003DzWlztEOZcMOof.Add(num2 - 1);
				}
			}
			if (_0023_003DzWlztEOZcMOof.Count > 1)
			{
				num2 = _0023_003DzWlztEOZcMOof[_0023_003DzWlztEOZcMOof.Count - 1];
				_0023_003DzWlztEOZcMOof.RemoveAt(_0023_003DzWlztEOZcMOof.Count - 1);
				num = _0023_003DzWlztEOZcMOof[_0023_003DzWlztEOZcMOof.Count - 1];
				_0023_003DzWlztEOZcMOof.RemoveAt(_0023_003DzWlztEOZcMOof.Count - 1);
			}
			else
			{
				flag = true;
			}
		}
	}

	public void _0023_003DzdD8_00246dQ_003D(double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, List<uint> _0023_003DzZE9fb_0024M_003D, List<uint> _0023_003DzoIXQ5WI_003D, bool _0023_003Dzesp9usQ_003D)
	{
		uint num = 4 * _0023_003Dzh5Ni86kh_klZ - 4;
		uint num2 = _0023_003Dz35dqAEgmjYB3 - 1;
		_0023_003DzoIXQ5WI_003D.Clear();
		bool flag = false;
		while (!flag)
		{
			uint num3 = Math.Min(num + _0023_003Dzl_0024yBDWU_003D * 4, _0023_003DzDLP_0024sgQUtP1t[num2]);
			for (uint num4 = num; num4 < num3; num4 += 4)
			{
				uint num5 = _0023_003DzOR4AhirKDLNL[num4 >> 2];
				if (_0023_003DzgMKLm6g_003D < _0023_003DzeCg54sNSoLDt[num4] || _0023_003DzKKRScFA_003D < _0023_003DzeCg54sNSoLDt[num4 + 1] || _0023_003DzjTLb8o0_003D > _0023_003DzeCg54sNSoLDt[num4 + 2] || _0023_003DzK8V8En8_003D > _0023_003DzeCg54sNSoLDt[num4 + 3])
				{
					continue;
				}
				if (num < _0023_003DzI_0024kcqcPjUnYF * 4)
				{
					flag = !_0023_003Dzo7HoprY_003D(num5, _0023_003DzZE9fb_0024M_003D);
					if (flag)
					{
						break;
					}
				}
				else
				{
					_0023_003DzoIXQ5WI_003D.Add(num5);
					_0023_003DzoIXQ5WI_003D.Add(num2 - 1);
				}
			}
			if (_0023_003DzoIXQ5WI_003D.Count > 1)
			{
				num2 = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
				num = _0023_003DzoIXQ5WI_003D[_0023_003DzoIXQ5WI_003D.Count - 1];
				_0023_003DzoIXQ5WI_003D.RemoveAt(_0023_003DzoIXQ5WI_003D.Count - 1);
			}
			else
			{
				flag = true;
			}
		}
	}

	public static bool _0023_003Dzo7HoprY_003D(List<uint> _0023_003DzWlztEOZcMOof, uint _0023_003DzyzK8swU_003D, double _0023_003DzJE4kkpk_003D, double _0023_003Dz0ImwsP3eB6i9, double _0023_003DzFlpXugJ_0024ZfLU, double _0023_003DzXnodJvaL6Unq)
	{
		_0023_003DzWlztEOZcMOof.Add(_0023_003DzyzK8swU_003D);
		return true;
	}

	public static bool _0023_003Dzo7HoprY_003D(List<uint> _0023_003DzWlztEOZcMOof, uint _0023_003DzyzK8swU_003D)
	{
		_0023_003DzWlztEOZcMOof.Add(_0023_003DzyzK8swU_003D);
		return true;
	}

	public static bool _0023_003Dzo7HoprY_003D(uint _0023_003DzyzK8swU_003D, List<uint> _0023_003DzWlztEOZcMOof)
	{
		_0023_003DzWlztEOZcMOof.Add(_0023_003DzyzK8swU_003D);
		return _0023_003DzWlztEOZcMOof.Count != 2;
	}

	internal static bool _0023_003Dzo7HoprY_003D(List<uint> _0023_003Dzbuq9_0024dwVCvSX, Dictionary<uint, List<_0023_003DzC2sCSJn2Q7FJ>> _0023_003DzUtcxhAY5kVjF, uint _0023_003DzfNi7d4A_003D, double _0023_003DzjTLb8o0_003D, double _0023_003DzK8V8En8_003D, double _0023_003DzgMKLm6g_003D, double _0023_003DzKKRScFA_003D, ref uint _0023_003Dzg_mSyzCWCG9x, ref uint _0023_003Dzesp9usQ_003D, ref uint _0023_003DzFra0eQQ_003D)
	{
		if (_0023_003Dzg_mSyzCWCG9x != _0023_003DzfNi7d4A_003D)
		{
			_0023_003Dzg_mSyzCWCG9x = _0023_003DzfNi7d4A_003D;
			_0023_003Dzbuq9_0024dwVCvSX.Add(1u);
			_0023_003DzFra0eQQ_003D = _0023_003Dzesp9usQ_003D++;
		}
		else
		{
			_0023_003Dzbuq9_0024dwVCvSX[_0023_003Dzbuq9_0024dwVCvSX.Count - 1]++;
		}
		if (_0023_003DzUtcxhAY5kVjF.ContainsKey(_0023_003DzFra0eQQ_003D))
		{
			_0023_003DzUtcxhAY5kVjF[(uint)(_0023_003DzUtcxhAY5kVjF.Count - 1)].Add(new _0023_003DzC2sCSJn2Q7FJ(_0023_003DzjTLb8o0_003D, _0023_003DzK8V8En8_003D, _0023_003DzgMKLm6g_003D, _0023_003DzKKRScFA_003D));
		}
		else
		{
			_0023_003DzUtcxhAY5kVjF.Add(_0023_003DzFra0eQQ_003D, new List<_0023_003DzC2sCSJn2Q7FJ>
			{
				new _0023_003DzC2sCSJn2Q7FJ(_0023_003DzjTLb8o0_003D, _0023_003DzK8V8En8_003D, _0023_003DzgMKLm6g_003D, _0023_003DzKKRScFA_003D)
			});
		}
		return true;
	}

	public static uint _0023_003DzSMQ6_0024BMzYvFAEZJtjA_003D_003D(uint _0023_003DzBJFJHwk_003D, uint _0023_003Dz40R7bAU_003D)
	{
		uint num = _0023_003DzBJFJHwk_003D ^ _0023_003Dz40R7bAU_003D;
		uint num2 = 0xFFFF ^ num;
		uint num3 = 0xFFFF ^ (_0023_003DzBJFJHwk_003D | _0023_003Dz40R7bAU_003D);
		uint num4 = _0023_003DzBJFJHwk_003D & (_0023_003Dz40R7bAU_003D ^ 0xFFFF);
		uint num5 = num | (num2 >> 1);
		uint num6 = (num >> 1) ^ num;
		uint num7 = (num3 >> 1) ^ (num2 & (num4 >> 1)) ^ num3;
		uint num8 = (num & (num3 >> 1)) ^ (num4 >> 1) ^ num4;
		num = num5;
		num2 = num6;
		num3 = num7;
		num4 = num8;
		num5 = (num & (num >> 2)) ^ (num2 & (num2 >> 2));
		num6 = (num & (num2 >> 2)) ^ (num2 & ((num ^ num2) >> 2));
		num7 ^= (num & (num3 >> 2)) ^ (num2 & (num4 >> 2));
		num8 ^= (num2 & (num3 >> 2)) ^ ((num ^ num2) & (num4 >> 2));
		num = num5;
		num2 = num6;
		num3 = num7;
		num4 = num8;
		num5 = (num & (num >> 4)) ^ (num2 & (num2 >> 4));
		num6 = (num & (num2 >> 4)) ^ (num2 & ((num ^ num2) >> 4));
		num7 ^= (num & (num3 >> 4)) ^ (num2 & (num4 >> 4));
		num8 ^= (num2 & (num3 >> 4)) ^ ((num ^ num2) & (num4 >> 4));
		num = num5;
		num2 = num6;
		num3 = num7;
		num4 = num8;
		num7 ^= (num & (num3 >> 8)) ^ (num2 & (num4 >> 8));
		num8 ^= (num2 & (num3 >> 8)) ^ ((num ^ num2) & (num4 >> 8));
		num = num7 ^ (num7 >> 1);
		num2 = num8 ^ (num8 >> 1);
		uint num9 = _0023_003DzBJFJHwk_003D ^ _0023_003Dz40R7bAU_003D;
		uint num10 = num2 | (0xFFFF ^ (num9 | num));
		num9 = (num9 | (num9 << 8)) & 0xFF00FF;
		num9 = (num9 | (num9 << 4)) & 0xF0F0F0F;
		num9 = (num9 | (num9 << 2)) & 0x33333333;
		num9 = (num9 | (num9 << 1)) & 0x55555555;
		uint num11 = (num10 | (num10 << 8)) & 0xFF00FF;
		uint num12 = (num11 | (num11 << 4)) & 0xF0F0F0F;
		uint num13 = (num12 | (num12 << 2)) & 0x33333333;
		return (((num13 | (num13 << 1)) & 0x55555555) << 1) | num9;
	}

	private static uint _0023_003DzK7xF5tQPcxVt(uint _0023_003DzIjbKWmB8CuC7)
	{
		uint num = _0023_003DzIjbKWmB8CuC7;
		uint num2 = 1u;
		do
		{
			num = (uint)Math.Ceiling((float)num / (float)_0023_003Dzl_0024yBDWU_003D);
			num2++;
		}
		while (num != 1);
		return num2;
	}

	private static void _0023_003DzoQcRoMY_003D(uint[] _0023_003DzHSO_00246A0_003D, double[] _0023_003DzFE_0024TcbDmO66X, ref uint[] _0023_003DzDPPdnUk_003D, uint _0023_003DzeMBeuAQ_003D, uint _0023_003DznYtQKck_003D)
	{
		if (_0023_003DzeMBeuAQ_003D / _0023_003Dzl_0024yBDWU_003D >= _0023_003DznYtQKck_003D / _0023_003Dzl_0024yBDWU_003D)
		{
			return;
		}
		uint num = _0023_003DzHSO_00246A0_003D[_0023_003DzeMBeuAQ_003D + _0023_003DznYtQKck_003D >> 1];
		uint num2 = _0023_003DzeMBeuAQ_003D - 1;
		uint num3 = _0023_003DznYtQKck_003D + 1;
		while (true)
		{
			num2++;
			if (_0023_003DzHSO_00246A0_003D[num2] >= num)
			{
				do
				{
					num3--;
				}
				while (_0023_003DzHSO_00246A0_003D[num3] > num);
				if (num2 >= num3)
				{
					break;
				}
				_0023_003Dzxd6BoZ4_003D(_0023_003DzHSO_00246A0_003D, _0023_003DzFE_0024TcbDmO66X, _0023_003DzDPPdnUk_003D, num2, num3);
			}
		}
		_0023_003DzoQcRoMY_003D(_0023_003DzHSO_00246A0_003D, _0023_003DzFE_0024TcbDmO66X, ref _0023_003DzDPPdnUk_003D, _0023_003DzeMBeuAQ_003D, num3);
		_0023_003DzoQcRoMY_003D(_0023_003DzHSO_00246A0_003D, _0023_003DzFE_0024TcbDmO66X, ref _0023_003DzDPPdnUk_003D, num3 + 1, _0023_003DznYtQKck_003D);
	}

	private static void _0023_003Dzxd6BoZ4_003D(uint[] _0023_003DzHSO_00246A0_003D, double[] _0023_003DzFE_0024TcbDmO66X, uint[] _0023_003DzDPPdnUk_003D, uint _0023_003Dz437_00244ak_003D, uint _0023_003DzTSeNR8Q_003D)
	{
		uint num = _0023_003DzHSO_00246A0_003D[_0023_003Dz437_00244ak_003D];
		_0023_003DzHSO_00246A0_003D[_0023_003Dz437_00244ak_003D] = _0023_003DzHSO_00246A0_003D[_0023_003DzTSeNR8Q_003D];
		_0023_003DzHSO_00246A0_003D[_0023_003DzTSeNR8Q_003D] = num;
		uint num2 = 4 * _0023_003Dz437_00244ak_003D;
		uint num3 = 4 * _0023_003DzTSeNR8Q_003D;
		double num4 = _0023_003DzFE_0024TcbDmO66X[num2];
		double num5 = _0023_003DzFE_0024TcbDmO66X[num2 + 1];
		double num6 = _0023_003DzFE_0024TcbDmO66X[num2 + 2];
		double num7 = _0023_003DzFE_0024TcbDmO66X[num2 + 3];
		_0023_003DzFE_0024TcbDmO66X[num2] = _0023_003DzFE_0024TcbDmO66X[num3];
		_0023_003DzFE_0024TcbDmO66X[num2 + 1] = _0023_003DzFE_0024TcbDmO66X[num3 + 1];
		_0023_003DzFE_0024TcbDmO66X[num2 + 2] = _0023_003DzFE_0024TcbDmO66X[num3 + 2];
		_0023_003DzFE_0024TcbDmO66X[num2 + 3] = _0023_003DzFE_0024TcbDmO66X[num3 + 3];
		_0023_003DzFE_0024TcbDmO66X[num3] = num4;
		_0023_003DzFE_0024TcbDmO66X[num3 + 1] = num5;
		_0023_003DzFE_0024TcbDmO66X[num3 + 2] = num6;
		_0023_003DzFE_0024TcbDmO66X[num3 + 3] = num7;
		uint num8 = _0023_003DzDPPdnUk_003D[_0023_003Dz437_00244ak_003D];
		_0023_003DzDPPdnUk_003D[_0023_003Dz437_00244ak_003D] = _0023_003DzDPPdnUk_003D[_0023_003DzTSeNR8Q_003D];
		_0023_003DzDPPdnUk_003D[_0023_003DzTSeNR8Q_003D] = num8;
	}
}
