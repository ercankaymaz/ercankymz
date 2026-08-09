namespace Microsoft.Extensions.ObjectPool;

public abstract class PooledObjectPolicy<T> : IPooledObjectPolicy<T> where T : notnull
{
	public abstract T Create();

	public abstract bool Return(T obj);
}
