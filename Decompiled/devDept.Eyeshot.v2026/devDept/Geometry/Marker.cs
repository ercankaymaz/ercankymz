namespace devDept.Geometry;

public class Marker<T>
{
	public T Item;

	public bool Mark;

	public Marker(T item)
	{
		Item = item;
	}

	public static implicit operator T(Marker<T> marker)
	{
		return marker.Item;
	}

	public static implicit operator Marker<T>(T value)
	{
		return new Marker<T>(value);
	}
}
