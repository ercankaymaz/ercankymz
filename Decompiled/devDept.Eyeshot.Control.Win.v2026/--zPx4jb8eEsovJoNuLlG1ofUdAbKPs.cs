using System.Diagnostics;
using System.Drawing;
using System.Globalization;

internal struct _0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs(int _0023_003DzhXpC6io_003D, int _0023_003DzZvnPBFw_003D, int _0023_003DzHavyKeA_003D, int _0023_003DznPWAePU_003D)
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int _0023_003DzCT_RrjI_003D = _0023_003DzhXpC6io_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int _0023_003Dzc1_0024Vycc_003D = _0023_003DzZvnPBFw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int _0023_003Dz4cDj0E0_003D = _0023_003DzHavyKeA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int _0023_003DzSD1Un3c_003D = _0023_003DznPWAePU_003D;

	public _0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs(Rectangle _0023_003DzpGw_0024feA_003D)
		: this(_0023_003DzpGw_0024feA_003D.Left, _0023_003DzpGw_0024feA_003D.Top, _0023_003DzpGw_0024feA_003D.Right, _0023_003DzpGw_0024feA_003D.Bottom)
	{
	}

	public int _0023_003DzGL_0024NIyk_003D()
	{
		return _0023_003DzCT_RrjI_003D;
	}

	public void _0023_003DzD5XGV9s_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz4cDj0E0_003D -= _0023_003DzCT_RrjI_003D - _0023_003DzsLHxXyo_003D;
		_0023_003DzCT_RrjI_003D = _0023_003DzsLHxXyo_003D;
	}

	public int _0023_003Dz7rXMpdc_003D()
	{
		return _0023_003Dzc1_0024Vycc_003D;
	}

	public void _0023_003DzWufYn1k_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzSD1Un3c_003D -= _0023_003Dzc1_0024Vycc_003D - _0023_003DzsLHxXyo_003D;
		_0023_003Dzc1_0024Vycc_003D = _0023_003DzsLHxXyo_003D;
	}

	public int _0023_003DzJndH3qzbRKM7()
	{
		return _0023_003DzSD1Un3c_003D - _0023_003Dzc1_0024Vycc_003D;
	}

	public void _0023_003Dz5PfPifm15qTy(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzSD1Un3c_003D = _0023_003DzsLHxXyo_003D + _0023_003Dzc1_0024Vycc_003D;
	}

	public int _0023_003Dzd3wwRAyZ0u7z()
	{
		return _0023_003Dz4cDj0E0_003D - _0023_003DzCT_RrjI_003D;
	}

	public void _0023_003Dz6hi5XBwx6UEG(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz4cDj0E0_003D = _0023_003DzsLHxXyo_003D + _0023_003DzCT_RrjI_003D;
	}

	public Point _0023_003DzRas_j1uFJyTi()
	{
		return new Point(_0023_003DzCT_RrjI_003D, _0023_003Dzc1_0024Vycc_003D);
	}

	public void _0023_003DzJajQHFZmoQKE(Point _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzD5XGV9s_003D(_0023_003DzsLHxXyo_003D.X);
		_0023_003DzWufYn1k_003D(_0023_003DzsLHxXyo_003D.Y);
	}

	public Size _0023_003DzL2jAKGI_003D()
	{
		return new Size(_0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7());
	}

	public void _0023_003DzYcnVJ_00240_003D(Size _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz6hi5XBwx6UEG(_0023_003DzsLHxXyo_003D.Width);
		_0023_003Dz5PfPifm15qTy(_0023_003DzsLHxXyo_003D.Height);
	}

	public static implicit operator Rectangle(_0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs _0023_003DzpGw_0024feA_003D)
	{
		return new Rectangle(_0023_003DzpGw_0024feA_003D._0023_003DzCT_RrjI_003D, _0023_003DzpGw_0024feA_003D._0023_003Dzc1_0024Vycc_003D, _0023_003DzpGw_0024feA_003D._0023_003Dzd3wwRAyZ0u7z(), _0023_003DzpGw_0024feA_003D._0023_003DzJndH3qzbRKM7());
	}

	public static implicit operator _0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs(Rectangle _0023_003DzpGw_0024feA_003D)
	{
		return new _0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs(_0023_003DzpGw_0024feA_003D);
	}

	public static bool operator ==(_0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs _0023_003DzKClhtPc_003D, _0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs _0023_003DzQ7wmRP8_003D)
	{
		return _0023_003DzKClhtPc_003D._0023_003DzCQnnTYk_003D(_0023_003DzQ7wmRP8_003D);
	}

	public static bool operator !=(_0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs _0023_003DzKClhtPc_003D, _0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs _0023_003DzQ7wmRP8_003D)
	{
		return !_0023_003DzKClhtPc_003D._0023_003DzCQnnTYk_003D(_0023_003DzQ7wmRP8_003D);
	}

	public bool _0023_003DzCQnnTYk_003D(_0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs _0023_003DzpGw_0024feA_003D)
	{
		if (_0023_003DzpGw_0024feA_003D._0023_003DzCT_RrjI_003D == _0023_003DzCT_RrjI_003D && _0023_003DzpGw_0024feA_003D._0023_003Dzc1_0024Vycc_003D == _0023_003Dzc1_0024Vycc_003D && _0023_003DzpGw_0024feA_003D._0023_003Dz4cDj0E0_003D == _0023_003Dz4cDj0E0_003D)
		{
			return _0023_003DzpGw_0024feA_003D._0023_003DzSD1Un3c_003D == _0023_003DzSD1Un3c_003D;
		}
		return false;
	}

	public override bool Equals(object _0023_003Dz2geqaCQ_003D)
	{
		if (_0023_003Dz2geqaCQ_003D is _0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs)
		{
			return _0023_003DzCQnnTYk_003D((_0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs)_0023_003Dz2geqaCQ_003D);
		}
		if (_0023_003Dz2geqaCQ_003D is Rectangle)
		{
			return _0023_003DzCQnnTYk_003D(new _0023_003DzPx4jb8eEsovJoNuLlG1ofUdAbKPs((Rectangle)_0023_003Dz2geqaCQ_003D));
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((Rectangle)this/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593366), _0023_003DzCT_RrjI_003D, _0023_003Dzc1_0024Vycc_003D, _0023_003Dz4cDj0E0_003D, _0023_003DzSD1Un3c_003D);
	}
}
