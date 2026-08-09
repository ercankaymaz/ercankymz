using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace Xbim.IO.Esent;

public class InverseCache : IInverseCache, IDisposable
{
	private class CacheKey
	{
		private readonly string _property;

		private readonly IPersistEntity _agument;

		private readonly Type _type;

		public CacheKey(string property, IPersistEntity agument, Type type)
		{
			_property = property;
			_agument = agument;
			_type = type;
		}

		public override int GetHashCode()
		{
			return _property.GetHashCode() + _agument.EntityLabel + _type.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is CacheKey cacheKey))
			{
				return false;
			}
			if (_agument.EntityLabel == cacheKey._agument.EntityLabel && _type == cacheKey._type)
			{
				return string.Equals(_property, cacheKey._property, StringComparison.Ordinal);
			}
			return false;
		}
	}

	private readonly Dictionary<CacheKey, IEnumerable<IPersistEntity>> _cache = new Dictionary<CacheKey, IEnumerable<IPersistEntity>>();

	private bool _disposed;

	public int Size => _cache.Count;

	public bool IsDisposed => _disposed;

	public bool TryGet<T>(string inverseProperty, IPersistEntity inverseArgument, out IEnumerable<T> entities) where T : IPersistEntity
	{
		CacheKey key = new CacheKey(inverseProperty, inverseArgument, typeof(T));
		if (_cache.TryGetValue(key, out var value))
		{
			entities = value.Cast<T>();
			return true;
		}
		entities = Enumerable.Empty<T>();
		return false;
	}

	public void Add<T>(string inverseProperty, IPersistEntity inverseArgument, IEnumerable<T> entities) where T : IPersistEntity
	{
		CacheKey key = new CacheKey(inverseProperty, inverseArgument, typeof(T));
		_cache.Add(key, entities.Cast<IPersistEntity>());
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_cache.Clear();
			_disposed = true;
		}
	}

	public void Clear()
	{
		_cache.Clear();
	}
}
