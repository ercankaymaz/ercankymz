using System;
using System.Diagnostics;
using System.Drawing;

namespace devDept.Geometry;

public class IntegerGrid
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzvzfN7QwXVC67;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point _0023_003DzPzcqaAf3nU2S;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point _0023_003DzXQqj9iOYxoKB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzKLKAjmKPV3fg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz6T3mJP9C_lTg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzAZbTv8c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzirIS_0024oE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzO1AkaTYvv61l;

	public Point GridMin
	{
		get
		{
			return _0023_003DzPzcqaAf3nU2S;
		}
		set
		{
			_0023_003DzPzcqaAf3nU2S = value;
		}
	}

	public Point GridMax => _0023_003DzXQqj9iOYxoKB;

	public IntegerGrid(int halfSize, Point2D min, Point2D max)
	{
		_0023_003DzIvyN59Q_003D(halfSize, min, max);
	}

	private void _0023_003DzIvyN59Q_003D(int _0023_003Dz4l02SF1NNK3X, Point2D _0023_003DzF7v9r2A_003D, Point2D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzvzfN7QwXVC67 = _0023_003Dz4l02SF1NNK3X;
		double num = _0023_003Dz8dK2uhU_003D.X - _0023_003DzF7v9r2A_003D.X;
		double num2 = _0023_003Dz8dK2uhU_003D.Y - _0023_003DzF7v9r2A_003D.Y;
		double num3 = 1.0;
		if (num != 0.0 && num2 != 0.0)
		{
			num3 = num2 / num;
		}
		if (num3 < 1.0)
		{
			_0023_003DzPzcqaAf3nU2S = new Point(-_0023_003DzvzfN7QwXVC67, (int)Math.Floor((double)(-_0023_003DzvzfN7QwXVC67) * num3));
		}
		else
		{
			_0023_003DzPzcqaAf3nU2S = new Point((int)Math.Floor((double)(-_0023_003DzvzfN7QwXVC67) / num3), -_0023_003DzvzfN7QwXVC67);
		}
		_0023_003DzXQqj9iOYxoKB = new Point(-_0023_003DzPzcqaAf3nU2S.X, -_0023_003DzPzcqaAf3nU2S.Y);
		Point2D point2D = new Point2D(_0023_003DzXQqj9iOYxoKB.X - _0023_003DzPzcqaAf3nU2S.X, _0023_003DzXQqj9iOYxoKB.Y - _0023_003DzPzcqaAf3nU2S.Y);
		if (num == 0.0)
		{
			_0023_003DzAZbTv8c_003D = 1.0;
		}
		else
		{
			_0023_003DzAZbTv8c_003D = point2D.X / num;
		}
		if (num2 == 0.0)
		{
			_0023_003DzirIS_0024oE_003D = 1.0;
		}
		else
		{
			_0023_003DzirIS_0024oE_003D = point2D.Y / num2;
		}
		_0023_003DzO1AkaTYvv61l = Math.Max(_0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D);
		_0023_003DzKLKAjmKPV3fg = _0023_003DzF7v9r2A_003D.X;
		_0023_003Dz6T3mJP9C_lTg = _0023_003DzF7v9r2A_003D.Y;
	}

	internal Point _0023_003Dz_0024cHmBejv4XfE()
	{
		return new Point((_0023_003DzXQqj9iOYxoKB.X - _0023_003DzPzcqaAf3nU2S.X) / 2, (_0023_003DzXQqj9iOYxoKB.Y - _0023_003DzPzcqaAf3nU2S.Y) / 2);
	}

	internal double _0023_003DzSz9j2QgD23s_0024()
	{
		return _0023_003DzO1AkaTYvv61l;
	}

	internal double _0023_003DzPjCDi56G8VEg()
	{
		return Math.Max((int)((double)(GridMax.X - GridMin.X) * 1.4142135623730951), (int)((double)(GridMax.Y - GridMin.Y) * 1.4142135623730951));
	}

	public void ScaleToGrid(double x, double y, int[] vertex)
	{
		ScaleToGrid(x, y, out vertex[0], out vertex[1]);
	}

	public void ScaleToGrid(double x, double y, out int gridX, out int gridY)
	{
		decimal d = (decimal)((x - _0023_003DzKLKAjmKPV3fg) * _0023_003DzAZbTv8c_003D);
		gridX = _0023_003DzPzcqaAf3nU2S.X + (int)Math.Round(d);
		decimal d2 = (decimal)((y - _0023_003Dz6T3mJP9C_lTg) * _0023_003DzirIS_0024oE_003D);
		gridY = _0023_003DzPzcqaAf3nU2S.Y + (int)Math.Round(d2);
	}

	public void ScaleToGrid(double x, double y, out long gridX, out long gridY)
	{
		decimal d = (decimal)((x - _0023_003DzKLKAjmKPV3fg) * _0023_003DzAZbTv8c_003D);
		gridX = _0023_003DzPzcqaAf3nU2S.X + (long)Math.Round(d);
		decimal d2 = (decimal)((y - _0023_003Dz6T3mJP9C_lTg) * _0023_003DzirIS_0024oE_003D);
		gridY = _0023_003DzPzcqaAf3nU2S.Y + (long)Math.Round(d2);
	}

	public int ScaleYToGrid(double y)
	{
		decimal d = (decimal)((y - _0023_003Dz6T3mJP9C_lTg) * _0023_003DzirIS_0024oE_003D);
		return _0023_003DzPzcqaAf3nU2S.Y + (int)Math.Round(d);
	}

	public void ScaleToWorld(int gridX, int gridY, out double x, out double y)
	{
		x = (double)(gridX - _0023_003DzPzcqaAf3nU2S.X) / _0023_003DzAZbTv8c_003D + _0023_003DzKLKAjmKPV3fg;
		y = (double)(gridY - _0023_003DzPzcqaAf3nU2S.Y) / _0023_003DzirIS_0024oE_003D + _0023_003Dz6T3mJP9C_lTg;
	}

	public void ScaleToWorld(long gridX, long gridY, out double x, out double y)
	{
		x = (double)(gridX - _0023_003DzPzcqaAf3nU2S.X) / _0023_003DzAZbTv8c_003D + _0023_003DzKLKAjmKPV3fg;
		y = (double)(gridY - _0023_003DzPzcqaAf3nU2S.Y) / _0023_003DzirIS_0024oE_003D + _0023_003Dz6T3mJP9C_lTg;
	}
}
