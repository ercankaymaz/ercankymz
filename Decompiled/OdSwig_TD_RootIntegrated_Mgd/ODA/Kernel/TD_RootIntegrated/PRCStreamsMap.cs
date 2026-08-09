using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class PRCStreamsMap : IDisposable, IDictionary<uint, OdStreamBuf>, ICollection<KeyValuePair<uint, OdStreamBuf>>, IEnumerable<KeyValuePair<uint, OdStreamBuf>>, IEnumerable
{
	public class PRCStreamsMapEnumerator : IEnumerator, IEnumerator<KeyValuePair<uint, OdStreamBuf>>, IDisposable
	{
		private PRCStreamsMap collectionRef;

		private IList<uint> keyCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public KeyValuePair<uint, OdStreamBuf> Current
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
				return (KeyValuePair<uint, OdStreamBuf>)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public PRCStreamsMapEnumerator(PRCStreamsMap collection)
		{
			collectionRef = collection;
			keyCollection = new List<uint>(collection.Keys);
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
					uint key = keyCollection[currentIndex];
					currentObject = new KeyValuePair<uint, OdStreamBuf>(key, collectionRef[key]);
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

	public OdStreamBuf this[uint key]
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

	public ICollection<uint> Keys
	{
		get
		{
			ICollection<uint> collection = new List<uint>();
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

	public ICollection<OdStreamBuf> Values
	{
		get
		{
			ICollection<OdStreamBuf> collection = new List<OdStreamBuf>();
			using PRCStreamsMapEnumerator pRCStreamsMapEnumerator = GetEnumerator();
			while (pRCStreamsMapEnumerator.MoveNext())
			{
				collection.Add(pRCStreamsMapEnumerator.Current.Value);
			}
			return collection;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PRCStreamsMap(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PRCStreamsMap obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~PRCStreamsMap()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_PRCStreamsMap(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool TryGetValue(uint key, out OdStreamBuf value)
	{
		if (ContainsKey(key))
		{
			value = this[key];
			return true;
		}
		value = null;
		return false;
	}

	public void Add(KeyValuePair<uint, OdStreamBuf> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Remove(KeyValuePair<uint, OdStreamBuf> item)
	{
		if (Contains(item))
		{
			return Remove(item.Key);
		}
		return false;
	}

	public bool Contains(KeyValuePair<uint, OdStreamBuf> item)
	{
		if (this[item.Key] == item.Value)
		{
			return true;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<uint, OdStreamBuf>[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(KeyValuePair<uint, OdStreamBuf>[] array, int arrayIndex)
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
		IList<uint> list = new List<uint>(Keys);
		for (int i = 0; i < list.Count; i++)
		{
			uint key = list[i];
			array.SetValue(new KeyValuePair<uint, OdStreamBuf>(key, this[key]), arrayIndex + i);
		}
	}

	IEnumerator<KeyValuePair<uint, OdStreamBuf>> IEnumerable<KeyValuePair<uint, OdStreamBuf>>.GetEnumerator()
	{
		return new PRCStreamsMapEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new PRCStreamsMapEnumerator(this);
	}

	public PRCStreamsMapEnumerator GetEnumerator()
	{
		return new PRCStreamsMapEnumerator(this);
	}

	public PRCStreamsMap()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_PRCStreamsMap__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public PRCStreamsMap(PRCStreamsMap other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_PRCStreamsMap__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdStreamBuf getitem(uint key)
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_getitem(swigCPtr, key), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(uint key, OdStreamBuf x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_setitem(swigCPtr, key, OdStreamBuf.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ContainsKey(uint key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_ContainsKey(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Add(uint key, OdStreamBuf value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_Add(swigCPtr, key, OdStreamBuf.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Remove(uint key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_Remove(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_create_iterator_begin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint get_next_key(IntPtr swigiterator)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_get_next_key(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.PRCStreamsMap_destroy_iterator(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
