using System;

internal sealed class _0023_003DqtFN_00241TjdaenuCmn9GBmqptPfjTUxtfhRNfxI_0024iGsTHc_003D : _0023_003DqDvj8ic3hCAE2Emnz6g_0024sCU66m83Gw75MUeEwWsZR_TE_003D
{
	private readonly byte[] _0023_003DzjYYAPCA_003D;

	public _0023_003DqtFN_00241TjdaenuCmn9GBmqptPfjTUxtfhRNfxI_0024iGsTHc_003D(byte[] _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348618864));
		}
		this._0023_003DzjYYAPCA_003D = (byte[])_0023_003DzjYYAPCA_003D.Clone();
	}

	public _0023_003DqtFN_00241TjdaenuCmn9GBmqptPfjTUxtfhRNfxI_0024iGsTHc_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619141));
		}
		if (_0023_003DzVC9FBdo_003D < 0 || _0023_003DzVC9FBdo_003D > _0023_003DzjYYAPCA_003D.Length)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619162));
		}
		if (_0023_003DzwBouG0w_003D < 0 || _0023_003DzVC9FBdo_003D + _0023_003DzwBouG0w_003D > _0023_003DzjYYAPCA_003D.Length)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619183));
		}
		this._0023_003DzjYYAPCA_003D = new byte[_0023_003DzwBouG0w_003D];
		Array.Copy(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, this._0023_003DzjYYAPCA_003D, 0, _0023_003DzwBouG0w_003D);
	}

	public byte[] _0023_003DzGvJ5zaMdsINLbBkrdscpG3rXyFbX()
	{
		return (byte[])_0023_003DzjYYAPCA_003D.Clone();
	}
}
