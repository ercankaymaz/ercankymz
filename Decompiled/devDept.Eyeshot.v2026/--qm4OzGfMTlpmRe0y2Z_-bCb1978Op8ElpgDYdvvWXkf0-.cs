using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D : DeriveBytes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static volatile bool _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DeriveBytes _0023_003Dz5rQzobg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003DzAvn2b38_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003DzR58imxw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzmQTFaQA_003D;

	public _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		this._0023_003DzAvn2b38_003D = _0023_003DziDLVpbY_003D;
		_0023_003DzR58imxw_003D = _0023_003Dz5rQzobg_003D;
		_0023_003DzmQTFaQA_003D = _0023_003DzAvn2b38_003D;
		if (!_0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D._0023_003DziDLVpbY_003D)
		{
			try
			{
				this._0023_003Dz5rQzobg_003D = new Rfc2898DeriveBytes(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			catch
			{
				_0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D._0023_003DziDLVpbY_003D = true;
			}
		}
		if (this._0023_003Dz5rQzobg_003D == null)
		{
			this._0023_003Dz5rQzobg_003D = new _0023_003Dq9o_OPfa_DuRpdjQlVA0aijWI4nFSxQq8_00244xk8qwRmjs_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
		}
	}

	public override byte[] GetBytes(int _0023_003DziDLVpbY_003D)
	{
		byte[] array = null;
		if (!_0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D._0023_003DziDLVpbY_003D)
		{
			try
			{
				array = _0023_003Dz5rQzobg_003D.GetBytes(_0023_003DziDLVpbY_003D);
			}
			catch
			{
				_0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D._0023_003DziDLVpbY_003D = true;
			}
		}
		if (array == null)
		{
			_0023_003Dz5rQzobg_003D = new _0023_003Dq9o_OPfa_DuRpdjQlVA0aijWI4nFSxQq8_00244xk8qwRmjs_003D(_0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D);
			array = _0023_003Dz5rQzobg_003D.GetBytes(_0023_003DziDLVpbY_003D);
		}
		return array;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
