using System;
using System.Collections;
using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Presentation;

public class XbimIPersistEntityCollection<TType> : ICollection<TType>, IEnumerable<TType>, IEnumerable where TType : class, IPersistEntity
{
	private class XbimIPersistIfcEntityCollectionEnumerator : IEnumerator<TType>, IEnumerator, IDisposable
	{
		private readonly List<IEnumerator<TType>> _enumerators;

		private int _index = -1;

		public TType Current
		{
			get
			{
				if (_index == -1 || _index >= _enumerators.Count)
				{
					return null;
				}
				return _enumerators[_index].Current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				if (_index == -1 || _index >= _enumerators.Count)
				{
					return null;
				}
				return _enumerators[_index].Current;
			}
		}

		public XbimIPersistIfcEntityCollectionEnumerator(Dictionary<IModel, HashSet<TType>> collection)
		{
			_enumerators = new List<IEnumerator<TType>>();
			foreach (HashSet<TType> value in collection.Values)
			{
				_enumerators.Add(value.GetEnumerator());
			}
		}

		public void Dispose()
		{
			foreach (IEnumerator<TType> enumerator2 in _enumerators)
			{
				enumerator2.Dispose();
			}
		}

		public bool MoveNext()
		{
			if (_index == -1)
			{
				_index = 0;
			}
			while (_index < _enumerators.Count)
			{
				if (_enumerators[_index].MoveNext())
				{
					return true;
				}
				_index++;
			}
			return false;
		}

		public void Reset()
		{
			foreach (IEnumerator<TType> enumerator2 in _enumerators)
			{
				enumerator2.Reset();
			}
			_index = -1;
		}
	}

	private readonly Dictionary<IModel, HashSet<TType>> _dictionary = new Dictionary<IModel, HashSet<TType>>();

	public int Count
	{
		get
		{
			int num = 0;
			foreach (HashSet<TType> value in _dictionary.Values)
			{
				num += value.Count;
			}
			return num;
		}
	}

	public bool IsReadOnly => false;

	public void Add(TType item)
	{
		if (!_dictionary.TryGetValue(item.Model, out var value))
		{
			_dictionary.Add(item.Model, new HashSet<TType> { item });
		}
		else
		{
			value.Add(item);
		}
	}

	public void Clear()
	{
		_dictionary.Clear();
	}

	public bool Contains(TType item)
	{
		if (_dictionary.TryGetValue(item.Model, out var value))
		{
			return value.Contains(item);
		}
		return false;
	}

	public void CopyTo(TType[] array, int arrayIndex)
	{
		foreach (KeyValuePair<IModel, HashSet<TType>> item in _dictionary)
		{
			item.Value.CopyTo(array, arrayIndex);
			arrayIndex += item.Value.Count;
		}
	}

	public bool Remove(TType item)
	{
		if (!_dictionary.TryGetValue(item.Model, out var value))
		{
			return false;
		}
		return value.Remove(item);
	}

	public IEnumerator<TType> GetEnumerator()
	{
		return new XbimIPersistIfcEntityCollectionEnumerator(_dictionary);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new XbimIPersistIfcEntityCollectionEnumerator(_dictionary);
	}
}
