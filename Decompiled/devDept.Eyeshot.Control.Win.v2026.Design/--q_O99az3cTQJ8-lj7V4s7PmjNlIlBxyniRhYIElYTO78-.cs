using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D : DeriveBytes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static volatile bool _0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DeriveBytes _0023_003DzBxpHhQ0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003Dztgqm2r4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003DzzKDx05I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dz3iPku7s_003D;

	public _0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D(byte[] _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		this._0023_003Dztgqm2r4_003D = _0023_003Dz9jrlnWk_003D;
		_0023_003DzzKDx05I_003D = _0023_003DzBxpHhQ0_003D;
		_0023_003Dz3iPku7s_003D = _0023_003Dztgqm2r4_003D;
		if (!_0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D._0023_003Dz9jrlnWk_003D)
		{
			try
			{
				this._0023_003DzBxpHhQ0_003D = new Rfc2898DeriveBytes(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			}
			catch
			{
				_0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D._0023_003Dz9jrlnWk_003D = true;
			}
		}
		if (this._0023_003DzBxpHhQ0_003D == null)
		{
			this._0023_003DzBxpHhQ0_003D = new _0023_003DqSO1PPb7IiakbhH4RNeeJfckHXTcoC3XAxAoJIPsCgCw_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
		}
	}

	public override byte[] GetBytes(int _0023_003Dz9jrlnWk_003D)
	{
		byte[] array = null;
		if (!_0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D._0023_003Dz9jrlnWk_003D)
		{
			try
			{
				array = _0023_003DzBxpHhQ0_003D.GetBytes(_0023_003Dz9jrlnWk_003D);
			}
			catch
			{
				_0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D._0023_003Dz9jrlnWk_003D = true;
			}
		}
		if (array == null)
		{
			_0023_003DzBxpHhQ0_003D = new _0023_003DqSO1PPb7IiakbhH4RNeeJfckHXTcoC3XAxAoJIPsCgCw_003D(_0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D);
			array = _0023_003DzBxpHhQ0_003D.GetBytes(_0023_003Dz9jrlnWk_003D);
		}
		return array;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
