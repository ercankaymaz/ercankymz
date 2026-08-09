namespace SharpGLTF.Geometry;

public readonly struct TrianglePrimitive<TVertex, Tmaterial>
{
	public readonly TVertex A;

	public readonly TVertex B;

	public readonly TVertex C;

	public readonly Tmaterial Material;
}
