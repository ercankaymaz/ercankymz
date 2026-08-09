namespace devDept.Serialization.ODA;

internal sealed class Point3dSurrogate : Surrogate<_0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D>
{
	public double X { get; set; }

	public double Y { get; set; }

	public double Z { get; set; }

	public Point3dSurrogate(_0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D point3d)
		: base(point3d)
	{
	}

	protected override _0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D ConvertToObject()
	{
		return new _0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D(X, Y, Z);
	}

	protected override void CopyDataToObject(_0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D obj)
	{
	}

	protected override void CopyDataFromObject(_0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D point3d)
	{
		X = point3d._0023_003DzR216mFc_003D();
		Y = point3d._0023_003DzqJqZpJk_003D();
		Z = point3d._0023_003Dz2_OZI5A_003D();
	}

	public static implicit operator _0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D(Point3dSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator Point3dSurrogate(_0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D source)
	{
		return source?._0023_003Dz_0024xHo97pGU7zE();
	}
}
