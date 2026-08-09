namespace SharpGLTF.Geometry;

public readonly struct LinePrimitive<TVertex, Tmaterial>
{
	public readonly TVertex A;

	public readonly TVertex B;

	public readonly Tmaterial Material;
}
