using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class std_map_OdString_OdString : IDisposable, IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable
{
	public class std_map_OdString_OdStringEnumerator : IEnumerator, IEnumerator<KeyValuePair<string, string>>, IDisposable
	{
		private std_map_OdString_OdString collectionRef;

		private IList<string> keyCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public KeyValuePair<string, string> Current
		{
			get
			{
				if (currentIndex == -1)
				{
					throw new InvalidOperationException("Enumeration not started.");
				}
				if (currentIndex > currentSize - 1)
				{
					throw new InvalidOperationException("Enumeration finished.");
				}
				if (currentObject == null)
				{
					throw new InvalidOperationException("Collection modified.");
				}
				return (KeyValuePair<string, string>)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public std_map_OdString_OdStringEnumerator(std_map_OdString_OdString collection)
		{
			collectionRef = collection;
			keyCollection = new List<string>(collection.Keys);
			currentIndex = -1;
			currentObject = null;
			currentSize = collectionRef.Count;
		}

		public bool MoveNext()
		{
			int count = collectionRef.Count;
			int num;
			if (currentIndex + 1 < count)
			{
				num = ((count == currentSize) ? 1 : 0);
				if (num != 0)
				{
					currentIndex++;
					string key = keyCollection[currentIndex];
					currentObject = new KeyValuePair<string, string>(key, collectionRef[key]);
					return (byte)num != 0;
				}
			}
			else
			{
				num = 0;
			}
			currentObject = null;
			return (byte)num != 0;
		}

		public void Reset()
		{
			currentIndex = -1;
			currentObject = null;
			if (collectionRef.Count != currentSize)
			{
				throw new InvalidOperationException("Collection modified.");
			}
		}

		public void Dispose()
		{
			currentIndex = -1;
			currentObject = null;
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public string this[string key]
	{
		get
		{
			return getitem(key);
		}
		set
		{
			setitem(key, value);
		}
	}

	public int Count => (int)size();

	public bool IsReadOnly => false;

	public ICollection<string> Keys
	{
		get
		{
			ICollection<string> collection = new List<string>();
			int count = Count;
			if (count > 0)
			{
				IntPtr swigiterator = create_iterator_begin();
				for (int i = 0; i < count; i++)
				{
					collection.Add(get_next_key(swigiterator));
				}
				destroy_iterator(swigiterator);
			}
			return collection;
		}
	}

	public ICollection<string> Values
	{
		get
		{
			ICollection<string> collection = new List<string>();
			using std_map_OdString_OdStringEnumerator std_map_OdString_OdStringEnumerator2 = GetEnumerator();
			while (std_map_OdString_OdStringEnumerator2.MoveNext())
			{
				collection.Add(std_map_OdString_OdStringEnumerator2.Current.Value);
			}
			return collection;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public std_map_OdString_OdString(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(std_map_OdString_OdString obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~std_map_OdString_OdString()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_std_map_OdString_OdString(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool TryGetValue(string key, out string value)
	{
		if (ContainsKey(key))
		{
			value = this[key];
			return true;
		}
		value = null;
		return false;
	}

	public void Add(KeyValuePair<string, string> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Remove(KeyValuePair<string, string> item)
	{
		if (Contains(item))
		{
			return Remove(item.Key);
		}
		return false;
	}

	public bool Contains(KeyValuePair<string, string> item)
	{
		if (this[item.Key] == item.Value)
		{
			return true;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<string, string>[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
		}
		if (array.Rank > 1)
		{
			throw new ArgumentException("Multi dimensional array.", "array");
		}
		if (arrayIndex + Count > array.Length)
		{
			throw new ArgumentException("Number of elements to copy is too large.");
		}
		IList<string> list = new List<string>(Keys);
		for (int i = 0; i < list.Count; i++)
		{
			string key = list[i];
			array.SetValue(new KeyValuePair<string, string>(key, this[key]), arrayIndex + i);
		}
	}

	IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
	{
		return new std_map_OdString_OdStringEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new std_map_OdString_OdStringEnumerator(this);
	}

	public std_map_OdString_OdStringEnumerator GetEnumerator()
	{
		return new std_map_OdString_OdStringEnumerator(this);
	}

	public std_map_OdString_OdString()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_map_OdString_OdString__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_map_OdString_OdString(std_map_OdString_OdString other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_map_OdString_OdString__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private string getitem(string key)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_getitem(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(string key, string x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_setitem(swigCPtr, key, x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ContainsKey(string key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_ContainsKey(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Add(string key, string value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_Add(swigCPtr, key, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Remove(string key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_Remove(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_create_iterator_begin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private string get_next_key(IntPtr swigiterator)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_get_next_key(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.std_map_OdString_OdString_destroy_iterator(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
