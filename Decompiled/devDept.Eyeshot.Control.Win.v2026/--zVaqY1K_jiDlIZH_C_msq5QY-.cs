using SharpDX.Direct3D;
using devDept;
using devDept.Graphics;

internal static class _0023_003DzVaqY1K_jiDlIZH_C_msq5QY_003D
{
	internal static primitiveType _0023_003DzOC8oSVZPCqOX(this PrimitiveTopology _0023_003DzQZ1JmC0_003D)
	{
		if ((uint)_0023_003DzQZ1JmC0_003D <= 5u)
		{
			return (primitiveType)_0023_003DzQZ1JmC0_003D;
		}
		throw new GraphicsException(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602951), _0023_003DzQZ1JmC0_003D));
	}

	internal static PrimitiveTopology _0023_003DzmQgruD9wOlD3(this primitiveType _0023_003DzQZ1JmC0_003D)
	{
		return (PrimitiveTopology)_0023_003DzQZ1JmC0_003D;
	}
}
