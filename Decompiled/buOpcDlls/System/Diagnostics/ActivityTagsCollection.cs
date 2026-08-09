using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(1)]
[System_002EDiagnostics_002EDiagnosticSource_002ENullable(0)]
[ComVisible(true)]
public class ActivityTagsCollection : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(0)]
	public struct Enumerator : IEnumerator<KeyValuePair<string, object>>, IDisposable, IEnumerator
	{
		private List<KeyValuePair<string, object>>.Enumerator _enumerator;

		[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })]
		public KeyValuePair<string, object> Current
		{
			[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })]
			get
			{
				return _enumerator.Current;
			}
		}

		[System_002EDiagnostics_002EDiagnosticSource_002ENullable(1)]
		object IEnumerator.Current => ((IEnumerator)_enumerator).Current;

		internal Enumerator(List<KeyValuePair<string, object>> list)
		{
			_enumerator = list.GetEnumerator();
		}

		public void Dispose()
		{
			_enumerator.Dispose();
		}

		public bool MoveNext()
		{
			return _enumerator.MoveNext();
		}

		void IEnumerator.Reset()
		{
			((IEnumerator)_enumerator).Reset();
		}
	}

	private List<KeyValuePair<string, object>> _list = new List<KeyValuePair<string, object>>();

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)]
	public object this[string key]
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)]
		get
		{
			int num = FindIndex(key);
			if (num >= 0)
			{
				return _list[num].Value;
			}
			return null;
		}
		[param: System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)]
		set
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			int num = FindIndex(key);
			if (value == null)
			{
				if (num >= 0)
				{
					_list.RemoveAt(num);
				}
			}
			else if (num >= 0)
			{
				_list[num] = new KeyValuePair<string, object>(key, value);
			}
			else
			{
				_list.Add(new KeyValuePair<string, object>(key, value));
			}
		}
	}

	public ICollection<string> Keys
	{
		get
		{
			List<string> list = new List<string>(_list.Count);
			foreach (KeyValuePair<string, object> item in _list)
			{
				list.Add(item.Key);
			}
			return list;
		}
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 2 })]
	public ICollection<object> Values
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 2 })]
		get
		{
			List<object> list = new List<object>(_list.Count);
			foreach (KeyValuePair<string, object> item in _list)
			{
				list.Add(item.Value);
			}
			return list;
		}
	}

	public bool IsReadOnly => false;

	public int Count => _list.Count;

	public ActivityTagsCollection()
	{
	}

	public ActivityTagsCollection([System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 0, 1, 2 })] IEnumerable<KeyValuePair<string, object>> list)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		foreach (KeyValuePair<string, object> item in list)
		{
			if (item.Key != null)
			{
				this[item.Key] = item.Value;
			}
		}
	}

	public void Add(string key, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] object value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		int num = FindIndex(key);
		if (num >= 0)
		{
			throw new InvalidOperationException(System_002EDiagnostics_002EDiagnosticSource3462135_002ESR.Format(System_002EDiagnostics_002EDiagnosticSource3462135_002ESR.KeyAlreadyExist, key));
		}
		_list.Add(new KeyValuePair<string, object>(key, value));
	}

	public void Add([System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> item)
	{
		if (item.Key == null)
		{
			throw new ArgumentNullException("item");
		}
		int num = FindIndex(item.Key);
		if (num >= 0)
		{
			throw new InvalidOperationException(System_002EDiagnostics_002EDiagnosticSource3462135_002ESR.Format(System_002EDiagnostics_002EDiagnosticSource3462135_002ESR.KeyAlreadyExist, item.Key));
		}
		_list.Add(item);
	}

	public void Clear()
	{
		_list.Clear();
	}

	public bool Contains([System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> item)
	{
		return _list.Contains(item);
	}

	public bool ContainsKey(string key)
	{
		return FindIndex(key) >= 0;
	}

	public void CopyTo([System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 0, 1, 2 })] KeyValuePair<string, object>[] array, int arrayIndex)
	{
		_list.CopyTo(array, arrayIndex);
	}

	IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
	{
		return new Enumerator(_list);
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(_list);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(_list);
	}

	public bool Remove(string key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		int num = FindIndex(key);
		if (num >= 0)
		{
			_list.RemoveAt(num);
			return true;
		}
		return false;
	}

	public bool Remove([System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 1, 2 })] KeyValuePair<string, object> item)
	{
		return _list.Remove(item);
	}

	public bool TryGetValue(string key, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] out object value)
	{
		int num = FindIndex(key);
		if (num >= 0)
		{
			value = _list[num].Value;
			return true;
		}
		value = null;
		return false;
	}

	private int FindIndex(string key)
	{
		for (int i = 0; i < _list.Count; i++)
		{
			if (_list[i].Key == key)
			{
				return i;
			}
		}
		return -1;
	}
}
