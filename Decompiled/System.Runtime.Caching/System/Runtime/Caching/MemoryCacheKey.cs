namespace System.Runtime.Caching;

internal class MemoryCacheKey
{
	private readonly string _key;

	private readonly int _hash;

	internal int Hash => _hash;

	internal string Key => _key;

	internal MemoryCacheKey(string key)
	{
		_key = key;
		_hash = key.GetHashCode();
	}
}
