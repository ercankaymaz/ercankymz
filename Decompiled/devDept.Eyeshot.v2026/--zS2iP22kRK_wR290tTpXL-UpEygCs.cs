using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

internal sealed class _0023_003DzS2iP22kRK_wR290tTpXL_0024UpEygCs
{
	public sealed class _0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D : IEquatable<_0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzBJFJHwk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz40R7bAU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dzo9ajQUuoihC2;

		public _0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D()
		{
		}

		public _0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D(double _0023_003DzSbaQfts_003D, double _0023_003DzqT00BQk_003D, double _0023_003Dzw_0024BDZU1EMnEh)
		{
			_0023_003DzBJFJHwk_003D = _0023_003DzSbaQfts_003D;
			_0023_003Dz40R7bAU_003D = _0023_003DzqT00BQk_003D;
			_0023_003Dzo9ajQUuoihC2 = _0023_003Dzw_0024BDZU1EMnEh;
		}

		public bool Equals(_0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D _0023_003Dzl_0024MIsC0_003D)
		{
			if (_0023_003DzBJFJHwk_003D == _0023_003Dzl_0024MIsC0_003D._0023_003DzBJFJHwk_003D && _0023_003Dz40R7bAU_003D == _0023_003Dzl_0024MIsC0_003D._0023_003Dz40R7bAU_003D)
			{
				return _0023_003Dzo9ajQUuoihC2 == _0023_003Dzl_0024MIsC0_003D._0023_003Dzo9ajQUuoihC2;
			}
			return false;
		}
	}

	public sealed class _0023_003Dz9nTrantjxcCZ
	{
		public double _0023_003DzBJFJHwk_003D;

		public double _0023_003Dz40R7bAU_003D;
	}

	public sealed class _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D
	{
		public _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzELu0Pss_003D;

		public _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D()
		{
			_0023_003DzELu0Pss_003D = new _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D();
		}

		public _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzELu0Pss_003D)
		{
			this._0023_003DzELu0Pss_003D = _0023_003DzELu0Pss_003D;
		}
	}

	public sealed class _0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D
	{
		public List<_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D> _0023_003DzELu0Pss_003D = new List<_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D>();
	}

	internal static void _0023_003Dz6RE3dDdB6oYMmzLiHA_003D_003D(List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003Dzjp7vt9a_KZf_, _0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D _0023_003DzcDEsV8s_003D)
	{
		_0023_003DzcDEsV8s_003D._0023_003DzELu0Pss_003D.Capacity = _0023_003Dzjp7vt9a_KZf_.Count;
		for (uint num = 0u; num < _0023_003Dzjp7vt9a_KZf_.Count; num++)
		{
			_0023_003DzcDEsV8s_003D._0023_003DzELu0Pss_003D.Add(new _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D(_0023_003Dzjp7vt9a_KZf_[(int)num]));
		}
	}

	internal static void _0023_003Dz7Kd2rRX1sG0Rju1wlQ_003D_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz2cu7AHHjZWpjfY7hrA_003D_003D, _0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D[] _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D, uint _0023_003DzdqibmAx3yxAsYZYXqA_003D_003D)
	{
		_0023_003Dz2cu7AHHjZWpjfY7hrA_003D_003D._0023_003DzELu0Pss_003D._0023_003Dz_0024zhBtcOVnXUgcCvuew_003D_003D().Clear();
		_0023_003Dz2cu7AHHjZWpjfY7hrA_003D_003D._0023_003DzELu0Pss_003D._0023_003Dz_0024zhBtcOVnXUgcCvuew_003D_003D().Capacity = Convert.ToInt32(_0023_003DzdqibmAx3yxAsYZYXqA_003D_003D);
		for (uint num = 0u; num < _0023_003DzdqibmAx3yxAsYZYXqA_003D_003D; num++)
		{
			_0023_003Dz2cu7AHHjZWpjfY7hrA_003D_003D._0023_003DzELu0Pss_003D._0023_003DzXWeKxuA_003D(_0023_003DzAeL6dYpVVowMt3XsCw_003D_003D[num]._0023_003DzBJFJHwk_003D, _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D[num]._0023_003Dz40R7bAU_003D, _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D[num]._0023_003Dzo9ajQUuoihC2, null, _0023_003Dz9NRsIJI_003D: false, null, null);
		}
	}

	internal static void _0023_003Dz9DwvzeKCc9m8OIXAXFnUIdk_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz2cu7AHHjZWpjfY7hrA_003D_003D, List<_0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D> _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D)
	{
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzELu0Pss_003D = _0023_003Dz2cu7AHHjZWpjfY7hrA_003D_003D._0023_003DzELu0Pss_003D;
		uint num = _0023_003DzELu0Pss_003D._0023_003Dz14lzA48_003D();
		for (uint num2 = 0u; num2 < num; num2++)
		{
			_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2 = _0023_003DzELu0Pss_003D[(int)num2];
			_0023_003DzAeL6dYpVVowMt3XsCw_003D_003D[(int)num2] = new _0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzR216mFc_003D(), _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzqJqZpJk_003D(), _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003Dz9YAI8AkJqBvo());
		}
	}

	public static _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz7oKc1bhv1IXK_0024MMKHlKX2dM_003D(_0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D[] _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D, uint _0023_003DzdqibmAx3yxAsYZYXqA_003D_003D, int _0023_003DzYxHDE5XqsoeQ)
	{
		try
		{
			_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D2 = new _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D();
			if (_0023_003DzAeL6dYpVVowMt3XsCw_003D_003D != null)
			{
				_0023_003Dz7Kd2rRX1sG0Rju1wlQ_003D_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D2, _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D, _0023_003DzdqibmAx3yxAsYZYXqA_003D_003D);
			}
			else
			{
				_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D2._0023_003DzELu0Pss_003D._0023_003Dz_0024zhBtcOVnXUgcCvuew_003D_003D().Capacity = (int)_0023_003DzdqibmAx3yxAsYZYXqA_003D_003D;
			}
			_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D2._0023_003DzELu0Pss_003D._0023_003DzsMdAaCgjZnbt(_0023_003DzYxHDE5XqsoeQ != 0);
			return _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D2;
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzWeE6k8e9j42VLmWe0V5PjCI_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003DzRStSB1rsoNKYaya4kg_003D_003D)
	{
		try
		{
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
		}
	}

	public static uint _0023_003DzZlyJ2aNa5n4pbiDBOPxTFeo_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt)
	{
		try
		{
			return (uint)_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Capacity;
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003Dzzr0zXF7RM9QSsw2zSw2ajtw_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, uint _0023_003Dz14lzA48_003D)
	{
		try
		{
			if (_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Capacity < _0023_003Dz14lzA48_003D)
			{
				List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> list = _0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D();
				_0023_003DzLn0GWXePkO0u._0023_003Dzl2vWevE_003D(list, (int)_0023_003Dz14lzA48_003D, null);
				_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003DzaMjF0SctC6BAYh2dYw_003D_003D(list);
			}
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static uint _0023_003DzBlqYIgZjxjXl4_PTGkSo2vNEKB61cGQE_0024A_003D_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt)
	{
		try
		{
			return _0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003Dz14lzA48_003D();
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzWxi3YUZF4w86zaIVWHbQ4Y35P5wYXVsdIQ_003D_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, List<_0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D> _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D)
	{
		try
		{
			_0023_003Dz9DwvzeKCc9m8OIXAXFnUIdk_003D(_0023_003Dz_Pbwmxzwl0tt, _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static bool _0023_003DzhiBdAS1FX3yjLYjuFiAYjJw_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt)
	{
		try
		{
			return _0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003DzSIEIoKw_003D();
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzgLIH8YLwcCA7qiCDNgploQWhh8RfKWOq4A_003D_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, List<_0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D> _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D, uint _0023_003DzdqibmAx3yxAsYZYXqA_003D_003D)
	{
		try
		{
			_0023_003Dz7Kd2rRX1sG0Rju1wlQ_003D_003D(_0023_003Dz_Pbwmxzwl0tt, _0023_003DzAeL6dYpVVowMt3XsCw_003D_003D.ToArray(), _0023_003DzdqibmAx3yxAsYZYXqA_003D_003D);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzBnKtuXKVuXJ3WEvk5IoZVeswIMG7(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, _0023_003Dz4sKVLhT3tNY9R2RzGg_003D_003D _0023_003DzkEYxO1SuR1Kw)
	{
		try
		{
			_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003DzXWeKxuA_003D(_0023_003DzkEYxO1SuR1Kw._0023_003DzBJFJHwk_003D, _0023_003DzkEYxO1SuR1Kw._0023_003Dz40R7bAU_003D, _0023_003DzkEYxO1SuR1Kw._0023_003Dzo9ajQUuoihC2, null, _0023_003Dz9NRsIJI_003D: false, null, null);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzSv7VJ81NwPA_0024Jjzlb5vvpj8_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, uint _0023_003Dz52ot2GfMKLd9, uint _0023_003Dzfsn580w_003D)
	{
		try
		{
			_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003Dz_0024zhBtcOVnXUgcCvuew_003D_003D().RemoveRange((int)_0023_003Dz52ot2GfMKLd9, (int)_0023_003Dzfsn580w_003D);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzZe7rZx02sm7ESGxklzesMfo_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt)
	{
		try
		{
			_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003Dz_0024zhBtcOVnXUgcCvuew_003D_003D().Clear();
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003Dz3MWKIwu_cyCqFU0RFdvFKbWflQVJ(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, int _0023_003DzYxHDE5XqsoeQ)
	{
		try
		{
			_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D._0023_003DzsMdAaCgjZnbt(_0023_003DzYxHDE5XqsoeQ != 0);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzURsaLo1TrRbknOWfwRddAcNCS2Zr(ref _0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D _0023_003DzCG5FgyvwevcURT_6Lw_003D_003D)
	{
		try
		{
			_0023_003DzCG5FgyvwevcURT_6Lw_003D_003D = null;
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static int _0023_003Dzo0lH0A4v4vJEOQNrZsMqkQLri_0024VU(_0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D _0023_003DzCG5FgyvwevcURT_6Lw_003D_003D)
	{
		try
		{
			return _0023_003DzCG5FgyvwevcURT_6Lw_003D_003D._0023_003DzELu0Pss_003D.Count;
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003DzSkLcIdjy_0024_0024klm5CWNaFOfow_003D(_0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D _0023_003DzCG5FgyvwevcURT_6Lw_003D_003D, uint _0023_003DzyzK8swU_003D)
	{
		try
		{
			return _0023_003DzCG5FgyvwevcURT_6Lw_003D_003D._0023_003DzELu0Pss_003D[(int)_0023_003DzyzK8swU_003D];
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzKUcMwFNK2RXrRZtw9grNtpZELTRJ(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, double _0023_003DzEEncnNQ_003D, _0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D _0023_003DzOkHnHgY_003D, int _0023_003Dz4rtumMd0NQfq, bool _0023_003DzcM9W6B4hvS52)
	{
		try
		{
			bool _0023_003DzsuJwsNonXKUJ = (_0023_003Dz4rtumMd0NQfq & 1) != 0;
			_0023_003Dz6RE3dDdB6oYMmzLiHA_003D_003D(_0023_003Dzjpa4idEx_0024nUarOiwkxe35rs_003D._0023_003Dzz_0024j730dooPtTZsdM1A_003D_003D(_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D, _0023_003DzEEncnNQ_003D, out var _, _0023_003DzcM9W6B4hvS52, _0023_003DzsuJwsNonXKUJ), _0023_003DzOkHnHgY_003D);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzULl2kOvxdKVg_0024c20tDe_0024TXtoauGn(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz0aaxWra_0024aSv_, _0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003DzMwHMMyeJx_L9, int _0023_003Dzio5AYGZ56N9jQeR2oQ_003D_003D, ref _0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D _0023_003DzNBFv6Go_003D, ref _0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D _0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D)
	{
		try
		{
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D obj = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dz0aaxWra_0024aSv_._0023_003DzELu0Pss_003D, _0023_003DzMwHMMyeJx_L9._0023_003DzELu0Pss_003D, _0023_003Dzio5AYGZ56N9jQeR2oQ_003D_003D switch
			{
				0 => (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)0, 
				1 => (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1, 
				2 => (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)2, 
				3 => (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)3, 
				_ => (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)0, 
			});
			_0023_003DzNBFv6Go_003D = new _0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D();
			_0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D = new _0023_003DzuzgyFMXKQR6LaAlY2dZNDGk_003D();
			_0023_003Dz6RE3dDdB6oYMmzLiHA_003D_003D(obj._0023_003DzNBFv6Go_003D, _0023_003DzNBFv6Go_003D);
			_0023_003Dz6RE3dDdB6oYMmzLiHA_003D_003D(obj._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D, _0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static double _0023_003Dz_0024WEuY7W1eCr0yBLJD0WeVu0_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt)
	{
		try
		{
			return _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D._0023_003Dz8valiGxIV7M0(_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static double _0023_003DzPlvT2hjSdmzX0UMI4g_003D_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt)
	{
		try
		{
			return _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D._0023_003DzyvZg648_003D(_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D);
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static int _0023_003Dzk_6u3mKRWCkVL42_0024WBKuVvLFq7aS(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, _0023_003Dz9nTrantjxcCZ _0023_003DzlY77YgY_003D)
	{
		try
		{
			return _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D._0023_003DzZtTSXL4qGrKajYEroQ_003D_003D(_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D, new _0023_003DzcQiRB3Mv_00246WF(_0023_003DzlY77YgY_003D._0023_003DzBJFJHwk_003D, _0023_003DzlY77YgY_003D._0023_003Dz40R7bAU_003D));
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzgbaP2NpslzK28Ti2y7zQips_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, ref double _0023_003DzseEZtf7V5fvR, ref double _0023_003Dz9f8a25bDTROb, ref double _0023_003DzsG5dDnzpMwvU, ref double _0023_003DzGR8OXAdFarLt)
	{
		try
		{
			_0023_003Dzz0hYUpqvcjySAw6KhA_003D_003D _0023_003Dzz0hYUpqvcjySAw6KhA_003D_003D2 = _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D._0023_003DzOO0_c5k_003D(_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D);
			_0023_003DzseEZtf7V5fvR = _0023_003Dzz0hYUpqvcjySAw6KhA_003D_003D2._0023_003DzWpVWsQY_003D;
			_0023_003Dz9f8a25bDTROb = _0023_003Dzz0hYUpqvcjySAw6KhA_003D_003D2._0023_003Dz39eM9Rw_003D;
			_0023_003DzsG5dDnzpMwvU = _0023_003Dzz0hYUpqvcjySAw6KhA_003D_003D2._0023_003Dz57Rju04_003D;
			_0023_003DzGR8OXAdFarLt = _0023_003Dzz0hYUpqvcjySAw6KhA_003D_003D2._0023_003Dz0CbgKvI_003D;
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}

	public static void _0023_003DzGNDQHiGymRCLFPnzdXggNNg_003D(_0023_003DzsEF8ynXdpfLHMMezSg_003D_003D _0023_003Dz_Pbwmxzwl0tt, _0023_003Dz9nTrantjxcCZ _0023_003DzmB_0024Kqs0jqSmX, ref uint _0023_003DzoNeaIa8NNWkH, ref _0023_003Dz9nTrantjxcCZ _0023_003DzVeJXcde_I3rg, ref double _0023_003DzYUMqwZQ_003D)
	{
		try
		{
			_0023_003DzEVkdNic3udBPyFTu_0024A_003D_003D _0023_003DzEVkdNic3udBPyFTu_0024A_003D_003D2 = new _0023_003DzEVkdNic3udBPyFTu_0024A_003D_003D(_0023_003Dz_Pbwmxzwl0tt._0023_003DzELu0Pss_003D, new _0023_003DzcQiRB3Mv_00246WF(_0023_003DzmB_0024Kqs0jqSmX._0023_003DzBJFJHwk_003D, _0023_003DzmB_0024Kqs0jqSmX._0023_003Dz40R7bAU_003D));
			_0023_003DzoNeaIa8NNWkH = _0023_003DzEVkdNic3udBPyFTu_0024A_003D_003D2._0023_003DzyzK8swU_003D();
			_0023_003DzVeJXcde_I3rg = new _0023_003Dz9nTrantjxcCZ
			{
				_0023_003DzBJFJHwk_003D = _0023_003DzEVkdNic3udBPyFTu_0024A_003D_003D2._0023_003DzlY77YgY_003D()._0023_003DzR216mFc_003D(),
				_0023_003Dz40R7bAU_003D = _0023_003DzEVkdNic3udBPyFTu_0024A_003D_003D2._0023_003DzlY77YgY_003D()._0023_003DzqJqZpJk_003D()
			};
			_0023_003DzYUMqwZQ_003D = _0023_003DzEVkdNic3udBPyFTu_0024A_003D_003D2._0023_003DzYUMqwZQ_003D();
		}
		catch (Exception ex)
		{
			Console.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941466) + MethodBase.GetCurrentMethod().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message);
			throw;
		}
	}
}
