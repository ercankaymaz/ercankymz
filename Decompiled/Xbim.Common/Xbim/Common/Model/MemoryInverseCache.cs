using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xbim.Common.Model;

public class MemoryInverseCache : IInverseCache, IDisposable
{
	private Dictionary<Type, Dictionary<int, HashSet<int>>> _index = new Dictionary<Type, Dictionary<int, HashSet<int>>>();

	private IEntityCollection _entities;

	private bool _disposed;

	public int Size
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<Type, Dictionary<int, HashSet<int>>> item in _index)
			{
				foreach (KeyValuePair<int, HashSet<int>> item2 in item.Value)
				{
					num += item2.Value.Count;
				}
			}
			return num;
		}
	}

	public bool IsDisposed => _disposed;

	public MemoryInverseCache(IEntityCollection entities)
	{
		_entities = entities;
	}

	private void Add(int key, IPersistEntity value)
	{
		Dictionary<int, HashSet<int>> index = GetIndex(value.GetType());
		if (!index.TryGetValue(key, out var value2))
		{
			value2 = new HashSet<int>();
			index.Add(key, value2);
		}
		value2.Add(value.EntityLabel);
	}

	private Dictionary<int, HashSet<int>> GetIndex(Type type)
	{
		if (_index.TryGetValue(type, out var value))
		{
			return value;
		}
		value = new Dictionary<int, HashSet<int>>();
		_index.Add(type, value);
		return value;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_index.Clear();
			_index = null;
			_entities = null;
			_disposed = true;
		}
	}

	public bool TryGet<T>(string inverseProperty, IPersistEntity inverseArgument, out IEnumerable<T> entities) where T : IPersistEntity
	{
		if (_disposed)
		{
			throw new ObjectDisposedException(GetType().FullName);
		}
		if (TryGetPrivate(inverseProperty, inverseArgument, out entities))
		{
			return true;
		}
		lock (_index)
		{
			if (TryGetPrivate(inverseProperty, inverseArgument, out entities))
			{
				return true;
			}
			foreach (IContainsIndexedReferences item in inverseArgument.Model.Instances.OfType<T>().OfType<IContainsIndexedReferences>().ToList())
			{
				foreach (IPersistEntity indexedReference in item.IndexedReferences)
				{
					Add(indexedReference.EntityLabel, item);
				}
			}
		}
		if (TryGetPrivate(inverseProperty, inverseArgument, out entities))
		{
			return true;
		}
		entities = null;
		return false;
	}

	private bool TryGetPrivate<T>(string inverseProperty, IPersistEntity inverseArgument, out IEnumerable<T> entities) where T : IPersistEntity
	{
		Type type = typeof(T);
		Type[] array = _index.Keys.Where((Type k) => type.GetTypeInfo().IsAssignableFrom(k)).ToArray();
		if (array.Length == 0)
		{
			entities = Enumerable.Empty<T>();
			return false;
		}
		entities = array.SelectMany((Type k) => Get<T>(k, inverseArgument.EntityLabel));
		return true;
	}

	private IEnumerable<T> Get<T>(Type type, int key) where T : IPersistEntity
	{
		if (!GetIndex(type).TryGetValue(key, out var value))
		{
			yield break;
		}
		foreach (int item in value)
		{
			yield return (T)_entities[item];
		}
	}

	public void Clear()
	{
		_index.Clear();
	}
}
