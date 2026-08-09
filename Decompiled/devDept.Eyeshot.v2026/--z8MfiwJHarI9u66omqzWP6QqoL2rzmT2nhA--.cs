using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry.ConstraintSolver;

internal sealed class _0023_003Dz8MfiwJHarI9u66omqzWP6QqoL2rzmT2nhA_003D_003D
{
	public Dictionary<BlockReference, LinkedList<Mate>> _0023_003DzhVzS_5o_003D = new Dictionary<BlockReference, LinkedList<Mate>>();

	public List<Mate> _0023_003DzddnMkwj8wXg_0024 = new List<Mate>();

	public _0023_003Dz8MfiwJHarI9u66omqzWP6QqoL2rzmT2nhA_003D_003D()
	{
	}

	public _0023_003Dz8MfiwJHarI9u66omqzWP6QqoL2rzmT2nhA_003D_003D(List<Mate> _0023_003DzcPInsbZkoP_0024F)
	{
		_0023_003DzddnMkwj8wXg_0024 = _0023_003DzcPInsbZkoP_0024F;
		foreach (Mate item in _0023_003DzcPInsbZkoP_0024F)
		{
			_0023_003DzXISuhdaUhDy5(item);
		}
	}

	public void _0023_003DzPJNpNF4_003D(Mate _0023_003DzbfrNXYE_003D)
	{
		_0023_003DzddnMkwj8wXg_0024.Add(_0023_003DzbfrNXYE_003D);
		_0023_003DzXISuhdaUhDy5(_0023_003DzbfrNXYE_003D);
	}

	internal void _0023_003DzXISuhdaUhDy5(Mate _0023_003Dz48C9g9BkbHSw)
	{
		BlockReference component = _0023_003Dz48C9g9BkbHSw._0023_003DzgM8TwmWg2tsG.Component;
		BlockReference component2 = _0023_003Dz48C9g9BkbHSw._0023_003DzdH0ws20LmJv0.Component;
		if (!_0023_003DzhVzS_5o_003D.ContainsKey(component))
		{
			_0023_003DzhVzS_5o_003D[component] = new LinkedList<Mate>();
		}
		_0023_003DzhVzS_5o_003D[component].AddFirst(_0023_003Dz48C9g9BkbHSw);
		if (component != component2)
		{
			if (!_0023_003DzhVzS_5o_003D.ContainsKey(component2))
			{
				_0023_003DzhVzS_5o_003D[component2] = new LinkedList<Mate>();
			}
			_0023_003DzhVzS_5o_003D[component2].AddFirst(_0023_003Dz48C9g9BkbHSw);
		}
	}

	internal void _0023_003Dz3ZWMVJs_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003DzWvO4rTE_003D, List<BlockReference> _0023_003Dz_0024GW7xop_0024SPQ6, List<Mate> _0023_003DzcPInsbZkoP_0024F, BlockReference _0023_003DzVjt_WVhWz_0024Qi)
	{
		if (!_0023_003DzhVzS_5o_003D.ContainsKey(_0023_003DzVjt_WVhWz_0024Qi))
		{
			return;
		}
		LinkedList<Mate> source = _0023_003DzhVzS_5o_003D[_0023_003DzVjt_WVhWz_0024Qi];
		for (int i = 0; i < source.Count(); i++)
		{
			BlockReference blockReference = ((_0023_003DzVjt_WVhWz_0024Qi == source.ElementAt(i)._0023_003DzdH0ws20LmJv0.Component) ? source.ElementAt(i)._0023_003DzgM8TwmWg2tsG.Component : source.ElementAt(i)._0023_003DzdH0ws20LmJv0.Component);
			Mate mate = source.ElementAt(i);
			if (_0023_003DzddnMkwj8wXg_0024.Contains(mate))
			{
				if (!_0023_003DzcPInsbZkoP_0024F.Contains(mate))
				{
					_0023_003DzcPInsbZkoP_0024F.Add(mate);
					_0023_003DzWvO4rTE_003D._0023_003Dz2m2938oFK1gG(mate);
				}
				if (!_0023_003Dz_0024GW7xop_0024SPQ6.Contains(blockReference) && !blockReference.IsFixed)
				{
					_0023_003Dz_0024GW7xop_0024SPQ6.Add(blockReference);
					blockReference._0023_003DzCvxG2A3KpWd8()._0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003DzWvO4rTE_003D, dragType.Free);
					_0023_003Dz3ZWMVJs_003D(_0023_003DzWvO4rTE_003D, _0023_003Dz_0024GW7xop_0024SPQ6, _0023_003DzcPInsbZkoP_0024F, blockReference);
				}
			}
		}
	}
}
