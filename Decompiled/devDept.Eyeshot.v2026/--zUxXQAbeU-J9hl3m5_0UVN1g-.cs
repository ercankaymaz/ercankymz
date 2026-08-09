using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

internal sealed class _0023_003DzUxXQAbeU_0024J9hl3m5_0UVN1g_003D
{
	private static NumberFormatInfo _0023_003Dz0qLklfo_003D = NumberFormatInfo.InvariantInfo;

	private int _0023_003DzAddCv_o_003D;

	private bool _0023_003DzJgiUeJw_003D(StreamReader _0023_003DzkKz7OWA_003D, out string[] _0023_003Dz0jxzq30_003D)
	{
		_0023_003Dz0jxzq30_003D = null;
		if (_0023_003DzkKz7OWA_003D.EndOfStream)
		{
			return false;
		}
		string text = _0023_003DzkKz7OWA_003D.ReadLine().Trim();
		while (string.IsNullOrWhiteSpace(text) || text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027)))
		{
			if (_0023_003DzkKz7OWA_003D.EndOfStream)
			{
				return false;
			}
			text = _0023_003DzkKz7OWA_003D.ReadLine().Trim();
		}
		_0023_003Dz0jxzq30_003D = text.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
		return true;
	}

	private void _0023_003Dz3_AG2Xg_003D(List<_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D> _0023_003DzELu0Pss_003D, int _0023_003DzyzK8swU_003D, string[] _0023_003DzQ9zpGF0_003D, int _0023_003DzqP5lTto_003D, int _0023_003DzlhyyCIKNInsE)
	{
		double _0023_003DzBJFJHwk_003D = double.Parse(_0023_003DzQ9zpGF0_003D[1], _0023_003Dz0qLklfo_003D);
		double _0023_003Dz40R7bAU_003D = double.Parse(_0023_003DzQ9zpGF0_003D[2], _0023_003Dz0qLklfo_003D);
		_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2 = new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		if (_0023_003DzlhyyCIKNInsE > 0 && _0023_003DzQ9zpGF0_003D.Length > 3 + _0023_003DzqP5lTto_003D)
		{
			_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2._0023_003DzebfWBK1CW3R8(int.Parse(_0023_003DzQ9zpGF0_003D[3 + _0023_003DzqP5lTto_003D]));
		}
		_0023_003DzELu0Pss_003D.Add(_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2);
	}

	public void _0023_003DzVemZ00E_003D(string _0023_003Dzg_0024RwPyE_003D, out _0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzN57VxTE7ZsCw)
	{
		_0023_003DzN57VxTE7ZsCw = null;
		string text = Path.ChangeExtension(_0023_003Dzg_0024RwPyE_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937375));
		if (File.Exists(text))
		{
			_0023_003DzN57VxTE7ZsCw = _0023_003Dzvb71UeyJtGrT(text);
			return;
		}
		text = Path.ChangeExtension(_0023_003Dzg_0024RwPyE_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937363));
		_0023_003DzN57VxTE7ZsCw = _0023_003DzTerWjWk_003D(text);
	}

	public void _0023_003DzVemZ00E_003D(string _0023_003Dzg_0024RwPyE_003D, out _0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzyXmKbtw_003D, out List<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = null;
		_0023_003DzVemZ00E_003D(_0023_003Dzg_0024RwPyE_003D, out _0023_003DzyXmKbtw_003D);
		string text = Path.ChangeExtension(_0023_003Dzg_0024RwPyE_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937355));
		if (File.Exists(text) && _0023_003DzyXmKbtw_003D != null)
		{
			_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = _0023_003DzABsfpV8aaCRl(text);
		}
	}

	public _0023_003DzOayra4XYxinnsLf1fA_003D_003D _0023_003DzVemZ00E_003D(string _0023_003Dzg_0024RwPyE_003D)
	{
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzN57VxTE7ZsCw = null;
		_0023_003DzVemZ00E_003D(_0023_003Dzg_0024RwPyE_003D, out _0023_003DzN57VxTE7ZsCw);
		return _0023_003DzN57VxTE7ZsCw;
	}

	public _0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzTerWjWk_003D(string _0023_003Dz_0024tIe5xaUi1YBE6hnvFX_0024Uk0_003D)
	{
		return _0023_003DzTerWjWk_003D(_0023_003Dz_0024tIe5xaUi1YBE6hnvFX_0024Uk0_003D, _0023_003DzhDX7wsBRaAjS: false);
	}

	public _0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzTerWjWk_003D(string _0023_003Dz_0024tIe5xaUi1YBE6hnvFX_0024Uk0_003D, bool _0023_003DzhDX7wsBRaAjS)
	{
		_0023_003DzAddCv_o_003D = 0;
		int num = 0;
		int _0023_003DzqP5lTto_003D = 0;
		int _0023_003DzlhyyCIKNInsE = 0;
		StreamReader streamReader = new StreamReader(_0023_003Dz_0024tIe5xaUi1YBE6hnvFX_0024Uk0_003D);
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzFaMCED8PjsukeIy29w_003D_003D2;
		try
		{
			if (!_0023_003DzJgiUeJw_003D(streamReader, out var _0023_003Dz0jxzq30_003D))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937512));
			}
			num = int.Parse(_0023_003Dz0jxzq30_003D[0]);
			if (num < 3)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937475));
			}
			if (_0023_003Dz0jxzq30_003D.Length > 1 && int.Parse(_0023_003Dz0jxzq30_003D[1]) != 2)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937178));
			}
			if (_0023_003Dz0jxzq30_003D.Length > 2)
			{
				_0023_003DzqP5lTto_003D = int.Parse(_0023_003Dz0jxzq30_003D[2]);
			}
			if (_0023_003Dz0jxzq30_003D.Length > 3)
			{
				_0023_003DzlhyyCIKNInsE = int.Parse(_0023_003Dz0jxzq30_003D[3]);
			}
			_0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = new _0023_003DzFaMCED8PjsukeIy29w_003D_003D(num);
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
					{
						throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937135));
					}
					if (_0023_003Dz0jxzq30_003D.Length < 3)
					{
						throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937335));
					}
					if (i == 0)
					{
						_0023_003DzAddCv_o_003D = int.Parse(_0023_003Dz0jxzq30_003D[0], _0023_003Dz0qLklfo_003D);
					}
					_0023_003Dz3_AG2Xg_003D(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL(), i, _0023_003Dz0jxzq30_003D, _0023_003DzqP5lTto_003D, _0023_003DzlhyyCIKNInsE);
				}
			}
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
		if (_0023_003DzhDX7wsBRaAjS)
		{
			string text = Path.ChangeExtension(_0023_003Dz_0024tIe5xaUi1YBE6hnvFX_0024Uk0_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937355));
			if (File.Exists(text))
			{
				_0023_003DzABsfpV8aaCRl(text, _0023_003DzAlu89Awr8CKh: true);
			}
		}
		return _0023_003DzFaMCED8PjsukeIy29w_003D_003D2;
	}

	public _0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003Dzvb71UeyJtGrT(string _0023_003DzZnRqlDfBNeJscaPd7IgEJW0_003D)
	{
		return _0023_003Dzvb71UeyJtGrT(_0023_003DzZnRqlDfBNeJscaPd7IgEJW0_003D, _0023_003DzhDX7wsBRaAjS: false, _0023_003DzAlu89Awr8CKh: false);
	}

	public _0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003Dzvb71UeyJtGrT(string _0023_003DzZnRqlDfBNeJscaPd7IgEJW0_003D, bool _0023_003DzhDX7wsBRaAjS)
	{
		return _0023_003Dzvb71UeyJtGrT(_0023_003DzZnRqlDfBNeJscaPd7IgEJW0_003D, _0023_003DzhDX7wsBRaAjS, _0023_003DzAlu89Awr8CKh: false);
	}

	public _0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003Dzvb71UeyJtGrT(string _0023_003DzZnRqlDfBNeJscaPd7IgEJW0_003D, bool _0023_003DzhDX7wsBRaAjS, bool _0023_003DzAlu89Awr8CKh)
	{
		_0023_003DzAddCv_o_003D = 0;
		int num = 0;
		int _0023_003DzqP5lTto_003D = 0;
		int _0023_003DzlhyyCIKNInsE = 0;
		StreamReader streamReader = new StreamReader(_0023_003DzZnRqlDfBNeJscaPd7IgEJW0_003D);
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzFaMCED8PjsukeIy29w_003D_003D2;
		try
		{
			if (!_0023_003DzJgiUeJw_003D(streamReader, out var _0023_003Dz0jxzq30_003D))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937512));
			}
			num = int.Parse(_0023_003Dz0jxzq30_003D[0]);
			if (_0023_003Dz0jxzq30_003D.Length > 1 && int.Parse(_0023_003Dz0jxzq30_003D[1]) != 2)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937178));
			}
			if (_0023_003Dz0jxzq30_003D.Length > 2)
			{
				_0023_003DzqP5lTto_003D = int.Parse(_0023_003Dz0jxzq30_003D[2]);
			}
			if (_0023_003Dz0jxzq30_003D.Length > 3)
			{
				_0023_003DzlhyyCIKNInsE = int.Parse(_0023_003Dz0jxzq30_003D[3]);
			}
			if (num > 0)
			{
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = new _0023_003DzFaMCED8PjsukeIy29w_003D_003D(num);
				for (int i = 0; i < num; i++)
				{
					if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
					{
						throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937135));
					}
					if (_0023_003Dz0jxzq30_003D.Length < 3)
					{
						throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937335));
					}
					if (i == 0)
					{
						_0023_003DzAddCv_o_003D = int.Parse(_0023_003Dz0jxzq30_003D[0], _0023_003Dz0qLklfo_003D);
					}
					_0023_003Dz3_AG2Xg_003D(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL(), i, _0023_003Dz0jxzq30_003D, _0023_003DzqP5lTto_003D, _0023_003DzlhyyCIKNInsE);
				}
			}
			else
			{
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = _0023_003DzTerWjWk_003D(Path.ChangeExtension(_0023_003DzZnRqlDfBNeJscaPd7IgEJW0_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937363)));
				num = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
			}
			List<_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D> list = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL();
			if (list.Count == 0)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937325));
			}
			if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937287));
			}
			int num2 = int.Parse(_0023_003Dz0jxzq30_003D[0]);
			int num3 = 0;
			if (_0023_003Dz0jxzq30_003D.Length > 1)
			{
				num3 = int.Parse(_0023_003Dz0jxzq30_003D[1]);
			}
			for (int j = 0; j < num2; j++)
			{
				if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937287));
				}
				if (_0023_003Dz0jxzq30_003D.Length < 3)
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937263));
				}
				int num4 = int.Parse(_0023_003Dz0jxzq30_003D[1]) - _0023_003DzAddCv_o_003D;
				int num5 = int.Parse(_0023_003Dz0jxzq30_003D[2]) - _0023_003DzAddCv_o_003D;
				int _0023_003Dz7uX3t_0024g_003D = 0;
				if (num3 > 0 && _0023_003Dz0jxzq30_003D.Length > 3)
				{
					_0023_003Dz7uX3t_0024g_003D = int.Parse(_0023_003Dz0jxzq30_003D[3]);
				}
				if (num4 < 0 || num4 >= num)
				{
					if (_0023_003DzFssxjLXQIoCN._0023_003Dzgn4R6SUws5Zs())
					{
						_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003Dz6jbnvgs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937231), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937946));
					}
				}
				else if (num5 < 0 || num5 >= num)
				{
					if (_0023_003DzFssxjLXQIoCN._0023_003Dzgn4R6SUws5Zs())
					{
						_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003Dz6jbnvgs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937914), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937946));
					}
				}
				else
				{
					_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzPJNpNF4_003D(new _0023_003Dz6aZVluM0HoQZHUo9pw_003D_003D(list[num4], list[num5], _0023_003Dz7uX3t_0024g_003D));
				}
			}
			if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937860));
			}
			int num6 = int.Parse(_0023_003Dz0jxzq30_003D[0]);
			if (num6 > 0)
			{
				for (int k = 0; k < num6; k++)
				{
					if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
					{
						throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937860));
					}
					if (_0023_003Dz0jxzq30_003D.Length < 3)
					{
						throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938087));
					}
					_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003Dz0YassfQEfNm_().Add(new _0023_003DzzmyWHqyGgz5CKzPZ3A_003D_003D(double.Parse(_0023_003Dz0jxzq30_003D[1], _0023_003Dz0qLklfo_003D), double.Parse(_0023_003Dz0jxzq30_003D[2], _0023_003Dz0qLklfo_003D)));
				}
			}
			if (_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
			{
				int num7 = int.Parse(_0023_003Dz0jxzq30_003D[0]);
				if (num7 > 0)
				{
					for (int l = 0; l < num7; l++)
					{
						if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
						{
							throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938075));
						}
						if (_0023_003Dz0jxzq30_003D.Length < 4)
						{
							throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302938017));
						}
						if (!int.TryParse(_0023_003Dz0jxzq30_003D[3], out var result))
						{
							result = l;
						}
						double result2 = 0.0;
						if (_0023_003Dz0jxzq30_003D.Length > 4)
						{
							double.TryParse(_0023_003Dz0jxzq30_003D[4], NumberStyles.Number, _0023_003Dz0qLklfo_003D, out result2);
						}
						_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzqJ5brMbSQ2kK().Add(new _0023_003DzuFZRm0B80JtyUBGPk4Z_0024PO0_003D(double.Parse(_0023_003Dz0jxzq30_003D[1], _0023_003Dz0qLklfo_003D), double.Parse(_0023_003Dz0jxzq30_003D[2], _0023_003Dz0qLklfo_003D), result, result2));
					}
				}
			}
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
		if (_0023_003DzhDX7wsBRaAjS)
		{
			string text = Path.ChangeExtension(_0023_003DzZnRqlDfBNeJscaPd7IgEJW0_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937355));
			if (File.Exists(text))
			{
				_0023_003DzABsfpV8aaCRl(text, _0023_003DzAlu89Awr8CKh);
			}
		}
		return _0023_003DzFaMCED8PjsukeIy29w_003D_003D2;
	}

	public List<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D> _0023_003DzABsfpV8aaCRl(string _0023_003Dz_0024TtfVnZKfiWkTAe4Gg_003D_003D)
	{
		return _0023_003DzABsfpV8aaCRl(_0023_003Dz_0024TtfVnZKfiWkTAe4Gg_003D_003D, _0023_003DzAlu89Awr8CKh: false);
	}

	private List<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D> _0023_003DzABsfpV8aaCRl(string _0023_003Dz_0024TtfVnZKfiWkTAe4Gg_003D_003D, bool _0023_003DzAlu89Awr8CKh)
	{
		int num = 0;
		int num2 = 0;
		StreamReader streamReader = new StreamReader(_0023_003Dz_0024TtfVnZKfiWkTAe4Gg_003D_003D);
		List<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D> list;
		try
		{
			bool flag = false;
			if (!_0023_003DzJgiUeJw_003D(streamReader, out var _0023_003Dz0jxzq30_003D))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937988));
			}
			num = int.Parse(_0023_003Dz0jxzq30_003D[0]);
			num2 = 0;
			if (_0023_003Dz0jxzq30_003D.Length > 2)
			{
				num2 = int.Parse(_0023_003Dz0jxzq30_003D[2]);
				flag = true;
			}
			if (num2 > 1)
			{
				_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003Dz6jbnvgs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937708), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937651));
			}
			list = new List<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D>(num);
			for (int i = 0; i < num; i++)
			{
				if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937988));
				}
				if (_0023_003Dz0jxzq30_003D.Length < 4)
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937641));
				}
				_0023_003Dz2_0024IJZUpMEIC7WwHkpepgCvw_003D _0023_003Dz2_0024IJZUpMEIC7WwHkpepgCvw_003D2 = new _0023_003Dz2_0024IJZUpMEIC7WwHkpepgCvw_003D(int.Parse(_0023_003Dz0jxzq30_003D[1]) - _0023_003DzAddCv_o_003D, int.Parse(_0023_003Dz0jxzq30_003D[2]) - _0023_003DzAddCv_o_003D, int.Parse(_0023_003Dz0jxzq30_003D[3]) - _0023_003DzAddCv_o_003D);
				if (num2 > 0 && flag)
				{
					int result = 0;
					flag = int.TryParse(_0023_003Dz0jxzq30_003D[4], out result);
					_0023_003Dz2_0024IJZUpMEIC7WwHkpepgCvw_003D2._0023_003Dz7uX3t_0024g_003D = result;
				}
				list.Add(_0023_003Dz2_0024IJZUpMEIC7WwHkpepgCvw_003D2);
			}
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
		if (_0023_003DzAlu89Awr8CKh)
		{
			string text = Path.ChangeExtension(_0023_003Dz_0024TtfVnZKfiWkTAe4Gg_003D_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937608));
			if (File.Exists(text))
			{
				_0023_003Dz11xgVvWomfh7(text, num);
			}
		}
		return list;
	}

	private double[] _0023_003Dz11xgVvWomfh7(string _0023_003Dz3DtQIWYN3JeaVOoYesNK_XE_003D, int _0023_003DzvkxnrZIgQ15Hesokmw_003D_003D)
	{
		double[] array = null;
		StreamReader streamReader = new StreamReader(_0023_003Dz3DtQIWYN3JeaVOoYesNK_XE_003D);
		try
		{
			if (!_0023_003DzJgiUeJw_003D(streamReader, out var _0023_003Dz0jxzq30_003D))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937844));
			}
			if (int.Parse(_0023_003Dz0jxzq30_003D[0]) != _0023_003DzvkxnrZIgQ15Hesokmw_003D_003D)
			{
				_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003Dz6jbnvgs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937816), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937756));
				return null;
			}
			array = new double[_0023_003DzvkxnrZIgQ15Hesokmw_003D_003D];
			for (int i = 0; i < _0023_003DzvkxnrZIgQ15Hesokmw_003D_003D; i++)
			{
				if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937844));
				}
				if (_0023_003Dz0jxzq30_003D.Length != 2)
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937641));
				}
				array[i] = double.Parse(_0023_003Dz0jxzq30_003D[1], _0023_003Dz0qLklfo_003D);
			}
			return array;
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
	}

	public List<_0023_003DzDI6Y1m9lXi8KG_0024_8bQ_003D_003D> _0023_003DzbmvLXtRfUMCc(string _0023_003Dzlz_JLDs_003D, int _0023_003Dzk3WSUo_00240LUMq7AqgIg_003D_003D)
	{
		List<_0023_003DzDI6Y1m9lXi8KG_0024_8bQ_003D_003D> list = null;
		_0023_003DzAddCv_o_003D = 0;
		StreamReader streamReader = new StreamReader(_0023_003Dzlz_JLDs_003D);
		try
		{
			if (!_0023_003DzJgiUeJw_003D(streamReader, out var _0023_003Dz0jxzq30_003D))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937287));
			}
			int num = int.Parse(_0023_003Dz0jxzq30_003D[0]);
			int num2 = 0;
			if (_0023_003Dz0jxzq30_003D.Length > 1)
			{
				num2 = int.Parse(_0023_003Dz0jxzq30_003D[1]);
			}
			if (num > 0)
			{
				list = new List<_0023_003DzDI6Y1m9lXi8KG_0024_8bQ_003D_003D>(num);
			}
			for (int i = 0; i < num; i++)
			{
				if (!_0023_003DzJgiUeJw_003D(streamReader, out _0023_003Dz0jxzq30_003D))
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937287));
				}
				if (_0023_003Dz0jxzq30_003D.Length < 3)
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937263));
				}
				int num3 = int.Parse(_0023_003Dz0jxzq30_003D[1]) - _0023_003DzAddCv_o_003D;
				int num4 = int.Parse(_0023_003Dz0jxzq30_003D[2]) - _0023_003DzAddCv_o_003D;
				int _0023_003Dz7uX3t_0024g_003D = 0;
				if (num2 > 0 && _0023_003Dz0jxzq30_003D.Length > 3)
				{
					_0023_003Dz7uX3t_0024g_003D = int.Parse(_0023_003Dz0jxzq30_003D[3]);
				}
				if (num3 < 0 || num3 >= _0023_003Dzk3WSUo_00240LUMq7AqgIg_003D_003D)
				{
					if (_0023_003DzFssxjLXQIoCN._0023_003Dzgn4R6SUws5Zs())
					{
						_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003Dz6jbnvgs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937231), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937946));
					}
				}
				else if (num4 < 0 || num4 >= _0023_003Dzk3WSUo_00240LUMq7AqgIg_003D_003D)
				{
					if (_0023_003DzFssxjLXQIoCN._0023_003Dzgn4R6SUws5Zs())
					{
						_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003Dz6jbnvgs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937914), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937946));
					}
				}
				else
				{
					list.Add(new _0023_003DzDI6Y1m9lXi8KG_0024_8bQ_003D_003D(num3, num4, _0023_003Dz7uX3t_0024g_003D));
				}
			}
			return list;
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
	}
}
