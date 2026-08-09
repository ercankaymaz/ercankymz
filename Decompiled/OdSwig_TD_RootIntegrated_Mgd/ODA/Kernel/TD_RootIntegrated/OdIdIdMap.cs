using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIdIdMap : IDisposable, IDictionary<ulong, ulong>, ICollection<KeyValuePair<ulong, ulong>>, IEnumerable<KeyValuePair<ulong, ulong>>, IEnumerable
{
	public class OdIdIdMapEnumerator : IEnumerator, IEnumerator<KeyValuePair<ulong, ulong>>, IDisposable
	{
		private OdIdIdMap collectionRef;

		private IList<ulong> keyCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public KeyValuePair<ulong, ulong> Current
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
				return (KeyValuePair<ulong, ulong>)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdIdIdMapEnumerator(OdIdIdMap collection)
		{
			collectionRef = collection;
			keyCollection = new List<ulong>(collection.Keys);
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
					ulong key = keyCollection[currentIndex];
					currentObject = new KeyValuePair<ulong, ulong>(key, collectionRef[key]);
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

	public ulong this[ulong key]
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

	public ICollection<ulong> Keys
	{
		get
		{
			ICollection<ulong> collection = new List<ulong>();
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

	public ICollection<ulong> Values
	{
		get
		{
			ICollection<ulong> collection = new List<ulong>();
			using OdIdIdMapEnumerator odIdIdMapEnumerator = GetEnumerator();
			while (odIdIdMapEnumerator.MoveNext())
			{
				collection.Add(odIdIdMapEnumerator.Current.Value);
			}
			return collection;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIdIdMap(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIdIdMap obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdIdIdMap()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIdIdMap(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool TryGetValue(ulong key, out ulong value)
	{
		if (ContainsKey(key))
		{
			value = this[key];
			return true;
		}
		value = 0uL;
		return false;
	}

	public void Add(KeyValuePair<ulong, ulong> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Remove(KeyValuePair<ulong, ulong> item)
	{
		if (Contains(item))
		{
			return Remove(item.Key);
		}
		return false;
	}

	public bool Contains(KeyValuePair<ulong, ulong> item)
	{
		if (this[item.Key] == item.Value)
		{
			return true;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<ulong, ulong>[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(KeyValuePair<ulong, ulong>[] array, int arrayIndex)
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
		IList<ulong> list = new List<ulong>(Keys);
		for (int i = 0; i < list.Count; i++)
		{
			ulong key = list[i];
			array.SetValue(new KeyValuePair<ulong, ulong>(key, this[key]), arrayIndex + i);
		}
	}

	IEnumerator<KeyValuePair<ulong, ulong>> IEnumerable<KeyValuePair<ulong, ulong>>.GetEnumerator()
	{
		return new OdIdIdMapEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdIdIdMapEnumerator(this);
	}

	public OdIdIdMapEnumerator GetEnumerator()
	{
		return new OdIdIdMapEnumerator(this);
	}

	public OdIdIdMap()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdIdIdMap__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdIdIdMap(OdIdIdMap other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdIdIdMap__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private ulong getitem(ulong key)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_getitem(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(ulong key, ulong x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_setitem(swigCPtr, key, x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ContainsKey(ulong key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_ContainsKey(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Add(ulong key, ulong value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_Add(swigCPtr, key, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Remove(ulong key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_Remove(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_create_iterator_begin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private ulong get_next_key(IntPtr swigiterator)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_get_next_key(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdIdIdMap_destroy_iterator(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
