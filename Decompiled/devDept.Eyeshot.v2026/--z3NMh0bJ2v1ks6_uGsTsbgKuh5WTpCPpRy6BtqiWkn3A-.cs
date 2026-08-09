using System.Drawing;
using System.Numerics;
using SharpGLTF.Geometry.VertexTypes;
using devDept.Geometry;

internal static class _0023_003Dz3NMh0bJ2v1ks6_uGsTsbgKuh5WTpCPpRy6BtqiWkn3A_0024
{
	public static VertexPosition _0023_003DzM1r5Ziv2v6WP(this Point3D _0023_003DzlY77YgY_003D)
	{
		return new VertexPosition((float)_0023_003DzlY77YgY_003D.X, (float)_0023_003DzlY77YgY_003D.Y, (float)_0023_003DzlY77YgY_003D.Z);
	}

	public static VertexPositionNormal _0023_003DzyOFoEJrAxZfT(this Point3D _0023_003DzlY77YgY_003D, Vector3D _0023_003DzZbOaTIM_003D)
	{
		return new VertexPositionNormal((float)_0023_003DzlY77YgY_003D.X, (float)_0023_003DzlY77YgY_003D.Y, (float)_0023_003DzlY77YgY_003D.Z, (float)_0023_003DzZbOaTIM_003D.X, (float)_0023_003DzZbOaTIM_003D.Y, (float)_0023_003DzZbOaTIM_003D.Z);
	}

	public static VertexColor1 _0023_003DzNwR9U5Yv1PP0(this PointRGB _0023_003DzlY77YgY_003D, int _0023_003DzbvIFYko_003D)
	{
		return new VertexColor1(new Vector4((float)(int)_0023_003DzlY77YgY_003D.R / 255f, (float)(int)_0023_003DzlY77YgY_003D.G / 255f, (float)(int)_0023_003DzlY77YgY_003D.B / 255f, (float)_0023_003DzbvIFYko_003D / 255f));
	}

	public static VertexColor1 _0023_003DzNwR9U5Yv1PP0(this Color _0023_003Dz1MMYB1g_003D)
	{
		return new VertexColor1(new Vector4((float)(int)_0023_003Dz1MMYB1g_003D.R / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.G / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.B / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.A / 255f));
	}

	public static VertexColor1Texture1 _0023_003DzBRkbFpJEE00mWpB40A_003D_003D(this Color _0023_003Dz1MMYB1g_003D, PointF _0023_003DzlY77YgY_003D)
	{
		return new VertexColor1Texture1(new Vector4((float)(int)_0023_003Dz1MMYB1g_003D.R / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.G / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.B / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.A / 255f), new Vector2(_0023_003DzlY77YgY_003D.X, 1f - _0023_003DzlY77YgY_003D.Y));
	}

	public static VertexTexture1 _0023_003Dztt1WuDlHUD9N(this PointF _0023_003DzlY77YgY_003D)
	{
		return new VertexTexture1(new Vector2(_0023_003DzlY77YgY_003D.X, 1f - _0023_003DzlY77YgY_003D.Y));
	}

	public static Vector4 _0023_003DzjBHxFu7sXBku(this Color _0023_003Dz1MMYB1g_003D)
	{
		return new Vector4((float)(int)_0023_003Dz1MMYB1g_003D.R / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.G / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.B / 255f, (float)(int)_0023_003Dz1MMYB1g_003D.A / 255f);
	}

	public static Color _0023_003DzwZbJhvk_003D(this Vector4 _0023_003Dz1MMYB1g_003D)
	{
		int red = (int)(_0023_003Dz1MMYB1g_003D.X * 255f);
		int green = (int)(_0023_003Dz1MMYB1g_003D.Y * 255f);
		int blue = (int)(_0023_003Dz1MMYB1g_003D.Z * 255f);
		return Color.FromArgb((int)(_0023_003Dz1MMYB1g_003D.W * 255f), red, green, blue);
	}
}
