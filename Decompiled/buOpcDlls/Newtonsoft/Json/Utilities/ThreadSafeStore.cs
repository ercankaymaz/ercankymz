using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class ThreadSafeStore<TKey, [Newtonsoft_002EJson_002ENullable(2)] TValue>
{
	private readonly ConcurrentDictionary<TKey, TValue> _concurrentStore;

	private readonly Func<TKey, TValue> _creator;

	public ThreadSafeStore(Func<TKey, TValue> creator)
	{
		ValidationUtils.ArgumentNotNull(creator, "creator");
		_creator = creator;
		_concurrentStore = new ConcurrentDictionary<TKey, TValue>();
	}

	public TValue Get(TKey key)
	{
		return _concurrentStore.GetOrAdd(key, _creator);
	}
}
