using devDept;
using devDept.Graphics;

internal static class _0023_003DzOS2IZSQnw3cd5R5N4ujWuuA_003D
{
	internal static primitiveType _0023_003DzOC8oSVZPCqOX(this int _0023_003DzmrtMJ48_003D)
	{
		return _0023_003DzmrtMJ48_003D switch
		{
			0 => primitiveType.PointList, 
			1 => primitiveType.LineList, 
			3 => primitiveType.LineStrip, 
			4 => primitiveType.TriangleList, 
			5 => primitiveType.TriangleStrip, 
			_ => throw new GraphicsException(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602951), _0023_003DzmrtMJ48_003D)), 
		};
	}

	internal static int _0023_003DzbCW6hty7CJbs(this primitiveType _0023_003DzQZ1JmC0_003D)
	{
		return _0023_003DzQZ1JmC0_003D switch
		{
			primitiveType.PointList => 0, 
			primitiveType.LineList => 1, 
			primitiveType.LineStrip => 3, 
			primitiveType.TriangleList => 4, 
			primitiveType.TriangleStrip => 5, 
			_ => 0, 
		};
	}
}
