using System.Drawing;

internal static class _0023_003Dz2s_jfmesluRNsQojsvPxHUSvCzK9A8PcWA_003D_003D
{
	public static PointF _0023_003Dzx9P_oXY_003D(this PointF _0023_003Dz9f_t8sQ_003D)
	{
		return new PointF(_0023_003Dz9f_t8sQ_003D.X, _0023_003Dz9f_t8sQ_003D.Y);
	}

	public static bool _0023_003Dzqh_BTJs_003D(this PointF _0023_003Dz9f_t8sQ_003D)
	{
		if (!float.IsNaN(_0023_003Dz9f_t8sQ_003D.X))
		{
			return !float.IsNaN(_0023_003Dz9f_t8sQ_003D.Y);
		}
		return false;
	}
}
