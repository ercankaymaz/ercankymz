namespace Microsoft.Extensions.ObjectPool;

public abstract class ObjectPool<T> where T : class
{
	public abstract T Get();

	public abstract void Return(T obj);
}
public static class ObjectPool
{
	public static ObjectPool<T> Create<T>(IPooledObjectPolicy<T>? policy = null) where T : class, new()
	{
		return new DefaultObjectPoolProvider().Create(policy ?? new DefaultPooledObjectPolicy<T>());
	}
}
