namespace System.Runtime;

public class OutWrapper<T>
{
	public T Value { get; set; }

	public OutWrapper()
	{
		Value = default(T);
	}

	public static implicit operator T(OutWrapper<T> wrapper)
	{
		return wrapper.Value;
	}
}
