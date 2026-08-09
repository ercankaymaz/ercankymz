using System;
using System.Collections.Generic;
using System.Globalization;
using devDept.Geometry;

internal sealed class _0023_003DzlsB1ow9F6_Wcr4ux_0024_JD7Iahu_0024L4
{
	private List<string[]> _0023_003Dz3la5Iva4byUn;

	private List<string> _0023_003Dz76NC2EsQMG0l;

	private List<string> _0023_003DzofGql9S9Mujx;

	private double[][] _0023_003DzJ4v7lIYOWYukelGE1w_003D_003D;

	private float _0023_003DzkyeWGW1v4ZEK;

	private string _0023_003Dz5u1h8ec_003D;

	private Dictionary<string, List<object[]>> _0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq;

	private Dictionary<string, List<object[]>> _0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D;

	private Dictionary<string, List<object[]>> _0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D;

	public _0023_003DzlsB1ow9F6_Wcr4ux_0024_JD7Iahu_0024L4()
	{
		_0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq = new Dictionary<string, List<object[]>>();
		_0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D = new Dictionary<string, List<object[]>>();
		_0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D = new Dictionary<string, List<object[]>>();
		_0023_003Dz76NC2EsQMG0l = new List<string>();
		_0023_003DzofGql9S9Mujx = new List<string>();
	}

