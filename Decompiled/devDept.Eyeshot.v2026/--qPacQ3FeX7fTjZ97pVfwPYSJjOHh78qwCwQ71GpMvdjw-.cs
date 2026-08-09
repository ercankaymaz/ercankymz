using System;
using System.Diagnostics;
using System.IO;
using System.Text;

internal sealed class _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dz5rQzobg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Decoder _0023_003DzAvn2b38_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzR58imxw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003DzmQTFaQA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003DzWYPqg2E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzEWLeis8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzbfrNXYE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzkKfJheA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzId5C3LA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MemoryStream _0023_003Dzt_m8zV0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BinaryReader _0023_003DzshZYG54_003D;

	public _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D(_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DziDLVpbY_003D)
		: this(_0023_003DziDLVpbY_003D, new UTF8Encoding())
	{
	}

	private _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D(_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DziDLVpbY_003D, Encoding _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003Dz5rQzobg_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (!_0023_003DziDLVpbY_003D._0023_003DzZmS2S24ChN1wnkvFtQiEiiI6mLEokf_f7OnkClYx3lm_vaV_0024YtAEzTrETj_0024XsT3Fs3tXV_w_003D())
		{
			throw new ArgumentException();
		}
		this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
		_0023_003DzAvn2b38_003D = _0023_003Dz5rQzobg_003D.GetDecoder();
		_0023_003DzEWLeis8_003D = _0023_003Dz5rQzobg_003D.GetMaxCharCount(128);
		int num = _0023_003Dz5rQzobg_003D.GetMaxByteCount(1);
		if (num < 16)
		{
			num = 16;
		}
		this._0023_003Dz5rQzobg_003D = new byte[num];
		_0023_003DzWYPqg2E_003D = null;
		_0023_003DzR58imxw_003D = null;
		_0023_003DzbfrNXYE_003D = _0023_003Dz5rQzobg_003D is UnicodeEncoding;
		_0023_003DzkKfJheA_003D = this._0023_003DziDLVpbY_003D is _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D;
	}

	public _0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D()
	{
		return _0023_003DziDLVpbY_003D;
	}

	public void _0023_003Dz7pofSEdG_0024NYX0I3_0024BQ2_0hqf00GTwaC2nQ_003D_003D()
	{
		_0023_003DzAajc9NGQRNFlTYurWL6A1sZuTruqx_FW1A_003D_003D(_0023_003DziDLVpbY_003D: true);
	}

	private void _0023_003DzAajc9NGQRNFlTYurWL6A1sZuTruqx_FW1A_003D_003D(bool _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D)
		{
			_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D2 = this._0023_003DziDLVpbY_003D;
			this._0023_003DziDLVpbY_003D = null;
			_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D2?._0023_003DzJdp3nXVxphDvJioj_0024YSQX50e14JPnx1O3PkGvLb93HfKksUFJLHG0f3bUgOKWEYvVvgHFBJKHdP5f5urh57ZWgk_003D();
		}
		this._0023_003DziDLVpbY_003D = null;
		_0023_003Dz5rQzobg_003D = null;
		_0023_003DzAvn2b38_003D = null;
		_0023_003DzR58imxw_003D = null;
		_0023_003DzmQTFaQA_003D = null;
		_0023_003DzWYPqg2E_003D = null;
	}

	private void _0023_003DzrdiQu2EIVRAv5W_0024v5fpttwgAmxjfwE6VME0zyv0NbvhhYIGrk3hoksN_0024wpXqyM4sx30F2OKajw2_()
	{
		_0023_003DzAajc9NGQRNFlTYurWL6A1sZuTruqx_FW1A_003D_003D(_0023_003DziDLVpbY_003D: true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zrdiQu2EIVRAv5W$v5fpttwgAmxjfwE6VME0zyv0NbvhhYIGrk3hoksN$wpXqyM4sx30F2OKajw2_
		this._0023_003DzrdiQu2EIVRAv5W_0024v5fpttwgAmxjfwE6VME0zyv0NbvhhYIGrk3hoksN_0024wpXqyM4sx30F2OKajw2_();
	}

	public int _0023_003Dzlv2Z61gGDw_k6h6Cly4WG8Q_003D()
	{
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		if (!_0023_003DziDLVpbY_003D._0023_003DzWpbADLL4o6kgUq7wtkwgc6Ts7xNzexyhm3yYYoorSu8mGABRFiobQ7xDRwiDafuMK6Cr_OdlHBFd())
		{
			return -1;
		}
		long num = _0023_003DziDLVpbY_003D._0023_003Dzwl9sCcsvR4k6PzVcPKWWotTJzm4oD4gNUyoQC7OJjpk_00241M08s70UvYFNG9PxA9cCifL33i8_003D();
		int result = _0023_003DzkkyfVKGdVJCtzq522tnwkJnzlwz6xXsxgA_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzQZ8To03pqmaE0_0024_s_0024MPn8tSR4QVXl_JNjN3rTa3mIQ_UWPJ027H8ZJC6fkO7HSABoir32uY_003D(num);
		return result;
	}

	public int _0023_003DzkkyfVKGdVJCtzq522tnwkJnzlwz6xXsxgA_003D_003D()
	{
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		return _0023_003Dzo06jmF_p_r_0gNJpi9XHkmo_003D();
	}

	public bool _0023_003DzAtDVoioEB_pO76hvK76nIp4_003D()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(1);
		return _0023_003Dz5rQzobg_003D[0] != 0;
	}

	public byte _0023_003Dzde912cHpBbiEQCr8HB1DjQ0hCNmJS1u2_Avb9oE_003D()
	{
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		int num = _0023_003DziDLVpbY_003D._0023_003Dzrq0YfyAp0Nijy1Gvlte5XnxkCzFwVSNGc7wElpy_0024LW_0024qFsQyWHa1sQRploiX7vdAEMt_0024ksvXpwjxqTH2_0024pC_IxlcWXCn();
		if (num == -1)
		{
			throw new Exception();
		}
		return (byte)num;
	}

	public sbyte _0023_003DzfF7Q00tS_0024h8uJk_Aa9XsN5Y_003D()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(1);
		return (sbyte)_0023_003Dz5rQzobg_003D[0];
	}

	public char _0023_003Dzq020Apl3t0tTa3hDVw_003D_003D()
	{
		int num = _0023_003DzkkyfVKGdVJCtzq522tnwkJnzlwz6xXsxgA_003D_003D();
		if (num == -1)
		{
			throw new Exception();
		}
		return (char)num;
	}

	private static decimal _0023_003DzI4UyHGdmpOsZfS36WafHTiP8I1r_0024I6rq1nreSryQsH1i(int _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, int _0023_003DzR58imxw_003D)
	{
		bool isNegative = (_0023_003DzR58imxw_003D & int.MinValue) != 0;
		byte scale = (byte)(_0023_003DzR58imxw_003D >> 16);
		return new decimal(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, isNegative, scale);
	}

	internal static decimal _0023_003DzDF3TZRAnlZIHbLAv3nIgnVUC_YdQayypCQ_003D_003D(byte[] _0023_003DziDLVpbY_003D)
	{
		int num = _0023_003DziDLVpbY_003D[0] | (_0023_003DziDLVpbY_003D[1] << 8) | (_0023_003DziDLVpbY_003D[2] << 16) | (_0023_003DziDLVpbY_003D[3] << 24);
		int num2 = _0023_003DziDLVpbY_003D[4] | (_0023_003DziDLVpbY_003D[5] << 8) | (_0023_003DziDLVpbY_003D[6] << 16) | (_0023_003DziDLVpbY_003D[7] << 24);
		int num3 = _0023_003DziDLVpbY_003D[8] | (_0023_003DziDLVpbY_003D[9] << 8) | (_0023_003DziDLVpbY_003D[10] << 16) | (_0023_003DziDLVpbY_003D[11] << 24);
		int num4 = _0023_003DziDLVpbY_003D[12] | (_0023_003DziDLVpbY_003D[13] << 8) | (_0023_003DziDLVpbY_003D[14] << 16) | (_0023_003DziDLVpbY_003D[15] << 24);
		return _0023_003DzI4UyHGdmpOsZfS36WafHTiP8I1r_0024I6rq1nreSryQsH1i(num, num2, num3, num4);
	}

	public string _0023_003DzOwJERBVAuTqjh71jJLc2f5rPKwjwHUqx8z35g6c_003D()
	{
		int num = 0;
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		int num2 = _0023_003DzsEfwRuJlkmPK8_0024FnCHJmVsqM5fxi();
		if (num2 < 0)
		{
			throw new IOException();
		}
		if (num2 == 0)
		{
			return string.Empty;
		}
		if (_0023_003DzR58imxw_003D == null)
		{
			_0023_003DzR58imxw_003D = new byte[128];
		}
		if (_0023_003DzWYPqg2E_003D == null)
		{
			_0023_003DzWYPqg2E_003D = new char[_0023_003DzEWLeis8_003D];
		}
		StringBuilder stringBuilder = null;
		do
		{
			int num3 = ((num2 - num > 128) ? 128 : (num2 - num));
			int num4 = _0023_003DziDLVpbY_003D._0023_003Dzu_0024wz50Gq3LJ8xd5lgsToLbHhVCfptTZN7NjjPuQ1kWJGK38M7lFOyzt0sHhCoqpa_0024W_0024ZkwQgzp275i1d_A_003D_003D(_0023_003DzR58imxw_003D, 0, num3);
			if (num4 == 0)
			{
				throw new Exception();
			}
			int chars = _0023_003DzAvn2b38_003D.GetChars(_0023_003DzR58imxw_003D, 0, num4, _0023_003DzWYPqg2E_003D, 0);
			if (num == 0 && num4 == num2)
			{
				return new string(_0023_003DzWYPqg2E_003D, 0, chars);
			}
			if (stringBuilder == null)
			{
				stringBuilder = new StringBuilder(num2);
			}
			stringBuilder.Append(_0023_003DzWYPqg2E_003D, 0, chars);
			num += num4;
		}
		while (num < num2);
		return stringBuilder.ToString();
	}

	public int _0023_003DzPKvR2qB7g5LHDQem4NCRq8hBn_kKuDEwxA_003D_003D(char[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910256), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910233));
		}
		if (_0023_003Dz5rQzobg_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzAvn2b38_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DziDLVpbY_003D.Length - _0023_003Dz5rQzobg_003D < _0023_003DzAvn2b38_003D)
		{
			throw new ArgumentException();
		}
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		return _0023_003Dz8NE1M63devbS_UEzPZviW15NB6Nx(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
	}

	private int _0023_003Dz8NE1M63devbS_UEzPZviW15NB6Nx(char[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = _0023_003DzAvn2b38_003D;
		if (_0023_003DzR58imxw_003D == null)
		{
			_0023_003DzR58imxw_003D = new byte[128];
		}
		while (num3 > 0)
		{
			num2 = num3;
			if (_0023_003DzbfrNXYE_003D)
			{
				num2 <<= 1;
			}
			if (num2 > 128)
			{
				num2 = 128;
			}
			if (_0023_003DzkKfJheA_003D)
			{
				_0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D2 = (_0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D)this._0023_003DziDLVpbY_003D;
				int byteIndex = _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D2._0023_003DzvGW4LLMZ9Y1kwSGSMYjFhaEDQ0tv();
				num2 = _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D2._0023_003DznJf77NmtMgaDkN3wxD_00248tFuvT8gi(num2);
				if (num2 == 0)
				{
					return _0023_003DzAvn2b38_003D - num3;
				}
				num = this._0023_003DzAvn2b38_003D.GetChars(_0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D2._0023_003Dzi2oPv05k_0024QM_NYl7geg9JSI_003D(), byteIndex, num2, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
			}
			else
			{
				num2 = this._0023_003DziDLVpbY_003D._0023_003Dzu_0024wz50Gq3LJ8xd5lgsToLbHhVCfptTZN7NjjPuQ1kWJGK38M7lFOyzt0sHhCoqpa_0024W_0024ZkwQgzp275i1d_A_003D_003D(_0023_003DzR58imxw_003D, 0, num2);
				if (num2 == 0)
				{
					return _0023_003DzAvn2b38_003D - num3;
				}
				num = this._0023_003DzAvn2b38_003D.GetChars(_0023_003DzR58imxw_003D, 0, num2, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
			}
			num3 -= num;
			_0023_003Dz5rQzobg_003D += num;
		}
		return _0023_003DzAvn2b38_003D;
	}

	private int _0023_003Dzo06jmF_p_r_0gNJpi9XHkmo_003D()
	{
		int num = 0;
		int num2 = 0;
		long num3 = (num3 = 0L);
		if (_0023_003DziDLVpbY_003D._0023_003DzWpbADLL4o6kgUq7wtkwgc6Ts7xNzexyhm3yYYoorSu8mGABRFiobQ7xDRwiDafuMK6Cr_OdlHBFd())
		{
			num3 = _0023_003DziDLVpbY_003D._0023_003Dzwl9sCcsvR4k6PzVcPKWWotTJzm4oD4gNUyoQC7OJjpk_00241M08s70UvYFNG9PxA9cCifL33i8_003D();
		}
		if (_0023_003DzR58imxw_003D == null)
		{
			_0023_003DzR58imxw_003D = new byte[128];
		}
		if (_0023_003DzmQTFaQA_003D == null)
		{
			_0023_003DzmQTFaQA_003D = new char[1];
		}
		while (num == 0)
		{
			num2 = ((!_0023_003DzbfrNXYE_003D) ? 1 : 2);
			int num4 = _0023_003DziDLVpbY_003D._0023_003Dzrq0YfyAp0Nijy1Gvlte5XnxkCzFwVSNGc7wElpy_0024LW_0024qFsQyWHa1sQRploiX7vdAEMt_0024ksvXpwjxqTH2_0024pC_IxlcWXCn();
			_0023_003DzR58imxw_003D[0] = (byte)num4;
			if (num4 == -1)
			{
				num2 = 0;
			}
			if (num2 == 2)
			{
				num4 = _0023_003DziDLVpbY_003D._0023_003Dzrq0YfyAp0Nijy1Gvlte5XnxkCzFwVSNGc7wElpy_0024LW_0024qFsQyWHa1sQRploiX7vdAEMt_0024ksvXpwjxqTH2_0024pC_IxlcWXCn();
				_0023_003DzR58imxw_003D[1] = (byte)num4;
				if (num4 == -1)
				{
					num2 = 1;
				}
			}
			if (num2 == 0)
			{
				return -1;
			}
			try
			{
				num = _0023_003DzAvn2b38_003D.GetChars(_0023_003DzR58imxw_003D, 0, num2, _0023_003DzmQTFaQA_003D, 0);
			}
			catch
			{
				if (_0023_003DziDLVpbY_003D._0023_003DzWpbADLL4o6kgUq7wtkwgc6Ts7xNzexyhm3yYYoorSu8mGABRFiobQ7xDRwiDafuMK6Cr_OdlHBFd())
				{
					_0023_003DziDLVpbY_003D._0023_003DzUQ_bGErryTDpszeAu244IzixOQag9otlJo42_0024oeegDPivRgB6_0024XwD9KrkyM3tgZwAvXv4b_A7Pkg5OViPw_003D_003D(num3 - _0023_003DziDLVpbY_003D._0023_003Dzwl9sCcsvR4k6PzVcPKWWotTJzm4oD4gNUyoQC7OJjpk_00241M08s70UvYFNG9PxA9cCifL33i8_003D(), 1);
				}
				throw;
			}
		}
		if (num == 0)
		{
			return -1;
		}
		return _0023_003DzmQTFaQA_003D[0];
	}

	public char[] _0023_003Dzf9bz7bDeO8PZ0j3UXff6Ux_0024y0CLUyiHalw_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		if (_0023_003DziDLVpbY_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		char[] array = new char[_0023_003DziDLVpbY_003D];
		int num = _0023_003Dz8NE1M63devbS_UEzPZviW15NB6Nx(array, 0, _0023_003DziDLVpbY_003D);
		if (num != _0023_003DziDLVpbY_003D)
		{
			char[] array2 = new char[num];
			Buffer.BlockCopy(array, 0, array2, 0, 2 * num);
			array = array2;
		}
		return array;
	}

	public int _0023_003DzEapvsYwOJ_U3XAvMNahAv_0024opFOBsF3NjYg_003D_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003Dz5rQzobg_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzAvn2b38_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DziDLVpbY_003D.Length - _0023_003Dz5rQzobg_003D < _0023_003DzAvn2b38_003D)
		{
			throw new ArgumentException();
		}
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		return this._0023_003DziDLVpbY_003D._0023_003Dzu_0024wz50Gq3LJ8xd5lgsToLbHhVCfptTZN7NjjPuQ1kWJGK38M7lFOyzt0sHhCoqpa_0024W_0024ZkwQgzp275i1d_A_003D_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
	}

	private void _0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y()
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new Exception();
		}
	}

	public byte[] _0023_003DzHTqx834uFCnyyCcvgIa_0024NIxGD2Rybq800A_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		byte[] array = new byte[_0023_003DziDLVpbY_003D];
		int num = 0;
		do
		{
			int num2 = this._0023_003DziDLVpbY_003D._0023_003Dzu_0024wz50Gq3LJ8xd5lgsToLbHhVCfptTZN7NjjPuQ1kWJGK38M7lFOyzt0sHhCoqpa_0024W_0024ZkwQgzp275i1d_A_003D_003D(array, num, _0023_003DziDLVpbY_003D);
			if (num2 == 0)
			{
				break;
			}
			num += num2;
			_0023_003DziDLVpbY_003D -= num2;
		}
		while (_0023_003DziDLVpbY_003D > 0);
		if (num != array.Length)
		{
			byte[] array2 = new byte[num];
			Buffer.BlockCopy(array, 0, array2, 0, num);
			array = array2;
		}
		return array;
	}

	private void _0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DzrFY8bHcCJutrNSz32DQKwyAkK7h4qw4zTVKZcHq_Pm9Y();
		int num = 0;
		int num2 = 0;
		if (_0023_003DziDLVpbY_003D == 1)
		{
			num2 = this._0023_003DziDLVpbY_003D._0023_003Dzrq0YfyAp0Nijy1Gvlte5XnxkCzFwVSNGc7wElpy_0024LW_0024qFsQyWHa1sQRploiX7vdAEMt_0024ksvXpwjxqTH2_0024pC_IxlcWXCn();
			if (num2 == -1)
			{
				throw new Exception();
			}
			_0023_003Dz5rQzobg_003D[0] = (byte)num2;
			return;
		}
		do
		{
			num2 = this._0023_003DziDLVpbY_003D._0023_003Dzu_0024wz50Gq3LJ8xd5lgsToLbHhVCfptTZN7NjjPuQ1kWJGK38M7lFOyzt0sHhCoqpa_0024W_0024ZkwQgzp275i1d_A_003D_003D(_0023_003Dz5rQzobg_003D, num, _0023_003DziDLVpbY_003D - num);
			if (num2 == 0)
			{
				throw new Exception();
			}
			num += num2;
		}
		while (num < _0023_003DziDLVpbY_003D);
	}

	internal int _0023_003DzsEfwRuJlkmPK8_0024FnCHJmVsqM5fxi()
	{
		int num = 0;
		int num2 = 0;
		byte b;
		do
		{
			if (num2 == 35)
			{
				throw new FormatException();
			}
			b = _0023_003Dzde912cHpBbiEQCr8HB1DjQ0hCNmJS1u2_Avb9oE_003D();
			num |= (b & 0x7F) << num2;
			num2 += 7;
		}
		while ((b & 0x80) != 0);
		return num;
	}

	public int _0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D()
	{
		if (_0023_003DzkKfJheA_003D)
		{
			return ((_0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D)_0023_003DziDLVpbY_003D)._0023_003DzsdY66sNiEj5Kg3_Ap_0024PKjkXBp2L1QO4_0024qc5do2Brn9FJ();
		}
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(4);
		return _0023_003Dz5rQzobg_003D[0] | (_0023_003Dz5rQzobg_003D[3] << 24) | (_0023_003Dz5rQzobg_003D[1] << 16) | (_0023_003Dz5rQzobg_003D[2] << 8);
	}

	public uint _0023_003Dz6FnwpulGEWQ9qGWIVYQmBS9naiYUtq7I761iDk4_003D()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(4);
		return (uint)((_0023_003Dz5rQzobg_003D[3] << 16) | _0023_003Dz5rQzobg_003D[1] | (_0023_003Dz5rQzobg_003D[0] << 8) | (_0023_003Dz5rQzobg_003D[2] << 24));
	}

	public long _0023_003DzrHcBIDM_zm2DjlT8p4axEjulBRQCiKqBKgwhAFx8MtbF()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(8);
		byte[] array = _0023_003Dz5rQzobg_003D;
		return (uint)((array[7] << 8) | (array[2] << 24) | array[0] | (array[1] << 16)) | ((long)((array[5] << 24) | (array[6] << 16) | array[4] | (array[3] << 8)) << 32);
	}

	public ulong _0023_003DzM8tOoteQqhykBsqRmBHHCA_0024ar3Us_zxNYVoXEYanifFq()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(8);
		byte[] array = _0023_003Dz5rQzobg_003D;
		return (ulong)((uint)((array[2] << 16) | (array[5] << 24) | (array[4] << 8) | array[6]) | ((long)((array[1] << 16) | array[0] | (array[7] << 24) | (array[3] << 8)) << 32));
	}

	public short _0023_003DzBLlGVMs_2v1_00240JsyU3F1qlk_003D()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(2);
		byte[] array = _0023_003Dz5rQzobg_003D;
		return (short)((array[0] << 8) | array[1]);
	}

	public ushort _0023_003DzDXx_0024S1eebw0ZVvaacGg83AOxi3nphLEsbjBHduHOOP0A()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(2);
		byte[] array = _0023_003Dz5rQzobg_003D;
		return (ushort)(array[1] | (array[0] << 8));
	}

	private byte[] _0023_003DzdDJLNbS_46J8l9S0QX6_Gr2FjGJ2()
	{
		byte[] array = _0023_003DzId5C3LA_003D;
		if (array == null)
		{
			array = (_0023_003DzId5C3LA_003D = new byte[16]);
		}
		return array;
	}

	public float _0023_003DzVyJrzRjgRb_6vFQcY3JSzTEWU7lSeQ5kFsxKQaacPqd3()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(4);
		byte[] array = _0023_003Dz5rQzobg_003D;
		byte[] array2 = _0023_003DzdDJLNbS_46J8l9S0QX6_Gr2FjGJ2();
		array2[1] = array[1];
		array2[3] = array[0];
		array2[2] = array[2];
		array2[0] = array[3];
		return _0023_003Dz6zC3u1uSz12xNiTcYdN_0024U2Vn8AgTvScPqA_003D_003D(array2).ReadSingle();
	}

	public double _0023_003DzgGOhcKuVrSSaTfjgj463_TcD0Nga()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(8);
		byte[] array = _0023_003Dz5rQzobg_003D;
		byte[] array2 = _0023_003DzdDJLNbS_46J8l9S0QX6_Gr2FjGJ2();
		array2[5] = array[1];
		array2[2] = array[4];
		array2[0] = array[2];
		array2[3] = array[3];
		array2[7] = array[0];
		array2[4] = array[6];
		array2[1] = array[5];
		array2[6] = array[7];
		return _0023_003Dz6zC3u1uSz12xNiTcYdN_0024U2Vn8AgTvScPqA_003D_003D(array2).ReadDouble();
	}

	public decimal _0023_003DzRSrEXP_Ino_0024KtMkOKrYKjKfJYj54uaCu7ixuwjlHS0_0024z()
	{
		_0023_003DzGsif9EGLsBZk7VIk9SDCUHrTqHxMeJdAIQ_003D_003D(16);
		byte[] array = _0023_003Dz5rQzobg_003D;
		byte[] array2 = _0023_003DzdDJLNbS_46J8l9S0QX6_Gr2FjGJ2();
		array2[14] = array[11];
		array2[5] = array[12];
		array2[7] = array[9];
		array2[6] = array[1];
		array2[10] = array[8];
		array2[11] = array[10];
		array2[8] = array[3];
		array2[0] = array[14];
		array2[4] = array[15];
		array2[3] = array[13];
		array2[1] = array[2];
		array2[2] = array[6];
		array2[15] = array[7];
		array2[9] = array[4];
		array2[12] = array[0];
		array2[13] = array[5];
		return _0023_003DzDF3TZRAnlZIHbLAv3nIgnVUC_YdQayypCQ_003D_003D(array2);
	}

	private BinaryReader _0023_003Dz6zC3u1uSz12xNiTcYdN_0024U2Vn8AgTvScPqA_003D_003D(byte[] _0023_003DziDLVpbY_003D)
	{
		MemoryStream memoryStream = _0023_003Dzt_m8zV0_003D;
		BinaryReader binaryReader = _0023_003DzshZYG54_003D;
		if (memoryStream == null)
		{
			memoryStream = (_0023_003Dzt_m8zV0_003D = new MemoryStream(8));
			binaryReader = (_0023_003DzshZYG54_003D = new BinaryReader(memoryStream));
		}
		else
		{
			binaryReader.BaseStream.Position = 0L;
		}
		memoryStream.Write(_0023_003DziDLVpbY_003D, 0, _0023_003DziDLVpbY_003D.Length);
		memoryStream.Position = 0L;
		return binaryReader;
	}
}
