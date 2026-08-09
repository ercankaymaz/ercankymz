internal sealed class _0023_003DzHPahAvdMv_mX79kRBg_003D_003D
{
	internal static uint _0023_003DzhSURiLJbOMuw(string _0023_003DzuwH5j5s_003D)
	{
		uint num = default(uint);
		if (_0023_003DzuwH5j5s_003D != null)
		{
			num = 2166136261u;
			for (int i = 0; i < _0023_003DzuwH5j5s_003D.Length; i++)
			{
				num = (_0023_003DzuwH5j5s_003D[i] ^ num) * 16777619;
			}
		}
		return num;
	}
}