	public virtual void _0023_003Dzxq8pNS0_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzkyeWGW1v4ZEK = Utility.FloatParse(_0023_003DzPzO_0024GUk_003D);
	}

	public virtual float _0023_003DzxS4fhlkxDQAJ()
	{
		return _0023_003DzkyeWGW1v4ZEK;
	}

	public virtual void _0023_003Dz8MI5JYEGqXMp(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz5u1h8ec_003D = _0023_003DzPzO_0024GUk_003D.Trim();
	}

	public virtual List<string[]> _0023_003DzaAWBnjSVRD6c()
	{
		if (_0023_003Dz3la5Iva4byUn == null)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			IEnumerator<string> enumerator = _0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				foreach (object[] item in _0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq[current])
				{
					int[] array = (int[])item[1];
					num += array.Length / 3;
				}
			}
			IEnumerator<string> enumerator3 = _0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D.Keys.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				string current2 = enumerator3.Current;
				List<object[]> list = _0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D[current2];
				num2 += list.Count;
			}
			IEnumerator<string> enumerator4 = _0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D.Keys.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				string current3 = enumerator4.Current;
				foreach (object[] item2 in _0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D[current3])
				{
					IList<double> list2 = (IList<double>)item2[0];
					num3 += list2.Count / 3;
				}
			}
			_0023_003Dz3la5Iva4byUn = new List<string[]>();
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934194),
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934180)
			});
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934145),
				Convert.ToString(_0023_003DzkyeWGW1v4ZEK, CultureInfo.InvariantCulture.NumberFormat)
			});
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934159),
				_0023_003Dz5u1h8ec_003D
			});
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				string.Empty,
				string.Empty
			});
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934909),
				Convert.ToString(num, CultureInfo.InvariantCulture.NumberFormat)
			});
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934867),
				Convert.ToString(num2, CultureInfo.InvariantCulture.NumberFormat)
			});
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934861),
				Convert.ToString(num3, CultureInfo.InvariantCulture.NumberFormat)
			});
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934822),
				Convert.ToString(_0023_003Dz76NC2EsQMG0l.Count, CultureInfo.InvariantCulture.NumberFormat)
			});
			foreach (string item3 in _0023_003Dz76NC2EsQMG0l)
			{
				_0023_003Dz3la5Iva4byUn.Add(new string[2]
				{
					string.Empty,
					item3
				});
			}
			_0023_003Dz3la5Iva4byUn.Add(new string[2]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934794),
				Convert.ToString(_0023_003DzofGql9S9Mujx.Count, CultureInfo.InvariantCulture.NumberFormat)
			});
			foreach (string item4 in _0023_003DzofGql9S9Mujx)
			{
				_0023_003Dz3la5Iva4byUn.Add(new string[2]
				{
					string.Empty,
					item4
				});
			}
		}
		return _0023_003Dz3la5Iva4byUn;
	}

	public virtual Dictionary<string, bool> _0023_003DzFv4IHz30d_0f()
	{
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		IEnumerator<string> enumerator = _0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			dictionary[enumerator.Current] = true;
		}
		IEnumerator<string> enumerator2 = _0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D.Keys.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			dictionary[enumerator2.Current] = true;
		}
		IEnumerator<string> enumerator3 = _0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D.Keys.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			dictionary[enumerator3.Current] = true;
		}
		return dictionary;
	}

	public virtual double[][] _0023_003DzMwNJNAeR95Tf0hOLSw_003D_003D()
	{
		return _0023_003DzJ4v7lIYOWYukelGE1w_003D_003D;
	}

	public virtual Dictionary<string, List<object[]>> _0023_003DzQbn3GXkIXf2H()
	{
		return _0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq;
	}

	public virtual Dictionary<string, List<object[]>> _0023_003Dz0pimFMbu4BgZzaiQ_0024A_003D_003D()
	{
		return _0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D;
	}

	public virtual Dictionary<string, List<object[]>> _0023_003DzYNux6PWoz6TL()
	{
		return _0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D;
	}

	public virtual void _0023_003Dzrm_ZNij9J2CVK_0024YrlA_003D_003D(double[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int[] _0023_003DzDPPdnUk_003D, double[] _0023_003DzZQ2HyLn4R0pl, double[] _0023_003DzztJY0_0024dXEFMk, string _0023_003DzaROjBYA_003D)
	{
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i += 3)
		{
			_0023_003DzlcoZyrC70kvY(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 2]);
		}
		if (!_0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq.ContainsKey(_0023_003DzaROjBYA_003D))
		{
			_0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq[_0023_003DzaROjBYA_003D] = new List<object[]>();
		}
		_0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq[_0023_003DzaROjBYA_003D].Add(new object[4] { _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzDPPdnUk_003D, _0023_003DzZQ2HyLn4R0pl, _0023_003DzztJY0_0024dXEFMk });
	}

	public virtual void _0023_003Dz8l58VOiDiXMZO2hepw_003D_003D(IList<double[]> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<double[]> _0023_003DzZQ2HyLn4R0pl, string _0023_003DzaROjBYA_003D)
	{
		foreach (double[] item in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
		{
			_0023_003DzlcoZyrC70kvY(item[0], item[1], item[2]);
		}
		if (!_0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D.ContainsKey(_0023_003DzaROjBYA_003D))
		{
			_0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D[_0023_003DzaROjBYA_003D] = new List<object[]>();
		}
		_0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D[_0023_003DzaROjBYA_003D].Add(new object[2] { _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzZQ2HyLn4R0pl });
	}

	public virtual void _0023_003Dzoq64prs_003D(IList<double> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<float> _0023_003DzZQ2HyLn4R0pl, string _0023_003DzaROjBYA_003D)
	{
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i += 3)
		{
			_0023_003DzlcoZyrC70kvY(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 2]);
		}
		if (!_0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D.ContainsKey(_0023_003DzaROjBYA_003D))
		{
			_0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D[_0023_003DzaROjBYA_003D] = new List<object[]>();
		}
		_0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D[_0023_003DzaROjBYA_003D].Add(new object[2] { _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzZQ2HyLn4R0pl });
	}

	public virtual void _0023_003DzpQMK2FLbnaBX(string _0023_003DzYWqyvPg_003D, bool _0023_003Dz_0024_0024e24_00240_003D)
	{
		if (_0023_003Dz_0024_0024e24_00240_003D)
		{
			if (!_0023_003Dz76NC2EsQMG0l.Contains(_0023_003DzYWqyvPg_003D))
			{
				_0023_003Dz76NC2EsQMG0l.Add(_0023_003DzYWqyvPg_003D);
			}
		}
		else if (!_0023_003DzofGql9S9Mujx.Contains(_0023_003DzYWqyvPg_003D))
		{
			_0023_003DzofGql9S9Mujx.Add(_0023_003DzYWqyvPg_003D);
		}
	}

	private void _0023_003DzlcoZyrC70kvY(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D)
	{
		if (_0023_003DzJ4v7lIYOWYukelGE1w_003D_003D == null)
		{
			_0023_003DzJ4v7lIYOWYukelGE1w_003D_003D = new double[2][]
			{
				new double[3] { _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D },
				new double[3] { _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D }
			};
			return;
		}
		if (_0023_003DzBJFJHwk_003D < _0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[0][0])
		{
			_0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[0][0] = _0023_003DzBJFJHwk_003D;
		}
		else if (_0023_003DzBJFJHwk_003D > _0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[1][0])
		{
			_0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[1][0] = _0023_003DzBJFJHwk_003D;
		}
		if (_0023_003Dz40R7bAU_003D < _0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[0][1])
		{
			_0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[0][1] = _0023_003Dz40R7bAU_003D;
		}
		else if (_0023_003Dz40R7bAU_003D > _0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[1][1])
		{
			_0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[1][1] = _0023_003Dz40R7bAU_003D;
		}
		if (_0023_003DzId5C3LA_003D < _0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[0][2])
		{
			_0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[0][2] = _0023_003DzId5C3LA_003D;
		}
		else if (_0023_003DzId5C3LA_003D > _0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[1][2])
		{
			_0023_003DzJ4v7lIYOWYukelGE1w_003D_003D[1][2] = _0023_003DzId5C3LA_003D;
		}
	}

	public virtual bool _0023_003Dzu0QISWA_HRnE(string _0023_003DzaROjBYA_003D)
	{
		if (!_0023_003Dzxc92BOzddQEMzoSYs0IJr7SPeyPq.ContainsKey(_0023_003DzaROjBYA_003D) && !_0023_003DzL8S6hQ817sCRopL9r9qHIgpfXaVCS4Pd3A_003D_003D.ContainsKey(_0023_003DzaROjBYA_003D))
		{
			return _0023_003DzXCW3vwVSiI75kRMT35a_0024mn8_003D.ContainsKey(_0023_003DzaROjBYA_003D);
		}
		return true;
	}
}
