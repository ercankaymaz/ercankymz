using System;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003Dzivz4YSuJqYmFhVFeMkAURNPIfZYjrTrm_0024Q_003D_003D
{
	private int _0023_003DzvzfN7QwXVC67;

	private Point3D _0023_003DzPzcqaAf3nU2S;

	private Point3D _0023_003DzXQqj9iOYxoKB;

	private double _0023_003DzKLKAjmKPV3fg;

	private double _0023_003Dz6T3mJP9C_lTg;

	private double _0023_003DzOi7fK6pOX6yh;

	private double _0023_003DzAZbTv8c_003D;

	private double _0023_003DzirIS_0024oE_003D;

	private double _0023_003DzmA8WJu0_003D;

	private double _0023_003DzO1AkaTYvv61l;

	public _0023_003Dzivz4YSuJqYmFhVFeMkAURNPIfZYjrTrm_0024Q_003D_003D(int _0023_003Dz4l02SF1NNK3X, Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzIvyN59Q_003D(_0023_003Dz4l02SF1NNK3X, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
	}

	private void _0023_003DzIvyN59Q_003D(int _0023_003Dz4l02SF1NNK3X, Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzvzfN7QwXVC67 = _0023_003Dz4l02SF1NNK3X;
		double num = _0023_003Dz8dK2uhU_003D.X - _0023_003DzF7v9r2A_003D.X;
		double num2 = _0023_003Dz8dK2uhU_003D.Y - _0023_003DzF7v9r2A_003D.Y;
		double num3 = _0023_003Dz8dK2uhU_003D.Z - _0023_003DzF7v9r2A_003D.Z;
		double num4 = Math.Max(num, Math.Max(num2, num3));
		double num5 = num / num4;
		double num6 = num2 / num4;
		double num7 = num3 / num4;
		_0023_003DzPzcqaAf3nU2S = new Point3D((int)Math.Floor((double)(-_0023_003DzvzfN7QwXVC67) * num5), (int)Math.Floor((double)(-_0023_003DzvzfN7QwXVC67) * num6), (int)Math.Floor((double)(-_0023_003DzvzfN7QwXVC67) * num7));
		_0023_003DzXQqj9iOYxoKB = new Point3D(0.0 - _0023_003DzPzcqaAf3nU2S.X, 0.0 - _0023_003DzPzcqaAf3nU2S.Y, 0.0 - _0023_003DzPzcqaAf3nU2S.Z);
		Point3D point3D = _0023_003DzXQqj9iOYxoKB - _0023_003DzPzcqaAf3nU2S;
		if (num == 0.0)
		{
			_0023_003DzAZbTv8c_003D = 1.0;
		}
		else
		{
			_0023_003DzAZbTv8c_003D = point3D.X / num;
		}
		if (num2 == 0.0)
		{
			_0023_003DzirIS_0024oE_003D = 1.0;
		}
		else
		{
			_0023_003DzirIS_0024oE_003D = point3D.Y / num2;
		}
		if (num3 == 0.0)
		{
			_0023_003DzmA8WJu0_003D = 1.0;
		}
		else
		{
			_0023_003DzmA8WJu0_003D = point3D.Z / num3;
		}
		_0023_003DzO1AkaTYvv61l = Math.Max(Math.Max(_0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D), _0023_003DzmA8WJu0_003D);
		_0023_003DzKLKAjmKPV3fg = _0023_003DzF7v9r2A_003D.X;
		_0023_003Dz6T3mJP9C_lTg = _0023_003DzF7v9r2A_003D.Y;
		_0023_003DzOi7fK6pOX6yh = _0023_003DzF7v9r2A_003D.Z;
	}

	public void _0023_003DzZz8cZLk_003D(Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzIvyN59Q_003D(_0023_003DzvzfN7QwXVC67 * 2, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
	}

	public void _0023_003DzP0_vBrSco8N8(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, out int _0023_003Dz1rZ3w2I_003D, out int _0023_003DzNGFpltQ_003D, out int _0023_003DzUlC3lfU_003D)
	{
		decimal d = (decimal)((_0023_003DzBJFJHwk_003D - _0023_003DzKLKAjmKPV3fg) * _0023_003DzAZbTv8c_003D);
		_0023_003Dz1rZ3w2I_003D = (int)_0023_003DzPzcqaAf3nU2S.X + (int)Math.Round(d);
		decimal d2 = (decimal)((_0023_003Dz40R7bAU_003D - _0023_003Dz6T3mJP9C_lTg) * _0023_003DzirIS_0024oE_003D);
		_0023_003DzNGFpltQ_003D = (int)_0023_003DzPzcqaAf3nU2S.Y + (int)Math.Round(d2);
		decimal d3 = (decimal)((_0023_003DzId5C3LA_003D - _0023_003DzOi7fK6pOX6yh) * _0023_003DzmA8WJu0_003D);
		_0023_003DzUlC3lfU_003D = (int)_0023_003DzPzcqaAf3nU2S.Z + (int)Math.Round(d3);
	}

	public void _0023_003DzaFoDiP4Kjs_5(int _0023_003Dz1rZ3w2I_003D, int _0023_003DzNGFpltQ_003D, int _0023_003DzUlC3lfU_003D, out double _0023_003DzBJFJHwk_003D, out double _0023_003Dz40R7bAU_003D, out double _0023_003DzId5C3LA_003D)
	{
		_0023_003DzBJFJHwk_003D = ((double)_0023_003Dz1rZ3w2I_003D - _0023_003DzPzcqaAf3nU2S.X) / _0023_003DzAZbTv8c_003D + _0023_003DzKLKAjmKPV3fg;
		_0023_003Dz40R7bAU_003D = ((double)_0023_003DzNGFpltQ_003D - _0023_003DzPzcqaAf3nU2S.Y) / _0023_003DzirIS_0024oE_003D + _0023_003Dz6T3mJP9C_lTg;
		_0023_003DzId5C3LA_003D = ((double)_0023_003DzUlC3lfU_003D - _0023_003DzPzcqaAf3nU2S.Z) / _0023_003DzmA8WJu0_003D + _0023_003DzOi7fK6pOX6yh;
	}

	public void _0023_003DzP0_vBrSco8N8(Solid _0023_003DzuwH5j5s_003D)
	{
		foreach (Solid.Portion portion in _0023_003DzuwH5j5s_003D.Portions)
		{
			Point3D[] vertices = portion.Vertices;
			foreach (Point3D point3D in vertices)
			{
				_0023_003DzP0_vBrSco8N8(point3D.X, point3D.Y, point3D.Z, out var _0023_003Dz1rZ3w2I_003D, out var _0023_003DzNGFpltQ_003D, out var _0023_003DzUlC3lfU_003D);
				point3D.X = _0023_003Dz1rZ3w2I_003D;
				point3D.Y = _0023_003DzNGFpltQ_003D;
				point3D.Z = _0023_003DzUlC3lfU_003D;
			}
		}
		_0023_003DzuwH5j5s_003D.UpdateBoundingBox(null);
	}

	public void _0023_003DzaFoDiP4Kjs_5(Solid _0023_003DzuwH5j5s_003D)
	{
		foreach (Solid.Portion portion in _0023_003DzuwH5j5s_003D.Portions)
		{
			Point3D[] vertices = portion.Vertices;
			foreach (Point3D point3D in vertices)
			{
				_0023_003DzaFoDiP4Kjs_5((int)point3D.X, (int)point3D.Y, (int)point3D.Z, out var _0023_003DzBJFJHwk_003D, out var _0023_003Dz40R7bAU_003D, out var _0023_003DzId5C3LA_003D);
				point3D.X = _0023_003DzBJFJHwk_003D;
				point3D.Y = _0023_003Dz40R7bAU_003D;
				point3D.Z = _0023_003DzId5C3LA_003D;
			}
		}
		_0023_003DzuwH5j5s_003D.UpdateBoundingBox(null);
	}
}
