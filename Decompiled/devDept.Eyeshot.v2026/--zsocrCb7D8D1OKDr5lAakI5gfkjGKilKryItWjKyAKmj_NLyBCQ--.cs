using System;
using System.Collections.Generic;

internal sealed class _0023_003DzsocrCb7D8D1OKDr5lAakI5gfkjGKilKryItWjKyAKmj_NLyBCQ_003D_003D
{
	public static uint _0023_003DznMInWv2HpFZJ4ThcuugGLdA_003D(_0023_003Dz69VbyUQTwo_8VjXKo3XOLbDGlsWh _0023_003DzFmiij5k_003D, uint _0023_003DzAqOpw0w_003D, _0023_003Dz9LOvunCmw1MA _0023_003DzWWgGxds_003D)
	{
		uint num = _0023_003DzAqOpw0w_003D;
		uint num2 = 0u;
		uint num3 = 0u;
		uint num4 = _0023_003DzAqOpw0w_003D;
		List<bool> list = new List<bool>();
		for (int i = 0; i < _0023_003DzFmiij5k_003D._0023_003Dz5dIgNyr05jlpX8XRO09_0vQ_003D(); i++)
		{
			list.Add(item: false);
		}
		Tuple<uint, uint> _0023_003DzAYqOj_Y_003D = new Tuple<uint, uint>(0u, 0u);
		Queue<uint> queue = new Queue<uint>();
		queue.Enqueue(num);
		_0023_003DzWWgGxds_003D._0023_003Dzz1z6HpY_003D(num);
		num2++;
		num3++;
		list[Convert.ToInt32(num)] = true;
		while (queue.Count > 0)
		{
			num = queue.Peek();
			queue.Dequeue();
			_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D2 = _0023_003DzFmiij5k_003D._0023_003Dzwk2b_qka0UdUy7NMnMNSHP8_003D(num, ref _0023_003DzAYqOj_Y_003D);
			bool flag;
			do
			{
				flag = false;
				for (uint num5 = _0023_003DzAYqOj_Y_003D.Item1; num5 != _0023_003DzAYqOj_Y_003D.Item2; num5++)
				{
					flag |= Convert.ToBoolean(!list[Convert.ToInt32(_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D2._0023_003DzYBaDcXE_003D(num5))]);
					if (!list[Convert.ToInt32(_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D2._0023_003DzYBaDcXE_003D(num5))] && !_0023_003DzWWgGxds_003D._0023_003Dzz9ds9Zke7dzrIhxeOw_003D_003D(_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D2._0023_003DzYBaDcXE_003D(num5)))
					{
						break;
					}
				}
				if (flag)
				{
					uint num6 = _0023_003DzWWgGxds_003D._0023_003DzPNC3Oqg_003D();
					_0023_003DzWWgGxds_003D._0023_003Dzz1z6HpY_003D(num6);
					num2++;
					list[Convert.ToInt32(num6)] = true;
					queue.Enqueue(num6);
				}
			}
			while (flag);
			if (num == num4 && queue.Count > 0)
			{
				num4 = queue.ToArray()[queue.Count - 1];
				num3++;
			}
		}
		return num2;
	}

