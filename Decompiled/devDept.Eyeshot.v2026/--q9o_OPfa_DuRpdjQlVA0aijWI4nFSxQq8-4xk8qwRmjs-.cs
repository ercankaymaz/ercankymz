using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003Dq9o_OPfa_DuRpdjQlVA0aijWI4nFSxQq8_00244xk8qwRmjs_003D : DeriveBytes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dz5rQzobg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzAvn2b38_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DqPjU0as5GIhLtc26yxRodCkx1PUYslUpZyu5YD78baPI_003D _0023_003DzR58imxw_003D = new _0023_003DqPjU0as5GIhLtc26yxRodCkx1PUYslUpZyu5YD78baPI_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003DzmQTFaQA_003D;

	public _0023_003Dq9o_OPfa_DuRpdjQlVA0aijWI4nFSxQq8_00244xk8qwRmjs_003D(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907679));
		}
		if (_0023_003Dz5rQzobg_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907660));
		}
		if (_0023_003DzAvn2b38_003D < 1)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907893));
		}
		this._0023_003DziDLVpbY_003D = (byte[])_0023_003DziDLVpbY_003D.Clone();
		this._0023_003Dz5rQzobg_003D = (byte[])_0023_003Dz5rQzobg_003D.Clone();
		this._0023_003DzAvn2b38_003D = _0023_003DzAvn2b38_003D;
		_0023_003DzmQTFaQA_003D = new byte[_0023_003DzR58imxw_003D._0023_003Dz_QyjuqYs5oUOuk23b3UiSgcrll07kCEvBA_003D_003D()];
	}

	private void _0023_003DzY0_0024v3DQpuvj0APwXBA_003D_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, byte[] _0023_003DzAvn2b38_003D, byte[] _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D)
	{
		if (_0023_003DziDLVpbY_003D != null)
		{
			this._0023_003DzR58imxw_003D._0023_003DznRS_7m5kES76wcf_0024b6lHyzPItiLX(_0023_003DziDLVpbY_003D, 0, _0023_003DziDLVpbY_003D.Length);
		}
		this._0023_003DzR58imxw_003D._0023_003DznRS_7m5kES76wcf_0024b6lHyzPItiLX(_0023_003DzAvn2b38_003D, 0, _0023_003DzAvn2b38_003D.Length);
		this._0023_003DzR58imxw_003D._0023_003DzSz1bUlDmodcDF3JzIrS_0024vW7eHN9Dm0J_MhOjISk_003D(this._0023_003DzmQTFaQA_003D, 0);
		Buffer.BlockCopy(this._0023_003DzmQTFaQA_003D, 0, _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D, this._0023_003DzmQTFaQA_003D.Length);
		for (int i = 1; i < _0023_003Dz5rQzobg_003D; i++)
		{
			this._0023_003DzR58imxw_003D._0023_003DznRS_7m5kES76wcf_0024b6lHyzPItiLX(this._0023_003DzmQTFaQA_003D, 0, this._0023_003DzmQTFaQA_003D.Length);
			this._0023_003DzR58imxw_003D._0023_003DzSz1bUlDmodcDF3JzIrS_0024vW7eHN9Dm0J_MhOjISk_003D(this._0023_003DzmQTFaQA_003D, 0);
			for (int j = 0; j < this._0023_003DzmQTFaQA_003D.Length; j++)
			{
				_0023_003DzR58imxw_003D[_0023_003DzmQTFaQA_003D + j] ^= this._0023_003DzmQTFaQA_003D[j];
			}
		}
	}

	public override byte[] GetBytes(int _0023_003DziDLVpbY_003D)
	{
		int num = _0023_003DzR58imxw_003D._0023_003Dz_QyjuqYs5oUOuk23b3UiSgcrll07kCEvBA_003D_003D();
		int num2 = (_0023_003DziDLVpbY_003D + num - 1) / num;
		byte[] array = new byte[4];
		byte[] array2 = new byte[num2 * num];
		int num3 = 0;
		_0023_003DzR58imxw_003D._0023_003DzjAAOtSYOpvTZrRt38Y4SbVjjWzCX(this._0023_003DziDLVpbY_003D);
		for (int i = 1; i <= num2; i++)
		{
			int num4 = 3;
			while (++array[num4] == 0)
			{
				num4--;
			}
			_0023_003DzY0_0024v3DQpuvj0APwXBA_003D_003D(_0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, array, array2, num3);
			num3 += num;
		}
		if (_0023_003DziDLVpbY_003D < array2.Length)
		{
			byte[] array3 = new byte[_0023_003DziDLVpbY_003D];
			Buffer.BlockCopy(array2, 0, array3, 0, _0023_003DziDLVpbY_003D);
			array2 = array3;
		}
		return array2;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
