using System.Drawing;
using System.Windows.Forms;
using devDept.Eyeshot.Control;
using devDept.Geometry;

internal sealed class _0023_003Dz3yTehjY_1ZV5QPm48sNaXRgcW8e5
{
	private int _0023_003DzWrBFoZqdtWms;

	public Point2D _0023_003DzHpyw44b5UiDs;

	public double _0023_003Dzb7hC4di27mC7;

	private double[] _0023_003DzTeiFF0k_003D = new double[2];

	private double[] _0023_003DziHo6QAY_003D = new double[20];

	private bool _0023_003DzA_0024BEoUxEH126Bymkxg_003D_003D;

	private bool _0023_003DzGsGRnLJ5OXMG;

	private bool[,] _0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D = new bool[2, 3];

	private Point _0023_003DzuefRPJYb68ci;

	private Point _0023_003Dz8eqYLGyUI_0024UV;

	public _0023_003Dz3yTehjY_1ZV5QPm48sNaXRgcW8e5()
	{
		_0023_003DzGsGRnLJ5OXMG = true;
		_0023_003DzA_0024BEoUxEH126Bymkxg_003D_003D = false;
		_0023_003DzHpyw44b5UiDs = Point2D.Origin;
		_0023_003Dzb7hC4di27mC7 = 0.2;
		_0023_003DzWrBFoZqdtWms = 10;
		_0023_003DzuefRPJYb68ci.X = (_0023_003DzuefRPJYb68ci.Y = 0);
		_0023_003Dz8eqYLGyUI_0024UV.X = (_0023_003Dz8eqYLGyUI_0024UV.Y = 0);
	}

	public bool _0023_003DzHmTC_0024O96lY7pGA6BqA_003D_003D()
	{
		return _0023_003DzGsGRnLJ5OXMG;
	}

	public void _0023_003DzcxKi6gPmHyQ7f8B1dw_003D_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzGsGRnLJ5OXMG = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dza_0024n7qpStWLsG(Point2D _0023_003Dzxi5Dd3Y_003D)
	{
		for (int num = _0023_003DzWrBFoZqdtWms - 1; num > 0; num--)
		{
			_0023_003DziHo6QAY_003D[num * 2] = _0023_003DziHo6QAY_003D[(num - 1) * 2];
			_0023_003DziHo6QAY_003D[num * 2 + 1] = _0023_003DziHo6QAY_003D[(num - 1) * 2 + 1];
		}
		_0023_003DziHo6QAY_003D[0] = _0023_003Dzxi5Dd3Y_003D.X;
		_0023_003DziHo6QAY_003D[1] = _0023_003Dzxi5Dd3Y_003D.Y;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 1.0;
		for (int i = 0; i < _0023_003DzWrBFoZqdtWms; i++)
		{
			num2 += _0023_003DziHo6QAY_003D[i * 2] * num5;
			num3 += _0023_003DziHo6QAY_003D[i * 2 + 1] * num5;
			num4 += num5;
			num5 *= _0023_003Dzb7hC4di27mC7;
		}
		_0023_003DzTeiFF0k_003D[0] = num2 / num4;
		_0023_003DzTeiFF0k_003D[1] = num3 / num4;
	}

	public void _0023_003DzshPEPAc_003D(Workspace _0023_003Dz0TvaYNo_003D, Point _0023_003DzTYCHRugcseEq)
	{
		_0023_003DzuefRPJYb68ci.X = _0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t() / 2;
		_0023_003DzuefRPJYb68ci.Y = _0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() / 2;
		if (_0023_003DzA_0024BEoUxEH126Bymkxg_003D_003D)
		{
			_0023_003DzA_0024BEoUxEH126Bymkxg_003D_003D = false;
			_0023_003Dzgv3CpKlqLndg(_0023_003Dz0TvaYNo_003D);
		}
		_0023_003DzHpyw44b5UiDs.X = _0023_003DzTYCHRugcseEq.X - _0023_003DzuefRPJYb68ci.X;
		_0023_003DzHpyw44b5UiDs.Y = _0023_003DzuefRPJYb68ci.Y - _0023_003DzTYCHRugcseEq.Y;
		if (_0023_003DzGsGRnLJ5OXMG)
		{
			_0023_003Dza_0024n7qpStWLsG(_0023_003DzHpyw44b5UiDs);
			_0023_003DzHpyw44b5UiDs.X = _0023_003DzTeiFF0k_003D[0];
			_0023_003DzHpyw44b5UiDs.Y = _0023_003DzTeiFF0k_003D[1];
		}
	}

