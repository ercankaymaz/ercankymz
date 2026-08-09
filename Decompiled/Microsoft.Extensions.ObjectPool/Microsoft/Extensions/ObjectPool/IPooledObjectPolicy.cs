namespace Microsoft.Extensions.ObjectPool;

public interface IPooledObjectPolicy<T> where T : notnull
{
	T Create();

	bool Return(T obj);
}
