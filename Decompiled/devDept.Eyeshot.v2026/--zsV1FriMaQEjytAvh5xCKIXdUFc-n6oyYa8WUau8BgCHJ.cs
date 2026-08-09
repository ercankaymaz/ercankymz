using System.Collections.Generic;

internal sealed class _0023_003DzsV1FriMaQEjytAvh5xCKIXdUFc_0024n6oyYa8WUau8BgCHJ : List<long>
{
	public _0023_003DzsV1FriMaQEjytAvh5xCKIXdUFc_0024n6oyYa8WUau8BgCHJ()
	{
	}

	public _0023_003DzsV1FriMaQEjytAvh5xCKIXdUFc_0024n6oyYa8WUau8BgCHJ(_0023_003DzsV1FriMaQEjytAvh5xCKIXdUFc_0024n6oyYa8WUau8BgCHJ _0023_003Dz_0024KoRL7BAgoxl)
	{
	}

	public virtual void _0023_003Dzz7VuV7VFyvdX(int _0023_003DzPzO_0024GUk_003D)
	{
		for (int i = 0; i < _0023_003DzPzO_0024GUk_003D; i++)
		{
			Add(0L);
		}
	}

	public virtual bool _0023_003DzvORV0oA_003D(int _0023_003DzpdeSbFA_003D)
	{
		if (_0023_003DzpdeSbFA_003D >> 5 < base.Count)
		{
			long num = base[_0023_003DzpdeSbFA_003D >> 5];
			long num2 = 1L << _0023_003DzpdeSbFA_003D % 32;
			return (num & num2) != 0;
		}
		return false;
	}

	public virtual void _0023_003DzOnQC6_0024o_003D(int _0023_003DzpdeSbFA_003D)
	{
		int num = _0023_003DzpdeSbFA_003D >> 5;
		if (num >= base.Count)
		{
			while (base.Count < num + 1)
			{
				Add(0L);
			}
		}
		long num2 = base[num];
		long num3 = 1L << _0023_003DzpdeSbFA_003D % 32;
		base[num] = num2 | num3;
	}
}
