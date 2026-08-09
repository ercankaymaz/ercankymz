using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D : Utility
{
	public static Transformation _0023_003DzRGGde2eEYTPn(Transformation _0023_003DzNDQ_E88_003D, Point3D _0023_003DzMlCq3wk_003D)
	{
		if (!_0023_003DzaxxaG7YkQhZN(_0023_003DzMlCq3wk_003D, out var _0023_003DzC82wi0s_003D, out var _0023_003DzqExQ9uA_003D))
		{
			return null;
		}
		_0023_003DzNDQ_E88_003D = _0023_003Dzyd5VPwzBzlhM(_0023_003DzNDQ_E88_003D, -3, _0023_003DzqExQ9uA_003D);
		_0023_003DzNDQ_E88_003D = _0023_003Dzyd5VPwzBzlhM(_0023_003DzNDQ_E88_003D, -1, _0023_003DzC82wi0s_003D);
		return _0023_003DzNDQ_E88_003D;
	}

	public static Transformation _0023_003Dzyd5VPwzBzlhM(Transformation _0023_003DzNDQ_E88_003D, int _0023_003DzA79rSXB8AvLt, double _0023_003DzbvIFYko_003D)
	{
		Transformation transformation = new Transformation();
		int num = Math.Abs(_0023_003DzA79rSXB8AvLt);
		if (_0023_003DzA79rSXB8AvLt > 0)
		{
			_0023_003DzbvIFYko_003D = Math.PI / 180.0 * _0023_003DzbvIFYko_003D;
		}
		transformation.Identity();
		switch (num)
		{
		case 1:
			transformation[1, 1] = Math.Cos(_0023_003DzbvIFYko_003D);
			transformation[1, 2] = 0.0 - Math.Sin(_0023_003DzbvIFYko_003D);
			transformation[2, 1] = Math.Sin(_0023_003DzbvIFYko_003D);
			transformation[2, 2] = Math.Cos(_0023_003DzbvIFYko_003D);
			break;
		case 2:
			transformation[0, 0] = Math.Cos(_0023_003DzbvIFYko_003D);
			transformation[0, 2] = Math.Sin(_0023_003DzbvIFYko_003D);
			transformation[2, 0] = 0.0 - Math.Sin(_0023_003DzbvIFYko_003D);
			transformation[2, 2] = Math.Cos(_0023_003DzbvIFYko_003D);
			break;
		case 3:
			transformation[0, 0] = Math.Cos(_0023_003DzbvIFYko_003D);
			transformation[0, 1] = 0.0 - Math.Sin(_0023_003DzbvIFYko_003D);
			transformation[1, 0] = Math.Sin(_0023_003DzbvIFYko_003D);
			transformation[1, 1] = Math.Cos(_0023_003DzbvIFYko_003D);
			break;
		}
		return transformation * _0023_003DzNDQ_E88_003D;
	}

	public static bool _0023_003DzaxxaG7YkQhZN(Point3D _0023_003DzMlCq3wk_003D, out double _0023_003DzC82wi0s_003D, out double _0023_003DzqExQ9uA_003D)
	{
		Vector3D asVector = _0023_003DzMlCq3wk_003D.AsVector;
		_0023_003DzC82wi0s_003D = 0.0;
		_0023_003DzqExQ9uA_003D = 0.0;
		if (!asVector.Normalize())
		{
			_0023_003DzMlCq3wk_003D.X = (_0023_003DzMlCq3wk_003D.Y = (_0023_003DzMlCq3wk_003D.Z = 0.0));
			return false;
		}
		double num;
		if ((num = _0023_003DzqYEEHSGpQg6n(_0023_003DzMlCq3wk_003D.X, _0023_003DzMlCq3wk_003D.Y)) < 1E-06)
		{
			_0023_003DzqExQ9uA_003D = Math.PI;
		}
		else
		{
			_0023_003DzqExQ9uA_003D = -Math.PI / 2.0 - _0023_003Dz_0024Hx0aoc_003D(_0023_003DzMlCq3wk_003D.X, _0023_003DzMlCq3wk_003D.Y);
		}
		_0023_003DzC82wi0s_003D = Math.PI / 2.0 - _0023_003Dz_0024Hx0aoc_003D(0.0 - num, _0023_003DzMlCq3wk_003D.Z);
		return true;
	}

	public static double _0023_003DzqYEEHSGpQg6n(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D)
	{
		return Math.Sqrt(Math.Pow(_0023_003DzjbqS1qE_003D, 2.0) + Math.Pow(_0023_003Dz1v6oPQk_003D, 2.0));
	}

	private static double _0023_003Dz_0024Hx0aoc_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
	{
		if (Math.Abs(_0023_003DzBJFJHwk_003D) < 2.2250738585072014E-307 && Math.Abs(_0023_003Dz40R7bAU_003D) < 2.2250738585072014E-307)
		{
			return 0.0;
		}
		double num = Math.Atan2(_0023_003Dz40R7bAU_003D, _0023_003DzBJFJHwk_003D);
		if (Math.Abs(num) < 1E-06)
		{
			num = 0.0;
		}
		else
		{
			for (; num < 0.0; num += Math.PI * 2.0)
			{
			}
		}
		return num;
	}

	public static double _0023_003DzEQxK9Wi6z58v(Solid.Portion _0023_003Dzd9ZyL64_003D, Point3D _0023_003DzlY77YgY_003D)
	{
		double num = 0.0;
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D point3D4 = new Point3D();
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			for (int num2 = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour; num2 != 0; num2 = _0023_003Dzd9ZyL64_003D.cycles[num2].NextContour)
			{
				int firstEdge;
				int num3 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num2].FirstEdge);
				point3D.X = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].X;
				point3D.Y = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].Y;
				point3D.Z = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].Z;
				firstEdge = _0023_003DzX_0024NuZLAtdLNx(firstEdge, _0023_003Dzd9ZyL64_003D);
				point3D2.X = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].X;
				point3D2.Y = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].Y;
				point3D2.Z = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].Z;
				firstEdge = _0023_003DzX_0024NuZLAtdLNx(firstEdge, _0023_003Dzd9ZyL64_003D);
				do
				{
					point3D3.X = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].X;
					point3D3.Y = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].Y;
					point3D3.Z = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D)].Z;
					point3D4.X = (point3D.X + point3D2.X + point3D3.X + _0023_003DzlY77YgY_003D.X) / 4.0;
					point3D4.Y = (point3D.Y + point3D2.Y + point3D3.Y + _0023_003DzlY77YgY_003D.Y) / 4.0;
					point3D4.Z = (point3D.Z + point3D2.Z + point3D3.Z + _0023_003DzlY77YgY_003D.Z) / 4.0;
					num += _0023_003DzTiok9Gp_0024kwsWIfeJZQ_003D_003D(point3D, point3D2, point3D3, _0023_003DzlY77YgY_003D);
					firstEdge = _0023_003DzX_0024NuZLAtdLNx(firstEdge, _0023_003Dzd9ZyL64_003D);
					point3D2.X = point3D3.X;
					point3D2.Y = point3D3.Y;
					point3D2.Z = point3D3.Z;
				}
				while (firstEdge != num3);
			}
		}
		return num;
	}

	private static double _0023_003DzTiok9Gp_0024kwsWIfeJZQ_003D_003D(Point3D _0023_003DzjR_8wWk_003D, Point3D _0023_003DzC_0024S_002404o_003D, Point3D _0023_003Dzne4B9QY_003D, Point3D _0023_003DzOl9GDQo_003D)
	{
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		point3D = _0023_003DzjR_8wWk_003D - _0023_003DzOl9GDQo_003D;
		point3D2 = _0023_003DzC_0024S_002404o_003D - _0023_003DzOl9GDQo_003D;
		point3D3 = _0023_003Dzne4B9QY_003D - _0023_003DzOl9GDQo_003D;
		return (point3D.X * point3D2.Y * point3D3.Z + point3D.Z * point3D2.X * point3D3.Y + point3D.Y * point3D2.Z * point3D3.X - point3D.Z * point3D2.Y * point3D3.X - point3D.Y * point3D2.X * point3D3.Z - point3D.X * point3D2.Z * point3D3.Y) * 0.16666667;
	}

	public static double _0023_003DzgG6NN7HDapes(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Vector3D vector3D = new Vector3D();
		double num = 0.0;
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			point3D3.X = (point3D3.Y = (point3D3.Z = 0.0));
			for (int num2 = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour; num2 != 0; num2 = _0023_003Dzd9ZyL64_003D.cycles[num2].NextContour)
			{
				int firstEdge;
				int num3 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num2].FirstEdge);
				int num4 = _0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D);
				point3D = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzgvbLr0qH7Irg(firstEdge, _0023_003Dzd9ZyL64_003D)] - _0023_003Dzd9ZyL64_003D._vertices[num4];
				firstEdge = _0023_003DzX_0024NuZLAtdLNx(firstEdge, _0023_003Dzd9ZyL64_003D);
				do
				{
					point3D2 = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzgvbLr0qH7Irg(firstEdge, _0023_003Dzd9ZyL64_003D)] - _0023_003Dzd9ZyL64_003D._vertices[num4];
					vector3D = Vector3D.Cross(point3D, point3D2);
					point3D3 += vector3D;
					point3D.X = point3D2.X;
					point3D.Y = point3D2.Y;
					point3D.Z = point3D2.Z;
					firstEdge = _0023_003DzX_0024NuZLAtdLNx(firstEdge, _0023_003Dzd9ZyL64_003D);
				}
				while (firstEdge != num3);
			}
			double d = Vector3D.Dot(point3D3, point3D3.AsVector);
			num += Math.Sqrt(d) / 2.0;
		}
		return num;
	}

	public static int _0023_003DzX_0024NuZLAtdLNx(int _0023_003DzkmOWJoPlqkka, Solid.Portion _0023_003DzkKfJheA_003D)
	{
		if (_0023_003DzkmOWJoPlqkka > 0)
		{
			return _0023_003DzkKfJheA_003D.edgeDatas[_0023_003DzkmOWJoPlqkka].NextEdge;
		}
		return _0023_003DzkKfJheA_003D.edgeDatas[-_0023_003DzkmOWJoPlqkka].PreviousEdge;
	}

	public static int _0023_003DzmvS45b0roOxZ(int _0023_003DzRpXgovo_003D, Solid.Portion _0023_003DzkKfJheA_003D)
	{
		if (_0023_003DzRpXgovo_003D > 0)
		{
			return _0023_003DzkKfJheA_003D.edgeDatas[_0023_003DzRpXgovo_003D].NextFace;
		}
		return _0023_003DzkKfJheA_003D.edgeDatas[-_0023_003DzRpXgovo_003D].PreviousFace;
	}

	public static int _0023_003DzXT_0024DTGaK6Dv9(int _0023_003DzR4vno_0024vncXLo, Solid.Portion _0023_003DzB68dg9Q_003D)
	{
		if (_0023_003DzR4vno_0024vncXLo > 0)
		{
			return _0023_003DzB68dg9Q_003D.edgeDatas[_0023_003DzR4vno_0024vncXLo].BeginVertex;
		}
		return _0023_003DzB68dg9Q_003D.edgeDatas[-_0023_003DzR4vno_0024vncXLo].EndVertex;
	}

	public static int _0023_003DzgvbLr0qH7Irg(int _0023_003DzR4vno_0024vncXLo, Solid.Portion _0023_003DzB68dg9Q_003D)
	{
		if (_0023_003DzR4vno_0024vncXLo > 0)
		{
			return _0023_003DzB68dg9Q_003D.edgeDatas[_0023_003DzR4vno_0024vncXLo].EndVertex;
		}
		return _0023_003DzB68dg9Q_003D.edgeDatas[-_0023_003DzR4vno_0024vncXLo].BeginVertex;
	}

	public static int _0023_003DzikKjBI8_003D(int _0023_003DzRpXgovo_003D, Solid.Portion _0023_003DzkKfJheA_003D)
	{
		if (_0023_003DzRpXgovo_003D > 0)
		{
			return _0023_003DzkKfJheA_003D.edgeDatas[_0023_003DzRpXgovo_003D].PreviousFace;
		}
		return _0023_003DzkKfJheA_003D.edgeDatas[-_0023_003DzRpXgovo_003D].NextFace;
	}

	public static bool _0023_003DzTbbOqnY_003D(Transformation _0023_003Dz42mfdJk_003D, double[,] _0023_003Dza1YcjwU_003D)
	{
		double num = _0023_003DzQnGzbjBy03e96Jr4rXmvHk0_003D(_0023_003Dza1YcjwU_003D);
		double[,] _0023_003DzUDlFc7k_003D = new double[3, 3];
		if (Math.Abs(num) < 0.0001)
		{
			return false;
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				int num2 = 1 - (i + j) % 2 * 2;
				_0023_003Dz2VNEtAiv5fWe(_0023_003Dza1YcjwU_003D, ref _0023_003DzUDlFc7k_003D, i, j);
				_0023_003Dz42mfdJk_003D[j, i] = _0023_003Dzhml7z4keh2ZFJJ1VnPKXLLQ_003D(_0023_003DzUDlFc7k_003D) * (double)num2 / num;
			}
		}
		return true;
	}

	public static double _0023_003DzQnGzbjBy03e96Jr4rXmvHk0_003D(double[,] _0023_003DzFAH4xII_003D)
	{
		double num = 0.0;
		double num2 = 1.0;
		double[,] _0023_003DzUDlFc7k_003D = new double[3, 3];
		int num3 = 0;
		while (num3 < 4)
		{
			_0023_003Dz2VNEtAiv5fWe(_0023_003DzFAH4xII_003D, ref _0023_003DzUDlFc7k_003D, 0, num3);
			double num4 = _0023_003Dzhml7z4keh2ZFJJ1VnPKXLLQ_003D(_0023_003DzUDlFc7k_003D);
			num += _0023_003DzFAH4xII_003D[0, num3] * num4 * num2;
			num3++;
			num2 *= -1.0;
		}
		return num;
	}

	public static double _0023_003Dzhml7z4keh2ZFJJ1VnPKXLLQ_003D(double[,] _0023_003DzKPUTl6c_003D)
	{
		return _0023_003DzKPUTl6c_003D[0, 0] * (_0023_003DzKPUTl6c_003D[1, 1] * _0023_003DzKPUTl6c_003D[2, 2] - _0023_003DzKPUTl6c_003D[2, 1] * _0023_003DzKPUTl6c_003D[1, 2]) - _0023_003DzKPUTl6c_003D[0, 1] * (_0023_003DzKPUTl6c_003D[1, 0] * _0023_003DzKPUTl6c_003D[2, 2] - _0023_003DzKPUTl6c_003D[2, 0] * _0023_003DzKPUTl6c_003D[1, 2]) + _0023_003DzKPUTl6c_003D[0, 2] * (_0023_003DzKPUTl6c_003D[1, 0] * _0023_003DzKPUTl6c_003D[2, 1] - _0023_003DzKPUTl6c_003D[2, 0] * _0023_003DzKPUTl6c_003D[1, 1]);
	}

	private static void _0023_003Dz2VNEtAiv5fWe(double[,] _0023_003DzFAH4xII_003D, ref double[,] _0023_003DzUDlFc7k_003D, int _0023_003Dz437_00244ak_003D, int _0023_003DzTSeNR8Q_003D)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				int num = i + ((i >= _0023_003Dz437_00244ak_003D) ? 1 : 0);
				int num2 = j + ((j >= _0023_003DzTSeNR8Q_003D) ? 1 : 0);
				_0023_003DzUDlFc7k_003D[i, j] = _0023_003DzFAH4xII_003D[num, num2];
			}
		}
	}

	public static void _0023_003DzM_uSBsYSa_0024UJzJqOlA_003D_003D(Transformation _0023_003DzGXR_0024mdnjxOPn, Point3D _0023_003Dz0AUOSO0_003D, Point3D _0023_003DziHdtxHs_003D)
	{
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		point3D2 = _0023_003DzGXR_0024mdnjxOPn * _0023_003Dz0AUOSO0_003D;
		point3D3.X = point3D2.X;
		point3D3.Y = point3D2.Y;
		point3D3.Z = point3D2.Z;
		for (short num = 1; num < 8; num++)
		{
			_0023_003DzoUj_d8OKlv5Q(_0023_003Dz0AUOSO0_003D, _0023_003DziHdtxHs_003D, num, point3D);
			point3D = _0023_003DzGXR_0024mdnjxOPn * point3D;
			if (point3D.X < point3D2.X)
			{
				point3D2.X = point3D.X;
			}
			if (point3D.Y < point3D2.Y)
			{
				point3D2.Y = point3D.Y;
			}
			if (point3D.Z < point3D2.Z)
			{
				point3D2.Z = point3D.Z;
			}
			if (point3D.X > point3D3.X)
			{
				point3D3.X = point3D.X;
			}
			if (point3D.Y > point3D3.Y)
			{
				point3D3.Y = point3D.Y;
			}
			if (point3D.Z > point3D3.Z)
			{
				point3D3.Z = point3D.Z;
			}
		}
		_0023_003Dz0AUOSO0_003D.X = point3D2.X;
		_0023_003Dz0AUOSO0_003D.Y = point3D2.Y;
		_0023_003Dz0AUOSO0_003D.Z = point3D2.Z;
		_0023_003DziHdtxHs_003D.X = point3D3.X;
		_0023_003DziHdtxHs_003D.Y = point3D3.Y;
		_0023_003DziHdtxHs_003D.Z = point3D3.Z;
	}

	private static void _0023_003DzoUj_d8OKlv5Q(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, short _0023_003Dz8lc6uO0_003D, Point3D _0023_003Dz77g161c_003D)
	{
		_0023_003Dz77g161c_003D.X = _0023_003DzFj_0024IqDQ_003D.X;
		_0023_003Dz77g161c_003D.Y = _0023_003DzFj_0024IqDQ_003D.Y;
		_0023_003Dz77g161c_003D.Z = _0023_003DzFj_0024IqDQ_003D.Z;
		if ((_0023_003Dz8lc6uO0_003D & 4) > 0)
		{
			_0023_003Dz77g161c_003D.X = _0023_003DzjdeMMkk_003D.X;
		}
		if ((_0023_003Dz8lc6uO0_003D & 2) > 0)
		{
			_0023_003Dz77g161c_003D.Y = _0023_003DzjdeMMkk_003D.Y;
		}
		if ((_0023_003Dz8lc6uO0_003D & 1) > 0)
		{
			_0023_003Dz77g161c_003D.Z = _0023_003DzjdeMMkk_003D.Z;
		}
	}

	public static double _0023_003Dz3tcNmVFEsR5K(Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		Size3D size3D = new Size3D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		double[] array = new double[3] { size3D.X, size3D.Y, size3D.Z };
		Array.Sort(array);
		double num = double.MaxValue;
		for (int i = 0; i < 3; i++)
		{
			if (!(array[i] < Utility._0023_003DzheSR8QM7q9ya))
			{
				num = array[i];
				break;
			}
		}
		return num * Utility._0023_003DzxhnLabVjXjPg;
	}

	public static bool _0023_003Dz0CVowaLJ_0024Ik4(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, double _0023_003DzezTples_003D)
	{
		if (Math.Abs(_0023_003DzFj_0024IqDQ_003D.X - _0023_003DzjdeMMkk_003D.X) > _0023_003DzezTples_003D)
		{
			return false;
		}
		if (Math.Abs(_0023_003DzFj_0024IqDQ_003D.Y - _0023_003DzjdeMMkk_003D.Y) > _0023_003DzezTples_003D)
		{
			return false;
		}
		if (Math.Abs(_0023_003DzFj_0024IqDQ_003D.Z - _0023_003DzjdeMMkk_003D.Z) > _0023_003DzezTples_003D)
		{
			return false;
		}
		return true;
	}

	public static int _0023_003DzM_00243BeHw_003D(Vector3D _0023_003DzjbqS1qE_003D, Point3D _0023_003Dzt_m8zV0_003D, double _0023_003Dzg7UZF5Q_003D, Vector3D _0023_003Dz1v6oPQk_003D)
	{
		_0023_003Dz1v6oPQk_003D.X = _0023_003Dzt_m8zV0_003D.Y * _0023_003DzjbqS1qE_003D.Z - _0023_003Dzt_m8zV0_003D.Z * _0023_003DzjbqS1qE_003D.Y;
		_0023_003Dz1v6oPQk_003D.Y = _0023_003Dzt_m8zV0_003D.Z * _0023_003DzjbqS1qE_003D.X - _0023_003Dzt_m8zV0_003D.X * _0023_003DzjbqS1qE_003D.Z;
		_0023_003Dz1v6oPQk_003D.Z = _0023_003Dzt_m8zV0_003D.X * _0023_003DzjbqS1qE_003D.Y - _0023_003Dzt_m8zV0_003D.Y * _0023_003DzjbqS1qE_003D.X;
		Vector3D vector3D = new Vector3D(_0023_003Dz1v6oPQk_003D.X, _0023_003Dz1v6oPQk_003D.Y, _0023_003Dz1v6oPQk_003D.Z);
		if (!vector3D.Normalize())
		{
			_0023_003Dz1v6oPQk_003D.X = (_0023_003Dz1v6oPQk_003D.Y = (_0023_003Dz1v6oPQk_003D.Z = 0.0));
			return 0;
		}
		_0023_003Dz1v6oPQk_003D.X = vector3D.X;
		_0023_003Dz1v6oPQk_003D.Y = vector3D.Y;
		_0023_003Dz1v6oPQk_003D.Z = vector3D.Z;
		double num = Math.Cos(_0023_003Dzg7UZF5Q_003D);
		double num2 = Math.Sin(_0023_003Dzg7UZF5Q_003D);
		_0023_003Dz1v6oPQk_003D.X = num * _0023_003DzjbqS1qE_003D.X + num2 * _0023_003Dz1v6oPQk_003D.X;
		_0023_003Dz1v6oPQk_003D.Y = num * _0023_003DzjbqS1qE_003D.Y + num2 * _0023_003Dz1v6oPQk_003D.Y;
		_0023_003Dz1v6oPQk_003D.Z = num * _0023_003DzjbqS1qE_003D.Z + num2 * _0023_003Dz1v6oPQk_003D.Z;
		return 1;
	}

	public static bool _0023_003DzQ_0024aXDFOrP7sJ(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D)
	{
		Vector3D vector3D = Vector3D.Subtract(_0023_003DzjdeMMkk_003D, _0023_003DzFj_0024IqDQ_003D);
		if (!vector3D.Normalize())
		{
			return true;
		}
		Vector3D vector3D2 = Vector3D.Subtract(_0023_003Dzm4eSPQQ_003D, _0023_003DzFj_0024IqDQ_003D);
		if (!vector3D2.Normalize())
		{
			return true;
		}
		if (Math.Abs(Vector3D.Dot(vector3D, vector3D2)) > 0.999999)
		{
			return true;
		}
		return false;
	}

	public static double _0023_003Dz_wQ1vNtxSvPU(Point3D _0023_003DzUUmZRyo_003D, Point3D _0023_003DzdCP541Q_003D, Point3D _0023_003DzB68dg9Q_003D, ref Point3D _0023_003Dzi4cdUYM_003D, double _0023_003DzkRSfKls1SLfn)
	{
		double _0023_003DzCSRWkYc_003D = (0.0 - _0023_003DzdCP541Q_003D.X) * _0023_003DzB68dg9Q_003D.X - _0023_003DzdCP541Q_003D.Y * _0023_003DzB68dg9Q_003D.Y - _0023_003DzdCP541Q_003D.Z * _0023_003DzB68dg9Q_003D.Z;
		_0023_003DzEbjnYZoK6CcK(_0023_003DzdCP541Q_003D, _0023_003DzCSRWkYc_003D, _0023_003DzUUmZRyo_003D, _0023_003DzdCP541Q_003D, ref _0023_003Dzi4cdUYM_003D, _0023_003DzkRSfKls1SLfn);
		return _0023_003DzYJQw9E4K0KCQ(_0023_003DzB68dg9Q_003D, _0023_003Dzi4cdUYM_003D);
	}

	public static double _0023_003DzYJQw9E4K0KCQ(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D)
	{
		return Math.Sqrt((_0023_003DzFj_0024IqDQ_003D.X - _0023_003DzjdeMMkk_003D.X) * (_0023_003DzFj_0024IqDQ_003D.X - _0023_003DzjdeMMkk_003D.X) + (_0023_003DzFj_0024IqDQ_003D.Y - _0023_003DzjdeMMkk_003D.Y) * (_0023_003DzFj_0024IqDQ_003D.Y - _0023_003DzjdeMMkk_003D.Y) + (_0023_003DzFj_0024IqDQ_003D.Z - _0023_003DzjdeMMkk_003D.Z) * (_0023_003DzFj_0024IqDQ_003D.Z - _0023_003DzjdeMMkk_003D.Z));
	}

	public static int _0023_003DzEbjnYZoK6CcK(Point3D _0023_003Dzd9ZyL64_003D, double _0023_003DzCSRWkYc_003D, Point3D _0023_003DzUUmZRyo_003D, Point3D _0023_003DzdCP541Q_003D, ref Point3D _0023_003DzB68dg9Q_003D, double _0023_003DzkRSfKls1SLfn)
	{
		double num = _0023_003Dzd9ZyL64_003D.X * _0023_003DzdCP541Q_003D.X + _0023_003Dzd9ZyL64_003D.Y * _0023_003DzdCP541Q_003D.Y + _0023_003Dzd9ZyL64_003D.Z * _0023_003DzdCP541Q_003D.Z;
		double num2 = _0023_003Dzd9ZyL64_003D.X * _0023_003DzUUmZRyo_003D.X + _0023_003Dzd9ZyL64_003D.Y * _0023_003DzUUmZRyo_003D.Y + _0023_003Dzd9ZyL64_003D.Z * _0023_003DzUUmZRyo_003D.Z + _0023_003DzCSRWkYc_003D;
		if (Math.Abs(num) < 1E-06)
		{
			if (Math.Abs(num2) < _0023_003DzkRSfKls1SLfn)
			{
				return 0;
			}
			return -1;
		}
		num2 = (0.0 - num2) / num;
		_0023_003DzB68dg9Q_003D.X = _0023_003DzdCP541Q_003D.X * num2;
		_0023_003DzB68dg9Q_003D.Y = _0023_003DzdCP541Q_003D.Y * num2;
		_0023_003DzB68dg9Q_003D.Z = _0023_003DzdCP541Q_003D.Z * num2;
		_0023_003DzB68dg9Q_003D = _0023_003DzUUmZRyo_003D + _0023_003DzB68dg9Q_003D;
		return 1;
	}

	public static bool _0023_003DzbAQBFKkei0NN(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D, Point3D _0023_003Dzd9ZyL64_003D, ref double _0023_003DzCSRWkYc_003D)
	{
		_0023_003Dzd9ZyL64_003D.X = (_0023_003DzFj_0024IqDQ_003D.Y - _0023_003DzjdeMMkk_003D.Y) * (_0023_003DzFj_0024IqDQ_003D.Z - _0023_003Dzm4eSPQQ_003D.Z) - (_0023_003DzFj_0024IqDQ_003D.Y - _0023_003Dzm4eSPQQ_003D.Y) * (_0023_003DzFj_0024IqDQ_003D.Z - _0023_003DzjdeMMkk_003D.Z);
		_0023_003Dzd9ZyL64_003D.Y = (_0023_003DzFj_0024IqDQ_003D.Z - _0023_003DzjdeMMkk_003D.Z) * (_0023_003DzFj_0024IqDQ_003D.X - _0023_003Dzm4eSPQQ_003D.X) - (_0023_003DzFj_0024IqDQ_003D.Z - _0023_003Dzm4eSPQQ_003D.Z) * (_0023_003DzFj_0024IqDQ_003D.X - _0023_003DzjdeMMkk_003D.X);
		_0023_003Dzd9ZyL64_003D.Z = (_0023_003DzFj_0024IqDQ_003D.X - _0023_003DzjdeMMkk_003D.X) * (_0023_003DzFj_0024IqDQ_003D.Y - _0023_003Dzm4eSPQQ_003D.Y) - (_0023_003DzFj_0024IqDQ_003D.X - _0023_003Dzm4eSPQQ_003D.X) * (_0023_003DzFj_0024IqDQ_003D.Y - _0023_003DzjdeMMkk_003D.Y);
		_0023_003DzCSRWkYc_003D = _0023_003DzqYEEHSGpQg6n(_0023_003DzqYEEHSGpQg6n(_0023_003Dzd9ZyL64_003D.X, _0023_003Dzd9ZyL64_003D.Y), _0023_003Dzd9ZyL64_003D.Z);
		if (_0023_003DzCSRWkYc_003D < 2.2250738585072014E-307)
		{
			return false;
		}
		_0023_003Dzd9ZyL64_003D.X *= 1.0 / _0023_003DzCSRWkYc_003D;
		_0023_003Dzd9ZyL64_003D.Y *= 1.0 / _0023_003DzCSRWkYc_003D;
		_0023_003Dzd9ZyL64_003D.Z *= 1.0 / _0023_003DzCSRWkYc_003D;
		_0023_003DzCSRWkYc_003D = (0.0 - _0023_003DzFj_0024IqDQ_003D.X) * _0023_003Dzd9ZyL64_003D.X - _0023_003DzFj_0024IqDQ_003D.Y * _0023_003Dzd9ZyL64_003D.Y - _0023_003DzFj_0024IqDQ_003D.Z * _0023_003Dzd9ZyL64_003D.Z;
		return true;
	}

	public static double _0023_003DznvriWn0uITSS(Point3D _0023_003DzB68dg9Q_003D, Point3D _0023_003DzoMNiNRw_003D, double _0023_003DzXrexKjY_003D)
	{
		return _0023_003DzoMNiNRw_003D.X * _0023_003DzB68dg9Q_003D.X + _0023_003DzoMNiNRw_003D.Y * _0023_003DzB68dg9Q_003D.Y + _0023_003DzoMNiNRw_003D.Z * _0023_003DzB68dg9Q_003D.Z + _0023_003DzXrexKjY_003D;
	}

	public static bool _0023_003DzY50dbZ5WG8m7(Point3D _0023_003Dz77g161c_003D, double _0023_003DzkRSfKls1SLfn)
	{
		double num = Math.Sqrt(_0023_003Dz77g161c_003D.X * _0023_003Dz77g161c_003D.X + _0023_003Dz77g161c_003D.Y * _0023_003Dz77g161c_003D.Y + _0023_003Dz77g161c_003D.Z * _0023_003Dz77g161c_003D.Z);
		if (num < _0023_003DzkRSfKls1SLfn / 10000.0)
		{
			_0023_003Dz77g161c_003D.X = (_0023_003Dz77g161c_003D.Y = (_0023_003Dz77g161c_003D.Z = 0.0));
			return false;
		}
		_0023_003Dz77g161c_003D.X /= num;
		_0023_003Dz77g161c_003D.Y /= num;
		_0023_003Dz77g161c_003D.Z /= num;
		return true;
	}

	public static bool _0023_003DzLP0_0024mg_0024PyXRx(IList<Point2D> _0023_003DzD_6vtKc_003D, IList<Point2D> _0023_003Dz_SqBXz8_003D)
	{
		foreach (Point2D item in _0023_003DzD_6vtKc_003D)
		{
			if (!Utility.PointInPolygon(item, _0023_003Dz_SqBXz8_003D))
			{
				return false;
			}
		}
		return true;
	}
}
