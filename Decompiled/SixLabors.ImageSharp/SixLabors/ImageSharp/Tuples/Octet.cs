namespace SixLabors.ImageSharp.Tuples;

internal struct Octet<T> where T : unmanaged
{
	public T V0;

	public T V1;

	public T V2;

	public T V3;

	public T V4;

	public T V5;

	public T V6;

	public T V7;

	public override readonly string ToString()
	{
		return $"Octet<{typeof(T)}>({V0},{V1},{V2},{V3},{V4},{V5},{V6},{V7})";
	}
}
