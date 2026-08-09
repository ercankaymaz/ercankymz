using System.Collections.Generic;

internal sealed class _0023_003Dzv7zQIwO0XE8nnk1zbQ_003D_003D<_0023_003DzWWgGxds_003D> : global::_0023_003DzQBIRl4p7y7c29pD__0024Q_003D_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : _0023_003DzmKBPh7nOT6nY
{
	public _0023_003Dzv7zQIwO0XE8nnk1zbQ_003D_003D()
	{
		_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Clear();
	}

	public override void _0023_003Dzxj8_0024IGX9tO2w(_0023_003DzWWgGxds_003D _0023_003DzB68dg9Q_003D)
	{
		_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.AddLast(_0023_003DzB68dg9Q_003D);
	}

	public override void _0023_003DzMao_Mqc_003D(double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		_0023_003Dzm0CYiiE_003D = _0023_003DzuMKQhOieejyEvhtVOw_003D_003D;
	}

	public override void _0023_003Dzc_0024pb7t4_003D()
	{
		if (_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Count < 2)
		{
			return;
		}
		LinkedList<_0023_003DzWWgGxds_003D> linkedList = new LinkedList<_0023_003DzWWgGxds_003D>();
		LinkedList<_0023_003DzWWgGxds_003D>.Enumerator enumerator = _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.GetEnumerator();
		enumerator.MoveNext();
		LinkedList<_0023_003DzWWgGxds_003D>.Enumerator enumerator2 = _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.GetEnumerator();
		enumerator2.MoveNext();
		enumerator2.MoveNext();
		LinkedList<_0023_003DzWWgGxds_003D>.Enumerator enumerator3 = enumerator2;
		enumerator3.MoveNext();
		LinkedList<_0023_003DzWWgGxds_003D>.Enumerator enumerator4 = enumerator2;
		linkedList.AddLast(enumerator.Current);
		bool flag = true;
		while (enumerator3.Current != _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Last.Value)
		{
			_0023_003DzWWgGxds_003D _0023_003Dz77g161c_003D = (_0023_003DzWWgGxds_003D)(enumerator3.Current - enumerator.Current);
			if (((_0023_003DzWWgGxds_003D)enumerator2.Current._0023_003Dz3P41GFRPL8iZ(enumerator.Current, _0023_003Dz77g161c_003D) - enumerator2.Current)._0023_003Dzn8G7AOUeiIgL() < _0023_003Dzm0CYiiE_003D)
			{
				enumerator4 = enumerator3;
				enumerator3.MoveNext();
				if (flag)
				{
					enumerator2.MoveNext();
				}
				flag = !flag;
			}
			else
			{
				linkedList.AddLast(enumerator4.Current);
				enumerator = enumerator4;
				enumerator2 = enumerator3;
				enumerator4 = enumerator2;
				enumerator3.MoveNext();
			}
		}
		linkedList.AddLast(_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Last.Value);
		_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D = new LinkedList<_0023_003DzWWgGxds_003D>(linkedList);
	}
}