	public void _0023_003Dzgv3CpKlqLndg(Workspace _0023_003Dz0TvaYNo_003D)
	{
		if (_0023_003DzuefRPJYb68ci.X != 0 && _0023_003DzuefRPJYb68ci.Y != 0)
		{
			_0023_003DzdZEGJ7k_003D(_0023_003Dz0TvaYNo_003D, _0023_003DzuefRPJYb68ci.X, _0023_003DzuefRPJYb68ci.Y);
		}
		else
		{
			_0023_003DzA_0024BEoUxEH126Bymkxg_003D_003D = true;
		}
		_0023_003Dz0TvaYNo_003D._0023_003DzPPWf23dA_0024OGK = true;
	}

	private void _0023_003DzdZEGJ7k_003D(Workspace _0023_003Dz0TvaYNo_003D, int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D)
	{
		Point p = new Point(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D);
		Cursor.Position = _0023_003Dz0TvaYNo_003D.PointToScreen(p);
		_0023_003Dz8eqYLGyUI_0024UV.X = _0023_003Dz8GBMuoM_003D;
		_0023_003Dz8eqYLGyUI_0024UV.Y = _0023_003DzJU0R6e0_003D;
	}

	internal void _0023_003Dzu8_0024tRXp_0024yCuW(MouseButtons _0023_003Dz6q6yZMs_003D)
	{
		int[] array = _0023_003DzabRwFpv9gnvn(_0023_003Dz6q6yZMs_003D);
		if (array != null)
		{
			int[] array2 = array;
			foreach (int num in array2)
			{
				_0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[1, num] = _0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[0, num];
				_0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[0, num] = true;
			}
		}
	}

	public bool _0023_003DzsZJmCwY_003D(MouseButtons _0023_003Dz6q6yZMs_003D)
	{
		int[] array = _0023_003DzabRwFpv9gnvn(_0023_003Dz6q6yZMs_003D);
		if (array != null)
		{
			bool flag = true;
			int[] array2 = array;
			foreach (int num in array2)
			{
				flag = _0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[0, num];
			}
			if (flag)
			{
				return true;
			}
		}
		if (_0023_003Dz6q6yZMs_003D == MouseButtons.None)
		{
			return true;
		}
		return false;
	}

	public bool _0023_003Dz3Iqkcdw_003D(MouseButtons _0023_003Dz6q6yZMs_003D)
	{
		return !_0023_003DzsZJmCwY_003D(_0023_003Dz6q6yZMs_003D);
	}

	private int[] _0023_003DzabRwFpv9gnvn(MouseButtons _0023_003Dz6q6yZMs_003D)
	{
		int[] result = null;
		switch (_0023_003Dz6q6yZMs_003D)
		{
		case MouseButtons.Left:
			result = new int[1];
			break;
		case MouseButtons.Right:
			result = new int[1] { 1 };
			break;
		case MouseButtons.Middle:
			result = new int[1] { 2 };
			break;
		case MouseButtons.Left | MouseButtons.Right:
			result = new int[2] { 0, 1 };
			break;
		case MouseButtons.Left | MouseButtons.Right | MouseButtons.Middle:
			result = new int[3] { 0, 1, 2 };
			break;
		case MouseButtons.Left | MouseButtons.Middle:
			result = new int[2] { 0, 2 };
			break;
		case MouseButtons.Right | MouseButtons.Middle:
			result = new int[2] { 1, 2 };
			break;
		}
		return result;
	}

	internal void _0023_003DzA_0024ihSwbmVYvs(MouseButtons _0023_003Dz6q6yZMs_003D)
	{
		int[] array = _0023_003DzabRwFpv9gnvn(_0023_003Dz6q6yZMs_003D);
		if (array != null)
		{
			int[] array2 = array;
			foreach (int num in array2)
			{
				_0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[1, num] = _0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[0, num];
				_0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[0, num] = false;
			}
		}
	}

	internal void _0023_003Dz85CTaduOYRBd()
	{
		for (int i = 0; i < _0023_003DziHo6QAY_003D.Length; i++)
		{
			_0023_003DziHo6QAY_003D[i] = 0.0;
		}
	}

	internal void _0023_003DzvUkLDVo88jah()
	{
		int length = _0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			_0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[1, i] = _0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[0, i];
			_0023_003Dz6m2pmXBEdtmpH95obQ_003D_003D[0, i] = false;
		}
	}
}
