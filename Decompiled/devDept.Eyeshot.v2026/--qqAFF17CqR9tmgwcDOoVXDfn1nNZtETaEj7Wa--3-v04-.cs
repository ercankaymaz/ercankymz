using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;

internal sealed class _0023_003DqqAFF17CqR9tmgwcDOoVXDfn1nNZtETaEj7Wa_0024_00243_0024v04_003D : IDisposable
{
	private sealed class _0023_003DziDLVpbY_003D
	{
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqCamkBM7Pyb2IDEnDiYrsczoWQmJb7bqMzEgXGBY7DmE_003D m__0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D _0023_003Dz5rQzobg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzAvn2b38_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzR58imxw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static volatile Type _0023_003DzmQTFaQA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzWYPqg2E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEWLeis8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SymmetricAlgorithm _0023_003DzbfrNXYE_003D;

	public _0023_003DqqAFF17CqR9tmgwcDOoVXDfn1nNZtETaEj7Wa_0024_00243_0024v04_003D()
	{
		_0023_003Dz3Y05bSqCbyfMtTrn3ZPqG1Ol6DDZ((_0023_003DqCamkBM7Pyb2IDEnDiYrsczoWQmJb7bqMzEgXGBY7DmE_003D)1);
	}

	public void Dispose()
	{
		((IDisposable)_0023_003DzbfrNXYE_003D)?.Dispose();
	}

	public _0023_003DqCamkBM7Pyb2IDEnDiYrsczoWQmJb7bqMzEgXGBY7DmE_003D _0023_003DzV1XDE18mH3R8HAzotUnZgaE_003D()
	{
		return this.m__0023_003DziDLVpbY_003D;
	}

	public void _0023_003Dz3Y05bSqCbyfMtTrn3ZPqG1Ol6DDZ(_0023_003DqCamkBM7Pyb2IDEnDiYrsczoWQmJb7bqMzEgXGBY7DmE_003D _0023_003DziDLVpbY_003D)
	{
		if (this.m__0023_003DziDLVpbY_003D != _0023_003DziDLVpbY_003D)
		{
			this.m__0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
			_0023_003DzEWLeis8_003D = true;
		}
	}

	public _0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D _0023_003Dz60gSlaxhPbyFqhc92oabBnC_0024yoQ_0024mLvGzv_jhp4_003D()
	{
		return _0023_003Dz5rQzobg_003D;
	}

	public void _0023_003DzpIqsaG5s_0024d77OMyFjMF_0024hwgWA_UEjjWYuuuCY3qM5Gt8(_0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003Dz5rQzobg_003D != _0023_003DziDLVpbY_003D)
		{
			_0023_003Dz5rQzobg_003D = _0023_003DziDLVpbY_003D;
			_0023_003DzEWLeis8_003D = true;
		}
	}

	public byte[] _0023_003Dzr04AhMkN2HrCTrOjlzkf2HamevaX()
	{
		return _0023_003DzAvn2b38_003D;
	}

	public void _0023_003DzhriuXvk6OTYxyHyL5eIXX5CV_0024nV1vZ37Cg_003D_003D(byte[] _0023_003DziDLVpbY_003D)
	{
		_0023_003DzAvn2b38_003D = _0023_003DziDLVpbY_003D;
		_0023_003DzEWLeis8_003D = true;
	}

	public byte[] _0023_003DzKvEkAi3qu9qxDeu2cz_0024qDmM_003D()
	{
		return _0023_003DzR58imxw_003D;
	}

	public void _0023_003DzYJM7OEzFo9Uao6USz0xr5Uw_003D(byte[] _0023_003DziDLVpbY_003D)
	{
		_0023_003DzR58imxw_003D = _0023_003DziDLVpbY_003D;
		_0023_003DzEWLeis8_003D = true;
	}