	public static uint _0023_003DznMInWv2HpFZJ4ThcuugGLdA_003D(_0023_003Dz69VbyUQTwo_8VjXKo3XOLbDGlsWh _0023_003DzFmiij5k_003D, uint _0023_003DzAqOpw0w_003D, _0023_003DzgF0g3xVa3LGbZFsACktAw3ntnDtDxltyHvb1PATdbgj8 _0023_003DzWWgGxds_003D)
	{
		uint num = _0023_003DzAqOpw0w_003D;
		uint num2 = 0u;
		uint num3 = 0u;
		uint num4 = _0023_003DzAqOpw0w_003D;
		List<bool> list = new List<bool>();
		for (int i = 0; i < _0023_003DzFmiij5k_003D._0023_003Dz5dIgNyr05jlpX8XRO09_0vQ_003D(); i++)
		{
			list.Add(item: false);
		}
		Tuple<uint, uint> _0023_003DzAYqOj_Y_003D = new Tuple<uint, uint>(0u, 0u);
		Queue<uint> queue = new Queue<uint>();
		queue.Enqueue(num);
		_0023_003DzWWgGxds_003D._0023_003Dzz1z6HpY_003D(num);
		num2++;
		num3++;
		list[Convert.ToInt32(num)] = true;
		while (queue.Count > 0)
		{
			num = queue.Peek();
			queue.Dequeue();
			_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D2 = _0023_003DzFmiij5k_003D._0023_003Dzwk2b_qka0UdUy7NMnMNSHP8_003D(num, ref _0023_003DzAYqOj_Y_003D);
			bool flag;
			do
			{
				flag = false;
				for (uint num5 = _0023_003DzAYqOj_Y_003D.Item1; num5 != _0023_003DzAYqOj_Y_003D.Item2; num5++)
				{
					flag |= Convert.ToBoolean(!list[Convert.ToInt32(_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D2._0023_003DzYBaDcXE_003D(num5))]);
					if (!list[Convert.ToInt32(_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D2._0023_003DzYBaDcXE_003D(num5))] && !_0023_003DzWWgGxds_003D._0023_003Dzz9ds9Zke7dzrIhxeOw_003D_003D(_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D2._0023_003DzYBaDcXE_003D(num5), num3))
					{
						break;
					}
				}
				if (flag)
				{
					uint num6 = _0023_003DzWWgGxds_003D._0023_003DzPNC3Oqg_003D();
					_0023_003DzWWgGxds_003D._0023_003Dzz1z6HpY_003D(num6);
					num2++;
					list[Convert.ToInt32(num6)] = true;
					queue.Enqueue(num6);
				}
			}
			while (flag);
			if (num == num4 && queue.Count > 0)
			{
				num4 = queue.ToArray()[queue.Count - 1];
				num3++;
			}
		}
		return num2;
	}

	public static void _0023_003DzGIpLi9c_0024OsssVNqnS2Tza40rKQ2_(_0023_003Dz69VbyUQTwo_8VjXKo3XOLbDGlsWh _0023_003DzFmiij5k_003D, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzPZHsjosE6_0024X_0024, ref Tuple<uint, uint> _0023_003Dzl3DhHgI_003D, ref uint _0023_003DzWAKvyMOaICWrYa7j6A_003D_003D)
	{
		_0023_003DzgF0g3xVa3LGbZFsACktAw3ntnDtDxltyHvb1PATdbgj8 _0023_003DzgF0g3xVa3LGbZFsACktAw3ntnDtDxltyHvb1PATdbgj9 = new _0023_003DzgF0g3xVa3LGbZFsACktAw3ntnDtDxltyHvb1PATdbgj8(_0023_003Dzl3DhHgI_003D.Item1, _0023_003DzPZHsjosE6_0024X_0024);
		_0023_003Dzl3DhHgI_003D = new Tuple<uint, uint>(_0023_003Dzl3DhHgI_003D.Item1, _0023_003Dzl3DhHgI_003D.Item1);
		while (true)
		{
			_0023_003DznMInWv2HpFZJ4ThcuugGLdA_003D(_0023_003DzFmiij5k_003D, _0023_003Dzl3DhHgI_003D.Item1, _0023_003DzgF0g3xVa3LGbZFsACktAw3ntnDtDxltyHvb1PATdbgj9);
			if (_0023_003DzgF0g3xVa3LGbZFsACktAw3ntnDtDxltyHvb1PATdbgj9._0023_003Dzp7FDESUtrW_s == _0023_003Dzl3DhHgI_003D.Item1)
			{
				break;
			}
			_0023_003Dzl3DhHgI_003D = new Tuple<uint, uint>(_0023_003Dzl3DhHgI_003D.Item1, _0023_003DzgF0g3xVa3LGbZFsACktAw3ntnDtDxltyHvb1PATdbgj9._0023_003Dzp7FDESUtrW_s);
			_0023_003Dzl3DhHgI_003D = new Tuple<uint, uint>(_0023_003Dzl3DhHgI_003D.Item2, _0023_003Dzl3DhHgI_003D.Item1);
		}
		_0023_003DzWAKvyMOaICWrYa7j6A_003D_003D = _0023_003DzgF0g3xVa3LGbZFsACktAw3ntnDtDxltyHvb1PATdbgj9._0023_003DzGa4PTdZSkFjq;
	}
}
