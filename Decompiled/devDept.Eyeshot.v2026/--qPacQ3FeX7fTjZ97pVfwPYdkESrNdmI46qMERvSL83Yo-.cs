using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003DqPacQ3FeX7fTjZ97pVfwPYdkESrNdmI46qMERvSL83Yo_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003Dz5rQzobg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D[] _0023_003DzAvn2b38_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dqy79GaFqXfJyGRxADW8SzoVL2xZ0_0024kwo_HbErPO8MT0Y_003D _0023_003DzR58imxw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqJTjaQmhkW8F60LVdPhnyD3poPDF3twYpdy0oQNHKaf0_003D _0023_003DzmQTFaQA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqBtO_Ln5vbudMbzVGmzEMIy5peuaUpGADidnrgN2dgH4_003D _0023_003DzWYPqg2E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEWLeis8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzbfrNXYE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzkKfJheA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzId5C3LA_003D;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length => _0023_003Dz5rQzobg_003D.Length;

	public override long Position
	{
		get
		{
			return _0023_003Dz5rQzobg_003D.Position + (_0023_003DzkKfJheA_003D - _0023_003DzId5C3LA_003D);
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public _0023_003DqPacQ3FeX7fTjZ97pVfwPYdkESrNdmI46qMERvSL83Yo_003D(Stream _0023_003DziDLVpbY_003D, _0023_003Dqy79GaFqXfJyGRxADW8SzoVL2xZ0_0024kwo_HbErPO8MT0Y_003D _0023_003Dz5rQzobg_003D = null, _0023_003DqJTjaQmhkW8F60LVdPhnyD3poPDF3twYpdy0oQNHKaf0_003D _0023_003DzAvn2b38_003D = null, bool _0023_003DzR58imxw_003D = false)
	{
		this._0023_003Dz5rQzobg_003D = _0023_003DziDLVpbY_003D;
		this._0023_003DziDLVpbY_003D = _0023_003DzR58imxw_003D;
		_0023_003DzmQTFaQA_003D = _0023_003DzAvn2b38_003D;
		this._0023_003DzR58imxw_003D = _0023_003Dz5rQzobg_003D;
		if (this._0023_003DzR58imxw_003D == null)
		{
			this._0023_003DzR58imxw_003D = _0023_003Dqy79GaFqXfJyGRxADW8SzoVL2xZ0_0024kwo_HbErPO8MT0Y_003D._0023_003DzgJ_0024h47yqcgvERuMayMoR9XFjkyqcjoptEXCZ5Nw_003D();
		}
		if (this._0023_003DzR58imxw_003D._0023_003DzU92g2PxgQCR4DoC0uq1liCsqkyD7D85m9Vju8wM_003D() == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907827));
		}
		if (this._0023_003DzR58imxw_003D._0023_003Dzk7vqgYctF3rzEEQEhTpLKJXLVm1qmtEHBQ_003D_003D() == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907827));
		}
		if (!this._0023_003Dz5rQzobg_003D.CanRead)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907814));
		}
		if (!this._0023_003Dz5rQzobg_003D.CanSeek)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907814));
		}
	}

	private void _0023_003Dzq_0024bVj8bBH8hwPPMbVlGdc6f_002421oA()
	{
		if (!_0023_003DzEWLeis8_003D)
		{
			_0023_003DzAvn2b38_003D = new _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D[_0023_003DzR58imxw_003D._0023_003DzU92g2PxgQCR4DoC0uq1liCsqkyD7D85m9Vju8wM_003D()];
			for (int i = 0; i < _0023_003DzR58imxw_003D._0023_003DzU92g2PxgQCR4DoC0uq1liCsqkyD7D85m9Vju8wM_003D(); i++)
			{
				_0023_003DzAvn2b38_003D[i] = new _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D();
			}
			if (_0023_003DzmQTFaQA_003D != null)
			{
				_0023_003DzWYPqg2E_003D = _0023_003DzmQTFaQA_003D._0023_003DzS2rD7MOKa6G_oZOXKeZ2sqqqNI73vRTeiDxjOWs_003D(_0023_003DzR58imxw_003D);
			}
			_0023_003DzEWLeis8_003D = true;
		}
	}

	protected override void Dispose(bool _0023_003DziDLVpbY_003D)
	{
		try
		{
			if (_0023_003DziDLVpbY_003D && !this._0023_003DziDLVpbY_003D)
			{
				_0023_003Dz5rQzobg_003D.Close();
			}
		}
		finally
		{
			base.Dispose(_0023_003DziDLVpbY_003D);
		}
	}

	public override void SetLength(long _0023_003DziDLVpbY_003D)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		throw new NotSupportedException();
	}

	public override void Flush()
	{
	}

	private int _0023_003DzymuJVXwrwXnvoOsW_60kk48_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		int num = _0023_003DzId5C3LA_003D - _0023_003DzkKfJheA_003D;
		if (num <= 0)
		{
			return 0;
		}
		if (num > _0023_003DzAvn2b38_003D)
		{
			num = _0023_003DzAvn2b38_003D;
		}
		Buffer.BlockCopy(_0023_003DzbfrNXYE_003D, _0023_003DzkKfJheA_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, num);
		_0023_003DzkKfJheA_003D += num;
		return num;
	}

	private void _0023_003DziXFSsTlYKmUP9TRMwCBON3g_003D(int _0023_003DziDLVpbY_003D)
	{
		int num = (int)_0023_003Dz5rQzobg_003D.Position;
		if (num >= _0023_003Dz5rQzobg_003D.Length)
		{
			return;
		}
		int num2 = num + _0023_003DziDLVpbY_003D;
		_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D[] array = _0023_003DzAvn2b38_003D;
		foreach (_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2 in array)
		{
			if (_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2._0023_003Dz5rQzobg_003D <= num && _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2._0023_003DzAvn2b38_003D >= num2)
			{
				_0023_003DzbfrNXYE_003D = _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2._0023_003DziDLVpbY_003D;
				_0023_003DzId5C3LA_003D = _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2._0023_003DzAvn2b38_003D - _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2._0023_003Dz5rQzobg_003D;
				_0023_003DzkKfJheA_003D = num - _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2._0023_003Dz5rQzobg_003D;
				_0023_003Dz5rQzobg_003D.Position = _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2._0023_003DzAvn2b38_003D;
				_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D2._0023_003DzR58imxw_003D = DateTime.UtcNow;
				return;
			}
		}
		int num3 = 0;
		DateTime dateTime = _0023_003DzAvn2b38_003D[0]._0023_003DzR58imxw_003D;
		for (int j = 1; j < _0023_003DzAvn2b38_003D.Length; j++)
		{
			if (_0023_003DzAvn2b38_003D[j]._0023_003DzR58imxw_003D < dateTime)
			{
				num3 = j;
			}
		}
		_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3 = _0023_003DzAvn2b38_003D[num3];
		if (_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003DziDLVpbY_003D == null)
		{
			_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003DziDLVpbY_003D = new byte[_0023_003DzR58imxw_003D._0023_003DzLd2Av16mh5CJ0Hzb13kSEPmaFmUz34mbA_0024ES5MLkeNPo()];
		}
		int num4 = num;
		num = _0023_003Dzj5KNldBuA6LoN1n3YeLA2wxBk_uZ(num);
		if (num < 0)
		{
			num = 0;
		}
		num2 = num + _0023_003DzR58imxw_003D._0023_003DzLd2Av16mh5CJ0Hzb13kSEPmaFmUz34mbA_0024ES5MLkeNPo();
		if (_0023_003DzWYPqg2E_003D == null || !_0023_003DzWYPqg2E_003D._0023_003DzypmwmD1_ZIM5RAAjrXNsKjY_003D(num, ref _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3))
		{
			_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003Dz5rQzobg_003D = num;
			_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003DzR58imxw_003D = DateTime.UtcNow;
			_0023_003DzbfrNXYE_003D = _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003DziDLVpbY_003D;
			_0023_003Dz5rQzobg_003D.Position = num;
			_0023_003DzId5C3LA_003D = _0023_003Dz5rQzobg_003D.Read(_0023_003DzbfrNXYE_003D, 0, num2 - num);
			_0023_003DzkKfJheA_003D = num4 - num;
			_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003DzAvn2b38_003D = num + _0023_003DzId5C3LA_003D;
			if (_0023_003DzWYPqg2E_003D != null)
			{
				_0023_003DzWYPqg2E_003D._0023_003Dzo4W5cihITWXpV01ULVC3_0024Ow_003D(_0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3);
			}
		}
		else
		{
			_0023_003DzbfrNXYE_003D = _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003DziDLVpbY_003D;
			_0023_003DzId5C3LA_003D = _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003DzAvn2b38_003D - num;
			_0023_003Dz5rQzobg_003D.Position = _0023_003DqokHK_cUOtnj3sNXR4_J_JI_0024_0024AOsLZh_0024r4LNP6ypg5rI_003D3._0023_003DzAvn2b38_003D;
			_0023_003DzkKfJheA_003D = num4 - num;
		}
	}

	private int _0023_003Dzj5KNldBuA6LoN1n3YeLA2wxBk_uZ(int _0023_003DziDLVpbY_003D)
	{
		return _0023_003DziDLVpbY_003D - _0023_003DziDLVpbY_003D % _0023_003DzR58imxw_003D._0023_003DzLd2Av16mh5CJ0Hzb13kSEPmaFmUz34mbA_0024ES5MLkeNPo();
	}

	public override int Read(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907793));
		}
		if (_0023_003Dz5rQzobg_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907806));
		}
		if (_0023_003DzAvn2b38_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907783));
		}
		if (_0023_003DziDLVpbY_003D.Length - _0023_003Dz5rQzobg_003D < _0023_003DzAvn2b38_003D)
		{
			throw new ArgumentException();
		}
		int num = _0023_003Dz5rQzobg_003D;
		int num2 = _0023_003DzymuJVXwrwXnvoOsW_60kk48_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
		if (num2 == _0023_003DzAvn2b38_003D)
		{
			return num2;
		}
		int num3 = num2;
		if (num2 > 0)
		{
			_0023_003DzAvn2b38_003D -= num2;
			_0023_003Dz5rQzobg_003D += num2;
		}
		_0023_003DzkKfJheA_003D = (_0023_003DzId5C3LA_003D = 0);
		_0023_003Dzq_0024bVj8bBH8hwPPMbVlGdc6f_002421oA();
		if (_0023_003DzAvn2b38_003D >= _0023_003DzR58imxw_003D._0023_003DzLd2Av16mh5CJ0Hzb13kSEPmaFmUz34mbA_0024ES5MLkeNPo())
		{
			if (_0023_003DzWYPqg2E_003D == null)
			{
				return this._0023_003Dz5rQzobg_003D.Read(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D) + num3;
			}
			int num4 = (int)this._0023_003Dz5rQzobg_003D.Position - num3;
			if (_0023_003DzWYPqg2E_003D._0023_003Dz5JvwZ684sdqg2Wnn7Q_003D_003D(num4, _0023_003DziDLVpbY_003D, num, _0023_003DzAvn2b38_003D + num3, out var num5))
			{
				this._0023_003Dz5rQzobg_003D.Seek(num5 - num3, SeekOrigin.Current);
				return num5;
			}
			num5 = this._0023_003Dz5rQzobg_003D.Read(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			if (num5 != 0)
			{
				_0023_003DzWYPqg2E_003D._0023_003DzTUHDXsEZk4yB9Zveum_0024zlE96pQ2Ma3LCVp9rJpo_003D(num4, _0023_003DziDLVpbY_003D, num, num5 + num3, num5 < _0023_003DzAvn2b38_003D);
			}
			return num5 + num3;
		}
		_0023_003DziXFSsTlYKmUP9TRMwCBON3g_003D(_0023_003DzAvn2b38_003D);
		num2 = _0023_003DzymuJVXwrwXnvoOsW_60kk48_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
		return num2 + num3;
	}

	public override long Seek(long _0023_003DziDLVpbY_003D, SeekOrigin _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DzId5C3LA_003D - _0023_003DzkKfJheA_003D > 0 && _0023_003Dz5rQzobg_003D == SeekOrigin.Current)
		{
			_0023_003DziDLVpbY_003D -= _0023_003DzId5C3LA_003D - _0023_003DzkKfJheA_003D;
		}
		long position = Position;
		long num = this._0023_003Dz5rQzobg_003D.Seek(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		_0023_003DzkKfJheA_003D = (int)(num - (position - _0023_003DzkKfJheA_003D));
		if (0 <= _0023_003DzkKfJheA_003D && _0023_003DzkKfJheA_003D < _0023_003DzId5C3LA_003D)
		{
			this._0023_003Dz5rQzobg_003D.Seek(_0023_003DzId5C3LA_003D - _0023_003DzkKfJheA_003D, SeekOrigin.Current);
		}
		else
		{
			_0023_003DzkKfJheA_003D = (_0023_003DzId5C3LA_003D = 0);
		}
		return num;
	}
}
