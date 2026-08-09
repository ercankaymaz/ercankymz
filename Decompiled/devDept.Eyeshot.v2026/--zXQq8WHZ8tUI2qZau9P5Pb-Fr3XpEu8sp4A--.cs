using System;
using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzXQq8WHZ8tUI2qZau9P5Pb_0024Fr3XpEu8sp4A_003D_003D
{
	private int _0023_003DzCySviCfxDlP4;

	private int _0023_003Dzu3GUhJZFFpv3;

	private int _0023_003Dz_eY3Y4c_003D;

	private int _0023_003Dz77g161c_003D;

	private int _0023_003DzkWkrR0ZjgTMi;

	private int _0023_003DzZ0t5Xg3NXJuB;

	private int _0023_003DzTycgamM_003D;

	private int _0023_003DzOaj8lfo_003D;

	private int _0023_003DzNwvwyPc_003D;

	private int _0023_003DzKbOSFCI_003D;

	private int _0023_003Dzx1VbofJoBCNi;

	private int _0023_003DzJUfcGJLxhTKi;

	private int _0023_003Dzv5CkNXOQp4mA;

	private _0023_003DzbL_0024qJHev5v1hOpN5SyjWUZ3saWa4 _0023_003Dz1v6oPQk_003D;

	private List<MNODE> _0023_003DzKQ4FD_00248_003D;

	internal _0023_003DzXQq8WHZ8tUI2qZau9P5Pb_0024Fr3XpEu8sp4A_003D_003D(List<MNODE> _0023_003Dzfqtprvo_003D)
	{
		_0023_003DzKQ4FD_00248_003D = _0023_003Dzfqtprvo_003D;
		_0023_003DzCySviCfxDlP4 = 0;
		_0023_003Dzu3GUhJZFFpv3 = 0;
		_0023_003Dz_eY3Y4c_003D = 0;
		_0023_003Dz77g161c_003D = 0;
		_0023_003DzkWkrR0ZjgTMi = 0;
		_0023_003DzZ0t5Xg3NXJuB = 0;
		_0023_003DzTycgamM_003D = 0;
		_0023_003DzOaj8lfo_003D = 0;
		_0023_003DzNwvwyPc_003D = 0;
		_0023_003DzKbOSFCI_003D = 0;
		_0023_003Dzx1VbofJoBCNi = 0;
		_0023_003DzJUfcGJLxhTKi = 0;
		_0023_003Dzv5CkNXOQp4mA = 0;
		_0023_003Dz1v6oPQk_003D = new _0023_003DzbL_0024qJHev5v1hOpN5SyjWUZ3saWa4();
	}

	internal int _0023_003DzKlS_0024RTSkHohzMAAySQ_003D_003D(Solid _0023_003DzcDEsV8s_003D, ref int _0023_003DzSkUy_T8_003D, int _0023_003DzkKfJheA_003D, int _0023_003DzoMNiNRw_003D, double _0023_003Dz6pajdGM_003D, double _0023_003DzkRSfKls1SLfn)
	{
		int num = _0023_003DzcYOEhcm_0024ARi_(_0023_003DzkKfJheA_003D, _0023_003DzoMNiNRw_003D, ref _0023_003DzSkUy_T8_003D, _0023_003DzCaPJP54_003D: true);
		for (int i = 0; i < num; i++)
		{
			Solid.Portion portion = new Solid.Portion();
			if (!_0023_003Dz27zQzqf2ysoF(portion, _0023_003DzkRSfKls1SLfn))
			{
				return 0;
			}
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion))
			{
				return 0;
			}
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion, _0023_003DzcDEsV8s_003D))
			{
				return 0;
			}
		}
		return num;
	}

	private bool _0023_003Dz27zQzqf2ysoF(Solid.Portion _0023_003Dz5Tpjxj5wp_0024R8, double _0023_003DzkRSfKls1SLfn)
	{
		if (_0023_003Dz77g161c_003D >= _0023_003DzOaj8lfo_003D - 1)
		{
			_0023_003Dz_eY3Y4c_003D = _0023_003Dz_eY3Y4c_003D + _0023_003DzNwvwyPc_003D - 1;
			_0023_003Dz77g161c_003D = _0023_003Dzu3GUhJZFFpv3;
			if (_0023_003Dz_eY3Y4c_003D >= _0023_003DzTycgamM_003D - 1)
			{
				return false;
			}
		}
		if (_0023_003DzOaj8lfo_003D == _0023_003DzKbOSFCI_003D)
		{
			_0023_003Dzv5CkNXOQp4mA = 1;
		}
		else
		{
			_0023_003Dzv5CkNXOQp4mA = _0023_003DzOaj8lfo_003D / (_0023_003DzKbOSFCI_003D - 1);
			if (_0023_003DzOaj8lfo_003D > _0023_003Dzv5CkNXOQp4mA * _0023_003DzKbOSFCI_003D - (_0023_003Dzv5CkNXOQp4mA - 1))
			{
				_0023_003Dzv5CkNXOQp4mA++;
			}
		}
		_0023_003Dz5Tpjxj5wp_0024R8.Id = _0023_003Dzx1VbofJoBCNi++;
		if (_0023_003Dz_eY3Y4c_003D + _0023_003DzNwvwyPc_003D < _0023_003DzTycgamM_003D)
		{
			_0023_003DzkWkrR0ZjgTMi = _0023_003Dz_eY3Y4c_003D + _0023_003DzNwvwyPc_003D;
		}
		else if ((_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D & 2) > 0)
		{
			_0023_003DzkWkrR0ZjgTMi = _0023_003DzTycgamM_003D - 1;
		}
		else
		{
			_0023_003DzkWkrR0ZjgTMi = _0023_003DzTycgamM_003D;
		}
		if (_0023_003Dz77g161c_003D + _0023_003DzKbOSFCI_003D < _0023_003DzOaj8lfo_003D)
		{
			_0023_003DzZ0t5Xg3NXJuB = _0023_003Dz77g161c_003D + _0023_003DzKbOSFCI_003D;
		}
		else if ((_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D & 8) > 0)
		{
			_0023_003DzZ0t5Xg3NXJuB = _0023_003DzOaj8lfo_003D - 1;
		}
		else
		{
			_0023_003DzZ0t5Xg3NXJuB = _0023_003DzOaj8lfo_003D;
		}
		int num = _0023_003DzkWkrR0ZjgTMi - _0023_003Dz_eY3Y4c_003D;
		int num2 = _0023_003DzZ0t5Xg3NXJuB - _0023_003Dz77g161c_003D;
		_0023_003DzE7QJd0IP7bADn_002432mQ_003D_003D(_0023_003Dz5Tpjxj5wp_0024R8, num, num2);
		int num3 = 0;
		for (int i = _0023_003Dz_eY3Y4c_003D; i < _0023_003DzkWkrR0ZjgTMi; i++)
		{
			int num4 = i * _0023_003DzOaj8lfo_003D + _0023_003Dz77g161c_003D;
			int num5 = _0023_003Dz77g161c_003D;
			while (num5 < _0023_003DzZ0t5Xg3NXJuB)
			{
				MNODE mNODE = _0023_003DzKQ4FD_00248_003D[num4 + (num5 - _0023_003Dz77g161c_003D)];
				_0023_003Dz5Tpjxj5wp_0024R8._vertices[num3] = new Point3D(mNODE.X, mNODE.Y, mNODE.Z);
				if (mNODE.num > 0 || mNODE.num < 0)
				{
					if (num5 == _0023_003DzZ0t5Xg3NXJuB - 1)
					{
						if (i != _0023_003DzkWkrR0ZjgTMi - 1 && ((mNODE.num & 0x4000) > 0 || (mNODE.num & 0x4000) < 0))
						{
							int num6 = (num5 - _0023_003Dz77g161c_003D + 1) * 2 - 1 + (2 * num2 - 1) * (i - _0023_003Dz_eY3Y4c_003D);
							_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num6].Type |= 1;
						}
					}
					else if (i != _0023_003DzkWkrR0ZjgTMi - 1)
					{
						if ((mNODE.num & 0x8000) > 0 || (mNODE.num & 0x8000) < 0)
						{
							int num6 = (num5 - _0023_003Dz77g161c_003D + 1) * 2 + (2 * num2 - 1) * (i - _0023_003Dz_eY3Y4c_003D);
							_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num6].Type |= 1;
						}
						if ((mNODE.num & 0x4000) > 0 || (mNODE.num & 0x4000) < 0)
						{
							int num6 = (num5 - _0023_003Dz77g161c_003D + 1) * 2 - 1 + (2 * num2 - 1) * (i - _0023_003Dz_eY3Y4c_003D);
							_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num6].Type |= 1;
						}
					}
					else if ((mNODE.num & 0x8000) > 0 || (mNODE.num & 0x8000) < 0)
					{
						int num6 = num5 - _0023_003Dz77g161c_003D + 1 + (2 * num2 - 1) * (i - _0023_003Dz_eY3Y4c_003D);
						_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num6].Type |= 1;
					}
				}
				num5++;
				num3++;
			}
		}
		_0023_003Dz5Tpjxj5wp_0024R8.vertexCount = num3;
		int num7 = 0;
		if (_0023_003Dz_eY3Y4c_003D == 1 && (_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D & 1) > 0)
		{
			num7 = 1;
			_0023_003DzYnNdSUVevLPe(_0023_003Dz5Tpjxj5wp_0024R8, num, num2, _0023_003DzCaPJP54_003D: true);
		}
		if (_0023_003DzkWkrR0ZjgTMi == _0023_003DzTycgamM_003D - 1 && (_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D & 2) > 0)
		{
			num7 |= 2;
			_0023_003DzlvtZwrSNQzpd(_0023_003Dz5Tpjxj5wp_0024R8, num, num2, _0023_003DzCaPJP54_003D: true);
		}
		if ((_0023_003DzTycgamM_003D == _0023_003DzNwvwyPc_003D || _0023_003DzOaj8lfo_003D == _0023_003DzKbOSFCI_003D) && _0023_003Dzkuc_KOdXPr_0024x(_0023_003Dz5Tpjxj5wp_0024R8, num, num2, num7, _0023_003DzkRSfKls1SLfn))
		{
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DztDdwD3iU3oOP(_0023_003Dz5Tpjxj5wp_0024R8))
			{
				return false;
			}
			_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_8JqadwXrdJr(_0023_003Dz5Tpjxj5wp_0024R8);
		}
		_0023_003Dz77g161c_003D = _0023_003Dz77g161c_003D + _0023_003DzKbOSFCI_003D - 1;
		return true;
	}

	private bool _0023_003Dzkuc_KOdXPr_0024x(Solid.Portion _0023_003Dz5Tpjxj5wp_0024R8, int _0023_003DzNwvwyPc_003D, int _0023_003DzKbOSFCI_003D, int _0023_003DzrJehE7jGwTmA, double _0023_003DzkRSfKls1SLfn)
	{
		int num = 0;
		int num2 = 0;
		int num3;
		if (_0023_003DzNwvwyPc_003D == 1)
		{
			if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[0], _0023_003Dz5Tpjxj5wp_0024R8._vertices[_0023_003DzKbOSFCI_003D - 1], _0023_003DzkRSfKls1SLfn))
			{
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[_0023_003DzKbOSFCI_003D - 1].EndVertex = 0;
				num3 = _0023_003DzKbOSFCI_003D - 1;
				if ((_0023_003DzrJehE7jGwTmA & 1) > 0)
				{
					int num4 = 2 * _0023_003DzKbOSFCI_003D - 1;
					int num5 = _0023_003DzKbOSFCI_003D;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].PreviousFace = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousFace;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].PreviousEdge = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousEdge;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousEdge = 0;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousFace = 0;
					num4--;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = -num5;
					num3 += _0023_003DzKbOSFCI_003D;
				}
				if ((_0023_003DzrJehE7jGwTmA & 2) > 0)
				{
					int num4 = num3 + _0023_003DzKbOSFCI_003D;
					int num5 = num3 + 1;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextFace = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextEdge = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = 0;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace = 0;
					num4 = _0023_003DzKbOSFCI_003D - 1;
					_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = num5;
				}
			}
			return true;
		}
		for (int i = 0; i < _0023_003DzKbOSFCI_003D; i++)
		{
			if (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[i], _0023_003Dz5Tpjxj5wp_0024R8._vertices[(_0023_003DzNwvwyPc_003D - 1) * _0023_003DzKbOSFCI_003D + i], _0023_003DzkRSfKls1SLfn))
			{
				num2 = 1;
				break;
			}
		}
		for (int i = 0; i < _0023_003DzNwvwyPc_003D; i++)
		{
			if (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[i * _0023_003DzKbOSFCI_003D], _0023_003Dz5Tpjxj5wp_0024R8._vertices[(i + 1) * _0023_003DzKbOSFCI_003D - 1], _0023_003DzkRSfKls1SLfn))
			{
				num = 1;
				break;
			}
		}
		num3 = (2 * _0023_003DzKbOSFCI_003D - 1) * (_0023_003DzNwvwyPc_003D - 1) + _0023_003DzKbOSFCI_003D - 1;
		if (num2 == 0)
		{
			for (int i = 1; i < _0023_003DzKbOSFCI_003D; i++)
			{
				int num4 = (2 * _0023_003DzKbOSFCI_003D - 1) * (_0023_003DzNwvwyPc_003D - 1) + i;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i * 2].PreviousFace = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousFace;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i * 2].PreviousEdge = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousEdge;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousEdge = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousFace = 0;
				int num5 = (2 * _0023_003DzKbOSFCI_003D - 1) * (_0023_003DzNwvwyPc_003D - 2) + 2 * i + 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextEdge = -2 * i;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].EndVertex = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i * 2].EndVertex;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5 - 2].EndVertex = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i * 2].BeginVertex;
			}
		}
		if (num == 0)
		{
			for (int i = 1; i < _0023_003DzNwvwyPc_003D; i++)
			{
				int num4 = (2 * _0023_003DzKbOSFCI_003D - 1) * i;
				int num5 = (2 * _0023_003DzKbOSFCI_003D - 1) * (i - 1) + 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextFace = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextEdge = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4 - 1].NextEdge = num5;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4 - 1].EndVertex = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].BeginVertex;
				num4 = Math.Abs(_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextEdge);
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].EndVertex = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].EndVertex;
			}
			if ((_0023_003DzrJehE7jGwTmA & 1) > 0)
			{
				int num4 = num3 + _0023_003DzKbOSFCI_003D;
				int num5 = num3 + 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].PreviousFace = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousFace;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].PreviousEdge = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousEdge;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousEdge = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousFace = 0;
				num4--;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = -num5;
				num3 += _0023_003DzKbOSFCI_003D;
			}
			if ((_0023_003DzrJehE7jGwTmA & 2) > 0)
			{
				int num4 = num3 + _0023_003DzKbOSFCI_003D;
				int num5 = num3 + 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextFace = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextEdge = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace = 0;
				num4 = (2 * _0023_003DzKbOSFCI_003D - 1) * (_0023_003DzNwvwyPc_003D - 1) + _0023_003DzKbOSFCI_003D - 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = num5;
			}
			return true;
		}
		if (num2 == 0)
		{
			return true;
		}
		return false;
	}

	private void _0023_003DzYnNdSUVevLPe(Solid.Portion _0023_003Dz5Tpjxj5wp_0024R8, int _0023_003DzNwvwyPc_003D, int _0023_003DzKbOSFCI_003D, bool _0023_003DzCaPJP54_003D)
	{
		int vertexCount = _0023_003Dz5Tpjxj5wp_0024R8.vertexCount;
		_0023_003Dz5Tpjxj5wp_0024R8.vertexCount++;
		if (_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount] == null)
		{
			_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount] = new Point3D();
		}
		_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount].X = _0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[2].X;
		_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount].Y = _0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[2].Y;
		_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount].Z = _0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[2].Z;
		int edgeCount = _0023_003Dz5Tpjxj5wp_0024R8.edgeCount;
		int num = 0;
		int num2;
		int num3;
		if (_0023_003DzNwvwyPc_003D == 1)
		{
			num2 = 1;
			num3 = 1;
		}
		else if (_0023_003DzCaPJP54_003D)
		{
			num2 = 2;
			num3 = 2;
		}
		else
		{
			num2 = 3;
			num3 = 3;
		}
		int num4 = ++_0023_003Dz5Tpjxj5wp_0024R8.faceCount;
		int index = _0023_003Dz77g161c_003D;
		int num5;
		MNODE mNODE;
		for (int i = 1; i < _0023_003DzKbOSFCI_003D; i++)
		{
			num5 = ++_0023_003Dz5Tpjxj5wp_0024R8.edgeCount;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].BeginVertex = num;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].EndVertex = vertexCount;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextEdge = -(num5 + 1);
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextFace = num4;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].PreviousEdge = -(num2 - num3);
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].PreviousFace = num4 - 1;
			mNODE = _0023_003DzKQ4FD_00248_003D[index++];
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].Type = 0;
			if ((mNODE.num & 0x4000) > 0 || (mNODE.num & 0x4000) < 0)
			{
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].Type |= 1;
			}
			else
			{
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].Type |= 4;
			}
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num2].PreviousEdge = num5;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num2].PreviousFace = num4;
			_0023_003Dz5Tpjxj5wp_0024R8.faces[num4].FirstContour = num4;
			_0023_003Dz5Tpjxj5wp_0024R8.faces[num4].FaceLabel = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.cycles[num4].NextContour = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.cycles[num4].FirstEdge = num5;
			num++;
			num2 += num3;
			num4++;
		}
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[edgeCount + 1].PreviousEdge = 0;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[edgeCount + 1].PreviousFace = 0;
		num5 = ++_0023_003Dz5Tpjxj5wp_0024R8.edgeCount;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].BeginVertex = num;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].EndVertex = vertexCount;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextEdge = 0;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].NextFace = 0;
		mNODE = _0023_003DzKQ4FD_00248_003D[index];
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].Type = 0;
		if ((mNODE.num & 0x4000) > 0 || (mNODE.num & 0x4000) < 0)
		{
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].Type |= 1;
		}
		else
		{
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].Type |= 4;
		}
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].PreviousEdge = -(num2 - num3);
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num5].PreviousFace = num4 - 1;
		_0023_003Dz5Tpjxj5wp_0024R8.contourCount = (_0023_003Dz5Tpjxj5wp_0024R8.faceCount = --num4);
	}

	private void _0023_003DzlvtZwrSNQzpd(Solid.Portion _0023_003Dz5Tpjxj5wp_0024R8, int _0023_003DzNwvwyPc_003D, int _0023_003DzKbOSFCI_003D, bool _0023_003DzCaPJP54_003D)
	{
		int vertexCount = _0023_003Dz5Tpjxj5wp_0024R8.vertexCount;
		_0023_003Dz5Tpjxj5wp_0024R8.vertexCount++;
		if (_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount] == null)
		{
			_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount] = new Point3D();
		}
		_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount].X = _0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[3].X;
		_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount].Y = _0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[3].Y;
		_0023_003Dz5Tpjxj5wp_0024R8._vertices[vertexCount].Z = _0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[3].Z;
		int edgeCount = _0023_003Dz5Tpjxj5wp_0024R8.edgeCount;
		int num = _0023_003DzKbOSFCI_003D * (_0023_003DzNwvwyPc_003D - 1);
		int num2 = ((!_0023_003DzCaPJP54_003D) ? (((_0023_003DzKbOSFCI_003D - 1) * 3 + 1) * (_0023_003DzNwvwyPc_003D - 1) + 1) : (((_0023_003DzKbOSFCI_003D - 1) * 2 + 1) * (_0023_003DzNwvwyPc_003D - 1) + 1));
		int num3 = ++_0023_003Dz5Tpjxj5wp_0024R8.faceCount;
		int index = (_0023_003DzTycgamM_003D - 1) * _0023_003DzOaj8lfo_003D + _0023_003Dz77g161c_003D;
		int num4;
		MNODE mNODE;
		for (int i = 1; i < _0023_003DzKbOSFCI_003D; i++)
		{
			num4 = ++_0023_003Dz5Tpjxj5wp_0024R8.edgeCount;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].BeginVertex = num;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].EndVertex = vertexCount;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = -(num4 - 1);
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace = num3 - 1;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousEdge = num2;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousFace = num3;
			mNODE = _0023_003DzKQ4FD_00248_003D[index++];
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].Type = 0;
			if ((mNODE.num & 0x4000) > 0 || (mNODE.num & 0x4000) < 0)
			{
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].Type |= 1;
			}
			else
			{
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].Type |= 4;
			}
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num2].NextEdge = num4 + 1;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num2].NextFace = num3;
			_0023_003Dz5Tpjxj5wp_0024R8.faces[num3].FirstContour = num3;
			_0023_003Dz5Tpjxj5wp_0024R8.faces[num3].FaceLabel = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.cycles[num3].NextContour = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.cycles[num3].FirstEdge = -num4;
			num++;
			num2++;
			num3++;
		}
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[edgeCount + 1].NextEdge = 0;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[edgeCount + 1].NextFace = 0;
		num4 = ++_0023_003Dz5Tpjxj5wp_0024R8.edgeCount;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].BeginVertex = num;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].EndVertex = vertexCount;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousEdge = 0;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].PreviousFace = 0;
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = -(num4 - 1);
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace = num3 - 1;
		mNODE = _0023_003DzKQ4FD_00248_003D[index];
		_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].Type = 0;
		if ((mNODE.num & 0x4000) > 0 || (mNODE.num & 0x4000) < 0)
		{
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].Type |= 1;
		}
		else
		{
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].Type |= 4;
		}
		_0023_003Dz5Tpjxj5wp_0024R8.contourCount = (_0023_003Dz5Tpjxj5wp_0024R8.faceCount = --num3);
	}

	private void _0023_003DzE7QJd0IP7bADn_002432mQ_003D_003D(Solid.Portion _0023_003Dz5Tpjxj5wp_0024R8, int _0023_003DzNwvwyPc_003D, int _0023_003DzKbOSFCI_003D)
	{
		int num = 1;
		int num2 = 0;
		int num3 = 1;
		if (_0023_003DzNwvwyPc_003D == 1)
		{
			for (int i = 1; i < _0023_003DzKbOSFCI_003D; i++)
			{
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].BeginVertex = num2;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].EndVertex = num2 + 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].NextEdge = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousEdge = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].NextFace = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousFace = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].Type = 4;
				num++;
				num2++;
			}
			_0023_003Dz5Tpjxj5wp_0024R8.edgeCount = num - 1;
			_0023_003Dz5Tpjxj5wp_0024R8.faceCount = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.contourCount = 0;
			return;
		}
		for (int j = 1; j < _0023_003DzNwvwyPc_003D; j++)
		{
			int num4 = num;
			for (int i = 1; i < _0023_003DzKbOSFCI_003D; i++)
			{
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].BeginVertex = num2;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].EndVertex = num2 + _0023_003DzKbOSFCI_003D;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].NextEdge = -(num + (_0023_003DzKbOSFCI_003D - 1) * 2);
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousEdge = num + 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].NextFace = num3 - 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousFace = num3;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].Type = 4;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num + 1].BeginVertex = num2;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num + 1].EndVertex = num2 + 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num + 1].NextEdge = num + 2;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num + 1].PreviousEdge = -(num - 2 * (_0023_003DzKbOSFCI_003D - 1) - 1);
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num + 1].NextFace = num3;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num + 1].PreviousFace = num3 - _0023_003DzKbOSFCI_003D + 1;
				_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num + 1].Type = 4;
				_0023_003Dz5Tpjxj5wp_0024R8.faces[num3].FirstContour = num3;
				_0023_003Dz5Tpjxj5wp_0024R8.faces[num3].FaceLabel = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.cycles[num3].NextContour = 0;
				_0023_003Dz5Tpjxj5wp_0024R8.cycles[num3].FirstEdge = num + 1;
				num += 2;
				num2++;
				num3++;
			}
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].BeginVertex = num2;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].EndVertex = num2 + _0023_003DzKbOSFCI_003D;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].NextEdge = -(num + 2 * (_0023_003DzKbOSFCI_003D - 1));
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].NextFace = num3 - 1;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousEdge = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousFace = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].Type = 4;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextEdge = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num4].NextFace = 0;
			num++;
			num2++;
		}
		for (int i = 1; i < _0023_003DzKbOSFCI_003D; i++)
		{
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].BeginVertex = num2;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].EndVertex = num2 + 1;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].NextEdge = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousEdge = -(num - i - 2 * (_0023_003DzKbOSFCI_003D - 1) + 2 * (i - 1));
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].NextFace = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousFace = num3 - _0023_003DzKbOSFCI_003D + i;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].Type = 4;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num - i - 2 * (_0023_003DzKbOSFCI_003D - 1) + 2 * i].NextEdge = -num;
			num++;
			num2++;
		}
		_0023_003Dz5Tpjxj5wp_0024R8.edgeCount = num - 1;
		_0023_003Dz5Tpjxj5wp_0024R8.faceCount = num3 - 1;
		_0023_003Dz5Tpjxj5wp_0024R8.contourCount = num3 - 1;
		for (int i = 1; i < _0023_003DzKbOSFCI_003D; i++)
		{
			num = i * 2;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousEdge = 0;
			_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[num].PreviousFace = 0;
		}
	}

	private int _0023_003DzcYOEhcm_0024ARi_(int _0023_003DzIRUndII_003D, int _0023_003Dz4okd4Qo_003D, ref int _0023_003Dzj_0024lnLcHvai_0024LyAygFQ_003D_003D, bool _0023_003DzCaPJP54_003D)
	{
		_0023_003DzOaj8lfo_003D = _0023_003Dz4okd4Qo_003D;
		_0023_003DzTycgamM_003D = _0023_003DzIRUndII_003D;
		_0023_003DzFAZrs_0024GWYoT9(_0023_003DzTycgamM_003D, _0023_003DzOaj8lfo_003D);
		if ((_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D & 4) > 0 || (_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D & 8) > 0)
		{
			if (!_0023_003Dzrl27G_w4XxD0(ref _0023_003DzTycgamM_003D, ref _0023_003DzOaj8lfo_003D))
			{
				return 0;
			}
			_0023_003DzFAZrs_0024GWYoT9(_0023_003DzTycgamM_003D, _0023_003DzOaj8lfo_003D);
		}
		_0023_003Dzu3GUhJZFFpv3 = _0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D & 4;
		_0023_003DzCySviCfxDlP4 = _0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D & 1;
		_0023_003Dz_eY3Y4c_003D = _0023_003DzCySviCfxDlP4;
		_0023_003Dz77g161c_003D = _0023_003Dzu3GUhJZFFpv3;
		int num = _0023_003DzTycgamM_003D - _0023_003DzCySviCfxDlP4;
		int num2 = _0023_003DzOaj8lfo_003D - _0023_003Dzu3GUhJZFFpv3;
		_0023_003DzVbcWZUxu_0024bU7(ref num, ref num2, _0023_003DzCaPJP54_003D);
		_0023_003DzNwvwyPc_003D = num;
		_0023_003DzKbOSFCI_003D = num2;
		if (_0023_003DzOaj8lfo_003D - _0023_003Dzu3GUhJZFFpv3 == _0023_003DzKbOSFCI_003D)
		{
			_0023_003Dzv5CkNXOQp4mA = 1;
		}
		else
		{
			_0023_003Dzv5CkNXOQp4mA = _0023_003DzOaj8lfo_003D / (_0023_003DzKbOSFCI_003D - 1);
			if (_0023_003DzOaj8lfo_003D > _0023_003Dzv5CkNXOQp4mA * _0023_003DzKbOSFCI_003D - (_0023_003Dzv5CkNXOQp4mA - 1))
			{
				_0023_003Dzv5CkNXOQp4mA++;
			}
		}
		if (_0023_003DzTycgamM_003D - _0023_003DzCySviCfxDlP4 == _0023_003DzNwvwyPc_003D)
		{
			_0023_003DzJUfcGJLxhTKi = 1;
		}
		else
		{
			_0023_003DzJUfcGJLxhTKi = _0023_003DzTycgamM_003D / (_0023_003DzNwvwyPc_003D - 1);
			if (_0023_003DzTycgamM_003D > _0023_003DzJUfcGJLxhTKi * _0023_003DzNwvwyPc_003D - (_0023_003DzJUfcGJLxhTKi - 1) + _0023_003DzCySviCfxDlP4)
			{
				_0023_003DzJUfcGJLxhTKi++;
			}
		}
		int num3 = _0023_003Dzv5CkNXOQp4mA * _0023_003DzJUfcGJLxhTKi;
		_0023_003Dzx1VbofJoBCNi = _0023_003Dzj_0024lnLcHvai_0024LyAygFQ_003D_003D;
		_0023_003Dzj_0024lnLcHvai_0024LyAygFQ_003D_003D += num3;
		return num3;
	}

	private void _0023_003DzFAZrs_0024GWYoT9(int _0023_003DzTycgamM_003D, int _0023_003DzOaj8lfo_003D)
	{
		_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D = 0;
		MNODE mNODE = _0023_003DzKQ4FD_00248_003D[0];
		MNODE mNODE2 = _0023_003DzKQ4FD_00248_003D[1];
		if (mNODE == mNODE2)
		{
			_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D |= 1;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[2].X = mNODE.X;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[2].Y = mNODE.Y;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[2].Z = mNODE.Z;
		}
		mNODE2 = _0023_003DzKQ4FD_00248_003D[_0023_003DzOaj8lfo_003D];
		if (mNODE == mNODE2)
		{
			_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D |= 4;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[0].X = mNODE.X;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[0].Y = mNODE.Y;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[0].Z = mNODE.Z;
		}
		mNODE2 = _0023_003DzKQ4FD_00248_003D[_0023_003DzOaj8lfo_003D * _0023_003DzTycgamM_003D - 2];
		mNODE = _0023_003DzKQ4FD_00248_003D[_0023_003DzOaj8lfo_003D * _0023_003DzTycgamM_003D - 1];
		if (mNODE == mNODE2)
		{
			_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D |= 2;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[3].X = mNODE.X;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[3].Y = mNODE.Y;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[3].Z = mNODE.Z;
		}
		mNODE2 = _0023_003DzKQ4FD_00248_003D[_0023_003DzOaj8lfo_003D * (_0023_003DzTycgamM_003D - 1) - 1];
		if (mNODE == mNODE2)
		{
			_0023_003Dz1v6oPQk_003D._0023_003DzaXVdQiI_003D = 8;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[1].X = mNODE.X;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[1].Y = mNODE.Y;
			_0023_003Dz1v6oPQk_003D._0023_003DzvgtE4SU_003D[1].Z = mNODE.Z;
		}
	}

	private bool _0023_003Dzrl27G_w4XxD0(ref int _0023_003DzTycgamM_003D, ref int _0023_003DzOaj8lfo_003D)
	{
		List<MNODE> list = new List<MNODE>();
		int index;
		for (int i = 0; i < _0023_003DzTycgamM_003D; i++)
		{
			for (int j = 0; j < _0023_003DzOaj8lfo_003D; j++)
			{
				index = (short)(j * _0023_003DzTycgamM_003D + i);
				MNODE item = _0023_003DzKQ4FD_00248_003D[index];
				list.Add(item);
			}
		}
		_0023_003DzKQ4FD_00248_003D = list;
		index = _0023_003DzTycgamM_003D;
		_0023_003DzTycgamM_003D = _0023_003DzOaj8lfo_003D;
		_0023_003DzOaj8lfo_003D = index;
		return true;
	}

	private void _0023_003DzVbcWZUxu_0024bU7(ref int _0023_003DzNwvwyPc_003D, ref int _0023_003DzKbOSFCI_003D, bool _0023_003DzCaPJP54_003D)
	{
		int num = _0023_003DzNwvwyPc_003D * _0023_003DzKbOSFCI_003D;
		int num2;
		int num3;
		if (_0023_003DzCaPJP54_003D)
		{
			num2 = 2 * _0023_003DzNwvwyPc_003D * _0023_003DzKbOSFCI_003D - 2 * _0023_003DzNwvwyPc_003D - _0023_003DzKbOSFCI_003D;
			num3 = (_0023_003DzNwvwyPc_003D - 1) * (_0023_003DzKbOSFCI_003D - 1);
		}
		else
		{
			num2 = 3 * _0023_003DzNwvwyPc_003D * _0023_003DzKbOSFCI_003D - 2 * _0023_003DzNwvwyPc_003D - _0023_003DzKbOSFCI_003D;
			num3 = 2 * (_0023_003DzNwvwyPc_003D - 1) * (_0023_003DzKbOSFCI_003D - 1);
		}
		while (num > 125 || num2 > 400 || num3 > 202)
		{
			if (_0023_003DzNwvwyPc_003D > _0023_003DzKbOSFCI_003D)
			{
				_0023_003DzNwvwyPc_003D = _0023_003DzNwvwyPc_003D / 2 + 1;
			}
			else
			{
				_0023_003DzKbOSFCI_003D = _0023_003DzKbOSFCI_003D / 2 + 1;
			}
			num = _0023_003DzNwvwyPc_003D * _0023_003DzKbOSFCI_003D;
			if (_0023_003DzCaPJP54_003D)
			{
				num2 = 2 * _0023_003DzNwvwyPc_003D * _0023_003DzKbOSFCI_003D - 2 * _0023_003DzNwvwyPc_003D - _0023_003DzKbOSFCI_003D;
				num3 = (_0023_003DzNwvwyPc_003D - 1) * (_0023_003DzKbOSFCI_003D - 1);
			}
			else
			{
				num2 = 3 * _0023_003DzNwvwyPc_003D * _0023_003DzKbOSFCI_003D - 2 * _0023_003DzNwvwyPc_003D - _0023_003DzKbOSFCI_003D;
				num3 = 2 * (_0023_003DzNwvwyPc_003D - 1) * (_0023_003DzKbOSFCI_003D - 1);
			}
		}
	}
}