	private static SymmetricAlgorithm _0023_003DzeN9iOWRRxFVa_qwAsKDjqH3q09MCOnyFF8kMjkw_003D()
	{
		if (_0023_003DzmQTFaQA_003D != null)
		{
			if (_0023_003DzmQTFaQA_003D == typeof(_0023_003DziDLVpbY_003D))
			{
				return null;
			}
			return Activator.CreateInstance(_0023_003DzmQTFaQA_003D) as SymmetricAlgorithm;
		}
		_0023_003DzmQTFaQA_003D = typeof(_0023_003DziDLVpbY_003D);
		Assembly assembly = null;
		try
		{
			assembly = Assembly.Load(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910905));
		}
		catch
		{
		}
		if (assembly == null)
		{
			return null;
		}
		try
		{
			Type type = assembly.GetType(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910576));
			if (type != null)
			{
				SymmetricAlgorithm result = Activator.CreateInstance(type) as SymmetricAlgorithm;
				_0023_003DzmQTFaQA_003D = type;
				return result;
			}
		}
		catch
		{
		}
		try
		{
			Type type2 = assembly.GetType(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910508));
			if (type2 != null)
			{
				SymmetricAlgorithm result2 = Activator.CreateInstance(type2) as SymmetricAlgorithm;
				_0023_003DzmQTFaQA_003D = type2;
				return result2;
			}
		}
		catch
		{
		}
		return null;
	}

	private static CipherMode _0023_003Dz7e4_0024GwzFqdTZT5O3hGmB7xSX1xzWV4onlw_003D_003D(_0023_003DqCamkBM7Pyb2IDEnDiYrsczoWQmJb7bqMzEgXGBY7DmE_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D == (_0023_003DqCamkBM7Pyb2IDEnDiYrsczoWQmJb7bqMzEgXGBY7DmE_003D)1)
		{
			return CipherMode.CBC;
		}
		throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910714));
	}

	private static PaddingMode _0023_003DzoLsqfqM4qD7t9yiP6EvFyXMTbSR8BOkQ3nVTKLs_003D(_0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D _0023_003DziDLVpbY_003D)
	{
		return _0023_003DziDLVpbY_003D switch
		{
			(_0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D)1 => PaddingMode.None, 
			(_0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D)2 => PaddingMode.PKCS7, 
			_ => throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910683)), 
		};
	}

	public _0023_003Dqnm1S8JiabN5PaFT5RW161C_0024asKd3bFI0NpQTXPlr06w_003D _0023_003DzPMTZQWmC_kxC4_00248Hi1yTyfjjEzDt()
	{
		return _0023_003Dzy8axZ8FPK_VZjQYqSNpW2ro_003D(_0023_003DziDLVpbY_003D: true);
	}

	public _0023_003Dqnm1S8JiabN5PaFT5RW161C_0024asKd3bFI0NpQTXPlr06w_003D _0023_003DzqCERRgWn1UAgxXgLK0NsYhZaoIjZ()
	{
		return _0023_003Dzy8axZ8FPK_VZjQYqSNpW2ro_003D(_0023_003DziDLVpbY_003D: false);
	}

	private _0023_003Dqnm1S8JiabN5PaFT5RW161C_0024asKd3bFI0NpQTXPlr06w_003D _0023_003Dzy8axZ8FPK_VZjQYqSNpW2ro_003D(bool _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzWYPqg2E_003D)
		{
			bool flag = _0023_003DzEWLeis8_003D || _0023_003DzbfrNXYE_003D == null;
			if (_0023_003DzbfrNXYE_003D == null)
			{
				_0023_003DzbfrNXYE_003D = _0023_003DzeN9iOWRRxFVa_qwAsKDjqH3q09MCOnyFF8kMjkw_003D();
				if (_0023_003DzbfrNXYE_003D == null)
				{
					_0023_003DzWYPqg2E_003D = true;
				}
			}
			if (_0023_003DzbfrNXYE_003D != null)
			{
				if (flag)
				{
					_0023_003DzbfrNXYE_003D.Key = _0023_003Dzr04AhMkN2HrCTrOjlzkf2HamevaX();
					_0023_003DzbfrNXYE_003D.IV = _0023_003DzKvEkAi3qu9qxDeu2cz_0024qDmM_003D();
					_0023_003DzbfrNXYE_003D.Mode = _0023_003Dz7e4_0024GwzFqdTZT5O3hGmB7xSX1xzWV4onlw_003D_003D(_0023_003DzV1XDE18mH3R8HAzotUnZgaE_003D());
					_0023_003DzbfrNXYE_003D.Padding = _0023_003DzoLsqfqM4qD7t9yiP6EvFyXMTbSR8BOkQ3nVTKLs_003D(_0023_003Dz60gSlaxhPbyFqhc92oabBnC_0024yoQ_0024mLvGzv_jhp4_003D());
				}
				return new _0023_003DqFlaG9QJSeGmw5xvY6juCN6jDkC1D5jdltuvEV3ioCAA_003D(_0023_003DziDLVpbY_003D ? _0023_003DzbfrNXYE_003D.CreateEncryptor() : _0023_003DzbfrNXYE_003D.CreateDecryptor());
			}
		}
		_0023_003DqlX2hFu2wN5f6DhPiKQE4GJbH7OlVpvptxHmR2S89xK4_003D _0023_003DqlX2hFu2wN5f6DhPiKQE4GJbH7OlVpvptxHmR2S89xK4_003D2 = new _0023_003DqlX2hFu2wN5f6DhPiKQE4GJbH7OlVpvptxHmR2S89xK4_003D(new _0023_003Dq4OhRvt2sLe4PD9nLI_GOIFTt5RF8bsbJ5x9P5zMU9eA_003D());
		_0023_003Dqqr0fJcmNHD_002426q7CfYl3TAO1DKprAE1BJrkSiB_CfFM_003D _0023_003Dqqr0fJcmNHD_002426q7CfYl3TAO1DKprAE1BJrkSiB_CfFM_003D2 = ((_0023_003Dz60gSlaxhPbyFqhc92oabBnC_0024yoQ_0024mLvGzv_jhp4_003D() == (_0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D)1) ? new _0023_003Dqqr0fJcmNHD_002426q7CfYl3TAO1DKprAE1BJrkSiB_CfFM_003D(_0023_003DqlX2hFu2wN5f6DhPiKQE4GJbH7OlVpvptxHmR2S89xK4_003D2) : new _0023_003Dqhu8iWDnFsbbcNK8gRnbmYaG4e9ifFUBFoAC8MFG7b30_003D(_0023_003DqlX2hFu2wN5f6DhPiKQE4GJbH7OlVpvptxHmR2S89xK4_003D2, _0023_003DzSrRwphpiizl7nN_tXYmyMoM_003D(_0023_003Dz60gSlaxhPbyFqhc92oabBnC_0024yoQ_0024mLvGzv_jhp4_003D())));
		_0023_003DquMh_RbFIfA6Odscsrwq4H4t9WpiGpsywUz8UYTg9PQw_003D _0023_003DquMh_RbFIfA6Odscsrwq4H4t9WpiGpsywUz8UYTg9PQw_003D2 = new _0023_003DquMh_RbFIfA6Odscsrwq4H4t9WpiGpsywUz8UYTg9PQw_003D(new _0023_003DqTnc2yZaUcqEcx7uiqB96ztHLdTV124OG9zwPJteCwqI_003D(_0023_003Dzr04AhMkN2HrCTrOjlzkf2HamevaX()), _0023_003DzKvEkAi3qu9qxDeu2cz_0024qDmM_003D());
		_0023_003Dqqr0fJcmNHD_002426q7CfYl3TAO1DKprAE1BJrkSiB_CfFM_003D2._0023_003DzH0W9gGm_6Zy4fxWleaec9QscfDQ41Foe_0024QJ_Z5M0xjosL6lU971WHp_CmCQ_pHt1dBxQpMd4JiyFWGO5vDZAf3E_003D(_0023_003DziDLVpbY_003D, _0023_003DquMh_RbFIfA6Odscsrwq4H4t9WpiGpsywUz8UYTg9PQw_003D2);
		return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqqftY9jn8NOLakAAstU4AZ0_003D(_0023_003Dqqr0fJcmNHD_002426q7CfYl3TAO1DKprAE1BJrkSiB_CfFM_003D2);
	}

	private static _0023_003DqJTjaQmhkW8F60LVdPhnyD28suQYp1eKJDTElj4I43ME_003D _0023_003DzSrRwphpiizl7nN_tXYmyMoM_003D(_0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D _0023_003DziDLVpbY_003D)
	{
		return _0023_003DziDLVpbY_003D switch
		{
			(_0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D)1 => null, 
			(_0023_003DqV6Pla8GvwrNbR9D38ddYuQr_0024GbFuW3zP9W_0024L5gvA2LM_003D)2 => new _0023_003Dq3vLB_0024dDS_0024WafwlZ3ExhYkDZlmwcihh6CK18JoRqKdBc_003D(), 
			_ => throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910683)), 
		};
	}
}
