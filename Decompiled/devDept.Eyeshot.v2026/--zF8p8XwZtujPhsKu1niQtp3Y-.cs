using System.Collections.Generic;
using devDept.Geometry;

internal sealed class _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D
{
	private IList<IList<Point2D>> _0023_003Dz4tLYLb4_003D;

	private Point2D _0023_003DzAZT6BTk_003D;

	private Point2D _0023_003Dz0Jn_0024JRQ_003D;

	public _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(IList<IList<Point2D>> _0023_003DzCRq4LBU_003D)
	{
		_0023_003DzNo9vCzZlIlCb(_0023_003DzCRq4LBU_003D);
	}

	public IList<IList<Point2D>> _0023_003DzIeMEgGvdP3uT()
	{
		return _0023_003Dz4tLYLb4_003D;
	}

	public void _0023_003DzNo9vCzZlIlCb(IList<IList<Point2D>> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz4tLYLb4_003D = _0023_003DzPzO_0024GUk_003D;
		_0023_003DzAZT6BTk_003D = Point2D.MaxValue;
		_0023_003Dz0Jn_0024JRQ_003D = Point2D.MinValue;
		foreach (IList<Point2D> item in _0023_003Dz4tLYLb4_003D)
		{
			Utility.UpdateMinMax(null, item, item.Count, _0023_003DzAZT6BTk_003D, _0023_003Dz0Jn_0024JRQ_003D);
		}
	}

	public Point2D _0023_003DzVQaoDTr7XsmN()
	{
		return _0023_003DzAZT6BTk_003D;
	}

	public Point2D _0023_003Dz15VJ9VVI6246()
	{
		return _0023_003Dz0Jn_0024JRQ_003D;
	}
}
