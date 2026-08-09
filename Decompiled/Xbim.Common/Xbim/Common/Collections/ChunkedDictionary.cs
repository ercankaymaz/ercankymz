using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xbim.Common.Collections;

public class ChunkedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	private int _currentChunk;

	private readonly List<Dictionary<TKey, TValue>> _chunks = new List<Dictionary<TKey, TValue>>();

	private readonly List<int> _chunkSizes;

	private readonly int _preferredChunkSize;

	public TValue this[TKey key]
	{
		get
		{
			FindChunkContainingKey(key, createIfNotExists: false, out var value);
			return value;
		}
		set
		{
			FindChunkContainingKey(key, createIfNotExists: true, out var _)[key] = value;
		}
	}

	public ICollection<TKey> Keys => _chunks.SelectMany((Dictionary<TKey, TValue> chunk) => chunk.Keys).ToList();

	public ICollection<TValue> Values => _chunks.SelectMany((Dictionary<TKey, TValue> chunk) => chunk.Values).ToList();

	public int Count => _chunks.Sum((Dictionary<TKey, TValue> chunk) => chunk.Count);

	public bool IsReadOnly => false;

	public ChunkedDictionary(int chunkSize)
	{
		if (chunkSize <= 0)
		{
			throw new ArgumentException("Chunk size must be greater than 0.", "chunkSize");
		}
		_preferredChunkSize = chunkSize;
		_chunkSizes = new List<int> { 3 };
		_currentChunk = 0;
		_chunks.Add(new Dictionary<TKey, TValue>(_chunkSizes[_currentChunk]));
	}

	public ChunkedDictionary(int totalSize, int chunkSize)
	{
		if (totalSize <= 0)
		{
			throw new ArgumentException("Total size must be greater than 0.", "totalSize");
		}
		if (chunkSize <= 0)
		{
			throw new ArgumentException("Chunk size must be greater than 0.", "chunkSize");
		}
		if (chunkSize > totalSize)
		{
			throw new ArgumentException("Chunk size must be less than or equal to the total size.", "chunkSize");
		}
		_preferredChunkSize = chunkSize;
		_chunkSizes = new List<int>();
		while (totalSize > 0)
		{
			if (totalSize >= chunkSize)
			{
				_chunkSizes.Add(chunkSize);
				totalSize -= chunkSize;
			}
			else
			{
				_chunkSizes.Add(totalSize);
				totalSize = 0;
			}
		}
		_currentChunk = 0;
		_chunks.Add(new Dictionary<TKey, TValue>(_chunkSizes[_currentChunk]));
	}

	public void Add(TKey key, TValue value)
	{
		((_chunks[_currentChunk].Count >= _chunkSizes[_currentChunk]) ? AddNewChunk() : _chunks[_currentChunk]).Add(key, value);
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		Add(item.Key, item.Value);
	}

	public void Clear()
	{
		_chunks.Clear();
		_currentChunk = 0;
		_chunks.Add(new Dictionary<TKey, TValue>(_chunkSizes[_currentChunk]));
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return _chunks.Any((Dictionary<TKey, TValue> chunk) => chunk.Contains(item));
	}

	public bool ContainsKey(TKey key)
	{
		return _chunks.Any((Dictionary<TKey, TValue> chunk) => chunk.ContainsKey(key));
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		foreach (Dictionary<TKey, TValue> chunk in _chunks)
		{
			foreach (KeyValuePair<TKey, TValue> item in chunk)
			{
				if (arrayIndex >= array.Length)
				{
					return;
				}
				array[arrayIndex++] = item;
			}
		}
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return _chunks.SelectMany((Dictionary<TKey, TValue> chunk) => chunk).GetEnumerator();
	}

	public bool Remove(TKey key)
	{
		TValue value;
		return FindChunkContainingKey(key, createIfNotExists: false, out value)?.Remove(key) ?? false;
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		TValue value;
		return FindChunkContainingKey(item.Key, createIfNotExists: false, out value)?.Remove(item.Key) ?? false;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		value = default(TValue);
		return FindChunkContainingKey(key, createIfNotExists: false, out value) != null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private Dictionary<TKey, TValue> FindChunkContainingKey(TKey key, bool createIfNotExists, out TValue value)
	{
		foreach (Dictionary<TKey, TValue> chunk in _chunks)
		{
			if (chunk.TryGetValue(key, out value))
			{
				return chunk;
			}
		}
		if (createIfNotExists)
		{
			value = default(TValue);
			return AddNewChunk();
		}
		throw new KeyNotFoundException("The given key was not present in the dictionary.");
	}

	private Dictionary<TKey, TValue> AddNewChunk()
	{
		_currentChunk++;
		if (_chunkSizes.Count <= _currentChunk)
		{
			_chunkSizes.Add(_preferredChunkSize);
		}
		Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(_chunkSizes[_currentChunk]);
		_chunks.Add(dictionary);
		return dictionary;
	}

	internal int GetChunkCount()
	{
		return _chunks.Count;
	}
}
